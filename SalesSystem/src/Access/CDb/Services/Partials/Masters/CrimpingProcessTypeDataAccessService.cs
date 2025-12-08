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
