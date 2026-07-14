
namespace Rfq.Data.Configuration
{
    public class DbDsiBranchConfigurationBendAssociationConfiguration : IEntityTypeConfiguration<DbDsiBranchConfigurationBendAssociation>
    {
        public void Configure(EntityTypeBuilder<DbDsiBranchConfigurationBendAssociation> builder)
        {
            builder.ToTable("DsiBranchConfigurationBendAssociation");
            builder.HasKey(x => x.RowId);
        }
    }
}
