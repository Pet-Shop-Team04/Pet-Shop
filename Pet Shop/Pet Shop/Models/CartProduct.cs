namespace Pet_Shop.Models
{
    public class CartProduct
    {
        public int ProdactId { get; set; }
        public int CartId { get; set; }
        public int Amount { get; set; }

        public Cart Cart { get; set; }
        public Product Prodact { get; set; }
    }
}
