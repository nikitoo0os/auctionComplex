namespace auctionComplex.Forms.Transactions
{
    partial class TransactionList
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
            this.TransactionsGrid = new System.Windows.Forms.DataGridView();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.до = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TransactionsGrid
            // 
            this.TransactionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionsGrid.Location = new System.Drawing.Point(16, 81);
            this.TransactionsGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TransactionsGrid.MultiSelect = false;
            this.TransactionsGrid.Name = "TransactionsGrid";
            this.TransactionsGrid.ReadOnly = true;
            this.TransactionsGrid.RowHeadersWidth = 51;
            this.TransactionsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TransactionsGrid.Size = new System.Drawing.Size(1312, 514);
            this.TransactionsGrid.TabIndex = 0;
            // 
            // FilterBtn
            // 
            this.FilterBtn.Location = new System.Drawing.Point(1120, 38);
            this.FilterBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(100, 36);
            this.FilterBtn.TabIndex = 1;
            this.FilterBtn.Text = "Фильтр";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(503, 41);
            this.StartDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.StartDateTimePicker.TabIndex = 2;
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(827, 41);
            this.EndDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(265, 22);
            this.EndDateTimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "От";
            // 
            // до
            // 
            this.до.AutoSize = true;
            this.до.Location = new System.Drawing.Point(791, 41);
            this.до.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.до.Name = "до";
            this.до.Size = new System.Drawing.Size(23, 16);
            this.до.TabIndex = 5;
            this.до.Text = "до";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Location = new System.Drawing.Point(16, 38);
            this.RefreshBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(100, 36);
            this.RefreshBtn.TabIndex = 6;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Транзакций найдено:";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Location = new System.Drawing.Point(1228, 38);
            this.ResetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(100, 36);
            this.ResetBtn.TabIndex = 8;
            this.ResetBtn.Text = "Сброс";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // TransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 610);
            this.Controls.Add(this.ResetBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.до);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.TransactionsGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TransactionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список транзакций пользователя №";
            this.Load += new System.EventHandler(this.TransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TransactionsGrid;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label до;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ResetBtn;
    }
}