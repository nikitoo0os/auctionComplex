using auctionComplex.Resources;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using auctionComplex.Classes.Security;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Forms.Resources;

namespace auctionComplex.Forms
{
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void LoginButton(object sender, EventArgs e)
        {
            string login = LoginInput.Text;
            string password = HashPassword(PasswordInput.Text);

            using (var db = new AuctionComplexContext())
            {
                var user = db.Users
                    .FirstOrDefault(m => (m.Username == login || m.Email == login) & m.Password == password);

                if (user != null)
                {
                    Session.UserId = user.Id;
                    label1.Text = "Авторизован";
                    Hide();
                    new MenuForm().Show();
                }
            }

        }
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}
