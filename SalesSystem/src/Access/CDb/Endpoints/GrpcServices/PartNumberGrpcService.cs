namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {

        public override async Task<ListPartNumberGrpc> ReadPartNumberGrpc(PartNumberGrpcRequest request, ServerCallContext context)
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
                    ListPartNumberGrpc response = await _CDbAccessService.ReadAllPartNumbers(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListPartNumberGrpc response = await _CDbAccessService.ReadManyPartNumbers(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListPartNumberGrpc response = await _CDbAccessService.ReadPartNumberById(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadByName:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListPartNumberGrpc response = await _CDbAccessService.ReadManyPartNumbers(request, cancellationToken);
                    return response;
                }
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> CreatePartNumberGrpc(PartNumberGrpcRequest request, ServerCallContext context)
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

            if (request.PartNumberGrpcsToCreate == null || request.PartNumberGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreatePartNumbers(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.PartNumberGrpcsToCreate.Count} components types created successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No components types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> UpdatePartNumberGrpc(PartNumberGrpcRequest request, ServerCallContext context)
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

            if (request.PartNumberGrpcsToUpdate == null || request.PartNumberGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdatePartNumbers(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.PartNumberGrpcsToUpdate.Count} composite component types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No composite component types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<CDbCrudGrpcResponse> DeletePartNumberGrpc(PartNumberGrpcRequest request, ServerCallContext context)
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

            if (request.PartNumberGrpcsToDelete == null || request.PartNumberGrpcsToDelete.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No composite component types to delete.");
                throw new RpcException(status);
            }

            int deleteCount = request.PartNumberGrpcsToDelete.Count;

            CDbCrudGrpcResponse deleteResponseMessage = new CDbCrudGrpcResponse();
            ListPartNumberGrpc allPartNumbers = new ListPartNumberGrpc();
            CancellationToken cancellationToken = context.CancellationToken;

            allPartNumbers = await _CDbAccessService.ReadAllPartNumbers(cancellationToken);
            int startCount = allPartNumbers.PartNumberGrpcs.Count;

            bool response = await _CDbAccessService.DeletePartNumbers(request, cancellationToken);

            if (response)
            {
                allPartNumbers = await _CDbAccessService.ReadAllPartNumbers(cancellationToken);
                int endCount = allPartNumbers.PartNumberGrpcs.Count;
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
