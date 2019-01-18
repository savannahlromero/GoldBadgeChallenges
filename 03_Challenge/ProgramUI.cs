using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    class ProgramUI
    {
        EventRepository _repo = new EventRepository();

        public void Run()
        {
            Start:
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
                    goto Leave;
            }
            Console.WriteLine("\nWould you like to continue using this application?\n" +
                "1. Yes\n" +
                "2. No\n");
            int cont = int.Parse(Console.ReadLine());

            switch (cont)
            {
                case 1:
                    Console.Clear();
                    goto Start;
                case 2:
                    break;
            }
        Leave:
            Console.Clear();
            Console.WriteLine("Have a lovely day.");
            Console.ReadKey();
        }
        public void AddEvents()
        {
            Console.Clear();
            Event eventName = new Event();
            Console.WriteLine("What type of event will it be?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert\n");
            int typeChoice = int.Parse(Console.ReadLine());
            switch (typeChoice)
            {
                case 1:
                    eventName.EventType = EventType.Golf;
                    break;
                case 2:
                    eventName.EventType = EventType.Bowling;
                    break;
                case 3:
                    eventName.EventType = EventType.AmusementPark;
                    break;
                case 4:
                    eventName.EventType = EventType.Concert;
                    break;
            }
            Console.WriteLine("\nHow many attendees will there be?");
            eventName.EventAttendeeCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat is the cost-per-person for this event?");
            eventName.EventCostPerPerson = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nWhat is the total event cost?");
            eventName.EventTotalCost = decimal.Parse(Console.ReadLine());
            Console.Clear();
            //DATETIME SETUP START
            Console.WriteLine("Now we will begin filling out the date and time for the event.\nWe use an automated system for this, so please follow the instructions closely.\nPress any key to continue.\n");
            Console.ReadKey();
            DateTimeSetup:
            Console.WriteLine("\nWhat year will the event take place?");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIn what month will the event take place?\n(Please use numerical values. \"1\" for \"January\", etc.)");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("\nOn what day will the event take place?\n(Please use numerical values.)");
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("\nAt what hour will the event start? (Please use military/24-hour time)");
            int hour = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIf the event starts at a specific minute, (i.e. at 3:30 PM), please type the minute value now. Otherwise, type \"0\".");
            int minute = int.Parse(Console.ReadLine());

            eventName.EventDate = new DateTime(year, month, day, hour, minute, 0);

            Console.WriteLine("\nYou selected " + eventName.EventDate + " as your date. Is this correct?\n" +
                          "1. Yes\n" +
                          "2. No");
            int correctDate = int.Parse(Console.ReadLine());

            switch (correctDate)
            {
                case 1:
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    goto DateTimeSetup;
            }
            

            _repo.AddEventToList(eventName);

        }
        public void ListEvents()
        {
            Console.Clear();
            List<Event> eventList = _repo.GetEventList();
            foreach (Event eventName in eventList)
            {
                Console.WriteLine($"Type: {eventName.EventType}\nAttendee Count: {eventName.EventAttendeeCount}\nCost-Per-Person: {eventName.EventCostPerPerson}\nEvent total cost: {eventName.EventTotalCost}\nEvent date: {eventName.EventDate}\n");
            }
        }
        public void TotalCostAll()
        {
      
            decimal totalCost = _repo.TotalCostOfAllOutings(true);

            Console.WriteLine($"\nThe current total cost of all events is ${totalCost}.");
        }
        public void TotalCostType()
        {
            EventType calculateType = EventType.Golf;
            Console.WriteLine("What event type would you like to calculate?\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            int chooseType = int.Parse(Console.ReadLine());
            switch (chooseType)
            {
                case 1:
                    calculateType = EventType.Golf;
                    break;
                case 2:
                    calculateType = EventType.Bowling;
                    break;
                case 3:
                    calculateType = EventType.AmusementPark;
                    break;
                case 4:
                    calculateType = EventType.Concert;
                    break;
            }
            decimal costForType = _repo.CostOfOutingsByType(calculateType);
            Console.WriteLine($"The total cost of those events is ${costForType}.");
        }
    }
}
