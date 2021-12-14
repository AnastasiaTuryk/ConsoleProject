using System;
using System.Collections.Generic;
using DAL;
using DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class BusinessUser
    {
        public IRepository<User> user = new UserRepository();
        List<User> listUs;

        public BusinessUser()
        {
            listUs=user.GetList();
        }
        
        public void CreateUser(string password,string email,string login)
        {
            if(listUs.Any(u=> u.Login ==login))
            {
                throw new Exception("User already is exists!");
            }
            Guid salt = Guid.NewGuid();
            DateTime dateTime = DateTime.UtcNow;
            int id = 0;
            var users = new User(id,login, email, hash(password, salt.ToString()), dateTime, dateTime,salt);
            user.Add(users);
        }


        public bool Login(string login,string password)
        {
            User us = listUs.SingleOrDefault(u => u.Login == login);
            return us != null && us.Password.SequenceEqual(hash(password, us.Salt.ToString()));
        }
        private byte[] hash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }


        
    }
}
