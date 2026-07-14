namespace SalesSystem.Rfq.Models
{
    public class FileObjectUxModel
    {
        public string Id
        { get; private set; }
        public IBrowserFile? File
        { get; set; }
        public bool IsUploaded
        { get; set; }
        public UxObjectStatus Status
        { get; set; }
        public FileObjectUploadStatus UploadStatus
        { get; set; }
        public DateTime CreatedAt
        { get; private set; }
        public string? OriginalFileName
        { get; private set; }
        public long OriginalFileSize
        { get; private set; }

        public FileObjectUxModel(IBrowserFile browserFile)
        {
            Id = Guid.NewGuid().ToString();
            File = browserFile;
            Status = UxObjectStatus.Created;
            IsUploaded = false;
            UploadStatus = new FileObjectUploadStatus();
            CreatedAt = DateTime.UtcNow;
            OriginalFileName = browserFile?.Name;
            OriginalFileSize = browserFile?.Size ?? 0;
        }

        /// <summary>
        /// Check if this file object can be safely removed (not uploaded yet)
        /// </summary>
        public bool CanBeRemovedSafely => 
            UploadStatus.Status == FileUploadStatus.NotStarted || 
            UploadStatus.Status == FileUploadStatus.Failed;

        /// <summary>
        /// Get a display-friendly file identifier
        /// </summary>
        public string DisplayName => OriginalFileName ?? "Unknown File";

        /// <summary>
        /// Check if the file is still valid (IBrowserFile might become stale)
        /// </summary>
        public bool IsFileValid => File != null && File.Name == OriginalFileName && File.Size == OriginalFileSize;
    }
}
