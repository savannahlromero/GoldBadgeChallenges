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
        Start:
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
            Console.Clear();
            Console.WriteLine("Would you like to continue using this application? (y/n)");
            string leaveM = Console.ReadLine();
            string leaveMenu = leaveM.ToLower();
            if (leaveMenu == "y")
            {
                Console.Clear();
                goto Start;
            }
        }
        private void AddABadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            List<string> emptyDoorList = new List<string>();
            newBadge.DoorNames = emptyDoorList;
            Console.WriteLine("What will the ID of this new badge be?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Let's add a door to the badge.");
            Console.ReadKey();
        LoopForDoors:
            Console.Clear();
            Console.WriteLine("What would you like the name of the door to be?");
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
            Console.Clear();
            Dictionary<int, List<string>> dict = _repo.ReturnDictionary();
            Console.WriteLine("What is the badge number to update?");
            int badgeID = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (KeyValuePair<int, List<string>> item in dict)
            {
                if (item.Key == badgeID)
                {
                    Console.WriteLine($"Badge # {item.Key} has access to the following doors:");
                    foreach (string door in item.Value)
                    {
                        Console.WriteLine($"{door}");
                    }
                }
            }
            Console.WriteLine("What would you like to do?\n" +
                "1. Add a door\n" +
                "2. Remove a door\n");
            int updateNav = int.Parse(Console.ReadLine());
            switch (updateNav)
            {
                case 1:
                    goto AddADoor;
                case 2:
                    goto RemoveADoor;
                default:
                    goto End;
            }
        RemoveADoor:
            Console.WriteLine("What door would you like to remove?");
            string doorDeath = Console.ReadLine();
            foreach (KeyValuePair<int, List<string>> item in dict)
            {
                if (item.Key == badgeID)
                {
                    item.Value.Remove(doorDeath);
                }
            }

            goto End;
        AddADoor:
            Console.WriteLine("What would you like the name of the door to be?");
            string doorName = Console.ReadLine();
            foreach (KeyValuePair<int, List<string>> item in dict)
            {
                if (item.Key == badgeID)
                {
                    item.Value.Add(doorName);
                }
            }
            goto End;
        End:
            foreach (KeyValuePair<int, List<string>> item in dict)
            {
                if (item.Key == badgeID)
                {
                    Console.Clear();
                    Console.WriteLine($"Your badge has been updated. Badge # {item.Key} has access to the following doors:");
                    foreach (string door in item.Value)
                    {
                        Console.WriteLine($"{door}");
                    }
                }
            }
            Console.ReadKey();
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> dict = _repo.ReturnDictionary();
            Console.WriteLine("Key Badge #\t\t Door Access");
            foreach (KeyValuePair<int, List<string>> item in dict)
            {
                Console.WriteLine($"{item.Key}");
                foreach (string door in item.Value)
                {
                    Console.WriteLine($"\t\t\t{door}");
                }
                Console.WriteLine("----------------------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
