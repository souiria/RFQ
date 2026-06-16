namespace DSI.Data.Configuration
{
    public class DbCompositeDetailConfiguration : IEntityTypeConfiguration<DbCompositeDetail>
    {
        public void Configure(EntityTypeBuilder<DbCompositeDetail> builder)
        {
            builder.ToTable("DsiCompositeDetail");
            builder.HasKey(x => x.RowId);
        }
    }
}
