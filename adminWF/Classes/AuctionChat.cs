using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace auctionComplex.Classes
{
    [Table("auction_chats")]
    internal class AuctionChat
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        public AuctionItem AuctionItem { get; set; }
        [Column("AuctionItemId")]
        public int AuctionItemId { get; set; }

        public virtual ICollection<UserChat> UserChats { get; } = new List<UserChat>();
    }
}
