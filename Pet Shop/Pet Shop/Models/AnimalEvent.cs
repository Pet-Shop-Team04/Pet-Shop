namespace Pet_Shop.Models
{
    public class AnimalEvent
    {
        public int EventId { get; set; }
        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
        public Event Event { get; set; }
    }
}
