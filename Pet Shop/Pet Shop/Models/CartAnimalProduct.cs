namespace Pet_Shop.Models
{
    public class CartAnimalProduct
    {
        public int AnimalProdactId { get; set; }
        public int CartId { get; set; }

        //Navigation Properties

        public Cart Carts { get; set; }
        public AnimalProduct AnimalProdacts { get; set; }

    }
}
