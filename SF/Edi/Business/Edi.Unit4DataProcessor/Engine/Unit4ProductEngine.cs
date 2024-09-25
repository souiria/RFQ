namespace Edi.Unit4DataProcessor.Engine;
internal class Unit4ProductEngine : IRequestHandler<ValidateProductRequest, List<EdiInvoiceInformationDto>>
{
    private readonly ILogger<Unit4ProductEngine> _logger;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public Unit4ProductEngine(ILogger<Unit4ProductEngine> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<List<EdiInvoiceInformationDto>> Handle(ValidateProductRequest request, CancellationToken cancellationToken)
    {
        await Task.Delay(0, cancellationToken);
        var validationResults =  await ValidateProducts(request.SalesPriceData, request.CustomerParameters);
        return await CheckForFullyValidDispatch(validationResults);
    }

    private async Task<List<EdiInvoiceInformationDto>> ValidateProducts(List<EdiInvoiceInformationDto> invoiceData, EdiCustomerParameterDto customerParameters)
    {
        try
        {
            foreach (var information in invoiceData.Where(information => !information.IsValidProduct))
            {
                information.IsProcessStarted = true;
                var usePartNumber = customerParameters.IsUsingPartNumber
                    ? information.PartNumber
                    : information.CustomerPartNumber;


                // Check Unit 4 Product Master Data
                if (await ProductInUnit4MasterData(usePartNumber,
                        customerParameters.Unit4Client.Trim()))
                {
                    information.IsValidProduct = true;
                }
                else
                {
                    // Check Unit 4 Product Batch Input
                    var unit4ProductCount = await GetAllAlgProductInputCountByPartNumber(
                        usePartNumber.Trim(), customerParameters.Unit4Client);
                    if (unit4ProductCount == 0)
                    {
                        try
                        {
                            information.IsValidProduct = await AddAlgProductInput(information,
                                customerParameters);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, ex.Message);
                            // TODO: Sort email
                            //await _emailHelper.SendEdiEmailAsync(
                            //    new EmailContentDto
                            //    {
                            //        Filename = information.FileName,
                            //        EmailType = EdiInvoiceEmailType.ErrorAddingProductToUnit4, Exception = e,
                            //        PartNumber = information.PartNumber
                            //    }, cancellationToken);
                        }
                    }
                    else
                    {
                        information.IsValidProduct = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        return invoiceData;
    }
    private async Task<bool> ProductInUnit4MasterData(string informationPartNumber, string unit4Client)
    {
        await Task.Delay(0);
        return Manager.Unit4DataProcessor.Unit4Products != null
               && Manager.Unit4DataProcessor.Unit4Products.Count != 0
               && Manager.Unit4DataProcessor.Unit4Products.Any(m => string.Equals(m.Article.Trim(), informationPartNumber.Trim(), StringComparison.CurrentCultureIgnoreCase)
                                                                    && string.Equals(m.AgressoClient.Trim(), unit4Client, StringComparison.CurrentCultureIgnoreCase));
    }
    private async Task<int> GetAllAlgProductInputCountByPartNumber(string partNumber, string unit4Client)
    {
        var query = new GetUnit4InputProductsQuery { PartNumber = partNumber, Client = unit4Client };
        return await _mediator.Send(query);
    }
    private async Task<bool> AddAlgProductInput(EdiInvoiceInformationDto information, EdiCustomerParameterDto customer)
    {
        DbAlgProductInput? productData = new();
        try
        {
            productData = await EdiDtoToDbModel(information, customer);
            return await _mediator.Send(new AddUnit4ProductCommand(productData));
        }
        catch (Exception ex)
        {
            await _mediator.Send(new SendEmailRequest
            {
                EmailContent = new EmailContentDto
                    { Filename = information.FileName, PartNumber = productData.article, EmailType = EdiInvoiceEmailType.ErrorAddingProductToUnit4 }
            });
            Console.WriteLine(ex);
            throw;
        }
        
    }

    /// <summary>
    /// Converts Dto to DbAlgProductInput
    /// </summary>
    /// <param name="information"></param>
    /// <returns></returns>
    public async Task<DbAlgProductInput> EdiDtoToDbModel(EdiInvoiceInformationDto information, EdiCustomerParameterDto customerParameter)
    {
        await Task.Delay(0);
        return new DbAlgProductInput
        {
            add_up = 0,
            amount_set = 0,
            apar_gr_id = "",
            apar_id = "",
            art_descr = customerParameter.IsUsingPartNumber ? information.PartNumber : information.CustomerPartNumber,
            art_gr_id = customerParameter.Unit4ProductGroup,
            article = customerParameter.IsUsingPartNumber ? information.PartNumber : information.CustomerPartNumber,
            asset_id = "",
            batch_id = "",
            bflag = 2,
            bonus_type = 0,
            client = customerParameter.Unit4Client, //"WU",
            comp_article = "",
            contract_ctr = "",
            contract_id = "",
            currency = information.CurrencyCode,
            date_col1 = new DateTime(1900, 01, 01),
            date_col2 = new DateTime(1900, 01, 01),
            date_col3 = new DateTime(1900, 01, 01),
            date_col4 = new DateTime(1900, 01, 01),
            date_from = DateTime.Now.AddYears(100),
            date_limitted = 0,
            date_to = DateTime.Now.AddYears(100),
            deliv_day = 0,
            description = "",
            disc_type = 0,
            ean = "",
            fixed_contract = 0,
            guarantee = 0,
            image_source = "",
            kit_type = "",
            language = "EN",
            line_no = 0,
            location = "",
            long_info = "",
            lot_flag = 0,
            max_level = 0,
            message_text = "",
            multiplier = 0,
            nick_name = "",
            old_rel_value = "",
            order_level = 0,
            order_val = 0,
            overrun = 0,
            price_code = "",
            price_gr = "",
            purch_amt = 0,
            purch_price = 0,
            purch_rule = "",
            reference_1 = "",
            rel_attr_id = customerParameter.rel_attr_id,
            rel_attr_id1 = customerParameter.rel_attr_id1,
            rel_attr_id2 = customerParameter.rel_attr_id2,
            rel_attr_id3 = customerParameter.rel_attr_id3,
            rel_attr_id4 = customerParameter.rel_attr_id4,
            rel_attr_id5 = customerParameter.rel_attr_id5,
            rel_value = customerParameter.rel_value,
            rel_value1 = customerParameter.rel_value1,
            rel_value2 = customerParameter.rel_value2,
            rel_value3 = customerParameter.rel_value3,
            rel_value4 = customerParameter.rel_value4,
            rel_value5 = customerParameter.rel_value5,
            rent_flag = 0,
            sales_amt = 0,
            serial_cat = 0,
            serial_flag = 0,
            serial_no = "",
            short_info = information.PartNumber,
            source_type = "",
            status = "N",
            stock_flag = 0,
            sup_article = "",
            tax_code = "",
            text_type = "I",
            text1 = "",
            text2 = "",
            text3 = "",
            text4 = "",
            trans_type = "1",
            unit_code = "EA",
            unit_descr = "",
            unit_value = 0,
            update_flag = 0,
            value_1 = 0,
            value_from = 0,
            value_to = 0,
            value1 = 0,
            value2 = 0,
            value3 = 0,
            value4 = 0,
            volume = 0,
            warehouse = customerParameter.Unit4Warehouse,
            weight = 0,

            agrtid = 0,
            external_flag = 0,
            info_flag = 0,
            min_order_qty = 0,
            order_qty_inc = 0,
            product_rank = 0,
            public_product = 0
        };
    }

    private async Task<List<EdiInvoiceInformationDto>> CheckForFullyValidDispatch(List<EdiInvoiceInformationDto> validationResults)
    {
        try
        {
            foreach (var information in validationResults.Where(information => information is { IsValidPrice: true, IsValidProduct: true }))
            {
                information.Status = EdiInvoiceStatus.ValidDispatchLine;
            }

            if (validationResults.All(x => x.Status == EdiInvoiceStatus.ValidDispatchLine))
                return validationResults;
            else
            {
                await UpdateEdiInvoiceInformationAsync(validationResults, CancellationToken.None);
                return null;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    private async Task<bool> UpdateEdiInvoiceInformationAsync(List<EdiInvoiceInformationDto> invoiceInformation, CancellationToken cancellationToken)
    {
        try
        {
            return await _mediator.Send(new UpdateEdiInvoiceInformationCommand(_mapper.Map<List<DbEdiInvoiceInformation>>(invoiceInformation)), cancellationToken);
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
