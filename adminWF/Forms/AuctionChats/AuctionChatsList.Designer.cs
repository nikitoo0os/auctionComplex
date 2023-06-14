namespace auctionComplex.Forms.AuctionChats
{
    partial class AuctionChatsList
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
            this.AuctionChatsGrid = new System.Windows.Forms.DataGridView();
            this.CountChatLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SearchInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AuctionChatsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AuctionChatsGrid
            // 
            this.AuctionChatsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuctionChatsGrid.Location = new System.Drawing.Point(10, 91);
            this.AuctionChatsGrid.MultiSelect = false;
            this.AuctionChatsGrid.Name = "AuctionChatsGrid";
            this.AuctionChatsGrid.ReadOnly = true;
            this.AuctionChatsGrid.RowHeadersWidth = 51;
            this.AuctionChatsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuctionChatsGrid.Size = new System.Drawing.Size(957, 451);
            this.AuctionChatsGrid.TabIndex = 0;
            this.AuctionChatsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowChatMessages);
            // 
            // CountChatLabel
            // 
            this.CountChatLabel.AutoSize = true;
            this.CountChatLabel.Location = new System.Drawing.Point(10, 7);
            this.CountChatLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CountChatLabel.Name = "CountChatLabel";
            this.CountChatLabel.Size = new System.Drawing.Size(35, 13);
            this.CountChatLabel.TabIndex = 1;
            this.CountChatLabel.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите №";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(12, 59);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(85, 26);
            this.RefreshBtn.TabIndex = 3;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.Location = new System.Drawing.Point(852, 59);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(56, 26);
            this.SearchBtn.TabIndex = 4;
            this.SearchBtn.Text = "Поиск";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(913, 59);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(56, 26);
            this.ResetBtn.TabIndex = 5;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // SearchInput
            // 
            this.SearchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchInput.Location = new System.Drawing.Point(634, 59);
            this.SearchInput.Margin = new System.Windows.Forms.Padding(2);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(213, 27);
            this.SearchInput.TabIndex = 6;
            // 
            // AuctionChatsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 554);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CountChatLabel);
            this.Controls.Add(this.AuctionChatsGrid);
            this.Name = "AuctionChatsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чаты аукционов";
            this.Load += new System.EventHandler(this.AuctionChatsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AuctionChatsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AuctionChatsGrid;
        private System.Windows.Forms.Label CountChatLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.TextBox SearchInput;
    }
}