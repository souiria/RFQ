namespace Edi.Unit4DataProcessor.Access.CQRS.Queries;
internal class GetUnit4AsoHeaderCountQuery : IRequest<int>
{
    public string? FinanceCode { get; set; }
    public string? Client { get; set; }
    public string? DispatchNumber { get; set; }
    public DateTime DispatchDate { get; set; }
}