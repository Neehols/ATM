namespace BankAdmin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRecover = new System.Windows.Forms.Button();
            this.comboBoxDeletedUsers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeletedSearch = new System.Windows.Forms.Button();
            this.txtSearchDeleted = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(117, 125);
            this.comboBoxUsers.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(100, 21);
            this.comboBoxUsers.TabIndex = 2;
            // 
            // btnAddUser
            // 
            this.btnAddUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(217, 324);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(207, 39);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Nieuwe gebruiker aanmaken";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEdit.Location = new System.Drawing.Point(117, 153);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Bewerken";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(117, 214);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(117, 240);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Zoeken";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRecover
            // 
            this.btnRecover.ForeColor = System.Drawing.Color.White;
            this.btnRecover.Image = ((System.Drawing.Image)(resources.GetObject("btnRecover.Image")));
            this.btnRecover.Location = new System.Drawing.Point(426, 153);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(75, 23);
            this.btnRecover.TabIndex = 7;
            this.btnRecover.Text = "Herstellen";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // comboBoxDeletedUsers
            // 
            this.comboBoxDeletedUsers.FormattingEnabled = true;
            this.comboBoxDeletedUsers.Location = new System.Drawing.Point(426, 127);
            this.comboBoxDeletedUsers.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDeletedUsers.Name = "comboBoxDeletedUsers";
            this.comboBoxDeletedUsers.Size = new System.Drawing.Size(100, 21);
            this.comboBoxDeletedUsers.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Geblokkeerde gebruikers:";
            // 
            // btnDeletedSearch
            // 
            this.btnDeletedSearch.Location = new System.Drawing.Point(426, 240);
            this.btnDeletedSearch.Name = "btnDeletedSearch";
            this.btnDeletedSearch.Size = new System.Drawing.Size(75, 23);
            this.btnDeletedSearch.TabIndex = 12;
            this.btnDeletedSearch.Text = "Zoeken";
            this.btnDeletedSearch.UseVisualStyleBackColor = true;
            this.btnDeletedSearch.Click += new System.EventHandler(this.btnDeletedSearch_Click);
            // 
            // txtSearchDeleted
            // 
            this.txtSearchDeleted.Location = new System.Drawing.Point(426, 214);
            this.txtSearchDeleted.Name = "txtSearchDeleted";
            this.txtSearchDeleted.Size = new System.Drawing.Size(100, 20);
            this.txtSearchDeleted.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Gebruikers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Medwerker paneel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(645, 404);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeletedSearch);
            this.Controls.Add(this.txtSearchDeleted);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDeletedUsers);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.comboBoxUsers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Bank Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.ComboBox comboBoxDeletedUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeletedSearch;
        private System.Windows.Forms.TextBox txtSearchDeleted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

