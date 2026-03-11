using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [PrimaryKey("UserId")]
    public class User
    {
        public required Guid UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
