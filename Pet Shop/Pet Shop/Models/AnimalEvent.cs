namespace Pet_Shop.Models
{
    public class AnimalEvent
    {
        public int EventId { get; set; }
        public int AnimalId { get; set; }

        //Navigation Properties

        public Animal Animals { get; set; }
        public Event Events { get; set; }
    }
}
