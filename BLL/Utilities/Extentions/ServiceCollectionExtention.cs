namespace BLL.Utilities.Extentions;

public static class ServiceCollectionExtention
{

    public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services,IConfiguration configuration )
    {
        services.AddControllers().AddFluentValidation(opt =>
        {
            opt.ImplicitlyValidateChildProperties = true;
            opt.ImplicitlyValidateRootCollectionElements = true;
            opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });
        services.AddDbContext<SimRaDb>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<SimRaDb>().AddDefaultTokenProviders();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ILayoutService, LayoutManager>();
        services.AddScoped<ICategoryService, CategoryManager>();      
        services.AddScoped<ISubCategoryService, SubCategoryManager>();
        services.AddScoped<ICompanyService, CompanyManager>();
        services.AddScoped<IParameterService, ParameterManager>();

        return services;
    }
}
