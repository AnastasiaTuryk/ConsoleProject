using MySql.Data.MySqlClient;
using System;
using BusinessLogic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionWindowsForm
{
    public partial class Form1 : Form
    {
        BusinessUser business = new BusinessUser();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string passUser = textBox2.Text;
            business.Login(loginUser, passUser);
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm form = new RegisterForm();
            form.Show();
        }
    }
}
