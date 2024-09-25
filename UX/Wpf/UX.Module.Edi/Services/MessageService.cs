using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using GrpcServices;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.Core.Enums;
using UX.Module.Edi.Core.Helpers;
using UX.Module.Edi.Core.Interfaces;
using UX.Module.Edi.Core.Messages.Responses;

namespace UX.Module.Edi.Services
{
    public class MessageService : IMessageService
    {
        public string Token { get; set; }
        public async Task<ReprocessResponse> ReprocessDispatchData(string apiPath, ReprocessRequest request)
        {
            await Task.Delay(0);
            var response = new ReprocessResponse();
            var client = GetClient();

            #region Unary
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await client.ReprocessDispatchDataAsync(request, cancellationToken: cts.Token);

            response.Success = true;
            #endregion

            return response;
        }

        public async Task<ReprocessResponse> ProcessDuplicatesRequest(string apiPath, ProcessDuplicatesRequest request)
        {
            await Task.Delay(0);
            var response = new ReprocessResponse();

            var client = GetClient();

            #region Unary
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            await client.ProcessDuplicatesAsync(request, cancellationToken: cts.Token);

            response.Success = true;
            #endregion

            return response;
        }

        public string GetMessage()
        {
            throw new NotImplementedException();
        }



        public async IAsyncEnumerable<EdiInvoiceInformationDto> GetAllInvoiceInformation<T>(string apiPath, T request)
        {
            var client = GetClient();

            #region Unary
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            var unaryCall = await client.GetEdiInvoiceInformationAsync(new Empty(), cancellationToken: cts.Token);

            foreach (var result in unaryCall.InvoiceInformationData)
            {
                
                yield return new EdiInvoiceInformationDto
                {
                    BatchId = result.BatchId,
                    CurrencyCode = result.CurrencyCode,
                    Customer = result.Customer,
                    CustomerDispatchNumber = result.CustomerDispatchNumber,
                    CustomerLocation = result.CustomerLocation,
                    CustomerLocationId = Guid.Parse(result.CustomerLocationId),
                    CustomerOrderNumber = result.CustomerOrderNumber,
                    CustomerPartNumber = result.CustomerPartNumber,
                    DeliveryTerms = result.DeliveryTerms,
                    DispatchDate = result.DispatchDate.ToDateTime(),
                    DispatchNumber = result.DispatchNumber,
                    ExchangeRate = result.ExchangeRate,
                    FileName = result.FileName,
                    FinanceCode = result.FinanceCode,
                    Id = Guid.Parse(result.Id),
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
                    Status = (EdiInvoiceStatus)System.Enum.Parse(typeof(EdiInvoiceStatus), result.Status),

                };

            }
            #endregion

            #region TEST FOR UNARY CALL
            //for (var i = 0; i < 10; i++)
            //{
            //    // var response = await client.SayHelloAsync(new HelloRequest { Name = $"{i}" });

            //    var response = await client.SayHelloAsync(
            //        new HelloRequest { Name = $"{i}" });

            //    Console.WriteLine(response.Message);
            //    await Task.Delay(2000);
            //}
            #endregion

            #region Local Debug Sample Data
            //await Task.Delay(5000);
            //return new InvoiceInformationResponse
            //{
            //    InvoiceInformation = new List<EdiInvoiceInformationDto>
            //    {
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part1",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis001",
            //            ExchangeRate = 1.0,
            //            FileName = "Test.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = false,
            //            IsValidPrice = false,
            //            IsValidProduct = false,
            //            MessageType = "ASN",
            //            OrderPrice = -1.0,
            //            PartDescription = "A Part",
            //            PartNumber = "Part1",
            //            Quantity = 25,
            //            Status = EdiInvoiceStatus.MissingPrice,

            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part2",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = false,
            //            IsValidPrice = true,
            //            IsValidProduct = false,
            //            MessageType = "ASN",
            //            OrderPrice = 9.876,
            //            PartDescription = "A Part 2",
            //            PartNumber = "Part2",
            //            Quantity = 25,
            //            Status = EdiInvoiceStatus.MissingPart,
            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part3",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = true,
            //            IsValidPrice = true,
            //            IsValidProduct = true,
            //            MessageType = "ASN",
            //            OrderPrice = 11.276,
            //            PartDescription = "A Part 3",
            //            PartNumber = "Part3",
            //            Quantity = 370,
            //            TotalInvoicePrice = 250000.00,
            //            Status = EdiInvoiceStatus.HeldUp,
            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part4",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = true,
            //            IsValidPrice = true,
            //            IsValidProduct = true,
            //            MessageType = "ASN",
            //            OrderPrice = 15.973,
            //            PartDescription = "A Part 4",
            //            PartNumber = "Part4",
            //            Quantity = 279,
            //            TotalInvoicePrice = 250000.00,
            //            Status = EdiInvoiceStatus.HeldUp,
            //        }
            //    }
            //};
            #endregion
        }

