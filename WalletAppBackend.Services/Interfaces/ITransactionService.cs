using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> CreateAsync(Transaction transaction);

        List<Transaction> GetTransactions(int userId);
    }
}
