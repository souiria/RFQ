using Master;
using Master.Endpoints.GrpcServices;
using Master.Services;

namespace Regression.Tests.Master
{
    public class MasterRegressionTests
    {
        MasterAccessService _MasterAccessService;
        MasterGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            _MasterAccessService = new MasterAccessService(provider, true);
            Mock<ILogger<MasterGrpcService>> logger = new Mock<ILogger<MasterGrpcService>>();
            _GrpcService = new MasterGrpcService(_MasterAccessService, logger.Object);
        }

        // ---------------------------------------------------------
        //   SayHello
        // ---------------------------------------------------------
        [Test]
        public async Task RegressionTest_Master_AllEndpoints_FilterOnly_ShouldReturnExpectedResults()
        {
            CommonTypes.HelloRequest helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";
            ServerCallContext helloContext = CreateServerContext(nameof(_GrpcService.SayHello));

            CommonTypes.HelloReply helloResult = await _GrpcService.SayHello(helloRequest, helloContext);
            Assert.That(helloResult.Message == "Hello TestName", Is.True);

            // =========================================================
            // CURRENCY
            // =========================================================

            MastersFilterRequestGrpc currencyFilter = new MastersFilterRequestGrpc();
            currencyFilter.DatabaseList = "CURRENCYGRPC";
            currencyFilter.FilterExpression = "Id != null && Id == \"EC44E5CD-5832-48DD-B5A3-440B5CB49450\"";

            ServerCallContext currencyContext = CreateServerContext(nameof(_GrpcService.FilterMasterDataGrpc));
            MastersFilterResponseGrpc currencyResp = await _GrpcService.FilterMasterDataGrpc(currencyFilter, currencyContext);

            Assert.That(currencyResp.CurrencyGrpcList.CurrencyGrpc.Count == 1, Is.True);
            Assert.That(currencyResp.CurrencyGrpcList.CurrencyGrpc.First().CurrencyName == "TESTNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc currencyFail = new MastersFilterRequestGrpc();
            currencyFail.DatabaseList = "CURRENCYGRPC";
            currencyFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc currencyFailResp = await _GrpcService.FilterMasterDataGrpc(currencyFail, currencyContext);
            Assert.That(currencyFailResp.CurrencyGrpcList.CurrencyGrpc.Count == 0, Is.True);

            // =========================================================
            // CUSTOMER
            // =========================================================

            MastersFilterRequestGrpc customerFilter = new MastersFilterRequestGrpc();
            customerFilter.DatabaseList = "CUSTOMERGRPC";
            customerFilter.FilterExpression = "Id != null && Id == \"04707931-2CFF-4B2C-8FBD-BEF614C6A99A\"";

            MastersFilterResponseGrpc customerResp = await _GrpcService.FilterMasterDataGrpc(customerFilter, currencyContext);
            Assert.That(customerResp.CustomerGrpcList.CustomerGrpc.Count == 1, Is.True);
            Assert.That(customerResp.CustomerGrpcList.CustomerGrpc.First().Id == "04707931-2CFF-4B2C-8FBD-BEF614C6A99A", Is.True);

            // Fail case
            MastersFilterRequestGrpc customerFail = new MastersFilterRequestGrpc();
            customerFail.DatabaseList = "CUSTOMERGRPC";
            customerFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc customerFailResp = await _GrpcService.FilterMasterDataGrpc(customerFail, currencyContext);
            Assert.That(customerFailResp.CustomerGrpcList.CustomerGrpc.Count == 0, Is.True);

            // =========================================================
            // CUSTOMER LOCATION
            // =========================================================

            MastersFilterRequestGrpc custLocFilter = new MastersFilterRequestGrpc();
            custLocFilter.DatabaseList = "CUSTOMERLOCATIONGRPC";
            custLocFilter.FilterExpression = "Id != null && Id == \"3759C3B6-ACEB-475E-9BA3-74F13E441E2D\"";

            MastersFilterResponseGrpc custLocResp = await _GrpcService.FilterMasterDataGrpc(custLocFilter, currencyContext);
            Assert.That(custLocResp.CustomerLocationGrpcList.CustomerLocationGrpc.Count == 1, Is.True);
            Assert.That(custLocResp.CustomerLocationGrpcList.CustomerLocationGrpc.First().CustomerName == "TESTCUSTOMERNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc custLocFail = new MastersFilterRequestGrpc();
            custLocFail.DatabaseList = "CUSTOMERLOCATIONGRPC";
            custLocFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc custLocFailResp = await _GrpcService.FilterMasterDataGrpc(custLocFail, currencyContext);
            Assert.That(custLocFailResp.CustomerLocationGrpcList.CustomerLocationGrpc.Count == 0, Is.True);

            // =========================================================
            // MILESTONE
            // =========================================================

            MastersFilterRequestGrpc milestoneFilter = new MastersFilterRequestGrpc();
            milestoneFilter.DatabaseList = "MILESTONEGRPC";
            milestoneFilter.FilterExpression = "Id != null && Id == \"50365C14-734C-406A-B18E-9A3EFF9E2D17\"";

            MastersFilterResponseGrpc milestoneResp = await _GrpcService.FilterMasterDataGrpc(milestoneFilter, currencyContext);
            Assert.That(milestoneResp.MilestoneGrpcList.MilestoneGrpc.Count == 1, Is.True);
            Assert.That(milestoneResp.MilestoneGrpcList.MilestoneGrpc.First().MilestoneEventName == "TESTMILESTONEEVENTNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc milestoneFail = new MastersFilterRequestGrpc();
            milestoneFail.DatabaseList = "MILESTONEGRPC";
            milestoneFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc milestoneFailResp = await _GrpcService.FilterMasterDataGrpc(milestoneFail, currencyContext);
            Assert.That(milestoneFailResp.MilestoneGrpcList.MilestoneGrpc.Count == 0, Is.True);

            // =========================================================
            // PLATFORM
            // =========================================================

            MastersFilterRequestGrpc platformFilter = new MastersFilterRequestGrpc();
            platformFilter.DatabaseList = "PLATFORMGRPC";
            platformFilter.FilterExpression = "Id != null && Id == \"46711693-0EA4-4F9A-86C1-4973308BF795\"";

            MastersFilterResponseGrpc platformResp = await _GrpcService.FilterMasterDataGrpc(platformFilter, currencyContext);
            Assert.That(platformResp.PlatformGrpcList.PlatformGrpc.Count == 1, Is.True);
            Assert.That(platformResp.PlatformGrpcList.PlatformGrpc.First().PlatformName == "TESTPLATFORMNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc platformFail = new MastersFilterRequestGrpc();
            platformFail.DatabaseList = "PLATFORMGRPC";
            platformFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc platformFailResp = await _GrpcService.FilterMasterDataGrpc(platformFail, currencyContext);
            Assert.That(platformFailResp.PlatformGrpcList.PlatformGrpc.Count == 0, Is.True);

            // =========================================================
            // PROGRAM
            // =========================================================

            MastersFilterRequestGrpc programFilter = new MastersFilterRequestGrpc();
            programFilter.DatabaseList = "PROGRAMGRPC";
            programFilter.FilterExpression = "Id != null && Id == \"AEA9E204-0353-4297-A9FF-BBE75F9B4A93\"";

            MastersFilterResponseGrpc programResp = await _GrpcService.FilterMasterDataGrpc(programFilter, currencyContext);
            Assert.That(programResp.ProgramGrpcList.ProgramGrpc.Count == 1, Is.True);
            Assert.That(programResp.ProgramGrpcList.ProgramGrpc.First().ProgramName == "TESTPROGRAMNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc programFail = new MastersFilterRequestGrpc();
            programFail.DatabaseList = "PROGRAMGRPC";
            programFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc programFailResp = await _GrpcService.FilterMasterDataGrpc(programFail, currencyContext);
            Assert.That(programFailResp.ProgramGrpcList.ProgramGrpc.Count == 0, Is.True);

            // =========================================================
            // PROJECT
            // =========================================================

            MastersFilterRequestGrpc projectFilter = new MastersFilterRequestGrpc();
            projectFilter.DatabaseList = "PROJECTGRPC";
            projectFilter.FilterExpression = "Id != null && Id == \"461616E5-FD7B-491C-9592-8453182E7E72\"";

            MastersFilterResponseGrpc projectResp = await _GrpcService.FilterMasterDataGrpc(projectFilter, currencyContext);
            Assert.That(projectResp.ProjectGrpcList.ProjectGrpc.Count == 1, Is.True);
            Assert.That(projectResp.ProjectGrpcList.ProjectGrpc.First().ProjectName == "TESTPROJECTNAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc projectFail = new MastersFilterRequestGrpc();
            projectFail.DatabaseList = "PROJECTGRPC";
            projectFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc projectFailResp = await _GrpcService.FilterMasterDataGrpc(projectFail, currencyContext);
            Assert.That(projectFailResp.ProjectGrpcList.ProjectGrpc.Count == 0, Is.True);

            // =========================================================
            // VEHICLE
            // =========================================================

            MastersFilterRequestGrpc vehicleFilter = new MastersFilterRequestGrpc();
            vehicleFilter.DatabaseList = "VEHICLEGRPC";
            vehicleFilter.FilterExpression = "Id != null && Id == \"766612A1-5C65-4D17-950D-2841E1888F0B\"";

            MastersFilterResponseGrpc vehicleResp = await _GrpcService.FilterMasterDataGrpc(vehicleFilter, currencyContext);
            Assert.That(vehicleResp.VehicleGrpcList.VehicleGrpc.Count == 1, Is.True);
            Assert.That(vehicleResp.VehicleGrpcList.VehicleGrpc.First().VehicleName == "TESTVEHICLENAME", Is.True);

            // Fail case
            MastersFilterRequestGrpc vehicleFail = new MastersFilterRequestGrpc();
            vehicleFail.DatabaseList = "VEHICLEGRPC";
            vehicleFail.FilterExpression = $"Id != null && Id == \"{Guid.NewGuid()}\"";

            MastersFilterResponseGrpc vehicleFailResp = await _GrpcService.FilterMasterDataGrpc(vehicleFail, currencyContext);
            Assert.That(vehicleFailResp.VehicleGrpcList.VehicleGrpc.Count == 0, Is.True);
        }

        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline;
            deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata;
            metadata = new Metadata();
            ServerCallContext serverCallContext;
            serverCallContext = TestServerCallContext.Create(
                                    method: methodName,
                                    host: "localhost",
                                    deadline: deadline,
                                    requestHeaders: metadata,
                                    cancellationToken: CancellationToken.None,
                                    peer: "10.0.0.25:5001",
                                    authContext: null,
                                    contextPropagationToken: null,
                                    writeHeadersFunc: (headers) => Task.CompletedTask,
                                    writeOptionsGetter: () => new WriteOptions(),
                                    writeOptionsSetter: (writeOptions) => { }
                                );
            return serverCallContext;
        }
    }
}
