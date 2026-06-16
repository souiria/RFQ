namespace DSI.Data.Configuration
{
    public class DbWireSpecificationConfiguration : IEntityTypeConfiguration<DbWireSpecification>
    {
        public void Configure(EntityTypeBuilder<DbWireSpecification> builder)
        {
            builder.ToTable("DsiWireSpecification");
            builder.HasKey(x => x.RowId);
        }
    }
}
