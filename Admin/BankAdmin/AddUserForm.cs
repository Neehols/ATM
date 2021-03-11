using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAdmin
{
    public partial class AddUserForm : Form
    {
        Database database;
        User user;
        BankDetails bank = new BankDetails();
        public AddUserForm(Database _database)
        {
            user = new User();
            database = _database;
            InitializeComponent();
        }

        int page = 0;
        bool error = false;
        private void button1_Click(object sender, EventArgs e)
        {
                if (page == 0)
                {
                    user.FirstName = textBox1.Text;
                    lblUserDataName.Text = "Achternaam";
                }
                else if (page == 1)
                {
                    user.LastName = textBox1.Text;
                    lblUserDataName.Text = "Geslacht";
                }
                else if (page == 2)
                {
                    user.Gender = textBox1.Text;
                    lblUserDataName.Text = "Email";
                }
                else if (page == 3)
                {
                    user.Email = textBox1.Text;
                    lblUserDataName.Text = "Stad";
                }
                else if (page == 4)
                {
                    user.City = textBox1.Text;
                    lblUserDataName.Text = "ZIP / Postcode";
                }
                else if (page == 5)
                {
                    user.PostalCode = textBox1.Text;
                    lblUserDataName.Text = "Adres";
                }
                else if (page == 6)
                {
                    user.Street = textBox1.Text;
                    lblUserDataName.Text = "Telefoonnummer";
                }
                else if (page == 7)
                {
                    try
                    {
                        user.Telephone = int.Parse(textBox1.Text);
                        error = false;
                        lblUserDataName.Text = "Pincode";
                    }
                    catch
                    {
                        MessageBox.Show("Voer een nummer in.");
                        error = true;
                    }
                }
                else if (page == 8)
                {
                    user.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(textBox1.Text);
                    Form1.globalUser = user;
                    this.Close();
                }
            if (error == false)
            {
                textBox1.Text = "";
                page++;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, null);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
