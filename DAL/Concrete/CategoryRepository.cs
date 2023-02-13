

namespace DAL.Concrete;

public class CategoryRepository : EntityRepository<Category, SimRaDb>, ICategoryRepository
{
    public CategoryRepository(SimRaDb context) : base(context)
    {
    }
}
