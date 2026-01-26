namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateMiscellaneousComponentTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_MiscellaneousComponentTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryMiscellaneousComponentTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMiscellaneousComponentTypesQuery, List<MiscellaneousComponentTypeGrpc>>>();
                    _MiscellaneousComponentTypeRefreshInProgress = true;
                    GetMiscellaneousComponentTypesQuery query = new GetMiscellaneousComponentTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MiscellaneousComponentTypeGrpc>> results = await _QueryMiscellaneousComponentTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
                        _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.AddRange(results.Value);
                    }

                    _MiscellaneousComponentTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListMiscellaneousComponentTypeGrpc> ReadAllMiscellaneousComponentTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _MiscellaneousComponentTypeGrpcs;
                }

                ListMiscellaneousComponentTypeGrpc returnList = new ListMiscellaneousComponentTypeGrpc();
                IQueryable<MiscellaneousComponentTypeGrpc> query = _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.MiscellaneousComponentTypeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateMiscellaneousComponentTypeData(cancellationToken);
            return _MiscellaneousComponentTypeGrpcs;
        }

        public async Task<bool> CreateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.MiscellaneousComponentTypeGrpcsToCreate == null || request.MiscellaneousComponentTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MiscellaneousComponentTypeGrpcRequest or MiscellaneousComponentTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_MiscellaneousComponentTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMiscellaneousComponentTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MiscellaneousComponentTypeCommand>>();
                    MiscellaneousComponentTypeCommand command = new MiscellaneousComponentTypeCommand(CommandType.Create, request.MiscellaneousComponentTypeGrpcsToCreate);

                    Result result = await _CommandMiscellaneousComponentTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MiscellaneousComponentTypeRefreshInProgress = true;
                        _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
                        _MiscellaneousComponentTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.MiscellaneousComponentTypeGrpcsToUpdate == null || request.MiscellaneousComponentTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MiscellaneousComponentTypeGrpcRequest or MiscellaneousComponentTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_MiscellaneousComponentTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMiscellaneousComponentTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MiscellaneousComponentTypeCommand>>();
                    MiscellaneousComponentTypeCommand command = new MiscellaneousComponentTypeCommand(CommandType.Update, request.MiscellaneousComponentTypeGrpcsToUpdate);

                    Result result = await _CommandMiscellaneousComponentTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MiscellaneousComponentTypeRefreshInProgress = true;
                        _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
                        _MiscellaneousComponentTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
