using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductImage:ITable
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
