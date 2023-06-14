namespace auctionComplex.Forms.Attachments
{
    partial class AttachmentsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AttachmentsGrid = new System.Windows.Forms.DataGridView();
            this.AddFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ObjectCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AttachmentsGrid
            // 
            this.AttachmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttachmentsGrid.Location = new System.Drawing.Point(16, 111);
            this.AttachmentsGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AttachmentsGrid.Name = "AttachmentsGrid";
            this.AttachmentsGrid.RowHeadersWidth = 51;
            this.AttachmentsGrid.Size = new System.Drawing.Size(1421, 635);
            this.AttachmentsGrid.TabIndex = 0;
            this.AttachmentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowAttachment);
            // 
            // AddFileBtn
            // 
            this.AddFileBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddFileBtn.Location = new System.Drawing.Point(16, 69);
            this.AddFileBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AddFileBtn.Name = "AddFileBtn";
            this.AddFileBtn.Size = new System.Drawing.Size(200, 34);
            this.AddFileBtn.TabIndex = 1;
            this.AddFileBtn.Text = "Добавить файл";
            this.AddFileBtn.UseVisualStyleBackColor = true;
            this.AddFileBtn.Click += new System.EventHandler(this.AddFileBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(224, 69);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(125, 34);
            this.RefreshBtn.TabIndex = 2;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(1312, 69);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(125, 34);
            this.ResetBtn.TabIndex = 3;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.Location = new System.Drawing.Point(1179, 69);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(125, 34);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Поиск";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchInput
            // 
            this.SearchInput.Location = new System.Drawing.Point(855, 69);
            this.SearchInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(315, 34);
            this.SearchInput.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(851, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите № или название ";
            // 
            // ObjectCountLabel
            // 
            this.ObjectCountLabel.AutoSize = true;
            this.ObjectCountLabel.Location = new System.Drawing.Point(16, 13);
            this.ObjectCountLabel.Name = "ObjectCountLabel";
            this.ObjectCountLabel.Size = new System.Drawing.Size(134, 16);
            this.ObjectCountLabel.TabIndex = 7;
            this.ObjectCountLabel.Text = "Объектов найдено:";
            // 
            // AttachmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 761);
            this.Controls.Add(this.ObjectCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.AddFileBtn);
            this.Controls.Add(this.AttachmentsGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AttachmentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Облачное хранилище";
            this.Load += new System.EventHandler(this.AttachmentsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AttachmentsGrid;
        private System.Windows.Forms.Button AddFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ObjectCountLabel;
    }
}