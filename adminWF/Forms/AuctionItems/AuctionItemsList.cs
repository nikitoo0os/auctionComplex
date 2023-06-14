using auctionComplex.Classes;
using auctionComplex.Services.AuctionItems;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace auctionComplex.Forms.AuctionItems
{
    public partial class AuctionItemsList : Form
    {
        private List<AuctionItem> Items;
        internal User User;

        public AuctionItemsList()
        {
            InitializeComponent();
        }

        private void ListAucitonItems_Load(object sender, EventArgs e)
        {
            if(User != null)
            {
                Text = $"Список аукционных лотов пользователя №{User.Id}";
                Items = AuctionItemService.GetAuctionItemByIdAuctioneer(User.Id);
                RefreshData();
            }
            else
            {
                Text = $"Список аукционных лотов";
                //Items = AuctionItemService.GetRequiredAuctionItems(); //во время деплоя
                Items = AuctionItemService.GetAllAuctionItems(); //для тестирования
                RefreshData();
            }


        }

        private void ShowAuctionItem(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = AuctionItemsGrid.Rows[e.RowIndex];

                int auctionItemId = (int)selectedRow.Cells["Id"].Value;

                ShowAuctionItemDetails(auctionItemId);
            }   
        }

        private void ShowAuctionItemDetails(int auctionItemId)
        {
            AuctionItemDetails auctionItemDetails = new AuctionItemDetails();
            auctionItemDetails.AuctionItem = AuctionItemService.GetAuctionItemById(auctionItemId);

            auctionItemDetails.Show();
        }

        private void AuctionItemsList_Activated(object sender, EventArgs e)
        {
            ListAucitonItems_Load(sender, e);
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            string filter = FilterInput.Text;
            string status = StatusCB.Text;
            bool isActive = IsActiveAuction.Checked;
            
            if(filter != "")
            {
                Items = AuctionItemService.GetFilterAuctionItemsList(filter, isActive, status);
                RefreshData();
            }
        }

        private void RefreshData()
        {
            //AuctionItemsGrid.DataSource = null;
            //AuctionItemsGrid.Rows.Clear();
            AuctionItemsGrid.DataSource = Items;
            AuctionItemsGrid.Refresh();

            AuctionItemsGrid.ClearSelection();

            AuctionItemsGrid.Columns["Id"].HeaderText = "№";
            AuctionItemsGrid.Columns["Title"].HeaderText = "Название";
            AuctionItemsGrid.Columns["InvestmentSize"].HeaderText = "Размер инвестиций(TON)";
            AuctionItemsGrid.Columns["Category"].HeaderText = "Категория";
            AuctionItemsGrid.Columns["StartDate"].HeaderText = "Дата создания";
            AuctionItemsGrid.Columns["AuctioneerId"].HeaderText = "№ Аукциониста";
            AuctionItemsGrid.Columns["IsValid"].HeaderText = "Статус";

            AuctionItemsGrid.Columns["Id"].Width = 50;
            AuctionItemsGrid.Columns["Title"].Width = 300;
            AuctionItemsGrid.Columns["InvestmentSize"].Width = 160;
            AuctionItemsGrid.Columns["Category"].Width = 150;
            AuctionItemsGrid.Columns["StartDate"].Width = 100;
            AuctionItemsGrid.Columns["Auctioneer"].Width = 150;

            AuctionItemsGrid.Columns["Description"].Visible = false;
            AuctionItemsGrid.Columns["Location"].Visible = false;
            AuctionItemsGrid.Columns["EndDate"].Visible = false;
            AuctionItemsGrid.Columns["Winner"].Visible = false;
            AuctionItemsGrid.Columns["WinnerId"].Visible = false;
            AuctionItemsGrid.Columns["Auctioneer"].Visible = false;
            AuctionItemsGrid.Columns["AuctionChats"].Visible = false;

            CountAucitonItemsLabel.Text = "";
            CountAucitonItemsLabel.Text += "Всего аукционных лотов: " + Items.Count;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            Items = AuctionItemService.GetAllAuctionItems();
            RefreshData();
            StatusCB.Text = "";
            FilterInput.Text = "";
            IsActiveAuction.Checked = false;
        }
    }
}
