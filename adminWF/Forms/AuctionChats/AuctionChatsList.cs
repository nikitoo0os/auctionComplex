using auctionComplex.Classes;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Services;
using auctionComplex.Services.AuctionItems;
using System.Collections.Generic;
using System.Windows.Forms;

namespace auctionComplex.Forms.AuctionChats
{
    public partial class AuctionChatsList : Form
    {
        private List<AuctionChat> AuctionChats;
        public AuctionChatsList()
        {
            InitializeComponent();
        }

        private void AuctionChatsList_Load(object sender, System.EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            Text = "Список аукционных чатов";
            AuctionChats = AuctionChatService.GetAllAuctionChats();
            AuctionChatsGrid.DataSource = AuctionChats;
            AuctionChatsGrid.Refresh();


            AuctionChatsGrid.Columns["Id"].HeaderText = "№";
            AuctionChatsGrid.Columns["AuctionItemId"].HeaderText = "№ аукциона";
            AuctionChatsGrid.Columns["AuctionItem"].Visible = false;
            AuctionChatsGrid.Columns["UserChats"].Visible = false;
            AuctionChatsGrid.ClearSelection();
            CountChatLabel.Text = $"Чатов найдено: {AuctionChatsGrid.RowCount}";
        }

        private void ShowChatMessages(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = AuctionChatsGrid.Rows[e.RowIndex];

                int auctionChatId = (int)selectedRow.Cells["Id"].Value;

                ShowAuctionChatDetails(auctionChatId);
            }

        }

        private void ShowAuctionChatDetails(int auctionChatId)
        {
            ChatMessagesList chatMessagesList = new ChatMessagesList();
            chatMessagesList.AuctionChat = AuctionChatService.GetAuctionChatById(auctionChatId);

            chatMessagesList.Show();
        }
    }
}
