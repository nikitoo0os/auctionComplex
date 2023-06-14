using auctionComplex.Classes;
using auctionComplex.Forms.Bids;
using auctionComplex.Services;
using auctionComplex.Services.AuctionItems;
using System;
using System.Windows.Forms;

namespace auctionComplex.Forms.AuctionItems
{
    public partial class AuctionItemDetails : Form
    {
        internal AuctionItem AuctionItem;
        public AuctionItemDetails()
        {
            InitializeComponent();
        }

        private void AuctionItemDetails_Load(object sender, EventArgs e)
        {
            User Auctioneer = UserService.GetUserById(AuctionItem.AuctioneerId);

            Text += AuctionItem.Id;
            AuctioneerLabel.Text = $"{Auctioneer.Id}. {Auctioneer.SecondName} {Auctioneer.FirstName}";
            TitleLabel.Text = AuctionItem.Title;
            CategoryLabel.Text = AuctionItem.Category;
            DescriptionLabel.Text = AuctionItem.Description;
            LocationLabel.Text = AuctionItem.Location;
            VolumeInvLabel.Text = AuctionItem.InvestmentSize.ToString();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            SetIsValidAuctionItem("allow");
        }

        private void ToProcessedBtn_Click(object sender, EventArgs e)
        {
            SetIsValidAuctionItem("edit");
        }
        private void DismissBtn_Click(object sender, EventArgs e)
        {
            SetIsValidAuctionItem("dismiss");
        }

        private void SetIsValidAuctionItem(string isValid)
        {
            AuctionItem.IsValid = isValid;
            AuctionItemService.PutAuctionItem(AuctionItem);
            Hide();
            AuctionItemsList form = new AuctionItemsList();
            form.Activate();
        }

        private void ShowBidsBtn_Click(object sender, EventArgs e)
        {
            BidList bidList = new BidList();
            bidList.AuctionItem = AuctionItem;
            bidList.Show();
        }
    }
}
