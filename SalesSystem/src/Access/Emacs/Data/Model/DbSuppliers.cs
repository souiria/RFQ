namespace Emacs.Data.Model
{
    public class DbSuppliers : IAggregateRoot
    {
        public int SupplierCode
        { get; set; }
        public string? SupplierName
        { get; set; }
    }
}
