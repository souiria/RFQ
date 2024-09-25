namespace Edi.Api.Access.CQRS.Queries;
internal class GetCustomerParameterQuery : IRequest<List<EdiCustomerParameterDto>>
{
    public string? FinanceCode { get; set; }
}
