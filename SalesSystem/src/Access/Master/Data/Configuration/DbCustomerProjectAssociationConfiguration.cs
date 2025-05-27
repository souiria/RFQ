namespace Master.Data.Configuration
{
    public class DbCustomerProjectAssociationConfiguration : IEntityTypeConfiguration<DbCustomerProjectAssociation>
    {
        public void Configure(EntityTypeBuilder<DbCustomerProjectAssociation> builder)
        {
            builder.ToTable("CustomerProjectAssociation");
            builder.HasKey(x => x.Id);
        }
    }
}
