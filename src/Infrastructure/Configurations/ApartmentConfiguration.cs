using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
        builder.ToTable("Apartments", t =>
        {
            t.HasCheckConstraint("CK_Apartments_PricePerNight", """ "PricePerNight" > 0 """);
            t.HasCheckConstraint("CK_Apartments_MaxGuests", """ "MaxGuests" > 0 """);
        });

        builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Description).HasMaxLength(2000);
        builder.Property(a => a.City).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Street).IsRequired().HasMaxLength(200);
        builder.Property(a => a.PricePerNight).HasPrecision(10, 2);

        builder.Property(a => a.CheckInFrom).HasDefaultValue(new TimeOnly(15, 0));
        builder.Property(a => a.CheckOutUntil).HasDefaultValue(new TimeOnly(10, 0));
        builder.Property(a => a.CreatedAt).HasDefaultValueSql("now()");

        builder.HasIndex(a => a.City);

        builder.HasOne(a => a.Owner)
            .WithMany(u => u.Apartments)
            .HasForeignKey(a => a.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}