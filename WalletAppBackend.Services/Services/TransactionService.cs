using WalletAppBackend.DatabaseProvider;
using WalletAppBackend.DatabaseProvider.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;

        public TransactionService(DataContext dataContext, IUserService userService)
        {
            _dataContext = dataContext;
            _userService = userService;
        }

        public List<Transaction> GetTransactions(int userId)
        {
            var transactions = _dataContext.Transactions.Where(x => x.UserRecipientId == userId || x.UserSenderId == userId);
            var lastTransactions = transactions.ToList().TakeLast(10).ToList();

            return lastTransactions;
        }

        public async Task<Transaction> CreateAsync(Transaction transaction)
        {
            transaction.UserRecipient = await _userService.GetUserAsync(transaction.UserRecipientId);
            transaction.UserSender = await _userService.GetUserAsync(transaction.UserSenderId);

            await _dataContext.Transactions.AddAsync(transaction);

            await _dataContext.SaveChangesAsync();

            return transaction;
        }
    }
}
