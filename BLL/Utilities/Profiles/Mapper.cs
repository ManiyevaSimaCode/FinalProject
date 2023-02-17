using Entities.DTOs.Company;
using Entities.DTOs.Parameter;
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

            //Parameter
            CreateMap<Parameter, ParameterGetDto>().ReverseMap();
            CreateMap<ParameterPostDto, Parameter>().ReverseMap();

            //Company
            CreateMap<Company, CompanyGetDto>().ReverseMap();
            CreateMap<CompanyPostDto, Company>().ReverseMap();

        }
    }
}
