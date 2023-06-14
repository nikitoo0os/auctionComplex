namespace auctionComplex.Forms.AuctionItems
{
    partial class AuctionItemDetails
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
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.ToProcessedBtn = new System.Windows.Forms.Button();
            this.DismissBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AuctioneerLabel = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VolumeInvLabel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CategoryLabel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.TextBox();
            this.ShowBidsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(315, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Содержимое лота";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubmitBtn.Location = new System.Drawing.Point(22, 567);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(75, 34);
            this.SubmitBtn.TabIndex = 1;
            this.SubmitBtn.Text = "Принять";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // ToProcessedBtn
            // 
            this.ToProcessedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ToProcessedBtn.Location = new System.Drawing.Point(104, 567);
            this.ToProcessedBtn.Name = "ToProcessedBtn";
            this.ToProcessedBtn.Size = new System.Drawing.Size(119, 34);
            this.ToProcessedBtn.TabIndex = 2;
            this.ToProcessedBtn.Text = "На доработку";
            this.ToProcessedBtn.UseVisualStyleBackColor = true;
            this.ToProcessedBtn.Click += new System.EventHandler(this.ToProcessedBtn_Click);
            // 
            // DismissBtn
            // 
            this.DismissBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DismissBtn.Location = new System.Drawing.Point(228, 567);
            this.DismissBtn.Name = "DismissBtn";
            this.DismissBtn.Size = new System.Drawing.Size(75, 34);
            this.DismissBtn.TabIndex = 3;
            this.DismissBtn.Text = "Отказ";
            this.DismissBtn.UseVisualStyleBackColor = true;
            this.DismissBtn.Click += new System.EventHandler(this.DismissBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Аукционист:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Название: ";
            // 
            // AuctioneerLabel
            // 
            this.AuctioneerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuctioneerLabel.Location = new System.Drawing.Point(116, 78);
            this.AuctioneerLabel.Multiline = true;
            this.AuctioneerLabel.Name = "AuctioneerLabel";
            this.AuctioneerLabel.Size = new System.Drawing.Size(309, 30);
            this.AuctioneerLabel.TabIndex = 6;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TitleLabel.Location = new System.Drawing.Point(116, 120);
            this.TitleLabel.Multiline = true;
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(672, 30);
            this.TitleLabel.TabIndex = 7;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionLabel.Location = new System.Drawing.Point(116, 166);
            this.DescriptionLabel.Multiline = true;
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(672, 228);
            this.DescriptionLabel.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(29, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Описание:";
            // 
            // VolumeInvLabel
            // 
            this.VolumeInvLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VolumeInvLabel.Location = new System.Drawing.Point(238, 466);
            this.VolumeInvLabel.Multiline = true;
            this.VolumeInvLabel.Name = "VolumeInvLabel";
            this.VolumeInvLabel.Size = new System.Drawing.Size(131, 30);
            this.VolumeInvLabel.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(19, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Объём инвестиций от(TON):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(19, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Местоположение:";
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CategoryLabel.Location = new System.Drawing.Point(564, 78);
            this.CategoryLabel.Multiline = true;
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(224, 30);
            this.CategoryLabel.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(465, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Категория:";
            // 
            // LocationLabel
            // 
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LocationLabel.Location = new System.Drawing.Point(163, 420);
            this.LocationLabel.Multiline = true;
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(625, 30);
            this.LocationLabel.TabIndex = 13;
            // 
            // ShowBidsBtn
            // 
            this.ShowBidsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowBidsBtn.Location = new System.Drawing.Point(648, 567);
            this.ShowBidsBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ShowBidsBtn.Name = "ShowBidsBtn";
            this.ShowBidsBtn.Size = new System.Drawing.Size(139, 34);
            this.ShowBidsBtn.TabIndex = 16;
            this.ShowBidsBtn.Text = "Просмотр ставок";
            this.ShowBidsBtn.UseVisualStyleBackColor = true;
            this.ShowBidsBtn.Click += new System.EventHandler(this.ShowBidsBtn_Click);
            // 
            // AuctionItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.ShowBidsBtn);
            this.Controls.Add(this.CategoryLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.VolumeInvLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.AuctioneerLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DismissBtn);
            this.Controls.Add(this.ToProcessedBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.label1);
            this.Name = "AuctionItemDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аукционный лот №";
            this.Load += new System.EventHandler(this.AuctionItemDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button ToProcessedBtn;
        private System.Windows.Forms.Button DismissBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AuctioneerLabel;
        private System.Windows.Forms.TextBox TitleLabel;
        private System.Windows.Forms.TextBox DescriptionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VolumeInvLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CategoryLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox LocationLabel;
        private System.Windows.Forms.Button ShowBidsBtn;
    }
}