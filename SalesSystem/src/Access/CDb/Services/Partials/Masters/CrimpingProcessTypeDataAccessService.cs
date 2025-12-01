namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCrimpingProcessTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_CrimpingProcessTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryCrimpingProcessTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCrimpingProcessTypesQuery, List<CrimpingProcessTypeGrpc>>>();
                    _CrimpingProcessTypeRefreshInProgress = true;
                    GetCrimpingProcessTypesQuery query = new GetCrimpingProcessTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CrimpingProcessTypeGrpc>> results = await _QueryCrimpingProcessTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
                        _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.AddRange(results.Value);
                    }

                    _CrimpingProcessTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListCrimpingProcessTypeGrpc> ReadAllCrimpingProcessTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Any())
            {
                await PopulateCrimpingProcessTypeData(cancellationToken);
            }

            return _CrimpingProcessTypeGrpcs;
        }

        public async Task<ListCrimpingProcessTypeGrpc> ReadManyCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CrimpingProcessTypeRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            // either all actives or non actives
            switch (requestType)
            {
                case RequestType.ReadByIsActive:
                {
                    bool isActive = request.GrpcRequestParameter.BoolValue ?? false;
                    await Task.Delay(1, cancellationToken);
                    if (!_CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Any())
                    {
                        await PopulateCrimpingProcessTypeData(cancellationToken);
                    }

                    _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
                    List<CrimpingProcessTypeGrpc> filteredList = _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.AddRange(filteredList);
                    return _FilteredCrimpingProcessTypeGrpcs;
                }
                case RequestType.ReadByCode:
                {
                    string code = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(code))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Any())
                    {
                        await PopulateCrimpingProcessTypeData(cancellationToken);
                    }

                    _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
                    List<CrimpingProcessTypeGrpc> filteredList = _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.AddRange(filteredList);
                    return _FilteredCrimpingProcessTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListCrimpingProcessTypeGrpc> ReadCrimpingProcessTypeById(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CrimpingProcessTypeRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.ReadById)
            {
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a compositeComponent type by ID.");
                throw new RpcException(status);
            }

            Guid id = request.GrpcRequestParameter.StringValue != null ? Guid.Parse(request.GrpcRequestParameter.StringValue) : Guid.Empty;
            if (id == Guid.Empty)
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid ID parameter value.");
                throw new RpcException(status);
            }

            await Task.Delay(1, cancellationToken);
            if (!_CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Any())
            {
                await PopulateCrimpingProcessTypeData(cancellationToken);
            }

            _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
            List<CrimpingProcessTypeGrpc> filteredList = _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredCrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.AddRange(filteredList);
            return _FilteredCrimpingProcessTypeGrpcs;
        }

        public async Task<bool> CreateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CrimpingProcessTypeGrpcsToCreate == null || request.CrimpingProcessTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CrimpingProcessTypeGrpcRequest or CrimpingProcessTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_CrimpingProcessTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandCrimpingProcessTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<CrimpingProcessTypeCommand>>();
                    CrimpingProcessTypeCommand command = new CrimpingProcessTypeCommand(CommandType.Create, request.CrimpingProcessTypeGrpcsToCreate);

                    Result result = await _CommandCrimpingProcessTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CrimpingProcessTypeRefreshInProgress = true;
                        _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
                        _CrimpingProcessTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CrimpingProcessTypeGrpcsToUpdate == null || request.CrimpingProcessTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CrimpingProcessTypeGrpcRequest or CrimpingProcessTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_CrimpingProcessTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandCrimpingProcessTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<CrimpingProcessTypeCommand>>();
                    CrimpingProcessTypeCommand command = new CrimpingProcessTypeCommand(CommandType.Update, request.CrimpingProcessTypeGrpcsToUpdate);

                    Result result = await _CommandCrimpingProcessTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CrimpingProcessTypeRefreshInProgress = true;
                        _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Clear();
                        _CrimpingProcessTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
