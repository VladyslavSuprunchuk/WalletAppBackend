using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend.Services.Interfaces
{
    public interface IPointsService
    {
        Task<int> CalculatePointsAsync(int userId);
    }
}
