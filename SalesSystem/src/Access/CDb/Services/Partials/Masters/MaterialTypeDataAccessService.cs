namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateMaterialTypeData(CancellationToken cancellationToken)
        {
            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialTypesQuery, List<MaterialTypeGrpc>>>();
                    _MaterialTypeRefreshInProgress = true;
                    GetMaterialTypesQuery query = new GetMaterialTypesQuery();
                    Result<List<MaterialTypeGrpc>> results = await _QueryMaterialTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.AddRange(results.Value);
                    }

                    _MaterialTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListMaterialTypeGrpc> ReadAllMaterialTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_MaterialTypeGrpcs.MaterialTypeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _MaterialTypeGrpcs;
                }

                ListMaterialTypeGrpc returnList = new ListMaterialTypeGrpc();
                IQueryable<MaterialTypeGrpc> query = _MaterialTypeGrpcs.MaterialTypeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.MaterialTypeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateMaterialTypeData(cancellationToken);
            return _MaterialTypeGrpcs;
        }

        public async Task<bool> CreateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.MaterialTypeGrpcsToCreate == null || request.MaterialTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeGrpcRequest or MaterialTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MaterialTypeCommand>>();
                    MaterialTypeCommand command = new MaterialTypeCommand(CommandType.Create, request.MaterialTypeGrpcsToCreate);

                    Result result = await _CommandMaterialTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MaterialTypeRefreshInProgress = true;
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.MaterialTypeGrpcsToUpdate == null || request.MaterialTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeGrpcRequest or MaterialTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MaterialTypeCommand>>();
                    MaterialTypeCommand command = new MaterialTypeCommand(CommandType.Update, request.MaterialTypeGrpcsToUpdate);

                    Result result = await _CommandMaterialTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MaterialTypeRefreshInProgress = true;
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
