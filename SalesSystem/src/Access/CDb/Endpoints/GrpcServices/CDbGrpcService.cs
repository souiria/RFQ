namespace CDb.Endpoints.GrpcServices
{
    public class CDbGrpcService : CDbService.CDbServiceBase
    {
        readonly ICDbAccessService _CDbAccessService;
        readonly ILogger<CDbGrpcService> _Logger;

        public CDbGrpcService(ICDbAccessService cDbAccessService, ILogger<CDbGrpcService> logger)
        {
            _CDbAccessService = cDbAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<CDbCrudGrpcResponse> CreateClipTypeGrpc(ClipTypeGrpcRequest request, ServerCallContext context)
        {
            if (request == null || request.RequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RequestParameter.RequestType))
            {
                requestType = (RequestType)request.RequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating clip types.");
                throw new RpcException(status);
            }

            if (request.ClipTypeGrpcsToAdd == null || request.ClipTypeGrpcsToAdd.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListClipTypeGrpc response = await _CDbAccessService.CreateClipTypes(request, cancellationToken);
            if (response == null || response.ClipTypeGrpcs.Count == 0)
            {
                responseMessage.Message = "No clip types created.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{response.ClipTypeGrpcs.Count} Clip types created successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }

        public override async Task<ListClipTypeGrpc> ReadClipTypeGrpc(ClipTypeGrpcRequest request, ServerCallContext context)
        {
            if (request == null || request.RequestParameter == null )
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RequestParameter.RequestType))
            {
                requestType = (RequestType)request.RequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.ReadAll:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.GetAllClipTypes(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.GetManyClipTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.GetClipTypeById(request, cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }

        //public override async Task<CDbCrudGrpcResponse> Cr(PartNumberRequest request, ServerCallContext context)
        //{
        //    if (request == null || request.PartNumberGrpcToAdd == null || request.PartNumberGrpcToAdd.Count == 0)
        //    {
        //        Status status = new Status(StatusCode.InvalidArgument, "Null request or clip types to add.");
        //        throw new RpcException(status);
        //    }

        //    CancellationToken cancellationToken = context.CancellationToken;
        //    ListClipTypeGrpc response = await _CDbAccessService.CreateClipTypes(request, cancellationToken);
        //    if(response == null || response.ClipTypeGrpc.Count == 0)
        //    {
        //        Status status = new Status(StatusCode.NotFound, "No clip types created.");
        //        throw new RpcException(status);
        //    }

        //    CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
        //    responseMessage.Message = "Clip types created successfully.";
        //    responseMessage.SaveSuccess = true;

        //    return await Task.FromResult(responseMessage);
        //}
    }
}
