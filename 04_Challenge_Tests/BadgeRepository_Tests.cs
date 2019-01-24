using System;
using System.Collections.Generic;
using _04_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Challenge_Tests
{
    [TestClass]
    public class BadgeRepository_Tests
    {
        [TestMethod]
        public void AddToAndGetDictionary()
        {
            List<string> list = new List<string>();
            BadgeRepository repo = new BadgeRepository();
            Badge badgeOne = new Badge(12345, list);
            Badge badgeTwo = new Badge(12346, list);



            repo.AddToDictionary(badgeOne);
            repo.AddToDictionary(badgeTwo);

            Dictionary<int, List<string>> dict = repo.ReturnDictionary();

            int actual = dict.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void AddToListOfDoors()
        {
            List<string> list = new List<string>();
            BadgeRepository repo = new BadgeRepository();
            Badge badgeOne = new Badge(12345, list);
            string stringOne = "A32";

            Badge badgeRefined = repo.AddToListOfDoors(badgeOne, stringOne);

            repo.AddToDictionary(badgeRefined);

            Assert.IsTrue(badgeRefined.DoorNames.Contains(stringOne));
        }
        [TestMethod]
        public void GetListOfDoors()
        {
            List<string> list = new List<string>();
            BadgeRepository repo = new BadgeRepository();
            Badge badgeOne = new Badge(12345, list);
            string stringOne = "A32";

            Badge badgeRefined = repo.AddToListOfDoors(badgeOne, stringOne);

            int actual = repo.GetListOfDoors(badgeRefined).Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
