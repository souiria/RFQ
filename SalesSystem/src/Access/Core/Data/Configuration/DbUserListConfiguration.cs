namespace Core.Data.Configuration
{
    public class DbUserListConfiguration : IEntityTypeConfiguration<DbUserList>
    {
        public void Configure(EntityTypeBuilder<DbUserList> builder)
        {
            builder.ToTable("UserList");
            builder.HasKey(x => x.Id);
        }
    }
}
