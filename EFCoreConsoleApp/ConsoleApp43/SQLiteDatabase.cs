using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder, ModelBuilder
using Microsoft.EntityFrameworkCore.Diagnostics;

using Models; // Category, Product

namespace SQLiteDatabaseConfig;

// this manages the connection to the database
public class SQLiteDatabase : DbContext
{
    // these properties map to tables in the database
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Database.db");

        string connection = $"Filename={path}";

        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine($"Connection: {connection}");
        ForegroundColor = previousColor;

        optionsBuilder.UseSqlite(connection);

        /*        optionsBuilder
                    .LogTo(WriteLine) // Console
                    .EnableSensitiveDataLogging();*/
        optionsBuilder
            .LogTo(
                WriteLine, // Console
                new[] { RelationalEventId.CommandExecuting }
            )
            .EnableSensitiveDataLogging();

        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // example of using Fluent API instead of attributes
        // to limit the length of a category name to 15
        modelBuilder
            .Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // NOT NULL
            .HasMaxLength(15);
        if (Database.ProviderName?.Contains("Sqlite") ?? false)
        {
            // added to "fix" the lack of decimal support in SQLite
            modelBuilder
                .Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }

        modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Discontinued);
    }
}
