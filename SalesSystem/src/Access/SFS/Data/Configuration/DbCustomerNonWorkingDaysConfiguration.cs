namespace SFS.Data.Configuration
{
    public class DbCustomerNonWorkingDaysConfiguration : IEntityTypeConfiguration<DbCustomerNonWorkingDays>
    {
        public void Configure(EntityTypeBuilder<DbCustomerNonWorkingDays> builder)
        {
            builder.ToTable("tblCustomerNonWorkingDays");
            builder.HasNoKey();
        }
    }
}
