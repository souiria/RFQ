namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<CDbCrudGrpcResponse> CreateMiscellaneousComponentTypeGrpc(MiscellaneousComponentTypeGrpcRequest request, ServerCallContext context)
        {
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

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating miscellaneousComponent types.");
                throw new RpcException(status);
            }

            if (request.MiscellaneousComponentTypeGrpcsToCreate == null || request.MiscellaneousComponentTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No miscellaneousComponent types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateMiscellaneousComponentTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.MiscellaneousComponentTypeGrpcsToCreate.Count} miscellaneousComponent types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all miscellaneousComponent types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListMiscellaneousComponentTypeGrpc> ReadMiscellaneousComponentTypeGrpc(MiscellaneousComponentTypeGrpcRequest request, ServerCallContext context)
        {
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
                case RequestType.ReadAll:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListMiscellaneousComponentTypeGrpc response = await _CDbAccessService.ReadAllMiscellaneousComponentTypes(cancellationToken, request.GrpcRequestParameter.Position, request.GrpcRequestParameter.Take);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting miscellaneousComponent types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateMiscellaneousComponentTypeGrpc(MiscellaneousComponentTypeGrpcRequest request, ServerCallContext context)
        {
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

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating miscellaneousComponent types.");
                throw new RpcException(status);
            }

            if (request.MiscellaneousComponentTypeGrpcsToUpdate == null || request.MiscellaneousComponentTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No miscellaneousComponent types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateMiscellaneousComponentTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No miscellaneousComponent types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.MiscellaneousComponentTypeGrpcsToUpdate.Count} MiscellaneousComponent types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
    }
}
