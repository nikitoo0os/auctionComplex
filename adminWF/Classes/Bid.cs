using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace auctionComplex.Classes
{
    [Table("bids")]
    internal class Bid
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("investment_volume")]
        public double InvestmentVolume { get; set; }

        [Column("entry_percentage")]
        public double EntryPercentage { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        public User User { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }

        
        public AuctionItem AuctionItem{ get; set; }
        [Column("auction_item_id")]
        public int AuctionItemId { get; set; }
    }
}
