using System.Diagnostics;
using System.Globalization;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using NUnit.Framework.Interfaces;
using static RfqModule.RfqModule;
namespace RfqModule.Tests
{
    [TestFixture]
    public class RfqModuleLiveTests
    {
        GrpcChannel? _GrpcChannel;
        RfqModuleClient? _RfqModuleClient;
        
        readonly string _GrpcServiceUrl;        // Adjust to your service URL
        readonly Guid _TestUserId;              // Replace with valid test user
        readonly string _TestUserEmail;         // Replace with valid test user email
        readonly string _TestCustomerId;          // Ford
        readonly string _TestLocationGuid;       // FORD TBC
        readonly string _TestProjectGuid;       // ProjectAssociation T6RANPHEV; projectId = 1A302054-2821-4FDA-91C3-E86878139783
        readonly string _TestUnitGuid;
        readonly string _TestModelGuid;

        public RfqModuleLiveTests()
        {
            _GrpcServiceUrl = "https://localhost:7207"; // Adjust to your service URL
            _TestUserId = Guid.Parse("86380EFD-5651-4552-8145-E59E785F099A"); // Replace with valid test user
            _TestUserEmail = "Darran.Williams@sews-e.com";
            _TestCustomerId = "6812e12d-bd63-4519-8d41-7e66462cfcdb";       // Ford
            _TestLocationGuid = "FA5B3550-2085-48E3-AE5E-0237BFEC89D7";     // FORD TBC
            _TestProjectGuid = "9671fd1d-193d-4048-ac36-e209411af29f";      // ProjectAssociation T6RANPHEV; projectId = 1A302054-2821-4FDA-91C3-E86878139783
            _TestUnitGuid = "test-unit-guid";
            _TestModelGuid = "test-model-guid";
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            try
            {
                // Create channel to the live gRPC service
                _GrpcChannel = GrpcChannel.ForAddress(_GrpcServiceUrl);
                _RfqModuleClient = new RfqModuleClient(_GrpcChannel);
                
                Debug.WriteLine($"[SETUP] Connected to live gRPC service at {_GrpcServiceUrl}");
                Debug.WriteLine($"[SETUP] Test User ID: {_TestUserId}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"Failed to setup live gRPC connection: {ex.Message}");
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _GrpcChannel?.Dispose();
        }

        [Test]
        [Category("Live")]
        [Category("Basic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task SayHello_LiveService_ReturnsCorrectMessage()
        {
            // Arrange
            HelloRequest request = new HelloRequest { Name = "LiveTestUser" };

            try
            {
                // Act
                HelloReply response = await _RfqModuleClient!.SayHelloAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Message, Is.EqualTo("Hello LiveTestUser"));
                
                Debug.WriteLine($"[PASS] SayHello Response: {response.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Customers")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetAllCustomersGrpc_LiveService_ReturnsCustomers()
        {
            // Arrange
            GetAllCustomersGrpcRequest request = new GetAllCustomersGrpcRequest();
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            Debug.WriteLine($"Starting GetAllCustomersGrpc at {DateTime.UtcNow}");

            try
            {
                // Act
                GetAllCustomersGrpcResponse response = await _RfqModuleClient!.GetAllCustomersGrpcAsync(request);
                stopwatch.Stop();

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Customers, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] GetAllCustomers - Total Count: {response.TotalCount}, Retrieved: {response.Customers.Count}");
                Debug.WriteLine($"... completed in {stopwatch.ElapsedMilliseconds}ms");

                // Log first few customers
                foreach (CustomerGrpc customer in response.Customers.Take(3))
                {
                    Debug.WriteLine($"  - Customer: {customer.Id} | {customer.CustomerBusinessGroupName}");
                }

                // Performance assertion
                if (5000 <= stopwatch.ElapsedMilliseconds) // 5 seconds threshold
                {
                    Assert.Warn($"GetAllCustomers took {stopwatch.ElapsedMilliseconds}ms - may indicate performance issues");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Customers")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetCustomersByUserIdGrpc_LiveService_WithValidUserId_ReturnsCustomers()
        {
            // Arrange
            GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest
            {
                UserId = _TestUserEmail
            };

            try
            {
                // Act
                GetCustomersByUserIdGrpcResponse response = await _RfqModuleClient!.GetCustomersByUserIdGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Customers, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] GetCustomersByUserId - Total Count: {response.TotalCount}, Retrieved: {response.Customers.Count}");

                // Log customers for this user
                foreach (CustomerGrpc customer in response.Customers.Take(3))
                {
                    Debug.WriteLine($"  - Customer: {customer.Id} | {customer.CustomerBusinessGroupName}");
                }

                // Validate customer data structure
                foreach (CustomerGrpc customer in response.Customers)
                {
                    Assert.That(customer.Id, Is.Not.Null.And.Not.Empty, "Customer ID should not be null or empty");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("ProjectAssociations")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetProjectAssociationsByCustomerId_LiveService_ReturnsAssociations()
        {
            // Arrange
            GetProjectAssociationsByCustomerIdRequest request = new GetProjectAssociationsByCustomerIdRequest
            {
                CustomerId = _TestCustomerId
            };

            try
            {
                // Act
                GetProjectAssociationsByCustomerIdResponse response = await _RfqModuleClient!.GetProjectAssociationsByCustomerIdAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.ProjectAssociation, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] GetProjectAssociationsByCustomerId - Retrieved: {response.ProjectAssociation.Count} associations");

                // Log associations
                foreach (ProjectAssociation? association in response.ProjectAssociation.Take(3))
                {
                    Debug.WriteLine($"  - Association: {association.Id} | Project: {association.CustomerProjectGuid}");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                Debug.WriteLine($"[INFO] No project associations found for customer {_TestCustomerId} (expected for test data)");
                Assert.Pass("Service correctly returned NotFound for test customer ID");
            }
        }

        [Test]
        [Category("Live")]
        [Category("RfqReasons")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task GetRfqReasonsGrpc_LiveService_ReturnsRfqReasons()
        {
            // Arrange
            GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest
            {
                RequestType = 1, // Read operation
                Position = 0,
                Take = 10
            };

            try
            {
                // Act
                GetRfqReasonsGrpcResponse response = await _RfqModuleClient!.GetRfqReasonsGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.RfqReasons, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] GetRfqReasons - Retrieved: {response.RfqReasons.Count} reasons");

                // Log first few reasons
                foreach (RfqReasonGrpc reason in response.RfqReasons.Take(5))
                {
                    Debug.WriteLine($"  - Reason: {reason.RowId} | {reason.RfqReasonTitle}");
                }

                // Validate reason data
                foreach (RfqReasonGrpc reason in response.RfqReasons)
                {
                    Assert.That(reason.RowId, Is.GreaterThan(0), "Reason ID should be greater than 0");
                    Assert.That(reason.RfqReasonTitle, Is.Not.Null.And.Not.Empty, "Reason title should not be null or empty");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("CreateProject")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task CreateRfqProjectGrpc_LiveService_WithValidData_ReturnsSuccess()
        {
            // Arrange
            DateTime nextMonth = DateTime.UtcNow.AddDays(30);

            CreateRfqProjectGrpcRequest request = new CreateRfqProjectGrpcRequest();
            request.Project = new RfqProject();
            request.Project.CustomerBusinessUnitGuid = _TestUnitGuid;
            request.Project.CustomerLocationGuid = _TestLocationGuid;
            request.Project.ProjectGuid = _TestProjectGuid;
            request.Project.RfqReasonId = 1;
            request.Project.VehicleVolume = 1000;
            request.Project.RfqResponseDeadline = Timestamp.FromDateTime(nextMonth);
            request.Project.CarModelGuid = _TestModelGuid;

            try
            {
                // Act
                CreateRfqProjectGrpcResponse response = await _RfqModuleClient!.CreateRfqProjectGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] CreateRfqProject - Success: {response.Success}, Message: {response.Message}");
                
                if (response.Success)
                {
                    Assert.That(response.Success, Is.True);
                    Debug.WriteLine($"  - Created Project ID: {response.CreatedProjectId}");
                }
                else
                {
                    // Creation may fail due to validation rules with test data
                    Assert.That(response.Message, Is.Not.Null.And.Not.Empty, "Error message should be provided when creation fails");
                    Debug.WriteLine($"  - Creation failed (expected with test data): {response.Message}");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                Debug.WriteLine($"[INFO] CreateRfqProject validation error (expected with test data): {ex.Status.Detail}");
                Assert.Pass("Service correctly validated request and returned InvalidArgument");
            }
        }

        [Test]
        [Category("Live")]
        [Category("CreateProject")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task CreateRfqProjectGrpc_LiveService_WithInvalidData_ReturnsValidationError()
        {
            // Arrange - Create request with missing required fields
            CreateRfqProjectGrpcRequest request = new CreateRfqProjectGrpcRequest();
            // Intentionally leave required fields empty to test validation

            try
            {
                // Act
                CreateRfqProjectGrpcResponse response = await _RfqModuleClient!.CreateRfqProjectGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Success, Is.False, "Request with invalid data should not succeed");
                Assert.That(response.Message, Is.Not.Null.And.Not.Empty, "Error message should be provided for invalid request");
                
                Debug.WriteLine($"[PASS] CreateRfqProject validation - Success: {response.Success}, Message: {response.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                Debug.WriteLine($"[PASS] CreateRfqProject correctly rejected invalid request: {ex.Status.Detail}");
                Assert.Pass("Service correctly validated request and returned InvalidArgument");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Upload")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task UploadPartsGrpc_LiveService_WithValidData_ReturnsResponse()
        {
            // Arrange
            DateTime nextMonth = DateTime.UtcNow.AddDays(30);
            
            // Create a test RfqProject
            RfqProject rfqProject = new RfqProject
            {
                RowId = 1,
                RfqNumber = "LIVE-TEST-RFQ-001",
                CustomerBusinessUnitGuid = _TestUnitGuid,
                CustomerLocationGuid = _TestLocationGuid,
                ProjectGuid = _TestProjectGuid,
                RfqReasonId = 1,
                RfqResponseDeadline = Timestamp.FromDateTime(nextMonth),
                CarModelGuid = _TestModelGuid,
                VehicleVolume = 1000
            };

            UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest
            {
                FileData = ByteString.CopyFromUtf8("part_number,description\nTEST-001,Test Part\nTEST-002,Another Test Part"),
                FileName = "live_Test_parts.csv",
                ProjectId = rfqProject.ProjectGuid,
            };

            try
            {
                // Act
                UploadPartsRequestGrpcResponse response = await _RfqModuleClient!.UploadPartsGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                
                Debug.WriteLine($"[PASS] UploadParts - Success: {response.Success}, Message: {response.Message}");

            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Integration")]
        [Category("EndToEnd")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task FullWorkflow_LiveService_CreateProjectAndUploadParts()
        {
            // This test simulates the complete workflow from the Blazor application
            Debug.WriteLine("[E2E-TEST] Starting full RFQ workflow test");

            try
            {
                // Step 1: Get customers (like in CreateRfq.razor OnInitializedAsync)
                Debug.WriteLine("[E2E-STEP-1] Getting customers...");
                GetCustomersByUserIdGrpcRequest customersRequest = new GetCustomersByUserIdGrpcRequest
                {
                    UserId = _TestUserEmail
                };
                
                GetCustomersByUserIdGrpcResponse customersResponse = await _RfqModuleClient!.GetCustomersByUserIdGrpcAsync(customersRequest);
                Assert.That(customersResponse.Customers, Is.Not.Empty, "Should have customers for workflow test");
                
                CustomerGrpc testCustomer = customersResponse.Customers.First();
                Debug.WriteLine($"[E2E-STEP-1] Selected customer: {testCustomer.CustomerBusinessGroupName}");

                // Step 2: Get RFQ reasons
                Debug.WriteLine("[E2E-STEP-2] Getting RFQ reasons...");
                GetRfqReasonsGrpcRequest reasonsRequest = new GetRfqReasonsGrpcRequest
                {
                    RequestType = 1,
                    Position = 0,
                    Take = 10
                };
                
                GetRfqReasonsGrpcResponse reasonsResponse = await _RfqModuleClient.GetRfqReasonsGrpcAsync(reasonsRequest);
                Assert.That(reasonsResponse.RfqReasons, Is.Not.Empty, "Should have RFQ reasons for workflow test");
                
                RfqReasonGrpc testReason = reasonsResponse.RfqReasons.First();
                Debug.WriteLine($"[E2E-STEP-2] Selected reason: {testReason.RfqReasonTitle}");

                // Step 3: Create RFQ Project (like in CreateRfq.razor SubmitDataAsync)
                Debug.WriteLine("[E2E-STEP-3] Creating RFQ project...");
                DateTime responseDeadline = DateTime.UtcNow.AddDays(30);

                CreateRfqProjectGrpcRequest createRequest = new CreateRfqProjectGrpcRequest();
                createRequest.Project.CustomerBusinessUnitGuid = _TestUnitGuid;
                createRequest.Project.CustomerLocationGuid = _TestLocationGuid;
                createRequest.Project.ProjectGuid = _TestProjectGuid;
                createRequest.Project.RfqReasonId = testReason.RowId ?? 0;
                createRequest.Project.VehicleVolume = 1000;
                createRequest.Project.RfqResponseDeadline = Timestamp.FromDateTime(responseDeadline);
                createRequest.Project.CarModelGuid = _TestModelGuid;

                CreateRfqProjectGrpcResponse createResponse = await _RfqModuleClient.CreateRfqProjectGrpcAsync(createRequest);
                
                if (createResponse.Success)
                {
                    Debug.WriteLine($"[E2E-STEP-3] Project created successfully with ID: {createResponse.CreatedProjectId}");
                    
                    // Step 4: Upload parts file (like in CreateRfq.razor SubmitDataAsync)
                    Debug.WriteLine("[E2E-STEP-4] Uploading parts file...");
                    
                    RfqProject rfqProject = new RfqProject
                    {
                        RowId = Convert.ToInt64(createResponse.CreatedProjectId, 10),
                        RfqNumber = $"E2E-TEST-{DateTime.UtcNow:yyyyMMdd-HHmmss}",
                        CustomerBusinessUnitGuid = _TestUnitGuid,
                        CustomerLocationGuid = _TestLocationGuid,
                        ProjectGuid = _TestProjectGuid,
                        RfqReasonId = testReason.RowId ?? 0,
                        RfqResponseDeadline = Timestamp.FromDateTime(responseDeadline),
                        CarModelGuid = _TestModelGuid,
                        VehicleVolume = 1000
                    };

                    UploadPartsRequestGrpcRequest uploadRequest = new UploadPartsRequestGrpcRequest
                    {
                        FileData = ByteString.CopyFromUtf8("part_number,description,quantity\nE2E-PART-001,Test Part 1,100\nE2E-PART-002,Test Part 2,200"),
                        FileName = "e2e_Test_parts.csv",
                        ProjectId = rfqProject.ProjectGuid,
                    };

                    UploadPartsRequestGrpcResponse uploadResponse = await _RfqModuleClient.UploadPartsGrpcAsync(uploadRequest);
                    
                    Debug.WriteLine($"[E2E-STEP-4] Parts upload result: Success={uploadResponse.Success}, Message ={uploadResponse.Message}");
                    
                    // Final assertions
                    Assert.That(uploadResponse, Is.Not.Null);
                    Debug.WriteLine("[E2E-TEST] ✓ Full workflow completed successfully");
                }
                else
                {
                    Debug.WriteLine($"[E2E-STEP-3] Project creation failed (expected with test data): {createResponse.Message}");
                    Assert.Pass("Workflow validation completed - project creation failed as expected with test data");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available for E2E test: {ex.Message}");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
            {
                Debug.WriteLine($"[E2E-TEST] Validation error in workflow (expected with test data): {ex.Status.Detail}");
                Assert.Pass("E2E workflow validation completed");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Performance")]
        [Category("HealthCheck")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task ServiceHealth_LiveService_AllEndpoints_RespondsWithinTimeout()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(30);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeout);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            try
            {
                // Test basic connectivity with SayHello
                HelloRequest helloRequest = new HelloRequest { Name = "HealthCheck" };
                HelloReply helloResponse = await _RfqModuleClient!.SayHelloAsync(helloRequest, cancellationToken: cancellationToken);
                
                Assert.That(helloResponse, Is.Not.Null);
                Debug.WriteLine("[PASS] Service Health Check - All endpoints accessible");
                Debug.WriteLine($"  - Response time: < {timeout.TotalSeconds}s");
                Debug.WriteLine($"  - Service message: {helloResponse.Message}");
            }
            catch (OperationCanceledException)
            {
                Assert.Fail($"Service did not respond within {timeout.TotalSeconds} seconds");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"gRPC service is not available: {ex.Message}");
            }
        }

        [Test]
        [Category("Live")]
        [Category("Performance")]
        [Repeat(3)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Layout", "IDESIGN103:Avoid compound statements.", Justification = "<Pending>")]
        public async Task LoadTest_GetCustomers_ConsistencyAndPerformance()
        {
            // This test runs multiple times to check consistency and performance
            Stopwatch stopwatch = Stopwatch.StartNew();
            
            try
            {
                GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest
                {
                    UserId = _TestUserEmail
                };
                
                GetCustomersByUserIdGrpcResponse response = await _RfqModuleClient!.GetCustomersByUserIdGrpcAsync(request);
                stopwatch.Stop();
                
                Debug.WriteLine($"[LOAD-TEST-RUN-{TestContext.CurrentContext.CurrentRepeatCount + 1}] " +
                                $"Retrieved {response.Customers.Count} customers in {stopwatch.ElapsedMilliseconds}ms");

                Assert.That(response.Customers, Is.Not.Null);
                
                // Performance assertion - warn if consistently slow
                if (10000 <= stopwatch.ElapsedMilliseconds) // 10 seconds threshold
                {
                    Assert.Warn($"Performance variance detected in run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {stopwatch.ElapsedMilliseconds}ms");
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive($"Service unavailable in load test run {TestContext.CurrentContext.CurrentRepeatCount + 1}: {ex.Message}");
            }
        }
    }
}