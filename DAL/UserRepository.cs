using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserRepository:IRepository<User>
    {
        protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public List<User> users;
        

        public UserRepository()
        {
            users = new List<User>();
            ReadFromSql();
        }
        public void ReadFromSql()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand com = conn.CreateCommand())
            {


                com.CommandText = "SELECT [user_id],[login],[email],[password],[RowInsertTime],[RowUpdateTime],[Salt] FROM [User]";

                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {


                    int user_id = (int)reader["user_id"];
                    string login = (string)reader["login"];
                    string email = (string)reader["email"];
                    byte[] password = (byte[])reader["password"];
                    DateTime RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                    DateTime RowInsertTime = (DateTime)reader["RowInsertTime"];
                    Guid salt = (Guid)reader["Salt"];

                    User tmp = new User(user_id, login, email, password, RowUpdateTime, RowInsertTime,salt);
                    users.Add(tmp);

                }

            }
        }
        public void Add(User list)
        {
            users.Add(list);
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string pass = BitConverter.ToString(list.Password).Replace("-", "").ToLower();
                string pss = "0x" + pass;
                string CommandText = ($"INSERT INTO [User]  ([login],[email],[password],[Salt]) VALUES('{list.Login}','{list.Email}',{pss},'{list.Salt}')");
                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            users.Clear();
            ReadFromSql();
        }



        public List<User> GetList()
        {
            users.Clear();
            ReadFromSql();
            return users;
        }

        public void Update(string Table, int id, string newvalue, string Field)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                int tmp = Convert.ToInt32(newvalue);
                string CommandText = $"UPDATE {Table} SET {Field} ='{tmp}' WHERE user_id={id} ";

                SqlCommand comm = new SqlCommand(CommandText, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }
            users.Clear();
            ReadFromSql();
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string CommandText = $"DELETE FROM User WHERE user_id={id}";

                SqlCommand command = new SqlCommand(CommandText, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].Id == id)
                {
                    users.RemoveAt(i);
                }
            }

        }
    }
}
