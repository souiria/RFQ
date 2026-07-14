namespace CDb.Data.Configuration.Masters
{
    public class DbPersonConfiguration : IEntityTypeConfiguration<DbPerson>
    {
        public void Configure(EntityTypeBuilder<DbPerson> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => p.Email);

            builder.HasIndex(p => new { p.PersonType, p.Name, p.Email })
                .IsUnique();
        }
    }
}
