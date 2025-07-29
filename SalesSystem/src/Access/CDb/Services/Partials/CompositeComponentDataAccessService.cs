namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateCompositeComponentData(CancellationToken cancellationToken)
        {
            // TBD: Implement database loading logic here.
            await Task.Delay(1, cancellationToken);

            if (!_CompositeComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    //_CompositeComponentHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCurrenciesQuery, List<CompositeComponentGrpc>>>();
                    //_CompositeComponentRefreshInProgress = true;
                    //GetCurrenciesQuery query = new GetCurrenciesQuery();
                    //await Task.Delay(1, cancellationToken);
                    //Result<List<CompositeComponentGrpc>> results = await _CompositeComponentHandler.Handle(query, cancellationToken);
                    //if (results.Value.Count <= 0)
                    //{
                    //}
                    //else
                    //{
                    //    _Currencies.CompositeComponentGrpc.Clear();
                    //    _Currencies.CompositeComponentGrpc.AddRange(results.Value);
                    //}

                    _CompositeComponentRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        public async Task<ListCompositeComponentGrpc> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToCreate == null || request.CompositeComponentGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToCreate cannot be null or empty.");
            }

            foreach (CompositeComponentGrpc? compositeComponent in request.CompositeComponentGrpcsToCreate)
            {
                // for now, we just add a new compositeComponent type with a new ID into the cache
                _CompositeComponentGrpcs.CompositeComponentGrpcs.Add(compositeComponent);
            }

            return _CompositeComponentGrpcs;
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

            _FilteredCompositeComponentGrpcs.CompositeComponentGrpcs.Clear();
            List<CompositeComponentGrpc> filteredList = _CompositeComponentGrpcs.CompositeComponentGrpcs.Where(x => x.ComponentGrpc.Id == id).ToList();
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

        public async Task<ListCompositeComponentGrpc> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToUpdate == null || request.CompositeComponentGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToUpdate cannot be null or empty.");
            }

            foreach (CompositeComponentGrpc? compositeComponent in request.CompositeComponentGrpcsToUpdate)
            {
                // for now, we just add a new compositeComponent type with a new ID into the cache
                CompositeComponentGrpc? existingCompositeComponent = _CompositeComponentGrpcs.CompositeComponentGrpcs.FirstOrDefault(x => x.ComponentGrpc.Id == compositeComponent.ComponentGrpc.Id);
                if (existingCompositeComponent == null)
                {
                    throw new KeyNotFoundException($"CompositeComponent with ID {compositeComponent.ComponentGrpc.Id} not found for update.");
                }

                // Update the existing compositeComponent
                _CompositeComponentGrpcs.CompositeComponentGrpcs.Remove(existingCompositeComponent);
                _CompositeComponentGrpcs.CompositeComponentGrpcs.Add(compositeComponent);
            }

            return _CompositeComponentGrpcs;
        }

        public async Task<ListCompositeComponentGrpc> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.CompositeComponentGrpcsToDelete == null || request.CompositeComponentGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentGrpcRequest or CompositeComponentGrpcsToDelete cannot be null or empty.");
            }

            foreach (CompositeComponentGrpc? compositeComponent in request.CompositeComponentGrpcsToDelete)
            {
                // for now, we just remove the compositeComponent type with the specified ID from the cache
                CompositeComponentGrpc? existingCompositeComponent = _CompositeComponentGrpcs.CompositeComponentGrpcs.FirstOrDefault(x => x.ComponentGrpc.Id == compositeComponent.ComponentGrpc.Id);
                if (existingCompositeComponent == null)
                {
                    throw new KeyNotFoundException($"CompositeComponent with ID {compositeComponent.ComponentGrpc.Id} not found for deletion.");
                }

                // Remove the existing compositeComponent
                _CompositeComponentGrpcs.CompositeComponentGrpcs.Remove(existingCompositeComponent);
            }

            return _CompositeComponentGrpcs;
        }
    }
}
