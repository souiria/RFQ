namespace Master.Data.Configuration
{
    public class DbMilestoneHierarchyConfiguration : IEntityTypeConfiguration<DbMilestoneHierarchy>
    {
        public void Configure(EntityTypeBuilder<DbMilestoneHierarchy> builder)
        {
            builder.ToTable("MilestoneHierarchy");
            builder.HasKey(x => x.Id);
        }
    }
}
