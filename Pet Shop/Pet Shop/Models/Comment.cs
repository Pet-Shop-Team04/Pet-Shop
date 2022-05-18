using System.Collections.Generic;

namespace Pet_Shop.Models
{
    public class Comment
    {


        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CComment { get; set; }
        public List<CommentAnimal> CommentAnimals { get; set; }

        public ApplicationUser AppUser { get; set; }
    }
}
