using Entities.DTOs.AppUser;
using Entities.DTOs.Product;

namespace Entities.DTOs.Favourite
{
    public class FavouriteGetDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductGetDto ProductGetDto { get; set; }
        public string UserId { get; set; }
        public AppUserGetDto User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
