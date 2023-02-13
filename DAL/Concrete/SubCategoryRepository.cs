

namespace DAL.Concrete;

public class SubCategoryRepository : EntityRepository<SubCategory, SimRaDb>, ISubCategoryRepository
{
    public SubCategoryRepository(SimRaDb context) : base(context)
    {
    }
}
