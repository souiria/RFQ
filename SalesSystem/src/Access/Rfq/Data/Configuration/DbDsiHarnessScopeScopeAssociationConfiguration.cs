namespace Rfq.Data.Configuration
{
    public class DbDsiHarnessScopeScopeAssociationConfiguration : IEntityTypeConfiguration<DbDsiHarnessScopeScopeAssociation>
    {
        public void Configure(EntityTypeBuilder<DbDsiHarnessScopeScopeAssociation> builder)
        {
            builder.ToTable("DsiHarnessScopeScopeAssociation");
            builder.HasKey(x => x.RowId);
        }
    }
}
