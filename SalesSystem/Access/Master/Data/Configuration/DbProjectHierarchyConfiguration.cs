namespace Master.Data.Configuration
{
    public class DbProjectHierarchyConfiguration : IEntityTypeConfiguration<DbProjectHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbProjectHierarchy> builder)
        {
            builder.ToTable("ProjectHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
