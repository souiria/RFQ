namespace Rfq.Data.Configuration
{
    public class DbRfqNotesConfiguration : IEntityTypeConfiguration<DbRfqNotes>
    {
        public void Configure(EntityTypeBuilder<DbRfqNotes> builder)
        {
            builder.ToTable("RfqNotes");
            builder.HasKey(x => x.RowId);
            builder.HasOne(x => x.RfqProject).WithMany(x => x.RfqNotes).HasForeignKey(e => e.RfqId);
        }
    }
}
