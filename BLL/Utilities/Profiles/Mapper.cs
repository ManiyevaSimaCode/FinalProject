using Entities.Concrete;
using Entities.DTOs.Account;
using Entities.DTOs.Company;
using Entities.DTOs.Paginate;
using Entities.DTOs.Parameter;
using Entities.DTOs.Product;
using Entities.DTOs.ProductParameter;
using Entities.DTOs.SubCategory;
using Entities.DTOs.SubCategoryParameter;

namespace BLL.Utilities.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //Category
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<CategoryPostDto, Category>().ReverseMap();

            //SubCategory
            CreateMap<SubCategory, SubCategoryGetDto>().ReverseMap();
            CreateMap<SubCategoryPostDto, SubCategory>().ReverseMap();
            CreateMap<SubCategoryParameter, SubCategoryParameterGetDto>().ReverseMap();
            CreateMap<SubCategoryParameter, SubCategoryParameterGetDto>().ReverseMap();
            CreateMap<SubCategoryPostDto, SubCategory>().ReverseMap();


            //Parameter
            CreateMap<Parameter, SubCategoryParameter>()
                .ForMember(s => s.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(s => s.Parameter, opt => opt.MapFrom(src => src));
            CreateMap<Parameter, ParameterGetDto>().ReverseMap();
            CreateMap<ParameterPostDto, Parameter>().ReverseMap();

            //Company
            CreateMap<Company, CompanyGetDto>().ReverseMap();
            CreateMap<CompanyPostDto, Company>().ReverseMap();


            //Auth
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<RegisterDto, AppUser>()
                 .ForMember(dest => dest.Description, opt => opt.Ignore());


            //Product

            CreateMap<Product, ProductGetDto>().ReverseMap();
            CreateMap<ProductPostDto, Product>().ReverseMap();
            CreateMap<ProductParameter, ProductParameterGetDto>().ReverseMap();
            CreateMap<ProductParameterGetDto, ProductParameter>().ReverseMap();

            //Paginate


            CreateMap<Category, PaginateDto<Category>>().ReverseMap();

        }
    }
}
