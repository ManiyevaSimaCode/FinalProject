namespace DAL.Utilities.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.isDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.HasMany(c => c.SubCategories).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId);
        }
    }
}