        public async IAsyncEnumerable<EdiInvoiceInformationDto> GetAllInvoiceInformationStream<T>(string apiPath, T request)
        {
            var client = GetClient();

            #region Server Streaming
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            using var streamingCall = client.GetEdiInvoiceInformationStream(new Empty(), cancellationToken: cts.Token);

                while (await streamingCall.ResponseStream.MoveNext(cancellationToken: cts.Token))
                {
                    yield return new EdiInvoiceInformationDto
                    {
                        BatchId = streamingCall.ResponseStream.Current.BatchId,
                        CurrencyCode = streamingCall.ResponseStream.Current.CurrencyCode,
                        Customer = streamingCall.ResponseStream.Current.Customer,
                        CustomerDispatchNumber = streamingCall.ResponseStream.Current.CustomerDispatchNumber,
                        CustomerLocation = streamingCall.ResponseStream.Current.CustomerLocation,
                        CustomerLocationId = Guid.Parse(streamingCall.ResponseStream.Current.CustomerLocationId),
                        CustomerOrderNumber = streamingCall.ResponseStream.Current.CustomerOrderNumber,
                        CustomerPartNumber = streamingCall.ResponseStream.Current.CustomerPartNumber,
                        DeliveryTerms = streamingCall.ResponseStream.Current.DeliveryTerms,
                        DispatchDate = streamingCall.ResponseStream.Current.DispatchDate.ToDateTime(),
                        DispatchNumber = streamingCall.ResponseStream.Current.DispatchNumber,
                        ExchangeRate = streamingCall.ResponseStream.Current.ExchangeRate,
                        FileName = streamingCall.ResponseStream.Current.FileName,
                        FinanceCode = streamingCall.ResponseStream.Current.FinanceCode,
                        Id = Guid.Parse(streamingCall.ResponseStream.Current.Id),
                        IsAgressoTransferred = streamingCall.ResponseStream.Current.IsAgressoTransferred,
                        IsProcessStarted = streamingCall.ResponseStream.Current.IsProcessStarted,
                        IsValid = streamingCall.ResponseStream.Current.IsValid,
                        IsValidPrice = streamingCall.ResponseStream.Current.IsValidPrice,
                        IsValidProduct = streamingCall.ResponseStream.Current.IsValidProduct,
                        MessageType = streamingCall.ResponseStream.Current.MessageType,
                        OrderPrice = streamingCall.ResponseStream.Current.OrderPrice,
                        PartDescription = streamingCall.ResponseStream.Current.PartDescription,
                        PartNumber = streamingCall.ResponseStream.Current.PartNumber,
                        Quantity = streamingCall.ResponseStream.Current.Quantity,
                        TotalInvoicePrice = streamingCall.ResponseStream.Current.TotalInvoicePrice,
                        Status = (EdiInvoiceStatus)System.Enum.Parse(typeof(EdiInvoiceStatus), streamingCall.ResponseStream.Current.Status),

                    };

                }
            #endregion

            #region TEST FOR UNARY CALL
            //for (var i = 0; i < 10; i++)
            //{
            //    // var response = await client.SayHelloAsync(new HelloRequest { Name = $"{i}" });

            //    var response = await client.SayHelloAsync(
            //        new HelloRequest { Name = $"{i}" });

            //    Console.WriteLine(response.Message);
            //    await Task.Delay(2000);
            //}
            #endregion

            #region Local Debug Sample Data
            //await Task.Delay(5000);
            //return new InvoiceInformationResponse
            //{
            //    InvoiceInformation = new List<EdiInvoiceInformationDto>
            //    {
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part1",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis001",
            //            ExchangeRate = 1.0,
            //            FileName = "Test.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = false,
            //            IsValidPrice = false,
            //            IsValidProduct = false,
            //            MessageType = "ASN",
            //            OrderPrice = -1.0,
            //            PartDescription = "A Part",
            //            PartNumber = "Part1",
            //            Quantity = 25,
            //            Status = EdiInvoiceStatus.MissingPrice,

            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part2",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = false,
            //            IsValidPrice = true,
            //            IsValidProduct = false,
            //            MessageType = "ASN",
            //            OrderPrice = 9.876,
            //            PartDescription = "A Part 2",
            //            PartNumber = "Part2",
            //            Quantity = 25,
            //            Status = EdiInvoiceStatus.MissingPart,
            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part3",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = true,
            //            IsValidPrice = true,
            //            IsValidProduct = true,
            //            MessageType = "ASN",
            //            OrderPrice = 11.276,
            //            PartDescription = "A Part 3",
            //            PartNumber = "Part3",
            //            Quantity = 370,
            //            TotalInvoicePrice = 250000.00,
            //            Status = EdiInvoiceStatus.HeldUp,
            //        },
            //        new EdiInvoiceInformationDto
            //        {
            //            BatchId = "BatchId2",
            //            CurrencyCode = "EUR",
            //            Customer = "A customer",
            //            CustomerDispatchNumber = "A batch no 2",
            //            CustomerLocation = "Somewhere",
            //            CustomerLocationId = Guid.NewGuid(),
            //            CustomerOrderNumber = "xyz",
            //            CustomerPartNumber = "Part4",
            //            DeliveryTerms = "DDP",
            //            DispatchDate = DateTime.Now,
            //            DispatchNumber = "Dis002",
            //            ExchangeRate = 1.0,
            //            FileName = "Test2.csv",
            //            FinanceCode = "40206",
            //            Id = Guid.NewGuid(),
            //            IsAgressoTransferred = false,
            //            IsProcessStarted = false,
            //            IsValid = true,
            //            IsValidPrice = true,
            //            IsValidProduct = true,
            //            MessageType = "ASN",
            //            OrderPrice = 15.973,
            //            PartDescription = "A Part 4",
            //            PartNumber = "Part4",
            //            Quantity = 279,
            //            TotalInvoicePrice = 250000.00,
            //            Status = EdiInvoiceStatus.HeldUp,
            //        }
            //    }
            //};
            #endregion
        }

