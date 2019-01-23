using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge
{
    public class EventRepository
    {
        List<Event> _eventList = new List<Event>();

        public void AddEventToList(Event eventName)
        {
            _eventList.Add(eventName);
        }
        public List<Event> GetEventList()
        {
            return _eventList;
        }
        public decimal TotalCostOfAllOutings(bool totalCost)
        {
            decimal totalCostAllOutings = 0;

            foreach(Event eventName in _eventList)
            {
                decimal cost = eventName.EventTotalCost;
                totalCostAllOutings += cost;
            }
            return totalCostAllOutings;
            
        }
        public decimal CostOfOutingsByType(EventType eventType)
        {
            decimal totalCostPerType = 0;

            foreach(Event eventName in _eventList)
            {
                if (eventName.EventType == eventType)
                {
                    decimal cost = eventName.EventTotalCost;
                    totalCostPerType += cost;
                }
            }
            return totalCostPerType;

        }
    }
}
