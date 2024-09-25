using UX.Commercial.Edi.Core.Enums;

namespace UX.Commercial.Edi.Core.Messages
{
    public class InvalidDispatchesMessage 
    {
        public string Message { get; set; }
        public bool IsDirty { get; set; } = false;
        public bool IsBusy { get; set; } = false;
        public RibbonTabOperation Operation { get; set; } = RibbonTabOperation.Empty;
    }
}