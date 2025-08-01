using CDb.CQRS.Command.Masters.CoverType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCoverTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_CoverTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryCoverTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCoverTypesQuery, List<CoverTypeGrpc>>>();
                    _CoverTypeRefreshInProgress = true;
                    GetCoverTypesQuery query = new GetCoverTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CoverTypeGrpc>> results = await _QueryCoverTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _CoverTypeGrpcs.CoverTypeGrpcs.Clear();
                        _CoverTypeGrpcs.CoverTypeGrpcs.AddRange(results.Value);
                    }

                    _CoverTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListCoverTypeGrpc> ReadAllCoverTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_CoverTypeGrpcs.CoverTypeGrpcs.Any())
            {
                await PopulateCoverTypeData(cancellationToken);
            }

            return _CoverTypeGrpcs;
        }

        public async Task<ListCoverTypeGrpc> ReadManyCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CoverTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_CoverTypeGrpcs.CoverTypeGrpcs.Any())
                    {
                        await PopulateCoverTypeData(cancellationToken);
                    }

                    _FilteredCoverTypeGrpcs.CoverTypeGrpcs.Clear();
                    List<CoverTypeGrpc> filteredList = _CoverTypeGrpcs.CoverTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredCoverTypeGrpcs.CoverTypeGrpcs.AddRange(filteredList);
                    return _FilteredCoverTypeGrpcs;
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
                    if (!_CoverTypeGrpcs.CoverTypeGrpcs.Any())
                    {
                        await PopulateCoverTypeData(cancellationToken);
                    }

                    _FilteredCoverTypeGrpcs.CoverTypeGrpcs.Clear();
                    List<CoverTypeGrpc> filteredList = _CoverTypeGrpcs.CoverTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredCoverTypeGrpcs.CoverTypeGrpcs.AddRange(filteredList);
                    return _FilteredCoverTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListCoverTypeGrpc> ReadCoverTypeById(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CoverTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_CoverTypeGrpcs.CoverTypeGrpcs.Any())
            {
                await PopulateCoverTypeData(cancellationToken);
            }

            _FilteredCoverTypeGrpcs.CoverTypeGrpcs.Clear();
            List<CoverTypeGrpc> filteredList = _CoverTypeGrpcs.CoverTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredCoverTypeGrpcs.CoverTypeGrpcs.AddRange(filteredList);
            return _FilteredCoverTypeGrpcs;
        }

        public async Task<bool> CreateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CoverTypeGrpcsToCreate == null || request.CoverTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CoverTypeGrpcRequest or CoverTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_CoverTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandCoverTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<CoverTypeCommand>>();
                    CoverTypeCommand command = new CoverTypeCommand(CommandType.Create, request.CoverTypeGrpcsToCreate);

                    Result result = await _CommandCoverTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CoverTypeRefreshInProgress = true;
                        _CoverTypeGrpcs.CoverTypeGrpcs.Clear();
                        _CoverTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CoverTypeGrpcsToUpdate == null || request.CoverTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CoverTypeGrpcRequest or CoverTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_CoverTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandCoverTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<CoverTypeCommand>>();
                    CoverTypeCommand command = new CoverTypeCommand(CommandType.Update, request.CoverTypeGrpcsToUpdate);

                    Result result = await _CommandCoverTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CoverTypeRefreshInProgress = true;
                        _CoverTypeGrpcs.CoverTypeGrpcs.Clear();
                        _CoverTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
