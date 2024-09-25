using System.Text;

namespace Edi.FileWatcher.Engine;
internal class CheckForFilesEngine : IRequestHandler<CheckForFilesRequest>
{
    private readonly ILogger<CheckForFilesEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly string _directory;
    private List<string> _newFiles;
    private List<EdiFileDataUploadDto> _ediFileData;
    private List<EdiFileDataUploadDto> _ediDuplicateFileData;
    private EdiCustomerParameterDto _customerParameter;
    private List<EdiInvoiceInformationDto> _ediInvoiceInformation;
    private List<EdiFileDataUploadDto> _filenames;
    private bool _alreadyProcessing;

    public CheckForFilesEngine(ILogger<CheckForFilesEngine> logger, IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
        _directory = Environment.GetEnvironmentVariable("EDI_DIRECTORY_PATH") ?? "C:\\EDIFileWatcher";
        _newFiles = new List<string>();
        _ediFileData = new List<EdiFileDataUploadDto>();
        _ediDuplicateFileData = new List<EdiFileDataUploadDto>();
        _customerParameter = new EdiCustomerParameterDto();
        _ediInvoiceInformation = new List<EdiInvoiceInformationDto>();
        _filenames = [];
        _alreadyProcessing = false;
    }

    public async Task Handle(CheckForFilesRequest request, CancellationToken cancellationToken)
    {
        if (!_alreadyProcessing)
        {
            _newFiles.Clear();
            _ediFileData.Clear();
            _ediDuplicateFileData.Clear();
            _ediInvoiceInformation.Clear();

            try
            {
                await Task.Delay(0, cancellationToken);

                // Check Dropbox for new files
                _alreadyProcessing = true;
                _logger.LogDebug("Checking for Files.");

                var dropBoxFiles = GetFilesByDirectory($"{_directory}\\Dropbox", cancellationToken);
                // Check whether the new file name has already been used and loaded - if so, throw error and move to error folder.
                foreach (var dropBoxFile in dropBoxFiles)
                {
                    if (Path.GetExtension(dropBoxFile) != ".csv")
                    {
                        MoveFile(_directory, dropBoxFile, EdiInvoiceStatus.Error);
                        _logger.LogInformation($"Unsupported file extension for {dropBoxFile}");
                        await _mediator.Send(new SendEmailRequest
                        {
                            EmailContent = new EmailContentDto
                                { Filename = dropBoxFile, EmailType = EdiInvoiceEmailType.InvalidColumnCount }
                        }, cancellationToken);
                    }

                    var alreadyUsed = await CheckIfFileNameAlreadyUsed(dropBoxFile, cancellationToken);
                    if (alreadyUsed)
                    {
                        await _mediator.Send(new SendEmailRequest
                        {
                            EmailContent = new EmailContentDto
                                { Filename = dropBoxFile, EmailType = EdiInvoiceEmailType.FileNameAlreadyUploaded }
                        }, cancellationToken);
                        MoveFile(_directory, dropBoxFile, EdiInvoiceStatus.Error);
                        _logger.LogInformation($"File {dropBoxFile} has already been used, moving to error folder.");
                    }
                    else
                    {
                        _newFiles.Add(dropBoxFile);
                    }
                }

                // Check whether the file contents have already been loaded.
                foreach (var newFile in _newFiles)
                {
                    _logger.LogDebug($"Reading data from {newFile}");
                    await ReadEdiFileDataAsync(newFile, cancellationToken);
                }

                // Save valid data to EdiFileDataUpload table.
                if (_ediFileData.Count != 0)
                {
                    var groupedEdiFileData = _ediFileData.GroupBy(x => x.FinanceCode);

                    foreach (var financeCode in groupedEdiFileData)
                    {
                        // Check for empty customer number
                        await GetCustomerParameterAsync(financeCode.Key, cancellationToken);
                        await CheckForEmptyCustomerNumber(financeCode, cancellationToken);
                        await CreateEdiInvoiceInformationModelAsync(financeCode, cancellationToken);
                    }

                    await SaveEdiFileDataAsync(cancellationToken);
                    await SaveEdiInvoiceInformationAsync(cancellationToken);
                    _logger.LogDebug("Saved data to Edi Invoice Information table");
                }

                // Save duplicate data to EdiDuplicateFileData table
                if (_ediDuplicateFileData.Count != 0)
                {
                    var dropBoxFile = new StringBuilder();
                    await SaveEdiFileDuplicateDataAsync(cancellationToken);
                    _logger.LogDebug("Saved data to Edi File Duplicate Data table");
                    foreach (var duplicateFileData in _ediDuplicateFileData.GroupBy(x => x.FileName))
                    {
                        var fileName = duplicateFileData.FirstOrDefault()?.FileName;
                        dropBoxFile.Append($"{fileName} ,");
                    }
                    await _mediator.Send(new SendEmailRequest
                    {
                        EmailContent = new EmailContentDto
                            { Filename = dropBoxFile.ToString(), EmailType = EdiInvoiceEmailType.DuplicatedData }
                    }, cancellationToken);
                    
                }

                // Move file into archive folder.
                foreach (var newFile in _newFiles)
                {
                    MoveFile(_directory, newFile, EdiInvoiceStatus.Duplicate);
                }

                if (_newFiles.Any())
                {
                    // Select all outstanding rows from Edi Invoice Information
                    await GetEdiInvoiceInformationDataAsync(cancellationToken);
                    var dispatches = _ediInvoiceInformation.GroupBy(x => x.DispatchNumber);
                    foreach (var dispatch in dispatches)
                    {
                        await _publishEndpoint.Publish(new DispatchDataInserted { DispatchData = dispatch.ToList() },
                            cancellationToken);
                    }
                }
                // Finished.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _alreadyProcessing = false;
            }
        }
        else
        {
            _logger.LogInformation("Processing files found");
        }
    }

