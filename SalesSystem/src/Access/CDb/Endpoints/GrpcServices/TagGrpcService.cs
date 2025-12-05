namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<ListTagGrpc> ReadTagGrpc(TagGrpcRequest request, ServerCallContext context)
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
                    ListTagGrpc response = await _CDbAccessService.ReadAllTags(cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> CreateTagGrpc(TagGrpcRequest request, ServerCallContext context)
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

            if (request.TagGrpcsToCreate == null || request.TagGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateTags(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.TagGrpcsToCreate.Count} components types created successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No components types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> UpdateTagGrpc(TagGrpcRequest request, ServerCallContext context)
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

            if (request.TagGrpcsToUpdate == null || request.TagGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateTags(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.TagGrpcsToUpdate.Count} composite component types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No composite component types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> DeleteTagGrpc(TagGrpcRequest request, ServerCallContext context)
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

            if (request.TagGrpcsToDelete == null || request.TagGrpcsToDelete.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to delete.");
                throw new RpcException(status);
            }

            int deleteCount = request.TagGrpcsToDelete.Count;

            CDbCrudGrpcResponse deleteResponseMessage = new CDbCrudGrpcResponse();
            ListTagGrpc allTags = new ListTagGrpc();
            CancellationToken cancellationToken = context.CancellationToken;

            allTags = await _CDbAccessService.ReadAllTags(cancellationToken);
            int startCount = allTags.TagGrpcs.Count;

            bool response = await _CDbAccessService.DeleteTags(request, cancellationToken);

            if (response)
            {
                allTags = await _CDbAccessService.ReadAllTags(cancellationToken);
                int endCount = allTags.TagGrpcs.Count;
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
