using Backend.Models;
using Backend.Database;
using Backend.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<User> EditUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new RepositoryException($"User with ID {userId} not found.");
            }
            return user;
        }
        public async Task<User> DeleteUserById(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new RepositoryException($"User with ID {userId} not found.");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> ClearUserRepository()
        {
            var users = await _context.Users.ToListAsync();
            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<User> Login(string username, string hashedPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == hashedPassword);
            if (user == null)
            {
                throw new RepositoryException("Invalid username or password.");
            }
            return user;
        }
    }
}
