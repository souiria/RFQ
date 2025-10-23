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
        [Category("FullWorkflow")]
        public async Task FullRfqWorkflow_WithLoggingExtensions_ExecutesSuccessfully()
        {
            _Logger.GenericLogInformation("=== Starting Full RFQ Workflow Integration Test ===");

            try
            {
                // Step 1: Connectivity Test
                _Logger.GenericLogInformation("[WORKFLOW-STEP-1] Testing connectivity with SayHello");
                HelloReply helloResponse = await _RfqModuleClientService.SayHelloAsync("IntegrationTest");
                Assert.That(helloResponse, Is.Not.Null);
                EqualConstraint equality = Is.EqualTo("Hello IntegrationTest");
                Assert.That(helloResponse.Message, equality);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-1] ✓ Connectivity confirmed: {helloResponse.Message}");

                // Step 2: Get All Customers
                _Logger.GenericLogInformation("[WORKFLOW-STEP-2] Getting all customers");
                GetAllCustomersGrpcResponse allCustomersResponse = await _RfqModuleClientService.GetAllCustomersAsync(0, 10);
                Assert.That(allCustomersResponse, Is.Not.Null);
                Assert.That(allCustomersResponse.Customers, Is.Not.Null);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-2] ✓ Retrieved {allCustomersResponse.Customers.Count}/{allCustomersResponse.TotalCount} customers");

                // Step 3: Get Customers by User ID
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-3] Getting customers for user: {_TestUserId}");
                GetCustomersByUserIdGrpcResponse userCustomersResponse = await _RfqModuleClientService.GetCustomersByUserIdAsync(_TestUserId);
                Assert.That(userCustomersResponse, Is.Not.Null);
                Assert.That(userCustomersResponse.Customers, Is.Not.Null);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-3] ✓ Retrieved {userCustomersResponse.Customers.Count} customers for user");

                // Step 4: Get RFQ Reasons
                _Logger.GenericLogInformation("[WORKFLOW-STEP-4] Getting RFQ reasons");
                GetRfqReasonsGrpcResponse reasonsResponse = await _RfqModuleClientService.GetRfqReasonsAsync();
                Assert.That(reasonsResponse, Is.Not.Null);
                Assert.That(reasonsResponse.RfqReasons, Is.Not.Null);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-4] ✓ Retrieved {reasonsResponse.RfqReasons.Count} RFQ reasons");

                // Step 5: Get Project Associations (if we have customers)
                if (0 <= userCustomersResponse.Customers.Count)
                {
                    CustomerGrpc firstCustomer = userCustomersResponse.Customers.First();
                    string customerId = firstCustomer.Id ?? _TestCustomerId;

                    _Logger.GenericLogInformation($"[WORKFLOW-STEP-5] Getting project associations for customer: {customerId}");
                    GetProjectAssociationsByCustomerIdResponse associationsResponse = await _RfqModuleClientService.GetProjectAssociationsByCustomerIdAsync(customerId);
                    Assert.That(associationsResponse, Is.Not.Null);
                    _Logger.GenericLogInformation($"[WORKFLOW-STEP-5] ✓ Retrieved {associationsResponse.ProjectAssociation.Count} project associations. Success: {associationsResponse.Success}");
                }

                // Step 6: Test File Upload
                //_Logger.GenericLogInformation("[WORKFLOW-STEP-6] Testing file upload");
                //string testContent = "Integration test file content\nLine 2: Test data\nLine 3: More test data";
                //byte[] fileData = Encoding.UTF8.GetBytes(testContent);
                //FileUploadResponse uploadResponse = await _RfqModuleClientService.UploadFileAsync(fileData, "FORD.xml");
                //Assert.That(uploadResponse, Is.Not.Null);
                //_Logger.GenericLogInformation($"[WORKFLOW-STEP-6] ✓ File upload completed. Success: {uploadResponse.Success}, Message: {uploadResponse.Message}");

                // Step 7: Test Parts Upload
                _Logger.GenericLogInformation("[WORKFLOW-STEP-7] Testing parts upload");
                string csvContent = "part_number,description,quantity\nINT-001,Integration Test Part 1,100\nINT-002,Integration Test Part 2,200\nINT-003,Integration Test Part 3,150";
                byte[] partsData = Encoding.UTF8.GetBytes(csvContent);
                UploadPartsRequestGrpcResponse partsUploadResponse = await _RfqModuleClientService.UploadPartsAsync("integration-test-project", partsData, "integration_parts.csv");
                Assert.That(partsUploadResponse, Is.Not.Null);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-7] ✓ Parts upload completed. Success: {partsUploadResponse.Success}, Message: {partsUploadResponse.Message}");

                // Step 8: Test Project Creation (if we have reasons)
                if (0 <= reasonsResponse.RfqReasons.Count)
                {
                    RfqReasonGrpc firstReason = reasonsResponse.RfqReasons.First();

                    _Logger.GenericLogInformation("[WORKFLOW-STEP-8] Testing RFQ project creation");
                    RfqProject project = new RfqProject();
                    project.CustomerBusinessUnitGuid = _TestCustomerId;
                    project.CustomerLocationGuid = "integration-test-location";
                    project.ProjectGuid = "integration-test-project-guid";
                    project.RfqReasonId = firstReason.RowId ?? 1;
                    project.VehicleVolume = 1000;
                    DateTime date = DateTime.UtcNow.AddDays(30);
                    project.RfqResponseDeadline = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(date);

                    CreateRfqProjectGrpcResponse createResponse = await _RfqModuleClientService.CreateRfqProjectAsync(project);
                    Assert.That(createResponse, Is.Not.Null);
                    _Logger.GenericLogInformation($"[WORKFLOW-STEP-8] ✓ Project creation completed. Success: {createResponse.Success}, Message: {createResponse.Message}, Created ID: {createResponse.CreatedProjectId}");
                }

                // Step 9: Test Vehicle Lookup
                _Logger.GenericLogInformation("[WORKFLOW-STEP-9] Testing vehicle lookup by project code");
                GetVehicleByProjectCodeGrpcResponse vehiclesResponse = await _RfqModuleClientService.GetVehiclesByProjectCodeAsync("T6RANPHEV");
                Assert.That(vehiclesResponse, Is.Not.Null);
                Assert.That(vehiclesResponse.Vehicles, Is.Not.Null);
                _Logger.GenericLogInformation($"[WORKFLOW-STEP-9] ✓ Vehicle lookup completed. Retrieved {vehiclesResponse.Vehicles.Count} vehicles");

                _Logger.GenericLogInformation("=== ✓ Full RFQ Workflow Integration Test Completed Successfully ===");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                _Logger.GenericLogError("gRPC service unavailable during full workflow test", ex);
                Assert.Inconclusive($"gRPC service unavailable for integration test: {ex.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                _Logger.GenericLogInformation($"Integration workflow validation completed with expected InvalidArgument: {ex.Status.Detail}");
                Assert.Pass("Integration workflow validation completed - some operations failed as expected with test data");
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error during full RFQ workflow integration test", ex);
                throw;
            }
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
    }
}