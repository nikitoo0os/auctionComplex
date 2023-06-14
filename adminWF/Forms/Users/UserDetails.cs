using auctionComplex.Classes;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Forms.Bids;
using auctionComplex.Forms.Wallets;
using auctionComplex.Services;
using System.Windows.Forms;

namespace auctionComplex.Forms.Users
{
    public partial class UserDetails : Form
    {
        internal User User;
        public UserDetails()
        {
            InitializeComponent();
        }

        private void UserDetails_Load(object sender, System.EventArgs e)
        {
            if(User != null)
            {
                Text = "Пользователь №" + User.Id;
                FirstNameInput.Text = User.FirstName;
                SecondNameInput.Text = User.SecondName;
                UsernameInput.Text = User.Username;
                EmailInput.Text = User.Email;
                PasswordInput.Text = User.Password;
                IsAdminCB.Checked = User.IsAdmin;
                IsVerifyCB.Checked = User.IsVerify;
            }
            else
            {
                Text = "Добавление пользователя";
                EditUserBtn.Text = "Добавить";
            }
        }

        private void EditUserBtn_Click(object sender, System.EventArgs e)
        {
            if(User != null)
            {
                User.FirstName = FirstNameInput.Text;
                User.SecondName = SecondNameInput.Text;
                User.Username = UsernameInput.Text;
                User.Email = EmailInput.Text;
                User.IsAdmin = IsAdminCB.Checked;
                User.Password = PasswordInput.Text;
                User.IsVerify = IsVerifyCB.Checked;

                UserService.EditUser(User);
                MessageBox.Show("Данные пользователя обновлены!");
            }
            else
            {
                User user = new User
                {
                    FirstName = FirstNameInput.Text,
                    SecondName = SecondNameInput.Text,
                    Username = UsernameInput.Text,
                    Password = PasswordInput.Text,
                    Email = EmailInput.Text,
                    IsAdmin = IsAdminCB.Checked,
                    IsVerify = IsVerifyCB.Checked
                };
                UserService.CreateUser(user);
                Hide();
            }

        }

        private void WalletsUserBtn_Click(object sender, System.EventArgs e)
        {
            WalletsList walletsList = new WalletsList();
            walletsList.User = User;
            walletsList.ShowDialog();

        }

        private void BidsUserBtn_Click(object sender, System.EventArgs e)
        {
            BidList bidList = new BidList();
            bidList.User = User;
            bidList.ShowDialog();
        }

        private void AuctionItemUserBtn_Click(object sender, System.EventArgs e)
        {
            AuctionItemsList auctionItemsList = new AuctionItemsList();
            auctionItemsList.User = User;
            auctionItemsList.ShowDialog();
        }

        private void DeleteUserBtn_Click(object sender, System.EventArgs e)
        {
            UserService.DeleteUserById (User.Id);
            Hide();
        }
    }
}
