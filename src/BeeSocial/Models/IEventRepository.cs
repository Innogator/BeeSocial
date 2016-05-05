using System.Collections.Generic;

namespace BeeSocial.Models
{
    public interface IEventRepository
    {
        void Add(Event e);
        IEnumerable<Event> GetAll();
        Event Find(string id);
        Event Remove(string id);
        void Update(Event e);
    }
}
