using UX.Commercial.Edi.Core.Enums;

namespace UX.Commercial.Edi.Core.Messages
{
    public class UpdateMessage 
    {
        public string Message { get; set; }
        public CRUDOperation Operation { get; set; }
    }
}