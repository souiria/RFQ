namespace DSI.Data.Configuration
{
   public class DbComponentConfiguration : IEntityTypeConfiguration<DbComponent>
    {
        public void Configure(EntityTypeBuilder<DbComponent> builder)
        {
            builder.ToTable("Component");
            builder.HasKey(x => x.Id);
        }
    }
}
