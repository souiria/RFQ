namespace Edi.DataProcessor.Access.Data.Configurations;

internal class DbMinAlgArticleConfiguration : IEntityTypeConfiguration<DbMinAlgArticle>
{
    public void Configure(EntityTypeBuilder<DbMinAlgArticle> builder)
    {
        RelationalEntityTypeBuilderExtensions.ToTable((EntityTypeBuilder)builder, "algarticle");
        builder.HasNoKey();
        builder.Property(x => x.Id).HasColumnName("agrtid");
        builder.Property(x => x.Article).HasColumnName("article");
        builder.Property(x => x.Description).HasColumnName("art_descr");
        builder.Property(x => x.AgressoClient).HasColumnName("client");
    }
}
