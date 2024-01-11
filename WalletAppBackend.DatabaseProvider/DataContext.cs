using Microsoft.EntityFrameworkCore;
using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend.DatabaseProvider
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DataContext(DbContextOptions options): base(options)
        {         
        }
    }
}
