using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeSocial.Models
{
    public class Event
    {
        public string EventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
