using CDb.CQRS.Command.Masters.Partner;
using CDb.CQRS.Query.Masters.Partner;

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

        public async Task<ListPartnerGrpc> ReadAllPartners(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_PartnerGrpcs.PartnerGrpcs.Any())
            {
                await PopulatePartnerData(cancellationToken);
            }

            return _PartnerGrpcs;
        }

        public async Task<ListPartnerGrpc> ReadManyPartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PartnerRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            // either all actives or non actives
            switch (requestType)
            {
                case RequestType.ReadByIsActive:
                {
                    bool isActive = request.GrpcRequestParameter.BoolValue ?? false;
                    await Task.Delay(1, cancellationToken);
                    if (!_PartnerGrpcs.PartnerGrpcs.Any())
                    {
                        await PopulatePartnerData(cancellationToken);
                    }

                    _FilteredPartnerGrpcs.PartnerGrpcs.Clear();
                    List<PartnerGrpc> filteredList = _PartnerGrpcs.PartnerGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredPartnerGrpcs.PartnerGrpcs.AddRange(filteredList);
                    return _FilteredPartnerGrpcs;
                }
                case RequestType.ReadByCode:
                {
                    string code = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(code))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_PartnerGrpcs.PartnerGrpcs.Any())
                    {
                        await PopulatePartnerData(cancellationToken);
                    }

                    _FilteredPartnerGrpcs.PartnerGrpcs.Clear();
                    List<PartnerGrpc> filteredList = _PartnerGrpcs.PartnerGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredPartnerGrpcs.PartnerGrpcs.AddRange(filteredList);
                    return _FilteredPartnerGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListPartnerGrpc> ReadPartnerById(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PartnerRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.ReadById)
            {
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a compositeComponent type by ID.");
                throw new RpcException(status);
            }

            Guid id = request.GrpcRequestParameter.StringValue != null ? Guid.Parse(request.GrpcRequestParameter.StringValue) : Guid.Empty;
            if (id == Guid.Empty)
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid ID parameter value.");
                throw new RpcException(status);
            }

            await Task.Delay(1, cancellationToken);
            if (!_PartnerGrpcs.PartnerGrpcs.Any())
            {
                await PopulatePartnerData(cancellationToken);
            }

            _FilteredPartnerGrpcs.PartnerGrpcs.Clear();
            List<PartnerGrpc> filteredList = _PartnerGrpcs.PartnerGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredPartnerGrpcs.PartnerGrpcs.AddRange(filteredList);
            return _FilteredPartnerGrpcs;
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
