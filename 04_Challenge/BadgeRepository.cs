using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class BadgeRepository
    {

        Dictionary<int, List<string>> _dict = new Dictionary<int, List<string>>();

        public void AddToDictionary(Badge badge)
        {
            _dict.Add(badge.BadgeID, badge.DoorNames);
        }

        public Dictionary<int, List<string>> ReturnDictionary()
        {
            return _dict;
        }

       public Badge AddToListOfDoors(Badge badge, string stringName)
        {
            List<string> addList = badge.DoorNames;

            addList.Add(stringName);

            badge.DoorNames = addList;

            return badge;
        }
       public List<string> GetListOfDoors(Badge badge)
        {
            List<string> newList = badge.DoorNames;

            return newList;

        }
        
    }
}
