namespace Pet_Shop.Models
{
    public class CommentAnimal
    {

        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public Comment Comment { get; set; }
        public Animal Animal { get; set; }
    }
}
