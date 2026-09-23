using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public ICollection<Apartment> Apartments { get; set; } = default!;
    public ICollection<Reservation> Reservations { get; set; } = default!;
}