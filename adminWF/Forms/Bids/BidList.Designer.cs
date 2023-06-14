namespace auctionComplex.Forms.Bids
{
    partial class BidList
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
            this.BidGrid = new System.Windows.Forms.DataGridView();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.BidsCountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BidGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // BidGrid
            // 
            this.BidGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BidGrid.Location = new System.Drawing.Point(12, 79);
            this.BidGrid.Name = "BidGrid";
            this.BidGrid.RowHeadersWidth = 51;
            this.BidGrid.Size = new System.Drawing.Size(776, 359);
            this.BidGrid.TabIndex = 0;
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(12, 45);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(86, 28);
            this.RefreshBtn.TabIndex = 1;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBtn.Location = new System.Drawing.Point(702, 45);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(86, 28);
            this.ResetBtn.TabIndex = 2;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.Location = new System.Drawing.Point(611, 45);
            this.SearchBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(86, 28);
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.Text = "Поиск";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // BidsCountLabel
            // 
            this.BidsCountLabel.AutoSize = true;
            this.BidsCountLabel.Location = new System.Drawing.Point(10, 11);
            this.BidsCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BidsCountLabel.Name = "BidsCountLabel";
            this.BidsCountLabel.Size = new System.Drawing.Size(94, 13);
            this.BidsCountLabel.TabIndex = 4;
            this.BidsCountLabel.Text = "Ставок найдено: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Введите № ";
            // 
            // SearchInput
            // 
            this.SearchInput.Location = new System.Drawing.Point(408, 45);
            this.SearchInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(200, 29);
            this.SearchInput.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "сначала последние ставки",
            "сначала с большим объёмом",
            "сначала с большим процентом"});
            this.comboBox1.Location = new System.Drawing.Point(220, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Сортировка";
            // 
            // BidList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BidsCountLabel);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.BidGrid);
            this.Name = "BidList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список ставок";
            this.Load += new System.EventHandler(this.BidList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BidGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BidGrid;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button ResetBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label BidsCountLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}