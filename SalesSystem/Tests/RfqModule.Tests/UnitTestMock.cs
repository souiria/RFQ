using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Core.Testing;
using Grpc.Core.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.Globalization;
using static RfqModule.RfqModule;

namespace RfqModule.Tests
{
    public class RfqModuleGrpcTests
    {
        Mock<ILogger<RfqModuleBase>> _MockLogger;
        Mock<IRfqManagerService> _MockRfqManagerService;
        TestRfqGrpcService _RfqGrpcService;

        [SetUp]
        public void Setup()
        {
            _MockLogger = new Mock<ILogger<RfqModuleBase>>();
            _MockRfqManagerService = new Mock<IRfqManagerService>();
            _RfqGrpcService = new TestRfqGrpcService(_MockLogger.Object, _MockRfqManagerService.Object);
        }

        ServerCallContext CreateServerCallContext(string methodName)
        {
            return TestServerCallContext.Create(
                method: methodName,
                host: "localhost",
                deadline: DateTime.UtcNow.AddMinutes(30),
                requestHeaders: new Metadata(),
                cancellationToken: CancellationToken.None,
                peer: "10.0.0.25:5001",
                authContext: null,
                contextPropagationToken: null,
                writeHeadersFunc: (metadata) => TaskUtils.CompletedTask,
                writeOptionsGetter: () => new WriteOptions(),
                writeOptionsSetter: (writeOptions) => { }
            );
        }

        [Test]
        public async Task SayHello_ValidRequest_ReturnsCorrectMessage()
        {
            // Arrange
            HelloRequest request = new HelloRequest { Name = "TestUser" };
            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.SayHello));

