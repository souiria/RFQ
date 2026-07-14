namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTypeCodeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTypeCodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTypeCodesQuery, List<TypeCodeGrpc>>>();
                    _TypeCodeRefreshInProgress = true;
                    GetTypeCodesQuery query = new GetTypeCodesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TypeCodeGrpc>> results = await _QueryTypeCodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeGrpcs.TypeCodeGrpcs.AddRange(results.Value);
                    }

                    _TypeCodeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTypeCodeGrpc> ReadAllTypeCodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_TypeCodeGrpcs.TypeCodeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _TypeCodeGrpcs;
                }

                ListTypeCodeGrpc returnList = new ListTypeCodeGrpc();
                IQueryable<TypeCodeGrpc> query = _TypeCodeGrpcs.TypeCodeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.TypeCodeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateTypeCodeData(cancellationToken);
            return _TypeCodeGrpcs;
        }

        public async Task<bool> CreateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TypeCodeGrpcsToCreate == null || request.TypeCodeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeGrpcRequest or TypeCodeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTypeCodeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TypeCodeCommand>>();
                    TypeCodeCommand command = new TypeCodeCommand(CommandType.Create, request.TypeCodeGrpcsToCreate);

                    Result result = await _CommandTypeCodeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TypeCodeRefreshInProgress = true;
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TypeCodeGrpcsToUpdate == null || request.TypeCodeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeGrpcRequest or TypeCodeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTypeCodeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TypeCodeCommand>>();
                    TypeCodeCommand command = new TypeCodeCommand(CommandType.Update, request.TypeCodeGrpcsToUpdate);

                    Result result = await _CommandTypeCodeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TypeCodeRefreshInProgress = true;
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
