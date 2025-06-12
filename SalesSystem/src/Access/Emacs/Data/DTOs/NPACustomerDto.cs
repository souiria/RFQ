namespace Emacs.Data.DTOs
{
    public class NPACustomerDto
    {
        public long Id
        { get; set; }
        public string? Code
        { get; set; }
        public string? Name
        { get; set; }
        public long Subsidiary_id
        { get; set; }
        public long Buyer_id
        { get; set; }
        public string? Address
        { get; set; }
        public string? Phone
        { get; set; }
        public string? Email
        { get; set; }
        public string? Contact
        { get; set; }
        public string? Alternate_contact
        { get; set; }
        public bool Active
        { get; set; }
    }
}
