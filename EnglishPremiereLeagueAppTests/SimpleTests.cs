using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data;
using EnglishPremierLeagueApp;
using EnglishPremierLeagueApp.Models;
using EnglishPremierLeagueApp.ModelsOLD;
using EnglishPremierLeagueApp.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnglishPremiereLeagueAppTests
{
    [TestClass]
    public class UnitTest
    {
        
        [TestMethod]
        public void MinDateOfScheduleTableTest()
        {
            using (var context = new FootballLeagueEntities())
            {
                
                Assert.AreEqual(context.Games.Min(game => game.DateOfGame),
                    context.Games.OrderBy(game => game.DateOfGame).ToList().ElementAt(0).DateOfGame);
            }
        }


        [TestMethod]
        public void BindingListTest()
        {
            using (var context = new FootballLeagueContext())
            {
                var a = context.Users.Local.Count;
                Assert.IsTrue(a == 0);
            }
        }

        [TestMethod]
        public void RepositoryTest()
        {
            using (var context = new FootballLeagueContext())
            {
                var repo = new Repository<Users>(context);
                Assert.AreEqual((repo.GetAllOrderedBy(OrderTypeEnum.Descending, usr => usr.Login) as List<Users>)?.Count,
                    repo.GetAll().OrderByDescending(usr => usr.Login).ToList().Count);
            }
        }
        [TestMethod]
        public void TransferStatusTest()
        {
            using (var context = new FootballLeagueContext())
            {
                var transferStatus = context.Transfers.Single().Status;
                Assert.IsTrue(transferStatus.Equals(TransferStatus.Pending));
            }
        }
        [TestMethod]
        public void TrasferStatusSetTest()
        {
            using (var context = new FootballLeagueContext())
            {
                context.Transfers.Single().Status = TransferStatus.Accepted;
            }
        }
        [TestMethod]
        public void LoadMethodTest()
        {
            using (var context = new FootballLeagueContext())
            {
                context.Users.Load();
                var user = new Users
                {
                    Login = "qwe",
                    Password = "asd"
                };
                var local1 = context.Users.Local;
                context.Users.Local.Add(user);
                context.Users.Load();
                var local2 = context.Users.Local;
                Assert.IsNotNull(context.Users.Local.Single(usr => usr.Equals(user)));
                Assert.IsTrue(ReferenceEquals(local1, local2));
            }
        }

        [TestMethod]
        public void RepositoryFactoryTest()
        {
            using (var context = new FootballLeagueContext())
            {
                RepositoryFactory.Register<IRepository<Players>, Repository<Players>>();
                var repository = RepositoryFactory.CreateRepository<IRepository<Players>>(context);
                var player = repository.Get(0);
            }
        }
    }
}
