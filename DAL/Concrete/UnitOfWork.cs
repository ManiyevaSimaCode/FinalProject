
namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimRaDb _dbContext;
        ICategoryRepository _categoryRepository;
        ISubCategoryRepository _subCategoryRepository;

        public UnitOfWork(SimRaDb dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository =>   _categoryRepository?? new CategoryRepository(_dbContext) ;
        public ISubCategoryRepository SubCategoryRepository =>   _subCategoryRepository?? new SubCategoryRepository(_dbContext);

        public async Task SaveAsync()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}
