using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
using Pet_Shop.Models.DTO;
using Pet_Shop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Services
{
    public class EventServices : IEvent
    {
        private readonly PetDbContext _context;

        public EventServices(PetDbContext context)
        {
            _context = context;
        }

        public async Task<Event> Create(EventDTO eventDto)
        {
            Event event1 = new Event {
                Title = eventDto.Title,
                Date = eventDto.Date,
                Description = eventDto.Description,
                Status = eventDto.Status
            };

            _context.Entry(event1).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return event1;
        }

        public async Task DeletEvent(int Id)
        {
            Event event1 = await _context.Events.FindAsync(Id);
            if (event1 != null)
            {
                _context.Entry(event1).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<EventDTO> GetEvent(int Id)
        {
            return await _context.Events.Select(
                event1 => new EventDTO
                {
                    EventId = event1.EventId,
                    Title = event1.Title,
                   Date = event1.Date,
                   Description = event1.Description,
                    Status = event1.Status
                }).FirstOrDefaultAsync(x => x.EventId == Id);
        }

        public async Task<List<EventDTO>> GetEvents()
        {
            return await _context.Events.Select(

            event1 => new EventDTO
            {
                EventId = event1.EventId,
                Title = event1.Title,
                Date = event1.Date,
                Description = event1.Description,
                Status = event1.Status
            }).ToListAsync();
        }

        public async Task<Event> UpdateEvent(int Id, EventDTO eventDto)
        {
            Event event1 = new Event
            {
                Title = eventDto.Title,
                Date = eventDto.Date,
                Description = eventDto.Description,
                Status = eventDto.Status
            };

            _context.Entry(event1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return event1;
        }
    }
}
