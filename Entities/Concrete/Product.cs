using Core.Entities.Concrete;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product:ITable
    {
        public Product()
        {
            Reviews=new List<Review>();
            ProductImages=new List<ProductImage>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Favourite> Favourites { get; set; }
        public List<ProductParameter> ProductParameters { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public string ForwardUrl { get; set; }
        public bool isDeleted { get; set; }
        public bool isConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
