using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DAL;
using DTO;
using BusinessLogic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuctionWindowsForm
{
    public partial class MainForm : Form
    {
        IRepository<Auction> repository = new AuctionRepository();
        BusinessAuction business = new BusinessAuction();
        
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;

            //dataGridView1.DataSource = repository.GetList();

            Print(repository.GetList());
            dataGridView1.ReadOnly = true;




        }
        public void Print(List<Auction> rep)
        {
            //dataGridView1.RowCount = repository.GetList().Count;
            dataGridView1.RowCount = rep.Count;
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "START_TIME";
            dataGridView1.Columns[2].HeaderText = "END_TIME";
            dataGridView1.Columns[3].HeaderText = "START_PRICE";
            dataGridView1.Columns[4].HeaderText = "END_PRICE";
            dataGridView1.Columns[5].HeaderText = "ACTIVE";
            dataGridView1.Columns[6].HeaderText = "ID_GOODS";
            dataGridView1.Columns[7].HeaderText = "ROW_UPDATE_TIME";
            dataGridView1.Columns[8].HeaderText = "ROW_INSERT_TIME";
           
            for (int i = 0; i < rep.Count; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Id;
                    }
                    if (j == 1)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Start_time;
                    }
                    if (j == 2)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].End_time;
                    }
                    if (j == 3)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].start_price;
                    }
                    if (j == 4)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].end_price;
                    }
                    if (j == 5)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Active;
                    }
                    if (j == 6)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].Id_goods;
                    }
                    if (j == 7)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].RowUpdateTime;
                    }
                    if (j == 8)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = rep[i].RowInsertTime;
                    }

                }

            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

      

        private void button1_Click(object sender, EventArgs e)//active auction
        {
            //dataGridView1.DataSource = business.ActiveAuction();
            //dataGridView1.Refresh();
            Print(business.ActiveAuction());
        }

        
        private void button2_Click(object sender, EventArgs e)//disactive ausction
        {
            //dataGridView1.DataSource = business.DisactiveAuction();
            //dataGridView1.Refresh();
            Print(business.DisactiveAuction());
        }

        private void button3_Click(object sender, EventArgs e)//all auctions
        {
            //dataGridView1.DataSource = repository.GetList();
            //dataGridView1.Refresh();
            Print(repository.GetList());
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)//add
        {
            AddForm form = new AddForm();
            form.Show();

            //dataGridView1.Refresh();
           Print(repository.GetList());
        }

        private void pictureBox2_Click(object sender, EventArgs e)//delete
        {
            for (int i = 0; i < repository.GetList().Count; i++)
            {
                if ((Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) == repository.GetList()[i].Id))
                {
                    repository.Delete(repository.GetList()[i].Id);
                }
            }
            //dataGridView1.Refresh();
            Print(repository.GetList());
        }

        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                
                GoodsForm goodForm = new GoodsForm();
                goodForm.idtextbox.Text= Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                goodForm.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)//refresh
        {
            Print(repository.GetList());
        }
    }

   
}
