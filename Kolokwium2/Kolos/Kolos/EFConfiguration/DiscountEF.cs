using Kolos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos.Components;

public class DiscountEF : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discount");

        builder.HasKey(d => d.IdDiscount);
        builder.Property(d => d.Value);
        builder.Property(d => d.DateFrom);
        builder.Property(d => d.DateTo);
        builder.HasOne(d => d.Subscription).WithMany().HasForeignKey(d => d.IdSubscription);
    }
}