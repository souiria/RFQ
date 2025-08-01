using CDb.CQRS.Command.Masters.WireType;
using CDb.CQRS.Query.Masters.WireType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWireTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWireTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWireTypesQuery, List<WireTypeGrpc>>>();
                    _WireTypeRefreshInProgress = true;
                    GetWireTypesQuery query = new GetWireTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<WireTypeGrpc>> results = await _QueryWireTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeGrpcs.WireTypeGrpcs.AddRange(results.Value);
                    }

                    _WireTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWireTypeGrpc> ReadAllWireTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_WireTypeGrpcs.WireTypeGrpcs.Any())
            {
                await PopulateWireTypeData(cancellationToken);
            }

            return _WireTypeGrpcs;
        }

        public async Task<ListWireTypeGrpc> ReadManyWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_WireTypeGrpcs.WireTypeGrpcs.Any())
                    {
                        await PopulateWireTypeData(cancellationToken);
                    }

                    _FilteredWireTypeGrpcs.WireTypeGrpcs.Clear();
                    List<WireTypeGrpc> filteredList = _WireTypeGrpcs.WireTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredWireTypeGrpcs.WireTypeGrpcs.AddRange(filteredList);
                    return _FilteredWireTypeGrpcs;
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
                    if (!_WireTypeGrpcs.WireTypeGrpcs.Any())
                    {
                        await PopulateWireTypeData(cancellationToken);
                    }

                    _FilteredWireTypeGrpcs.WireTypeGrpcs.Clear();
                    List<WireTypeGrpc> filteredList = _WireTypeGrpcs.WireTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredWireTypeGrpcs.WireTypeGrpcs.AddRange(filteredList);
                    return _FilteredWireTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListWireTypeGrpc> ReadWireTypeById(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_WireTypeGrpcs.WireTypeGrpcs.Any())
            {
                await PopulateWireTypeData(cancellationToken);
            }

            _FilteredWireTypeGrpcs.WireTypeGrpcs.Clear();
            List<WireTypeGrpc> filteredList = _WireTypeGrpcs.WireTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredWireTypeGrpcs.WireTypeGrpcs.AddRange(filteredList);
            return _FilteredWireTypeGrpcs;
        }

        public async Task<bool> CreateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireTypeGrpcsToCreate == null || request.WireTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeGrpcRequest or WireTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireTypeCommand>>();
                    WireTypeCommand command = new WireTypeCommand(CommandType.Create, request.WireTypeGrpcsToCreate);

                    Result result = await _CommandWireTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireTypeRefreshInProgress = true;
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireTypeGrpcsToUpdate == null || request.WireTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireTypeGrpcRequest or WireTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WireTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireTypeCommand>>();
                    WireTypeCommand command = new WireTypeCommand(CommandType.Update, request.WireTypeGrpcsToUpdate);

                    Result result = await _CommandWireTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireTypeRefreshInProgress = true;
                        _WireTypeGrpcs.WireTypeGrpcs.Clear();
                        _WireTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
