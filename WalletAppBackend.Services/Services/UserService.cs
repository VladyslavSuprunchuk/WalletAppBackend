using Microsoft.EntityFrameworkCore;
using WalletAppBackend.DatabaseProvider;
using WalletAppBackend.DatabaseProvider.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dataContext.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }
    }
}
