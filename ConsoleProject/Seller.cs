using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public Seller(int Id, string name, int rating)
        {
            this.Id = Id;
            this.Name = name;
            this.Rating = rating;
        }
        public void Write()
        {
            Console.WriteLine($"ID: {Id} \nName: {Name} \nRating: {Rating} \n");
        }

    }
}
