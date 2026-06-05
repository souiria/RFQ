namespace Master.Data.Configuration
{
    public class DbProjectEngineeringAssocitationConfiguration : IEntityTypeConfiguration<DbProjectEngineeringAssociation>
    {
        public void Configure(EntityTypeBuilder<DbProjectEngineeringAssociation> builder)
        {
            builder.ToTable("ProjectEngineeringAssociation");
            builder.HasKey(x => x.Id);
        }
    }
}
