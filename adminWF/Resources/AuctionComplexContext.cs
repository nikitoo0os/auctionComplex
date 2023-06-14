using auctionComplex.Classes;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace auctionComplex.Resources
{
    internal partial class AuctionComplexContext : DbContext
    {

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<AuctionChat> AuctionChats { get; set; }
        public DbSet<AuctionItem> AuctionItems { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public AuctionComplexContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["AuctionComplexDatabase"].ConnectionString);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=auction_complex_m;Username=postgres;Password=1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionItem>()
                .HasOne(a => a.Winner)
                .WithMany(u => u.WinAuctionItems)
                .HasForeignKey(a => a.WinnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
