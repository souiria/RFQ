namespace Core.Endpoints.Grpc
{
    public class CoreGrpcService : Core.CoreBase
    {
        readonly ICoreAccessService _CoreAccessService;
        readonly ILogger<CoreGrpcService> _Logger;

        public CoreGrpcService(ICoreAccessService coreAccessService, ILogger<CoreGrpcService> logger)
        {
            _CoreAccessService = coreAccessService;
            _Logger = logger;
        }

        public override Task<CommonTypes.HelloReply> SayHello(CommonTypes.HelloRequest request, ServerCallContext context)
        {
            CommonTypes.HelloReply reply = new CommonTypes.HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<CommonTypes.HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<ListUsersGrpc> ReadUsersListGrpc(ReadUsersListGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadUserListGrpc starting");
            ListUsersGrpc reply = new ListUsersGrpc();
            if (request == null || request.GrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _CoreAccessService.GetAllUserList(context.CancellationToken);
                case RequestType.ReadByUsername:
                return await _CoreAccessService.GetUserListByUserName(request, context.CancellationToken);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }
    }
}
