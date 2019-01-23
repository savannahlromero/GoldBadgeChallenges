using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    class ProgramUI
    {
        BadgeRepository _repo = new BadgeRepository();
        internal void Run()
        {
            Console.WriteLine("Hello Security Admin, what would you like to do?\n" +
                "1. Add a badge\n" +
                "2. Edit a badge\n" +
                "3. List all badges");
            int navigation = int.Parse(Console.ReadLine());

            switch (navigation)
            {
                case 1:
                    AddABadge();
                    break;
                case 2:
                    EditABadge();
                    break;
                case 3:
                    ListAllBadges();
                    break;
            }
            Console.WriteLine("Would you like to continue using this appliacation?");
        }
        private void AddABadge()
        {
            Badge newBadge = new Badge();
            Console.WriteLine("What will the ID of this new badge be?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            LoopForDoors:
            Console.WriteLine("Let's add a door to the badge. What would you like the name of the door to be?");
            string doorName = Console.ReadLine();
            Badge updatedBadge = _repo.AddToListOfDoors(newBadge, doorName);
            newBadge = updatedBadge;
            Console.WriteLine("Would you like to add another door to this badge? (y/n)");
            string response = Console.ReadLine();
            string responseL = response.ToLower();

            if (responseL == "y")
            {
                goto LoopForDoors;
            }
            _repo.AddToDictionary(newBadge);

        }
        private void EditABadge()
        {

        }
        private void ListAllBadges()
        {

        }
    }
}
