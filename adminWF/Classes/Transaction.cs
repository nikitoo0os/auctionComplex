using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace auctionComplex.Classes
{
    [Table("transactions")]
    internal class Transaction
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }
        
        public Wallet SenderWallet { get; set; }

        [Column("sender_wallet_id")]
        public int SenderWalletId { get; set; }

        public Wallet ReceiverWallet { get; set; }

        [Column("receiver_wallet_id")]
        public int ReceiverWalletId { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; } 

    }
}
