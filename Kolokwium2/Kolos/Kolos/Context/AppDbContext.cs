using Kolos.Components;
using Kolos.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolos.Context;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Discount> Discounts  { get; set; }
    public DbSet<Payment> Payments  { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Subscription> Subscriptions{ get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ClientEF());
        modelBuilder.ApplyConfiguration(new  DiscountEF());
        modelBuilder.ApplyConfiguration(new PaymentEF());
        modelBuilder.ApplyConfiguration(new SaleEF());
        modelBuilder.ApplyConfiguration(new SubscriptionEF());
    }
}