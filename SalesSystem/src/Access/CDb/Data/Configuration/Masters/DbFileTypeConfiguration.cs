namespace CDb.Data.Configuration.Masters
{
    public class DbFileTypeConfiguration : IEntityTypeConfiguration<DbFileType>
    {
        public void Configure(EntityTypeBuilder<DbFileType> builder)
        {
            builder.ToTable("FileTypes");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(f => f.Name)
                .IsUnique();
            builder.Property(f => f.Description)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(f => f.IsActive)
                .IsRequired();

            AddSeedData(builder);
        }

        static void AddSeedData(EntityTypeBuilder<DbFileType> builder)
        {
            DbFileType fileTypeGeneric = new DbFileType("Generic", "Generic", false);
            DbFileType fileTypeDrawing = new DbFileType("Drawing", "Drawing", false);
            DbFileType fileTypeUserManual = new DbFileType("UserManual", "User Manual", false);
            DbFileType fileTypeCatalog = new DbFileType("Catalog", "Catalog", false);
            DbFileType fileTypeComponentSymbol = new DbFileType("ComponentSymbol", "Component symbol", false);
            DbFileType fileTypeComponentDrawing = new DbFileType("ComponentDrawing", "Component drawing", false);
            DbFileType fileTypeComponentImage = new DbFileType("ComponentImage", "Component image", false);

            builder.HasData(
                fileTypeGeneric,
                fileTypeDrawing,
                fileTypeUserManual,
                fileTypeCatalog,
                fileTypeComponentSymbol,
                fileTypeComponentDrawing,
                fileTypeComponentImage
            );
        }
    }
}