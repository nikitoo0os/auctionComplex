using auctionComplex.Classes;
using auctionComplex.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace auctionComplex.Forms.Transactions
{
    public partial class TransactionList : Form
    {
        private User User;
        public TransactionList()
        {
            InitializeComponent();
           
        }
        internal void SetUser(User user)
        {
            User = user;
        }

        private void TransactionList_Load(object sender, System.EventArgs e)
        {
            if (User != null)
            {
                Text = "Список транзакций пользователя №" + User.Id;
                TransactionsGrid.DataSource = TransactionService.GetTransactionsByIdUser(User.Id);
                label2.Text = "Транзакций найдено: " + TransactionsGrid.ColumnCount.ToString();
                TransactionsGrid.Columns["SenderWalletId"].HeaderText = "№ кошелька-отправителя";
                TransactionsGrid.Columns["ReceiverWalletId"].HeaderText = "№ кошелька-получателя";
                TransactionsGrid.Columns["SenderWallet"].Visible = true;
                TransactionsGrid.Columns["ReceiverWallet"].Visible = true;

                TransactionsGrid.Refresh();
            }
            else
            {
                Text = "Список транзакций";
                List<Transaction> transactions = TransactionService.GetAllTransactions();
                
                TransactionsGrid.DataSource = transactions;
                TransactionsGrid.Columns[6].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                label2.Text = "Транзакций найдено: " + TransactionsGrid.RowCount.ToString();
                TransactionsGrid.Refresh();

                TransactionsGrid.Columns["SenderWalletId"].HeaderText = "Отправитель";
                TransactionsGrid.Columns["ReceiverWalletId"].HeaderText = "Получатель";
                TransactionsGrid.Columns["SenderWallet"].Visible = false;
                TransactionsGrid.Columns["ReceiverWallet"].Visible = false;
            }

            TransactionsGrid.Columns["Id"].HeaderText = "№";
            TransactionsGrid.Columns["amount"].HeaderText = "Размер";
            TransactionsGrid.Columns["timestamp"].HeaderText = "Дата";

            TransactionsGrid.Columns["Id"].Width = 100;
            TransactionsGrid.Columns["amount"].Width = 150;
            TransactionsGrid.Columns["SenderWallet"].Width = 200;
            TransactionsGrid.Columns["ReceiverWallet"].Width = 150;
            TransactionsGrid.Columns["timestamp"].Width = 150;

            TransactionsGrid.ClearSelection();
        }

        private void FilterBtn_Click(object sender, System.EventArgs e)
        {
            TransactionsGrid.DataSource = TransactionService.GetTransactionByDate(StartDateTimePicker.Value, EndDateTimePicker.Value);
            label2.Text = label2.Text = "Транзакций найдено: " + TransactionsGrid.RowCount.ToString();
        }

        private void ResetBtn_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void RefreshBtn_Click(object sender, System.EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            if (User != null)
            {
                TransactionsGrid.DataSource = TransactionService.GetTransactionsByIdUser(User.Id);
            }
            else
            {
                List<Transaction> transactions = TransactionService.GetAllTransactions();
                TransactionsGrid.DataSource = transactions;
            }
            label2.Text = label2.Text = "Транзакций найдено: " + TransactionsGrid.RowCount.ToString();
        }
    }
}
