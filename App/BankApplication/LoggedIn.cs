using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Globalization;

namespace BankApplication
{
    public partial class LoggedIn : Form
    {
        BankDetails account = new BankDetails();
        SQL sql;
        public LoggedIn(BankDetails _account, SQL _sql)
        {
            sql = _sql;
            account = _account;
            var userName = Transaction.GetUserName(account.UserID);
            InitializeComponent();
            lblUserName.Text = userName; 
            LoadSaldo();
            LoadTransactions();
        }

        private void LoggedIn_Load(object sender, EventArgs e)
        { 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double depositValue;
            bool depositing = true;
            var message = "";
            while (depositing)
            {
                var test = Interaction.InputBox("Hoeveel geld wilt u overmaken? "+message, "Overmaken");
                var result = Double.TryParse(test, out depositValue);
                depositing = false;
                if (test == "" || test.Contains("-"))
                {
                    MessageBox.Show("Storten geannuleerd.", "Geannuleerd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == true)
                {
                    var transaction = new Transaction() { BankID = account.AccountID, Date = new Date().Now().ToString("yyyy-MM-dd H:mm:ss"), Type = "Deposit", Value = depositValue };
                    sql.InsertClass(typeof(Transaction), transaction);
                    account.UpdateSaldo(depositValue, account.AccountID);
                }
                else if (result == false)
                {
                    message = "(voer een nummer in a.u.b)";
                    depositing = true;
                }
            }
            LoadSaldo();
            LoadTransactions();
        }
        private void LoadSaldo()
        {
            lblBalance.Text = "€ "+account.GetSaldo(account.AccountID); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(Transaction.DailyWithdrawCount(account.AccountID)) < 3)
            {

                var currentBalance = double.Parse(account.GetSaldo(account.AccountID));
                if (currentBalance > 0)
                {
                    double withdrawValue;
                    bool withdrawing = true;
                    var message = "";
                    while (withdrawing)
                    {
                        var test = Interaction.InputBox("Hoeveel geld wilt u opnemen? " + message, "Opnemen");
                        var result = Double.TryParse(test, out withdrawValue);
                        if(result == true)
                        result = withdrawValue % 5 == 0 ? true : false;
                        withdrawing = false;
                        if (test == "" || test.Contains("-") || withdrawValue<=0)
                        {
                            MessageBox.Show("Opnemen geannuleerd.", "Geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == true)
                        {
                            if (withdrawValue > currentBalance)
                            {
                                MessageBox.Show("U heeft niet genoeg op uw saldo staan", "Withdraw failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if(withdrawValue > 500)
                            {
                                MessageBox.Show("U heeft de maximale grens van €500 per transactie overschreden.", "Opnemen geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                var transaction = new Transaction() { BankID = account.AccountID, Date = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss"), Type = "Withdraw", Value = -withdrawValue };
                                sql.InsertClass(typeof(Transaction), transaction);
                                account.UpdateSaldo(-withdrawValue, account.AccountID);
                            }
                        }
                        else if (result == false)
                        {
                            message = "(Een bedrag opnemen moet deelbaar zijn door 5)";
                            withdrawing = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("U heeft niet genoeg saldo", "Opnemen geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                LoadSaldo();
                LoadTransactions();
            }
            else
            {
                MessageBox.Show("U heeft het limiet bereikt van 3x geld opnemen per dag.", "Opnemen geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadTransactions()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            dataGridView1.Columns.Add("", "Type");
            dataGridView1.Columns.Add("", "Value");
            dataGridView1.Columns.Add("", "Date");
            var transactions = Transaction.GetLatestTransactions(account.AccountID);
            foreach (var transaction in transactions)
            {
                dataGridView1.Rows.Add(transaction.Type, transaction.Value.ToString()+ "€", transaction.Date.ToString());
            }
        }
      private void lblUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
