namespace Master.Data.Configuration
{
    public class DbCustomerBusinessUserAssociationConfiguration : IEntityTypeConfiguration<DbCustomerBusinessUserAssociation>
    {
        public void Configure(EntityTypeBuilder<DbCustomerBusinessUserAssociation> builder)
        {
            builder.ToTable("CustomerBusinessUserAssociation");
            builder.HasKey(x => x.Id);
        }
    }
}
