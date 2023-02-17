
namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimRaDb _dbContext;
        ICategoryRepository _categoryRepository;
        ISubCategoryRepository _subCategoryRepository;
        IParameterRepository _parameterRepository;
        ICompanyRepository _companyRepository;

        public UnitOfWork(SimRaDb dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository =>   _categoryRepository?? new CategoryRepository(_dbContext) ;
        public ISubCategoryRepository SubCategoryRepository =>   _subCategoryRepository?? new SubCategoryRepository(_dbContext);
        public IParameterRepository ParameterRepository =>   _parameterRepository?? new ParameterRepository(_dbContext);
        public ICompanyRepository CompanyRepository =>   _companyRepository ?? new CompanyRepository(_dbContext);

        //public async Task SaveAsync()
        //{
        //     await _dbContext.SaveChangesAsync();
        //}
    }
}
