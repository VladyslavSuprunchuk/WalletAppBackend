using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend.Services.Interfaces
{
    public interface ICardService
    {
        Task<Card> CreateCardAsync(int userId);

        Task<Card> GetCardAsync(int userId, int cardId);
    }
}
