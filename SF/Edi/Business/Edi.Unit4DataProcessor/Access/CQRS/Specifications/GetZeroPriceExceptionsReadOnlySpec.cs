namespace Edi.Unit4DataProcessor.Access.CQRS.Specifications;
internal class GetZeroPriceExceptionsReadOnlySpec : Specification<DbZeroPriceExceptions>
{
public GetZeroPriceExceptionsReadOnlySpec(string? wmsSiteCode)
{
    Query.Where(x => x.SiteCode == wmsSiteCode).AsNoTracking();
}
}