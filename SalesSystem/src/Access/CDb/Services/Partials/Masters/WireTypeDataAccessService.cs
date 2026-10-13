namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWireTypeData(CancellationToken cancellationToken)
        {
            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWireTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWireTypesQuery, List<WireTypeGrpc>>>();
                    _WireTypeRefreshInProgress = true;
                    GetWireTypesQuery query = new GetWireTypesQuery();
                    Result<List<WireTypeGrpc>> results = await _QueryWireTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeGrpcs.WireTypeGrpcs.AddRange(results.Value);
                    }

                    _WireTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWireTypeGrpc> ReadAllWireTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_WireTypeGrpcs.WireTypeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _WireTypeGrpcs;
                }

                ListWireTypeGrpc returnList = new ListWireTypeGrpc();
                IQueryable<WireTypeGrpc> query = _WireTypeGrpcs.WireTypeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.WireTypeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateWireTypeData(cancellationToken);
            return _WireTypeGrpcs;
        }
        public async Task<bool> CreateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.WireTypeGrpcsToCreate == null || request.WireTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeGrpcRequest or WireTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireTypeCommand>>();
                    WireTypeCommand command = new WireTypeCommand(CommandType.Create, request.WireTypeGrpcsToCreate);

                    Result result = await _CommandWireTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireTypeRefreshInProgress = true;
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.WireTypeGrpcsToUpdate == null || request.WireTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeGrpcRequest or WireTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireTypeCommand>>();
                    WireTypeCommand command = new WireTypeCommand(CommandType.Update, request.WireTypeGrpcsToUpdate);

                    Result result = await _CommandWireTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireTypeRefreshInProgress = true;
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
