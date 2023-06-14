using auctionComplex.Classes;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Services;
using auctionComplex.Services.AuctionItems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace auctionComplex.Forms.AuctionChats
{
    public partial class ChatMessagesList : Form
    {
        internal static List<ChatMessage> ChatMessages;
        internal AuctionChat AuctionChat;

        public ChatMessagesList()
        {
            InitializeComponent();

        }
        private void ChatMessagesList_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void RefreshData()
        {
            if (AuctionChat != null)
            {
                Text = $"Чат аукциона №{AuctionChat.AuctionItemId}";
                ChatMessagesGrid.DataSource = ChatMessageService.GetChatMessagesByAuctionChatId(AuctionChat.Id);
                ChatMessagesGrid.Refresh();
            }
            else
            {
                Text = $"Все сообщения";
                ChatMessagesGrid.DataSource = ChatMessageService.GetAllChatMessages();
                ChatMessagesGrid.Refresh();
            }
            ChatMessagesGrid.Columns["Id"].HeaderText = "№";
            ChatMessagesGrid.Columns["Text"].HeaderText = "Текст";
            ChatMessagesGrid.Columns["Text"].Width = 350;
            ChatMessagesGrid.Columns["AuctionChatId"].HeaderText = "№ чата";
            ChatMessagesGrid.Columns["UserId"].HeaderText = "№ отправителя";
            ChatMessagesGrid.Columns["AttachmentId"].HeaderText = "№ вложения";
            ChatMessagesGrid.Columns["Timestamp"].HeaderText = "Отправлено";

            ChatMessagesGrid.Columns["AuctionChat"].Visible = false;
            ChatMessagesGrid.Columns["User"].Visible = false;
            ChatMessagesGrid.Columns["Attachment"].Visible = false;
            ChatMessagesGrid.ClearSelection();
            CountChatMessages.Text = $"Сообщений найдено: {ChatMessagesGrid.RowCount}";
        }
    }
}
