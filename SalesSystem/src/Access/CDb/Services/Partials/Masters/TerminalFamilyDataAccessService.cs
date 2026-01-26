namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTerminalFamilyData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTerminalFamilysQuery, List<TerminalFamilyGrpc>>>();
                    _TerminalFamilyRefreshInProgress = true;
                    GetTerminalFamilysQuery query = new GetTerminalFamilysQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TerminalFamilyGrpc>> results = await _QueryTerminalFamilyHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.AddRange(results.Value);
                    }

                    _TerminalFamilyRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTerminalFamilyGrpc> ReadAllTerminalFamilys(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_TerminalFamilyGrpcs.TerminalFamilyGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _TerminalFamilyGrpcs;
                }

                ListTerminalFamilyGrpc returnList = new ListTerminalFamilyGrpc();
                IQueryable<TerminalFamilyGrpc> query = _TerminalFamilyGrpcs.TerminalFamilyGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.TerminalFamilyGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateTerminalFamilyData(cancellationToken);
            return _TerminalFamilyGrpcs;
        }

        public async Task<bool> CreateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalFamilyGrpcsToCreate == null || request.TerminalFamilyGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyGrpcRequest or TerminalFamilyGrpcsToCreate cannot be null or empty.");
            }

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalFamilyCommand>>();
                    TerminalFamilyCommand command = new TerminalFamilyCommand(CommandType.Create, request.TerminalFamilyGrpcsToCreate);

                    Result result = await _CommandTerminalFamilyHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalFamilyRefreshInProgress = true;
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalFamilyGrpcsToUpdate == null || request.TerminalFamilyGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalFamilyGrpcRequest or TerminalFamilyGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TerminalFamilyRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalFamilyHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalFamilyCommand>>();
                    TerminalFamilyCommand command = new TerminalFamilyCommand(CommandType.Update, request.TerminalFamilyGrpcsToUpdate);

                    Result result = await _CommandTerminalFamilyHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalFamilyRefreshInProgress = true;
                        _TerminalFamilyGrpcs.TerminalFamilyGrpcs.Clear();
                        _TerminalFamilyRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
