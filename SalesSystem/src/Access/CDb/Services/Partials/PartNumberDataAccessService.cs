namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulatePartNumberData(CancellationToken cancellationToken)
        {
            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryPartNumberHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartNumbersQuery, List<PartNumberGrpc>>>();
                    _PartNumberRefreshInProgress = true;
                    GetPartNumbersQuery query = new GetPartNumbersQuery();
                    Result<List<PartNumberGrpc>> results = await _QueryPartNumberHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberGrpcs.PartNumberGrpcs.AddRange(results.Value);
                    }

                    _PartNumberRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListPartNumberGrpc> ReadAllPartNumbers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartNumberGrpcs.PartNumberGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _PartNumberGrpcs;
                }

                ListPartNumberGrpc returnList = new ListPartNumberGrpc();
                IQueryable<PartNumberGrpc> query = _PartNumberGrpcs.PartNumberGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.PartNumberGrpcs.AddRange(query);
                return returnList;
            }

            await PopulatePartNumberData(cancellationToken);
            return _PartNumberGrpcs;
        }

        public async Task<bool> CreatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.PartNumberGrpcsToCreate == null || request.PartNumberGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToCreate cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Create, request.PartNumberGrpcsToCreate);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.PartNumberGrpcsToUpdate == null || request.PartNumberGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToUpdate cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Update, request.PartNumberGrpcsToUpdate);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
        public async Task<bool> DeletePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.PartNumberGrpcsToDelete == null || request.PartNumberGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartNumberGrpcRequest or PartNumberGrpcsToDelete cannot be null or empty.");
            }

            if (!_PartNumberRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartNumberHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartNumberCommand>>();
                    PartNumberCommand command = new PartNumberCommand(CommandType.Delete, request.PartNumberGrpcsToDelete);

                    Result result = await _CommandPartNumberHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartNumberRefreshInProgress = true;
                        _PartNumberGrpcs.PartNumberGrpcs.Clear();
                        _PartNumberRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
