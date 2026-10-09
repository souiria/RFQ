namespace SalesSystem.Rfq.Components.Pages.Components
{
    public partial class FileManager : IAsyncDisposable
    {
        const int MAX_FILE_SIZE = 16 * 1024 * 1024;

        [Parameter]
        public IReadOnlyCollection<FileObjectUxModel> FileObjects { get; set; } = Array.Empty<FileObjectUxModel>();

        [Parameter]
        public EventCallback<Collection<FileObjectUxModel>> OnFilesAdded { get; set; }

        [Parameter]
        public EventCallback OnClearAllRequested { get; set; }

        [Parameter]
        public bool UploadDisabled { get; set; } = true;

        // Drop zone elements
        ElementReference _DropZoneElement;
        InputFile? _InputFile;
        string? _InputFileKey = Guid.NewGuid().ToString();
        IJSObjectReference? _Module;
        IJSObjectReference? _DropZoneInstance;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    _Module = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/DropZone.js");
                    if (_InputFile?.Element != null)
                    {
                        _DropZoneInstance = await _Module.InvokeAsync<IJSObjectReference>("initializeFileDropZone", _DropZoneElement, _InputFile.Element);
                    }
                }
                catch (JSException ex)
                {
                    Console.WriteLine($"ERROR initializing drop zone: {ex.Message}");
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine($"ERROR initializing drop zone: {ex.Message}");
                }
                catch (TaskCanceledException ex)
                {
                    Console.WriteLine($"ERROR initializing drop zone: {ex.Message}");
                }
            }
        }

        async Task OnChange(InputFileChangeEventArgs e)
        {
            try
            {
                List<FileObjectUxModel> newFileObjects = new List<FileObjectUxModel>();
                List<string> addedFiles = new List<string>();
                List<string> rejectedFiles = new List<string>();

                foreach (IBrowserFile file in e.GetMultipleFiles())
                {
                    try
                    {
                        // Check for duplicates by name and size against the current known set
                        if (IsFileAlreadyAdded(file))
                        {
                            rejectedFiles.Add($"{file.Name} (duplicate)");
                            continue;
                        }

                        FileObjectUxModel fileObject = new FileObjectUxModel(file);

                        // Validate file type and size
                        RfqFileType fileType = DetermineFileType(fileObject);
                        if (fileType != RfqFileType.UNK && fileObject.File?.Size <= MAX_FILE_SIZE && 0 < fileObject.File?.Size)
                        {
                            newFileObjects.Add(fileObject);
                            addedFiles.Add(file.Name);
                        }
                        else
                        {
                            string reason = fileType == RfqFileType.UNK ? "unsupported file type" :
                                           fileObject.File?.Size > MAX_FILE_SIZE ? "file too large" :
                                           "invalid file size";
                            rejectedFiles.Add($"{file.Name} ({reason})");
                        }
                    }
                    catch (IOException fileEx)
                    {
                        rejectedFiles.Add($"{file.Name} (error: {fileEx.Message})");
                    }
                    catch (ArgumentException fileEx)
                    {
                        rejectedFiles.Add($"{file.Name} (error: {fileEx.Message})");
                    }
                }

                // Show user feedback
                if (addedFiles.Count > 0)
                {
                    string message = addedFiles.Count == 1
                        ? $"Added file: {addedFiles[0]}"
                        : $"Added {addedFiles.Count} files: {string.Join(", ", addedFiles.Take(3))}{(addedFiles.Count > 3 ? "..." : "")}";
                    Snackbar.Add(message, Severity.Success);
                }

                if (rejectedFiles.Count > 0)
                {
                    string message = rejectedFiles.Count == 1
                        ? $"Rejected file: {rejectedFiles[0]}"
                        : $"Rejected {rejectedFiles.Count} files: {string.Join(", ", rejectedFiles.Take(3))}{(rejectedFiles.Count > 3 ? "..." : "")}";
                    Snackbar.Add(message, Severity.Warning);
                }

                if (newFileObjects.Count > 0 && OnFilesAdded.HasDelegate)
                {
                    // Wrap the List in a Collection<T> to match the public API type
                    await OnFilesAdded.InvokeAsync(new Collection<FileObjectUxModel>(newFileObjects));
                }

                StateHasChanged();
            }
            catch (InvalidOperationException ex)
            {
                Snackbar.Add($"Error uploading files: {ex.Message}", Severity.Error);
            }
        }

        bool IsFileAlreadyAdded(IBrowserFile newFile)
        {
            return FileObjects.Any(f =>
                f.Status != UxObjectStatus.Deleted &&
                f.OriginalFileName == newFile.Name &&
                f.OriginalFileSize == newFile.Size);
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

            RfqFileType fileType = DetermineFileType(fileObject.File.Name);
            return fileType;
        }

        RfqFileType DetermineFileType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToUpperInvariant();

            return extension switch
            {
                ".DSI" => RfqFileType.DSI,
                _ => RfqFileType.UNK
            };
        }

        async Task ClearAllFiles()
        {
            try
            {
                // Reset the input file key to clear the input element
                _InputFileKey = Guid.NewGuid().ToString();

                // Delegate the actual clearing of storage to the owner (ViewModel)
                if (OnClearAllRequested.HasDelegate)
                {
                    await OnClearAllRequested.InvokeAsync();
                }

                StateHasChanged();

                Snackbar.Add("All files cleared successfully", Severity.Success);
            }
            catch (InvalidOperationException ex)
            {
                Snackbar.Add($"Error clearing files: {ex.Message}", Severity.Error);
            }
        }

        public async Task ResetInputFileAsync()
        {
            try
            {
                // Generate new key to force InputFile to re-render and reset internal state
                _InputFileKey = Guid.NewGuid().ToString();

                // Force component to re-render
                StateHasChanged();

                // Small delay to ensure re-render completes
                await Task.Delay(50);

                Console.WriteLine($">>> InputFile reset with new key: {_InputFileKey}");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"ERROR resetting InputFile: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"ERROR resetting InputFile: {ex.Message}");
            }
        }
        public async ValueTask DisposeAsync()
        {
            try
            {
                if (_DropZoneInstance != null)
                {
                    await _DropZoneInstance.InvokeVoidAsync("dispose");
                    await _DropZoneInstance.DisposeAsync();
                }

                if (_Module != null)
                {
                    await _Module.DisposeAsync();
                }
            }
            catch (JSException ex)
            {
                Console.WriteLine($"ERROR disposing FileManagement: {ex.Message}");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine($"ERROR disposing FileManagement: {ex.Message}");
            }
            catch (JSDisconnectedException ex)
            {
                Console.WriteLine($"ERROR disposing FileManagement: {ex.Message}");
            }
            finally
            {
                // Prevent derived types that introduce a finalizer from needing to
                // re-implement IDisposable to call GC.SuppressFinalize.
                GC.SuppressFinalize(this);
            }
        }
    }
}
