using Microsoft.VisualBasic;

namespace Edi.Unit4DataProcessor.Engine;
internal class Unit4DispatchEngine : IRequestHandler<ValidateUnit4DispatchRequest, List<EdiInvoiceInformationDto>>
{
    private readonly ILogger<Unit4DispatchEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public Unit4DispatchEngine(ILogger<Unit4DispatchEngine> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(ValidateUnit4DispatchRequest request, CancellationToken cancellationToken)
    {
        var dispatch = request.SalesPriceData.First();
        var parameters = request.CustomerParameters;
        // Check if in BatchInput
        var invalidCount = await GetUnit4BatchInputCountAsync(dispatch.FinanceCode, parameters.Unit4Client, dispatch.DispatchNumber, dispatch.DispatchDate, cancellationToken);
        if (invalidCount != 0)
        {
            _logger.LogError($"{dispatch.FileName} and {dispatch.DispatchNumber} already exist in AlgBatchInput");
            return null;
        }
        // Check if in AsoHeader
        invalidCount = await GetUnit4AsoHeaderCountAsync(dispatch.FinanceCode, parameters.Unit4Client, dispatch.DispatchNumber, dispatch.DispatchDate, cancellationToken);
        if (invalidCount != 0)
        {
            _logger.LogError($"{dispatch.FileName} and {dispatch.DispatchNumber} already exist in AsoHeader");
            return null;
        }
        // Send to Unit4
        await SendDispatchDataToUnit4Async(request.SalesPriceData, request.CustomerParameters);
        return request.SalesPriceData;
    }
    
    private async Task<int> GetUnit4BatchInputCountAsync(string financeCode, string unit4Client, string dispatchNumber, DateTime dispatchDate, CancellationToken cancellationToken)
    {
        var query = new GetUnit4BatchInputCountQuery { FinanceCode = financeCode, Client = unit4Client, DispatchNumber = dispatchNumber, DispatchDate = dispatchDate };
        return await _mediator.Send(query, cancellationToken);
    }

    private async Task<int> GetUnit4AsoHeaderCountAsync(string financeCode, string client, string dispatchNumber, DateTime dispatchDate, CancellationToken cancellationToken)
    {
        var query = new GetUnit4AsoHeaderCountQuery { FinanceCode = financeCode, Client = client, DispatchNumber = dispatchNumber, DispatchDate = dispatchDate };
        return await _mediator.Send(query, cancellationToken);
    }

    private async Task SendDispatchDataToUnit4Async(List<EdiInvoiceInformationDto> invoiceInformation, EdiCustomerParameterDto parameters)
    {
        var inputData = await InvoiceInformationDtoToAlgBatchInput(invoiceInformation, parameters);
        if (await _mediator.Send(new AddDispatchToUnit4Command(inputData)))
        {
            invoiceInformation.ForEach(m =>
            {
                m.ProcessCompletionDate = DateTime.Now;
                m.Status = EdiInvoiceStatus.SentToUnit4;
            });
            // Save data to EdiInvoiceUnit4 table
            if (await _mediator.Send(
                    new AddEdiInvoiceUnit4Command(_mapper.Map<List<DbEdiInvoiceUnit4>>(invoiceInformation))))
            {
                // Remove data from Edi Invoice table
                await _mediator.Send(
                    new DeleteEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(invoiceInformation)));
            }

        }
        else
        {
            // Save data to Edi Invoice table and report error
            await _mediator.Send(
                new UpdateEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(invoiceInformation)));
            var email = invoiceInformation.FirstOrDefault();
            await _mediator.Send(new SendEmailRequest
            {
                EmailContent = new EmailContentDto
                    { DispatchNumber = email?.DispatchNumber, Filename = email?.FileName, EmailType = EdiInvoiceEmailType.ErrorAddingInvoiceToUnit4 }
            });
        }
    }

    /// <summary>
    /// Converts Dto to DbAlgBatchInput
    /// </summary>
    /// <param name="invoiceInformation"></param>
    /// <param name="parameters"></param>
    /// <returns>List<DbAlgBatchInput></returns>
    private async Task<List<DbAlgBatchInput>> InvoiceInformationDtoToAlgBatchInput(List<EdiInvoiceInformationDto> invoiceInformation, EdiCustomerParameterDto parameters)
    {
        await Task.Delay(0);
        var toReturn = new List<DbAlgBatchInput>();
        var orderId = DateTime.UtcNow.Ticks;

        var rowNo = 0;

            foreach (var invoice in invoiceInformation)
            {
                // Add Header row
                if (rowNo == 0)
                {
                    toReturn.Add(new DbAlgBatchInput
                    {
                        amount_set = (invoice.OrderPrice == 0 && parameters.AllowZeroPrices) ? 0 : 1,
                        apar_id = parameters.FinanceCode,
                        art_descr = "",
                        article = "",
                        batch_id = invoice.BatchId,
                        client = parameters.Unit4Client,
                        cur_amount = 0,
                        currency = "",
                        del_met_descr = invoice.TransportDetails,
                        del_term_descr = invoice.DeliveryTerms,
                        deliv_attention = parameters.IsUsingCustomerDispatchNumber
                            ? invoice.CustomerDispatchNumber
                            : invoice.DispatchNumber,
                        dim_5 = "",
                        dim_6 = "",
                        dim_value_1 = parameters.Dim_Value_1,
                        dim_value_2 = parameters.Dim_Value_2,
                        dim_value_3 = parameters.Dim_Value_3,
                        dim_value_4 = parameters.Dim_Value_4,
                        dim_value_5 = parameters.Dim_Value_5,
                        dim_value_6 = parameters.Dim_Value_6,
                        dim_value_7 = parameters.Dim_Value_7,
                        ext_ord_ref = invoice.WMSInvoiceNumber,
                        line_no = rowNo,
                        long_info1 = invoice.TariffCode,
                        markings = invoice.UnloadingPoint,
                        order_date = invoice.DispatchDate,
                        // just make it a unique number per dispatch
                        order_id = orderId,
                        responsible = "RESP",
                        responsible2 = "RESP",
                        sup_article = invoice.CustomerOrderNumber,
                        tax_code = parameters.Unit4TaxCode,
                        text1 = "", //Will eventually become pallet information
                        text2 = invoice.TotalNetWeight > 0 ? $"{invoice.TotalNetWeight} {invoice.UnitOfMeasure}" : "",
                        text3 = $"{invoice.TotalGrossWeight} {invoice.UnitOfMeasure}",
                        text4 = invoice.ExchangeRate.ToString(),
                        trans_type = "42",
                        value_1 = 0,
                        warehouse = invoice.WMSSiteCode,
                        ext_order_id = (parameters.IsUsingCustomerDispatchNumber
                            ? invoice.CustomerDispatchNumber
                            : invoice.DispatchNumber)
                    });
                    rowNo++;
                }

                // Add detail row
                toReturn.Add(new DbAlgBatchInput
                {
                    amount_set = (invoice.OrderPrice == 0 && parameters.AllowZeroPrices) ? 0 : 1,
                    apar_id = "",
                    art_descr = invoice.PartDescription,
                    article = parameters.IsUsingPartNumber ? invoice.PartNumber : invoice.CustomerPartNumber,
                    batch_id = invoice.BatchId,
                    client = parameters.Unit4Client,
                    cur_amount = invoice.Quantity * invoice.OrderPrice,
                    currency = invoice.CurrencyCode,
                    del_met_descr = "",
                    del_term_descr = "",
                    deliv_attention = parameters.IsUsingCustomerDispatchNumber
                        ? invoice.CustomerDispatchNumber
                        : invoice.DispatchNumber,
                    dim_5 = "",
                    dim_6 = "",
                    ext_ord_ref = "",
                    line_no = rowNo,
                    long_info1 = invoice.TariffCode,
                    markings = "",
                    order_date = invoice.DispatchDate,
                    // just make it a unique number per dispatch
                    order_id = orderId,
                    responsible = "RESP",
                    responsible2 = "RESP",
                    sup_article = invoice.CustomerOrderNumber,
                    tax_code = parameters.Unit4TaxCode,
                    text1 = "",
                    text2 = "",
                    text3 = "",
                    text4 = "",
                    trans_type = "42",
                    value_1 = invoice.Quantity,
                    warehouse = invoice.WMSSiteCode,
                    ext_order_id = ""

                });

                rowNo++;
            }

            orderId = DateTime.UtcNow.Ticks;

        return toReturn;
    }
}
