
using Amazon.S3.Model;
using auctionComplex.Classes;
using auctionComplex.Services;
using System.Windows.Forms;

namespace auctionComplex.Forms.Bids
{
    public partial class BidList : Form
    {
        internal AuctionItem AuctionItem;
        internal User User;
        public BidList()
        {
            InitializeComponent();
        }

        private void BidList_Load(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void SearchBtn_Click(object sender, System.EventArgs e)
        {
            string filter = SearchInput.Text;
            BidGrid.DataSource = BidService.GetFilterBidList(filter);
            BidGrid.Refresh();
            BidsCountLabel.Text = $"Ставок найдено: {BidGrid.RowCount}";
        }

        private void RefreshBtn_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (User != null)
            {
                Text = $"Список ставок пользователя №{User.Id}";
                BidGrid.DataSource = BidService.GetBidsByUserId(User.Id);
                BidGrid.Refresh();
            }
            else if (User == null && AuctionItem == null)
            {
                Text = $"Список ставок";
                BidGrid.DataSource = BidService.GetAllBids();
                BidGrid.Refresh();
            }
            else
            {
                Text = $"Список ставок на аукционе №{AuctionItem.Id}";
                BidGrid.DataSource = BidService.GetBidsByAuctionId(AuctionItem.Id);
                BidGrid.Refresh();
            }

            BidGrid.Columns["Id"].HeaderText = "№";
            BidGrid.Columns["InvestmentVolume"].HeaderText = "Объём инвестиций";
            BidGrid.Columns["EntryPercentage"].HeaderText = "Процент входа";
            BidGrid.Columns["Timestamp"].HeaderText = "Дата ставки";
            BidGrid.Columns["User"].Visible = false;
            BidGrid.Columns["AuctionItem"].Visible = false;

            BidsCountLabel.Text = $"Ставок найдено: {BidGrid.RowCount}";
        }
    }
}
