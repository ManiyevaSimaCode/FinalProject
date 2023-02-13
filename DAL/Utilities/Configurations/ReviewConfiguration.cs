namespace DAL.Utilities.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(c => c.Comment).HasMaxLength(5000);
            builder.Property(c => c.Pros).HasMaxLength(5000);
            builder.Property(c => c.Cons).HasMaxLength(5000);
            builder.Property(c => c.rating).IsRequired();
            builder.Property(c => c.isDeleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");


            builder.HasOne(p => p.Product).WithMany(p => p.Reviews).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.User).WithMany(p => p.Reviews).HasForeignKey(p => p.UserId);

        }
    }
}
