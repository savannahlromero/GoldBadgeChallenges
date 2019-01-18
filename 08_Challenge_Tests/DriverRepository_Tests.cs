using System;
using System.Linq;
using _08_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_Challenge_Tests
{
    [TestClass]
    public class DriverRepository_Tests
    {
        [TestMethod]
        public void AddAndGetList()
        {
            DriverRepository repo = new DriverRepository();
            Driver person = new Driver(2, 1, 8, 4);
            Driver personTwo = new Driver(3, 1, 8, 3);

            repo.AddDriverToList(person);
            repo.AddDriverToList(personTwo);

            int actual = repo.GetDriverList().Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateDriverScore()
        {
            DriverRepository repo = new DriverRepository();
            Driver person = new Driver(2, 1, 8, 4);

            int actual = repo.CalculateDriverScore(person);
            int expected = 8;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateFinalPremium()
        {
            DriverRepository repo = new DriverRepository();
            Driver person = new Driver(2, 1, 8, 4);

            int score = repo.CalculateDriverScore(person);
            decimal actual = repo.CalculateFinalPremium(score);
            decimal expected = 95.00m;

            Assert.AreEqual(expected, actual);


        }
    }
}
