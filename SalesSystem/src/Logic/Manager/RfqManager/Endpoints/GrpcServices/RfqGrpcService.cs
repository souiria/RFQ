namespace RfqModule.Endpoints.GrpcServices
{
    public class RfqGrpcService : RfqModule.RfqModuleBase
    {
        readonly ILogger<RfqGrpcService> _Logger;
        readonly IRfqManagerService _RfqManagerService;

        public RfqGrpcService(ILogger<RfqGrpcService> logger, IRfqManagerService rfqManagerService)
        {
            _Logger = logger;
            _RfqManagerService = rfqManagerService;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<FileUploadResponse> UploadFile(FileUploadRequest request, ServerCallContext context)
        {
            FileUploadResponse uploadResponse = await _RfqManagerService.UploadFileAsync(request);
            if(uploadResponse.Success == false)
            {
                _Logger.GenericLogInformation("File upload failed: " + uploadResponse.Message);
                uploadResponse.Message = "File upload failed: " + uploadResponse.Message;
                return uploadResponse;
            }

            _Logger.GenericLogInformation("File " + request.FileName + " uploaded successfully.");
            uploadResponse.Message = "File " + request.FileName + " uploaded successfully.";
            return uploadResponse;
        }
    }
}
