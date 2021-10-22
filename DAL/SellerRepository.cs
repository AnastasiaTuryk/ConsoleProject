using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SellerRepository : IRepository<Seller>
    {
        //private string connStr = "Data Source=DESKTOP-K3G2FJG;Initial Catalog=AuctionManager;Integrated Security=True";
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public List<Seller> sellerList;
        public SellerRepository()
        {
            sellerList = new List<Seller>();
            ReadFromSql();
        }
        public void ReadFromSql()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand com = conn.CreateCommand())
            {


                com.CommandText = "select id,name,rating,RowUpdateTime,RowInsertTime from Seller";

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {


                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                    DateTime RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                    DateTime RowInsertTime = (DateTime)reader["RowInsertTime"];

                    int rating = (int)reader["rating"];
                    Seller tmp = new Seller(id, name, rating, RowUpdateTime, RowInsertTime);
                    sellerList.Add(tmp);

                }

            }
        }
        public void Add(Seller list)
        {
            sellerList.Add(list);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = ($"INSERT INTO Seller (name,rating) VALUES ('{list.Name}',,{list.Rating}");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            sellerList.Clear();
            ReadFromSql();
        }



        public List<Seller> GetList()
        {
            return sellerList;
        }

        public void Update(string Table, int id, string newvalue, string Field)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                int tmp = Convert.ToInt32(newvalue);
                string CommandText = $"UPDATE {Table} SET {Field} ='{tmp}' WHERE id={id} ";

                SqlCommand comm = new SqlCommand(CommandText, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            sellerList.Clear();
            ReadFromSql();
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = $"DELETE FROM Seller WHERE id={id}";

                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            for (int i = 0; i < sellerList.Count(); i++)
            {
                if (sellerList[i].Id == id)
                {
                    sellerList.RemoveAt(i);
                }
            }

        }
    }
}
