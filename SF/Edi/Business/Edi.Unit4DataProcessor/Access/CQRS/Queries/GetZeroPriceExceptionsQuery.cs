namespace Edi.Unit4DataProcessor.Access.CQRS.Queries;
internal class GetZeroPriceExceptionsQuery : IRequest<List<ZeroPriceExceptionsDto>>
{
    public string? WmsSiteCode { get; set; }
}
