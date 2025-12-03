namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<CDbCrudGrpcResponse> CreateMaterialTypeGrpc(MaterialTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating material types.");
                throw new RpcException(status);
            }

            if (request.MaterialTypeGrpcsToCreate == null || request.MaterialTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No material types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateMaterialTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.MaterialTypeGrpcsToCreate.Count} material types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all material types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListMaterialTypeGrpc> ReadMaterialTypeGrpc(MaterialTypeGrpcRequest request, ServerCallContext context)
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
                    ListMaterialTypeGrpc response = await _CDbAccessService.ReadAllMaterialTypes(cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting material types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateMaterialTypeGrpc(MaterialTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating material types.");
                throw new RpcException(status);
            }

            if (request.MaterialTypeGrpcsToUpdate == null || request.MaterialTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No material types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateMaterialTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No material types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.MaterialTypeGrpcsToUpdate.Count} Material types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
    }
}
