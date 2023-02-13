using Entities.DTOs.SubCategory;

namespace BLL.Utilities.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            //Category
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<CategoryPostDto, Category>().ReverseMap();

            //Subcategory
            CreateMap<SubCategory, SubCategoryGetDto>().ReverseMap();
            CreateMap<SubCategoryPostDto, SubCategory>().ReverseMap();
        }
    }
}
