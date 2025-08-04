namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<CDbCrudGrpcResponse> CreateWaterproofTypeGrpc(WaterproofTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating waterproof types.");
                throw new RpcException(status);
            }

            if (request.WaterproofTypeGrpcsToCreate == null || request.WaterproofTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No waterproof types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateWaterproofTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.WaterproofTypeGrpcsToCreate.Count} waterproof types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all waterproof types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListWaterproofTypeGrpc> ReadWaterproofTypeGrpc(WaterproofTypeGrpcRequest request, ServerCallContext context)
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
                    ListWaterproofTypeGrpc response = await _CDbAccessService.ReadAllWaterproofTypes(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListWaterproofTypeGrpc response = await _CDbAccessService.ReadManyWaterproofTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadByCode:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListWaterproofTypeGrpc response = await _CDbAccessService.ReadManyWaterproofTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListWaterproofTypeGrpc response = await _CDbAccessService.ReadWaterproofTypeById(request, cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting waterproof types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateWaterproofTypeGrpc(WaterproofTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating waterproof types.");
                throw new RpcException(status);
            }

            if (request.WaterproofTypeGrpcsToUpdate == null || request.WaterproofTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No waterproof types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateWaterproofTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No waterproof types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.WaterproofTypeGrpcsToUpdate.Count} Fuse types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
    }
}
