namespace DAL.Utilities.Configurations
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.isDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasOne(s => s.Category).WithMany(s => s.SubCategories).HasForeignKey(s => s.CategoryId);
        }
    }
}
