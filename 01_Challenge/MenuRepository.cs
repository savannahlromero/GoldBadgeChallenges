using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddMealToList(Menu meal)
        {
            _menuList.Add(meal);
        }
        public List<Menu> GetMealFromList()
        {
            return _menuList;
        }
        public bool RemoveMealFromList(int removeMealNumber)
        {
            foreach (Menu meal in _menuList)
            {
                if (meal.MealNumber == removeMealNumber)
                {
                    _menuList.Remove(meal);
                    return true;
                }
            }
            return false;
        }
    }
}
