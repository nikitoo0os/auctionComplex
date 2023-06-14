using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auctionComplex.Classes
{
    [Table("wallets")]
    internal class Wallet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("address"), MaxLength(48)]
        public string Address { get; set; }

        [Column("balance")]
        public double Balance { get; set; }

        public User User { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
