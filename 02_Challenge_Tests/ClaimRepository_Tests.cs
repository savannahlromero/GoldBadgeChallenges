using System;
using _02_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Challenge_Tests
{
    [TestClass]
    public class ClaimRepository_Tests
    {
        [TestMethod]
        public void AddToAndGetQueue()
        {
            ClaimRepository repo = new ClaimRepository();
            DateTime incident = new DateTime(2019, 1, 1);
            DateTime claimTime = new DateTime(2019, 1, 20);
            Claim claimOne = new Claim(1, ClaimType.Car, "Yk a car did the break and things", 400.00m, incident, claimTime, true);
            Claim claimTwo = new Claim(1, ClaimType.Car, "Yk a car did the break and things", 400.00m, incident, claimTime, true);
            repo.AddClaimToQueue(claimOne);
            repo.AddClaimToQueue(claimTwo);

            int actual = repo.GetQueue().Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveAClaim()
        {
            ClaimRepository repo = new ClaimRepository();
            DateTime incident = new DateTime(2019, 1, 1);
            DateTime claimTime = new DateTime(2019, 1, 20);
            Claim claimOne = new Claim(1, ClaimType.Car, "Yk a car did the break and things", 400.00m, incident, claimTime, true);
            Claim claimTwo = new Claim(1, ClaimType.Car, "Yk a car did the break and things", 400.00m, incident, claimTime, true);
            repo.AddClaimToQueue(claimOne);
            repo.AddClaimToQueue(claimTwo);
            repo.RemoveClaimFromQueue();

            int actual = repo.GetQueue().Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ValidClaim()
        {
            ClaimRepository repo = new ClaimRepository();
            Claim claimOne = new Claim();
            DateTime incident = new DateTime(2019, 1, 1);
            DateTime claimTime = new DateTime(2019, 1, 20);

            claimOne.DateOfIncident = incident;
            claimOne.DateOfClaim = claimTime;
            bool validity = repo.IsThisClaimValid(claimOne);
            claimOne.IsValid = validity;

            bool actual = claimOne.IsValid;
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
