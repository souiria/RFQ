namespace EDI.Data.Model
{
    public class DbZeroPriceExceptions : IAggregateRoot
    {
        public string? WmsCustomerCode
        { get; set; } 
        public string ProductNumber
        { get; set; } 

        public DbZeroPriceExceptions()
        {
            ProductNumber = "ALL";
        }
    }
}
