using Kolos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos.Components;

public class SaleEF :IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");

        builder.HasKey(s => s.IdSale);
        builder.Property(s => s.CreatedAt);
        builder.HasOne(s => s.Client).WithMany().HasForeignKey(s => s.IdClient);
        builder.HasOne(s => s.Subscription).WithMany().HasForeignKey(s => s.IdSubscription);
    }
}