    private List<string> GetFilesByDirectory(string directoryPath, CancellationToken token)
    {
        var ret = new List<string>();
        if (token.IsCancellationRequested) return ret;
        ret.AddRange(Directory.EnumerateFiles(directoryPath).Select(file => new FileInfo(file).FullName));
        return ret;
    }

    private async Task<bool> CheckIfFileNameAlreadyUsed(string fileName, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        var fileWithoutPath = new FileInfo(fileName).Name;
        var alreadyUsed = await _mediator.Send(new CheckForExistingFileNameRequest { FileName = fileWithoutPath }, cancellationToken);
        return alreadyUsed.Any();
    }

    public string MoveFile(string directoryPath, string filepath, EdiInvoiceStatus status)
    {
        var subfolder = status switch
        {
            EdiInvoiceStatus.New or EdiInvoiceStatus.Duplicate => "Archive",
            EdiInvoiceStatus.Error => "Error",
            _ => ""
        };
        var newFile = $"{directoryPath}\\{subfolder}\\{Path.GetFileName(filepath)}";
        if (File.Exists(newFile) && subfolder != "Import")
        {
            newFile = $"{directoryPath}\\{subfolder}\\{Path.GetFileNameWithoutExtension(filepath)}_{DateTime.Now:dd_MM_yyyy_HH_mm}.csv";
            File.Move(filepath, $"{newFile}");
        }
        else
            File.Move(filepath, newFile);
        return newFile;
    }

