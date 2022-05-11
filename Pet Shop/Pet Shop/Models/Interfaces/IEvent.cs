using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    interface IEvent
    {
        Task<Event> Create(Event Event);
        Task<Event> GetEvent(int Id);
        Task<List<Event>> GetEvents();
        Task<Event> UpdateEvent(int Id, Event Event);
        Task DeletEvent(int Id);
    }
}
