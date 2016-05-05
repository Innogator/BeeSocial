using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace BeeSocial.Models
{
    public class EventRepository : IEventRepository
    {
        static ConcurrentDictionary<string, Event> _events = new ConcurrentDictionary<string, Event>();

        public EventRepository()
        {
            Add(new Event()
                {
                    Title = "Concert",
                    Description = "Musical concert at the park",
                    Price = 0.00M,
                    Date = new DateTime(2016, 05, 20)
                }
            );

            Add(new Event()
                {
                    Title = "Art Exhibit",
                    Description = "At local museum",
                    Price = 20.00M,
                    Date = new DateTime(2016, 05, 21)
                }
            );

            Add(new Event()
                {
                    Title = "Yoga Class",
                    Description = "Social yoga class",
                    Price = 10.00M,
                    Date = new DateTime(2016, 05, 22)
                }
            );
        }

        public IEnumerable<Event> GetAll()
        {
            return _events.Values;
        }

        public void Add(Event e)
        {
            e.EventID = Guid.NewGuid().ToString();
            _events[e.EventID] = e;
        }

        public Event Find(string id)
        {
            Event e;
            _events.TryGetValue(id, out e);
            return e;
        }

        public Event Remove(string id)
        {
            Event e;
            _events.TryGetValue(id, out e);
            _events.TryRemove(id, out e);
            return e;
        }
        
        public void Update(Event e)
        {
            _events[e.EventID] = e;
        }
    }
}
