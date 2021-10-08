using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private string connStr = "Data Source=DESKTOP-K3G2FJG;Initial Catalog=AuctionManager;Integrated Security=True";
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


                com.CommandText = "select id,name,rating from Seller";

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {


                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                    

                    int rating = (int)reader["rating"];
                    Seller tmp = new Seller(id, name, rating);
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
    }
}
