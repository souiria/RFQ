namespace EDI.Data.Configuration
{
    public class DbEdiGlobalParameterConfiguration : IEntityTypeConfiguration<DbEdiGlobalParameter>
    {
        public void Configure(EntityTypeBuilder<DbEdiGlobalParameter> builder)
        {
            builder.ToTable("EdiGlobalParameter", "dbo");
            builder.HasKey(x => x.ParameterName).HasName("PK_EdiGlobalParameter").IsClustered();
        }
    }
}
