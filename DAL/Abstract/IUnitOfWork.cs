namespace DAL.Abstract
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get;  }
        public ISubCategoryRepository SubCategoryRepository { get; }
        Task SaveAsync();
    }
}
