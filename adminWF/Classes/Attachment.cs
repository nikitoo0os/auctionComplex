using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auctionComplex.Classes
{
    [Table("attachments")]
    internal class Attachment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("key"), MaxLength(250)]
        public string Key { get; set; }

        [Column("name"), MaxLength(250)]
        public string Name { get; set; }

        [Column("file_size")]
        public double FileSize { get; set; }

        [Column("file_type"), MaxLength(250)]
        public string FileType { get; set; }

        [Column("timestamp")]
        public DateTime Timestamp { get; set; }

        public virtual ICollection<ChatMessage> chatMessages { get; } = new List<ChatMessage>();
    }
}
