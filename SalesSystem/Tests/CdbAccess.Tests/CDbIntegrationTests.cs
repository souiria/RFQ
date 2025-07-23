using CDb;
using CDb.Endpoints.GrpcServices;
using CDb.Enums;
using CDb.Extensions;
using CDb.Services;
using Grpc.Core;
using Grpc.Core.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace CdbAccess.Tests
{
    public class CDbIntegrationTests
    {
        ICDbAccessService _CDbAccessService;
        CDbGrpcService _GrpcService;

        // create an id for the component
        readonly string _CreateCompositeComponentId;
        readonly string _ReadByIdCompositeCableComponentId;

        public CDbIntegrationTests()
        {
            _CreateCompositeComponentId = "8e020bbc-7fec-4365-b622-7191c52f9dac";
            _ReadByIdCompositeCableComponentId =  "83e2c52d-3728-4ceb-a57b-b9234995b45f";
        }

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            _CDbAccessService = new CDbAccessService(serviceProvider, true);
            Mock<ILogger<CDbGrpcService>> logger = new Mock<ILogger<CDbGrpcService>>();
            _GrpcService = new CDbGrpcService(_CDbAccessService, logger.Object);
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
        // ClipType Tests
        [Test]
        public void GetAllClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
            grpcRequestParameter.BoolValue = true;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(4);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void GetNotActiveClipTypesTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
            grpcRequestParameter.BoolValue = false; // Only not active clip types
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

        }
        [Test]
        public void CreateClipTypeTest()
        {
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            ClipTypeGrpc clip = new ClipTypeGrpc();
            clip.Code = "TESTCLIP";
            clip.Description = "Test Clip";
            clip.IsActive = true;
            request.ClipTypeGrpcsToCreate.Add(clip);
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateClipTypeGrpc));

            Task<CDbCrudGrpcResponse> getClipTypeGrpcReply = _GrpcService.CreateClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply, Is.Not.Null);
            Assert.That(getClipTypeGrpcReply.Result.SaveSuccess, Is.True);

        }
        [Test]
        public void UpdateClipTypeTest()
        {
            // get the one non active clip type
            ClipTypeGrpcRequest request = new ClipTypeGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByIsActive;
            grpcRequestParameter.BoolValue = false; // Only not active clip types
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));

            Task<ListClipTypeGrpc> getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

            ClipTypeGrpc clip = getClipTypeGrpcReply.Result.ClipTypeGrpcs.First();
            // save clip id for later checks
            string clipId = clip.Id;  

            // update the description of the clip type
            request = new ClipTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            clip.Code = "EXECUTE_ORDER_66";
            clip.Description = "Vanquish all the Jedi in the Universe!";
            request.ClipTypeGrpcsToUpdate.Add(clip);
            request.GrpcRequestParameter = grpcRequestParameter;
            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateClipTypeGrpc));

            Task<CDbCrudGrpcResponse> updateClipTypeGrpcReply = _GrpcService.UpdateClipTypeGrpc(request, serverCallContext);
            Assert.That(updateClipTypeGrpcReply, Is.Not.Null);
            Assert.That(updateClipTypeGrpcReply.Result.SaveSuccess, Is.True);

            // read the clip back from the storage, check to see the order was tored properly
            request = new ClipTypeGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue =clipId; // use the saved clip id
            request.GrpcRequestParameter = grpcRequestParameter;
            serverCallContext = CreateServerContext(nameof(_GrpcService.ReadClipTypeGrpc));
             
            getClipTypeGrpcReply = _GrpcService.ReadClipTypeGrpc(request, serverCallContext);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs, Is.Not.Null);
            countConstraint = Is.EqualTo(1);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.Count, countConstraint);

            NUnit.Framework.Constraints.EqualConstraint codeConstraint = Is.EqualTo("EXECUTE_ORDER_66");
            NUnit.Framework.Constraints.EqualConstraint descriptionConstraint = Is.EqualTo("Vanquish all the Jedi in the Universe!");
    
            // check the description of the clip type
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.First().Code, codeConstraint);
            Assert.That(getClipTypeGrpcReply.Result.ClipTypeGrpcs.First().Description, descriptionConstraint);
        }
        // CompositeComponent Tests
        [Test]
        public void GetAllComponentsTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadAll;
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            Task<ListCompositeComponentGrpc> getCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(2);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
        }
        [Test]
        public void GetByComponentSheetNumberCompositeComponentTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadByComponentSheetNumber;
            grpcRequestParameter.IntValue = 90001; // Use a known component sheet number
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            Task<ListCompositeComponentGrpc> getCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);

            // check the name and sheet number of the component
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-001");
            NUnit.Framework.Constraints.EqualConstraint sheetNumberConstraint = Is.EqualTo(90001);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.SheetNumber, sheetNumberConstraint);

            // Cablle specific things $"JCAB-001"
            NUnit.Framework.Constraints.EqualConstraint componentTypeConstraint = Is.EqualTo((int)ComponentType.Cable);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.ComponentType, componentTypeConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.G);
            Assert.That(getCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);        
        }
        [Test]
        public void CreateCompositeComponentTest()
        {

            // create a blue cable composite component
            CompositeComponentGrpc blueCableCompositeComponent = new CompositeComponentGrpc(); // will be a cable and  the component sheet number will be 90003
            ComponentGrpc blueCableBaseComponent = new ComponentGrpc();
            blueCableCompositeComponent.ComponentGrpc = blueCableBaseComponent;
            blueCableCompositeComponent.ComponentGrpc.Id = _CreateCompositeComponentId;
            blueCableCompositeComponent.ComponentGrpc.Name = $"{ComponentType.Cable.GetEnumDescription()}-003";
            blueCableCompositeComponent.ComponentGrpc.ComponentType = (int)ComponentType.Cable;
            blueCableCompositeComponent.ComponentGrpc.SheetNumber = 90003;
            blueCableCompositeComponent.ComponentGrpc.Issue = "A";
            blueCableCompositeComponent.ComponentGrpc.Weight = 0.5;
            blueCableCompositeComponent.ComponentGrpc.Comment = "A standard blue cable used in various applications.";
            blueCableCompositeComponent.ComponentGrpc.ComponentStatus = (int)ComponentStatus.CurrentValid;
            // add specific properties for the cable
            CableGrpc blueCablePartComponent = new CableGrpc();
            blueCableCompositeComponent.CableGrpc = blueCablePartComponent;
            blueCableCompositeComponent.CableGrpc.Id = _CreateCompositeComponentId;
            blueCableCompositeComponent.CableGrpc.WireCount = 8;
            blueCableCompositeComponent.CableGrpc.IsShielded = true;
            blueCableCompositeComponent.CableGrpc.Length = 150;
            blueCableCompositeComponent.CableGrpc.Color = (int)ColorType.B; // Blue

            // persist the component
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Create;
            request.CompositeComponentGrpcsToCreate.Add(blueCableCompositeComponent);
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.CreateCompositeComponentGrpc));

            Task<CDbCrudGrpcResponse> getCompositeComponentGrpcReply = _GrpcService.CreateCompositeComponentGrpc(request, serverCallContext);
            Assert.That(getCompositeComponentGrpcReply, Is.Not.Null);
            Assert.That(getCompositeComponentGrpcReply.Result.SaveSuccess, Is.True);

            // try to read back by id
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _CreateCompositeComponentId; // use the saved component id
            request.GrpcRequestParameter = grpcRequestParameter;
            serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));
            Task<ListCompositeComponentGrpc> readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
            // check the name and sheet number of the component
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-003");
            NUnit.Framework.Constraints.EqualConstraint sheetNumberConstraint = Is.EqualTo(90003);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.SheetNumber, sheetNumberConstraint);
            // blue cable specific things
            NUnit.Framework.Constraints.EqualConstraint componentTypeConstraint = Is.EqualTo((int)ComponentType.Cable);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.ComponentType, componentTypeConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.B);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);

        }
        [Test]
        public void GetByIdCompositeComponentTest()
        {
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ReadByIdCompositeCableComponentId; // Use a known component id, see SampleCDbAccessDataService
            request.GrpcRequestParameter = grpcRequestParameter;
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));

            // try to read back by id
            Task<ListCompositeComponentGrpc> readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);

            // check the name and sheet number of the component
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-001");
            NUnit.Framework.Constraints.EqualConstraint sheetNumberConstraint = Is.EqualTo(90001);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.SheetNumber, sheetNumberConstraint);
            
            // green cable specific things
            NUnit.Framework.Constraints.EqualConstraint componentTypeConstraint = Is.EqualTo((int)ComponentType.Cable);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.ComponentType, componentTypeConstraint);
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.G);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);
        }
        [Test]
        public void UpdateCompositeComponentTest()
        {
            // get the one composite cable component
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ReadByIdCompositeCableComponentId; // Use a known component id, see SampleCDbAccessDataService
            request.GrpcRequestParameter = grpcRequestParameter;

            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));
            Task<ListCompositeComponentGrpc> readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);

            CompositeComponentGrpc compositeCable = readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First();
            // save the component id for later checks
            string componentId = compositeCable.ComponentGrpc.Id;
            
            // update the description of the component
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Update;
            compositeCable.ComponentGrpc.Name = "JCAB-001-UPDATED";
            compositeCable.ComponentGrpc.Comment = "Updated comment for the cable, this cable is now brown";
            compositeCable.CableGrpc.Color = (int)ColorType.BR; // change the color to brown 
            request.CompositeComponentGrpcsToUpdate.Add(compositeCable);
            request.GrpcRequestParameter = grpcRequestParameter;
            serverCallContext = CreateServerContext(nameof(_GrpcService.UpdateCompositeComponentGrpc));
            Task<CDbCrudGrpcResponse> updateCompositeComponentReply = _GrpcService.UpdateCompositeComponentGrpc(request, serverCallContext);
            Assert.That(updateCompositeComponentReply, Is.Not.Null);
            Assert.That(updateCompositeComponentReply.Result.SaveSuccess, Is.True);

            // read the component back from the storage, check to see the order was stored properly
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = componentId; // use the saved component id
            request.GrpcRequestParameter = grpcRequestParameter;
            serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));
             
            readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc
                (request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint nameConstraint = Is.EqualTo("JCAB-001-UPDATED");
            NUnit.Framework.Constraints.EqualConstraint commentConstraint = Is.EqualTo("Updated comment for the cable, this cable is now brown");
            NUnit.Framework.Constraints.EqualConstraint colorConstraint = Is.EqualTo((int)ColorType.BR); // Brown
            // check the name and comment of the component
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Name, nameConstraint);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().ComponentGrpc.Comment, commentConstraint);
            // check the color of the cable
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First().CableGrpc.Color, colorConstraint);
        }
        [Test]
        public void DeleteCompositeComponentTest()
        {
            // get the one composite cable component
            CompositeComponentGrpcRequest request = new CompositeComponentGrpcRequest();
            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = _ReadByIdCompositeCableComponentId; // Use a known component id, see SampleCDbAccessDataService
            request.GrpcRequestParameter = grpcRequestParameter;

            // try to read back by id
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));
            Task<ListCompositeComponentGrpc> readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(1);
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
            CompositeComponentGrpc compositeCable = readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.First();

            // save the component id for later checks
            string componentId = compositeCable.ComponentGrpc.Id;
            
            // delete the component
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.Delete;
            request.CompositeComponentGrpcsToDelete.Add(compositeCable);
            request.GrpcRequestParameter = grpcRequestParameter;
            
            serverCallContext = CreateServerContext(nameof(_GrpcService.DeleteCompositeComponentGrpc));
            Task<CDbCrudGrpcResponse> deleteCompositeComponentReply = _GrpcService.DeleteCompositeComponentGrpc(request, serverCallContext);
            Assert.That(deleteCompositeComponentReply, Is.Not.Null);
            Assert.That(deleteCompositeComponentReply.Result.SaveSuccess, Is.True);
            
            // try to read back by id
            request = new CompositeComponentGrpcRequest();
            grpcRequestParameter = new GrpcRequestParameter();
            grpcRequestParameter.RequestType = (int)RequestType.ReadById;
            grpcRequestParameter.StringValue = componentId; // use the saved component id
            request.GrpcRequestParameter = grpcRequestParameter;
            
            serverCallContext = CreateServerContext(nameof(_GrpcService.ReadCompositeComponentGrpc));
             
            readCompositeComponentGrpcReply = _GrpcService.ReadCompositeComponentGrpc(request, serverCallContext);
            
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs, Is.Not.Null);
            
            countConstraint = Is.EqualTo(0); // should not be found 
            Assert.That(readCompositeComponentGrpcReply.Result.CompositeComponentGrpcs.Count, countConstraint);
        }
        // Private helper method to create a mock ServerCallContext
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
