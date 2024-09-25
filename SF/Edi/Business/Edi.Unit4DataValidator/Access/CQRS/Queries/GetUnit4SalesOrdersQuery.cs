namespace Edi.Unit4DataValidator.Access.CQRS.Queries;
internal class GetUnit4SalesOrdersQuery : IRequest<List<Unit4SalesOrdersViewDto>>
{
    public string? FinanceCode { get; set; }
    public string? Client { get; set; }
    public string? DispatchNumber { get; set; }
    public DateTime DispatchDate { get; set; }
}
