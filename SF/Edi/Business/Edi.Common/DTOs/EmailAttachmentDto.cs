namespace Edi.Common.DTOs;
public class EmailAttachmentDto
{
    public int Id { get; set; }
    public int EmailId { get; set; }
    public EmailDto? Email { get; set; }
    public string? FileName { get; set; }
    public byte[]? Data { get; set; }
}
