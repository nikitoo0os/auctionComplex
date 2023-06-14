using System;
using System.Collections.Generic;
using System.Windows.Forms;
using auctionComplex.Classes;
using auctionComplex.Forms.AuctionItems;
using auctionComplex.Services;

namespace auctionComplex.Forms.Attachments
{
    public partial class AttachmentsList : Form
    {
        private List<Attachment> Attachments;
        public AttachmentsList()
        {
            InitializeComponent();
            Attachments = AttachmentService.GetAllAttachments();
        }

        private void AttachmentsList_Load(object sender, EventArgs e)
        {
            AttachmentsGrid.DataSource = Attachments;

            AttachmentsGrid.Columns["Id"].HeaderText = "№";
            AttachmentsGrid.Columns["Key"].HeaderText = "Ключ";
            AttachmentsGrid.Columns["Name"].HeaderText = "Название";
            AttachmentsGrid.Columns["FileSize"].HeaderText = "Размер файла(кБайт)";
            AttachmentsGrid.Columns["FileType"].HeaderText = "Тип файла";
            AttachmentsGrid.Columns["Timestamp"].HeaderText = "Загружено";

            AttachmentsGrid.Columns["Id"].Width = 50;
            AttachmentsGrid.Columns["Key"].Width = 300;
            AttachmentsGrid.Columns["Name"].Width = 250;
            AttachmentsGrid.Columns["FileSize"].Width = 150;
            AttachmentsGrid.Columns["FileType"].Width = 120;
            AttachmentsGrid.Columns["Timestamp"].Width = 140;

            AttachmentsGrid.Columns["chatMessages"].Visible = false;

            ObjectCountLabel.Text = $"Объектов найдено: {AttachmentsGrid.RowCount}";
        }

        private void ShowAttachment(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = AttachmentsGrid.Rows[e.RowIndex];

                int auctionItemId = (int)selectedRow.Cells["Id"].Value;

                ShowAttachmentDetails(auctionItemId);
            }
        }
        private void ShowAttachmentDetails(int attachmentId)
        {
            AttachmentDetails attachmentDetails = new AttachmentDetails();
            attachmentDetails.Attachment = AttachmentService.GetAttachmentById(attachmentId);

            attachmentDetails.ShowDialog();
        }

        private void AddFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {              
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AttachmentService.UploadFileToAws(openFileDialog);
                }
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            AttachmentsGrid.DataSource = AttachmentService.GetAllAttachments();
            AttachmentsGrid.Refresh();
            ObjectCountLabel.Text = $"Объектов найдено: {AttachmentsGrid.RowCount}";
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string filter = SearchInput.Text;
            AttachmentsGrid.DataSource = AttachmentService.GetFilterAttachmentsList(filter);
            AttachmentsGrid.Refresh();
            ObjectCountLabel.Text = $"Объектов найдено: {AttachmentsGrid.RowCount}";
        }
    }
}
