namespace EDI.Extensions
{
    public static class EdiMappingExtensions
    {
        #region CustomerParameter

        public static EdiCustomerParameterGrpc MapToCustomerParameterGrpc(this DbEdiCustomerParameter entity)
        {
            EdiCustomerParameterGrpc data = new EdiCustomerParameterGrpc();
            data.Id = entity.Id.ToString();
            data.AllowZeroPrices = entity.AllowZeroPrices;
            data.CriticalPathAlert = entity.CriticalPathAlert;
            data.Customer = entity.Customer;
            data.CustomerGuid = entity.CustomerGuid.ToString();
            data.CustomerLocation = entity.CustomerLocation;
            data.CustomerLocationGuId = entity.CustomerLocationGuid.ToString();
            data.DimValue1 = entity.DimValue1;
            data.DimValue2 = entity.DimValue2;
            data.DimValue3 = entity.DimValue3;
            data.DimValue4 = entity.DimValue4;
            data.DimValue5 = entity.DimValue5;
            data.DimValue6 = entity.DimValue6;
            data.DimValue7 = entity.DimValue7;
            data.DistributionList = entity.DistributionList;
            data.FinanceCode = entity.FinanceCode;
            data.IsAutomatingInvoices = entity.IsAutomatingInvoices;
            data.IsUsingCustomerDispatchNumber = entity.IsUsingCustomerDispatchNumber;
            data.IsUsingH1CustomerOrderNumber = entity.IsUsingH1CustomerOrderNumber;
            data.IsUsingH1SchedulingAgreement = entity.IsUsingH1SchedulingAgreement;
            data.IsUsingPartNumber = entity.IsUsingPartNumber;
            data.RelAttrId = entity.RelAttrId;
            data.RelAttrId1 = entity.RelAttrId1;
            data.RelAttrId2 = entity.RelAttrId2;
            data.RelAttrId3 = entity.RelAttrId3;
            data.RelAttrId4 = entity.RelAttrId4;
            data.RelAttrId5 = entity.RelAttrId5;
            data.RelValue = entity.RelValue;
            data.RelValue1 = entity.RelValue1;
            data.RelValue2 = entity.RelValue2;
            data.RelValue3 = entity.RelValue3;
            data.RelValue4 = entity.RelValue4;
            data.RelValue5 = entity.RelValue5;
            data.Unit4Client = entity.Unit4Client;
            data.Unit4OrderIdStatus = ((OrderIdStatus)entity.Unit4OrderIdStatus).ToString();
            data.Unit4ProductGroup = entity.Unit4ProductGroup;
            data.Unit4TaxCode = entity.Unit4TaxCode;
            data.Unit4Warehouse = entity.Unit4Warehouse;
            
            return data;
        }

        #endregion

        #region Edi File Data Upload

        public static EdiFileDataUploadDuplicatesGrpc MapToEdiFileDataUploadDuplicatesGrpc(this DbEdiFileDataUploadDuplicate entity)
        {
            EdiFileDataUploadDuplicatesGrpc data = new EdiFileDataUploadDuplicatesGrpc();
            data.Id = entity.Id;
            data.CustomerDispatchNumber = entity.CustomerDispatchNumber;
            data.CustomerOrderNumber = entity.CustomerOrderNumber;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.DeliveryTerms = entity.DeliveryTerms;
            data.DispatchDate = entity.DispatchDate.ToUniversalTime().ToTimestamp();
            data.DispatchNumber = entity.DispatchNumber;
            data.ExchangeRate = Convert.ToDouble(entity.ExchangeRate);
            data.FileName = entity.FileName;
            data.FinanceCode = entity.FinanceCode;
            data.MessageType = entity.MessageType;
            data.PartDescription = entity.PartDescription;
            data.PartNumber = entity.PartNumber;
            data.Quantity = Convert.ToDouble(entity.Quantity);
            data.Status = entity.Status;
            data.TariffCode = entity.TariffCode;
            data.TotalGrossWeight = Convert.ToDouble(entity.TotalGrossWeight);
            data.TotalNetWeight = Convert.ToDouble(entity.TotalNetWeight);
            data.TransportDetails = entity.TransportDetails;
            data.UnitofMeasure = entity.UnitofMeasure;
            data.UnloadingPoint = entity.UnloadingPoint;
            data.UploadDate = entity.UploadDate.ToUniversalTime().ToTimestamp();
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.WmsInvoiceNumber = entity.WmsInvoiceNumber;
            data.WmsSiteCode = entity.WmsSiteCode;

            return data;
        }

