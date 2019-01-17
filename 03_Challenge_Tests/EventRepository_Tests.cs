using System;
using System.Linq;
using _03_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Challenge_Tests
{
    [TestClass]
    public class EventRepository_Tests
    {
        [TestMethod]
        public void AddAndGetEventList()
        {
            EventRepository repo = new EventRepository();
            Event eventOne = new Event();
            Event eventTwo = new Event();

            repo.AddEventToList(eventOne);
            repo.AddEventToList(eventTwo);

            int actual = repo.GetEventList().Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TotalCostOfAllOutings()
        {
            EventRepository repo = new EventRepository();
            Event eventOne = new Event(EventType.AmusementPark, 300, DateTime.Now, 52.00m, 1500.00m);
            Event eventTwo = new Event(EventType.AmusementPark, 432, DateTime.Now, 52.00m, 2000.00m);
            Event eventThree = new Event(EventType.Bowling, 432, DateTime.Now, 52.00m, 2500.00m);

            repo.AddEventToList(eventOne);
            repo.AddEventToList(eventTwo);
            repo.AddEventToList(eventThree);
            bool calculateTotalCost = true;      

            decimal actual = repo.TotalCostOfAllOutings(calculateTotalCost);
            decimal expected = 6000.00m;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TotalCostOfOutingsByType()
        {
            EventRepository repo = new EventRepository();
            Event eventOne = new Event(EventType.AmusementPark, 300, DateTime.Now, 52.00m, 1500.00m);
            Event eventTwo = new Event(EventType.AmusementPark, 432, DateTime.Now, 52.00m, 2000.00m);

            repo.AddEventToList(eventOne);
            repo.AddEventToList(eventTwo);
            

            decimal actual = repo.CostOfOutingsByType(EventType.AmusementPark);
            decimal expected = 3500.00m;

            Assert.AreEqual(expected, actual);
        }
    }
}
