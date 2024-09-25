using UX.Module.Edi.Core.Enums;

namespace UX.Module.Edi.Core.Messages
{
    public class ProcessDataMessage
    {
        public string Message { get; set; }
        public RibbonTabOperation Operation;
    }
}
