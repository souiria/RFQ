namespace Master.Data.Configuration
{
    public class DbProgramHierarchyConfiguration : IEntityTypeConfiguration<DbProgramHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbProgramHierarchy> builder)
        {
            builder.ToTable("ProgramHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
