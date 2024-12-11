using Microsoft.EntityFrameworkCore;
using Bookstore.Core.Models;

namespace API.Contexts;

public class RelationalDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.BookID);
        modelBuilder.Entity<Book>().Property(b => b.BookID).ValueGeneratedOnAdd();

        modelBuilder.Entity<Order>().HasKey(o => o.OrderID);
        modelBuilder.Entity<Order>().Property(o => o.OrderID).ValueGeneratedOnAdd();

        modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
        modelBuilder.Entity<Customer>().Property(c => c.CustomerID).ValueGeneratedOnAdd();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while saving changes to the database.", ex);
        }
    }
}
