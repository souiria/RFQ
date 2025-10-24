namespace Unit4.Data.Configuration
{
    class DbMinAlgArticleConfiguration : IEntityTypeConfiguration<DbMinAlgArticle>
    {
        public void Configure(EntityTypeBuilder<DbMinAlgArticle> builder)
        {
            ((EntityTypeBuilder)builder).ToTable("algarticle");
            builder.HasNoKey();
            builder.Property(x => x.Id).HasColumnName("agrtid");
            builder.Property(x => x.Article).HasColumnName("article");
            builder.Property(x => x.Description).HasColumnName("art_descr");
            builder.Property(x => x.AgressoClient).HasColumnName("client");
        }
    }
}
