namespace Backend.DTOs
{
    public class EditUserDTO
    {
        public required Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
