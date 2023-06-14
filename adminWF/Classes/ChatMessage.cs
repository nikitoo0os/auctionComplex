using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace auctionComplex.Classes
{
    [Table("chat_messages")]
    internal class ChatMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("text"), MaxLength(250)]
        public string Text { get; set; }

        public AuctionChat AuctionChat { get; set; }
        [Column("AuctionChatId")]
        public int AuctionChatId { get; set; }

        public User User { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }

        public Attachment Attachment { get; set; }
        [Column("AttachmentId")]
        public int AttachmentId { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
