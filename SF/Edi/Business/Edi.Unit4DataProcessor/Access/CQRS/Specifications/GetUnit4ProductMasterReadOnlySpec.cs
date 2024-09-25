namespace Edi.Unit4DataProcessor.Access.CQRS.Specifications;
internal sealed class GetUnit4ProductMasterReadOnlySpec : Specification<DbMinAlgArticle>
{
    public GetUnit4ProductMasterReadOnlySpec()
    {
        Query
            .AsNoTracking();
    }
}
