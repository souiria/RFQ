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
                foreach(RfqDrawingPartNumbersGrpc drawingPartNumber in response.RfqDrawingPartNumbers)
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
            switch (requestType)
            {
                case RequestType.Read:
                    return await _RfqAccessService.GetAllRfqProjects(context.CancellationToken);
                case RequestType.ReadByRowId:
                    return await _RfqAccessService.GetRfqProjectByRowId(request,context.CancellationToken);
                default:
                    {
                        Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                        throw new RpcException(status);
                    }
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
                foreach(RfqProjectGrpc project in response.RfqProjects)
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
                Status status = new Status(StatusCode.InvalidArgument, "Invalid request type for updating rfq projects.");
                throw new RpcException(status);
            }

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
                    return await _RfqAccessService.GetRfqNotesByRowId(request,context.CancellationToken);
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
                foreach(RfqNotesGrpc notes in response.RfqNotes)
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
                    Status status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                    throw new RpcException(status);
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
                foreach(RfqReasonGrpc reason in response.RfqReasons)
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
    }
}
