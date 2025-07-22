using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;

namespace SFSTests
{
    public class SFSGrpcServiceTests
    {
        SFSAccessService _SfsAccessService;
        SFSGrpcService _GrpcService;
     

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _SfsAccessService = new SFSAccessService(serviceProvider, testing: true);
            CarModelViewGrpc car = new CarModelViewGrpc();
            car.Id = 1;
            car.ModelCode = "Model-X";
            car.ModelName = "X Series";
             car.VehicleName = "Electric-X";
            car.CustCode = "C123";
            car.CuWtKg = 1200.5;
            car.CuBase = 1000.0;
            car.Development = "Dev Phase";
            car.DeliverTo = "Factory 1";
             car.DeliveryPoint = "Dock 2";
            car.FinancialYearOffset = "0";
            car.UpdatedBy = "Tester";
            car.Profile = "Base";
            car.H1Id = "H1X";
            // Create the list wrapper and add your car
            CarModelListViewGrpc carModelList = new CarModelListViewGrpc();
            carModelList.Items.Add(car);

            // Set it using reflection
            _SfsAccessService.GetType()
                .GetField("_CarModelGrpcs", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(_SfsAccessService, carModelList);

            Mock<ILogger<SFSGrpcService>> logger = new Mock<ILogger<SFSGrpcService>>();
            _GrpcService = new SFSGrpcService(_SfsAccessService, logger.Object);
        }
   
        [Test]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);

            string replyString = "Hello TestName";
            NUnit.Framework.Constraints.EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }
        [Test]
        public void GetAllCarModelsTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllCarModels);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();

            Task<CarModelListViewGrpc> resultTask = _GrpcService.GetAllCarModels(request, serverCallContext);

            CarModelListViewGrpc result = resultTask.Result;

            Assert.That(result, Is.Not.Null);

            int carModelCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(carModelCount, countConstraint);
            CarModelViewGrpc carModel = result.Items[0];

            string expectedModelCode = "Model-X";
            string expectedModelName = "X Series";
            string expectedVehicleName = "Electric-X";

            NUnit.Framework.Constraints.EqualConstraint modelCodeConstraint = Is.EqualTo(expectedModelCode);
            NUnit.Framework.Constraints.EqualConstraint modelNameConstraint = Is.EqualTo(expectedModelName);
            NUnit.Framework.Constraints.EqualConstraint vehicleNameConstraint = Is.EqualTo(expectedVehicleName);

            Assert.That(carModel.ModelCode, modelCodeConstraint);
            Assert.That(carModel.ModelName, modelNameConstraint);
            Assert.That(carModel.VehicleName, vehicleNameConstraint);
        }
        [Test]
        public void GetAllProfilesTest()
        {
            string methodName = nameof(_GrpcService.GetAllProfiles);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();

            Task<ProfileListViewGrpc> resultTask = _GrpcService.GetAllProfiles(request, serverCallContext);
            ProfileListViewGrpc result = resultTask.Result;

            Assert.That(result, Is.Not.Null);

            int profileCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(profileCount, countConstraint);

            ProfileViewGrpc profile = result.Items[0];
            string expectedId = "Base";
            string expectedDisplay = "Base";

            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(expectedId);
            NUnit.Framework.Constraints.EqualConstraint displayConstraint = Is.EqualTo(expectedDisplay);

            Assert.That(profile.Id, idConstraint);
            Assert.That(profile.DisplayMember, displayConstraint);
        }

        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                             method: methodName
                                            , host: "localhost"
                                            , deadline: deadline
                                            , requestHeaders: metadata
                                            , cancellationToken: CancellationToken.None
                                            , peer: "10.0.0.25:5001"
                                            , authContext: null
                                            , contextPropagationToken: null
                                            , writeHeadersFunc: (metadata) => Task.CompletedTask
                                            , writeOptionsGetter: () => new WriteOptions()
                                            , writeOptionsSetter: (writeOptions) => { }
                                            );
            return serverCallContext;
        }
    }
}
