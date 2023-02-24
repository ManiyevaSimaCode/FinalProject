namespace DAL.Utilities.Configurations
{
    public class ParameterConfiguration : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.isDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasMany(p => p.ProductParameters).WithOne(p => p.Parameter).HasForeignKey(p => p.ProductId);
        }
    }
}
