namespace CDb.Data.Configuration.Components
{
    public class DbMiscellaneousComponentConfig : IEntityTypeConfiguration<DbMiscellaneousComponent>
    {
        public void Configure(EntityTypeBuilder<DbMiscellaneousComponent> builder)
        {
            builder.ToTable("MiscellaneousComponents");
            builder.Property(c => c.MiscellaneousComponentTypeId)
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
