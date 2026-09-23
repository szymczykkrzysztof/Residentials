namespace Domain.Entities;

public class Apartment
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public string City { get; set; } = default!;
    public string Street { get; set; } = default!;
    public decimal PricePerNight { get; set; }
    public int MaxGuests { get; set; }
    public TimeOnly CheckInFrom { get; set; } = new(15, 0);
    public TimeOnly CheckOutUntil { get; set; } = new(10, 0);
    public DateTimeOffset CreatedAt { get; set; }

    public Guid OwnerId { get; set; }
    public ApplicationUser Owner { get; set; } = default!;
    public ICollection<Reservation> Reservations { get; set; } = [];
}