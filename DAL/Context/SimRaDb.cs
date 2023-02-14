using System.Reflection;

namespace DAL.Context
{
    public class SimRaDb : IdentityDbContext<AppUser>
    {
        public SimRaDb(DbContextOptions<SimRaDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(builder);
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<SubCategory>SubCategories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Review>Reviews{ get; set; }
        public DbSet<Favourite>Favourites { get; set; }
        public DbSet<Parameter>Parameters { get; set; }
        public DbSet<Company>Companies { get; set; }
        public DbSet<ProductParameter> ProductParameters { get; set; }
        public DbSet<SubCategoryParameter> SubCategoryParameters { get; set; }




    }

}
