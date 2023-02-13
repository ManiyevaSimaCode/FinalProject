using Entities.Abstract;

namespace Entities.Concrete
{
    public class SubCategoryParameter:ITable
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int ParameterId { get; set; }
        public Parameter Parameter { get; set; }
    }
}
