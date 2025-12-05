namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWaterproofTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWaterproofTypesQuery, List<WaterproofTypeGrpc>>>();
                    _WaterproofTypeRefreshInProgress = true;
                    GetWaterproofTypesQuery query = new GetWaterproofTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<WaterproofTypeGrpc>> results = await _QueryWaterproofTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.AddRange(results.Value);
                    }

                    _WaterproofTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWaterproofTypeGrpc> ReadAllWaterproofTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_WaterproofTypeGrpcs.WaterproofTypeGrpcs.Any())
            {
                await PopulateWaterproofTypeData(cancellationToken);
            }

            return _WaterproofTypeGrpcs;
        }

        public async Task<bool> CreateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WaterproofTypeGrpcsToCreate == null || request.WaterproofTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeGrpcRequest or WaterproofTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WaterproofTypeCommand>>();
                    WaterproofTypeCommand command = new WaterproofTypeCommand(CommandType.Create, request.WaterproofTypeGrpcsToCreate);

                    Result result = await _CommandWaterproofTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WaterproofTypeRefreshInProgress = true;
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WaterproofTypeGrpcsToUpdate == null || request.WaterproofTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeGrpcRequest or WaterproofTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WaterproofTypeCommand>>();
                    WaterproofTypeCommand command = new WaterproofTypeCommand(CommandType.Update, request.WaterproofTypeGrpcsToUpdate);

                    Result result = await _CommandWaterproofTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WaterproofTypeRefreshInProgress = true;
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
