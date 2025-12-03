namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<ListFileNameGrpc> ReadFileNameGrpc(FileNameGrpcRequest request, ServerCallContext context)
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
                    ListFileNameGrpc response = await _CDbAccessService.ReadAllFileNames(cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> CreateFileNameGrpc(FileNameGrpcRequest request, ServerCallContext context)
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

            if (request.FileNameGrpcsToCreate == null || request.FileNameGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateFileNames(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.FileNameGrpcsToCreate.Count} components types created successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No components types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> UpdateFileNameGrpc(FileNameGrpcRequest request, ServerCallContext context)
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

            if (request.FileNameGrpcsToUpdate == null || request.FileNameGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateFileNames(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.FileNameGrpcsToUpdate.Count} composite component types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No composite component types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> DeleteFileNameGrpc(FileNameGrpcRequest request, ServerCallContext context)
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

            if (request.FileNameGrpcsToDelete == null || request.FileNameGrpcsToDelete.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to delete.");
                throw new RpcException(status);
            }

            int deleteCount = request.FileNameGrpcsToDelete.Count;

            CDbCrudGrpcResponse deleteResponseMessage = new CDbCrudGrpcResponse();
            ListFileNameGrpc allFileNames = new ListFileNameGrpc();
            CancellationToken cancellationToken = context.CancellationToken;

            allFileNames = await _CDbAccessService.ReadAllFileNames(cancellationToken);
            int startCount = allFileNames.FileNameGrpcs.Count;

            bool response = await _CDbAccessService.DeleteFileNames(request, cancellationToken);

            if (response)
            {
                allFileNames = await _CDbAccessService.ReadAllFileNames(cancellationToken);
                int endCount = allFileNames.FileNameGrpcs.Count;
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
