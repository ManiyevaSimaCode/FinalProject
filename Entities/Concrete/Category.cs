using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category:ITable
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategory>SubCategories { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
