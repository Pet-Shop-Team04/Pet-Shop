using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pet_Shop.Models;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.Interfaces;

namespace Pet_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEvent _event;

        public EventController(IEvent event1)
        {
            _event = event1;
        }

        // POST: api/Event

        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(EventDTO eventDTO)
        {
            Event event1 = await _event.Create(eventDTO);
            return Ok(event1);
        }

        // GET: api/Event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            var event1 = await _event.GetEvents();
            return Ok(event1);
        }

        // GET: api/Event/1
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            EventDTO eventDTO = await _event.GetEvent(id);
            return Ok(eventDTO);
        }

        // PUT: api/Event/2

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventDTO eventDTO)
        {
            if (id != eventDTO.EventId)
            {
                return BadRequest();
            }

            Event event1 = await _event.UpdateEvent(id, eventDTO);
            return Ok(event1);
        }



        // DELETE: api/Event/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var event1 = await _event.GetEvent(id);
            if (event1 == null)
            {
                return NotFound();
            }


            await _event.DeletEvent(id);
            return NoContent();

        }


    }
}
