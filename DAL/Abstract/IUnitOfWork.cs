namespace DAL.Abstract
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get;  }
        public ISubCategoryRepository SubCategoryRepository { get; }
        public IParameterRepository ParameterRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public IProductRepository ProductRepository { get; }

        //Task SaveAsync();
    }
}
