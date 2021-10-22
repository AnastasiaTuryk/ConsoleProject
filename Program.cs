using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Command cmd = new Command();
			bool menu = false;
			

			while (true)
			{
				Console.WriteLine("\t\t\t\t\t\t\tChoose that you want:\n");

				Console.WriteLine("\t0-to exit!");
				Console.WriteLine("\t1-to see all auction");
				Console.WriteLine("\t2-to add auction");
				Console.WriteLine("\t3-to change active of auction");

				Console.WriteLine("\t4-to see all goods");
				Console.WriteLine("\t5-to add goods");
				Console.WriteLine("\t6-to delete goods by index");

				Console.WriteLine("\t7-to see list of seller");
				Console.WriteLine("\t8-to add seller");
                Console.WriteLine("\t9-to sort rating of seller\n\n");
                
                
				
				Console.Write("input your number:");

				int Input; Input = int.Parse(Console.ReadLine());
				switch (Input)
				{
					case 0:
						menu = true;
						break;
					case 1:
						{
							cmd.WriteAuction();
							break;
						}
					case 2:
						{
                            DateTime start_time; DateTime end_time; int start_price; int end_price; bool active;
                            int id; int id_goods; 
                            Console.WriteLine("input start time:"); start_time = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("input end time:"); end_time = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("input start price:"); start_price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("input end price:"); end_price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("input active :"); active = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("input id_goods:"); id_goods = Convert.ToInt32(Console.ReadLine());
							DateTime rowinsert = DateTime.UtcNow;
							DateTime rowupdate = DateTime.UtcNow;
							Auction ac = new Auction(id, start_time, end_time, start_price, end_price, active, id_goods, rowupdate, rowinsert);
                            cmd.AddAuction(ac);
                            break;
                        }
					case 3:
						{
							int id; Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
							cmd.ChangeAct(id);
							break;
						}
					case 4:
						{
							cmd.WriteGoods();
							break;
						}
					case 5:
						{
                            int id;string name; string material;int id_seller;
							Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("input name:"); name = (Console.ReadLine());
                            Console.WriteLine("input material:"); material = (Console.ReadLine());
                            Console.WriteLine("input id_seller:"); id_seller = Convert.ToInt32(Console.ReadLine());
							DateTime rowinsert = DateTime.UtcNow;
							DateTime rowupdate= DateTime.UtcNow;

							Goods gd = new Goods(id, name, material, id_seller, rowupdate, rowinsert);
                            cmd.AddGoods(gd);

                            break;
                        }
					case 6:
						{
							int id; Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
							cmd.DeleteId(id);
							break;
						}
					case 7:
                        {
							cmd.WriteSeller();
							break;
                        }
					case 8:
                        {
							int id;string name;int rating;
							Console.WriteLine("input id:"); id = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("input name:"); name = (Console.ReadLine());
							Console.WriteLine("input rating:"); rating = Convert.ToInt32(Console.ReadLine());
							DateTime rowinsert = DateTime.UtcNow;
							DateTime rowupdate = DateTime.UtcNow;

							Seller sl = new Seller(id, name, rating, rowupdate, rowinsert);
							cmd.AddSeller(sl);
							break;

                        }
					case 9:
                        {
							cmd.SortRating();
							break;

                        }
					default:
						break;
				}
				if (menu)
					break;
			}
		}
    }
}

