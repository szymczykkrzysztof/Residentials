using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public required ICollection<Apartment> Apartments { get; set; }
    public required ICollection<Reservation> Reservations { get; set; }
}