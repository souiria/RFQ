namespace CDb.Endpoints.GrpcServices
{
    public class CDbGrpcService : CDbService.CDbServiceBase
    {
        readonly ICDbAccessService _CDbAccessService;
        readonly ILogger<CDbGrpcService> _Logger;

        public CDbGrpcService(ICDbAccessService cDbAccessService, ILogger<CDbGrpcService> logger)
        {
            _CDbAccessService = cDbAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region ClipType

        public override async Task<CDbCrudGrpcResponse> CreateClipTypeGrpc(ClipTypeGrpcRequest request, ServerCallContext context)
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

            if (request.ClipTypeGrpcsToCreate == null || request.ClipTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateClipTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.ClipTypeGrpcsToCreate.Count} clip types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all clip types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListClipTypeGrpc> ReadClipTypeGrpc(ClipTypeGrpcRequest request, ServerCallContext context)
        {
            if (request == null || request.GrpcRequestParameter == null )
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
                    ListClipTypeGrpc response = await _CDbAccessService.ReadAllClipTypes(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.ReadManyClipTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadByCode:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.ReadManyClipTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListClipTypeGrpc response = await _CDbAccessService.ReadClipTypeById(request, cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting clip types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateClipTypeGrpc(ClipTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating clip types.");
                throw new RpcException(status);
            }

            if (request.ClipTypeGrpcsToUpdate == null || request.ClipTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No clip types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateClipTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No clip types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.ClipTypeGrpcsToUpdate.Count} Clip types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
        #endregion

        #region CrimpingProcessType

        public override async Task<CDbCrudGrpcResponse> CreateCrimpingProcessTypeGrpc(CrimpingProcessTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating crimpingProcess types.");
                throw new RpcException(status);
            }

            if (request.CrimpingProcessTypeGrpcsToCreate == null || request.CrimpingProcessTypeGrpcsToCreate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No crimpingProcess types to add.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.CreateCrimpingProcessTypes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.CrimpingProcessTypeGrpcsToCreate.Count} crimpingProcess types created successfully.";
                responseMessage.SaveSuccess = true;

            }
            else
            {
                responseMessage.Message = "No/not all crimpingProcess types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<ListCrimpingProcessTypeGrpc> ReadCrimpingProcessTypeGrpc(CrimpingProcessTypeGrpcRequest request, ServerCallContext context)
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
                    ListCrimpingProcessTypeGrpc response = await _CDbAccessService.ReadAllCrimpingProcessTypes(cancellationToken);
                    return response;
                }

                case RequestType.ReadByIsActive:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCrimpingProcessTypeGrpc response = await _CDbAccessService.ReadManyCrimpingProcessTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadByCode:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCrimpingProcessTypeGrpc response = await _CDbAccessService.ReadManyCrimpingProcessTypes(request, cancellationToken);
                    return response;
                }

                case RequestType.ReadById:
                {
                    CancellationToken cancellationToken = context.CancellationToken;
                    ListCrimpingProcessTypeGrpc response = await _CDbAccessService.ReadCrimpingProcessTypeById(request, cancellationToken);
                    return response;
                }

                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for getting crimpingProcess types.");
                    throw new RpcException(status);
                }
            }
        }
        public override async Task<CDbCrudGrpcResponse> UpdateCrimpingProcessTypeGrpc(CrimpingProcessTypeGrpcRequest request, ServerCallContext context)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating crimpingProcess types.");
                throw new RpcException(status);
            }

            if (request.CrimpingProcessTypeGrpcsToUpdate == null || request.CrimpingProcessTypeGrpcsToUpdate.Count == 0)
            {
                Status status = new Status(StatusCode.InvalidArgument, "No crimpingProcess types to update.");
                throw new RpcException(status);
            }

            CDbCrudGrpcResponse responseMessage = new CDbCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _CDbAccessService.UpdateCrimpingProcessTypes(request, cancellationToken);

            if (!response)
            {
                responseMessage.Message = "No crimpingProcess types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{request.CrimpingProcessTypeGrpcsToUpdate.Count} CrimpingProcess types updated successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
        #endregion

        #region CompositeComponent
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
            ListCompositeComponentGrpc response = await _CDbAccessService.CreateCompositeComponents(request, cancellationToken);
            if (response == null || response.CompositeComponentGrpcs.Count == 0)
            {
                responseMessage.Message = "No components types created.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{response.CompositeComponentGrpcs.Count} components types created successfully.";
                responseMessage.SaveSuccess = true;
            }

            return responseMessage;
        }
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
            ListCompositeComponentGrpc response = await _CDbAccessService.UpdateCompositeComponents(request, cancellationToken);

            if (response == null || response.CompositeComponentGrpcs.Count == 0)
            {
                responseMessage.Message = "No composite component types updated.";
                responseMessage.SaveSuccess = false;
            }
            else
            {
                responseMessage.Message = $"{response.CompositeComponentGrpcs.Count} composite component types updated successfully.";
                responseMessage.SaveSuccess = true;
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

            ListCompositeComponentGrpc response = await _CDbAccessService.DeleteCompositeComponents(request, cancellationToken);

            if (response == null || response.CompositeComponentGrpcs.Count == 0)
            {
                deleteResponseMessage.Message = "No composite component types deleted.";
                deleteResponseMessage.SaveSuccess = false;
            }
            else
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

            return deleteResponseMessage;
        }
        #endregion
    }
}
