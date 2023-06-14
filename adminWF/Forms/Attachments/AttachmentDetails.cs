using auctionComplex.Classes;
using auctionComplex.Services;
using System;
using System.Windows.Forms;

namespace auctionComplex.Forms.AuctionItems
{
    public partial class AttachmentDetails : Form
    {
        internal Attachment Attachment;
        public AttachmentDetails()
        {
            InitializeComponent();
        }

        private void AttachmentDetails_Load(object sender, EventArgs e)
        {
            Text = "Вложение №" + Attachment.Id;
            KeyLabel.Text = Attachment.Key;
            NameLabel.Text = Attachment.Name;
            TypeLabel.Text = Attachment.FileType;
            FileSizeLabel.Text = Attachment.FileSize.ToString();
            TimestampLabel.Text = Attachment.Timestamp.ToString();
        }


        private void SearchUserBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveAsBtn_Click(object sender, EventArgs e)
        {
            AttachmentService.DownloadFile(Attachment.Key);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            AttachmentService.DeleteAttachmentByKey(Attachment.Key);
        }
    }
}
