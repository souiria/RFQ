namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulatePartNumberData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryPartNumberHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartNumbersQuery, List<PartNumberGrpc>>>();
                    _PartNumberRefreshInProgress = true;
                    GetPartNumbersQuery query = new GetPartNumbersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartNumberGrpc>> results = await _QueryPartNumberHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberGrpcs.PartNumberGrpcs.AddRange(results.Value);
                    }

                    _PartNumberRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListPartNumberGrpc> ReadAllPartNumbers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_PartNumberGrpcs.PartNumberGrpcs.Any())
            {
                await PopulatePartNumberData(cancellationToken);
            }

            return _PartNumberGrpcs;
        }

        public async Task<ListPartNumberGrpc> ReadManyPartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_PartNumberGrpcs.PartNumberGrpcs.Any())
                    {
                        await PopulatePartNumberData(cancellationToken);
                    }

                    _FilteredPartNumberGrpcs.PartNumberGrpcs.Clear();
                    List<PartNumberGrpc> filteredList = _PartNumberGrpcs.PartNumberGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredPartNumberGrpcs.PartNumberGrpcs.AddRange(filteredList);
                    return _FilteredPartNumberGrpcs;
                }
                case RequestType.ReadByName:
                {
                    string name = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(name))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_PartNumberGrpcs.PartNumberGrpcs.Any())
                    {
                        await PopulatePartNumberData(cancellationToken);
                    }

                    _FilteredPartNumberGrpcs.PartNumberGrpcs.Clear();
                    List<PartNumberGrpc> filteredList = _PartNumberGrpcs.PartNumberGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredPartNumberGrpcs.PartNumberGrpcs.AddRange(filteredList);
                    return _FilteredPartNumberGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListPartNumberGrpc> ReadPartNumberById(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberRequest or GrpcRequestParameter cannot be null.");
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
            if (!_PartNumberGrpcs.PartNumberGrpcs.Any())
            {
                await PopulatePartNumberData(cancellationToken);
            }

            _FilteredPartNumberGrpcs.PartNumberGrpcs.Clear();
            List<PartNumberGrpc> filteredList = _PartNumberGrpcs.PartNumberGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredPartNumberGrpcs.PartNumberGrpcs.AddRange(filteredList);
            return _FilteredPartNumberGrpcs;
        }

        public async Task<bool> CreatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PartNumberGrpcsToCreate == null || request.PartNumberGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToCreate cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Create, request.PartNumberGrpcsToCreate);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PartNumberGrpcsToUpdate == null || request.PartNumberGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToUpdate cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Update, request.PartNumberGrpcsToUpdate);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
        public async Task<bool> DeletePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PartNumberGrpcsToDelete == null || request.PartNumberGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToDelete cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Delete, request.PartNumberGrpcsToDelete);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
