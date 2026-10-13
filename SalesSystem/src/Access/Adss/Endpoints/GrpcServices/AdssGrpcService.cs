using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Adss.Endpoints.GrpcServices
{
    public class AdssGrpcService : AdssGrpc.AdssGrpcBase
    {
        readonly IAdssService _Svc;
        readonly ILogger<AdssGrpcService> _Logger;
        string _NoImage64;
        readonly byte[] _NoImageBytes;
        string _NoImageContentType;
        readonly AdssSettings _Settings;
        public AdssGrpcService(IAdssService svc, ILogger<AdssGrpcService> logger,IOptions<AdssSettings> options)
        {
            _Settings = options.Value;
            _Svc = svc;
            _Logger = logger;
            _NoImage64 = "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";
            _NoImageBytes = Convert.FromBase64String(_NoImage64);
           _NoImageContentType = "image/jpeg";
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            CommonTypes.HelloReply reply = new CommonTypes.HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<CommonTypes.HelloReply> result = Task.FromResult(reply);
            return result;
        }
    public override async Task<PartImageReply> GetPartImage(PartImageRequest request,ServerCallContext context)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            string partNumber = string.IsNullOrWhiteSpace(request.PartNumber)
                ? "noimage"
                : request.PartNumber;

            _Logger.GenericLogInformation(
                $"ADSS gRPC START - Part {partNumber}, " +
                $"Peer {context.Peer}");

            CancellationToken ct = context.CancellationToken;

            _Logger.GenericLogInformation(
                $"ADSS gRPC BEFORE service call - Part {partNumber}");

            (byte[]? imageBytes, string? contentType) =
                await _Svc.GetPartImageAsync(partNumber, ct);

            _Logger.GenericLogInformation(
                $"ADSS gRPC AFTER service call - Part {partNumber}, " +
                $"ElapsedMs {sw.ElapsedMilliseconds}, " +
                $"ImageLength {imageBytes?.Length ?? 0}, " +
                $"ContentType {contentType}, " +
                $"CancellationRequested {ct.IsCancellationRequested}");

            if (imageBytes == null || imageBytes.Length == 0)
            {
                ByteString noImageData = ByteString.CopyFrom(_NoImageBytes);
                PartImageReply noImageReply = new PartImageReply();
                noImageReply.Data = noImageData;
                noImageReply.ContentType = _NoImageContentType;

                _Logger.GenericLogInformation(
                    $"ADSS gRPC NO IMAGE - Part {partNumber}, " +
                    $"ElapsedMs {sw.ElapsedMilliseconds}, " +
                    $"RootPath {_Settings.RootPathServer}");

                return noImageReply;
            }

            ByteString imageData = ByteString.CopyFrom(imageBytes);
            PartImageReply imageReply = new PartImageReply();
            imageReply.Data = imageData;
            imageReply.ContentType = contentType;

            _Logger.GenericLogInformation(
                $"ADSS gRPC RETURN IMAGE - Part {partNumber}, " +
                $"Bytes {imageBytes.Length}, " +
                $"ElapsedMs {sw.ElapsedMilliseconds}");

            return imageReply;
        }
    }
}
