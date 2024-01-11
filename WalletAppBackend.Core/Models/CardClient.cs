using WalletAppBackend.Core.Constants;

namespace WalletAppBackend.Core.Models
{
    public class CardClient
    {
        public int Id { get; set; }

        public decimal Balance { get; set; }

        public decimal MaxLimit { get; set; } = MagicNumbers.Max_Limit;

        public decimal Available { get { return MaxLimit - Balance; } }
    }
}
