using auctionComplex.Classes;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Services;
using auctionComplex.Services.AuctionItems;
using auctionComplex.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace auctionComplex.Forms.Users
{
    public partial class UsersList : Form
    {
        List<User> Users;
        public UsersList()
        {
            InitializeComponent();
            RefreshData();
        }

        private void UsersList_Load(object sender, System.EventArgs e)
        {
            UsersGrid.ClearSelection();

            UsersGrid.Columns["Id"].HeaderText = "№";
            UsersGrid.Columns["FirstName"].HeaderText = "Имя";
            UsersGrid.Columns["SecondName"].HeaderText = "Фамилия";
            UsersGrid.Columns["Email"].HeaderText = "Электронная почта";
            UsersGrid.Columns["Username"].HeaderText = "Имя пользователя";
            UsersGrid.Columns["Password"].HeaderText = "Пароль";
            UsersGrid.Columns["IsAdmin"].HeaderText = "Привилегии";

            UsersGrid.Columns["Id"].Width = 50;
            UsersGrid.Columns["FirstName"].Width = 200;
            UsersGrid.Columns["SecondName"].Width = 200;
            UsersGrid.Columns["Email"].Width = 200;
            UsersGrid.Columns["Username"].Width = 200;
            UsersGrid.Columns["Password"].Width = 200;
            UsersGrid.Columns["IsAdmin"].Width = 150;

            UsersGrid.Columns["Wallets"].Visible = false;
            UsersGrid.Columns["Bids"].Visible = false;
            UsersGrid.Columns["ChatMessages"].Visible = false;
            UsersGrid.Columns["UserChats"].Visible = false;
            UsersGrid.Columns["IsVerify"].Visible = false;
        }

        private void ShowUserDetails(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = UsersGrid.Rows[e.RowIndex];
                int userId = (int)selectedRow.Cells["Id"].Value;
                UserDetails userDetails = new UserDetails();
                userDetails.User = UserService.GetUserById(userId);
                userDetails.Show();
            }
        }

        private void SearchBtn_Click(object sender, System.EventArgs e)
        {
            string filter = SearchInput.Text;
            if (filter != "")
            {
                UsersGrid.DataSource = UserService.GetFilterUserList(filter);
                CountUsersLabel.Text = "Найдено пользователей: " + UsersGrid.RowCount;
            }
            else
            {
                RefreshData();
            }
        }

        private void RefreshData()
        {
            Users = UserService.GetAllUsers();
            UsersGrid.DataSource = Users;
            CountUsersLabel.Text = "Найдено пользователей: " + UsersGrid.RowCount;
        }

        private void RefreshBtn_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void AddUserBtn_Click(object sender, System.EventArgs e)
        {
            new UserDetails().Show();
        }
    }
}
