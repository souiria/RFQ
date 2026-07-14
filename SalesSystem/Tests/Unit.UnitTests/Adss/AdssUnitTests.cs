using Adss;
using Adss.Endpoints.GrpcServices;
using Adss.Models;
using Adss.Services;

namespace Unit.Tests.Adss
{
    class AdssUnitTests
    {
        AdssService _AdssService;
        AdssGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            string tempPath = Path.GetTempPath();
            string testId = Guid.NewGuid().ToString("N");
            string folderName = "AdssTests_" + testId;
            string rootPath = Path.Combine(tempPath, folderName);

            Directory.CreateDirectory(rootPath);

             byte[] sampleJpg = new byte[] { 0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0xFF, 0xD9 };
            string jpgFileName = "ABC123.jpg";
            string jpgPath = Path.Combine(rootPath, jpgFileName);
            File.WriteAllBytes(jpgPath, sampleJpg);

            ServiceCollection serviceCollection = new ServiceCollection();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            Mock<IOptions<AdssSettings>> options = new Mock<IOptions<AdssSettings>>();
            AdssSettings settings = new AdssSettings();
            settings.RootPathLocal = rootPath;
            settings.RootPathServer = rootPath;
            options.Setup(o => o.Value).Returns(settings);

            Mock<IHostEnvironment> env = new Mock<IHostEnvironment>();
            string environmentName = Environments.Development;
            env.SetupGet(e => e.EnvironmentName).Returns(environmentName);

            Mock<ILogger<AdssService>> adssLogger = new Mock<ILogger<AdssService>>();
            Mock<ILogger<AdssGrpcService>> grpcLogger = new Mock<ILogger<AdssGrpcService>>();

            _AdssService = new AdssService(options.Object, env.Object, adssLogger.Object);
            _GrpcService = new AdssGrpcService(_AdssService, grpcLogger.Object);
        }

        [Test]
        [Category("Unit")]
        public void SayHelloTest()
        {
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";

            string methodName = nameof(_GrpcService.SayHello);
            ServerCallContext serverCallContext = CreateServerContext(methodName);

            Task<HelloReply> task = _GrpcService.SayHello(request, serverCallContext);
            HelloReply helloReply = task.Result;

            string expected = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(expected);

            Assert.That(task, Is.Not.Null);
            Assert.That(helloReply.Message, equalConstraint);
        }

        #region GetPartImage

        [Test]
        [Category("Unit")]
        public void GetPartImageGrpcTest_Success()
        {
            PartImageRequest request = new PartImageRequest();
            string partNumber = "ABC123";
            request.PartNumber = partNumber;

            string methodName = nameof(_GrpcService.GetPartImage);
            ServerCallContext serverCallContext = CreateServerContext(methodName);

            Task<PartImageReply> task = _GrpcService.GetPartImage(request, serverCallContext);
            PartImageReply reply = task.Result;

            Assert.That(reply, Is.Not.Null);

            string expectedContentType = "image/jpeg";
            EqualConstraint contentTypeConstraint = Is.EqualTo(expectedContentType);
            string actualContentType = reply.ContentType;
            Assert.That(actualContentType, contentTypeConstraint);

            byte[] expectedBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0xFF, 0xD9 };
            ByteString data = reply.Data;
            byte[] actualBytes = data.ToByteArray();

            EqualConstraint bytesConstraint = Is.EqualTo(expectedBytes);
            Assert.That(actualBytes, bytesConstraint);
        }

        #endregion
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