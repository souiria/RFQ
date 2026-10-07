namespace SalesSystem.Rfq.Components.Pages.Components
{
    public partial class FileCards
    {
        [Parameter]
        public IReadOnlyCollection<FileObjectUxModel> FileObjects { get; set; } = Array.Empty<FileObjectUxModel>();

        [Parameter]
        public EventCallback<FileObjectUxModel> OnRetryUpload { get; set; }

        [Parameter]
        public EventCallback<FileObjectUxModel> OnRemoveFile { get; set; }

        async Task RemoveFile(FileObjectUxModel fileObject)
        {
            try
            {
                // Notify parent component about the removal
                if (OnRemoveFile.HasDelegate)
                {
                    await OnRemoveFile.InvokeAsync(fileObject);
                }
                else
                {
                    // Fallback: just mark as deleted if no parent handler
                    fileObject.Status = UxObjectStatus.Deleted;
                    StateHasChanged();
                }
            }
            catch (ObjectDisposedException ex)
            {
                // Component or its resources were disposed during the async operation
                Console.WriteLine($"ERROR in RemoveFile: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // StateHasChanged/InvokeAsync called from wrong context, or renderer issues
                Console.WriteLine($"ERROR in RemoveFile: {ex.Message}");
            }
        }

        string GetCardCssClass(FileObjectUxModel fileObject)
        {
            string baseClass = "file-card";

            if (fileObject.Status == UxObjectStatus.Deleted)
            {
                return $"{baseClass} deleted";
            }

            if (fileObject.IsUploaded || fileObject.UploadStatus.Status == FileUploadStatus.Success)
            {
                return $"{baseClass} uploaded";
            }

            return baseClass;
        }

        string GetStatusCssClass(UxObjectStatus status)
        {
            return status switch
            {
                UxObjectStatus.Created => "status-created",
                UxObjectStatus.Updated => "status-updated",
                UxObjectStatus.Deleted => "status-deleted",
                UxObjectStatus.Read => "status-read",
                _ => "status-created"
            };
        }

        string GetUploadStatusCssClass(FileUploadStatus status)
        {
            return status switch
            {
                FileUploadStatus.NotStarted => "upload-not-started",
                FileUploadStatus.InProgress => "upload-in-progress",
                FileUploadStatus.Success => "upload-success",
                FileUploadStatus.Failed => "upload-failed",
                _ => "upload-not-started"
            };
        }

        string GetStatusDisplayText(UxObjectStatus status)
        {
            return status switch
            {
                UxObjectStatus.Created => "Created",
                UxObjectStatus.Updated => "Updated",
                UxObjectStatus.Deleted => "Deleted",
                UxObjectStatus.Read => "Read",
                UxObjectStatus.None => "None",
                _ => status.ToString()
            };
        }

        string GetUploadStatusDisplayText(FileUploadStatus status)
        {
            return status switch
            {
                FileUploadStatus.NotStarted => "Not Started",
                FileUploadStatus.InProgress => "Uploading...",
                FileUploadStatus.Success => "Uploaded",
                FileUploadStatus.Failed => "Failed",
                _ => status.ToString()
            };
        }

        string FormatFileSize(long bytes)
        {
            if (bytes == 0)
            {
                return "0 B";
            }

            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double size = bytes;

            while (size >= 1024 && order < sizes.Length - 1)
            {
                order++;
                size /= 1024;
            }

            return $"{size:0.##} {sizes[order]}";
        }

        RfqFileType DetermineFileType(FileObjectUxModel fileObject)
        {
            if (fileObject.File == null)
            {
                return RfqFileType.UNK;
            }

            if (fileObject.Status == UxObjectStatus.Deleted)
            {
                return RfqFileType.UNK;
            }

            return DetermineFileType(fileObject.File.Name);
        }

        RfqFileType DetermineFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToUpperInvariant();

            return extension switch
            {
                ".DSI" => RfqFileType.DSI,
                ".CSV" => RfqFileType.CSV,
                ".TXT" => RfqFileType.TXT,
                ".XLS" or ".XLSX" => RfqFileType.XLS,
                ".XML" => RfqFileType.XML,
                ".MTF" => RfqFileType.MTF,
                _ => RfqFileType.UNK
            };
        }

        string GetFAFileTypeIcon(RfqFileType fileType)
        {
            return fileType switch
            {
                RfqFileType.UNK => "fa-solid fa-paperclip",
                RfqFileType.DSI => "fa-brands fa-cuttlefish",
                RfqFileType.CSV => "fa-solid fa-file-csv",
                RfqFileType.TXT => "fa-solid fa-file",
                RfqFileType.XLS => "fa-solid fa-file-excel",
                RfqFileType.XML => "fa-solid fa-file-lines",
                RfqFileType.MTF => "fa-solid fa-file-alt",
                _ => "fa-solid fa-paperclip"
            };
        }

        //string GetFileTypeIcon(RfqFileType fileType)
        //{
        //    return fileType switch
        //    {
        //        RfqFileType.UNK => Icons.Material.Filled.AttachFile,
        //        RfqFileType.DSI => Icons.Material.Filled.Engineering,
        //        RfqFileType.CSV => Icons.Material.Filled.TextFormat,
        //        RfqFileType.XLS => Icons.Material.Filled.Workspaces,
        //        RfqFileType.XML => Icons.Material.Filled.DataExploration,
        //        RfqFileType.MTF => Icons.Material.Filled.DataObject,
        //        _ => Icons.Material.Filled.AttachFile
        //    };
        //}

        Color GetFileTypeColor(RfqFileType fileType)
        {
            return fileType switch
            {
                RfqFileType.UNK => Color.Error,
                RfqFileType.DSI => Color.Success,
                RfqFileType.CSV => Color.Success,
                RfqFileType.TXT => Color.Warning,
                RfqFileType.XLS => Color.Success,
                RfqFileType.XML => Color.Success,
                RfqFileType.MTF => Color.Success,
                _ => Color.Error
            };
        }
    }
}
