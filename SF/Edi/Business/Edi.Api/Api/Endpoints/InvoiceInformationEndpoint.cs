using Castle.Core.Resource;
using Edi.Api.Access.CQRS.Commands;
using Edi.Api.Access.Data.Models;
using Edi.Common.Messages.Responses;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace Edi.Api.Endpoints;

public class InvoiceInformationEndpoint : InvoiceInformationService.InvoiceInformationServiceBase
{
    private readonly ILogger<InvoiceInformationEndpoint> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private TelemetryClient _telemetry;
    private readonly IPublishEndpoint _publishEndpoint;

    private List<EdiFileDataUploadDto> _ediDuplicateFileData;
    private EdiCustomerParameterDto? _customerParameter;
    private List<EdiInvoiceInformationDto> _ediInvoiceInformation;

    public InvoiceInformationEndpoint(ILogger<InvoiceInformationEndpoint> logger, TelemetryClient telemetry, IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _telemetry = telemetry;
        _mediator = mediator;
        _mapper = mapper;
        _publishEndpoint = publishEndpoint;
        _ediDuplicateFileData = new();
        _ediInvoiceInformation = new();
    }

    #region InvoiceInformationService Methods
    public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        var timer = new Stopwatch();
        timer.Start();
        var results = await _mediator.Send(new InvalidDispatchRequest());
        timer.Stop();
        return await Task.FromResult(new HelloReply
        {
            Message = $"{results.Count} Results collated in {timer.ElapsedMilliseconds}ms"
        });
    }

    public override async Task<ListInvoiceInformationData> GetEdiInvoiceInformation(Empty request, ServerCallContext context)
    {
        //System.Collections.Generic.IAsyncEnumerable<InvoiceInformationData> toReturn;
        ListInvoiceInformationData informationData = new();
        try
        {
            var results = await _mediator.Send(new InvalidDispatchRequest());
            //var dispatchData = _mapper.Map<List<InvoiceInformationData>>(results);

            //foreach (var invoiceInformationData in dispatchData)
            //{
            //    await responseStream.WriteAsync(invoiceInformationData);
            //}

            foreach (var result in results)
            {
                informationData.InvoiceInformationData.Add(new InvoiceInformationData
                {
                    BatchId = result.BatchId,
                    CurrencyCode = result.CurrencyCode,
                    Customer = result.Customer,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerLocation = result.CustomerLocation,
                    CustomerLocationId = result.CustomerLocationId.ToString(),
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    CustomerPartNumber = result.CustomerPartNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    DispatchDate = result.DispatchDate.ToUniversalTime().ToTimestamp(),
                    DispatchNumber = result.DispatchNumber,
                    ExchangeRate = result.ExchangeRate,
                    FileName = result.FileName,
                    FinanceCode = result.FinanceCode,
                    Id = result.Id.ToString(),
                    IsAgressoTransferred = result.IsAgressoTransferred,
                    IsProcessStarted = result.IsProcessStarted,
                    IsValid = result.IsValid,
                    IsValidPrice = result.IsValidPrice,
                    IsValidProduct = result.IsValidProduct,
                    MessageType = result.MessageType,
                    OrderPrice = result.OrderPrice,
                    PartDescription = result.PartDescription,
                    PartNumber = result.PartNumber,
                    Quantity = result.Quantity,
                    TotalInvoicePrice = result.TotalInvoicePrice,
                    Status = result.Status.ToString(),

                });
                
            }

            return informationData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task GetEdiInvoiceInformationStream(Empty request, IServerStreamWriter<InvoiceInformationData> responseStream, ServerCallContext context)
    {
        try
        {
            var timer = new Stopwatch();
            timer.Start();
            var results = await _mediator.Send(new InvalidDispatchRequest());
            ServiceEventSource.Current.Message($"{results.Count} Results collated from DB in {timer.ElapsedMilliseconds}ms");
            foreach (var result in results)
            {
                var informationData = new InvoiceInformationData
                {
                    BatchId = result.BatchId,
                    CurrencyCode = result.CurrencyCode,
                    Customer = result.Customer,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerLocation = result.CustomerLocation,
                    CustomerLocationId = result.CustomerLocationId.ToString(),
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    CustomerPartNumber = result.CustomerPartNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    DispatchDate = result.DispatchDate.ToUniversalTime().ToTimestamp(),
                    DispatchNumber = result.DispatchNumber,
                    ExchangeRate = result.ExchangeRate,
                    FileName = result.FileName,
                    FinanceCode = result.FinanceCode,
                    Id = result.Id.ToString(),
                    IsAgressoTransferred = result.IsAgressoTransferred,
                    IsProcessStarted = result.IsProcessStarted,
                    IsValid = result.IsValid,
                    IsValidPrice = result.IsValidPrice,
                    IsValidProduct = result.IsValidProduct,
                    MessageType = result.MessageType,
                    OrderPrice = result.OrderPrice,
                    PartDescription = result.PartDescription,
                    PartNumber = result.PartNumber,
                    Quantity = result.Quantity,
                    TotalInvoicePrice = result.TotalInvoicePrice,
                    Status = result.Status.ToString(),

                };
                await responseStream.WriteAsync(informationData);
            }
            ServiceEventSource.Current.Message($"{results.Count} Results collated and sent in {timer.ElapsedMilliseconds}ms");
            timer.Stop();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task<ListDuplicateInvoiceInformation> GetDuplicateInvoiceInformation(Empty request, ServerCallContext context)
    {
        //System.Collections.Generic.IAsyncEnumerable<InvoiceInformationData> toReturn;
        ListDuplicateInvoiceInformation duplicateData = new();
        try
        {
            var results = await _mediator.Send(new DuplicatedDispatchDataRequest());
            foreach (var result in results)
            {
                duplicateData.DuplicateInvoiceInformation.Add(new DuplicateInvoiceInformation
                {
                    FinanceCode = result.FinanceCode,
                    CustomerPartNumber = result.CustomerPartNumber,
                    FileName = result.FileName,
                    DispatchNumber = result.DispatchNumber,
                    DispatchDate = result.DispatchDate.ToUniversalTime().ToTimestamp(),
                    PartNumber = result.PartNumber,
                    TotalGrossWeight = result.TotalGrossWeight,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    ExchangeRate = result.ExchangeRate,
                    Id = result.Id,
                    Quantity = result.Quantity,
                    PartDescription = result.PartDescription,
                    UnloadingPoint = result.UnloadingPoint,
                    WmsSiteCode = result.WmsSiteCode,
                    WmsCustomerCode = result.WmsCustomerCode,
                    MessageType = result.MessageType,
                    TotalNetWeight = result.TotalNetWeight,
                    UnitOfMeasure = result.UnitOfMeasure,
                    TariffCode = result.TariffCode,
                    TransportDetails = result.TransportDetails,
                    WmsInvoiceNumber = result.WmsInvoiceNumber,
                    UploadDate = result.UploadDate.ToUniversalTime().ToTimestamp(),
                    Status = result.Status.ToString()
                });

            }

            return duplicateData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task GetDuplicateInvoiceInformationStream(Empty request, IServerStreamWriter<DuplicateInvoiceInformation> responseStream, ServerCallContext context)
    {
        try
        {
            var results = await _mediator.Send(new DuplicatedDispatchDataRequest());

            foreach (var result in results)
            {
                var duplicateData = new DuplicateInvoiceInformation
                {
                    FinanceCode = result.FinanceCode,
                    CustomerPartNumber = result.CustomerPartNumber,
                    FileName = result.FileName,
                    DispatchNumber = result.DispatchNumber,
                    DispatchDate = result.DispatchDate.ToUniversalTime().ToTimestamp(),
                    PartNumber = result.PartNumber,
                    TotalGrossWeight = result.TotalGrossWeight,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    ExchangeRate = result.ExchangeRate,
                    Id = result.Id,
                    Quantity = result.Quantity,
                    PartDescription = result.PartDescription,
                    UnloadingPoint = result.UnloadingPoint,
                    WmsSiteCode = result.WmsSiteCode,
                    WmsCustomerCode = result.WmsCustomerCode,
                    MessageType = result.MessageType,
                    TotalNetWeight = result.TotalNetWeight,
                    UnitOfMeasure = result.UnitOfMeasure,
                    TariffCode = result.TariffCode,
                    TransportDetails = result.TransportDetails,
                    WmsInvoiceNumber = result.WmsInvoiceNumber,
                    UploadDate = DateTime.UtcNow.ToTimestamp(),
                    Status = result.Status.ToString()
                };
                await responseStream.WriteAsync(duplicateData);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task<ProcessDuplicatesResponse> ProcessDuplicates(ProcessDuplicatesRequest request, ServerCallContext context)
    {
        ProcessDuplicatesResponse duplicateData = new();
        try
        {
            // First Process Duplicates
            var toDelete = new List<DuplicateDataDto>();
            var toReprocess = new List<DuplicateDataDto>();

            foreach (var duplicate in request.DuplicateData)
            {
                if (duplicate.IsMarkedForDeletion)
                {
                    toDelete.Add(new DuplicateDataDto
                    {
                        DispatchNumber = duplicate.DispatchNumber,
                        FileName = duplicate.FileName,
                        Id = Guid.Parse(duplicate.Id),
                        IsMarkedForDeletion = duplicate.IsMarkedForDeletion,
                        IsMarkedForReprocessing = duplicate.IsMarkedForReprocessing
                    });
                }
                if (duplicate.IsMarkedForReprocessing)
                {
                    toReprocess.Add(new DuplicateDataDto
                    {
                        DispatchNumber = duplicate.DispatchNumber,
                        FileName = duplicate.FileName,
                        Id = Guid.Parse(duplicate.Id),
                        IsMarkedForDeletion = duplicate.IsMarkedForDeletion,
                        IsMarkedForReprocessing = duplicate.IsMarkedForReprocessing
                    });
                }
            }
            if (toDelete.Count > 0)
                await DeleteDuplicates(toDelete, context.CancellationToken);
            if (toReprocess.Count > 0)
                await SendDuplicates(toReprocess, context.CancellationToken);

            // Now wait a few moments then get remaining and return
            await Task.Delay(TimeSpan.FromSeconds(10));
            var results = await _mediator.Send(new DuplicatedDispatchDataRequest());

            foreach (var result in results)
            {
                duplicateData.DuplicateInvoiceInformation.Add(new DuplicateInvoiceInformation
                {
                    FinanceCode = result.FinanceCode,
                    CustomerPartNumber = result.CustomerPartNumber,
                    FileName = result.FileName,
                    DispatchNumber = result.DispatchNumber,
                    DispatchDate = result.DispatchDate.ToUniversalTime().ToTimestamp(),
                    PartNumber = result.PartNumber,
                    TotalGrossWeight = result.TotalGrossWeight,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    ExchangeRate = result.ExchangeRate,
                    Id = result.Id,
                    Quantity = result.Quantity,
                    PartDescription = result.PartDescription,
                    UnloadingPoint = result.UnloadingPoint,
                    WmsSiteCode = result.WmsSiteCode,
                    WmsCustomerCode = result.WmsCustomerCode,
                    MessageType = result.MessageType,
                    TotalNetWeight = result.TotalNetWeight,
                    UnitOfMeasure = result.UnitOfMeasure,
                    TariffCode = result.TariffCode,
                    TransportDetails = result.TransportDetails,
                    WmsInvoiceNumber = result.WmsInvoiceNumber,
                    UploadDate = result.UploadDate.ToUniversalTime().ToTimestamp()
                });
            }

            return duplicateData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override Task<ReprocessResponse> ReprocessDispatchData(ReprocessRequest request, ServerCallContext context)
    {
        return base.ReprocessDispatchData(request, context);
    }

    public override async Task<ListEdiCustomerParameterData> GetEdiCustomerParameters(Empty request, ServerCallContext context)
    {
        ListEdiCustomerParameterData parameterData = new();
        try
        {
            var results = await _mediator.Send(new EdiCustomerParameterRequest());
            foreach (var result in results)
            {
                parameterData.EdiCustomerParameterData.Add(new EdiCustomerParameterData
                { 
                    FinanceCode = result.FinanceCode,
                    AllowZeroPrices = result.AllowZeroPrices,
                    Customer = result.Customer,
                    CustomerGuid = result.CustomerGuid.ToString(),
                    CustomerLocation = result.CustomerLocation,
                    CustomerLocationGuId = result.CustomerLocationGuId.ToString(),
                    DimValue1 = result.Dim_Value_1,
                    DimValue2 = result.Dim_Value_2,
                    DimValue3 = result.Dim_Value_3,
                    DimValue4 = result.Dim_Value_4,
                    DimValue5 = result.Dim_Value_5,
                    DimValue6 = result.Dim_Value_6,
                    DimValue7 = result.Dim_Value_7,
                    Id = result.Id.ToString(),
                    IsUsingPartNumber = result.IsUsingPartNumber,
                    Unit4Client = result.Unit4Client,
                    IsAutomatingInvoices = result.IsAutomatingInvoices,
                    IsUsingCustomerDispatchNumber = result.IsUsingCustomerDispatchNumber,
                    IsUsingH1CustomerOrderNumber = result.IsUsingH1CustomerOrderNumber,
                    IsUsingH1SchedulingAgreement = result.IsUsingH1SchedulingAgreement,
                    RelAttrId = result.rel_attr_id,
                    RelAttrId1 = result.rel_attr_id1,
                    RelAttrId2 = result.rel_attr_id2,
                    RelAttrId3 = result.rel_attr_id3,
                    RelAttrId4 = result.rel_attr_id4,
                    RelAttrId5 = result.rel_attr_id5,
                    RelValue = result.rel_value,
                    RelValue1 = result.rel_value1,
                    RelValue2 = result.rel_value2,
                    RelValue3 = result.rel_value3,
                    RelValue4 = result.rel_value4,
                    RelValue5 = result.rel_value5,
                    Unit4OrderIdStatus = result.Unit4OrderIdStatus.ToString(),
                    Unit4ProductGroup = result.Unit4ProductGroup,
                    Unit4TaxCode = result.Unit4TaxCode,
                    Unit4Warehouse = result.Unit4Warehouse

                });

            }

            return parameterData;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override async Task GetEdiCustomerParametersStream(Empty request, IServerStreamWriter<EdiCustomerParameterData> responseStream, ServerCallContext context)
    {
        try
        {
            var results = await _mediator.Send(new EdiCustomerParameterRequest());

            foreach (var result in results)
            {
                var parameterData = new EdiCustomerParameterData
                {
                    FinanceCode = result.FinanceCode,
                    AllowZeroPrices = result.AllowZeroPrices,
                    Customer = result.Customer,
                    CustomerGuid = result.CustomerGuid.ToString(),
                    CustomerLocation = result.CustomerLocation,
                    CustomerLocationGuId = result.CustomerLocationGuId.ToString(),
                    DimValue1 = result.Dim_Value_1,
                    DimValue2 = result.Dim_Value_2,
                    DimValue3 = result.Dim_Value_3,
                    DimValue4 = result.Dim_Value_4,
                    DimValue5 = result.Dim_Value_5,
                    DimValue6 = result.Dim_Value_6,
                    DimValue7 = result.Dim_Value_7,
                    Id = result.Id.ToString(),
                    IsUsingPartNumber = result.IsUsingPartNumber,
                    Unit4Client = result.Unit4Client,
                    IsAutomatingInvoices = result.IsAutomatingInvoices,
                    IsUsingCustomerDispatchNumber = result.IsUsingCustomerDispatchNumber,
                    IsUsingH1CustomerOrderNumber = result.IsUsingH1CustomerOrderNumber,
                    IsUsingH1SchedulingAgreement = result.IsUsingH1SchedulingAgreement,
                    RelAttrId = result.rel_attr_id,
                    RelAttrId1 = result.rel_attr_id1,
                    RelAttrId2 = result.rel_attr_id2,
                    RelAttrId3 = result.rel_attr_id3,
                    RelAttrId4 = result.rel_attr_id4,
                    RelAttrId5 = result.rel_attr_id5,
                    RelValue = result.rel_value,
                    RelValue1 = result.rel_value1,
                    RelValue2 = result.rel_value2,
                    RelValue3 = result.rel_value3,
                    RelValue4 = result.rel_value4,
                    RelValue5 = result.rel_value5,
                    Unit4OrderIdStatus = result.Unit4OrderIdStatus.ToString(),
                    Unit4ProductGroup = result.Unit4ProductGroup,
                    Unit4TaxCode = result.Unit4TaxCode,
                    Unit4Warehouse = result.Unit4Warehouse

                };
                await responseStream.WriteAsync(parameterData);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Private Methods
    private async Task SendDuplicates(List<DuplicateDataDto> toProcess, CancellationToken cancellationToken)
    {
        _ediDuplicateFileData.Clear();
        _ediInvoiceInformation.Clear();
        // Get Duplicate Data
        foreach (var duplicateDataDto in toProcess)
        {
            _ediDuplicateFileData.AddRange(await _mediator.Send(new GetDuplicateEdiFileDataQuery { Filename = duplicateDataDto.FileName, DispatchNumber = duplicateDataDto.DispatchNumber}, cancellationToken));
        }
        
        // Convert into EdiInvoiceInformation
        var groupedEdiFileData = _ediDuplicateFileData.GroupBy(x => x.FinanceCode);
        foreach (var financeCode in groupedEdiFileData)
        {
            await GetCustomerParameterAsync(financeCode.Key, cancellationToken);
            await CreateEdiInvoiceInformationModelAsync(financeCode, cancellationToken);
        }

        await SaveEdiInvoiceInformationAsync(cancellationToken);
        await UpdateDuplicateEdiFileData(EdiFileUploadStatus.Processed, cancellationToken);

        // Publish
        var dispatches = _ediInvoiceInformation.GroupBy(x => x.DispatchNumber);
        foreach (var dispatch in dispatches)
        {
            await _publishEndpoint.Publish(new DispatchDataInserted { DispatchData = dispatch.ToList() },
                cancellationToken);
        }
    }

    private async Task GetCustomerParameterAsync(string? financeCode, CancellationToken cancellationToken)
    {
        var query = new GetCustomerParameterQuery { FinanceCode = financeCode };
        var queryResults = await _mediator.Send(query, cancellationToken);
        _customerParameter = queryResults.FirstOrDefault();
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

    private async Task DeleteDuplicates(List<DuplicateDataDto> toDelete, CancellationToken cancellationToken)
    {
        _ediDuplicateFileData.Clear();
        _ediInvoiceInformation.Clear();
        // Get Duplicate Data
        foreach (var duplicateDataDto in toDelete)
        {
            _ediDuplicateFileData.AddRange(await _mediator.Send(new GetDuplicateEdiFileDataQuery { Filename = duplicateDataDto.FileName, DispatchNumber = duplicateDataDto.DispatchNumber }, cancellationToken));
        }
        await UpdateDuplicateEdiFileData(EdiFileUploadStatus.Deleted, cancellationToken);
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

    private async Task<bool> UpdateDuplicateEdiFileData(EdiFileUploadStatus status, CancellationToken cancellationToken)
    {
        try
        {
            _ediDuplicateFileData.ForEach(x => x.Status = status);
            return await _mediator.Send(new UpdateEdiFileDuplicateDataCommand(_mapper.Map<List<DbEdiFileDataUploadDuplicate>>(_ediDuplicateFileData)), cancellationToken);
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

    #endregion
}
