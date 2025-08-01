namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTerminalFamilyData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTerminalFamilysQuery, List<TerminalFamilyGrpc>>>();
                    _TerminalFamilyRefreshInProgress = true;
                    GetTerminalFamilysQuery query = new GetTerminalFamilysQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TerminalFamilyGrpc>> results = await _QueryTerminalFamilyHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.AddRange(results.Value);
                    }

                    _TerminalFamilyRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTerminalFamilyGrpc> ReadAllTerminalFamilys(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TerminalFamilyGrpcs.TerminalFamilyGrpcs.Any())
            {
                await PopulateTerminalFamilyData(cancellationToken);
            }

            return _TerminalFamilyGrpcs;
        }

        public async Task<ListTerminalFamilyGrpc> ReadManyTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_TerminalFamilyGrpcs.TerminalFamilyGrpcs.Any())
                    {
                        await PopulateTerminalFamilyData(cancellationToken);
                    }

                    _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                    List<TerminalFamilyGrpc> filteredList = _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.AddRange(filteredList);
                    return _FilteredTerminalFamilyGrpcs;
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
                    if (!_TerminalFamilyGrpcs.TerminalFamilyGrpcs.Any())
                    {
                        await PopulateTerminalFamilyData(cancellationToken);
                    }

                    _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                    List<TerminalFamilyGrpc> filteredList = _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.AddRange(filteredList);
                    return _FilteredTerminalFamilyGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListTerminalFamilyGrpc> ReadTerminalFamilyById(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyRequest or GrpcRequestParameter cannot be null.");
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
            if (!_TerminalFamilyGrpcs.TerminalFamilyGrpcs.Any())
            {
                await PopulateTerminalFamilyData(cancellationToken);
            }

            _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
            List<TerminalFamilyGrpc> filteredList = _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredTerminalFamilyGrpcs.TerminalFamilyGrpcs.AddRange(filteredList);
            return _FilteredTerminalFamilyGrpcs;
        }

        public async Task<bool> CreateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalFamilyGrpcsToCreate == null || request.TerminalFamilyGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyGrpcRequest or TerminalFamilyGrpcsToCreate cannot be null or empty.");
            }

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalFamilyCommand>>();
                    TerminalFamilyCommand command = new TerminalFamilyCommand(CommandType.Create, request.TerminalFamilyGrpcsToCreate);

                    Result result = await _CommandTerminalFamilyHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalFamilyRefreshInProgress = true;
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalFamilyGrpcsToUpdate == null || request.TerminalFamilyGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyGrpcRequest or TerminalFamilyGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalFamilyCommand>>();
                    TerminalFamilyCommand command = new TerminalFamilyCommand(CommandType.Update, request.TerminalFamilyGrpcsToUpdate);

                    Result result = await _CommandTerminalFamilyHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalFamilyRefreshInProgress = true;
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
