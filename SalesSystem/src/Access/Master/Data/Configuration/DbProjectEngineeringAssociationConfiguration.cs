namespace Master.Data.Configuration
{
    public class DbProjectEngineeringAssociationConfiguration
        : IEntityTypeConfiguration<DbProjectEngineeringAssociation>
    {
        public void Configure(EntityTypeBuilder<DbProjectEngineeringAssociation> builder)
        {
            builder.ToTable("ProjectEngineeringAssociation", "dbo");

            builder.HasKey(x => x.Id);
        }
    }
}