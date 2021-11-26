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
    public partial class AddGoodForm : Form
    {
        IRepository<Goods> repository = new GoodsRepository();
        IRepository<Seller> sell_rep = new SellerRepository();
        public AddGoodForm()
        {
            InitializeComponent();
            for (int i = 0; i < sell_rep.GetList().Count; i++)
            {
              
                listBox1.Items.Add(sell_rep.GetList()[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                int seller_id=0;
                string name = textBox1.Text;
                string material = textBox3.Text;
                string seller_name =Convert.ToString( listBox1.SelectedItem);
                DateTime dateTime1 = DateTime.UtcNow;
                DateTime dateTime2 = DateTime.UtcNow;
                foreach (var s in sell_rep.GetList())
                {
                    if (s.Name == seller_name)
                        seller_id = s.Id;
                }
                Goods goods = new Goods(id, name,material,seller_id,dateTime1,dateTime2);
                repository.Add(goods);
                MessageBox.Show("Sucсess");
                GoodsForm goodsForm = new GoodsForm();
                goodsForm.Print(repository.GetList());
               
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Hide();
        }


    }
}
