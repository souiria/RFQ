using System;
using System.Collections.Generic;

namespace UX.Commercial.Edi.SharedKernel
{
    public class ResponseBase
    {
        public string OperationId { get; set; }
        public List<Exception> Exceptions { get; set; } = new List<Exception>();
        public byte[] CompressedMessage { get; set; }
        public bool HasHeartBeat { get; set; }
        public string DebugMessage { get; set; }
    }
}
