using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class ProgramUI
    {
        public void Run()
        {
            Console.WriteLine("Welcome! What would you like to do today?\n" +
                "1. Add event to list\n" +
                "2. Display list of events\n" +
                "3. View total cost of all events\n" +
                "4. View total cost of events by type\n" +
                "5. Exit");
            int navigation = int.Parse(Console.ReadLine());

            switch (navigation)
            {
                case 1:
                    AddEvents();
                    break;
                case 2:
                    ListEvents();
                    break;
                case 3:
                    TotalCostAll();
                    break;
                case 4:
                    TotalCostType();
                    break;
                case 5:
                    break;
            }
        }
        public void AddEvents()
        {

        }
        public void ListEvents()
        {

        }
        public void TotalCostAll()
        {

        }
        public void TotalCostType()
        {

        }
    }
}
