namespace Master.Data.Configuration
{
    public class DbPlatformHierarchyConfiguration : IEntityTypeConfiguration<DbPlatformHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbPlatformHierarchy> builder)
        {
            builder.ToTable("PlatformHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
