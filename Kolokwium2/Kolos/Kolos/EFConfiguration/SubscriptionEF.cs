using Kolos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos.Components;

public class SubscriptionEF : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscription");

        builder.HasKey(s => s.IdSubscription);
        builder.Property(s => s.Name).HasMaxLength(100);
        builder.Property(s => s.RenewalPeriod);
        builder.Property(s => s.EndTime);
        builder.Property(s => s.Price);
        
    }
}