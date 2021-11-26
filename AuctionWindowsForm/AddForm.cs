using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DTO;
using DAL;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionWindowsForm
{
    public partial class AddForm : Form
    {
        IRepository<Auction> repository = new AuctionRepository();
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                int id_goods = 1;
                DateTime start_time =Convert.ToDateTime(textBox1.Text);
                DateTime end_time = Convert.ToDateTime(textBox3.Text);
                int start_price = Convert.ToInt32(textBox4.Text);
                int end_price = Convert.ToInt32(textBox2.Text);
                DateTime dateTime1 = DateTime.UtcNow;
                DateTime dateTime2 = DateTime.UtcNow;
                bool active;
                if (checkBox1.Checked==true)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }
                Auction auction = new Auction(id, start_time, end_time, start_price, end_price, active, id_goods, dateTime1, dateTime2);
                repository.Add(auction);
                MessageBox.Show("Success");
                MainForm mainForm = new  MainForm() ;
                // mainForm.dataGridView1.Refresh();
                mainForm.Print(repository.GetList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Hide();
        }
    }
}
