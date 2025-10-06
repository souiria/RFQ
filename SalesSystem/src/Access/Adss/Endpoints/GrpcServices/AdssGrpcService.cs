namespace Adss.Endpoints.GrpcServices
{
    public class AdssGrpcService : AdssGrpc.AdssGrpcBase
    {
         readonly IAdssService _Svc;
        readonly ILogger<AdssGrpcService> _Logger;

        public AdssGrpcService(IAdssService svc, ILogger<AdssGrpcService> logger)
        {
            _Svc = svc;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }
        public override async Task<PartImageReply> GetPartImage(PartImageRequest request, ServerCallContext context)
        {
            string partNumber = string.IsNullOrWhiteSpace(request.PartNumber)
                      ? "noimage"
                      : request.PartNumber;

            CancellationToken cancellationToken = context.CancellationToken;

            (byte[]? imageBytesOrNull, string? contentTypeOrNull) = await _Svc.GetPartImageAsync(partNumber, cancellationToken);

            bool imageMissing = imageBytesOrNull is null || string.IsNullOrEmpty(contentTypeOrNull);
            if (imageMissing)
            {
                Status status = new Status(StatusCode.NotFound, $"No image found for part '{partNumber}'.");
                throw new RpcException(status);
            }

            ByteString imageData = ByteString.CopyFrom(imageBytesOrNull);
            string? contentType = contentTypeOrNull;

            PartImageReply reply = new PartImageReply();

            reply.Data = imageData;
            reply.ContentType = contentType;
            

            return reply;
        }
    }
}