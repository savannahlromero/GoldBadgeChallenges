using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    class ProgramUI
    {
        MenuRepository _repo = new MenuRepository();

        internal void Run()
        {
            Start:
            Console.WriteLine("Hello, what would you like to do?\n" +
                "1. Add a new menu item\n" +
                "2. View existing menu items\n" +
                "3. Remove a menu item\n" +
                "4.Exit");
            int navigation = int.Parse(Console.ReadLine());

            switch (navigation)
            {
                case 1:
                    AddMenuItem();
                    break;
                case 2:
                    GetMenu();
                    break;
                case 3:
                    RemoveMenuItem();
                    break;
                case 4:
                    break;
            }

            Console.WriteLine("\nWould you like to continue using this application?\n" +
                "1. Yes\n" +
                "2. No");
            int cont = int.Parse(Console.ReadLine());

            switch (cont)
            {
                case 1:
                    Console.Clear();
                    goto Start;
                case 2:
                    break;
            }

        }
        private void AddMenuItem()
        {
            Menu newItem = new Menu();
            Console.Clear();
            Console.WriteLine("What do you want the new item's meal number to be?");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("What will the name of the item be?");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("How will you describe this new item?");
            newItem.MealDescription = Console.ReadLine();
            Console.WriteLine("What are the item's ingredients?");
            newItem.IngredientsList = Console.ReadLine();
            Console.WriteLine("Finally, how much will this item cost?");
            newItem.MealPrice = decimal.Parse(Console.ReadLine());

            _repo.AddMealToList(newItem);

        }
        private void GetMenu()
        {
            Console.Clear();
            List<Menu> mealList = _repo.GetMealFromList();
            foreach (Menu meal in mealList)
            {
                Console.WriteLine($"{meal.MealNumber}.\nName: {meal.MealName}\nDescription: {meal.MealDescription}\nIngredients: {meal.IngredientsList}\nPrice: {meal.MealPrice}\n");
            }
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            GetMenu();
            Console.WriteLine("What item would you like to remove? (Please select the item's number)");
            int mealNumber = int.Parse(Console.ReadLine());

            bool success = _repo.RemoveMealFromList(mealNumber);
            if (success == true)
            {
                Console.WriteLine($"Number {mealNumber} was successfully removed.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Number {mealNumber} was not successfully removed. Please try again.");
            }
            
        }
    }
}
