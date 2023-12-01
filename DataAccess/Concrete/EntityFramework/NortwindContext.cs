using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;
public class NortwindContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // docker & azure data studio with ms sql server
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=northwind;
        User Id=SA;Password=reallyStrongPwd123;Trusted_Connection=false;TrustServerCertificate=True;
        MultiSubnetFailover=True");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}