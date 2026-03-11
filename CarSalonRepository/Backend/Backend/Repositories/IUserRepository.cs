using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
        Task<User> EditUser(User user);
        Task<User> DeleteUserById(Guid userId);
        Task<IEnumerable<User>> ClearUserRepository();
        Task<User> Login(string username, string hashedPassword);
    }
}
