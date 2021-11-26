using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using DTO;
using DAL;
using BusinessLogic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionWindowsForm
{
    public partial class GoodsForm : Form
    {
        IRepository<Goods> repository = new GoodsRepository();
        IRepository<Auction> auction = new AuctionRepository();
        BusinessGoods goods = new BusinessGoods();
       
        public GoodsForm()
        {
            InitializeComponent();
            textBox1.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            textBox1.Text = "search";
            textBox1.ForeColor = Color.Gray;
            Print(repository.GetList());
        }

        public void Print(List<Goods> rep)
        {
            dataGridView1.RowCount = rep.Count;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "NAME";
            dataGridView1.Columns[2].HeaderText = "MATERIAL";
            dataGridView1.Columns[3].HeaderText = "SELLER ID";
            dataGridView1.Columns[4].HeaderText = "ROW UPDATE TIME";
            dataGridView1.Columns[5].HeaderText = "ROW INSERT TIME";

            for (int i = 0; i < rep.Count; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (j == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Id;
                    }
                    if (j == 1)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Name;
                    }
                    if (j == 2)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Material;
                    }
                    if (j == 3)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Id_seller;
                    }
                    if (j == 4)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].RowUpdateTime;
                    }
                    if (j == 5)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].RowInsertTime;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//add
        {
            AddGoodForm addGood = new AddGoodForm();
            addGood.Show();
            Print(repository.GetList());
        }

        private void pictureBox2_Click(object sender, EventArgs e)//delete
        {
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if((Convert.ToInt32( dataGridView1.CurrentRow.Cells[0].Value)==repository.GetList()[i].Id))
                {
                    repository.Delete(repository.GetList()[i].Id);
                }
            }
            Print(repository.GetList());
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)//sort
        {
            Print(goods.SortGoods());
        }

        private void button1_Click(object sender, EventArgs e)//search
        {
            string name = textBox1.Text;
            Print(goods.Search(name));
        }

      

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "search";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "search")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)//search
        {
            
            textBox1.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Print(repository.GetList());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if ((Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) == repository.GetList()[i].Id))
                {
                    auction.Update("Auction", Convert.ToInt32(idtextbox.Text), Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value), "id_good");
                }
            }

        }
    }
}
