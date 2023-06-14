namespace auctionComplex.Forms.AuctionChats
{
    partial class ChatMessagesList
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
            this.ChatMessagesGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.CountChatMessages = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChatMessagesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ChatMessagesGrid
            // 
            this.ChatMessagesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChatMessagesGrid.Location = new System.Drawing.Point(12, 97);
            this.ChatMessagesGrid.MultiSelect = false;
            this.ChatMessagesGrid.Name = "ChatMessagesGrid";
            this.ChatMessagesGrid.ReadOnly = true;
            this.ChatMessagesGrid.RowHeadersWidth = 51;
            this.ChatMessagesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ChatMessagesGrid.Size = new System.Drawing.Size(957, 399);
            this.ChatMessagesGrid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 502);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Удалить сообщение";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CountChatMessages
            // 
            this.CountChatMessages.AutoSize = true;
            this.CountChatMessages.Location = new System.Drawing.Point(12, 9);
            this.CountChatMessages.Name = "CountChatMessages";
            this.CountChatMessages.Size = new System.Drawing.Size(117, 13);
            this.CountChatMessages.TabIndex = 2;
            this.CountChatMessages.Text = "Найдено сообщений: ";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(603, 58);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 33);
            this.textBox1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(850, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Поиск";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ChatMessagesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CountChatMessages);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ChatMessagesGrid);
            this.Name = "ChatMessagesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщения чата №";
            this.Load += new System.EventHandler(this.ChatMessagesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChatMessagesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ChatMessagesGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label CountChatMessages;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}