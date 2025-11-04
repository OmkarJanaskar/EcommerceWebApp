using ECommerceAPI.Models;
using System.Threading.Tasks;

namespace ECommerceAPI.Repository.Interface
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> ValidateUserAsync(string userName, string password);

    }
}
