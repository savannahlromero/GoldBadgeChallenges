using System;
using System.Collections.Generic;
using System.Linq;
using _01_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Challenge_Tests
{
    [TestClass]
    public class MenuRepository_Tests
    {
        [TestMethod]
        public void AddAndGetMealToAndFromList()
        {


            Menu meal = new Menu();
            Menu mealTwo = new Menu();
            MenuRepository repo = new MenuRepository();

            repo.AddMealToList(meal);
            repo.AddMealToList(mealTwo);

            int actual = repo.GetMealFromList().Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void RemoveMealFromList()
        {
            Menu meal = new Menu();
            Menu mealTwo = new Menu(1, "Hot Dog", "Hot and made of dogs", "Meat (not dog", 3.99m);
            MenuRepository repo = new MenuRepository();

            repo.AddMealToList(meal);
            repo.AddMealToList(mealTwo);
            repo.RemoveMealFromList(meal.MealNumber);

            int actual = repo.GetMealFromList().Count();
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }
    }
}
