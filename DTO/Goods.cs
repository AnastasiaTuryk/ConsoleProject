using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Goods
    {
        public int Id { get; set; }
        public int Id_seller { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }

        public DateTime RowUpdateTime { get; set; }
        public DateTime RowInsertTime { get; set; }

        public Goods(int Id, string name, string material, int id_seller, DateTime RowUpdateTime, DateTime RowInsertTime)
        {
            this.Id = Id;
            this.Name = name;
            this.Material = material;
            this.Id_seller = id_seller;
            this.RowUpdateTime = RowUpdateTime;
            this.RowInsertTime = RowInsertTime;
        }
        public void Write()
        {
            Console.WriteLine($"ID: {Id} \nName: {Name} \nMaterial: {Material} \nId seller: {Id_seller} \n");
        }
    }
}
