using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace auctionComplex.Classes
{
    [Table("auction_items")]
    internal class AuctionItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title"), MaxLength(250)]
        public string Title { get; set; }

        [Column("description"), MaxLength(1000)]
        public string Description { get; set; }

        [Column("investment_size")]
        public double InvestmentSize { get; set; }

        [Column("location"), MaxLength(500)]
        public string Location { get; set; }

        [Column("category"), MaxLength(100)]
        public string Category { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [ForeignKey("WinnerId")]
        public User Winner { get; set; }
        [Column("winner_id")]
        public int? WinnerId { get; set; }

        public User Auctioneer { get; set; }
        [Column("auctioneer_id")]
        public int AuctioneerId { get; set; }

        [Column("is_valid")]
        public string IsValid { get; set; } = "verification";

        public virtual ICollection<AuctionChat> AuctionChats { get; } = new List<AuctionChat>();
    }
}