        public async IAsyncEnumerable<EdiFileDataUploadDto> GetDuplicateInvoiceInformation<T>(string apiPath, T request)
        {
            await Task.Delay(0);
            var client = GetClient();

            #region Unary
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            var unaryCall = await client.GetDuplicateInvoiceInformationAsync(new Empty(), cancellationToken: cts.Token);

            foreach (var result in unaryCall.DuplicateInvoiceInformation)
            {

                yield return new EdiFileDataUploadDto
                {
                    FinanceCode = result.FinanceCode,
                    CustomerPartNumber = result.CustomerPartNumber,
                    FileName = result.FileName,
                    DispatchNumber = result.DispatchNumber,
                    DispatchDate = result.DispatchDate.ToDateTime(),
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
                    UploadDate = result.UploadDate.ToDateTime()
                };

            }
            #endregion
        }

        public async IAsyncEnumerable<EdiFileDataUploadDto> GetDuplicateInvoiceInformationStream<T>(string apiPath, T request)
        {
            await Task.Delay(0);
            var client = GetClient();

            #region Stream

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            using var streamingCall = client.GetDuplicateInvoiceInformationStream(new Empty(), cancellationToken: cts.Token);

            while (await streamingCall.ResponseStream.MoveNext(cancellationToken: cts.Token))
            {
                yield return new EdiFileDataUploadDto
                {
                    FinanceCode = streamingCall.ResponseStream.Current.FinanceCode,
                    CustomerPartNumber = streamingCall.ResponseStream.Current.CustomerPartNumber,
                    FileName = streamingCall.ResponseStream.Current.FileName,
                    DispatchNumber = streamingCall.ResponseStream.Current.DispatchNumber,
                    DispatchDate = streamingCall.ResponseStream.Current.DispatchDate.ToDateTime(),
                    PartNumber = streamingCall.ResponseStream.Current.PartNumber,
                    TotalGrossWeight = streamingCall.ResponseStream.Current.TotalGrossWeight,
                    CustomerDispatchNumber = streamingCall.ResponseStream.Current.CustomerDispatchNumber,
                    CustomerOrderNumber = streamingCall.ResponseStream.Current.CustomerOrderNumber,
                    DeliveryTerms = streamingCall.ResponseStream.Current.DeliveryTerms,
                    ExchangeRate = streamingCall.ResponseStream.Current.ExchangeRate,
                    Id = streamingCall.ResponseStream.Current.Id,
                    Quantity = streamingCall.ResponseStream.Current.Quantity,
                    PartDescription = streamingCall.ResponseStream.Current.PartDescription,
                    UnloadingPoint = streamingCall.ResponseStream.Current.UnloadingPoint,
                    WmsSiteCode = streamingCall.ResponseStream.Current.WmsSiteCode,
                    WmsCustomerCode = streamingCall.ResponseStream.Current.WmsCustomerCode,
                    MessageType = streamingCall.ResponseStream.Current.MessageType,
                    TotalNetWeight = streamingCall.ResponseStream.Current.TotalNetWeight,
                    UnitOfMeasure = streamingCall.ResponseStream.Current.UnitOfMeasure,
                    TariffCode = streamingCall.ResponseStream.Current.TariffCode,
                    TransportDetails = streamingCall.ResponseStream.Current.TransportDetails,
                    WmsInvoiceNumber = streamingCall.ResponseStream.Current.WmsInvoiceNumber,
                    UploadDate = streamingCall.ResponseStream.Current.UploadDate.ToDateTime()
                };
            }
            #endregion
        }

