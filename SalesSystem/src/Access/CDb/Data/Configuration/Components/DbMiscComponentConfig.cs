namespace CDb.Data.Configuration.Components
{
    public class DbMiscComponentConfig : IEntityTypeConfiguration<DbMiscComponent>
    {
        public void Configure(EntityTypeBuilder<DbMiscComponent> builder)
        {
            builder.ToTable("MiscComponents");
            builder.Property(c => c.ComponentTypeId)
                .IsRequired();
            builder.Property(c => c.Dimension)
                .HasMaxLength(32);
            builder.Property(c => c.AdditionaInfo)
                .HasMaxLength(256);
            builder.Property(c => c.Color)
                .IsRequired()
                .HasDefaultValue(ColorType.X);
        }
    }
}
