namespace Backend.DTOs
{
    public class UserDTO
    {
        public required Guid UserId { get; set; }
        public required string Username { get; set; }
    }
}
