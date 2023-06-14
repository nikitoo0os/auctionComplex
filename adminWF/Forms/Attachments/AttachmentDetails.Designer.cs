namespace auctionComplex.Forms.AuctionItems
{
    partial class AttachmentDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.TextBox();
            this.FileSizeLabel = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TimestampLabel = new System.Windows.Forms.TextBox();
            this.TypeLabel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SearchUserBtn = new System.Windows.Forms.Button();
            this.SaveAsBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(295, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Содержимое вложения";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBtn.Location = new System.Drawing.Point(621, 333);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(167, 34);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "Удалить вложение";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ключ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(60, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер файла:";
            // 
            // KeyLabel
            // 
            this.KeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyLabel.Location = new System.Drawing.Point(69, 78);
            this.KeyLabel.Multiline = true;
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(719, 30);
            this.KeyLabel.TabIndex = 6;
            // 
            // FileSizeLabel
            // 
            this.FileSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileSizeLabel.Location = new System.Drawing.Point(191, 240);
            this.FileSizeLabel.Multiline = true;
            this.FileSizeLabel.Name = "FileSizeLabel";
            this.FileSizeLabel.Size = new System.Drawing.Size(136, 30);
            this.FileSizeLabel.TabIndex = 7;
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(69, 128);
            this.NameLabel.Multiline = true;
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(719, 30);
            this.NameLabel.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Имя:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(409, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дата добавления:";
            // 
            // TimestampLabel
            // 
            this.TimestampLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimestampLabel.Location = new System.Drawing.Point(560, 240);
            this.TimestampLabel.Multiline = true;
            this.TimestampLabel.Name = "TimestampLabel";
            this.TimestampLabel.Size = new System.Drawing.Size(136, 30);
            this.TimestampLabel.TabIndex = 13;
            // 
            // TypeLabel
            // 
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLabel.Location = new System.Drawing.Point(111, 177);
            this.TypeLabel.Multiline = true;
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(677, 30);
            this.TypeLabel.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(9, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "Тип файла:";
            // 
            // SearchUserBtn
            // 
            this.SearchUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchUserBtn.Location = new System.Drawing.Point(16, 333);
            this.SearchUserBtn.Name = "SearchUserBtn";
            this.SearchUserBtn.Size = new System.Drawing.Size(136, 34);
            this.SearchUserBtn.TabIndex = 16;
            this.SearchUserBtn.Text = "Найти автора";
            this.SearchUserBtn.UseVisualStyleBackColor = true;
            this.SearchUserBtn.Click += new System.EventHandler(this.SearchUserBtn_Click);
            // 
            // SaveAsBtn
            // 
            this.SaveAsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveAsBtn.Location = new System.Drawing.Point(158, 333);
            this.SaveAsBtn.Name = "SaveAsBtn";
            this.SaveAsBtn.Size = new System.Drawing.Size(136, 34);
            this.SaveAsBtn.TabIndex = 17;
            this.SaveAsBtn.Text = "Сохранить как";
            this.SaveAsBtn.UseVisualStyleBackColor = true;
            this.SaveAsBtn.Click += new System.EventHandler(this.SaveAsBtn_Click);
            // 
            // AttachmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.SaveAsBtn);
            this.Controls.Add(this.SearchUserBtn);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TimestampLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FileSizeLabel);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.label1);
            this.Name = "AttachmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вложение №";
            this.Load += new System.EventHandler(this.AttachmentDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox KeyLabel;
        private System.Windows.Forms.TextBox FileSizeLabel;
        private System.Windows.Forms.TextBox NameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TimestampLabel;
        private System.Windows.Forms.TextBox TypeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SearchUserBtn;
        private System.Windows.Forms.Button SaveAsBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}