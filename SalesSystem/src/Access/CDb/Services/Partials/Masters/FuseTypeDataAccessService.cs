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