        public async IAsyncEnumerable<EdiCustomerParameterDto> GetAllCustomerParameter<T>(string apiPath, T request)
        {
            await Task.Delay(0);
            var client = GetClient();

            #region Unary
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            var unaryCall = await client.GetEdiCustomerParametersAsync(new Empty(), cancellationToken: cts.Token);

            foreach (var result in unaryCall.EdiCustomerParameterData)
            {

                yield return new EdiCustomerParameterDto
                {
                    Id = Guid.Parse(result.Id),
                    Customer = result.Customer,
                    CustomerLocation = result.CustomerLocation,
                    FinanceCode = result.FinanceCode,
                    Unit4TaxCode = result.Unit4TaxCode,
                    IsAutomatingInvoices = result.IsAutomatingInvoices,
                    IsUsingCustomerDispatchNumber = result.IsUsingCustomerDispatchNumber,
                    IsUsingPartNumber = result.IsUsingPartNumber,
                    IsUsingH1CustomerOrderNumber = result.IsUsingH1CustomerOrderNumber,
                    Unit4OrderIdStatus = (OrderIdStatus)System.Enum.Parse(typeof(OrderIdStatus), result.Unit4OrderIdStatus),
                    Unit4ProductGroup = result.Unit4ProductGroup,
                    Unit4Warehouse = result.Unit4Warehouse,
                    Unit4Client = result.Unit4Client,
                    IsUsingH1SchedulingAgreement = result.IsUsingH1SchedulingAgreement,
                    CustomerGuid = Guid.Parse(result.CustomerGuid),
                    CustomerLocationGuId = Guid.Parse(result.CustomerLocationGuId),
                    AllowZeroPrices = result.AllowZeroPrices,
                    Dim_Value_1 = result.DimValue1,
                    Dim_Value_2 = result.DimValue2,
                    Dim_Value_3 = result.DimValue3,
                    Dim_Value_4 = result.DimValue4,
                    Dim_Value_5 = result.DimValue5,
                    Dim_Value_6 = result.DimValue6,
                    Dim_Value_7 = result.DimValue7,
                    rel_attr_id = result.RelAttrId,
                    rel_attr_id1 = result.RelAttrId1,
                    rel_attr_id2 = result.RelAttrId2,
                    rel_attr_id3 = result.RelAttrId3,
                    rel_attr_id4 = result.RelAttrId4,
                    rel_attr_id5 = result.RelAttrId5,
                    rel_value  = result.RelValue,
                    rel_value1 = result.RelValue1,
                    rel_value2 = result.RelValue2,
                    rel_value3 = result.RelValue3,
                    rel_value4 = result.RelValue4,
                    rel_value5 = result.RelValue5
                };

            }
            #endregion
        }

        public async IAsyncEnumerable<EdiCustomerParameterDto> GetAllCustomerParameterStream<T>(string apiPath, T request)
        {
            await Task.Delay(0);
            var client = GetClient();

            #region Stream

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));
            using var streamingCall = client.GetEdiCustomerParametersStream(new Empty(), cancellationToken: cts.Token);

