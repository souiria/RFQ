namespace DSI.Data.Configuration
{
   public class DbComponentConfiguration : IEntityTypeConfiguration<DbComponent>
    {
        public void Configure(EntityTypeBuilder<DbComponent> builder)
        {
            builder.ToTable("DsiComponent");
            builder.HasKey(x => x.RowId);
        }
    }
}
