using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using DTO;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicTests
{
    [TestClass]
    public class UnitTestBusiness
    {
        IRepository<User> users_rep = new UserRepository();
        IRepository<Auction> auctions_rep = new AuctionRepository();
        BusinessUser businessUser = new BusinessUser();
        BusinessAuction businessAuction = new BusinessAuction();
        BusinessGoods businessGoods = new BusinessGoods();

        [TestMethod]
        public void TestCreateUser()
        {
            string password = "admin";
            string email = "admin";
            string login = "admin";
            businessUser.CreateUser(password, email, login);
            Assert.IsTrue(users_rep.GetList().Any(x => x.Login==login && x.Email==email));
        }

        //[TestMethod]
        //public void TestLogin()
        //{

        //}

        [TestMethod]
        public void TestActiveAuctions()
        {
            List<Auction> list = new List<Auction>();
            Auction expected = new Auction(1, Convert.ToDateTime("2002.06.05"), Convert.ToDateTime("2002.06.07"), 100, 200, true, 1, DateTime.Now, DateTime.Now);
            list.Add(expected);
            //List<Auction> actual = new List<Auction>();
            var actual=businessAuction.ActiveAuction();
            Assert.AreEqual(expected, actual);

          
        }
        [TestMethod]
        public void TestDisactiveAuctions()
        {
            List<Auction> list = new List<Auction>();
            Auction expected = new Auction(1, Convert.ToDateTime("2002.06.05"), Convert.ToDateTime("2002.06.07"), 100, 200, false, 1, DateTime.Now, DateTime.Now);
            list.Add(expected);
            List<Auction> actual = new List<Auction>();
            actual = businessAuction.DisactiveAuction();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSortGoods()
        {
            List<Goods> goods = new List<Goods>();
            Goods expected1 = new Goods(1, "vasa", "glass", 1, DateTime.Now, DateTime.Now);
            Goods expected2 = new Goods(2, "coin", "aluminum", 1, DateTime.Now, DateTime.Now);
            Goods expected3 = new Goods(3, "picture", "oil", 1, DateTime.Now, DateTime.Now);
            goods.Add(expected1);
            goods.Add(expected2);
            goods.Add(expected3);

            List<Goods> goods1 = new List<Goods>();
            goods1 = businessGoods.SortGoods();

            Assert.AreEqual(goods, goods1);
        }

        [TestMethod]
        public void TestSearchGoods()
        {
            List<Goods> expected = new List<Goods>();
            Goods goods = new Goods(1, "vasa", "glass", 1, DateTime.Now, DateTime.Now);
            expected.Add(goods);
            var actual = businessGoods.Search("vasa");
            Assert.AreEqual(expected, actual);
        }

    }
}
