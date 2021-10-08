using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Auction
    {
        public int Id { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public int start_price { get; set; }
        public int end_price { get; set; }
        public bool Active { get; set; }
        public int Id_goods { get; set; }

        public Auction(int Id_auction, DateTime start_time,DateTime end_time,int start_price,int end_price,bool active,int id_goods)
        {
            this.Id=Id_auction;
            this.Start_time = start_time;
            this.End_time = end_time;
            this.start_price = start_price;
            this.end_price = end_price;
            this.Active = active;
            this.Id_goods = id_goods;
        }
        public void Write()
        {
            Console.WriteLine($"ID: {Id} \nStart time: {Start_time} \nEnd time: {End_time} \nstart price: {start_price} \nend price: {end_price} \nActive: {Active} \nId goods: {Id_goods} \n");
        }
    }
}
