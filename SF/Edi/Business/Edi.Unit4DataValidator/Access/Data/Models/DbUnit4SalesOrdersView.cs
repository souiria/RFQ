namespace Edi.Unit4DataValidator.Access.Data.Models;

public class DbUnit4SalesOrdersView : IAggregateRoot
{
    public string? FinanceCode { get; set; }
    public string? Client {  get; set; }
    public string? DespatchNumber {  get; set; }
    public DateTime DespatchDate { get; set; }
    public string? ProductNumber {  get; set; }
    public string? Status { get; set; }
}
