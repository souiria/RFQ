using CDb.Data.Model;

namespace CDb.Data.Configuration
{
    public class DbAuditEventConfiguration : IEntityTypeConfiguration<DbAuditEvent>
    {
        public void Configure(EntityTypeBuilder<DbAuditEvent> builder)
        {
            builder.ToTable("AuditEvent");
            builder.HasKey(x => x.Id);
        }
    }
}
