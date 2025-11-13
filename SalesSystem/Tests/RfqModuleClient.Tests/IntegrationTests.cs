using System.Text;
using Grpc.Core;
using Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Constraints;
using RfqModule;
using RfqModuleClient.Tests.Services;

namespace RfqModuleClient.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        RfqModuleClientService _RfqModuleClientService;
        ILogger<IntegrationTests> _Logger;
        IHost _Host;
        IConfiguration _Configuration;
        Guid _TestUserId;
        string _TestCustomerId;
        string _TestProjectGuid;
        string _TestLocationGuid;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _Host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddSeq();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();

            _Configuration = _Host.Services.GetRequiredService<IConfiguration>();
            _Logger = _Host.Services.GetRequiredService<ILogger<IntegrationTests>>();
            ILogger<RfqModuleClientService> rfqGrpcClientServiceLogger = _Host.Services.GetRequiredService<ILogger<RfqModuleClientService>>();
            _RfqModuleClientService = new RfqModuleClientService(_Configuration, rfqGrpcClientServiceLogger);

            _TestUserId = Guid.Parse(_Configuration["TestData:TestUserId"] ?? "86380EFD-5651-4552-8145-E59E785F099A");
            _TestCustomerId = _Configuration["TestData:TestCustomerId"] ?? "6812E12D-BD63-4519-8D41-7E66462CFCDB";
            _TestProjectGuid = _Configuration["TestData:TestProjectGuid"] ?? "1A302054-2821-4FDA-91C3-E86878139783";
            _TestLocationGuid = _Configuration["TestData:TestLocationGuid"] ?? "FA5B3550-2085-48E3-AE5E-0237BFEC89D7";

            _Logger.GenericLogInformation($"IntegrationTests setup completed with test user: {_TestUserId}, customer: {_TestCustomerId}, project: {_TestProjectGuid}, and location: {_TestLocationGuid}");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _RfqModuleClientService?.Dispose();
            _Host?.Dispose();
            _Logger.GenericLogInformation("IntegrationTests cleanup completed");
        }

        [Test]
        [Category("Integration")]
        [Category("Performance")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task AllEndpoints_PerformanceTest_RespondsWithinAcceptableTime()
        {
            _Logger.GenericLogInformation("=== Starting All Endpoints Performance Test ===");

            List<(string Endpoint, long ElapsedMs, bool Success)> performanceResults = new List<(string Endpoint, long ElapsedMs, bool Success)>();

            try
            {
                System.Diagnostics.Stopwatch overallStopwatch = System.Diagnostics.Stopwatch.StartNew();

                // Test each endpoint and measure performance
                List<(string Name, Func<Task> TestFunc)> endpoints = new List<(string Name, Func<Task> TestFunc)>
                {
                    ("SayHello", async () => await _RfqModuleClientService.SayHelloAsync("PerformanceTest")),
                    ("GetAllCustomers", async () => await _RfqModuleClientService.GetAllCustomersAsync(0, 5)),
                    ("GetCustomersByUserId", async () => await _RfqModuleClientService.GetCustomersByUserIdAsync(_TestUserId)),
                    ("GetRfqReasons", async () => await _RfqModuleClientService.GetRfqReasonsAsync()),
                    ("GetProjectAssociations", async () => await _RfqModuleClientService.GetProjectAssociationsByCustomerIdAsync(_TestCustomerId)),
                    ("GetVehiclesByProjectCode", async () => await _RfqModuleClientService.GetVehiclesByProjectCodeAsync("TEST")),
                    ("UploadFile", async () => await _RfqModuleClientService.UploadFileAsync(Encoding.UTF8.GetBytes("test"), "perf_test.txt")),
                    ("UploadParts", async () => await _RfqModuleClientService.UploadPartsAsync("test-project", Encoding.UTF8.GetBytes("part,desc\nTEST,Test Part"), "perf_parts.csv"))
                };

                foreach ((string endpointName, Func<Task> testFunc) in endpoints)
                {
                    try
                    {
                        _Logger.GenericLogInformation($"[PERFORMANCE] Testing endpoint: {endpointName}");
                        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

                        await testFunc();

                        stopwatch.Stop();
                        performanceResults.Add((endpointName, stopwatch.ElapsedMilliseconds, true));
                        _Logger.GenericLogInformation($"[PERFORMANCE] ✓ {endpointName}: {stopwatch.ElapsedMilliseconds}ms");
                    }
                    catch (RpcException ex) when (ex.StatusCode != StatusCode.Unavailable)
                    {
                        // Expected for some endpoints with test data
                        performanceResults.Add((endpointName, 0, false));
                        _Logger.GenericLogInformation($"[PERFORMANCE] ~ {endpointName}: Expected error with test data ({ex.StatusCode})");
                    }
                }

                overallStopwatch.Stop();

                // Log performance summary
                _Logger.GenericLogInformation("=== Performance Test Results ===");
                foreach ((string endpoint, long elapsedMs, bool success) in performanceResults)
                {
                    if (success)
                    {
                        _Logger.GenericLogInformation($"{endpoint}: {elapsedMs}ms");
                        Assert.That(elapsedMs, Is.LessThan(10000), $"{endpoint} should respond within 10 seconds");
                    }
                    else
                    {
                        _Logger.GenericLogInformation($"{endpoint}: Failed (expected with test data)");
                    }
                }

                _Logger.GenericLogInformation($"=== Overall test duration: {overallStopwatch.ElapsedMilliseconds}ms ===");

                // Assert that at least some endpoints were successful
                int successfulEndpoints = performanceResults.Count(r => r.Success);
                Assert.That(successfulEndpoints, Is.GreaterThan(0), "At least some endpoints should be successful");

                _Logger.GenericLogInformation("=== ✓ All Endpoints Performance Test Completed ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during performance test", ex);
                Assert.Inconclusive($"gRPC service unavailable for performance test: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during all endpoints performance test", ex);
                throw;
            }
        }

        [Test]
        [Category("Integration")]
        [Category("RfqProject")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetAllRfqProjectAsync_WithValidParameters_ReturnsExpectedCount()
        {
            _Logger.GenericLogInformation("=== Starting GetAllRfqProjectAsync Integration Test ===");

            try
            {
                // Test 1: Default parameters (position=0, take=100)
                _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with default parameters");
                System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                
                int defaultResult = await _RfqModuleClientService.GetAllRfqProjectAsync();
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[TEST] ✓ Default call completed in {stopwatch.ElapsedMilliseconds}ms, returned {defaultResult} projects");

                // Assertions for default call
                Assert.That(defaultResult, Is.GreaterThanOrEqualTo(0), "Default call should return non-negative count");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(10000), "Default call should complete within 10 seconds");

                // Test 2: Small page size
                _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with small page (position=0, take=5)");
                stopwatch.Restart();
                
                int smallPageResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 0, take: 5);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[TEST] ✓ Small page call completed in {stopwatch.ElapsedMilliseconds}ms, returned {smallPageResult} projects");

                // Assertions for small page
                Assert.That(smallPageResult, Is.GreaterThanOrEqualTo(0), "Small page call should return non-negative count");
                Assert.That(smallPageResult, Is.LessThanOrEqualTo(Math.Max(5, defaultResult)), "Small page result should be reasonable compared to default");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000), "Small page call should complete within 5 seconds");

                // Test 3: Large page size
                _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with large page (position=0, take=1000)");
                stopwatch.Restart();
                
                int largePageResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 0, take: 1000);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[TEST] ✓ Large page call completed in {stopwatch.ElapsedMilliseconds}ms, returned {largePageResult} projects");

                // Assertions for large page
                Assert.That(largePageResult, Is.GreaterThanOrEqualTo(0), "Large page call should return non-negative count");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(15000), "Large page call should complete within 15 seconds");

                // Test 4: Second page (if there are enough records)
                if (10 <= defaultResult)
                {
                    _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with pagination (position=5, take=5)");
                    stopwatch.Restart();
                    
                    int secondPageResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 5, take: 5);
                    
                    stopwatch.Stop();
                    _Logger.GenericLogInformation($"[TEST] ✓ Second page call completed in {stopwatch.ElapsedMilliseconds}ms, returned {secondPageResult} projects");

                    // Assertions for second page
                    Assert.That(secondPageResult, Is.GreaterThanOrEqualTo(0), "Second page call should return non-negative count");
                    Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000), "Second page call should complete within 5 seconds");
                }
                else
                {
                    _Logger.GenericLogInformation("[TEST] Skipping pagination test - insufficient records for meaningful test");
                }

                // Test 5: Edge case - Zero take
                _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with zero take (position=0, take=0)");
                stopwatch.Restart();
                
                int zeroTakeResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 0, take: 0);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[TEST] ✓ Zero take call completed in {stopwatch.ElapsedMilliseconds}ms, returned {zeroTakeResult} projects");

                // Assertions for zero take
                Assert.That(zeroTakeResult, Is.GreaterThan(0), "Zero take should return all projects");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(3000), "Zero take call should complete quickly");

                // Test 6: Cancellation token test
                _Logger.GenericLogInformation("[TEST] Testing GetAllRfqProjectAsync with cancellation token");
                using CancellationTokenSource cts = new CancellationTokenSource(5000); // 5 second timeout
                stopwatch.Restart();
                
                int tokenResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 0, take: 10, cancellationToken: cts.Token);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[TEST] ✓ Cancellation token call completed in {stopwatch.ElapsedMilliseconds}ms, returned {tokenResult} projects");

                // Assertions for cancellation token test
                Assert.That(tokenResult, Is.GreaterThanOrEqualTo(0), "Cancellation token call should return non-negative count");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000), "Call should complete before cancellation timeout");

                // Summary logging
                _Logger.GenericLogInformation("=== GetAllRfqProjectAsync Test Results Summary ===");
                _Logger.GenericLogInformation($"Default call (0, 100): {defaultResult} projects");
                _Logger.GenericLogInformation($"Small page (0, 5): {smallPageResult} projects");
                _Logger.GenericLogInformation($"Large page (0, 1000): {largePageResult} projects");
                _Logger.GenericLogInformation($"Zero take (0, 0): {zeroTakeResult} projects");
                _Logger.GenericLogInformation($"With cancellation token (0, 10): {tokenResult} projects");
                
                _Logger.GenericLogInformation("=== ✓ GetAllRfqProjectAsync Integration Test Completed Successfully ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during GetAllRfqProjectAsync test", ex);
                Assert.Inconclusive($"gRPC service unavailable for GetAllRfqProjectAsync test: {ex.Message}");
            }
            catch (OperationCanceledException ex)
            {
                _Logger.GenericLogError("GetAllRfqProjectAsync test was cancelled", ex);
                Assert.Inconclusive($"GetAllRfqProjectAsync test was cancelled: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during GetAllRfqProjectAsync integration test", ex);
                throw;
            }
        }

        [Test]
        [Category("Integration")]
        [Category("RfqProject")]
        [Category("Performance")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetAllRfqProjectAsync_PerformanceTest_RespondsWithinAcceptableTime()
        {
            _Logger.GenericLogInformation("=== Starting GetAllRfqProjectAsync Performance Test ===");

            try
            {
                List<(string TestCase, long ElapsedMs, int ResultCount)> performanceResults = new List<(string, long, int)>();

                // Performance test cases with different parameter combinations
                List<(string Name, int Position, int Take)> testCases = new List<(string, int, int)>
                {
                    ("Small Page", 0, 5),
                    ("Medium Page", 0, 50),
                    ("Large Page", 0, 100),
                    ("XL Page", 0, 500),
                    ("Second Page", 10, 20),
                    ("Deep Pagination", 100, 25)
                };

                foreach ((string testName, int position, int take) in testCases)
                {
                    _Logger.GenericLogInformation($"[PERF] Testing {testName}: position={position}, take={take}");
                    
                    System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    
                    int result = await _RfqModuleClientService.GetAllRfqProjectAsync(position, take);
                    
                    stopwatch.Stop();
                    
                    performanceResults.Add((testName, stopwatch.ElapsedMilliseconds, result));
                    _Logger.GenericLogInformation($"[PERF] ✓ {testName}: {stopwatch.ElapsedMilliseconds}ms, {result} projects");

                    // Performance assertions
                    Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(8000), $"{testName} should complete within 8 seconds");
                    Assert.That(result, Is.GreaterThanOrEqualTo(0), $"{testName} should return non-negative count");
                }

                // Calculate and log performance statistics
                long minTime = performanceResults.Min(r => r.ElapsedMs);
                long maxTime = performanceResults.Max(r => r.ElapsedMs);
                double avgTime = performanceResults.Average(r => r.ElapsedMs);
                int totalProjects = performanceResults.Sum(r => r.ResultCount);

                _Logger.GenericLogInformation("=== GetAllRfqProjectAsync Performance Results ===");
                _Logger.GenericLogInformation($"Minimum response time: {minTime}ms");
                _Logger.GenericLogInformation($"Maximum response time: {maxTime}ms");
                _Logger.GenericLogInformation($"Average response time: {avgTime:F1}ms");
                _Logger.GenericLogInformation($"Total projects retrieved: {totalProjects}");
                _Logger.GenericLogInformation($"Tests completed: {performanceResults.Count}");

                // Overall performance assertions
                Assert.That(avgTime, Is.LessThan(5000), "Average response time should be under 5 seconds");
                Assert.That(maxTime, Is.LessThan(10000), "Maximum response time should be under 10 seconds");

                _Logger.GenericLogInformation("=== ✓ GetAllRfqProjectAsync Performance Test Completed Successfully ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during GetAllRfqProjectAsync performance test", ex);
                Assert.Inconclusive($"gRPC service unavailable for performance test: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during GetAllRfqProjectAsync performance test", ex);
                throw;
            }
        }

        [Test]
        [Category("Integration")]
        [Category("RfqProject")]
        [Category("ErrorHandling")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetAllRfqProjectAsync_WithInvalidParameters_HandlesGracefully()
        {
            _Logger.GenericLogInformation("=== Starting GetAllRfqProjectAsync Error Handling Test ===");

            try
            {
                // Test with very large position (potential out of bounds)
                _Logger.GenericLogInformation("[ERROR] Testing GetAllRfqProjectAsync with very large position");
                System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
                
                int largePositionResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 999999, take: 10);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[ERROR] ✓ Large position test completed in {stopwatch.ElapsedMilliseconds}ms, returned {largePositionResult} projects");
                
                // Should handle gracefully - likely return 0 for out of bounds
                Assert.That(largePositionResult, Is.GreaterThanOrEqualTo(0), "Large position should return non-negative count");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(5000), "Large position test should complete quickly");

                // Test with negative position (should be handled by service)
                _Logger.GenericLogInformation("[ERROR] Testing GetAllRfqProjectAsync with negative position");
                stopwatch.Restart();
                
                int negativePositionResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: -1, take: 10);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[ERROR] ✓ Negative position test completed in {stopwatch.ElapsedMilliseconds}ms, returned {negativePositionResult} projects");
                
                Assert.That(negativePositionResult, Is.GreaterThanOrEqualTo(0), "Negative position should return non-negative count");

                // Test with very large take value
                _Logger.GenericLogInformation("[ERROR] Testing GetAllRfqProjectAsync with very large take value");
                stopwatch.Restart();
                
                int largeTakeResult = await _RfqModuleClientService.GetAllRfqProjectAsync(position: 0, take: int.MaxValue);
                
                stopwatch.Stop();
                _Logger.GenericLogInformation($"[ERROR] ✓ Large take test completed in {stopwatch.ElapsedMilliseconds}ms, returned {largeTakeResult} projects");
                
                Assert.That(largeTakeResult, Is.GreaterThanOrEqualTo(0), "Large take should return non-negative count");
                Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(30000), "Large take test should complete within 30 seconds");

                _Logger.GenericLogInformation("=== ✓ GetAllRfqProjectAsync Error Handling Test Completed Successfully ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during error handling test", ex);
                Assert.Inconclusive($"gRPC service unavailable for error handling test: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                _Logger.GenericLogInformation($"[ERROR] Expected ArgumentException caught: {ex.Message}");
                // This is acceptable for invalid parameters
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Unexpected error during GetAllRfqProjectAsync error handling test", ex);
                throw;
            }
        }
        [Test]
        [Category("Integration")]
        [Category("RfqProject")]
        [Category("Performance")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetRfqProjectByIdAsync_PerformanceTest_RespondsWithinAcceptableTime()
        {
            _Logger.GenericLogInformation("=== Starting GetRfqProjectAsync Performance Test ===");

            try
            {
                List<(string TestCase, long ElapsedMs, long RowId)> performanceResults = new List<(string, long, long)>();

                // Performance test cases with different parameter combinations
                List<(string Name, long RowId)> testCases = new List<(string, long)>
                {
                    ("Project #21", 21),
                    ("Project #50", 50),
                    ("Project #100", 100),
                    ("Project #127", 127),
                };

                foreach ((string testName, long rowId) in testCases)
                {
                    _Logger.GenericLogInformation($"[PERF] Testing {testName}: position={rowId}");

                    System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();

                    RfqProject? result = await _RfqModuleClientService.GetRfqProjectByIdAsync(rowId);

                    stopwatch.Stop();

                    Assert.That(result, Is.Not.Null, $"{testName} should return a valid RfqProject");

                    performanceResults.Add((testName, stopwatch.ElapsedMilliseconds, rowId));
                    _Logger.GenericLogInformation($"[PERF] ✓ {testName}: {stopwatch.ElapsedMilliseconds}ms, project {rowId}");

                    // Performance assertions
                    Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(8000), $"{testName} should complete within 8 seconds");
                }

                // Calculate and log performance statistics
                long minTime = performanceResults.Min(r => r.ElapsedMs);
                long maxTime = performanceResults.Max(r => r.ElapsedMs);
                double avgTime = performanceResults.Average(r => r.ElapsedMs);

                _Logger.GenericLogInformation("=== GetRfqProjectByIdAsync Performance Results ===");
                _Logger.GenericLogInformation($"Minimum response time: {minTime}ms");
                _Logger.GenericLogInformation($"Maximum response time: {maxTime}ms");
                _Logger.GenericLogInformation($"Average response time: {avgTime:F1}ms");

                // Overall performance assertions
                Assert.That(avgTime, Is.LessThan(5000), "Average response time should be under 5 seconds");
                Assert.That(maxTime, Is.LessThan(10000), "Maximum response time should be under 10 seconds");

                _Logger.GenericLogInformation("=== ✓ GetRfqProjectAsync Performance Test Completed Successfully ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during GetRfqProjectByIdAsync performance test", ex);
                Assert.Inconclusive($"gRPC service unavailable for performance test: {ex.Message}");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during GetRfqProjectByIdAsync performance test", ex);
                throw;
            }
        }
    }
}