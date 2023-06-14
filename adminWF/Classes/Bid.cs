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
        public int EntryPercentage { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("user_id")]
        public User User { get; set; }

        [Column("auction_id")]
        public AuctionItem AuctionItem{ get; set; }

    }
}
