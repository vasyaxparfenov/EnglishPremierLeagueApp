using System;
using System.Linq;
using EnglishPremierLeagueApp;
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
    }
}
