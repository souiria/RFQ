namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulatePartnerData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_PartnerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryPartnerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartnersQuery, List<PartnerGrpc>>>();
                    _PartnerRefreshInProgress = true;
                    GetPartnersQuery query = new GetPartnersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartnerGrpc>> results = await _QueryPartnerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _PartnerGrpcs.PartnerGrpcs.Clear();
                        _PartnerGrpcs.PartnerGrpcs.AddRange(results.Value);
                    }

                    _PartnerRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListPartnerGrpc> ReadAllPartners(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartnerGrpcs.PartnerGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _PartnerGrpcs;
                }

                ListPartnerGrpc returnList = new ListPartnerGrpc();
                IQueryable<PartnerGrpc> query = _PartnerGrpcs.PartnerGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.PartnerGrpcs.AddRange(query);
                return returnList;
            }

            await PopulatePartnerData(cancellationToken);
            return _PartnerGrpcs;
        }

        public async Task<bool> CreatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PartnerGrpcsToCreate == null || request.PartnerGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartnerGrpcRequest or PartnerGrpcsToCreate cannot be null or empty.");
            }

            if (!_PartnerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartnerHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartnerCommand>>();
                    PartnerCommand command = new PartnerCommand(CommandType.Create, request.PartnerGrpcsToCreate);

                    Result result = await _CommandPartnerHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartnerRefreshInProgress = true;
                        _PartnerGrpcs.PartnerGrpcs.Clear();
                        _PartnerRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PartnerGrpcsToUpdate == null || request.PartnerGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PartnerGrpcRequest or PartnerGrpcsToUpdate cannot be null or empty.");
            }

            if (!_PartnerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPartnerHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PartnerCommand>>();
                    PartnerCommand command = new PartnerCommand(CommandType.Update, request.PartnerGrpcsToUpdate);

                    Result result = await _CommandPartnerHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PartnerRefreshInProgress = true;
                        _PartnerGrpcs.PartnerGrpcs.Clear();
                        _PartnerRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
