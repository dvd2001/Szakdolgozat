using Backend.DTOs;
using Backend.Repositories;
using Backend.Models;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Services
{
    public class UserService(IUserRepository userRepository, IDTOConversionService dtoConversionService) : IUserService
    {
        public async Task<UserDTO> CreateUser(CreateUserDTO user)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(user.Password);
                byte[] hashedPasswordBytes = mySHA256.ComputeHash(passwordBytes);
                var newUser = new User
                {
                    UserId = Guid.NewGuid(),
                    Username = user.Username,
                    Password = Convert.ToBase64String(hashedPasswordBytes)
                };
                var result = await userRepository.CreateUser(newUser);
                return dtoConversionService.ConvertUserToUserDTO(result);
            }
        }

        public async Task<IEnumerable<UserDTO>> DeleteAllUsers()
        {
            var result = await userRepository.ClearUserRepository();
            return result.Select(user => dtoConversionService.ConvertUserToUserDTO(user)).ToList();
        }

        public async Task<UserDTO> DeleteUserById(Guid userId)
        {
            var result = await userRepository.DeleteUserById(userId);
            return dtoConversionService.ConvertUserToUserDTO(result);
        }

        public async Task<UserDTO> EditUser(EditUserDTO user)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(user.Password);
                byte[] hashedPasswordBytes = mySHA256.ComputeHash(passwordBytes);
                var userToEdit = new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = Convert.ToBase64String(hashedPasswordBytes)
                };
                var result = await userRepository.EditUser(userToEdit);
                return dtoConversionService.ConvertUserToUserDTO(result);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var result = await userRepository.GetAllUsers();
            return result.Select(user => dtoConversionService.ConvertUserToUserDTO(user)).ToList();
        }

        public async Task<UserDTO> GetUserById(Guid userId)
        {
            var result = await userRepository.GetUserById(userId);
            return dtoConversionService.ConvertUserToUserDTO(result);
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedPasswordBytes = mySHA256.ComputeHash(passwordBytes);
                var hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
                var result = await userRepository.Login(username, hashedPassword);
                return dtoConversionService.ConvertUserToUserDTO(result);
            }
        }
    }
}
