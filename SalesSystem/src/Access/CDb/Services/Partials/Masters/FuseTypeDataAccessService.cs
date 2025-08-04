namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateFuseTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_FuseTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryFuseTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetFuseTypesQuery, List<FuseTypeGrpc>>>();
                    _FuseTypeRefreshInProgress = true;
                    GetFuseTypesQuery query = new GetFuseTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<FuseTypeGrpc>> results = await _QueryFuseTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _FuseTypeGrpcs.FuseTypeGrpcs.Clear();
                        _FuseTypeGrpcs.FuseTypeGrpcs.AddRange(results.Value);
                    }

                    _FuseTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListFuseTypeGrpc> ReadAllFuseTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_FuseTypeGrpcs.FuseTypeGrpcs.Any())
            {
                await PopulateFuseTypeData(cancellationToken);
            }

            return _FuseTypeGrpcs;
        }

        public async Task<ListFuseTypeGrpc> ReadManyFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "FuseTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_FuseTypeGrpcs.FuseTypeGrpcs.Any())
                    {
                        await PopulateFuseTypeData(cancellationToken);
                    }

                    _FilteredFuseTypeGrpcs.FuseTypeGrpcs.Clear();
                    List<FuseTypeGrpc> filteredList = _FuseTypeGrpcs.FuseTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredFuseTypeGrpcs.FuseTypeGrpcs.AddRange(filteredList);
                    return _FilteredFuseTypeGrpcs;
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
                    if (!_FuseTypeGrpcs.FuseTypeGrpcs.Any())
                    {
                        await PopulateFuseTypeData(cancellationToken);
                    }

                    _FilteredFuseTypeGrpcs.FuseTypeGrpcs.Clear();
                    List<FuseTypeGrpc> filteredList = _FuseTypeGrpcs.FuseTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredFuseTypeGrpcs.FuseTypeGrpcs.AddRange(filteredList);
                    return _FilteredFuseTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListFuseTypeGrpc> ReadFuseTypeById(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "FuseTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_FuseTypeGrpcs.FuseTypeGrpcs.Any())
            {
                await PopulateFuseTypeData(cancellationToken);
            }

            _FilteredFuseTypeGrpcs.FuseTypeGrpcs.Clear();
            List<FuseTypeGrpc> filteredList = _FuseTypeGrpcs.FuseTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredFuseTypeGrpcs.FuseTypeGrpcs.AddRange(filteredList);
            return _FilteredFuseTypeGrpcs;
        }

        public async Task<bool> CreateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.FuseTypeGrpcsToCreate == null || request.FuseTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FuseTypeGrpcRequest or FuseTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_FuseTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFuseTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FuseTypeCommand>>();
                    FuseTypeCommand command = new FuseTypeCommand(CommandType.Create, request.FuseTypeGrpcsToCreate);

                    Result result = await _CommandFuseTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FuseTypeRefreshInProgress = true;
                        _FuseTypeGrpcs.FuseTypeGrpcs.Clear();
                        _FuseTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.FuseTypeGrpcsToUpdate == null || request.FuseTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FuseTypeGrpcRequest or FuseTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_FuseTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFuseTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FuseTypeCommand>>();
                    FuseTypeCommand command = new FuseTypeCommand(CommandType.Update, request.FuseTypeGrpcsToUpdate);

                    Result result = await _CommandFuseTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FuseTypeRefreshInProgress = true;
                        _FuseTypeGrpcs.FuseTypeGrpcs.Clear();
                        _FuseTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
