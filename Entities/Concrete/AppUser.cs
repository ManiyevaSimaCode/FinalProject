using Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class AppUser:IdentityUser
    {
        public List<Favourite> Favourites { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Product> Products { get; set; }
        public bool isCompany { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string InstagramUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
    }
}
