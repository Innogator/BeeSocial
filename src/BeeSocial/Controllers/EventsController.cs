using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using BeeSocial.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BeeSocial.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        [FromServices]
        public IEventRepository Events { get; set; }
                
        // GET: /events
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return Events.GetAll();
        }

        // GET: /events/1
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var e = Events.Find(id);
            if (e == null)
            {
                return HttpNotFound();
            }

            return new ObjectResult(e);
        }

        // POST: /events
        [HttpPost]
        public IActionResult Post([FromBody] Event e)
        {
            if (e == null)
            {
                return HttpBadRequest();
            }

            Events.Add(e);
            return CreatedAtRoute("Details", new { controller = "Events", id = e.EventID }, e);
        }

        // PUT /events/1
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Event e)
        {
            if (e == null || e.EventID != id)
            {
                return HttpBadRequest();
            }

            var ev = Events.Find(id);
            if (ev == null)
            {
                return HttpNotFound();
            }

            Events.Update(e);
            return new NoContentResult();
        }

        // DELETE: /events/1
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Events.Remove(id);
        }
    }
}
