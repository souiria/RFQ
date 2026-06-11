namespace DSI.Data.Configuration
{     
    public class DbBranchInsulationConfiguration : IEntityTypeConfiguration<DbBranchInsulation>
    {
        public void Configure(EntityTypeBuilder<DbBranchInsulation> builder)
        {
            builder.ToTable("BranchInsulation");
            builder.HasKey(x => x.Id);
        }
    }
}
