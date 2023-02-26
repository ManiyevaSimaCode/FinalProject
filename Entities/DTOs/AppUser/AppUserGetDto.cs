using Entities.DTOs.Favourite;
using Entities.DTOs.Product;
using Entities.DTOs.Review;

namespace Entities.DTOs.AppUser
{
    public class AppUserGetDto
    {
        public List<FavouriteGetDto> Favourites { get; set; }
        public List<ReviewGetDto> Reviews { get; set; }
        public List<ProductGetDto> Products { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool isCompany { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
    }
}
