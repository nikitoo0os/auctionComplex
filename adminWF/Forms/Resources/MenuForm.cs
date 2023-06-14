using auctionComplex.Classes.Security;
using auctionComplex.Forms.Attachments;
using auctionComplex.Forms.AuctionChats;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Forms.Bids;
using auctionComplex.Forms.Transactions;
using auctionComplex.Forms.Users;
using auctionComplex.Forms.Wallets;
using Npgsql;
using System;
using System.Windows.Forms;

namespace auctionComplex.Forms.Resources
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void UsersBtn_Click(object sender, EventArgs e)
        {
            new UsersList().Show();
        }

        private void ChatsBtn_Click(object sender, EventArgs e)
        {
            new AuctionChatsList().Show();
        }

        private void TransactionBtn_Click(object sender, EventArgs e)
        {
            new TransactionList().Show();
        }

        private void AuctionItemsBtn_Click(object sender, EventArgs e)
        {
            new AuctionItemsList().Show();
        }

        private void BidsBtn_Click(object sender, EventArgs e)
        {
            new BidList().Show();
        }

        private void WalletsBtn_Click(object sender, EventArgs e)
        {
            new WalletsList().Show();
        }

        private void AttachmentsBtn_Click(object sender, EventArgs e)
        {
            new AttachmentsList().Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Session.UserId = 0;
            Hide();
            new AuthorizationForm().Show();
        }

        
    }
}
