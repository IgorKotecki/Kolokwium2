using Kolos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos.Components;

public class PaymentEF :IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(p => p.IdPayment);
        builder.Property(p => p.Date);
        builder.HasOne(p => p.Client).WithMany().HasForeignKey(p => p.IdClient);
        builder.HasOne(p => p.SySubscription).WithMany().HasForeignKey(p => p.IdSubscription);
    }
}