namespace Edi.DataProcessor.Access.CQRS.Specifications;
internal sealed class GetZeroPriceExceptionsReadOnlySpec : Specification<DbZeroPriceExceptions>
{
public GetZeroPriceExceptionsReadOnlySpec(string? wmsSiteCode)
{
    Query.Where(x => x.SiteCode == wmsSiteCode).AsNoTracking();
}
}