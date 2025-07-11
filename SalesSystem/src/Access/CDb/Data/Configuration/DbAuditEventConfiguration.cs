using CDb.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CDb.Data.Configuration
{
    internal class DbAuditEventConfiguration : IEntityTypeConfiguration<DbAuditEvent>
    {
        public void Configure(EntityTypeBuilder<DbAuditEvent> builder)
        {
            builder.ToTable("AuditEvent");
            builder.HasKey(x => x.Id);
        }
    }
}
