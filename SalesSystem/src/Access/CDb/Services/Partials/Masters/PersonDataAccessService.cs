namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulatePersonData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryPersonHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPersonsQuery, List<PersonGrpc>>>();
                    _PersonRefreshInProgress = true;
                    GetPersonsQuery query = new GetPersonsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PersonGrpc>> results = await _QueryPersonHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonGrpcs.PersonGrpcs.AddRange(results.Value);
                    }

                    _PersonRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListPersonGrpc> ReadAllPersons(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_PersonGrpcs.PersonGrpcs.Any())
            {
                await PopulatePersonData(cancellationToken);
            }

            return _PersonGrpcs;
        }
      
        public async Task<bool> CreatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PersonGrpcsToCreate == null || request.PersonGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PersonGrpcRequest or PersonGrpcsToCreate cannot be null or empty.");
            }

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPersonHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PersonCommand>>();
                    PersonCommand command = new PersonCommand(CommandType.Create, request.PersonGrpcsToCreate);

                    Result result = await _CommandPersonHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PersonRefreshInProgress = true;
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PersonGrpcsToUpdate == null || request.PersonGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PersonGrpcRequest or PersonGrpcsToUpdate cannot be null or empty.");
            }

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPersonHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PersonCommand>>();
                    PersonCommand command = new PersonCommand(CommandType.Update, request.PersonGrpcsToUpdate);

                    Result result = await _CommandPersonHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PersonRefreshInProgress = true;
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
