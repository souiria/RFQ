namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCompositeComponentData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryComponentHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetComponentsQuery, List<CompositeComponentGrpc>>>();
                    _CompositeComponentRefreshInProgress = true;
                    GetComponentsQuery query = new GetComponentsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CompositeComponentGrpc>> results = await _QueryComponentHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.AddRange(results.Value);
                    }

                    _CompositeComponentRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        public async Task<bool> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToCreate == null || request.CompositeComponentGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToCreate cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Create, request.CompositeComponentGrpcsToCreate);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<ListCompositeComponentGrpc> ReadAllCompositeComponents(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_CompositeComponentGrpcs.CompositeComponentGrpcs.Any())
            {
                await PopulateCompositeComponentData(cancellationToken);
            }

            return _CompositeComponentGrpcs;
        }

        public Task<ListCompositeComponentGrpc> ReadManyCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ListCompositeComponentGrpc> ReadCompositeComponentsById(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentRequest or GrpcRequestParameter cannot be null.");
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
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a composite component by id.");
                throw new RpcException(status);
            }

            string id = request.GrpcRequestParameter.StringValue;
            if (string.IsNullOrEmpty(id))
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid IntValue parameter value.");
                throw new RpcException(status);
            }

            if (!_CompositeComponentGrpcs.CompositeComponentGrpcs.Any())
            {
                await PopulateCompositeComponentData(cancellationToken);
            }

            System.Globalization.CultureInfo invariantCulture = System.Globalization.CultureInfo.InvariantCulture;   
            _FilteredCompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
            List<CompositeComponentGrpc> filteredList = _CompositeComponentGrpcs.CompositeComponentGrpcs.Where(x => x.ComponentGrpc.Id.ToUpper(invariantCulture) == id.ToUpper(invariantCulture)).ToList();
            _FilteredCompositeComponentGrpcs.CompositeComponentGrpcs.AddRange(filteredList);
            return _FilteredCompositeComponentGrpcs;
        }

        public async Task<ListCompositeComponentGrpc> ReadCompositeComponentsBySheetNumber(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentRequest or GrpcRequestParameter cannot be null.");
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

            if (requestType != RequestType.ReadByComponentSheetNumber)
            {
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadByComponentSheetNumber to get a composite component by sheet number.");
                throw new RpcException(status);
            }

            int sheetNumber = request.GrpcRequestParameter.IntValue ?? 0;
            if (sheetNumber <= 0)
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid IntValue parameter value.");
                throw new RpcException(status);
            }

            if (!_CompositeComponentGrpcs.CompositeComponentGrpcs.Any())
            {
                await PopulateCompositeComponentData(cancellationToken);
            }

            _FilteredCompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
            List<CompositeComponentGrpc> filteredList = _CompositeComponentGrpcs.CompositeComponentGrpcs.Where(x => x.ComponentGrpc.SheetNumber == sheetNumber).ToList();
            _FilteredCompositeComponentGrpcs.CompositeComponentGrpcs.AddRange(filteredList);
            return _FilteredCompositeComponentGrpcs;
        }

        public async Task<bool> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToUpdate == null || request.CompositeComponentGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToUpdate cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Update, request.CompositeComponentGrpcsToUpdate);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToDelete == null || request.CompositeComponentGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToDelete cannot be null or empty.");
            }

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandComponentHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ComponentCommand>>();
                    ComponentCommand command = new ComponentCommand(CommandType.Delete, request.CompositeComponentGrpcsToDelete);

                    Result result = await _CommandComponentHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _CompositeComponentRefreshInProgress = true;
                        _CompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
                        _CompositeComponentRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
