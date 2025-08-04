namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateWaterproofTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetWaterproofTypesQuery, List<WaterproofTypeGrpc>>>();
                    _WaterproofTypeRefreshInProgress = true;
                    GetWaterproofTypesQuery query = new GetWaterproofTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<WaterproofTypeGrpc>> results = await _QueryWaterproofTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.AddRange(results.Value);
                    }

                    _WaterproofTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListWaterproofTypeGrpc> ReadAllWaterproofTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_WaterproofTypeGrpcs.WaterproofTypeGrpcs.Any())
            {
                await PopulateWaterproofTypeData(cancellationToken);
            }

            return _WaterproofTypeGrpcs;
        }

        public async Task<ListWaterproofTypeGrpc> ReadManyWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_WaterproofTypeGrpcs.WaterproofTypeGrpcs.Any())
                    {
                        await PopulateWaterproofTypeData(cancellationToken);
                    }

                    _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                    List<WaterproofTypeGrpc> filteredList = _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.AddRange(filteredList);
                    return _FilteredWaterproofTypeGrpcs;
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
                    if (!_WaterproofTypeGrpcs.WaterproofTypeGrpcs.Any())
                    {
                        await PopulateWaterproofTypeData(cancellationToken);
                    }

                    _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                    List<WaterproofTypeGrpc> filteredList = _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.AddRange(filteredList);
                    return _FilteredWaterproofTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListWaterproofTypeGrpc> ReadWaterproofTypeById(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_WaterproofTypeGrpcs.WaterproofTypeGrpcs.Any())
            {
                await PopulateWaterproofTypeData(cancellationToken);
            }

            _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
            List<WaterproofTypeGrpc> filteredList = _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredWaterproofTypeGrpcs.WaterproofTypeGrpcs.AddRange(filteredList);
            return _FilteredWaterproofTypeGrpcs;
        }

        public async Task<bool> CreateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WaterproofTypeGrpcsToCreate == null || request.WaterproofTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeGrpcRequest or WaterproofTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WaterproofTypeCommand>>();
                    WaterproofTypeCommand command = new WaterproofTypeCommand(CommandType.Create, request.WaterproofTypeGrpcsToCreate);

                    Result result = await _CommandWaterproofTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WaterproofTypeRefreshInProgress = true;
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.WaterproofTypeGrpcsToUpdate == null || request.WaterproofTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "WaterproofTypeGrpcRequest or WaterproofTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_WaterproofTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandWaterproofTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<WaterproofTypeCommand>>();
                    WaterproofTypeCommand command = new WaterproofTypeCommand(CommandType.Update, request.WaterproofTypeGrpcsToUpdate);

                    Result result = await _CommandWaterproofTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _WaterproofTypeRefreshInProgress = true;
                        _WaterproofTypeGrpcs.WaterproofTypeGrpcs.Clear();
                        _WaterproofTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
