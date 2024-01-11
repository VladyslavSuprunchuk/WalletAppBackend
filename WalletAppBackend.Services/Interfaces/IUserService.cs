using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);

        Task<User> CreateUserAsync(User user);
    }
}
