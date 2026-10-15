using Adss;
using Adss.Endpoints.GrpcServices;
using Adss.Models;
using Adss.Services;

namespace Regression.Tests.Adss
{
    public class AdssRegressionTests
    {
        AdssService _AdssService;
        AdssGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            string tempPath = Path.GetTempPath();
            string testId = Guid.NewGuid().ToString("N");
            string folderName = "AdssRegression_" + testId;
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

            Mock<ILogger<AdssService>> adssLoggerMock = new Mock<ILogger<AdssService>>();
            ILogger<AdssService> adssLogger = adssLoggerMock.Object;

            Mock<ILogger<AdssGrpcService>> grpcLoggerMock = new Mock<ILogger<AdssGrpcService>>();
            ILogger<AdssGrpcService> grpcLogger = grpcLoggerMock.Object;

            _AdssService = new AdssService(options.Object, env.Object, adssLogger);
            _GrpcService = new AdssGrpcService(_AdssService, grpcLogger, options.Object);
        }

        [Test]
        public async Task RegressionTest_ADSS_AllEndpoints_ShouldReturnExpectedResults()
        {
            // ---------------------------------------------------------
            //   SayHello
            // ---------------------------------------------------------
            CommonTypes.HelloRequest helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";

            string helloMethodName = nameof(_GrpcService.SayHello);
            ServerCallContext helloContext = CreateServerContext(helloMethodName);

            CommonTypes.HelloReply helloReply = await _GrpcService.SayHello(helloRequest, helloContext);

            string expectedHello = "Hello TestName";
            string actualHello = helloReply.Message;
            EqualConstraint helloConstraint = Is.EqualTo(expectedHello);
            Assert.That(actualHello, helloConstraint);

            // =========================================================
            // GetPartImage - SUCCESS (existing file ABC123.jpg)
            // =========================================================
            PartImageRequest imageSuccessRequest = new PartImageRequest();
            string successPartNumber = "ABC123";
            imageSuccessRequest.PartNumber = successPartNumber;

            string imageSuccessMethodName = nameof(_GrpcService.GetPartImage);
            ServerCallContext imageSuccessContext = CreateServerContext(imageSuccessMethodName);

            PartImageReply imageSuccessReply = await _GrpcService.GetPartImage(imageSuccessRequest, imageSuccessContext);

            Assert.That(imageSuccessReply, Is.Not.Null);

            string expectedContentTypeSuccess = "image/jpeg";
            string actualContentTypeSuccess = imageSuccessReply.ContentType;
            EqualConstraint contentTypeSuccessConstraint = Is.EqualTo(expectedContentTypeSuccess);
            Assert.That(actualContentTypeSuccess, contentTypeSuccessConstraint);

            byte[] expectedBytesSuccess = new byte[] { 0xFF, 0xD8, 0xFF, 0xDB, 0x00, 0x00, 0xFF, 0xD9 };
            ByteString dataSuccess = imageSuccessReply.Data;
            byte[] actualBytesSuccess = dataSuccess.ToByteArray();
            EqualConstraint bytesSuccessConstraint = Is.EqualTo(expectedBytesSuccess);
            Assert.That(actualBytesSuccess, bytesSuccessConstraint);

            // =========================================================
            // GetPartImage - NO IMAGE (default embedded)
            // =========================================================
            PartImageRequest imageDefaultRequest = new PartImageRequest();
            string missingPartNumber = "NOTFOUND";
            imageDefaultRequest.PartNumber = missingPartNumber;

            string imageDefaultMethodName = nameof(_GrpcService.GetPartImage);
            ServerCallContext imageDefaultContext = CreateServerContext(imageDefaultMethodName);

            PartImageReply imageDefaultReply = await _GrpcService.GetPartImage(imageDefaultRequest, imageDefaultContext);

            Assert.That(imageDefaultReply, Is.Not.Null);

            string expectedContentTypeDefault = "image/jpeg";
            string actualContentTypeDefault = imageDefaultReply.ContentType;
            EqualConstraint contentTypeDefaultConstraint = Is.EqualTo(expectedContentTypeDefault);
            Assert.That(actualContentTypeDefault, contentTypeDefaultConstraint);

            ByteString dataDefault = imageDefaultReply.Data;
            byte[] actualBytesDefault = dataDefault.ToByteArray();

            bool defaultHasNoBytes = actualBytesDefault == null || actualBytesDefault.Length <= 0;
            Assert.That(defaultHasNoBytes, Is.False);

        }
        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                                    method: methodName,
                                                    host: "localhost",
                                                    deadline: deadline,
                                                    requestHeaders: metadata,
                                                    cancellationToken: CancellationToken.None,
                                                    peer: "10.0.0.25:5001",
                                                    authContext: null,
                                                    contextPropagationToken: null,
                                                    writeHeadersFunc: (metadata) => Task.CompletedTask,
                                                    writeOptionsGetter: () => new WriteOptions(),
                                                    writeOptionsSetter: (writeOptions) => { }
                                                  );
            return serverCallContext;
        }
    }
}