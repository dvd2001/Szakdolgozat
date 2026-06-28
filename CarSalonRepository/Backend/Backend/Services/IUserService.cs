using Backend.DTOs;

namespace Backend.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(CreateUserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(Guid userId);
        Task<UserDTO> EditUser(EditUserDTO user, Guid userId);
        Task<UserDTO> DeleteUserById(Guid userId);
        Task<IEnumerable<UserDTO>> DeleteAllUsers();
        Task<UserDTO> Login(string username, string password);
    }
}