            while (await streamingCall.ResponseStream.MoveNext(cancellationToken: cts.Token))
            {
                yield return new EdiCustomerParameterDto
                {
                    Id = Guid.Parse(streamingCall.ResponseStream.Current.Id),
                    Customer = streamingCall.ResponseStream.Current.Customer,
                    CustomerLocation = streamingCall.ResponseStream.Current.CustomerLocation,
                    FinanceCode = streamingCall.ResponseStream.Current.FinanceCode,
                    Unit4TaxCode = streamingCall.ResponseStream.Current.Unit4TaxCode,
                    IsAutomatingInvoices = streamingCall.ResponseStream.Current.IsAutomatingInvoices,
                    IsUsingCustomerDispatchNumber = streamingCall.ResponseStream.Current.IsUsingCustomerDispatchNumber,
                    IsUsingPartNumber = streamingCall.ResponseStream.Current.IsUsingPartNumber,
                    IsUsingH1CustomerOrderNumber = streamingCall.ResponseStream.Current.IsUsingH1CustomerOrderNumber,
                    Unit4OrderIdStatus = (OrderIdStatus)System.Enum.Parse(typeof(OrderIdStatus), streamingCall.ResponseStream.Current.Unit4OrderIdStatus),
                    Unit4ProductGroup = streamingCall.ResponseStream.Current.Unit4ProductGroup,
                    Unit4Warehouse = streamingCall.ResponseStream.Current.Unit4Warehouse,
                    Unit4Client = streamingCall.ResponseStream.Current.Unit4Client,
                    IsUsingH1SchedulingAgreement = streamingCall.ResponseStream.Current.IsUsingH1SchedulingAgreement,
                    CustomerGuid = Guid.Parse(streamingCall.ResponseStream.Current.CustomerGuid),
                    CustomerLocationGuId = Guid.Parse(streamingCall.ResponseStream.Current.CustomerLocationGuId),
                    AllowZeroPrices = streamingCall.ResponseStream.Current.AllowZeroPrices,
                    Dim_Value_1 = streamingCall.ResponseStream.Current.DimValue1,
                    Dim_Value_2 = streamingCall.ResponseStream.Current.DimValue2,
                    Dim_Value_3 = streamingCall.ResponseStream.Current.DimValue3,
                    Dim_Value_4 = streamingCall.ResponseStream.Current.DimValue4,
                    Dim_Value_5 = streamingCall.ResponseStream.Current.DimValue5,
                    Dim_Value_6 = streamingCall.ResponseStream.Current.DimValue6,
                    Dim_Value_7 = streamingCall.ResponseStream.Current.DimValue7,
                    rel_attr_id = streamingCall.ResponseStream.Current.RelAttrId,
                    rel_attr_id1 = streamingCall.ResponseStream.Current.RelAttrId1,
                    rel_attr_id2 = streamingCall.ResponseStream.Current.RelAttrId2,
                    rel_attr_id3 = streamingCall.ResponseStream.Current.RelAttrId3,
                    rel_attr_id4 = streamingCall.ResponseStream.Current.RelAttrId4,
                    rel_attr_id5 = streamingCall.ResponseStream.Current.RelAttrId5,
                    rel_value = streamingCall.ResponseStream.Current.RelValue,
                    rel_value1 = streamingCall.ResponseStream.Current.RelValue1,
                    rel_value2 = streamingCall.ResponseStream.Current.RelValue2,
                    rel_value3 = streamingCall.ResponseStream.Current.RelValue3,
                    rel_value4 = streamingCall.ResponseStream.Current.RelValue4,
                    rel_value5 = streamingCall.ResponseStream.Current.RelValue5
                };
            }
            #endregion
        }

        public async Task<bool> SaveAllCustomerParameter<T>(string url, T request)
        {
            throw new NotImplementedException();
        }

        private InvoiceInformationService.InvoiceInformationServiceClient GetClient()
        {
            var handler = new GrpcWebHandler(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (o, c, ch, er) => true
            });

            var httpclient = new HttpClient(handler);

            var chanOps = new GrpcChannelOptions() { HttpClient = httpclient };
            var channel = GrpcChannel.ForAddress("https://tddawdev007.sews-tdd.com:443/", chanOps);
            return new InvoiceInformationService.InvoiceInformationServiceClient(channel);
        }

    }
}
