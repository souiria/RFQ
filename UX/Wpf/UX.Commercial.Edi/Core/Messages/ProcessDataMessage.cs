using UX.Commercial.Edi.Core.Enums;

namespace UX.Commercial.Edi.Core.Messages
{
    public class ProcessDataMessage
    {
        public string Message { get; set; }
        public RibbonTabOperation Operation;
    }
}
