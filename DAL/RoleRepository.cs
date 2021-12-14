using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class RoleRepository
    {
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public List<Role> List;
        public RoleRepository()
        {
            List = new List<Role>();
            ReadFromSql();
        }
        public void ReadFromSql()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand com = conn.CreateCommand())
            {


                com.CommandText = "select id,name from Role";

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {


                    int id = (int)reader["id"];
                    string name = (string)reader["name"];
                   

                    
                    Role tmp = new Role(name,id);
                    List.Add(tmp);

                }

            }
        }
        public void Add(Role list)
        {
            List.Add(list);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = ($"INSERT INTO Role (name) VALUES ('{list.Name}')");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            List.Clear();
            ReadFromSql();
        }



        public List<Role> GetList()
        {
            return List;
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
            List.Clear();
            ReadFromSql();
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = $"DELETE FROM Role WHERE id={id}";

                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            for (int i = 0; i < List.Count(); i++)
            {
                if (List[i].ID == id)
                {
                    List.RemoveAt(i);
                }
            }

        }
    }
}

