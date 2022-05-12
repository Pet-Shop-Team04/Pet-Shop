using Microsoft.EntityFrameworkCore;
using Pet_Shop.Data;
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

        public async Task<Event> Create(Event Event)
        {
            _context.Entry(Event).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return Event;
        }

        public Task DeletEvent(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetEvent(int Id)
        {
            return await _context.Events.Include(e => e.AnimalEvents)
                                        .ThenInclude(c => c.Animals)
                                        .FirstOrDefaultAsync(x => x.EventId == Id);
        }

        public async Task<List<Event>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }

        public async Task<Event> UpdateEvent(int Id, Event Event)
        {
            _context.Entry(Event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Event;

        }
    }
}
