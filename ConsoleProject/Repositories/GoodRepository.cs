using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public class GoodRepository : IGoodRepository
    {
        private string connStr = "Data Source=DESKTOP-K3G2FJG;Initial Catalog=AuctionManager;Integrated Security=True";
        public List<Goods> goodsList;
        public GoodRepository()
        {
            goodsList = new List<Goods>();
            ReadFromSql();
        }
        public void ReadFromSql()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand com = conn.CreateCommand())
            {


                com.CommandText = "select id,name,material,seller_id from Goods";

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {

                    
                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                    string material = (string)reader["material"];
            
                    int id_seller = (int)reader["seller_id"];
                    Goods tmp = new Goods(id, name, material, id_seller);
                    goodsList.Add(tmp);

                }

            }
        }
        public void Add(Goods list)
        {
            goodsList.Add(list);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                string CommandText = ($"INSERT INTO Goods (name,material,seller_id) VALUES ('{list.Name}','{list.Material}',{list.Id_seller})");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            goodsList.Clear();
            ReadFromSql();
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = $"DELETE FROM Goods WHERE id={id}";

                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            for (int i = 0; i < goodsList.Count(); i++)
            {
                if(goodsList[i].Id==id)
                {
                    goodsList.RemoveAt(i);
                }
            }
            //ReadFromSql();
        }
        

        public List<Goods> GetList()
        {
            return goodsList;
        }

       
    }
}
