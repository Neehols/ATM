using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;
using System.IO;

namespace BankAdmin 
{
    public partial class Form1 : Form 
    {

        Database database;
        SQL sql;
        Random rnd = new Random();
        public static User globalUser;
        public User usersql;
        public List<User> databaseCache;
        public List<User> deletedDatabaseCache;

       
        public string[] username = {};

        public Form1() 
        {
            InitializeComponent();
            
            string connectionString = "";
            try
            {
                connectionString = File.ReadAllText(Directory.GetCurrentDirectory() + @"\connectionstring.txt");
            }
            catch
            {
                MessageBox.Show("Please make sure connectionstring.txt is in the same folder as this program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            
            database = new Database(connectionString);
           
            sql = new SQL(database);
            usersql = new User();
            databaseCache = usersql.GetUserNamesBankNumbers();
            GetDeletedUserNames();
            GetUserNames();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedIndex != -1)
            {
                var id = ((int[])comboBoxUsers.Tag)[comboBoxUsers.SelectedIndex];
                var user = usersql.GetSingleUser(id.ToString());
                var EditUserDialog = new EditUserForm(user, sql);
                var result = EditUserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    sql.EditClass(typeof(User), EditUserForm.globalUser);
                    if (EditUserForm.globalUser.Password != null)
                    {
                        BankDetails.UpdatePin(EditUserForm.globalUser.Password, EditUserForm.globalUser.UserId.ToString());
                    }

                }
                if (result == DialogResult.Yes)
                {
                    GetUserNames();
                    comboBoxUsers.Text = "";
                    comboBoxUsers.SelectedIndex = -1;
                }
                else
                {
                    GetUserNames();
                }
                GetDeletedUserNames();
            }
        }

        public void GetUserNames()
        {
            // put 'name' data in database into combobox
            databaseCache = usersql.GetUserNamesBankNumbers();
            comboBoxUsers.DataSource = databaseCache.Select(x=> x.FirstName).ToArray();
            comboBoxUsers.Tag = databaseCache.Select(x => x.UserId).ToArray();

        }
        public void GetDeletedUserNames()
        {
            deletedDatabaseCache = usersql.GetDeletedUserNamesBankNumbers();
            comboBoxDeletedUsers.DataSource = deletedDatabaseCache.Select(x => x.FirstName).ToArray();
            comboBoxDeletedUsers.Tag = deletedDatabaseCache.Select(x => x.UserId).ToArray();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var AddUserDialog = new AddUserForm(database);
            AddUserDialog.ShowDialog();
            sql.InsertClass(typeof(User), globalUser);
            var userId = usersql.LastId();
            var bankdetails = new BankDetails() { BankAccountNumber = GenerateBankNumber(), BankAccountPin = globalUser.Password, BankBalance = 0, UserId = userId };
            sql.InsertClass(typeof(BankDetails), bankdetails);
            GetUserNames();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                var result = databaseCache.Where(name => name.FirstName.Contains(txtSearch.Text) || ((Dictionary<string, string>)name.JoinCollumns)["bank_rekeningnummer"].Contains(txtSearch.Text));
                comboBoxUsers.DataSource = result.Select(x => x.FirstName).ToArray();
                comboBoxUsers.Tag = result.Select(x => x.UserId).ToArray();
            }
            else
            {
                comboBoxUsers.DataSource = databaseCache.Select(x=> x.FirstName).ToArray();
                comboBoxUsers.Tag = databaseCache.Select(x => x.UserId).ToArray();
            }
            comboBoxUsers.Focus();
            comboBoxUsers.DroppedDown = true;
        }
        private Int64 GenerateBankNumber()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                sb.Append(rnd.Next(0, 9));
            }
            return Convert.ToInt64(sb.ToString());
        }

        private void btnDeletedSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                var result = deletedDatabaseCache.Where(name => name.FirstName.Contains(txtSearchDeleted.Text) || ((Dictionary<string, string>)name.JoinCollumns)["bank_rekeningnummer"].Contains(txtSearchDeleted.Text));
                comboBoxDeletedUsers.DataSource = result.Select(x => x.FirstName).ToArray();
                comboBoxDeletedUsers.Tag = result.Select(x => x.UserId).ToArray();
            }
            else
            {
                comboBoxDeletedUsers.DataSource = deletedDatabaseCache.Select(x => x.FirstName).ToArray();
                comboBoxDeletedUsers.Tag = deletedDatabaseCache.Select(x => x.UserId).ToArray();
            }
            comboBoxDeletedUsers.Focus();
            comboBoxDeletedUsers.DroppedDown = true;
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            if (comboBoxDeletedUsers.SelectedIndex != -1)
            {
                BankDetails.ChangeAccountState(((int[])comboBoxDeletedUsers.Tag)[comboBoxDeletedUsers.SelectedIndex].ToString());
                comboBoxDeletedUsers.SelectedIndex = -1;
                GetDeletedUserNames();
                GetUserNames();
            }
        }
    }
}
