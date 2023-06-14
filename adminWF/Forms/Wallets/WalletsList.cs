using auctionComplex.Classes;
using auctionComplex.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auctionComplex.Forms.Wallets
{
    public partial class WalletsList : Form
    {
        internal User User;
        internal static List<Wallet> Wallets;
        public WalletsList()
        {
            InitializeComponent();
        }

        private void WalletsList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (User != null)
            {
                Text = "Список криптовалютных кошельков пользователя №" + User.Id;
                Wallets = WalletService.GetWalletsByIdUser(User.Id);
            }
            else
            {
                Text = "Список криптовалютных кошельков";
                Wallets = WalletService.GetAllWalletsList();
            }
            WalletsGrid.DataSource = Wallets;

            WalletsGrid.Columns["Id"].HeaderText = "№";
            WalletsGrid.Columns["Address"].HeaderText = "Адрес";
            WalletsGrid.Columns["Address"].Width = 310;
            WalletsGrid.Columns["Balance"].HeaderText = "Баланс";
            WalletsGrid.Columns["Balance"].Width = 150;
            WalletsGrid.Columns["UserId"].Visible = false;
            WalletsGrid.Columns["User"].Visible = false;
            WalletsGrid.ClearSelection();
            WalletsCountLabel.Text = $"Кошельков найдено: {WalletsGrid.RowCount}";
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string filter = SearchInput.Text;
            if(filter != "")
            {
                WalletsGrid.DataSource = WalletService.GetFilterWalletList(filter);
                WalletsGrid.Refresh();
                WalletsCountLabel.Text = $"Кошельков найдено: {WalletsGrid.RowCount}";
            }
            else
            {
                RefreshData();
            }
            
            
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            SearchInput.Text = "";
            RefreshData();
        }
    }
}
