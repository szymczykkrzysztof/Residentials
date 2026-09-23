using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservations", t =>
        {
            t.HasCheckConstraint("CK_Reservations_Dates", """ "EndDate" > "StartDate" """);
            t.HasCheckConstraint("CK_Reservations_Guests", """ "Guests" > 0 """);
            t.HasCheckConstraint("CK_Reservations_TotalPrice", """ "TotalPrice" > 0 """);
        });

        builder.Property(r => r.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(r => r.TotalPrice).HasPrecision(10, 2);
        builder.Property(r => r.CreatedAt).HasDefaultValueSql("now()");

        builder.HasOne(r => r.Apartment)
            .WithMany(a => a.Reservations)
            .HasForeignKey(r => r.ApartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Tenant)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}