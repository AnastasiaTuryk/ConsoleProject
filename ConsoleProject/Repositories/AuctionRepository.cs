using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Repositories
{
    public class AuctionRepository :IAuctionRepository
    {
        private string connStr = "Data Source=DESKTOP-K3G2FJG;Initial Catalog=AuctionManager;Integrated Security=True";
        public List<Auction> auctionsList;
        public AuctionRepository()
        {
            auctionsList = new List<Auction>();
            ReadFromSql();
        }
        public void ReadFromSql()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand com = conn.CreateCommand())
            {
                

                com.CommandText = "select start_time,end_time,start_price,end_price,active,id_good,id_auction from Auction" ;

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while(reader.Read())
                {
                    
                    DateTime Start_time = (DateTime)reader["start_time"];
                    DateTime End_time = (DateTime)reader["end_time"];
                    int start_price = (int)reader["start_price"];
                    int end_price = (int)reader["end_price"];
                    bool Active = (bool)reader["active"];
                    int Id_goods = (int)reader["id_good"];
                    int Id = (int)reader["id_auction"];
                    Auction tmp = new Auction(Id,Start_time,End_time,start_price,end_price,Active,Id_goods);
                    auctionsList.Add(tmp);
                    
                }

            }
        }
        public void Add(Auction list)
        {
            auctionsList.Add(list);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sqlStartDate = list.Start_time.ToString("yyyy-MM-dd");
                string sqlEndDate = list.End_time.ToString("yyyy-MM-dd");
                int t = Convert.ToInt32(list.Active);
                string CommandText = ($"INSERT INTO Auction (Start_time,End_time,start_price,end_price,active,id_good) VALUES ("+sqlStartDate+","+sqlEndDate+$",{list.start_price},{list.end_price},{t},{list.Id_goods})");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            auctionsList.Clear();
            ReadFromSql();
        }
        
        public List<Auction> GetList()
        {
            return auctionsList;
        }
        public void ChangeActive(bool act,int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                int actint = Convert.ToInt32(act);
                string CommandText = ($"UPDATE Auction SET active= {actint} WHERE id_auction={id}");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            auctionsList.Clear();
            ReadFromSql();
        }

       
    }
}

