using GrpcServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using UX.Module.Edi.Core.Dto;
using UX.Module.Edi.Core.Messages.Responses;
using Google.Protobuf.WellKnownTypes;
using UX.Module.Edi.Core.Enums;
using UX.Module.Edi.Core.Messages.Requests;

namespace ConsoleAppTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var request = new InvoiceInformationRequest()
            {
                IsCompressed = false,
                RequestType = InvoiceInformationRequestType.GetAllInvoiceInformation
            };
            await GetAllInvoiceInformation();
            await GetAllInvoiceInformationStream();

            //await foreach (var item in results)
            //{
            //    Console.WriteLine(item.BatchId);
            //}
            
        }

        public static async Task GetAllInvoiceInformation()
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var httpclient = new HttpClient(handler);

            var chanOps = new GrpcChannelOptions() { HttpClient = httpclient };
            var channel = GrpcChannel.ForAddress("https://tddawdev007.sews-tdd.com:443/", chanOps);
            var client = new InvoiceInformationService.InvoiceInformationServiceClient(channel);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));

            var timer = new Stopwatch();
            Console.WriteLine("Starting Standard Timer");
            timer.Start();

            #region Unary

            var unaryCall = client.GetEdiInvoiceInformation(new Empty(), cancellationToken: cts.Token);
            foreach (var result in unaryCall.InvoiceInformationData)
            {
                Console.WriteLine(result.BatchId);
            }

            #endregion

            timer.Stop();
            Console.WriteLine($"Finished Standard Timer: {timer.ElapsedMilliseconds}ms");
            Console.ReadLine();

            

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

        public static async Task GetAllInvoiceInformationStream()
        {
            var handler = new HttpClientHandler();

            handler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var httpclient = new HttpClient(handler);

            var chanOps = new GrpcChannelOptions() { HttpClient = httpclient };
            var channel = GrpcChannel.ForAddress("https://tddawdev007.sews-tdd.com:443/", chanOps);
            var client = new InvoiceInformationService.InvoiceInformationServiceClient(channel);
            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));

            var timer = new Stopwatch();
            Console.WriteLine("Starting Stream Timer");
            timer.Start();

            using var streamingCall = client.GetEdiInvoiceInformationStream(new Empty(), cancellationToken: cts.Token);
            while (await streamingCall.ResponseStream.MoveNext(cancellationToken: cts.Token))
            {
                await Task.Delay(0, cts.Token);
                Console.WriteLine(streamingCall.ResponseStream.Current.BatchId);
            }

            timer.Stop();
            Console.WriteLine($"Finished Stream Timer: {timer.ElapsedMilliseconds}ms");
            Console.ReadLine();
        }



    }
}
