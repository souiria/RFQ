namespace Edi.Unit4DataValidator.Access.Data.Models;
internal class DbZeroPriceExceptions : IAggregateRoot
{
    public required string SiteCode { get; set; }
    public required string ProductNumber { get; set; }
}
