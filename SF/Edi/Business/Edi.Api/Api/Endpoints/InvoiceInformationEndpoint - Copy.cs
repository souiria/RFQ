using Edi.Common.Messages.Responses;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace Edi.Api.Endpoints;

public class InvoiceInformationEndpoint_orig : InvoiceInformationService.InvoiceInformationServiceBase
{
    private readonly ILogger<InvoiceInformationEndpoint> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private TelemetryClient _telemetry;

    public InvoiceInformationEndpoint_orig(ILogger<InvoiceInformationEndpoint> logger, TelemetryClient telemetry, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _telemetry = telemetry;
        _mediator = mediator;
        _mapper = mapper;
    }

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
            //var results = await _mediator.Send(new InvalidDispatchRequest());
            //var dispatchData = _mapper.Map<List<InvoiceInformationData>>(results);

            //foreach (var invoiceInformationData in dispatchData)
            //{
            //    await responseStream.WriteAsync(invoiceInformationData);
            //}

            foreach (var result in await _mediator.Send(new InvalidDispatchRequest()))
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
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    //private static async System.Collections.Generic.IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> enumerable)
    //{
    //    foreach (var item in enumerable)
    //    {
    //        yield return await Task.FromResult(item);
    //    }
    //}
}
