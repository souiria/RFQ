namespace Master.Data.Configuration
{
    public class DbCurrencyConfiguration : IEntityTypeConfiguration<DbCurrency>
    {
        public void Configure(EntityTypeBuilder<DbCurrency> builder)
        {
            builder.ToTable("Currency");
            builder.HasKey(x => x.Id);
        }
    }
}
