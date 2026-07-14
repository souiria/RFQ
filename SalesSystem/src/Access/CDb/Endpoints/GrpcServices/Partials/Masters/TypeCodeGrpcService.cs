namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<CDbCrudGrpcResponse> CreateTypeCodeGrpc(TypeCodeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating type codes.");
                throw new RpcException(status);
            }

            if (request.TypeCodeGrpcsToCreate == null || request.TypeCodeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No type codes to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateTypeCodes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.TypeCodeGrpcsToCreate.Count} type codes created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all type codes created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListTypeCodeGrpc> ReadTypeCodeGrpc(TypeCodeGrpcRequest request, ServerCallContext context)
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
                    ListTypeCodeGrpc response = await _CDbAccessService.ReadAllTypeCodes(cancellationToken, request.GrpcRequestParameter.Position, request.GrpcRequestParameter.Take);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting type codes.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateTypeCodeGrpc(TypeCodeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating type codes.");
                throw new RpcException(status);
            }

            if (request.TypeCodeGrpcsToUpdate == null || request.TypeCodeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No type codes to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateTypeCodes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No type codes updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.TypeCodeGrpcsToUpdate.Count} Fuse types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
    }
}
