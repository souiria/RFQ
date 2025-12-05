namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTemperatureRangeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTemperatureRangesQuery, List<TemperatureRangeGrpc>>>();
                    _TemperatureRangeRefreshInProgress = true;
                    GetTemperatureRangesQuery query = new GetTemperatureRangesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TemperatureRangeGrpc>> results = await _QueryTemperatureRangeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.AddRange(results.Value);
                    }

                    _TemperatureRangeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTemperatureRangeGrpc> ReadAllTemperatureRanges(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TemperatureRangeGrpcs.TemperatureRangeGrpcs.Any())
            {
                await PopulateTemperatureRangeData(cancellationToken);
            }

            return _TemperatureRangeGrpcs;
        }

        public async Task<bool> CreateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TemperatureRangeGrpcsToCreate == null || request.TemperatureRangeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeGrpcRequest or TemperatureRangeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TemperatureRangeCommand>>();
                    TemperatureRangeCommand command = new TemperatureRangeCommand(CommandType.Create, request.TemperatureRangeGrpcsToCreate);

                    Result result = await _CommandTemperatureRangeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TemperatureRangeRefreshInProgress = true;
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TemperatureRangeGrpcsToUpdate == null || request.TemperatureRangeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeGrpcRequest or TemperatureRangeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TemperatureRangeCommand>>();
                    TemperatureRangeCommand command = new TemperatureRangeCommand(CommandType.Update, request.TemperatureRangeGrpcsToUpdate);

                    Result result = await _CommandTemperatureRangeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TemperatureRangeRefreshInProgress = true;
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
