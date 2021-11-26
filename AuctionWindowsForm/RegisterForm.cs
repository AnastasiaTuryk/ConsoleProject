using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BusinessLogic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionWindowsForm
{
    public partial class RegisterForm : Form
    {
        BusinessUser business = new BusinessUser(); 
        public RegisterForm()
        {
            InitializeComponent();
            textBox1.Text = "input login";
            textBox2.Text = "input password";
            textBox3.Text = "input email";
            textBox1.ForeColor = Color.Gray;
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            FormClosing += RegisterForm_FormClosing;

        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "input login")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
                
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "input login";
                textBox1.ForeColor = Color.Gray;
            }
                
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "input password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "input password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "input email")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "input email";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            string emailUser = textBox3.Text;
            business.CreateUser(passUser, emailUser, loginUser);
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }
    }
}
