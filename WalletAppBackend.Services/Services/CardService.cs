using Microsoft.EntityFrameworkCore;
using WalletAppBackend.Core.Constants;
using WalletAppBackend.DatabaseProvider;
using WalletAppBackend.DatabaseProvider.Models;
using WalletAppBackend.Services.Interfaces;

namespace WalletAppBackend.Services.Services
{
    public class CardService : ICardService
    {
        private readonly DataContext _dataContext;

        public CardService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Card> CreateCardAsync(int userId)
        {
            var randomGenerator = new Random();
            var card = new Card()
            {
                UserId = userId,
                Balance = randomGenerator.Next(0, MagicNumbers.Max_Limit),
            };

            await _dataContext.Cards.AddAsync(card);
            await _dataContext.SaveChangesAsync();

            return card;
        }

        public async Task<Card> GetCardAsync(int userId, int cardId)
        {
            var card = await _dataContext.Cards.FirstOrDefaultAsync(x => x.Id == cardId && x.UserId == userId);

            return card;
        }
    }
}
