using Entities.Concrete;
using Entities.DTOs.AppUser;
using Entities.DTOs.Product;

namespace Entities.DTOs.Review
{
    public class ReviewGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto ProductGetDto { get; set; }
        public AppUserGetDto User { get; set; }
        public Rating rating { get; set; }
        public string Comment { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class ReviewPostDto
    {

        public int ProductId { get; set; }
        public ProductGetDto ProductGetDto { get; set; }
        public AppUserGetDto User { get; set; }
        public Rating rating { get; set; }
        public string Comment { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public DateTime CreatedDate { get; set; }

    }

}
