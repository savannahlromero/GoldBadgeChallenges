using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert}
    public class Event
    {
        public EventType EventType { get; set; }
        public int EventAttendeeCount { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventCostPerPerson { get; set; }
        public decimal EventTotalCost { get; set; }

        public Event(EventType eventType, int eventAttendeeCount, DateTime eventDate, decimal eventCostPerPerson, decimal eventTotalCost)
        {
            EventType = eventType;
            EventAttendeeCount = eventAttendeeCount;
            EventDate = eventDate;
            EventCostPerPerson = eventCostPerPerson;
            EventTotalCost = eventTotalCost;
        }
        public Event()
        {

        }
    }
}
