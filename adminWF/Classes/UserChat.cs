using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace auctionComplex.Classes
{
    [Table("user_chats")]
    internal class UserChat
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public User User { get; set; }

        [Column("chat_id")]
        public AuctionChat AuctionChat { get; set; }
    }
}
