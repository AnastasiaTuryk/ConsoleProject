using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public DateTime RowInsertTime { get; set; }

        public Seller(int Id, string name, int rating, DateTime RowUpdateTime, DateTime RowInsertTime)
        {
            this.Id = Id;
            this.Name = name;
            this.Rating = rating;
            this.RowUpdateTime = RowUpdateTime;
            this.RowInsertTime = RowInsertTime;
        }
        public void Write()
        {
            Console.WriteLine($"ID: {Id} \nName: {Name} \nRating: {Rating} \n");
        }

    }
}
