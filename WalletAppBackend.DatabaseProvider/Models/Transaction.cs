using WalletAppBackend.Core.Enums;

namespace WalletAppBackend.DatabaseProvider.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public TransactionType Type { get; set; }

        public decimal Amount { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public int UserSenderId { get; set; }
        public User UserSender { get; set; }

        public int UserRecipientId {  get; set; }
        public User UserRecipient { get; set; }

        public bool Pending { get; set; }
    }
}
