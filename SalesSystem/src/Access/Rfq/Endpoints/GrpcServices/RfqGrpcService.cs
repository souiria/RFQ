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
        public override async Task<ListRfqDrawingPartNumbersGrpc> ReadRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("ReadRfqDrawingPartNumbersGrpc starting");
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
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqDrawingPartNumbers(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetRfqDrawingPartNumbersByRowId(request, context.CancellationToken);
                default:
                {
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqDrawingPartNumbersGrpc starting");
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for creating rfq drawing part numbers.");
                throw new RpcException(status);
            }

            RfqCrudGrpcResponse responseMessage = new RfqCrudGrpcResponse();
            CancellationToken cancellationToken = context.CancellationToken;
            ListRfqDrawingPartNumbersGrpc response = await _RfqAccessService.CreateRfqDrawingPartNumbers(request, cancellationToken);
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

            return responseMessage;
        }

        public override async Task<RfqCrudGrpcResponse> UpdateRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("UpdateRfqDrawingPartNumbersGrpc starting");
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            //switch (requestType)
            //{
            //    case RequestType.Read:
            //    return await _RfqAccessService.GetAllRfqProjects(context.CancellationToken);
            //    case RequestType.ReadByRowId:
            //    return await _RfqAccessService.GetRfqProjectByRowId(request, context.CancellationToken);
            //    default:
            //    {
            //        //return await _RfqAccessService.GetAllRfqProjects(context.CancellationToken);
            //        Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
            //        throw new RpcException(status);
            //    }
            //}
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqProjects(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetRfqProjectByRowId(request, context.CancellationToken);
                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqProjectGrpc(RfqProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqProjectGrpc starting");
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
         
            if (request == null || request.GrpcRequestParameter == null)
            {
                Status status = new Status(StatusCode.InvalidArgument, "Null request or request parameters.");
                throw new RpcException(status);
            }

            //RequestType requestType = RequestType.Update;
            //if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            //{
            //    requestType = (RequestType)request.GrpcRequestParameter.RequestType;
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqNotes(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetRfqNotesByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllRfqReasons(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetRfqReasonsByRowId(request, context.CancellationToken);
                default:
                {
                    return await _RfqAccessService.GetAllRfqReasons(context.CancellationToken);
                }
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateRfqReasonGrpc(RfqReasonGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateRfqReasonGrpc starting");
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBends(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiBendsByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchConfigurations(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiBranchConfigurationsByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchConfigurationBendAssociations(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiBranchConfigurationBendAssociationsByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchInsulations(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiBranchInsulationsByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiBranchInsulationThroughNodes(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiBranchInsulationThroughNodesByRowId(request, context.CancellationToken);
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

            RfqCrudGrpcResponse response = new RfqCrudGrpcResponse();
            switch (requestType)
            {
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCavityMappings(context.CancellationToken);
                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCavityMappingsByRowId(request, context.CancellationToken);
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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCircuitOptions(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCircuitOptionsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCircuitOptionGrpc(DsiCircuitOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCircuitOptionGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCentreStrips(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCentreStripsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCentreStripGrpc(DsiCentreStripGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCentreStripGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiComponents(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiComponentsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiComponentGrpc(DsiComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiComponentGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeDetails(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCompositeDetailsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeDetailGrpc(DsiCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeDetailGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeDetailCircuitOptionAssociations(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCompositeDetailCircuitOptionAssociationsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeDetailCircuitOptionAssociationGrpc(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeDetailCircuitOptionAssociationGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiCompositeOptions(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiCompositeOptionsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiCompositeOptionGrpc(DsiCompositeOptionGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiCompositeOptionGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnesses(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiHarnessesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessGrpc(DsiHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnessScopes(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiHarnessScopesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessScopeGrpc(DsiHarnessScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessScopeGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiHarnessScopeScopeAssociations(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiHarnessScopeScopeAssociationsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiHarnessScopeScopeAssociationGrpc(DsiHarnessScopeScopeAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiHarnessScopeScopeAssociationGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiManualBomQuantities(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiManualBomQuantitiesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiManualBomQuantityGrpc(DsiManualBomQuantityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiManualBomQuantityGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiMidWireComponents(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiMidWireComponentsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiMidWireComponentGrpc(DsiMidWireComponentGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiMidWireComponentGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiModuleChildDetails(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiModuleChildDetailsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiModuleChildDetailGrpc(DsiModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiModuleChildDetailGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiModuleCompatibilities(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiModuleCompatibilitiesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiModuleCompatibilityGrpc(DsiModuleCompatibilityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiModuleCompatibilityGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiMulticoreSpecifications(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiMulticoreSpecificationsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiMulticoreSpecificationGrpc(DsiMulticoreSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiMulticoreSpecificationGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiPinMappings(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiPinMappingsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiPinMappingGrpc(DsiPinMappingGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiPinMappingGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiPinMappingCavityMappingAssociations(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiPinMappingCavityMappingAssociationsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiPinMappingCavityMappingAssociationGrpc(DsiPinMappingCavityMappingAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiPinMappingCavityMappingAssociationGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiScopes(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiScopesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiScopeGrpc(DsiScopeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiScopeGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiSuppliers(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiSuppliersByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiSupplierGrpc(DsiSupplierGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiSupplierGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedCompositeDetails(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiTransformedCompositeDetailsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedCompositeDetailGrpc(DsiTransformedCompositeDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedCompositeDetailGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedModuleChildDetails(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiTransformedModuleChildDetailsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedModuleChildDetailGrpc(DsiTransformedModuleChildDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedModuleChildDetailGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiTransformedHarnesses(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiTransformedHarnessesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiTransformedHarnessGrpc(DsiTransformedHarnessGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiTransformedHarnessGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiUnitOfMeasures(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiUnitOfMeasuresByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiUnitOfMeasureGrpc(DsiUnitOfMeasureGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiUnitOfMeasureGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireMulticoreMarkers(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiWireMulticoreMarkersByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireMulticoreMarkerGrpc(DsiWireMulticoreMarkerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireMulticoreMarkerGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireSpecifications(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiWireSpecificationsByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireSpecificationGrpc(DsiWireSpecificationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireSpecificationGrpc starting");

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
                case RequestType.Read:
                return await _RfqAccessService.GetAllDsiWireThroughNodes(context.CancellationToken);

                case RequestType.ReadByRowId:
                return await _RfqAccessService.GetDsiWireThroughNodesByRowId(request, context.CancellationToken);

                default:
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }
        }

        public override async Task<RfqCrudGrpcResponse> CreateDsiWireThroughNodeGrpc(DsiWireThroughNodeGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("CreateDsiWireThroughNodeGrpc starting");

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

    }
}
