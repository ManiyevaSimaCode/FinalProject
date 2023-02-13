using Entities.Abstract;

namespace Entities.Concrete
{
    public class Parameter:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ProductParameter> ProductParameters { get; set; }
        public List<SubCategoryParameter> SubCategoryParameters { get; set; }
    }
}
