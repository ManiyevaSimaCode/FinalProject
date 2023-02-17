namespace DAL.Concrete
{
    public class CompanyRepository : EntityRepository<Company, SimRaDb>, ICompanyRepository
    {
        public CompanyRepository(SimRaDb context) : base(context)
        {
        }
    }
}
