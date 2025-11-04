namespace Rfq.Data.Configuration
{
    public class DbRfqProjectConfiguration : IEntityTypeConfiguration<DbRfqProject>
    {
        public void Configure(EntityTypeBuilder<DbRfqProject> builder)
        {
            builder.ToTable("RfqProject");
            builder.HasKey(x => x.RowId);
            builder.HasOne(x => x.RfqReason).WithMany(b => b.RfqReasons).HasForeignKey(e => e.RfqReasonId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.RfqNumber).HasComputedColumnSql("((('SEWS-'+right(CONVERT([varchar](4),datepart(year,[CreatedDate])),(2))) + '-027-')+right('000000'+CONVERT([varchar](6),[RowId]),(6)))", stored: true);
        }
    }
}