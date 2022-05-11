namespace Pet_Shop.Models
{
    public class AnimalCart
    {
        public int CartId { get; set; }
        public int AnimalId { get; set; }
        public Animal Animals { get; set; }
        public Cart Carts { get; set; }
    }
}
