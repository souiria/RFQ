namespace Edi.Unit4DataValidator.Access.CQRS.Queries;
internal class GetUnit4InputProductsQuery : IRequest<int>
{
    public string? PartNumber { get; set; }
    public string? Client { get; set; }
}
