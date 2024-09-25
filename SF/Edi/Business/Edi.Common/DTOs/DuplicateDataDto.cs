using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edi.Common.DTOs;
public class DuplicateDataDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string DispatchNumber { get; set; }
    public bool IsMarkedForDeletion { get; set; }
    public bool IsMarkedForReprocessing { get; set; }
}
