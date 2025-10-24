
namespace SalesSystem.Rfq.Models
{
    public class FileObjectUx
    {
        public IBrowserFile? File
        { get; set; }
        public bool IsUploaded
        { get; set; }
        public UxObjectStatus Status
        { get; set; }
        public FileObjectUploadStatus UploadStatus
        { get; set; }

        public FileObjectUx(IBrowserFile browserFile)
        {
            File = browserFile;
            Status = UxObjectStatus.Created;
            IsUploaded = false;
            UploadStatus = new FileObjectUploadStatus();
        }
    }
}
