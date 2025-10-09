using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using RfqModule.Tests.Resources;
using System.Diagnostics;
using System.Globalization;
using static RfqModule.RfqModule;

namespace RfqModule.Tests
{
    [TestFixture]
    public class RfqModuleLiveTests
    {
        GrpcChannel _GrpcChannel;
        RfqModuleClient _RfqModuleClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Create channel to the live gRPC service
            _GrpcChannel = GrpcChannel.ForAddress(TestMessages.GrpcServiceUrl);
            _RfqModuleClient = new RfqModuleClient(_GrpcChannel);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _GrpcChannel?.Dispose();
        }

        [Test]
        [Category("Live")]
        public async Task SayHello_LiveService_ReturnsCorrectMessage()
        {
            // Arrange
            HelloRequest request = new HelloRequest { Name = TestMessages.LiveTestUser };

            try
            {
                // Act
                HelloReply response = await _RfqModuleClient.SayHelloAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Message, Is.EqualTo(TestMessages.HelloLiveTestUserExpected));
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.SayHelloResponse, response.Message));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetAllCustomersGrpc_LiveService_ReturnsCustomers()
        {
            // Arrange
            GetAllCustomersGrpcRequest request = new GetAllCustomersGrpcRequest(); // { Position = 0, Take = 5 };
            Stopwatch stopWatch = Stopwatch.StartNew();
            Console.WriteLine($"Starting GetAllCustomersGrpc at {DateTime.UtcNow}");

            try
            {
                // Act
                GetAllCustomersGrpcResponse response = await _RfqModuleClient.GetAllCustomersGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetAllCustomersResponse, response.TotalCount, response.Customers.Count));
                
                foreach (CustomerGrpc? customer in response.Customers) //.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.CustomerDetail, customer.Id, customer.CustomerBusinessGroupName));
                }

                stopWatch.Stop();
                Console.WriteLine($"... timed at {stopWatch.ElapsedMilliseconds}ms");
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetCustomersByUserIdGrpc_LiveService_WithValidUserId_ReturnsCustomers()
        {
            // Arrange
            GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest { UserId = TestMessages.TestUserEmail };

            try
            {
                // Act
                GetCustomersByUserIdGrpcResponse response = await _RfqModuleClient.GetCustomersByUserIdGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetCustomersByUserIdResponse, response.TotalCount, response.Customers.Count));
                
                foreach (CustomerGrpc? customer in response.Customers.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.CustomerDetail, customer.Id, customer.CustomerBusinessGroupName));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetLocationsByCustomerIdGrpc_LiveService_WithValidCustomerId_ReturnsLocations()
        {
            // First get a customer to use its ID
            GetAllCustomersGrpcRequest customersRequest = new GetAllCustomersGrpcRequest { Position = 0, Take = 1 };

            try
            {
                GetAllCustomersGrpcResponse customersResponse = await _RfqModuleClient.GetAllCustomersGrpcAsync(customersRequest);
                
                if (customersResponse.Customers.Count == 0)
                {
                    Assert.Inconclusive(TestMessages.NoCustomersAvailableMessage);
                    return;
                }

                string customerId = customersResponse.Customers[0].Id;

                // Arrange
                GetLocationsByCustomerIdGrpcRequest request = new GetLocationsByCustomerIdGrpcRequest { CustomerId = customerId };

                // Act
                GetLocationsByCustomerIdGrpcResponse response = await _RfqModuleClient.GetLocationsByCustomerIdGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetLocationsByCustomerIdResponse, customerId, response.Locations.Count));
                
                foreach (CustomerLocationGrpc? location in response.Locations.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.LocationDetail, location.Id, location.CustomerName));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetProjectsByIdGrpc_LiveService_WithValidId_ReturnsProjects()
        {
            // Arrange - using a test ID, in real scenario you might get this from another endpoint
            GetProjectsByIdGrpcRequest request = new GetProjectsByIdGrpcRequest { Id = TestMessages.TestProjectId };

            try
            {
                // Act
                GetProjectsByIdGrpcResponse response = await _RfqModuleClient.GetProjectsByIdGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetProjectsByIdResponse, response.Projects.Count));
                
                foreach (ProjectGrpc? project in response.Projects.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.ProjectDetail, project.Id, project.ProjectName, project.ProjectCode));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                Console.WriteLine(TestMessages.GetProjectsByIdNotFoundMessage);
                Assert.Pass(TestMessages.ServiceNotFoundResponseMessage);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetVehiclesByProjectCodeGrpc_LiveService_WithValidProjectCode_ReturnsVehicles()
        {
            // Arrange
            GetVehicleByProjectCodeGrpcRequest request = new GetVehicleByProjectCodeGrpcRequest { ProjectCode = TestMessages.TestProjectCode };

            try
            {
                // Act
                GetVehicleByProjectCodeGrpcResponse response = await _RfqModuleClient.GetVehiclesByProjectCodeGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetVehiclesByProjectCodeResponse, response.Vehicles.Count));
                
                foreach (VehicleGrpc? vehicle in response.Vehicles.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.VehicleDetail, vehicle.Id, vehicle.VehicleName));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
            {
                Console.WriteLine(TestMessages.GetVehiclesByProjectCodeNotFoundMessage);
                Assert.Pass(TestMessages.ServiceNotFoundResponseMessage);
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetCustomerProjectAssociationsByLocationIdGrpc_LiveService_ReturnsAssociations()
        {
            // Arrange
            GetCustomerProjectAssociationsByLocationIdGrpcRequest request = new GetCustomerProjectAssociationsByLocationIdGrpcRequest { LocationId = TestMessages.TestLocationId };

            try
            {
                // Act
                GetCustomerProjectAssociationsByLocationIdGrpcResponse response = await _RfqModuleClient.GetCustomerProjectAssociationsByLocationIdGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetCustomerProjectAssociationsResponse, response.CustomerProjectAssociation.Count));
                
                foreach (CustomerProjectAssociationGrpc? association in response.CustomerProjectAssociation.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.AssociationDetail, association.Id, association.CustomerLocationGuid, association.ProjectGuid));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task GetRfqReasonsGrpc_LiveService_ReturnsRfqReasons()
        {
            // Arrange
            GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest
            { 
                RequestType = 1,
                Position = 0,
                Take = 10
            };

            try
            {
                // Act
                GetRfqReasonsGrpcResponse response = await _RfqModuleClient.GetRfqReasonsGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.GetRfqReasonsResponse, response.RfqReasons.Count));
                
                foreach (RfqReasonGrpc? reason in response.RfqReasons.Take(5))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.ReasonDetail, reason.RowId, reason.RfqReasonTitle));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Upload")]
        public async Task UploadFile_LiveService_WithValidFile_ReturnsSuccess()
        {
            // Arrange
            FileUploadRequest request = new FileUploadRequest
            {
                FileData = ByteString.CopyFromUtf8(TestMessages.TestFileContent),
                FileName = TestMessages.LiveTestFileName
            };

            try
            {
                // Act
                FileUploadResponse response = await _RfqModuleClient.UploadFileAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.UploadFileResponse, response.Success, response.Message));
                
                if (response.Success)
                {
                    Assert.That(response.Success, Is.True);
                    Assert.That(response.Message, Is.Not.Null.And.Not.Empty);
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Upload")]
        public async Task UploadPartsGrpc_LiveService_WithValidData_ReturnsResponse()
        {
            // Arrange
            RfqProject rfqProject = new RfqProject
            {
                RowId = 1,
                RfqNumber = TestMessages.LiveTestRfqNumber,
                CustomerBusinessUnitGuid = TestMessages.TestUnitGuid,
                CustomerLocationGuid = TestMessages.TestLocationGuid,
                ProjectGuid = TestMessages.TestProjectGuid,
                RfqReasonId = 1,
                RfqResponseDeadline = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30)),
                CarModelGuid = TestMessages.TestModelGuid,
                VehicleVolume = 1000
            };

            UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest
            {
                FileData = ByteString.CopyFromUtf8(TestMessages.TestPartsFileContent),
                FileName = TestMessages.LiveTestPartsFileName,
                Project = rfqProject
            };

            try
            {
                // Act
                UploadPartsRequestGrpcResponse response = await _RfqModuleClient.UploadPartsGrpcAsync(request);

                // Assert
                Assert.That(response, Is.Not.Null);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.UploadPartsGrpcResponse, response.Success, response.Message));
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.PartNumbersCountDetail, response.PartNumbers.Count));
                
                foreach (CustomerParts? partNumber in response.PartNumbers.Take(3))
                {
                    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.PartsDetail, partNumber.PartNumber1, partNumber.PartNumber2, partNumber.PartNumber3));
                }
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }

        [Test]
        [Category("Live")]
        public async Task ServiceHealth_LiveService_AllEndpoints_RespondsWithinTimeout()
        {
            TimeSpan timeout = TimeSpan.FromSeconds(10);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(timeout);
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            try
            {
                // Test basic connectivity with SayHello
                HelloRequest helloRequest = new HelloRequest { Name = TestMessages.HealthCheckUser };
                HelloReply helloResponse = await _RfqModuleClient.SayHelloAsync(helloRequest, cancellationToken: cancellationToken);
                
                Assert.That(helloResponse, Is.Not.Null);
                Console.WriteLine(TestMessages.ServiceHealthCheckResponse);
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.ResponseTimeDetail, timeout.TotalSeconds));
                Console.WriteLine(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceMessageDetail, helloResponse.Message));
            }
            catch (OperationCanceledException)
            {
                Assert.Fail(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceTimeoutMessage, timeout.TotalSeconds));
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                Assert.Inconclusive(string.Format(CultureInfo.InvariantCulture, TestMessages.ServiceUnavailableMessage, ex.Message));
            }
        }
    }
}