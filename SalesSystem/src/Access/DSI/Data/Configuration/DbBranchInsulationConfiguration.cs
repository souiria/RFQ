namespace DSI.Data.Configuration
{     
    public class DbBranchInsulationConfiguration : IEntityTypeConfiguration<DbBranchInsulation>
    {
        public void Configure(EntityTypeBuilder<DbBranchInsulation> builder)
        {
            builder.ToTable("DsiBranchInsulation");
            builder.HasKey(x => x.RowId);
        }
    }
}
