using CDb.CQRS.Command.Masters.ClipType;
using CDb.CQRS.Query.Masters.ClipType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateClipTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryClipTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetClipTypesQuery, List<ClipTypeGrpc>>>();
                    _ClipTypeRefreshInProgress = true;
                    GetClipTypesQuery query = new GetClipTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ClipTypeGrpc>> results = await _QueryClipTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeGrpcs.ClipTypeGrpcs.AddRange(results.Value);
                    }

                    _ClipTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListClipTypeGrpc> ReadAllClipTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
            {
                await PopulateClipTypeData(cancellationToken);
            }

            return _ClipTypeGrpcs;
        }

        public async Task<ListClipTypeGrpc> ReadManyClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
                    {
                        await PopulateClipTypeData(cancellationToken);
                    }

                    _FilteredClipTypeGrpcs.ClipTypeGrpcs.Clear();
                    List<ClipTypeGrpc> filteredList = _ClipTypeGrpcs.ClipTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredClipTypeGrpcs.ClipTypeGrpcs.AddRange(filteredList);
                    return _FilteredClipTypeGrpcs;
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
                    if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
                    {
                        await PopulateClipTypeData(cancellationToken);
                    }

                    _FilteredClipTypeGrpcs.ClipTypeGrpcs.Clear();
                    List<ClipTypeGrpc> filteredList = _ClipTypeGrpcs.ClipTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredClipTypeGrpcs.ClipTypeGrpcs.AddRange(filteredList);
                    return _FilteredClipTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListClipTypeGrpc> ReadClipTypeById(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
            {
                await PopulateClipTypeData(cancellationToken);
            }

            _FilteredClipTypeGrpcs.ClipTypeGrpcs.Clear();
            List<ClipTypeGrpc> filteredList = _ClipTypeGrpcs.ClipTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredClipTypeGrpcs.ClipTypeGrpcs.AddRange(filteredList);
            return _FilteredClipTypeGrpcs;
        }

        public async Task<bool> CreateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToCreate == null || request.ClipTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandClipTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ClipTypeCommand>>();
                    ClipTypeCommand command = new ClipTypeCommand(CommandType.Create, request.ClipTypeGrpcsToCreate);

                    Result result = await _CommandClipTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _ClipTypeRefreshInProgress = true;
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToUpdate == null || request.ClipTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandClipTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ClipTypeCommand>>();
                    ClipTypeCommand command = new ClipTypeCommand(CommandType.Update, request.ClipTypeGrpcsToUpdate);

                    Result result = await _CommandClipTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _ClipTypeRefreshInProgress = true;
                        _ClipTypeGrpcs.ClipTypeGrpcs.Clear();
                        _ClipTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
