using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DTO;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TestsAuction
{
    [TestClass]
    public class BusinessLogicTests
    {
        IRepository<User> users_rep = new UserRepository();
        IRepository<Goods> goods_rep = new GoodsRepository();
        IRepository<Auction> auctions_rep = new AuctionRepository();
        BusinessUser businessUser = new BusinessUser();
        BusinessAuction businessAuction = new BusinessAuction();
        BusinessGoods businessGoods = new BusinessGoods();

        [TestMethod]
        public void TestCreateUser()
        {
            string password = "testm1";
            string email = "testm1";
            string login = "testm1";
            businessUser.CreateUser(password, email, login);
            Assert.IsTrue(users_rep.GetList().Any(x => x.Login == login && x.Email == email));
        }

        [TestMethod]
        public void TestActiveAuctions()
        {
            List<Auction> list = new List<Auction>();
            Auction actual = new Auction(3, Convert.ToDateTime("1905.06.17"), Convert.ToDateTime("1905.06.18"), 50, 200, true, 1, DateTime.Now, DateTime.Now);
            list.Add(actual);
            //List<Auction> actual = new List<Auction>();
            List<Auction> expected = businessAuction.ActiveAuction();
            Assert.AreEqual(actual.start_price, expected[0].start_price);
            Assert.AreEqual(actual.end_price, expected[0].end_price);
            Assert.AreEqual(actual.Active, expected[0].Active);


        }
        [TestMethod]
        public void TestDisactiveAuctions()
        {
            List<Auction> list = new List<Auction>();
            Auction expected = new Auction(1, Convert.ToDateTime("2002.06.05"), Convert.ToDateTime("2002.06.07"), 100, 123, false, 1, DateTime.Now, DateTime.Now);
            list.Add(expected);
            List<Auction> actual = new List<Auction>();
            actual = businessAuction.DisactiveAuction();
            Assert.AreEqual(actual[0].start_price, expected.start_price);
            Assert.AreEqual(actual[0].end_price, expected.end_price);
            Assert.AreEqual(actual[0].Active, expected.Active);
        }

        [TestMethod]
        public void TestSortGoods()
        {
            List<Goods> goods = new List<Goods>();
            
            for (int i = 0; i < goods_rep.GetList().Count; i++)
            {
                goods.Add(goods_rep.GetList()[i]);
            }
            
            
            List<Goods> goods1 = new List<Goods>();
            goods1 = businessGoods.SortGoods();
            bool check = false;
            for (int i = 0; i < goods1.Count; i++)
            {
                if (goods[i].RowInsertTime == goods1[i].RowInsertTime)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }

            Assert.IsTrue(check);
         
        }

        [TestMethod]
        public void TestSearchGoods()
        {
            
            Goods expected =goods_rep.GetList()[0];
            List<Goods> actual = businessGoods.Search("vasa");
            Assert.AreEqual(actual[0].Name, expected.Name);
        }

    }
}
