namespace Edi.Common.DTOs;
public class EmailContentDto
{
    public string? Filename { get; set; }
    public string? DispatchNumber { get; set; }
    public string? PartNumber { get; set; }
    public DateTime? DispatchDate { get; set; }
    public DateTime? ProcessDate { get; set; }
    public Exception? Exception { get; set; }
    public EdiInvoiceEmailType EmailType { get; set; }
}