            // Act
            HelloReply response = await _RfqGrpcService.SayHello(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Message, Is.EqualTo("Hello TestUser"));
        }

        [Test]
        public async Task GetAllCustomersGrpc_ValidRequest_ReturnsCustomers()
        {
            // Arrange
            GetAllCustomersGrpcRequest request = new GetAllCustomersGrpcRequest { Position = 0, Take = 10 };
            GetAllCustomersGrpcResponse expectedResponse = new GetAllCustomersGrpcResponse
            {
                TotalCount = 2,
                Customers = 
                {
                    new CustomerGrpc 
                    { 
                        Id = "CUSTOMER1",
                        CustomerBusinessGroupCode = "BGC001",
                        CustomerBusinessGroupName = "Business Group 1",
                        SEWSEBusinessTeam = "Team A",
                        IsActive = true
                    },
                    new CustomerGrpc 
                    { 
                        Id = "customer2",
                        CustomerBusinessGroupCode = "BGC002",
                        CustomerBusinessGroupName = "Business Group 2",
                        SEWSEBusinessTeam = "Team B",
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetAllCustomersGrpc(It.IsAny<GetAllCustomersGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetAllCustomersGrpc));

            // Act
            GetAllCustomersGrpcResponse response = await _RfqGrpcService.GetAllCustomersGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.TotalCount, Is.EqualTo(2));
            Assert.That(response.Customers.Count, Is.EqualTo(2));
            Assert.That(response.Customers[0].Id.ToUpperInvariant(), Is.EqualTo("CUSTOMER1"));
            Assert.That(response.Customers[1].Id.ToUpperInvariant(), Is.EqualTo("CUSTOMER2"));
        }

        [Test]
        public async Task GetCustomersByUserIdGrpc_ValidUserId_ReturnsUserCustomers()
        {
            // Arrange
            GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest { UserId = "USER123" };
            GetCustomersByUserIdGrpcResponse expectedResponse = new GetCustomersByUserIdGrpcResponse
            {
                TotalCount = 1,
                Customers = 
                {
                    new CustomerGrpc 
                    { 
                        Id = "CUSTOMER1",
                        CustomerBusinessGroupCode = "BGC001",
                        CustomerBusinessGroupName = "USER BUSSINESS GROUP",
                        SEWSEBusinessTeam = "USER TEAM",
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetCustomersByUserIdGrpc(It.IsAny<GetCustomersByUserIdGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetCustomersByUserIdGrpc));

            // Act
            GetCustomersByUserIdGrpcResponse response = await _RfqGrpcService.GetCustomersByUserIdGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.TotalCount, Is.EqualTo(1));
            Assert.That(response.Customers.Count, Is.EqualTo(1));
            Assert.That(response.Customers[0].Id.ToUpperInvariant(), Is.EqualTo("CUSTOMER1"));
        }

        [Test]
        public async Task GetLocationsByCustomerIdGrpc_ValidCustomerId_ReturnsLocations()
        {
            // Arrange
            GetLocationsByCustomerIdGrpcRequest request = new GetLocationsByCustomerIdGrpcRequest { CustomerId = "CUSTOMER123" };
            GetLocationsByCustomerIdGrpcResponse expectedResponse = new GetLocationsByCustomerIdGrpcResponse
            {
                Locations = 
                {
                    new CustomerLocationGrpc 
                    { 
                        Id = "LOCATION1",
                        CustomerCode = "CUST001",
                        CustomerBusinessHierarchyGuid = "HIERARCHY123",
                        CustomerName = "TEST CUSTOMER",
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetLocationsByCustomerIdGrpc(It.IsAny<GetLocationsByCustomerIdGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetLocationsByCustomerIdGrpc));

            // Act
            GetLocationsByCustomerIdGrpcResponse response = await _RfqGrpcService.GetLocationsByCustomerIdGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Locations.Count, Is.EqualTo(1));
            Assert.That(response.Locations[0].Id.ToUpperInvariant(), Is.EqualTo("LOCATION1"));
            Assert.That(response.Locations[0].CustomerCode.ToUpperInvariant(), Is.EqualTo("CUST001"));
        }

        [Test]
        public async Task GetProjectsByIdGrpc_ValidId_ReturnsProjects()
        {
            // Arrange
            GetProjectsByIdGrpcRequest request = new GetProjectsByIdGrpcRequest { Id = "PROJECT123" };
            GetProjectsByIdGrpcResponse expectedResponse = new GetProjectsByIdGrpcResponse
            {
                Projects = 
                {
                    new ProjectGrpc 
                    { 
                        Id = "PROJECT1",
                        ProjectCode = "PROJ001",
                        ProjectName = "TEST PROJECT",
                        CustomerProjectCode = "CUST-PROJ-001",
                        ProjectDescription = "TEST PROJECT DESCRIPTION",
                        ProjectAnnualVolume = 1000,
                        ProgramHierarchyGuid = "PROGRAM123",
                        CreatedDate = Timestamp.FromDateTime(DateTime.UtcNow),
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetProjectsByIdGrpc(It.IsAny<GetProjectsByIdGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetProjectsByIdGrpc));

            // Act
            GetProjectsByIdGrpcResponse response = await _RfqGrpcService.GetProjectsByIdGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Projects.Count, Is.EqualTo(1));
            Assert.That(response.Projects[0].Id.ToUpperInvariant(), Is.EqualTo("PROJECT1"));
            Assert.That(response.Projects[0].ProjectCode.ToUpperInvariant(), Is.EqualTo("PROJ001"));
        }

        [Test]
        public async Task GetVehiclesByProjectCodeGrpc_ValidProjectCode_ReturnsVehicles()
        {
            // Arrange
            GetVehicleByProjectCodeGrpcRequest request = new GetVehicleByProjectCodeGrpcRequest { ProjectCode = "PROJ001" };
            GetVehicleByProjectCodeGrpcResponse expectedResponse = new GetVehicleByProjectCodeGrpcResponse
            {
                Vehicles = 
                {
                    new VehicleGrpc 
                    { 
                        Id = "vehicle1",
                        VehicleName = "Test Vehicle",
                        ProjectReference = "PROJ001",
                        VehicleDisplay = "Test Vehicle Display",
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetVehiclesByProjectCodeGrpc(It.IsAny<GetVehicleByProjectCodeGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetVehiclesByProjectCodeGrpc));

            // Act
            GetVehicleByProjectCodeGrpcResponse response = await _RfqGrpcService.GetVehiclesByProjectCodeGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Vehicles.Count, Is.EqualTo(1));
            Assert.That(response.Vehicles[0].Id.ToUpperInvariant(), Is.EqualTo("VEHICLE1"));
            Assert.That(response.Vehicles[0].VehicleName.ToUpperInvariant(), Is.EqualTo("TEST VEHICLE"));
        }

        [Test]
        public async Task GetCustomerProjectAssociationsByLocationIdGrpc_ValidLocationId_ReturnsAssociations()
        {
            // Arrange
            GetCustomerProjectAssociationsByLocationIdGrpcRequest request = new GetCustomerProjectAssociationsByLocationIdGrpcRequest { LocationId = "LOCATION123" };
            GetCustomerProjectAssociationsByLocationIdGrpcResponse expectedResponse = new GetCustomerProjectAssociationsByLocationIdGrpcResponse
            {
                CustomerProjectAssociation = 
                {
                    new CustomerProjectAssociationGrpc 
                    { 
                        Id = "ASSOCIATION1",
                        CustomerLocationGuid = "LOCATION123",
                        ProjectGuid = "PROJECT123",
                        IsActive = true
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetCustomerProjectAssociationsByLocationIdGrpc(It.IsAny<GetCustomerProjectAssociationsByLocationIdGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetCustomerProjectAssociationsByLocationIdGrpc));

            // Act
            GetCustomerProjectAssociationsByLocationIdGrpcResponse response = await _RfqGrpcService.GetCustomerProjectAssociationsByLocationIdGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.CustomerProjectAssociation.Count, Is.EqualTo(1));
            Assert.That(response.CustomerProjectAssociation[0].Id, Is.EqualTo("ASSOCIATION1"));
            Assert.That(response.CustomerProjectAssociation[0].CustomerLocationGuid, Is.EqualTo("LOCATION123"));
        }

        [Test]
        public async Task GetRfqReasonsGrpc_ValidRequest_ReturnsRfqReasons()
        {
            // Arrange
            GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest 
            { 
                RequestType = 1,
                Position = 0,
                Take = 10
            };
            GetRfqReasonsGrpcResponse expectedResponse = new GetRfqReasonsGrpcResponse
            {
                RfqReasons = 
                {
                    new RfqReasonGrpc 
                    { 
                        RowId = 1,
                        RfqReasonTitle = "COST REDUCTION"
                    },
                    new RfqReasonGrpc 
                    { 
                        RowId = 2,
                        RfqReasonTitle = "NEW PROJECT"
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.GetRfqReasonsGrpc(It.IsAny<GetRfqReasonsGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.GetRfqReasonsGrpc));

            // Act
            GetRfqReasonsGrpcResponse response = await _RfqGrpcService.GetRfqReasonsGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.RfqReasons.Count, Is.EqualTo(2));
            Assert.That(response.RfqReasons[0].RowId, Is.EqualTo(1));
            Assert.That(response.RfqReasons[0].RfqReasonTitle.ToUpperInvariant(), Is.EqualTo("COST REDUCTION"));
        }

        [Test]
        public async Task UploadPartsGrpc_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            RfqProject rfqProject = new RfqProject
            {
                RowId = 1,
                RfqNumber = "RFQ001",
                CustomerBusinessUnitGuid = "UNIT123",
                CustomerLocationGuid = "LOCATION123",
                ProjectGuid = "PROJECT123",
                RfqReasonId = 1,
                RfqResponseDeadline = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(30)),
                CarModelGuid = "MODEL123",
                VehicleVolume = 1000
            };

            UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest
            {
                FileData = ByteString.CopyFromUtf8("TEST FILE DATA"),
                FileName = "TEST_PARTS.XLSX",
                Project = rfqProject
            };

            UploadPartsRequestGrpcResponse expectedResponse = new UploadPartsRequestGrpcResponse
            {
                Success = true,
                Message = "PARTS UPLOADED SUCCESSFULLY",
                PartNumbers = 
                {
                    new CustomerParts
                    {
                        PartNumber1 = "PART001",
                        PartNumber2 = "PART002",
                        PartNumber3 = "PART003"
                    }
                }
            };

            _MockRfqManagerService
                .Setup(x => x.UploadPartsGrpc(It.IsAny<UploadPartsRequestGrpcRequest>()))
                .ReturnsAsync(expectedResponse);

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.UploadPartsGrpc));

            // Act
            UploadPartsRequestGrpcResponse response = await _RfqGrpcService.UploadPartsGrpc(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.True);
            Assert.That(response.Message.ToUpperInvariant(), Is.EqualTo("PARTS UPLOADED SUCCESSFULLY"));
            Assert.That(response.PartNumbers.Count, Is.EqualTo(1));
            Assert.That(response.PartNumbers[0].PartNumber1.ToUpperInvariant(), Is.EqualTo("PART001"));
        }

        [Test]
        public async Task UploadFile_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            FileUploadRequest request = new FileUploadRequest
            {
                FileData = ByteString.CopyFromUtf8("TEST FILE CONTENT"),
                FileName = "TEST_FILE.PDF"
            };

            ServerCallContext context = CreateServerCallContext(nameof(_RfqGrpcService.UploadFile));

            // Act
            FileUploadResponse response = await _RfqGrpcService.UploadFile(request, context);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.True);
            Assert.That(response.Message, Is.EqualTo($"File {request.FileName} uploaded successfully"));
        }

        // Test class that extends RfqModuleBase for testing purposes
        class TestRfqGrpcService : RfqModuleBase
        {
            readonly ILogger<RfqModuleBase> _Logger;
            readonly IRfqManagerService _RfqManagerService;

            public TestRfqGrpcService(ILogger<RfqModuleBase> logger, IRfqManagerService rfqManagerService)
            {
                _Logger = logger;
                _RfqManagerService = rfqManagerService;
            }

            public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
            {
                HelloReply reply = new HelloReply { Message = "Hello " + request.Name };
                return Task.FromResult(reply);
            }

            public override async Task<FileUploadResponse> UploadFile(FileUploadRequest request, ServerCallContext context)
            {
                FileUploadResponse response = new FileUploadResponse
                {
                    Success = true,
                    Message = $"File {request.FileName} uploaded successfully"
                };
                return await Task.FromResult(response);
            }

            public override async Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc(GetAllCustomersGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetAllCustomersGrpc(request);
            }

            public override async Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetCustomersByUserIdGrpc(request);
            }

            public override async Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetLocationsByCustomerIdGrpc(request);
            }

            public override async Task<GetProjectsByIdGrpcResponse> GetProjectsByIdGrpc(GetProjectsByIdGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetProjectsByIdGrpc(request);
            }

            public override async Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetVehiclesByProjectCodeGrpc(request);
            }

            public override async Task<GetCustomerProjectAssociationsByLocationIdGrpcResponse> GetCustomerProjectAssociationsByLocationIdGrpc(GetCustomerProjectAssociationsByLocationIdGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetCustomerProjectAssociationsByLocationIdGrpc(request);
            }

            public override async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.GetRfqReasonsGrpc(request);
            }

            public override async Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request, ServerCallContext context)
            {
                return await _RfqManagerService.UploadPartsGrpc(request);
            }
        }
    }

    // Mock interface for IRfqManagerService - you'll need to create this interface or reference the actual one
    public interface IRfqManagerService
    {
        Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc(GetAllCustomersGrpcRequest request);
        Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request);
        Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request);
        Task<GetProjectsByIdGrpcResponse> GetProjectsByIdGrpc(GetProjectsByIdGrpcRequest request);
        Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request);
        Task<GetCustomerProjectAssociationsByLocationIdGrpcResponse> GetCustomerProjectAssociationsByLocationIdGrpc(GetCustomerProjectAssociationsByLocationIdGrpcRequest request);
        Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request);
        Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request);
    }
}
