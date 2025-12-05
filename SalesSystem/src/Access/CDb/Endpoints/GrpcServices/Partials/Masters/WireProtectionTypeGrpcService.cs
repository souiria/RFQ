namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<CDbCrudGrpcResponse> CreateWireProtectionTypeGrpc(WireProtectionTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating wire protection types.");
                throw new RpcException(status);
            }

            if (request.WireProtectionTypeGrpcsToCreate == null || request.WireProtectionTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No wire protection types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateWireProtectionTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.WireProtectionTypeGrpcsToCreate.Count} wire protection types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all wire protection types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListWireProtectionTypeGrpc> ReadWireProtectionTypeGrpc(WireProtectionTypeGrpcRequest request, ServerCallContext context)
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
                    ListWireProtectionTypeGrpc response = await _CDbAccessService.ReadAllWireProtectionTypes(cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting wire protection types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateWireProtectionTypeGrpc(WireProtectionTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating wire protection types.");
                throw new RpcException(status);
            }

            if (request.WireProtectionTypeGrpcsToUpdate == null || request.WireProtectionTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No wire protection types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateWireProtectionTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No wire protection types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.WireProtectionTypeGrpcsToUpdate.Count} Fuse types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
    }
}
