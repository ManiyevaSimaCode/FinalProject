namespace BLL.Abstract
{
    public interface ILayoutService
    {
        Task<List<CategoryGetDto>>GetCategorySubCategories();
    }
}