        public static EdiFileDataUploadGrpc MapToEdiFileDataUploadGrpc(this DbEdiFileDataUpload entity)
        {
            EdiFileDataUploadGrpc data = new EdiFileDataUploadGrpc();
            data.Id = entity.Id;
            data.CustomerDispatchNumber = entity.CustomerDispatchNumber;
            data.CustomerOrderNumber = entity.CustomerOrderNumber;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.DeliveryTerms = entity.DeliveryTerms;
            data.DispatchDate = entity.DispatchDate.ToUniversalTime().ToTimestamp();
            data.DispatchNumber = entity.DispatchNumber;
            data.ExchangeRate = Convert.ToDouble(entity.ExchangeRate);
            data.FileName = entity.FileName;
            data.FinanceCode = entity.FinanceCode;
            data.MessageType = entity.MessageType;
            data.PartDescription = entity.PartDescription;
            data.PartNumber = entity.PartNumber;
            data.Quantity = Convert.ToDouble(entity.Quantity);
            data.Status = entity.Status;
            data.TariffCode = entity.TariffCode;
            data.TotalGrossWeight = Convert.ToDouble(entity.TotalGrossWeight);
            data.TotalNetWeight = Convert.ToDouble(entity.TotalNetWeight);
            data.TransportDetails = entity.TransportDetails;
            data.UnitofMeasure = entity.UnitofMeasure;
            data.UnloadingPoint = entity.UnloadingPoint;
            data.UploadDate = entity.UploadDate.ToUniversalTime().ToTimestamp();
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.WmsInvoiceNumber = entity.WmsInvoiceNumber;
            data.WmsSiteCode = entity.WmsSiteCode;

            return data;
        }

        #endregion

        #region Edi Global Parameters

        public static EdiGlobalParametersGrpc MapToEdiGlobalParametersGrpc(this DbEdiGlobalParameter entity)
        {
            EdiGlobalParametersGrpc data = new EdiGlobalParametersGrpc();
            data.ParameterDescription = entity.ParameterDescription;
            data.ParameterName = entity.ParameterName;
            data.ParameterValue = entity.ParameterValue;

            return data;
        }

        #endregion

        #region Edi Invoice Information

        public static EdiInvoiceInformationDuplicateGrpc MapToEdiInvoiceInformationDuplicateGrpc(this DbEdiInvoiceInformationDuplicate entity)
        {
            EdiInvoiceInformationDuplicateGrpc data = new EdiInvoiceInformationDuplicateGrpc();
            data.BatchId = entity.BatchId;
            data.CurrencyCode = entity.CurrencyCode;
            data.Customer = entity.Customer;
            data.CustomerDispatchNumber = entity.CustomerDispatchNumber;
            data.CustomerLocation = entity.CustomerLocation;
            data.CustomerLocationId = entity.CustomerLocationId.ToString();
            data.CustomerOrderNumber = entity.CustomerOrderNumber;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.DeliveryTerms = entity.DeliveryTerms;
            data.DispatchDate = entity.DispatchDate.ToUniversalTime().ToTimestamp();
            data.DispatchNumber = entity.DispatchNumber;
            data.ExchangeRate = Convert.ToDouble(entity.ExchangeRate);
            data.FileName = entity.FileName;
            data.FinanceCode = entity.FinanceCode;
            data.Id = entity.Id.ToString();
            data.IsAgressoTransferred = entity.IsAgressoTransferred;
            data.IsProcessStarted = entity.IsProcessStarted;
            data.IsValidPrice = entity.IsValidPrice;
            data.IsValidProduct = entity.IsValidProduct;
            data.MessageType = entity.MessageType;
            data.OrderPrice = Convert.ToDouble(entity.OrderPrice);
            data.PartDescription = entity.PartDescription;
            data.PartNumber = entity.PartNumber;
            data.ProcessCompletionDate = entity.ProcessCompletionDate.ToUniversalTime().ToTimestamp();
            data.ProcessStartDate = entity.ProcessStartDate.ToUniversalTime().ToTimestamp();
            data.Quantity = Convert.ToDouble(entity.Quantity);
            data.Status = ((EdiInvoiceStatus)entity.Status).ToString();
            data.TariffCode = entity.TariffCode;
            data.TotalGrossWeight = Convert.ToDouble(entity.TotalGrossWeight);
            data.TotalInvoicePrice = Convert.ToDouble(entity.TotalInvoicePrice);
            data.TotalNetWeight = Convert.ToDouble(entity.TotalNetWeight);
            data.TransportDetails = entity.TransportDetails;
            data.UnitOfMeasure = entity.UnitofMeasure;
            data.UnloadingPoint = entity.UnloadingPoint;
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.WMSInvoiceNumber = entity.WmsInvoiceNumber;
            data.WmsSiteCode = entity.WmsSiteCode;

            return data;
        }

