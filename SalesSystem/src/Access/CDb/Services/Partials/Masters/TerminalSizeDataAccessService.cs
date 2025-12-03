namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTerminalSizeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTerminalSizesQuery, List<TerminalSizeGrpc>>>();
                    _TerminalSizeRefreshInProgress = true;
                    GetTerminalSizesQuery query = new GetTerminalSizesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TerminalSizeGrpc>> results = await _QueryTerminalSizeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.AddRange(results.Value);
                    }

                    _TerminalSizeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTerminalSizeGrpc> ReadAllTerminalSizes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TerminalSizeGrpcs.TerminalSizeGrpcs.Any())
            {
                await PopulateTerminalSizeData(cancellationToken);
            }

            return _TerminalSizeGrpcs;
        }

        public async Task<bool> CreateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalSizeGrpcsToCreate == null || request.TerminalSizeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeGrpcRequest or TerminalSizeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalSizeCommand>>();
                    TerminalSizeCommand command = new TerminalSizeCommand(CommandType.Create, request.TerminalSizeGrpcsToCreate);

                    Result result = await _CommandTerminalSizeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalSizeRefreshInProgress = true;
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalSizeGrpcsToUpdate == null || request.TerminalSizeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeGrpcRequest or TerminalSizeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalSizeCommand>>();
                    TerminalSizeCommand command = new TerminalSizeCommand(CommandType.Update, request.TerminalSizeGrpcsToUpdate);

                    Result result = await _CommandTerminalSizeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalSizeRefreshInProgress = true;
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
