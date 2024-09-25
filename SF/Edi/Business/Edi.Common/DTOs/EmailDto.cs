using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edi.Common.DTOs;
public class EmailDto
{
    public int HashId { get; set; }
    public ApplicationModule Module { get; set; }
    public DateTime CreatedDate { get; private set; }
    public string? Subject { get; set; }
    public string? To { get; set; }
    public string? Cc { get; set; }
    public string? Bcc { get; set; }
    public string? Body { get; set; }
    public bool Sent { get; set; }
    public int Attempts { get; set; }
    public ICollection<EmailAttachmentDto>? Attachments { get; set; }
}
