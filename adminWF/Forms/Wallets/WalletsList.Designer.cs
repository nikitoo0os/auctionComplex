namespace auctionComplex.Forms.Wallets
{
    partial class WalletsList
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
            this.WalletsGrid = new System.Windows.Forms.DataGridView();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.WalletsCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WalletsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WalletsGrid
            // 
            this.WalletsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WalletsGrid.Location = new System.Drawing.Point(9, 66);
            this.WalletsGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WalletsGrid.MultiSelect = false;
            this.WalletsGrid.Name = "WalletsGrid";
            this.WalletsGrid.ReadOnly = true;
            this.WalletsGrid.RowHeadersWidth = 51;
            this.WalletsGrid.RowTemplate.Height = 24;
            this.WalletsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WalletsGrid.Size = new System.Drawing.Size(740, 345);
            this.WalletsGrid.TabIndex = 0;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.Location = new System.Drawing.Point(632, 33);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(56, 28);
            this.SearchBtn.TabIndex = 1;
            this.SearchBtn.Text = "Поиск";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchInput
            // 
            this.SearchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchInput.Location = new System.Drawing.Point(418, 33);
            this.SearchInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(210, 28);
            this.SearchInput.TabIndex = 2;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(9, 33);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(80, 28);
            this.RefreshBtn.TabIndex = 3;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(692, 33);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(56, 28);
            this.ResetBtn.TabIndex = 4;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // WalletsCountLabel
            // 
            this.WalletsCountLabel.AutoSize = true;
            this.WalletsCountLabel.Location = new System.Drawing.Point(10, 11);
            this.WalletsCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WalletsCountLabel.Name = "WalletsCountLabel";
            this.WalletsCountLabel.Size = new System.Drawing.Size(115, 13);
            this.WalletsCountLabel.TabIndex = 5;
            this.WalletsCountLabel.Text = "Кошельков найдено: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(416, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите № или адрес";
            // 
            // WalletsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 421);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WalletsCountLabel);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.WalletsGrid);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "WalletsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список криптовалютных кошельков";
            this.Load += new System.EventHandler(this.WalletsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WalletsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView WalletsGrid;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Label WalletsCountLabel;
        private System.Windows.Forms.Label label2;
    }
}