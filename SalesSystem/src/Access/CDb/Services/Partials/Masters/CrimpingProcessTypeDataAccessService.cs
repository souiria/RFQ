namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCrimpingProcessTypeData(CancellationToken cancellationToken)
        {
            if (!_CrimpingProcessTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryCrimpingProcessTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCrimpingProcessTypesQuery, List<CrimpingProcessTypeGrpc>>>();
                    _CrimpingProcessTypeRefreshInProgress = true;
                    GetCrimpingProcessTypesQuery query = new GetCrimpingProcessTypesQuery();
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

        public async Task<ListCrimpingProcessTypeGrpc> ReadAllCrimpingProcessTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CrimpingProcessTypeGrpcs;
                }

                ListCrimpingProcessTypeGrpc returnList = new ListCrimpingProcessTypeGrpc();
                IQueryable<CrimpingProcessTypeGrpc> query = _CrimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CrimpingProcessTypeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateCrimpingProcessTypeData(cancellationToken);
            return _CrimpingProcessTypeGrpcs;
        }

        public async Task<bool> CreateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
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
