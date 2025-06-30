
namespace Emacs.Data.Configuration
{
    public class DbEmacsRFIViewConfiguration : IEntityTypeConfiguration<DbEmacsRFIView>
    {
        public void Configure(EntityTypeBuilder<DbEmacsRFIView> builder)
        {
            builder.Property(x => x.CategoryCode2).HasColumnName("Category Code");
            builder.Property(x => x.DetailedCategoryCode).HasColumnName("Detailed Category Code");
            builder.Property(x => x.CategoryName).HasColumnName("Category Name");
            builder.Property(x => x.PartGroupCode).HasColumnName("Part Group Code");
            builder.Property(x => x.InsideDiameter).HasPrecision(6, 2);
            builder.Property(x => x.WallThickness).HasPrecision(6, 2);
            builder.Property(x => x.Length).HasPrecision(6, 2);
            builder.Property(x => x.WidthOrOutsideDiameter).HasPrecision(6, 2);
            builder.Property(x => x.MassOrWeight).HasPrecision(7, 2);
            builder.Property(x => x.Quantity).HasPrecision(6, 2);
            builder.Property(x => x.MassOrWeight2).HasPrecision(6, 2);
            builder.Property(x => x.PitchWidth).HasPrecision(5, 2);
            builder.ToTable("EmacsRFIView");
            builder.HasNoKey();
        }
    }
}
