using CDb.CQRS.Command.Masters.WireProtectionType;
using CDb.CQRS.Query.Masters.WireProtectionType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWireProtectionTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWireProtectionTypesQuery, List<WireProtectionTypeGrpc>>>();
                    _WireProtectionTypeRefreshInProgress = true;
                    GetWireProtectionTypesQuery query = new GetWireProtectionTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<WireProtectionTypeGrpc>> results = await _QueryWireProtectionTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.AddRange(results.Value);
                    }

                    _WireProtectionTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWireProtectionTypeGrpc> ReadAllWireProtectionTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Any())
            {
                await PopulateWireProtectionTypeData(cancellationToken);
            }

            return _WireProtectionTypeGrpcs;
        }

        public async Task<ListWireProtectionTypeGrpc> ReadManyWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Any())
                    {
                        await PopulateWireProtectionTypeData(cancellationToken);
                    }

                    _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                    List<WireProtectionTypeGrpc> filteredList = _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.AddRange(filteredList);
                    return _FilteredWireProtectionTypeGrpcs;
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
                    if (!_WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Any())
                    {
                        await PopulateWireProtectionTypeData(cancellationToken);
                    }

                    _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                    List<WireProtectionTypeGrpc> filteredList = _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.AddRange(filteredList);
                    return _FilteredWireProtectionTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListWireProtectionTypeGrpc> ReadWireProtectionTypeById(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Any())
            {
                await PopulateWireProtectionTypeData(cancellationToken);
            }

            _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
            List<WireProtectionTypeGrpc> filteredList = _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredWireProtectionTypeGrpcs.WireProtectionTypeGrpcs.AddRange(filteredList);
            return _FilteredWireProtectionTypeGrpcs;
        }

        public async Task<bool> CreateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireProtectionTypeGrpcsToCreate == null || request.WireProtectionTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeGrpcRequest or WireProtectionTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireProtectionTypeCommand>>();
                    WireProtectionTypeCommand command = new WireProtectionTypeCommand(CommandType.Create, request.WireProtectionTypeGrpcsToCreate);

                    Result result = await _CommandWireProtectionTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireProtectionTypeRefreshInProgress = true;
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WireProtectionTypeGrpcsToUpdate == null || request.WireProtectionTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WireProtectionTypeGrpcRequest or WireProtectionTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WireProtectionTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWireProtectionTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WireProtectionTypeCommand>>();
                    WireProtectionTypeCommand command = new WireProtectionTypeCommand(CommandType.Update, request.WireProtectionTypeGrpcsToUpdate);

                    Result result = await _CommandWireProtectionTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WireProtectionTypeRefreshInProgress = true;
                        _WireProtectionTypeGrpcs.WireProtectionTypeGrpcs.Clear();
                        _WireProtectionTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
