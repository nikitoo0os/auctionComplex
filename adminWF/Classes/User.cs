using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace auctionComplex.Classes
{
    [Table("users")]
    internal class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name"), MaxLength(100)]
        public string FirstName { get; set; }

        [Column("second_name"), MaxLength(100)]
        public string SecondName { get; set; }

        [Column("email"), MaxLength(100)]
        public string Email { get; set; }

        [Column("username"), MaxLength(100)]
        public string Username { get; set; }

        [Column("password"), MaxLength(100)]
        public string Password { get; set; }

        [Column("is_admin")]
        public bool IsAdmin { get; set; }

        [Column("is_verify")]
        public bool IsVerify { get; set; }

        [Column("date_of_registration")]
        public DateTimeOffset DateOfRegistration { get; set; }

        public virtual ICollection<Wallet> Wallets { get; } = new List<Wallet>();
        public virtual ICollection<Bid> Bids { get; } = new List<Bid>();
        public List<AuctionItem> WinAuctionItems { get; } = new List<AuctionItem>();
        public List<AuctionItem> MyAuctionItems { get; } = new List<AuctionItem>();
        public virtual ICollection<ChatMessage> ChatMessages { get; } = new List<ChatMessage>();
        public virtual ICollection<UserChat> UserChats { get; } = new List<UserChat>();
    }
}
