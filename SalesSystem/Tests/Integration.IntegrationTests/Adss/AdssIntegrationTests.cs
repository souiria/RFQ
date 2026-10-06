using Adss;
using Adss.Endpoints.GrpcServices;
using Adss.Models;
using Adss.Services;

namespace Integration.Tests.Adss
{
    public class AdssIntegrationTests
    {
        AdssService _AdssService;
        AdssGrpcService _GrpcService;
        ILoggerFactory _LoggerFactory;

        [SetUp]
        public void Setup()
        {
       
            string tempPath = Path.GetTempPath();
            string testId = Guid.NewGuid().ToString("N");
            string folderName = "AdssIT_" + testId;
            string rootPath = Path.Combine(tempPath, folderName);

            Directory.CreateDirectory(rootPath);

            byte[] sampleJpg = new byte[] { 0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0xFF, 0xD9 };
            string jpgFileName = "ABC123.jpg";
            string jpgPath = Path.Combine(rootPath, jpgFileName);
            File.WriteAllBytes(jpgPath, sampleJpg);

            ServiceCollection services = new ServiceCollection();
            ServiceProvider provider = services.BuildServiceProvider();

            Mock<IOptions<AdssSettings>> options = new Mock<IOptions<AdssSettings>>();
            AdssSettings settings = new AdssSettings();
            settings.RootPathLocal = rootPath;
            settings.RootPathServer = rootPath;
            options.Setup(o => o.Value).Returns(settings);

            Mock<IHostEnvironment> env = new Mock<IHostEnvironment>();
            string environmentName = Environments.Development;
            env.SetupGet(e => e.EnvironmentName).Returns(environmentName);

            _LoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<AdssService> adssLogger = _LoggerFactory.CreateLogger<AdssService>();
            _AdssService = new AdssService(options.Object, env.Object, adssLogger);
            ILogger<AdssGrpcService> grpcLogger = _LoggerFactory.CreateLogger<AdssGrpcService>();
            _GrpcService = new AdssGrpcService(_AdssService,grpcLogger,options.Object);

        }

        [TearDown]
        public void TearDown()
        {
            _LoggerFactory?.Dispose();
          
        }

        // ---------------------------------------------------------------------
        // SayHello
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";

            string methodName = nameof(_GrpcService.SayHello);
            ServerCallContext serverCallContext = CreateServerContext(methodName);

            Task<CommonTypes.HelloReply> helloTask = _GrpcService.SayHello(request, serverCallContext);
            CommonTypes.HelloReply helloReply = helloTask.Result;

            string expected = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(expected);

            Assert.That(helloTask, Is.Not.Null);
            Assert.That(helloReply.Message, equalConstraint);
        }

        // ---------------------------------------------------------------------
        // Adss: GetPartImage (Success)
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void GetPartImage_Success()
        {
            PartImageRequest request = new PartImageRequest();
            string partNumber = "ABC123";
            request.PartNumber = partNumber;

            string methodName = nameof(_GrpcService.GetPartImage);
            ServerCallContext ctx = CreateServerContext(methodName);

            Task<PartImageReply> task = _GrpcService.GetPartImage(request, ctx);
            PartImageReply reply = task.Result;

            Assert.That(reply, Is.Not.Null);

            string expectedContentType = "image/jpeg";
            EqualConstraint contentTypeConstraint = Is.EqualTo(expectedContentType);
            string actualContentType = reply.ContentType;
            Assert.That(actualContentType, contentTypeConstraint);

            // Match the bytes we wrote in Setup
            byte[] expectedBytes = new byte[] { 0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0xFF, 0xD9 };
            ByteString data = reply.Data;
            byte[] actualBytes = data.ToByteArray();

            EqualConstraint bytesConstraint = Is.EqualTo(expectedBytes);
            Assert.That(actualBytes, bytesConstraint);
        }

        // ---------------------------------------------------------------------
        // Adss: GetPartImage (No image -> returns default embedded)
        // ---------------------------------------------------------------------
        [Test]
        [Category("Integration")]
        public void GetPartImage_NoImage_ReturnsDefault()
        {
            PartImageRequest request = new PartImageRequest();
            string partNumber = "NOTFOUND";
            request.PartNumber = partNumber;

            string methodName = nameof(_GrpcService.GetPartImage);
            ServerCallContext ctx = CreateServerContext(methodName);

            Task<PartImageReply> task = _GrpcService.GetPartImage(request, ctx);
            PartImageReply reply = task.Result;

            Assert.That(reply, Is.Not.Null);

            string expectedContentType = "image/jpeg";
            EqualConstraint contentTypeConstraint = Is.EqualTo(expectedContentType);
            string actualContentType = reply.ContentType;
            Assert.That(actualContentType, contentTypeConstraint);
               ByteString data = reply.Data;
            byte[] actualBytes = data.ToByteArray();
            Assert.That(actualBytes, Is.Not.Null);
            Assert.That(actualBytes.Length, Is.Positive);
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
