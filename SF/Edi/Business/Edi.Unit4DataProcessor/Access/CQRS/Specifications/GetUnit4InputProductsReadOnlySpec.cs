namespace Edi.Unit4DataProcessor.Access.CQRS.Specifications;
internal sealed class GetUnit4InputProductsReadOnlySpec : Specification<DbAlgProductInput>
{
    public GetUnit4InputProductsReadOnlySpec(string? partNumber, string? client)
    {
        Query
            .Where(x => x.client == client && x.article == partNumber)
            .AsNoTracking();
    }
}
