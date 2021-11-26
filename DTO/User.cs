using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Guid Salt { get; set; }

        public DateTime RowUpdateTime { get; set; }
        public DateTime RowInsertTime { get; set; }

        public User (int id,string login,string email,byte[] password, DateTime RowUpdateTime, DateTime RowInsertTime,Guid salt)
        {
            this.Id = id;
            this.Login = login;
            this.Email = email;
            this.Password = password;
            this.RowUpdateTime = RowUpdateTime;
            this.RowInsertTime = RowInsertTime;
            this.Salt = salt;
        }
    }
}
