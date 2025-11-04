using ECommerceAPI.Models;
using ECommerceAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repository.Implementation
{
    public class UsersRepository:IUsersRepository
    {
        private readonly EcommerceDbContext _context;

        public UsersRepository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                // Log to console for now (in real app, use logger)
                Console.WriteLine($"Error in AddUserAsync: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                // Rethrow to be caught by controller
                throw;
            }
        }


        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> ValidateUserAsync(string userName, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);
        }

    }
}
