namespace auctionComplex.Forms.Users
{
    partial class UsersList
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
            this.UsersGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CountUsersLabel = new System.Windows.Forms.Label();
            this.SearchInput = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RefreshBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AddUserBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersGrid
            // 
            this.UsersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersGrid.Location = new System.Drawing.Point(12, 97);
            this.UsersGrid.MultiSelect = false;
            this.UsersGrid.Name = "UsersGrid";
            this.UsersGrid.ReadOnly = true;
            this.UsersGrid.RowHeadersWidth = 51;
            this.UsersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersGrid.Size = new System.Drawing.Size(1266, 478);
            this.UsersGrid.TabIndex = 0;
            this.UsersGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ShowUserDetails);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(584, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Список пользователей";
            // 
            // CountUsersLabel
            // 
            this.CountUsersLabel.AutoSize = true;
            this.CountUsersLabel.Location = new System.Drawing.Point(12, 33);
            this.CountUsersLabel.Name = "CountUsersLabel";
            this.CountUsersLabel.Size = new System.Drawing.Size(120, 13);
            this.CountUsersLabel.TabIndex = 2;
            this.CountUsersLabel.Text = "Всего пользователей:";
            // 
            // SearchInput
            // 
            this.SearchInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchInput.Location = new System.Drawing.Point(863, 63);
            this.SearchInput.Multiline = true;
            this.SearchInput.Name = "SearchInput";
            this.SearchInput.Size = new System.Drawing.Size(259, 28);
            this.SearchInput.TabIndex = 4;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBtn.Location = new System.Drawing.Point(1128, 63);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(72, 28);
            this.SearchBtn.TabIndex = 5;
            this.SearchBtn.Text = "Поиск";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(860, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите имя пользователя или №\r\n";
            // 
            // RefreshBtn
            // 
            this.RefreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshBtn.Location = new System.Drawing.Point(12, 63);
            this.RefreshBtn.Name = "RefreshBtn";
            this.RefreshBtn.Size = new System.Drawing.Size(88, 28);
            this.RefreshBtn.TabIndex = 7;
            this.RefreshBtn.Text = "Обновить";
            this.RefreshBtn.UseVisualStyleBackColor = true;
            this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1206, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сброс";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AddUserBtn
            // 
            this.AddUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddUserBtn.Location = new System.Drawing.Point(106, 63);
            this.AddUserBtn.Name = "AddUserBtn";
            this.AddUserBtn.Size = new System.Drawing.Size(188, 28);
            this.AddUserBtn.TabIndex = 9;
            this.AddUserBtn.Text = "Добавить пользователя";
            this.AddUserBtn.UseVisualStyleBackColor = true;
            this.AddUserBtn.Click += new System.EventHandler(this.AddUserBtn_Click);
            // 
            // UsersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1290, 586);
            this.Controls.Add(this.AddUserBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RefreshBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchInput);
            this.Controls.Add(this.CountUsersLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsersGrid);
            this.Name = "UsersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список пользователей";
            this.Load += new System.EventHandler(this.UsersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UsersGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountUsersLabel;
        private System.Windows.Forms.TextBox SearchInput;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RefreshBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddUserBtn;
    }
}