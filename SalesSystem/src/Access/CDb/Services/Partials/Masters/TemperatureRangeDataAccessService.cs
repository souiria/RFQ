namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTemperatureRangeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTemperatureRangesQuery, List<TemperatureRangeGrpc>>>();
                    _TemperatureRangeRefreshInProgress = true;
                    GetTemperatureRangesQuery query = new GetTemperatureRangesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TemperatureRangeGrpc>> results = await _QueryTemperatureRangeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.AddRange(results.Value);
                    }

                    _TemperatureRangeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTemperatureRangeGrpc> ReadAllTemperatureRanges(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TemperatureRangeGrpcs.TemperatureRangeGrpcs.Any())
            {
                await PopulateTemperatureRangeData(cancellationToken);
            }

            return _TemperatureRangeGrpcs;
        }

        public async Task<ListTemperatureRangeGrpc> ReadManyTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeRequest or GrpcRequestParameter cannot be null.");
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
                case RequestType.ReadByIsCustom:
                {
                    bool isCustom = request.GrpcRequestParameter.BoolValue ?? false;
                    await Task.Delay(1, cancellationToken);
                    if (!_TemperatureRangeGrpcs.TemperatureRangeGrpcs.Any())
                    {
                        await PopulateTemperatureRangeData(cancellationToken);
                    }

                    _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                    List<TemperatureRangeGrpc> filteredList = _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Where(x => x.IsCustom == isCustom).ToList();
                    _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.AddRange(filteredList);
                    return _FilteredTemperatureRangeGrpcs;
                }
                case RequestType.ReadByCode:
                {
                    string temperatureRange = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(temperatureRange))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_TemperatureRangeGrpcs.TemperatureRangeGrpcs.Any())
                    {
                        await PopulateTemperatureRangeData(cancellationToken);
                    }

                    _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                    List<TemperatureRangeGrpc> filteredList = _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Where(x => x.TemperatureRange == temperatureRange).ToList();
                    _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.AddRange(filteredList);
                    return _FilteredTemperatureRangeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListTemperatureRangeGrpc> ReadTemperatureRangeById(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_TemperatureRangeGrpcs.TemperatureRangeGrpcs.Any())
            {
                await PopulateTemperatureRangeData(cancellationToken);
            }

            _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
            List<TemperatureRangeGrpc> filteredList = _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredTemperatureRangeGrpcs.TemperatureRangeGrpcs.AddRange(filteredList);
            return _FilteredTemperatureRangeGrpcs;
        }

        public async Task<bool> CreateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TemperatureRangeGrpcsToCreate == null || request.TemperatureRangeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeGrpcRequest or TemperatureRangeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TemperatureRangeCommand>>();
                    TemperatureRangeCommand command = new TemperatureRangeCommand(CommandType.Create, request.TemperatureRangeGrpcsToCreate);

                    Result result = await _CommandTemperatureRangeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TemperatureRangeRefreshInProgress = true;
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TemperatureRangeGrpcsToUpdate == null || request.TemperatureRangeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TemperatureRangeGrpcRequest or TemperatureRangeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TemperatureRangeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTemperatureRangeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TemperatureRangeCommand>>();
                    TemperatureRangeCommand command = new TemperatureRangeCommand(CommandType.Update, request.TemperatureRangeGrpcsToUpdate);

                    Result result = await _CommandTemperatureRangeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TemperatureRangeRefreshInProgress = true;
                        _TemperatureRangeGrpcs.TemperatureRangeGrpcs.Clear();
                        _TemperatureRangeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
