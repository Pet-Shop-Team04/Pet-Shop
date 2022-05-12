using Pet_Shop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.Interfaces
{
    public interface IEvent
    {
        Task<Event> Create(EventDTO EventDto);
        Task<EventDTO> GetEvent(int Id);
        Task<List<EventDTO>> GetEvents();
        Task<Event> UpdateEvent(int Id, EventDTO Event);
        Task DeletEvent(int Id);
    }
}
