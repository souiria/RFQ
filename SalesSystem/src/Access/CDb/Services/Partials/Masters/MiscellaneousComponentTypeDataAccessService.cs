using CDb.CQRS.Command.Masters.MiscellaneousComponentType;
using CDb.CQRS.Query.Masters.MiscellaneousComponent;

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

        public async Task<ListMiscellaneousComponentTypeGrpc> ReadAllMiscellaneousComponentTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Any())
            {
                await PopulateMiscellaneousComponentTypeData(cancellationToken);
            }

            return _MiscellaneousComponentTypeGrpcs;
        }

        public async Task<ListMiscellaneousComponentTypeGrpc> ReadManyMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "MiscellaneousComponentTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Any())
                    {
                        await PopulateMiscellaneousComponentTypeData(cancellationToken);
                    }

                    _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
                    List<MiscellaneousComponentTypeGrpc> filteredList = _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.AddRange(filteredList);
                    return _FilteredMiscellaneousComponentTypeGrpcs;
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
                    if (!_MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Any())
                    {
                        await PopulateMiscellaneousComponentTypeData(cancellationToken);
                    }

                    _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
                    List<MiscellaneousComponentTypeGrpc> filteredList = _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.AddRange(filteredList);
                    return _FilteredMiscellaneousComponentTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListMiscellaneousComponentTypeGrpc> ReadMiscellaneousComponentTypeById(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "MiscellaneousComponentTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Any())
            {
                await PopulateMiscellaneousComponentTypeData(cancellationToken);
            }

            _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Clear();
            List<MiscellaneousComponentTypeGrpc> filteredList = _MiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredMiscellaneousComponentTypeGrpcs.MiscellaneousComponentTypeGrpcs.AddRange(filteredList);
            return _FilteredMiscellaneousComponentTypeGrpcs;
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
