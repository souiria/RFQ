namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateClipTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryClipTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetClipTypesQuery, List<ClipTypeGrpc>>>();
                    _ClipTypeRefreshInProgress = true;
                    GetClipTypesQuery query = new GetClipTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ClipTypeGrpc>> results = await _QueryClipTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeGrpcs.ClipTypeGrpcs.AddRange(results.Value);
                    }

                    _ClipTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListClipTypeGrpc> ReadAllClipTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
            {
                await PopulateClipTypeData(cancellationToken);
            }

            return _ClipTypeGrpcs;
        }

        public async Task<bool> CreateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToCreate == null || request.ClipTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandClipTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ClipTypeCommand>>();
                    ClipTypeCommand command = new ClipTypeCommand(CommandType.Create, request.ClipTypeGrpcsToCreate);

                    Result result = await _CommandClipTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _ClipTypeRefreshInProgress = true;
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToUpdate == null || request.ClipTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandClipTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ClipTypeCommand>>();
                    ClipTypeCommand command = new ClipTypeCommand(CommandType.Update, request.ClipTypeGrpcsToUpdate);

                    Result result = await _CommandClipTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _ClipTypeRefreshInProgress = true;
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
