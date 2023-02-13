namespace DAL.Utilities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Quantity).HasDefaultValue(1).HasMaxLength(25);
            builder.Property(c => c.Price).IsRequired().HasMaxLength(25);
            builder.Property(c => c.DiscountPrice).HasMaxLength(25);
            builder.Property(c => c.ForwardUrl).HasMaxLength(255);
            builder.Property(c => c.isConfirmed).HasDefaultValue(false);
            builder.Property(c => c.isDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");

            builder.HasMany(p => p.Reviews).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(p => p.Favourites).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(p => p.ProductParameters).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(p => p.ProductImages).WithOne(p => p.Product).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Company).WithMany(p => p.Products).HasForeignKey(p => p.CompanyId);
            builder.HasOne(p => p.User).WithMany(p => p.Products).HasForeignKey(p => p.UserId);

        }
    }
}
