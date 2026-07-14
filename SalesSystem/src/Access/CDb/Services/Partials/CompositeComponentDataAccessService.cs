namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCompositeComponentData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryComponentHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetComponentsQuery, List<CompositeComponentGrpc>>>();
                    _CompositeComponentRefreshInProgress = true;
                    GetComponentsQuery query = new GetComponentsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CompositeComponentGrpc>> results = await _QueryComponentHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.AddRange(results.Value);
                    }

                    _CompositeComponentRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        public async Task<bool> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToCreate == null || request.CompositeComponentGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToCreate cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Create, request.CompositeComponentGrpcsToCreate);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<ListCompositeComponentGrpc> ReadAllCompositeComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_CompositeComponentGrpcs.CompositeComponentGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _CompositeComponentGrpcs;
                }

                ListCompositeComponentGrpc returnList = new ListCompositeComponentGrpc();
                IQueryable<CompositeComponentGrpc> query = _CompositeComponentGrpcs.CompositeComponentGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.CompositeComponentGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateCompositeComponentData(cancellationToken);
            return _CompositeComponentGrpcs;
        }

        public async Task<bool> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToUpdate == null || request.CompositeComponentGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToUpdate cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Update, request.CompositeComponentGrpcsToUpdate);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToDelete == null || request.CompositeComponentGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToDelete cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Delete, request.CompositeComponentGrpcsToDelete);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
