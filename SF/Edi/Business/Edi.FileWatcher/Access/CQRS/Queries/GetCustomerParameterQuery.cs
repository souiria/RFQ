namespace Edi.FileWatcher.Access.CQRS.Queries;
internal class GetCustomerParameterQuery : IRequest<List<EdiCustomerParameterDto>>
{
    public string? FinanceCode { get; set; }
}
