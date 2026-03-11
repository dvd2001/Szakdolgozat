namespace Backend.DTOs
{
    public class SalonDTO
    {
        public required Guid SalonId { get; set; }
        public required string Name { get; set; } = default!;
        public required string Address { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? Website { get; set; } = default!;
        public IEnumerable<string> CarIds { get; set; } = new List<string>();
    }
}
