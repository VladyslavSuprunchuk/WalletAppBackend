namespace WalletAppBackend.DatabaseProvider.Models
{
    public class Card
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
