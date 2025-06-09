namespace Emacs.Data.Model
{
    public class DbCustomerData : IAggregateRoot
    {
        public string? CustomerCode
        { get; set; }
        public string? Customer
        { get; set; }
        public string? CustomerGroup
        { get; set; }
    }
}
