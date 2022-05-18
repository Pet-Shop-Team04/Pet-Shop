using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet_Shop.Models.DTO
{
    public class AnimalDto
    {
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfBerth { get; set; }
        public string Age { get; set; }
        public string AnimalType { get; set; }
        public List<CommentAnimal> CommentAnimals { get; set; }
        public List<EventDTO> AnimalEvents { get; set; }
    }
}
