using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [PrimaryKey("SalonId")]
    public class Salon
    {
        public required Guid SalonId { get; set; }
        public required string Name { get; set; } = default!;
        public required string Address { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? Website { get; set; } = default!;
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
