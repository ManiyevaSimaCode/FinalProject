using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class SubCategory:ITable
    {
        public SubCategory()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Product>Products { get; set; }

        public List<SubCategoryParameter> SubCategoryParameters { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public List<int> ParameterIds { get; set; }

    }
}
