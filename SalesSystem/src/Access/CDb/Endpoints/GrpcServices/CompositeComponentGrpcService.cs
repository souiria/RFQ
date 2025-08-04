namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<ListCompositeComponentGrpc> ReadCompositeComponentGrpc(CompositeComponentGrpcRequest request, ServerCallContext context)
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
                    ListCompositeComponentGrpc response = await _CDbAccessService.ReadAllCompositeComponents(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCompositeComponentGrpc response = await _CDbAccessService.ReadManyCompositeComponents(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCompositeComponentGrpc response = await _CDbAccessService.ReadCompositeComponentsById(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadByComponentSheetNumber:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCompositeComponentGrpc response = await _CDbAccessService.ReadCompositeComponentsBySheetNumber(request, cancellationToken);
                    return response;
                }
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> CreateCompositeComponentGrpc(CompositeComponentGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating clip types.");
                throw new RpcException(status);
            }

            if (request.CompositeComponentGrpcsToCreate == null || request.CompositeComponentGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateCompositeComponents(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.CompositeComponentGrpcsToCreate.Count} components types created successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No components types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> UpdateCompositeComponentGrpc(CompositeComponentGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating composite component types.");
                throw new RpcException(status);
            }

            if (request.CompositeComponentGrpcsToUpdate == null || request.CompositeComponentGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateCompositeComponents(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.CompositeComponentGrpcsToUpdate.Count} composite component types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No composite component types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> DeleteCompositeComponentGrpc(CompositeComponentGrpcRequest request, ServerCallContext context)
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

            if (requestType != RequestType.Delete)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for deleting composite component types.");
                throw new RpcException(status);
            }

            if (request.CompositeComponentGrpcsToDelete == null || request.CompositeComponentGrpcsToDelete.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to delete.");
                throw new RpcException(status);
            }

            int deleteCount = request.CompositeComponentGrpcsToDelete.Count;

            CDbCrudGrpcResponse deleteResponseMessage = new CDbCrudGrpcResponse();
            ListCompositeComponentGrpc allCompositeComponents = new ListCompositeComponentGrpc();
            CancellationToken cancellationToken = context.CancellationToken;

            allCompositeComponents = await _CDbAccessService.ReadAllCompositeComponents(cancellationToken);
            int startCount = allCompositeComponents.CompositeComponentGrpcs.Count;

            bool response = await _CDbAccessService.DeleteCompositeComponents(request, cancellationToken);

            if (response)
            {
                allCompositeComponents = await _CDbAccessService.ReadAllCompositeComponents(cancellationToken);
                int endCount = allCompositeComponents.CompositeComponentGrpcs.Count;
                if (endCount != startCount - deleteCount)
                {
                    deleteResponseMessage.Message = $"Warning: Expected {startCount - deleteCount} components, but found {endCount} after deletion.";
                    deleteResponseMessage.SaveSuccess = false;
                }
                else
                {
                    deleteResponseMessage.Message = $"{deleteCount} composite component types deleted successfully.";
                    deleteResponseMessage.SaveSuccess = true;
                }
            }
            else
            {
                deleteResponseMessage.Message = "No composite component types deleted.";
                deleteResponseMessage.SaveSuccess = false;
            }

            return deleteResponseMessage;
        }
    }
}
