namespace DSI.Data.Configuration
{
    public class DbCompositeDetailConfiguration : IEntityTypeConfiguration<DbCompositeDetail>
    {
        public void Configure(EntityTypeBuilder<DbCompositeDetail> builder)
        {
            builder.ToTable("CompositeDetail");
            builder.HasKey(x => x.Id);
        }
    }


}
