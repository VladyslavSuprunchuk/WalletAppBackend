namespace WalletAppBackend.DatabaseProvider.Models
{
    public class User
    {
        public int Id { get; set; }

        public int Points { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime? DateOfPointsSum { get;set; }

        public ICollection<Card> Cards { get; set; }
    }
}
