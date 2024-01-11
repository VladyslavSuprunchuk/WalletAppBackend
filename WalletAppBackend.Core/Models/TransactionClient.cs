using WalletAppBackend.Core.Enums;

namespace WalletAppBackend.Core.Models
{
    public class TransactionClient
    {
        public int Id { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int UserSenderId { get; set; }

        public int UserRecipientId { get; set; }

        public bool Pending { get; set; }
    }
}
