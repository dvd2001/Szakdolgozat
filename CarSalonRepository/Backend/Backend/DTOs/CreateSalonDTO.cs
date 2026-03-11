namespace Backend.DTOs
{
    public class CreateSalonDTO
    {
        public required string Name { get; set; } = default!;
        public required string Address { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? Website { get; set; } = default!;
        public IEnumerable<CreateCarDTO> Cars { get; set; } = new List<CreateCarDTO>();
    }
}
