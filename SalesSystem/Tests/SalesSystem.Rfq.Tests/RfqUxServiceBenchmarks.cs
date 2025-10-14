using SalesSystem.Rfq.Services;
using SalesSystem.Rfq.Tests.Resources;
using BenchmarkDotNet.Attributes;
using Moq;

namespace SalesSystem.Rfq.Tests
{
    [MemoryDiagnoser]
    [SimpleJob(launchCount: 1, warmupCount: 3, iterationCount: 5)]
    public class RfqUxServiceBenchmarks
    {
        RfqUxService _RfqUxService;
        Mock<RfqModule.RfqModule.RfqModuleClient> _MockGrpcClient;
        Guid _TestUserId;

        public RfqUxServiceBenchmarks()
        {
            _MockGrpcClient = new Mock<RfqModule.RfqModule.RfqModuleClient>();
            _RfqUxService = new RfqUxService(_MockGrpcClient.Object);
            _TestUserId = Guid.NewGuid();
        }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // Setup mock responses (similar to timing tests)
            SetupMockResponses();
        }

        void SetupMockResponses()
        {
            RfqModule.GetCustomersByUserIdGrpcResponse customersResponse = new RfqModule.GetCustomersByUserIdGrpcResponse();
            for (int i = 0; i < 100; i++) // Larger dataset for benchmarking
            {
                RfqModule.CustomerGrpc customer = new RfqModule.CustomerGrpc();

                customer.Id = $"customer-{i}";
                customer.CustomerBusinessGroupName = $"Customer Group {i}";
                customer.CustomerBusinessGroupCode = $"CGC{i:000}";
                customer.SEWSEBusinessTeam = $"Team {i % 10}";
                customer.IsActive = true;

                customersResponse.Customers.Add(customer);
            }

            RfqModule.GetCustomersByUserIdGrpcRequest itIsAny = It.IsAny<RfqModule.GetCustomersByUserIdGrpcRequest>();

            _MockGrpcClient
                .Setup(x => x.GetCustomersByUserIdGrpc(itIsAny, null, null, default))
                .Returns(customersResponse);
        }

        [Benchmark]
        public async Task<List<RfqModule.CustomerGrpc>> GetCustomersAsync_Benchmark()
        {
            return await _RfqUxService.GetCustomersAsync(_TestUserId);
        }

        [Benchmark]
        public async Task<List<RfqModule.CustomerLocationGrpc>> GetLocationsByCustomer_Benchmark()
        {
            return await _RfqUxService.GetLocationsByCustomer("test-customer-id");
        }

        [Benchmark]
        public async Task<List<RfqModule.RfqReasonGrpc>> GetReasons_Benchmark()
        {
            return await _RfqUxService.GetReasonsAsync();
        }
    }

    /// <summary>
    /// Test runner for benchmarks - can be used to run benchmarks programmatically
    /// </summary>
    [TestFixture]
    public class BenchmarkRunner
    {
        [Test]
        [Category("Benchmark")]
        [Explicit("Run only when needed for detailed performance analysis")]
        public void RunBenchmarks()
        {
            BenchmarkDotNet.Reports.Summary summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<RfqUxServiceBenchmarks>();        

            // You can add assertions here based on benchmark results if needed
            Assert.That(summary, Is.Not.Null);
            Console.WriteLine(TimingTestMessages.BenchmarkCompleted);
        }
    }
}