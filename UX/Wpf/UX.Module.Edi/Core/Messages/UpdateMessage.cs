using UX.Module.Edi.Core.Enums;

namespace UX.Module.Edi.Core.Messages
{
    public class UpdateMessage 
    {
        public string Message { get; set; }
        public CRUDOperation Operation { get; set; }
    }
}