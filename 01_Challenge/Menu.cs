using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string IngredientsList { get; set; } //Potentially switch this to a list
        public decimal MealPrice { get; set; }

        //CONSTRUCTORS
        public Menu(int mealNumber, string mealName, string mealDescription, string ingredientsList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            IngredientsList = ingredientsList;
            MealPrice = mealPrice;
        }
        public Menu()
        {

        }
    }
}
