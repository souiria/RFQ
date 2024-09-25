using UX.Module.Edi.SharedKernel;

namespace UX.Module.Edi.Core.Messages.Requests
{
    public class ImportFileRequest : RequestBase
    {
        public string FileName { get; set; }
        public CommercialEdiRequestType RequestType { get; set; }
    }

    public enum CommercialEdiRequestType
    {
        CheckForHeartBeat,
        StartFullFileProcessing,
        ImportFile,
        ReProcessFile
    }
}