        public static EdiInvoiceInformationGrpc MapToEdiInvoiceInformationGrpc(this DbEdiInvoiceInformation entity)
        {
            EdiInvoiceInformationGrpc data = new EdiInvoiceInformationGrpc();
            data.BatchId = entity.BatchId;
            data.CurrencyCode = entity.CurrencyCode;
            data.Customer = entity.Customer;
            data.CustomerDispatchNumber = entity.CustomerDispatchNumber;
            data.CustomerLocation = entity.CustomerLocation;
            data.CustomerLocationId = entity.CustomerLocationId.ToString();
            data.CustomerOrderNumber = entity.CustomerOrderNumber;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.DeliveryTerms = entity.DeliveryTerms;
            data.DispatchDate = entity.DispatchDate.ToUniversalTime().ToTimestamp();
            data.DispatchNumber = entity.DispatchNumber;
            data.ExchangeRate = Convert.ToDouble(entity.ExchangeRate);
            data.FileName = entity.FileName;
            data.FinanceCode = entity.FinanceCode;
            data.Id = entity.Id.ToString();
            data.IsAgressoTransferred = entity.IsAgressoTransferred;
            data.IsProcessStarted = entity.IsProcessStarted;
            data.IsValidPrice = entity.IsValidPrice;
            data.IsValidProduct = entity.IsValidProduct;
            data.MessageType = entity.MessageType;
            data.OrderPrice = Convert.ToDouble(entity.OrderPrice);
            data.PartDescription = entity.PartDescription;
            data.PartNumber = entity.PartNumber;
            data.ProcessCompletionDate = entity.ProcessCompletionDate.ToUniversalTime().ToTimestamp();
            data.ProcessStartDate = entity.ProcessStartDate.ToUniversalTime().ToTimestamp();
            data.Quantity = Convert.ToDouble(entity.Quantity);
            data.Status = ((EdiInvoiceStatus)entity.Status).ToString();
            data.TariffCode = entity.TariffCode;
            data.TotalGrossWeight = Convert.ToDouble(entity.TotalGrossWeight);
            data.TotalInvoicePrice = Convert.ToDouble(entity.TotalInvoicePrice);
            data.TotalNetWeight = Convert.ToDouble(entity.TotalNetWeight);
            data.TransportDetails = entity.TransportDetails;
            data.UnitOfMeasure = entity.UnitofMeasure;
            data.UnloadingPoint = entity.UnloadingPoint;
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.WMSInvoiceNumber = entity.WmsInvoiceNumber;
            data.WmsSiteCode = entity.WmsSiteCode;

            return data;
        }

        #endregion

        #region Edi Invoice Unit 4

        public static EdiInvoiceUnit4Grpc MapToEdiInvoiceUnit4Grpc(this DbEdiInvoiceUnit4 entity)
        {
            EdiInvoiceUnit4Grpc data = new EdiInvoiceUnit4Grpc();
            data.BatchId = entity.BatchId;
            data.CurrencyCode = entity.CurrencyCode;
            data.Customer = entity.Customer;
            data.CustomerDispatchNumber = entity.CustomerDispatchNumber;
            data.CustomerLocation = entity.CustomerLocation;
            data.CustomerLocationId = entity.CustomerLocationId.ToString();
            data.CustomerOrderNumber = entity.CustomerOrderNumber;
            data.CustomerPartNumber = entity.CustomerPartNumber;
            data.DeliveryTerms = entity.DeliveryTerms;
            data.DispatchDate = entity.DispatchDate.ToUniversalTime().ToTimestamp();
            data.DispatchNumber = entity.DispatchNumber;
            data.ExchangeRate = Convert.ToDouble(entity.ExchangeRate);
            data.FileName = entity.FileName;
            data.FinanceCode = entity.FinanceCode;
            data.Id = entity.Id.ToString();
            data.IsAgressoTransferred = entity.IsAgressoTransferred;
            data.IsProcessStarted = entity.IsProcessStarted;
            data.IsValidPrice = entity.IsValidPrice;
            data.IsValidProduct = entity.IsValidProduct;
            data.MessageType = entity.MessageType;
            data.OrderPrice = Convert.ToDouble(entity.OrderPrice);
            data.PartDescription = entity.PartDescription;
            data.PartNumber = entity.PartNumber;
            data.ProcessCompletionDate = entity.ProcessCompletionDate.ToUniversalTime().ToTimestamp();
            data.ProcessStartDate = entity.ProcessStartDate.ToUniversalTime().ToTimestamp();
            data.Quantity = Convert.ToDouble(entity.Quantity);
            data.Status = ((EdiInvoiceStatus)entity.Status).ToString();
            data.TariffCode = entity.TariffCode;
            data.TotalGrossWeight = Convert.ToDouble(entity.TotalGrossWeight);
            data.TotalInvoicePrice = Convert.ToDouble(entity.TotalInvoicePrice);
            data.TotalNetWeight = Convert.ToDouble(entity.TotalNetWeight);
            data.TransportDetails = entity.TransportDetails;
            data.UnitOfMeasure = entity.UnitofMeasure;
            data.UnloadingPoint = entity.UnloadingPoint;
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.WMSInvoiceNumber = entity.WmsInvoiceNumber;
            data.WmsSiteCode = entity.WmsSiteCode;

            return data;
        }

        public static EdiZeroPriceExceptionsGrpc MapToEdiZeroPriceExceptionsGrpc(this DbZeroPriceExceptions entity)
        {
            EdiZeroPriceExceptionsGrpc data = new EdiZeroPriceExceptionsGrpc();
            data.WmsCustomerCode = entity.WmsCustomerCode;
            data.ProductNumber = entity.ProductNumber;

            return data;
        }

        #endregion

    }
}
