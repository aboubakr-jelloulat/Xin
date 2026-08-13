using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Domain.Models;
using System.Reflection;

namespace Ordering.Infrastructure.AppDbContext;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    /// <summary>
    /// "It's basically the Open/Closed Principle applied to EF Core configuration you extend by adding new configuration classes, without modifying OnModelCreating.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        ///
        /// automatically scans an assembly (a compiled .dll) for every class implementing IEntityTypeConfiguration<T>, 
        /// instantiates them, and applies each one to the model so you don't have to manually call ApplyConfiguration(new XxxConfiguration()) 
        /// for every entity in OnModelCreating. 
        /// It uses reflection under the hood, and any new configuration class you add gets picked up automatically at runtime, 
        /// with no need to touch the DbContext again.
        ///

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}
