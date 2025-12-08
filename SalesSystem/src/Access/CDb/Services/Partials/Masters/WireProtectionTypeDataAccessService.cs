namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWireProtectionTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWireProtectionTypesQuery, List<WireProtectionTypeGrpc>>>();
                    _WireProtectionTypeRefreshInProgress = true;
                    GetWireProtectionTypesQuery query = new GetWireProtectionTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<WireProtectionTypeGrpc>> results = await _QueryWireProtectionTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.AddRange(results.Value);
                    }

                    _WireProtectionTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWireProtectionTypeGrpc> ReadAllWireProtectionTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Any())
            {
                await PopulateWireProtectionTypeData(cancellationToken);
            }

            return _WireProtectionTypeGrpcs;
        }

        public async Task<bool> CreateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireProtectionTypeGrpcsToCreate == null || request.WireProtectionTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeGrpcRequest or WireProtectionTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireProtectionTypeCommand>>();
                    WireProtectionTypeCommand command = new WireProtectionTypeCommand(CommandType.Create, request.WireProtectionTypeGrpcsToCreate);

                    Result result = await _CommandWireProtectionTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireProtectionTypeRefreshInProgress = true;
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireProtectionTypeGrpcsToUpdate == null || request.WireProtectionTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeGrpcRequest or WireProtectionTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireProtectionTypeCommand>>();
                    WireProtectionTypeCommand command = new WireProtectionTypeCommand(CommandType.Update, request.WireProtectionTypeGrpcsToUpdate);

                    Result result = await _CommandWireProtectionTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireProtectionTypeRefreshInProgress = true;
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
