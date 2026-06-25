namespace Rfq.Endpoints.GrpcServices
{
    public class RfqGrpcService : Rfq.RfqBase
    {
        readonly IRfqAccessService _RfqAccessService;
        readonly ILogger<RfqGrpcService> _Logger;

        public RfqGrpcService(IRfqAccessService rfqAccessService, ILogger<RfqGrpcService> logger)
        {
            _RfqAccessService = rfqAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region RfqDrawingPartNumbers
        public override async Task<ListRfqDrawingPartNumbersGrpc> ReadRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context) //
        {
            _Logger.GenericLogInformation("ReadRfqDrawingPartNumbersGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqDrawingPartNumbers(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation($"III Access Layer RfqGrpcService.CreateRfqDrawingPartNumbersGrpc called with {request.RfqDrawingPartNumbersGrpcsToCreate.Count} parts");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request. RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating rfq drawing part numbers.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;

            ListRfqDrawingPartNumbersGrpc response = await _RfqAccessService.CreateRfqDrawingPartNumbers(request, cancellationToken);
            _Logger.GenericLogInformation($"III Access Layer RfqGrpcService.CreateRfqDrawingPartNumbers created {response.RfqDrawingPartNumbers.Count} parts");

            if (request.RfqDrawingPartNumbersGrpcsToCreate.Count == response.RfqDrawingPartNumbers.Count)
            {
                responseMessage.Message = $"{request.RfqDrawingPartNumbersGrpcsToCreate.Count} RfqDrawingPartNumbers types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (RfqDrawingPartNumbersGrpc drawingPartNumber in response.RfqDrawingPartNumbers)
                {
                    responseMessage.StringValue = drawingPartNumber.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {   
                responseMessage.Message = "No/not all RfqDrawingPartNumbers types created.";
                responseMessage.SaveSuccess = false;
            }

            if (response.RfqDrawingPartNumbers.Count == 0)
            {
                responseMessage.Message = "No new items to create";
                responseMessage.SaveSuccess = true;
            }

            _Logger.GenericLogInformation($"III Access Layer RfqGrpcService.CreateRfqDrawingPartNumbers returning  {response.RfqDrawingPartNumbers.Count} parts, success {responseMessage.SaveSuccess}, message {responseMessage.Message}");
            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqDrawingPartNumbersGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating rfq drawing part numbers.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateRfqDrawingPartNumbers(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.RfqDrawingPartNumbersGrpcsToUpdate.Count} RfqDrawingPartNumbers types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqDrawingPartNumbers types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        #endregion

        #region RfqProjects

        public override async Task<ListRfqProjectGrpc> ReadRfqProjectGrpc(RfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadRfqProjectGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqProjects(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqProjectGrpc(RfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqProjectGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating rfq projects.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListRfqProjectGrpc response = await _RfqAccessService.CreateRfqProjects(request, cancellationToken);
            if (response.RfqProjects.Count == request.RfqProjectGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.RfqProjectGrpcsToCreate.Count} RfqProject types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (RfqProjectGrpc project in response.RfqProjects)
                {
                    responseMessage.StringValue = project.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all RfqProject types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqProjectGrpc(RfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqProjectGrpc starting");
         
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            //RequestType requestType = RequestType.Update;
            //if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            //{
            //    requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            //}
            //else
            //{
            //    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
            //    throw new RpcException(status);
            //}

            //if (requestType != RequestType.Update)
            //{
            //    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating rfq projects.");
            //    throw new RpcException(status);
            //}

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateRfqProjects(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.RfqProjectGrpcsToUpdate.Count} RfqProject types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqProject types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        public override async Task<RfqCrudGrpcResponse> DeleteRfqProjectByRowIdGrpc(RfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("DeleteRfqProjectByRowId (soft delete) starting");

            bool isRequestNull = request == null;
            long rowId = request?.RowId ?? 0;
            bool isRowIdMissing = rowId == 0;

            if (isRequestNull || isRowIdMissing)
            {
                Status status = new Status(StatusCode.InvalidArgument, $"Invalid or missing RowId. Received: {rowId}");
                throw new RpcException(status);
            }

                    ListRfqProjectGrpc resultList = await _RfqAccessService.DeleteRfqProjectByRowId(request!, context.CancellationToken);
                    bool result = !(resultList?.RfqProjects?.Count <= 0);

                    string message;

                    if (result)
                    {
                        message = $"RFQ project with RowId {rowId} marked as inactive.";
                    }
                    else
                    {
                        message = $"RFQ project with RowId {rowId} not found.";
                    }

                    RfqCrudGrpcResponse grpcResponse = new RfqCrudGrpcResponse();
                    grpcResponse.SaveSuccess = result;
                    grpcResponse.Message = message;
                    return grpcResponse;
        }
        #endregion

        #region RfqNotes

        public override async Task<ListRfqNotesGrpc> ReadRfqNotesGrpc(RfqNotesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadRfqNotesGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqNotes(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqNotesGrpc(RfqNotesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqNotesGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating rfq Notes.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListRfqNotesGrpc response = await _RfqAccessService.CreateRfqNotes(request, cancellationToken);
            if (response.RfqNotes.Count == request.RfqNotesGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.RfqNotesGrpcsToCreate.Count} RfqNotes types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (RfqNotesGrpc notes in response.RfqNotes)
                {
                    responseMessage.StringValue = notes.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all RfqNotes types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqNotesGrpc(RfqNotesGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqProjectGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateRfqNotes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.RfqNotesGrpcsToUpdate.Count} RfqNotes types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqNotes types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region RfqReason

        public override async Task<ListRfqReasonGrpc> ReadRfqReasonGrpc(RfqReasonGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadRfqReasonGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqReasons(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    return await _RfqAccessService.GetAllRfqReasons(context.CancellationToken);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqReasonGrpc(RfqReasonGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqReasonGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating rfq projects.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListRfqReasonGrpc response = await _RfqAccessService.CreateRfqReason(request, cancellationToken);
            if (response.RfqReasons.Count == request.RfqReasonGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.RfqReasonGrpcsToCreate.Count} RfqReason types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (RfqReasonGrpc reason in response.RfqReasons)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all Rfq types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqReasonGrpc(RfqReasonGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqReasonGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating rfq reasons.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateRfqReasons(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.RfqReasonGrpcsToUpdate.Count} RfqReason types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqProject types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }
        #endregion

        #region DsiBend

        public override async Task<ListDsiBendGrpc> ReadDsiBendGrpc(DsiBendGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiBendGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBends(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiBendGrpc(DsiBendGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiBendGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiBendGrpc response = await _RfqAccessService.CreateDsiBends(request, cancellationToken);
            if (response.DsiBends.Count == request.DsiBendGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiBendGrpcsToCreate.Count} DsiBends types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiBendGrpc reason in response.DsiBends)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiBends created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiBendGrpc(DsiBendGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiBendGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiBends(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiBendGrpcsToUpdate.Count} DsiBend types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiBend types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiBranchConfiguration

        public override async Task<ListDsiBranchConfigurationGrpc> ReadDsiBranchConfigurationGrpc(DsiBranchConfigurationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiBranchConfigurationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchConfigurations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiBranchConfigurationGrpc(DsiBranchConfigurationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiBranchConfigurationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiBranchConfigurationGrpc response = await _RfqAccessService.CreateDsiBranchConfigurations(request, cancellationToken);
            if (response.DsiBranchConfigurations.Count == request.DsiBranchConfigurationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiBranchConfigurationGrpcsToCreate.Count} DsiBranchConfigurations types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiBranchConfigurationGrpc reason in response.DsiBranchConfigurations)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchConfigurations created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiBranchConfigurationGrpc(DsiBranchConfigurationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiBranchConfigurationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiBranchConfigurations(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiBranchConfigurationGrpcsToUpdate.Count} DsiBranchConfiguration types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchConfiguration types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiBranchConfigurationBendAssociation

        public override async Task<ListDsiBranchConfigurationBendAssociationGrpc> ReadDsiBranchConfigurationBendAssociationGrpc(DsiBranchConfigurationBendAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiBranchConfigurationBendAssociationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchConfigurationBendAssociations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiBranchConfigurationBendAssociationGrpc(DsiBranchConfigurationBendAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiBranchConfigurationBendAssociationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiBranchConfigurationBendAssociationGrpc response = await _RfqAccessService.CreateDsiBranchConfigurationBendAssociations(request, cancellationToken);
            if (response.DsiBranchConfigurationBendAssociations.Count == request.DsiBranchConfigurationBendAssociationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiBranchConfigurationBendAssociationGrpcsToCreate.Count} DsiBranchConfigurationBendAssociations types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiBranchConfigurationBendAssociationGrpc reason in response.DsiBranchConfigurationBendAssociations)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchConfigurationBendAssociations created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiBranchConfigurationBendAssociationGrpc(DsiBranchConfigurationBendAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiBranchConfigurationBendAssociationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiBranchConfigurationBendAssociations(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiBranchConfigurationBendAssociationGrpcsToUpdate.Count} DsiBranchConfigurationBendAssociation types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchConfigurationBendAssociation types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiBranchInsulation

        public override async Task<ListDsiBranchInsulationGrpc> ReadDsiBranchInsulationGrpc(DsiBranchInsulationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiBranchInsulationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchInsulations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiBranchInsulationGrpc(DsiBranchInsulationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiBranchInsulationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiBranchInsulationGrpc response = await _RfqAccessService.CreateDsiBranchInsulations(request, cancellationToken);
            if (response.DsiBranchInsulations.Count == request.DsiBranchInsulationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiBranchInsulationGrpcsToCreate.Count} DsiBranchInsulations types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiBranchInsulationGrpc reason in response.DsiBranchInsulations)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchInsulations created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiBranchInsulationGrpc(DsiBranchInsulationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiBranchInsulationGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiBranchInsulations(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiBranchInsulationGrpcsToUpdate.Count} DsiBranchInsulation types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchInsulation types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiBranchInsulationThroughNode

        public override async Task<ListDsiBranchInsulationThroughNodeGrpc> ReadDsiBranchInsulationThroughNodeGrpc(DsiBranchInsulationThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiBranchInsulationThroughNodeGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchInsulationThroughNodes(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiBranchInsulationThroughNodeGrpc(DsiBranchInsulationThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiBranchInsulationThroughNodeGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiBranchInsulationThroughNodeGrpc response = await _RfqAccessService.CreateDsiBranchInsulationThroughNodes(request, cancellationToken);
            if (response.DsiBranchInsulationThroughNodes.Count == request.DsiBranchInsulationThroughNodeGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiBranchInsulationThroughNodeGrpcsToCreate.Count} DsiBranchInsulationThroughNodes types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiBranchInsulationThroughNodeGrpc reason in response.DsiBranchInsulationThroughNodes)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchInsulationThroughNodes created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiBranchInsulationThroughNodeGrpc(DsiBranchInsulationThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiBranchInsulationThroughNodeGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiBranchInsulationThroughNodes(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiBranchInsulationThroughNodeGrpcsToUpdate.Count} DsiBranchInsulationThroughNode types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiBranchInsulationThroughNode types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCavityMapping

        public override async Task<ListDsiCavityMappingGrpc> ReadDsiCavityMappingGrpc(DsiCavityMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCavityMappingGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCavityMappings(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCavityMappingGrpc(DsiCavityMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCavityMappingGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCavityMappingGrpc response = await _RfqAccessService.CreateDsiCavityMappings(request, cancellationToken);
            if (response.DsiCavityMappingGrpcs.Count == request.DsiCavityMappingGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCavityMappingGrpcsToCreate.Count} DsiCavityMappings types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCavityMappingGrpc reason in response.DsiCavityMappingGrpcs)
                {
                    responseMessage.StringValue = reason.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCavityMappings created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCavityMappingGrpc(DsiCavityMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCavityMappingGrpc starting");
            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating dsi bends.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCavityMappings(request, cancellationToken);
            if (response)
            {
                responseMessage.Message = $"{request.DsiCavityMappingGrpcsToUpdate.Count} DsiCavityMapping types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCavityMapping types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCircuitOption

        public override async Task<ListDsiCircuitOptionGrpc> ReadDsiCircuitOptionGrpc(DsiCircuitOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCircuitOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCircuitOptions(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCircuitOptionGrpc(DsiCircuitOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCircuitOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiCircuitOption.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCircuitOptionGrpc response = await _RfqAccessService.CreateDsiCircuitOptions(request, cancellationToken);

            if (response.DsiCircuitOptionGrpcs.Count == request.DsiCircuitOptionGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCircuitOptionGrpcsToCreate.Count} DsiCircuitOption types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCircuitOptionGrpc item in response.DsiCircuitOptionGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCircuitOption types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCircuitOptionGrpc(DsiCircuitOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCircuitOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiCircuitOption.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCircuitOptions(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiCircuitOptionGrpcsToUpdate.Count} DsiCircuitOption types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCircuitOption types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCentreStrip

        public override async Task<ListDsiCentreStripGrpc> ReadDsiCentreStripGrpc(DsiCentreStripGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCentreStripGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCentreStrips(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCentreStripGrpc(DsiCentreStripGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCentreStripGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiCentreStrip.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCentreStripGrpc response = await _RfqAccessService.CreateDsiCentreStrips(request, cancellationToken);

            if (response.DsiCentreStripGrpcs.Count == request.DsiCentreStripGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCentreStripGrpcsToCreate.Count} DsiCentreStrip types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCentreStripGrpc item in response.DsiCentreStripGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCentreStrip types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCentreStripGrpc(DsiCentreStripGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCentreStripGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiCentreStrip.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCentreStrips(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiCentreStripGrpcsToUpdate.Count} DsiCentreStrip types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCentreStrip types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiComponent

        public override async Task<ListDsiComponentGrpc> ReadDsiComponentGrpc(DsiComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiComponents(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiComponentGrpc(DsiComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiComponent.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiComponentGrpc response = await _RfqAccessService.CreateDsiComponents(request, cancellationToken);

            if (response.DsiComponentGrpcs.Count == request.DsiComponentGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiComponentGrpcsToCreate.Count} DsiComponent types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiComponentGrpc item in response.DsiComponentGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiComponent types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiComponentGrpc(DsiComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiComponent.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiComponents(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiComponentGrpcsToUpdate.Count} DsiComponent types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiComponent types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCompositeDetail

        public override async Task<ListDsiCompositeDetailGrpc> ReadDsiCompositeDetailGrpc(DsiCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeDetails(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeDetailGrpc(DsiCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiCompositeDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCompositeDetailGrpc response = await _RfqAccessService.CreateDsiCompositeDetails(request, cancellationToken);

            if (response.DsiCompositeDetailGrpcs.Count == request.DsiCompositeDetailGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCompositeDetailGrpcsToCreate.Count} DsiCompositeDetail types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCompositeDetailGrpc item in response.DsiCompositeDetailGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeDetail types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCompositeDetailGrpc(DsiCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiCompositeDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCompositeDetails(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiCompositeDetailGrpcsToUpdate.Count} DsiCompositeDetail types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeDetail types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation

        public override async Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> ReadDsiCompositeDetailCircuitOptionAssociationGrpc(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCompositeDetailCircuitOptionAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeDetailCircuitOptionAssociations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeDetailCircuitOptionAssociationGrpc(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeDetailCircuitOptionAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiCompositeDetailCircuitOptionAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCompositeDetailCircuitOptionAssociationGrpc response = await _RfqAccessService.CreateDsiCompositeDetailCircuitOptionAssociations(request, cancellationToken);

            if (response.DsiCompositeDetailCircuitOptionAssociationGrpcs.Count == request.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate.Count} DsiCompositeDetailCircuitOptionAssociation types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCompositeDetailCircuitOptionAssociationGrpc item in response.DsiCompositeDetailCircuitOptionAssociationGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeDetailCircuitOptionAssociation types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCompositeDetailCircuitOptionAssociationGrpc(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCompositeDetailCircuitOptionAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiCompositeDetailCircuitOptionAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCompositeDetailCircuitOptionAssociations(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiCompositeDetailCircuitOptionAssociationGrpcsToUpdate.Count} DsiCompositeDetailCircuitOptionAssociation types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeDetailCircuitOptionAssociation types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiCompositeOption

        public override async Task<ListDsiCompositeOptionGrpc> ReadDsiCompositeOptionGrpc(DsiCompositeOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiCompositeOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeOptions(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeOptionGrpc(DsiCompositeOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiCompositeOption.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiCompositeOptionGrpc response = await _RfqAccessService.CreateDsiCompositeOptions(request, cancellationToken);

            if (response.DsiCompositeOptionGrpcs.Count == request.DsiCompositeOptionGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiCompositeOptionGrpcsToCreate.Count} DsiCompositeOption types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiCompositeOptionGrpc item in response.DsiCompositeOptionGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeOption types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiCompositeOptionGrpc(DsiCompositeOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiCompositeOptionGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiCompositeOption.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiCompositeOptions(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiCompositeOptionGrpcsToUpdate.Count} DsiCompositeOption types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiCompositeOption types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiHarness

        public override async Task<ListDsiHarnessGrpc> ReadDsiHarnessGrpc(DsiHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnesses(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessGrpc(DsiHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiHarness.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiHarnessGrpc response = await _RfqAccessService.CreateDsiHarnesses(request, cancellationToken);

            if (response.DsiHarnessGrpcs.Count == request.DsiHarnessGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiHarnessGrpcsToCreate.Count} DsiHarness types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiHarnessGrpc item in response.DsiHarnessGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarness types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiHarnessGrpc(DsiHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiHarness.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiHarnesses(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiHarnessGrpcsToUpdate.Count} DsiHarness types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarness types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiHarnessScope

        public override async Task<ListDsiHarnessScopeGrpc> ReadDsiHarnessScopeGrpc(DsiHarnessScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiHarnessScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnessScopes(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessScopeGrpc(DsiHarnessScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiHarnessScope.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiHarnessScopeGrpc response = await _RfqAccessService.CreateDsiHarnessScopes(request, cancellationToken);

            if (response.DsiHarnessScopeGrpcs.Count == request.DsiHarnessScopeGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiHarnessScopeGrpcsToCreate.Count} DsiHarnessScope types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiHarnessScopeGrpc item in response.DsiHarnessScopeGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarnessScope types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiHarnessScopeGrpc(DsiHarnessScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiHarnessScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiHarnessScope.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiHarnessScopes(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiHarnessScopeGrpcsToUpdate.Count} DsiHarnessScope types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarnessScope types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiHarnessScopeScopeAssociation

        public override async Task<ListDsiHarnessScopeScopeAssociationGrpc> ReadDsiHarnessScopeScopeAssociationGrpc(DsiHarnessScopeScopeAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiHarnessScopeScopeAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnessScopeScopeAssociations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessScopeScopeAssociationGrpc(DsiHarnessScopeScopeAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessScopeScopeAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiHarnessScopeScopeAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiHarnessScopeScopeAssociationGrpc response = await _RfqAccessService.CreateDsiHarnessScopeScopeAssociations(request, cancellationToken);

            if (response.DsiHarnessScopeScopeAssociationGrpcs.Count == request.DsiHarnessScopeScopeAssociationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiHarnessScopeScopeAssociationGrpcsToCreate.Count} DsiHarnessScopeScopeAssociation types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiHarnessScopeScopeAssociationGrpc item in response.DsiHarnessScopeScopeAssociationGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarnessScopeScopeAssociation types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiHarnessScopeScopeAssociationGrpc(DsiHarnessScopeScopeAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiHarnessScopeScopeAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiHarnessScopeScopeAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiHarnessScopeScopeAssociations(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiHarnessScopeScopeAssociationGrpcsToUpdate.Count} DsiHarnessScopeScopeAssociation types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiHarnessScopeScopeAssociation types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiManualBomQuantity

        public override async Task<ListDsiManualBomQuantityGrpc> ReadDsiManualBomQuantityGrpc(DsiManualBomQuantityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiManualBomQuantityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiManualBomQuantities(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiManualBomQuantityGrpc(DsiManualBomQuantityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiManualBomQuantityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiManualBomQuantity.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiManualBomQuantityGrpc response = await _RfqAccessService.CreateDsiManualBomQuantities(request, cancellationToken);

            if (response.DsiManualBomQuantityGrpcs.Count == request.DsiManualBomQuantityGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiManualBomQuantityGrpcsToCreate.Count} DsiManualBomQuantity types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiManualBomQuantityGrpc item in response.DsiManualBomQuantityGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiManualBomQuantity types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiManualBomQuantityGrpc(DsiManualBomQuantityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiManualBomQuantityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiManualBomQuantity.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiManualBomQuantities(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiManualBomQuantityGrpcsToUpdate.Count} DsiManualBomQuantity types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiManualBomQuantity types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiMidWireComponent

        public override async Task<ListDsiMidWireComponentGrpc> ReadDsiMidWireComponentGrpc(DsiMidWireComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiMidWireComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiMidWireComponents(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiMidWireComponentGrpc(DsiMidWireComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiMidWireComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiMidWireComponent.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiMidWireComponentGrpc response = await _RfqAccessService.CreateDsiMidWireComponents(request, cancellationToken);

            if (response.DsiMidWireComponentGrpcs.Count == request.DsiMidWireComponentGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiMidWireComponentGrpcsToCreate.Count} DsiMidWireComponent types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiMidWireComponentGrpc item in response.DsiMidWireComponentGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiMidWireComponent types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiMidWireComponentGrpc(DsiMidWireComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiMidWireComponentGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiMidWireComponent.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiMidWireComponents(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiMidWireComponentGrpcsToUpdate.Count} DsiMidWireComponent types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiMidWireComponent types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiModuleChildDetail

        public override async Task<ListDsiModuleChildDetailGrpc> ReadDsiModuleChildDetailGrpc(DsiModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiModuleChildDetails(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiModuleChildDetailGrpc(DsiModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiModuleChildDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiModuleChildDetailGrpc response = await _RfqAccessService.CreateDsiModuleChildDetails(request, cancellationToken);

            if (response.DsiModuleChildDetailGrpcs.Count == request.DsiModuleChildDetailGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiModuleChildDetailGrpcsToCreate.Count} DsiModuleChildDetail types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiModuleChildDetailGrpc item in response.DsiModuleChildDetailGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiModuleChildDetail types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiModuleChildDetailGrpc(DsiModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiModuleChildDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiModuleChildDetails(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiModuleChildDetailGrpcsToUpdate.Count} DsiModuleChildDetail types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiModuleChildDetail types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiModuleCompatibility

        public override async Task<ListDsiModuleCompatibilityGrpc> ReadDsiModuleCompatibilityGrpc(DsiModuleCompatibilityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiModuleCompatibilityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiModuleCompatibilities(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiModuleCompatibilityGrpc(DsiModuleCompatibilityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiModuleCompatibilityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiModuleCompatibility.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiModuleCompatibilityGrpc response = await _RfqAccessService.CreateDsiModuleCompatibilities(request, cancellationToken);

            if (response.DsiModuleCompatibilityGrpcs.Count == request.DsiModuleCompatibilityGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiModuleCompatibilityGrpcsToCreate.Count} DsiModuleCompatibility types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiModuleCompatibilityGrpc item in response.DsiModuleCompatibilityGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiModuleCompatibility types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiModuleCompatibilityGrpc(DsiModuleCompatibilityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiModuleCompatibilityGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiModuleCompatibility.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiModuleCompatibilities(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiModuleCompatibilityGrpcsToUpdate.Count} DsiModuleCompatibility types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiModuleCompatibility types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiMulticoreSpecification

        public override async Task<ListDsiMulticoreSpecificationGrpc> ReadDsiMulticoreSpecificationGrpc(DsiMulticoreSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiMulticoreSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiMulticoreSpecifications(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiMulticoreSpecificationGrpc(DsiMulticoreSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiMulticoreSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiMulticoreSpecification.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiMulticoreSpecificationGrpc response = await _RfqAccessService.CreateDsiMulticoreSpecifications(request, cancellationToken);

            if (response.DsiMulticoreSpecificationGrpcs.Count == request.DsiMulticoreSpecificationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiMulticoreSpecificationGrpcsToCreate.Count} DsiMulticoreSpecification types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiMulticoreSpecificationGrpc item in response.DsiMulticoreSpecificationGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiMulticoreSpecification types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiMulticoreSpecificationGrpc(DsiMulticoreSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiMulticoreSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiMulticoreSpecification.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiMulticoreSpecifications(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiMulticoreSpecificationGrpcsToUpdate.Count} DsiMulticoreSpecification types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiMulticoreSpecification types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiPinMapping

        public override async Task<ListDsiPinMappingGrpc> ReadDsiPinMappingGrpc(DsiPinMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiPinMappingGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiPinMappings(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiPinMappingGrpc(DsiPinMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiPinMappingGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiPinMapping.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiPinMappingGrpc response = await _RfqAccessService.CreateDsiPinMappings(request, cancellationToken);

            if (response.DsiPinMappingGrpcs.Count == request.DsiPinMappingGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiPinMappingGrpcsToCreate.Count} DsiPinMapping types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiPinMappingGrpc item in response.DsiPinMappingGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiPinMapping types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiPinMappingGrpc(DsiPinMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiPinMappingGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiPinMapping.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiPinMappings(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiPinMappingGrpcsToUpdate.Count} DsiPinMapping types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiPinMapping types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiPinMappingCavityMappingAssociation

        public override async Task<ListDsiPinMappingCavityMappingAssociationGrpc> ReadDsiPinMappingCavityMappingAssociationGrpc(DsiPinMappingCavityMappingAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiPinMappingCavityMappingAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiPinMappingCavityMappingAssociations(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiPinMappingCavityMappingAssociationGrpc(DsiPinMappingCavityMappingAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiPinMappingCavityMappingAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiPinMappingCavityMappingAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiPinMappingCavityMappingAssociationGrpc response = await _RfqAccessService.CreateDsiPinMappingCavityMappingAssociations(request, cancellationToken);

            if (response.DsiPinMappingCavityMappingAssociationGrpcs.Count == request.DsiPinMappingCavityMappingAssociationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiPinMappingCavityMappingAssociationGrpcsToCreate.Count} DsiPinMappingCavityMappingAssociation types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiPinMappingCavityMappingAssociationGrpc item in response.DsiPinMappingCavityMappingAssociationGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiPinMappingCavityMappingAssociation types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiPinMappingCavityMappingAssociationGrpc(DsiPinMappingCavityMappingAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiPinMappingCavityMappingAssociationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiPinMappingCavityMappingAssociation.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiPinMappingCavityMappingAssociations(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiPinMappingCavityMappingAssociationGrpcsToUpdate.Count} DsiPinMappingCavityMappingAssociation types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiPinMappingCavityMappingAssociation types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiScope

        public override async Task<ListDsiScopeGrpc> ReadDsiScopeGrpc(DsiScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiScopes(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiScopeGrpc(DsiScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiScope.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiScopeGrpc response = await _RfqAccessService.CreateDsiScopes(request, cancellationToken);

            if (response.DsiScopeGrpcs.Count == request.DsiScopeGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiScopeGrpcsToCreate.Count} DsiScope types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiScopeGrpc item in response.DsiScopeGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiScope types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiScopeGrpc(DsiScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiScopeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiScope.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiScopes(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiScopeGrpcsToUpdate.Count} DsiScope types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiScope types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiSupplier

        public override async Task<ListDsiSupplierGrpc> ReadDsiSupplierGrpc(DsiSupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiSupplierGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiSuppliers(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiSupplierGrpc(DsiSupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiSupplierGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiSupplier.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiSupplierGrpc response = await _RfqAccessService.CreateDsiSuppliers(request, cancellationToken);

            if (response.DsiSupplierGrpcs.Count == request.DsiSupplierGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiSupplierGrpcsToCreate.Count} DsiSupplier types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiSupplierGrpc item in response.DsiSupplierGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiSupplier types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiSupplierGrpc(DsiSupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiSupplierGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiSupplier.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiSuppliers(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiSupplierGrpcsToUpdate.Count} DsiSupplier types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiSupplier types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiTransformedCompositeDetail

        public override async Task<ListDsiTransformedCompositeDetailGrpc> ReadDsiTransformedCompositeDetailGrpc(DsiTransformedCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiTransformedCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedCompositeDetails(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedCompositeDetailGrpc(DsiTransformedCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiTransformedCompositeDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiTransformedCompositeDetailGrpc response = await _RfqAccessService.CreateDsiTransformedCompositeDetails(request, cancellationToken);

            if (response.DsiTransformedCompositeDetailGrpcs.Count == request.DsiTransformedCompositeDetailGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiTransformedCompositeDetailGrpcsToCreate.Count} DsiTransformedCompositeDetail types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiTransformedCompositeDetailGrpc item in response.DsiTransformedCompositeDetailGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedCompositeDetail types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiTransformedCompositeDetailGrpc(DsiTransformedCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiTransformedCompositeDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiTransformedCompositeDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiTransformedCompositeDetails(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiTransformedCompositeDetailGrpcsToUpdate.Count} DsiTransformedCompositeDetail types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedCompositeDetail types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiTransformedModuleChildDetail

        public override async Task<ListDsiTransformedModuleChildDetailGrpc> ReadDsiTransformedModuleChildDetailGrpc(DsiTransformedModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiTransformedModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedModuleChildDetails(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedModuleChildDetailGrpc(DsiTransformedModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiTransformedModuleChildDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiTransformedModuleChildDetailGrpc response = await _RfqAccessService.CreateDsiTransformedModuleChildDetails(request, cancellationToken);

            if (response.DsiTransformedModuleChildDetailGrpcs.Count == request.DsiTransformedModuleChildDetailGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiTransformedModuleChildDetailGrpcsToCreate.Count} DsiTransformedModuleChildDetail types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiTransformedModuleChildDetailGrpc item in response.DsiTransformedModuleChildDetailGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedModuleChildDetail types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiTransformedModuleChildDetailGrpc(DsiTransformedModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiTransformedModuleChildDetailGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiTransformedModuleChildDetail.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiTransformedModuleChildDetails(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiTransformedModuleChildDetailGrpcsToUpdate.Count} DsiTransformedModuleChildDetail types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedModuleChildDetail types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiTransformedHarness

        public override async Task<ListDsiTransformedHarnessGrpc> ReadDsiTransformedHarnessGrpc(DsiTransformedHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiTransformedHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedHarnesses(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedHarnessGrpc(DsiTransformedHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiTransformedHarness.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiTransformedHarnessGrpc response = await _RfqAccessService.CreateDsiTransformedHarnesses(request, cancellationToken);

            if (response.DsiTransformedHarnessGrpcs.Count == request.DsiTransformedHarnessGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiTransformedHarnessGrpcsToCreate.Count} DsiTransformedHarness types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiTransformedHarnessGrpc item in response.DsiTransformedHarnessGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedHarness types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiTransformedHarnessGrpc(DsiTransformedHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiTransformedHarnessGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiTransformedHarness.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiTransformedHarnesses(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiTransformedHarnessGrpcsToUpdate.Count} DsiTransformedHarness types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiTransformedHarness types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiUnitOfMeasure

        public override async Task<ListDsiUnitOfMeasureGrpc> ReadDsiUnitOfMeasureGrpc(DsiUnitOfMeasureGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiUnitOfMeasureGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiUnitOfMeasures(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiUnitOfMeasureGrpc(DsiUnitOfMeasureGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiUnitOfMeasureGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiUnitOfMeasure.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiUnitOfMeasureGrpc response = await _RfqAccessService.CreateDsiUnitOfMeasures(request, cancellationToken);

            if (response.DsiUnitOfMeasureGrpcs.Count == request.DsiUnitOfMeasureGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiUnitOfMeasureGrpcsToCreate.Count} DsiUnitOfMeasure types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiUnitOfMeasureGrpc item in response.DsiUnitOfMeasureGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiUnitOfMeasure types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiUnitOfMeasureGrpc(DsiUnitOfMeasureGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiUnitOfMeasureGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiUnitOfMeasure.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiUnitOfMeasures(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiUnitOfMeasureGrpcsToUpdate.Count} DsiUnitOfMeasure types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiUnitOfMeasure types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiWireMulticoreMarker

        public override async Task<ListDsiWireMulticoreMarkerGrpc> ReadDsiWireMulticoreMarkerGrpc(DsiWireMulticoreMarkerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiWireMulticoreMarkerGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireMulticoreMarkers(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireMulticoreMarkerGrpc(DsiWireMulticoreMarkerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireMulticoreMarkerGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiWireMulticoreMarker.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiWireMulticoreMarkerGrpc response = await _RfqAccessService.CreateDsiWireMulticoreMarkers(request, cancellationToken);

            if (response.DsiWireMulticoreMarkerGrpcs.Count == request.DsiWireMulticoreMarkerGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiWireMulticoreMarkerGrpcsToCreate.Count} DsiWireMulticoreMarker types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiWireMulticoreMarkerGrpc item in response.DsiWireMulticoreMarkerGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireMulticoreMarker types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiWireMulticoreMarkerGrpc(DsiWireMulticoreMarkerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiWireMulticoreMarkerGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiWireMulticoreMarker.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiWireMulticoreMarkers(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiWireMulticoreMarkerGrpcsToUpdate.Count} DsiWireMulticoreMarker types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireMulticoreMarker types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiWireSpecification

        public override async Task<ListDsiWireSpecificationGrpc> ReadDsiWireSpecificationGrpc(DsiWireSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiWireSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireSpecifications(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireSpecificationGrpc(DsiWireSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiWireSpecification.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiWireSpecificationGrpc response = await _RfqAccessService.CreateDsiWireSpecifications(request, cancellationToken);

            if (response.DsiWireSpecificationGrpcs.Count == request.DsiWireSpecificationGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiWireSpecificationGrpcsToCreate.Count} DsiWireSpecification types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiWireSpecificationGrpc item in response.DsiWireSpecificationGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireSpecification types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiWireSpecificationGrpc(DsiWireSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiWireSpecificationGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiWireSpecification.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiWireSpecifications(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiWireSpecificationGrpcsToUpdate.Count} DsiWireSpecification types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireSpecification types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region DsiWireThroughNode

        public override async Task<ListDsiWireThroughNodeGrpc> ReadDsiWireThroughNodeGrpc(DsiWireThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadDsiWireThroughNodeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireThroughNodes(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireThroughNodeGrpc(DsiWireThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireThroughNodeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating DsiWireThroughNode.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListDsiWireThroughNodeGrpc response = await _RfqAccessService.CreateDsiWireThroughNodes(request, cancellationToken);

            if (response.DsiWireThroughNodeGrpcs.Count == request.DsiWireThroughNodeGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.DsiWireThroughNodeGrpcsToCreate.Count} DsiWireThroughNode types created successfully.";
                responseMessage.SaveSuccess = true;
                foreach (DsiWireThroughNodeGrpc item in response.DsiWireThroughNodeGrpcs)
                {
                    responseMessage.StringValue += item.RowId.ToString(CultureInfo.InvariantCulture) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireThroughNode types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateDsiWireThroughNodeGrpc(DsiWireThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateDsiWireThroughNodeGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating DsiWireThroughNode.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateDsiWireThroughNodes(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.DsiWireThroughNodeGrpcsToUpdate.Count} DsiWireThroughNode types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all DsiWireThroughNode types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        #endregion

        #region RfqNprRequest
        public override async Task<ListRfqNprRequestGrpc> ReadRfqNprRequestGrpc(RfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadRfqNprRequestGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqNprRequest(context.CancellationToken, request.RfqGrpcRequestParameter.Position, request.RfqGrpcRequestParameter.Take);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqNprRequestGrpc(RfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqNprRequestGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Create)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating RfqNprRequest.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListRfqNprRequestGrpc response = await _RfqAccessService.CreateRfqNprRequest(request, cancellationToken);

            if (response.RfqNprRequestGrpcs.Count == request.RfqNprRequestGrpcsToCreate.Count)
            {
                responseMessage.Message = $"{request.RfqNprRequestGrpcsToCreate.Count} RfqNprRequest types created successfully.";
                responseMessage.SaveSuccess = true;

                foreach (RfqNprRequestGrpc item in response.RfqNprRequestGrpcs)
                {
                    responseMessage.StringValue += JsonConvert.SerializeObject(item) + ",";
                }
            }
            else
            {
                responseMessage.Message = "No/not all RfqNprRequest types created.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqNprRequestGrpc(RfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqNprRequestGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Update)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating RfqNprRequest.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.UpdateRfqNprRequest(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.RfqNprRequestGrpcsToUpdate.Count} RfqNprRequest types updated successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqNprRequest types updated.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> DeleteRfqNprRequestByIdGrpc(RfqNprRequestGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("DeleteRfqNprRequestByIdGrpc starting");

            if (request == null || request.RfqGrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            RequestType requestType = RequestType.None;
            if (System.Enum.IsDefined(typeof(RequestType), request.RfqGrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.RfqGrpcRequestParameter.RequestType;
            }
            else
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.Delete)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating RfqNprRequest.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            bool response = await _RfqAccessService.DeleteRfqNprRequestById(request, cancellationToken);

            if (response)
            {
                responseMessage.Message = $"{request.RfqNprRequestGrpcsToDelete.Count} RfqNprRequest types deleted successfully.";
                responseMessage.SaveSuccess = true;
            }
            else
            {
                responseMessage.Message = "No/not all RfqNprRequest types deleted.";
                responseMessage.SaveSuccess = false;
            }

            return responseMessage;

        }
        public override async Task<ValidateNprRequestResponse> ValidateNprRequestGrpc(ValidateNprRequestRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ValidateNprRequestGrpc starting");

            if (request?.Items == null || request.Items.Count == 0)
            {
                _Logger.GenericLogInformation("No items provided.");
            }

            _Logger.GenericLogInformation($"ValidateNprRequestGrpc: received {request?.Items.Count} items");

            CancellationToken cancellationToken = context.CancellationToken;

            ValidateNprRequestRequest safeRequest = request!;
            ICollection<RfqNprRequestGrpc> safeItems = safeRequest.Items!;
            Collection<RfqNprRequestGrpc> items = new Collection<RfqNprRequestGrpc>();

            foreach (RfqNprRequestGrpc grpcItem in safeItems)
            {
                string iid = grpcItem.Id ?? string.Empty;
               // string customer = grpcItem.customer ?? string.Empty;
                items.Add(grpcItem);
            }

            NprValidationResultDto result = await _RfqAccessService.ValidateNprItemsAsync(items, cancellationToken);

            ValidateNprRequestResponse response = new ValidateNprRequestResponse();

            response.AllValid = result.AllValid;
            response.ItemCount = result.ItemCount;
            response.TotalQuantity = result.TotalQuantity;

            foreach (NprValidationLineDto line in result.LineStatuses)
            {
                SubmitNprLineStatus lineStatus = new SubmitNprLineStatus();
                lineStatus.Id = line.Id ?? string.Empty;
                lineStatus.IsValid = line.IsValid;

                foreach (ValidationErrorDto errorDto in line.Errors)
                {
                    ValidationError validation = new ValidationError();
                    validation.Field = errorDto.Field;
                    validation.Message = errorDto.Message;
                    lineStatus.Errors.Add(validation);

                }

                response.LineStatuses.Add(lineStatus);
            }

            return response;
        }
        #endregion

        public override async Task<RfqFilterResponse> FilterRfqGrpc(RfqFilterRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterRfqGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            RfqFilterResponse returnResponse = new RfqFilterResponse();
            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "RFQDRAWINGPARTNUMBERSGRPC":
                await _RfqAccessService.HandleFilterCase<RfqDrawingPartNumbersGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListRfqDrawingPartNumbersGrpc returnList = new ListRfqDrawingPartNumbersGrpc();
                        returnList.RfqDrawingPartNumbers.AddRange(filterlist);
                        returnResponse.ListRfqDrawingPartNumbersGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "RFQPROJECTGRPC":
                try
                {
                    await _RfqAccessService.HandleFilterCase<RfqProjectGrpc>(
                        request.FilterExpression, parsingConfig,
                        filterlist =>
                        {
                            ListRfqProjectGrpc returnList = new ListRfqProjectGrpc();
                            returnList.RfqProjects.AddRange(filterlist);
                            returnResponse.ListRfqProjectGrpc = returnList;
                            returnResponse.Success = true;
                        }, context.CancellationToken);
                }
                catch (ParseException ex)
                {
                    _Logger.GenericLogError($" RfqGrpcService.FilterRfqGrpc filter parsing failed. Expression: '{request.FilterExpression}'. Error: {ex.Message}", ex);
                    throw;
                }

                break;
                case "RFQNOTESGRPC":
                await _RfqAccessService.HandleFilterCase<RfqNotesGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListRfqNotesGrpc returnList = new ListRfqNotesGrpc();
                        returnList.RfqNotes.AddRange(filterlist);
                        returnResponse.ListRfqNotesGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "RFQREASONGRPC":
                await _RfqAccessService.HandleFilterCase<RfqReasonGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListRfqReasonGrpc returnList = new ListRfqReasonGrpc();
                        returnList.RfqReasons.AddRange(filterlist);
                        returnResponse.ListRfqReasonGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIBENDGRPC":
                await _RfqAccessService.HandleFilterCase<DsiBendGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiBendGrpc returnList = new ListDsiBendGrpc();
                        returnList.DsiBends.AddRange(filterlist);
                        returnResponse.ListDsiBendGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIBRANCHCONFIGURATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiBranchConfigurationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiBranchConfigurationGrpc returnList = new ListDsiBranchConfigurationGrpc();
                        returnList.DsiBranchConfigurations.AddRange(filterlist);
                        returnResponse.ListDsiBranchConfigurationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiBranchConfigurationBendAssociationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiBranchConfigurationBendAssociationGrpc returnList = new ListDsiBranchConfigurationBendAssociationGrpc();
                        returnList.DsiBranchConfigurationBendAssociations.AddRange(filterlist);
                        returnResponse.ListDsiBranchConfigurationBendAssociationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIBRANCHINSULATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiBranchInsulationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiBranchInsulationGrpc returnList = new ListDsiBranchInsulationGrpc();
                        returnList.DsiBranchInsulations.AddRange(filterlist);
                        returnResponse.ListDsiBranchInsulationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIBRANCHINSULATIONTHROUGHNODEGRPC":
                await _RfqAccessService.HandleFilterCase<DsiBranchInsulationThroughNodeGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiBranchInsulationThroughNodeGrpc returnList = new ListDsiBranchInsulationThroughNodeGrpc();
                        returnList.DsiBranchInsulationThroughNodes.AddRange(filterlist);
                        returnResponse.ListDsiBranchInsulationThroughNodeGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICAVITYMAPPINGGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCavityMappingGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCavityMappingGrpc returnList = new ListDsiCavityMappingGrpc();
                        returnList.DsiCavityMappingGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCavityMappingGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICENTRESTRIPGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCentreStripGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCentreStripGrpc returnList = new ListDsiCentreStripGrpc();
                        returnList.DsiCentreStripGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCentreStripGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICIRCUITOPTIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCircuitOptionGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCircuitOptionGrpc returnList = new ListDsiCircuitOptionGrpc();
                        returnList.DsiCircuitOptionGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCircuitOptionGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICOMPONENTGRPC":
                await _RfqAccessService.HandleFilterCase<DsiComponentGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiComponentGrpc returnList = new ListDsiComponentGrpc();
                        returnList.DsiComponentGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiComponentGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICOMPOSITEDETAILGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCompositeDetailGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCompositeDetailGrpc returnList = new ListDsiCompositeDetailGrpc();
                        returnList.DsiCompositeDetailGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCompositeDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCompositeDetailCircuitOptionAssociationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCompositeDetailCircuitOptionAssociationGrpc returnList = new ListDsiCompositeDetailCircuitOptionAssociationGrpc();
                        returnList.DsiCompositeDetailCircuitOptionAssociationGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCompositeDetailCircuitOptionAssociationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSICOMPOSITEOPTIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiCompositeOptionGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiCompositeOptionGrpc returnList = new ListDsiCompositeOptionGrpc();
                        returnList.DsiCompositeOptionGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiCompositeOptionGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIHARNESSGRPC":
                await _RfqAccessService.HandleFilterCase<DsiHarnessGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiHarnessGrpc returnList = new ListDsiHarnessGrpc();
                        returnList.DsiHarnessGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiHarnessGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIHARNESSSCOPEGRPC":
                await _RfqAccessService.HandleFilterCase<DsiHarnessScopeGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiHarnessScopeGrpc returnList = new ListDsiHarnessScopeGrpc();
                        returnList.DsiHarnessScopeGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiHarnessScopeGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIHARNESSSCOPESCOPEASSOCIATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiHarnessScopeScopeAssociationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiHarnessScopeScopeAssociationGrpc returnList = new ListDsiHarnessScopeScopeAssociationGrpc();
                        returnList.DsiHarnessScopeScopeAssociationGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiHarnessScopeScopeAssociationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIMANUALBOMQUANTITYGRPC":
                await _RfqAccessService.HandleFilterCase<DsiManualBomQuantityGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiManualBomQuantityGrpc returnList = new ListDsiManualBomQuantityGrpc();
                        returnList.DsiManualBomQuantityGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiManualBomQuantityGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIMIDWIRECOMPONENTGRPC":
                await _RfqAccessService.HandleFilterCase<DsiMidWireComponentGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiMidWireComponentGrpc returnList = new ListDsiMidWireComponentGrpc();
                        returnList.DsiMidWireComponentGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiMidWireComponentGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIMODULECHILDDETAILGRPC":
                await _RfqAccessService.HandleFilterCase<DsiModuleChildDetailGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiModuleChildDetailGrpc returnList = new ListDsiModuleChildDetailGrpc();
                        returnList.DsiModuleChildDetailGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiModuleChildDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIMODULECOMPATIBILITYGRPC":
                await _RfqAccessService.HandleFilterCase<DsiModuleCompatibilityGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiModuleCompatibilityGrpc returnList = new ListDsiModuleCompatibilityGrpc();
                        returnList.DsiModuleCompatibilityGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiModuleCompatibilityGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIMULTICORESPECIFICATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiMulticoreSpecificationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiMulticoreSpecificationGrpc returnList = new ListDsiMulticoreSpecificationGrpc();
                        returnList.DsiMulticoreSpecificationGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiMulticoreSpecificationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIPINMAPPINGGRPC":
                await _RfqAccessService.HandleFilterCase<DsiPinMappingGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiPinMappingGrpc returnList = new ListDsiPinMappingGrpc();
                        returnList.DsiPinMappingGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiPinMappingGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiPinMappingCavityMappingAssociationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiPinMappingCavityMappingAssociationGrpc returnList = new ListDsiPinMappingCavityMappingAssociationGrpc();
                        returnList.DsiPinMappingCavityMappingAssociationGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiPinMappingCavityMappingAssociationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSISCOPEGRPC":
                await _RfqAccessService.HandleFilterCase<DsiScopeGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiScopeGrpc returnList = new ListDsiScopeGrpc();
                        returnList.DsiScopeGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiScopeGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSISUPPLIERGRPC":
                await _RfqAccessService.HandleFilterCase<DsiSupplierGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiSupplierGrpc returnList = new ListDsiSupplierGrpc();
                        returnList.DsiSupplierGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiSupplierGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSITRANSFORMEDCOMPOSITEDETAILGRPC":
                await _RfqAccessService.HandleFilterCase<DsiTransformedCompositeDetailGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiTransformedCompositeDetailGrpc returnList = new ListDsiTransformedCompositeDetailGrpc();
                        returnList.DsiTransformedCompositeDetailGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiTransformedCompositeDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSITRANSFORMEDHARNESSGRPC":
                await _RfqAccessService.HandleFilterCase<DsiTransformedHarnessGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiTransformedHarnessGrpc returnList = new ListDsiTransformedHarnessGrpc();
                        returnList.DsiTransformedHarnessGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiTransformedHarnessGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSITRANSFORMEDMODULECHILDDETAILGRPC":
                await _RfqAccessService.HandleFilterCase<DsiTransformedModuleChildDetailGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiTransformedModuleChildDetailGrpc returnList = new ListDsiTransformedModuleChildDetailGrpc();
                        returnList.DsiTransformedModuleChildDetailGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiTransformedModuleChildDetailGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIUNITOFMEASUREGRPC":
                await _RfqAccessService.HandleFilterCase<DsiUnitOfMeasureGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiUnitOfMeasureGrpc returnList = new ListDsiUnitOfMeasureGrpc();
                        returnList.DsiUnitOfMeasureGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiUnitOfMeasureGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIWIREMULTICOREMARKERGRPC":
                await _RfqAccessService.HandleFilterCase<DsiWireMulticoreMarkerGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiWireMulticoreMarkerGrpc returnList = new ListDsiWireMulticoreMarkerGrpc();
                        returnList.DsiWireMulticoreMarkerGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiWireMulticoreMarkerGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIWIRESPECIFICATIONGRPC":
                await _RfqAccessService.HandleFilterCase<DsiWireSpecificationGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiWireSpecificationGrpc returnList = new ListDsiWireSpecificationGrpc();
                        returnList.DsiWireSpecificationGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiWireSpecificationGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "DSIWIRETHROUGHNODEGRPC":
                await _RfqAccessService.HandleFilterCase<DsiWireThroughNodeGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListDsiWireThroughNodeGrpc returnList = new ListDsiWireThroughNodeGrpc();
                        returnList.DsiWireThroughNodeGrpcs.AddRange(filterlist);
                        returnResponse.ListDsiWireThroughNodeGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                case "RFQNPRREQUESTGRPC":
                await _RfqAccessService.HandleFilterCase<RfqNprRequestGrpc>(
                    request.FilterExpression, parsingConfig,
                    filterlist =>
                    {
                        ListRfqNprRequestGrpc returnList = new ListRfqNprRequestGrpc();
                        returnList.RfqNprRequestGrpcs.AddRange(filterlist);
                        returnResponse.ListRfqNprRequestGrpc = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                break;
                default:
                _Logger.GenericLogInformation($"FilterRfqGrpc: Unknown DatabaseList '{request.DatabaseList}'");
                break;
            }

            return returnResponse;
        }
    }
}
