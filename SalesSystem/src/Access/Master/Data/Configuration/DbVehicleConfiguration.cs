namespace Master.Data.Configuration
{
    public class DbVehicleConfiguration : IEntityTypeConfiguration<DbVehicle>
    {
        public void Configure(EntityTypeBuilder<DbVehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(x => x.Id);
        }
    }
}
