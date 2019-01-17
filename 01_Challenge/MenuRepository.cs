using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuRepository
    {
        List<Menu> menuList = new List<Menu>();

        public void AddMealToList(Menu meal)
        {
            menuList.Add(meal);
        }
        public List<Menu> GetMealFromList()
        {
            return menuList;
        }
        public bool RemoveMealFromList(int removeMealNumber)
        {
            foreach (Menu meal in menuList)
            {
                if (meal.MealNumber == removeMealNumber)
                {
                    menuList.Remove(meal);
                    return true;
                }
            }
            return false;
        }
    }
}
