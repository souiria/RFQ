using CDb.CQRS.Command.Masters.TerminalSize;
using CDb.CQRS.Query.Masters.TerminalSize;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTerminalSizeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTerminalSizesQuery, List<TerminalSizeGrpc>>>();
                    _TerminalSizeRefreshInProgress = true;
                    GetTerminalSizesQuery query = new GetTerminalSizesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TerminalSizeGrpc>> results = await _QueryTerminalSizeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.AddRange(results.Value);
                    }

                    _TerminalSizeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTerminalSizeGrpc> ReadAllTerminalSizes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TerminalSizeGrpcs.TerminalSizeGrpcs.Any())
            {
                await PopulateTerminalSizeData(cancellationToken);
            }

            return _TerminalSizeGrpcs;
        }

        public async Task<ListTerminalSizeGrpc> ReadManyTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_TerminalSizeGrpcs.TerminalSizeGrpcs.Any())
                    {
                        await PopulateTerminalSizeData(cancellationToken);
                    }

                    _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                    List<TerminalSizeGrpc> filteredList = _TerminalSizeGrpcs.TerminalSizeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.AddRange(filteredList);
                    return _FilteredTerminalSizeGrpcs;
                }
                case RequestType.ReadByName:
                {
                    string name = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(name))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_TerminalSizeGrpcs.TerminalSizeGrpcs.Any())
                    {
                        await PopulateTerminalSizeData(cancellationToken);
                    }

                    _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                    List<TerminalSizeGrpc> filteredList = _TerminalSizeGrpcs.TerminalSizeGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.AddRange(filteredList);
                    return _FilteredTerminalSizeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListTerminalSizeGrpc> ReadTerminalSizeById(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_TerminalSizeGrpcs.TerminalSizeGrpcs.Any())
            {
                await PopulateTerminalSizeData(cancellationToken);
            }

            _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
            List<TerminalSizeGrpc> filteredList = _TerminalSizeGrpcs.TerminalSizeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredTerminalSizeGrpcs.TerminalSizeGrpcs.AddRange(filteredList);
            return _FilteredTerminalSizeGrpcs;
        }

        public async Task<bool> CreateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalSizeGrpcsToCreate == null || request.TerminalSizeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeGrpcRequest or TerminalSizeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalSizeCommand>>();
                    TerminalSizeCommand command = new TerminalSizeCommand(CommandType.Create, request.TerminalSizeGrpcsToCreate);

                    Result result = await _CommandTerminalSizeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalSizeRefreshInProgress = true;
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TerminalSizeGrpcsToUpdate == null || request.TerminalSizeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TerminalSizeGrpcRequest or TerminalSizeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TerminalSizeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTerminalSizeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TerminalSizeCommand>>();
                    TerminalSizeCommand command = new TerminalSizeCommand(CommandType.Update, request.TerminalSizeGrpcsToUpdate);

                    Result result = await _CommandTerminalSizeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TerminalSizeRefreshInProgress = true;
                        _TerminalSizeGrpcs.TerminalSizeGrpcs.Clear();
                        _TerminalSizeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
