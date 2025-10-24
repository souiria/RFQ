namespace SalesSystem.Rfq.Models
{
    public enum FileUploadStatus
    {
        NotStarted,
        InProgress,
        Success,
        Failed
    }
    public class FileObjectUploadStatus
    {
        public FileUploadStatus Status
        { get; set; }
        public string Message
        { get; set; } = string.Empty;
        public FileObjectUploadStatus()
        {
            Status = FileUploadStatus.NotStarted;
            Message = string.Empty;
        }
        public FileObjectUploadStatus(UploadPartsRequestGrpcResponse response)
        {
            Status = response.Success ? FileUploadStatus.Success : FileUploadStatus.Failed;
            Message = response.Message;
        }
    }
}