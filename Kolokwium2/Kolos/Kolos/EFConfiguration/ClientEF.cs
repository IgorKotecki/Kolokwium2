using Kolos.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos.Components;

public class ClientEF : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(c => c.IdClient);
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.Property(c => c.LastName).HasMaxLength(100);
        builder.Property(c => c.Email).HasMaxLength(100);
        builder.Property(c => c.Phoen).HasMaxLength(100);
        builder.HasOne(c => c.Sales).WithMany().HasForeignKey(s => s.IdSale);
    }
}