    private async Task ReadEdiFileDataAsync(string fileToRead, CancellationToken cancellationToken)
    {
        var fileData = await File.ReadAllLinesAsync(fileToRead, cancellationToken);
        var fileNameSplit = Path.GetFileNameWithoutExtension(fileToRead).Split('_');

        foreach (var line in fileData)
        {
            var lineData = line.Split(',');

            try
            {
                var rowData = await CsvDataToEdiFileDataUploadDto(lineData, Path.GetFileName(fileToRead),
                    fileNameSplit[0], cancellationToken);

                // Check for duplicate row data
                var isDuplicate = await CheckForDuplicateDataAsync(rowData.FileName, rowData.DispatchDate, rowData.DispatchNumber, cancellationToken);
                if (isDuplicate)
                {
                    _ediDuplicateFileData.Add(rowData);
                }
                else
                {
                    _ediFileData.Add(rowData);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        
    }

    private async Task<EdiFileDataUploadDto> CsvDataToEdiFileDataUploadDto(string[] lineData, string filename, string financeCode, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        if (lineData.Length < 20) throw new Exception("Unsupported file content length.");
        
        var index = 0;
        return new EdiFileDataUploadDto
        {
            FileName = filename, 
            FinanceCode = financeCode,
            DispatchNumber = lineData[index++],
            DispatchDate = Convert.ToDateTime(lineData[index++]),
            CustomerOrderNumber = lineData[index++],
            PartNumber = lineData[index++],
            PartDescription = string.IsNullOrEmpty(lineData[index++]) ? lineData[index - 2] : lineData[index - 1],
            Quantity = string.IsNullOrEmpty(lineData[index++]) ? 0d : double.Parse(lineData[index - 1]),
            UnloadingPoint = lineData[index++],
            WmsSiteCode = lineData[index++],
            WmsCustomerCode = lineData[index++],
            CustomerDispatchNumber = lineData[index++],
            MessageType = lineData[index++],
            ExchangeRate = string.IsNullOrEmpty(lineData[index++]) ? 0d : double.Parse(lineData[index - 1]),
            CustomerPartNumber = lineData[index++],
            TotalGrossWeight = string.IsNullOrEmpty(lineData[index++]) ? 0d : double.Parse(lineData[index - 1]),
            TotalNetWeight = string.IsNullOrEmpty(lineData[index++]) ? 0d : double.Parse(lineData[index - 1]),
            UnitOfMeasure = lineData[index++],
            TariffCode = lineData[index++],
            DeliveryTerms = lineData[index++],
            TransportDetails = lineData[index++],
            WmsInvoiceNumber = lineData[index]
        };
    }

    private async Task<bool> CheckForDuplicateDataAsync(string filename, DateTime dispatchDate, string dispatchNumber, CancellationToken cancellationToken)
    {
        var query = new GetDuplicateEdiFileDataQuery { Filename = filename, DispatchDate = dispatchDate, DispatchNumber = dispatchNumber };
        var queryResults = await _mediator.Send(query, cancellationToken);
        return queryResults.Any();
    }

    private async Task GetCustomerParameterAsync(string? financeCode, CancellationToken cancellationToken)
    {
        var query = new GetCustomerParameterQuery { FinanceCode = financeCode };
        var queryResults = await _mediator.Send(query, cancellationToken);
        if (queryResults != null) _customerParameter = queryResults.FirstOrDefault();
    }

    private async Task GetEdiInvoiceInformationDataAsync(CancellationToken cancellationToken)
    {
        _ediInvoiceInformation = await _mediator.Send(new GetEdiInvoiceInformationQuery(), cancellationToken);
    }
    private async Task CheckForEmptyCustomerNumber(IGrouping<string, EdiFileDataUploadDto> financeCode, CancellationToken cancellationToken)
    {
        _filenames.Clear();
        foreach (var fileDataUploadDto in financeCode)
        {
            if (!_customerParameter.IsUsingPartNumber && _ediFileData.Any(x => string.IsNullOrEmpty(x.CustomerPartNumber) && x.FileName == fileDataUploadDto.FileName))
            {
                _filenames.Add(fileDataUploadDto);
            }
        }

        // Stop bad files from saving
        var groupedBadFile = _filenames.GroupBy(x => x.FileName);
        foreach (var badFile in groupedBadFile)
        {
            var fileName = badFile.FirstOrDefault()?.FileName;
            for (int i = 0; i < _ediFileData.Count; i++)
            {
                if (_ediFileData[i].FileName == fileName)
                    _ediFileData.Remove(_ediFileData[i]);
            }

            _logger.LogError($"{fileName} - IsUsingPartNumber is false but Customer Part Number is null or empty");
            await _mediator.Send(new SendEmailRequest
            {
                EmailContent = new EmailContentDto
                    { Filename = fileName, EmailType = EdiInvoiceEmailType.InvalidColumnCount }
            }, cancellationToken);
        }

    }

    private async Task CreateEdiInvoiceInformationModelAsync(IGrouping<string, EdiFileDataUploadDto> data, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        foreach (var row in data)
        {
            _ediInvoiceInformation.Add(new EdiInvoiceInformationDto
            {
                DispatchNumber = row.DispatchNumber,
                FileName = row.FileName,
                FinanceCode = row.FinanceCode,
                DispatchDate = row.DispatchDate,
                BatchId = row.DispatchDate.ToString("yyyyMMdd") + row.DispatchNumber,
                CurrencyCode = "EUR",
                Customer = _customerParameter?.Customer,
                CustomerDispatchNumber = row.CustomerDispatchNumber,
                CustomerLocation = _customerParameter.CustomerLocation,
                CustomerLocationId = _customerParameter.CustomerLocationGuId,
                CustomerOrderNumber = row.CustomerOrderNumber,
                CustomerPartNumber = row.CustomerPartNumber,
                DeliveryTerms = row.DeliveryTerms,
                ExchangeRate = row.ExchangeRate,
                Id = Guid.NewGuid(),
                IsAgressoTransferred = false,
                IsProcessStarted = false,
                IsValid = false,
                IsValidPrice = false,
                IsValidProduct = false,
                MessageType = row.MessageType,
                OrderPrice = -1,
                PartDescription = row.PartDescription,
                PartNumber = row.PartNumber,
                ProcessStartDate = DateTime.UtcNow,
                Quantity = row.Quantity,
                Status = _customerParameter == null || (_customerParameter != null && !_customerParameter.IsAutomatingInvoices) ? EdiInvoiceStatus.Error
                    : EdiInvoiceStatus.New,
                TariffCode = row.TariffCode,
                TotalGrossWeight = row.TotalGrossWeight,
                TotalInvoicePrice = 0,
                TotalNetWeight = row.TotalNetWeight,
                TransportDetails = row.TransportDetails,
                UnitOfMeasure = row.UnitOfMeasure,
                UnloadingPoint = row.UnloadingPoint,
                WMSCustomerCode = row.WmsCustomerCode,
                WMSInvoiceNumber = row.WmsInvoiceNumber,
                WMSSiteCode = row.WmsSiteCode
            });

        }
        
    }

    private async Task<bool> SaveEdiFileDataAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new AddEdiFileDataCommand(_mapper.Map<List<DbEdiFileDataUpload>>(_ediFileData)), cancellationToken);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    private async Task<bool> SaveEdiFileDuplicateDataAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new AddEdiFileDuplicateDataCommand(_mapper.Map<List<DbEdiFileDataUploadDuplicate>>(_ediDuplicateFileData)), cancellationToken);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    private async Task<bool> SaveEdiInvoiceInformationAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new AddEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(_ediInvoiceInformation)), cancellationToken);
        }
        catch (AutoMapperMappingException ex)
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new SafeExceptionConverter()); //Add a converter.
            throw new Exception(JsonConvert.SerializeObject(ex, settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
