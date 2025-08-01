namespace EDI.Data.Configuration
{
    public class DbEdiGlobalParameterConfiguration : IEntityTypeConfiguration<DbEdiGlobalParameter>
    {
        public void Configure(EntityTypeBuilder<DbEdiGlobalParameter> builder)
        {
            builder.ToTable("EdiGlobalParameter", "dbo");
            builder.HasNoKey();
        }
    }
}
