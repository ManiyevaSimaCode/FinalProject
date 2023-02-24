namespace DAL.Concrete
{
    public class ProductRepository : EntityRepository<Product, SimRaDb>, IProductRepository
    {
        public ProductRepository(SimRaDb context) : base(context)
        {
        }
    }
}
