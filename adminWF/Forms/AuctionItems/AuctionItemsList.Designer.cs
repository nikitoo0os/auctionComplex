namespace auctionComplex.Forms.AuctionItems
{
    partial class AuctionItemsList
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
            this.AuctionItemsGrid = new System.Windows.Forms.DataGridView();
            this.CountAucitonItemsLabel = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.FilterInput = new System.Windows.Forms.TextBox();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.IsActiveAuction = new System.Windows.Forms.CheckBox();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.StatusCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AuctionItemsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AuctionItemsGrid
            // 
            this.AuctionItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuctionItemsGrid.Location = new System.Drawing.Point(15, 78);
            this.AuctionItemsGrid.MultiSelect = false;
            this.AuctionItemsGrid.Name = "AuctionItemsGrid";
            this.AuctionItemsGrid.ReadOnly = true;
            this.AuctionItemsGrid.RowHeadersWidth = 51;
            this.AuctionItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuctionItemsGrid.Size = new System.Drawing.Size(1019, 452);
            this.AuctionItemsGrid.TabIndex = 0;
            this.AuctionItemsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowAuctionItem);
            // 
            // CountAucitonItemsLabel
            // 
            this.CountAucitonItemsLabel.AutoSize = true;
            this.CountAucitonItemsLabel.Location = new System.Drawing.Point(12, 9);
            this.CountAucitonItemsLabel.Name = "CountAucitonItemsLabel";
            this.CountAucitonItemsLabel.Size = new System.Drawing.Size(138, 13);
            this.CountAucitonItemsLabel.TabIndex = 4;
            this.CountAucitonItemsLabel.Text = "Всего аукционных лотов: ";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(15, 42);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(86, 30);
            this.RefreshBtn.TabIndex = 5;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            // 
            // FilterInput
            // 
            this.FilterInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterInput.Location = new System.Drawing.Point(569, 42);
            this.FilterInput.Multiline = true;
            this.FilterInput.Name = "FilterInput";
            this.FilterInput.Size = new System.Drawing.Size(265, 30);
            this.FilterInput.TabIndex = 6;
            // 
            // FilterBtn
            // 
            this.FilterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilterBtn.Location = new System.Drawing.Point(840, 42);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(86, 30);
            this.FilterBtn.TabIndex = 7;
            this.FilterBtn.Text = "Фильтр";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Введите № или название лота";
            // 
            // IsActiveAuction
            // 
            this.IsActiveAuction.AutoSize = true;
            this.IsActiveAuction.Location = new System.Drawing.Point(450, 46);
            this.IsActiveAuction.Name = "IsActiveAuction";
            this.IsActiveAuction.Size = new System.Drawing.Size(93, 17);
            this.IsActiveAuction.TabIndex = 9;
            this.IsActiveAuction.Text = "идёт аукцион";
            this.IsActiveAuction.UseVisualStyleBackColor = true;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(948, 42);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(86, 30);
            this.ResetBtn.TabIndex = 10;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // StatusCB
            // 
            this.StatusCB.FormattingEnabled = true;
            this.StatusCB.Items.AddRange(new object[] {
            "На проверке",
            "Принят",
            "На доработке",
            "Отказ"});
            this.StatusCB.Location = new System.Drawing.Point(288, 44);
            this.StatusCB.Name = "StatusCB";
            this.StatusCB.Size = new System.Drawing.Size(121, 21);
            this.StatusCB.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Статус";
            // 
            // AuctionItemsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusCB);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.IsActiveAuction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.FilterInput);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.CountAucitonItemsLabel);
            this.Controls.Add(this.AuctionItemsGrid);
            this.Name = "AuctionItemsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование Аукционных Лотов";
            this.Activated += new System.EventHandler(this.AuctionItemsList_Activated);
            this.Load += new System.EventHandler(this.ListAucitonItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuctionItemsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AuctionItemsGrid;
        private System.Windows.Forms.Label CountAucitonItemsLabel;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.TextBox FilterInput;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsActiveAuction;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.ComboBox StatusCB;
        private System.Windows.Forms.Label label2;
    }
}