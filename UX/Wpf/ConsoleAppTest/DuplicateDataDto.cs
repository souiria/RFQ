using System;

namespace UX.Module.Edi.Core.Dto
{
    public class DuplicateDataDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string DispatchNumber { get; set; }
        public bool IsMarkedForDeletion { get; set; }
        public bool IsMarkedForReprocessing { get; set; }
    }
}
