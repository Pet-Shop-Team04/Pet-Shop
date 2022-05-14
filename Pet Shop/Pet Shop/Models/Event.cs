using System;
using System.Collections.Generic;

namespace Pet_Shop.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public List<AnimalEvent> AnimalEvents { get; set; }

    }
}
