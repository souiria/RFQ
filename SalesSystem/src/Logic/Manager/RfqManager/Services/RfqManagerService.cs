namespace RfqModule.Services
{
    public class RfqManagerService
    {
        List<CrossReferenceDto> _CrossReferenceDtos;
        List<FordCsvDto> _FordCSVDtos;
        DsiAggregate _DsiAggregate;

        readonly ILogger<RfqManagerService> _Logger;

        public RfqManagerService(ILogger<RfqManagerService> logger)
        {
            _Logger = logger;
            _CrossReferenceDtos = new List<CrossReferenceDto>();
            _FordCSVDtos = new List<FordCsvDto>();
            _DsiAggregate = new DsiAggregate();

        }

        public async Task<FileUploadResponse> UploadFileAsync(FileUploadRequest request)
        {
            FileUploadResponse response = new FileUploadResponse();
            try
            {
                // Check if file data exists
                if (request.FileData == null || request.FileData.Length == 0)
                {
                    response = new FileUploadResponse();
                    response.Success = false;
                    response.Message = "File data is empty or null.";
                    return response;
                }

                _Logger.GenericLogInformation("File upload request received for file: {FileName}" + request.FileName.ToString());
                _CrossReferenceDtos.Clear();
                _FordCSVDtos.Clear();
                // Process the file based on its extension
                string fileExtension = Path.GetExtension(request.FileName).ToUpperInvariant();
                byte[] fileData = request.FileData.ToByteArray();
                switch (fileExtension)
                {
                    case ".CSV":
                    // Handle CSV file processing
                    _Logger.GenericLogInformation("Processing CSV file: " + request.FileName);
                    object csvData = DocumentConverter.ConvertCSV(fileData, request.FileName);
                    _FordCSVDtos = (List<FordCsvDto>)csvData;
                    break;
                    case ".XML":
                    // Handle XML file processing
                    _Logger.GenericLogInformation("Processing XML file: " + request.FileName);
                    _CrossReferenceDtos = DocumentConverter.ConvertFordXMLFile(fileData).ToList();
                    break;
                    case ".XLSX":
                    // Handle Excel file processing
                    _Logger.GenericLogInformation("Processing Excel file: " + request.FileName);
                    _CrossReferenceDtos = DocumentConverter.ConvertExcelFile(fileData).ToList();
                    break;
                    case ".MTF":
                    // Handle MTF file processing
                    _Logger.GenericLogInformation("Processing MTF file: " + request.FileName);
                    _CrossReferenceDtos = DocumentConverter.ConvertToyotaXMLFile(fileData).ToList();
                    break;
                    case ".TXT":
                    // Handle TXT file processing
                    _Logger.GenericLogInformation("Processing TXT file: " + request.FileName);
                    _CrossReferenceDtos = DocumentConverter.ConvertRenaultCSVFile(fileData).ToList();
                    break;
                    case ".DSI":
                    // Handle DSI file processing
                    _Logger.GenericLogInformation("Processing DSI file: " + request.FileName);
                    _DsiAggregate = DocumentConverter.ConvertDsiFile(fileData);
                    break;
                    default:
                    _Logger.GenericLogInformation("Unsupported file type:" + fileExtension);
                    response = new FileUploadResponse();
                    response.Success = false;
                    response.Message = "Unsupported file type";
                    return response;
                }
            }
            catch (FileFormatException ex)
            {
                _Logger.GenericLogError("Error processing file upload for " + request.FileName, ex);
                response = new FileUploadResponse();
                response.Success = false;
                response.Message = "Unsupported file type";
                return response;
            }
            // Go to the access service to save the data to the database
            await Task.Delay(1000);

            _Logger.GenericLogInformation("File " + request.FileName + " processed successfully");
            response = new FileUploadResponse();
            response.Success = true;
            response.Message = "File uploaded successfully";
            return response;
        }
    }
}
