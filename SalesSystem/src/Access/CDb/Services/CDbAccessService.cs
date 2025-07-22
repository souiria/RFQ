using System.Threading;

namespace CDb.Services
{
    public class CDbAccessService : ICDbAccessService
    {
        #region In Memory Datasets

        ListClipTypeGrpc _ClipTypeGrpcs;
        ListClipTypeGrpc _FilteredClipTypeGrpcs;

        ListCompositeComponentGrpc _CompositeComponentGrpcs;
        ListCompositeComponentGrpc _FilteredCompositeComponentGrpcs;
        #endregion

        #region Fields and Properties
        bool _ClipTypeRefreshInProgress;
        bool _CompositeComponentRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;

        public CDbAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            _ClipTypeGrpcs = new ListClipTypeGrpc();
            _FilteredClipTypeGrpcs = new ListClipTypeGrpc();
            _CompositeComponentGrpcs = new ListCompositeComponentGrpc();
            _FilteredCompositeComponentGrpcs = new ListCompositeComponentGrpc();

            _ClipTypeRefreshInProgress = false;
            _CompositeComponentRefreshInProgress = false;

            _ServiceProvider = serviceProvider;
            if (testing)
            {
                _ClipTypeGrpcs = SampleCDbAccessDataService.PopulateClipTypeSampleData();
                _CompositeComponentGrpcs = SampleCDbAccessDataService.PopulateCompositeComponentSampleData();
            }
        }

        #region ClipType
        async Task<bool> PopulateClipTypeData(CancellationToken cancellationToken)
        {
            // TBD: Implement database loading logic here.
            await Task.Delay(1, cancellationToken);

            if (!_ClipTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    //_ClipTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCurrenciesQuery, List<ClipTypeGrpc>>>();
                    //_ClipTypeRefreshInProgress = true;
                    //GetCurrenciesQuery query = new GetCurrenciesQuery();
                    //await Task.Delay(1, cancellationToken);
                    //Result<List<ClipTypeGrpc>> results = await _ClipTypeHandler.Handle(query, cancellationToken);
                    //if (results.Value.Count <= 0)
                    //{
                    //}
                    //else
                    //{
                    //    _Currencies.ClipTypeGrpc.Clear();
                    //    _Currencies.ClipTypeGrpc.AddRange(results.Value);
                    //}

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

        public async Task<ListClipTypeGrpc> ReadManyClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (clipTypeRequest == null || clipTypeRequest.RequestParameter == null)
            {
                throw new ArgumentNullException(nameof(clipTypeRequest), "ClipTypeRequest or RequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), clipTypeRequest.RequestParameter.RequestType))
            {
                requestType = (RequestType)clipTypeRequest.RequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            // either all actives or non actives
            switch(requestType)
            {
                case RequestType.ReadByIsActive:
                {
                    bool isActive = clipTypeRequest.RequestParameter.BoolValue ?? false;
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
                default:
                    status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                    throw new RpcException(status);
            }   
        }

        public async Task<ListClipTypeGrpc> ReadClipTypeById(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (clipTypeRequest == null || clipTypeRequest.RequestParameter == null)
            {
                throw new ArgumentNullException(nameof(clipTypeRequest), "ClipTypeRequest or RequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), clipTypeRequest.RequestParameter.RequestType))
            {
                requestType = (RequestType)clipTypeRequest.RequestParameter.RequestType;
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

            Guid id = clipTypeRequest.RequestParameter.StringValue != null ? Guid.Parse(clipTypeRequest.RequestParameter.StringValue) : Guid.Empty;
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

        public async Task<ListClipTypeGrpc> CreateClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (clipTypeRequest == null || clipTypeRequest.ClipTypeGrpcsToCreate == null || clipTypeRequest.ClipTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(clipTypeRequest), "ClipTypeGrpcRequest or ClipTypeGrpcsToCreate cannot be null or empty.");
            }

            foreach (ClipTypeGrpc? clip in clipTypeRequest.ClipTypeGrpcsToCreate)
            {
                // for now, we just add a new compositeComponent type with a new ID into the cache
                clip.Id = Guid.NewGuid().ToString();
                _ClipTypeGrpcs.ClipTypeGrpcs.Add(clip);
            }

            return _ClipTypeGrpcs;
        }

        public async Task<ListClipTypeGrpc> UpdateClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (clipTypeRequest == null || clipTypeRequest.ClipTypeGrpcsToUpdate == null || clipTypeRequest.ClipTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(clipTypeRequest), "ClipTypeGrpcRequest or ClipTypeGrpcsToUpdate cannot be null or empty.");
            }

            foreach (ClipTypeGrpc? clip in clipTypeRequest.ClipTypeGrpcsToUpdate)
            {
                // for now, we just add a new compositeComponent type with a new ID into the cache
                ClipTypeGrpc? existingClip = _ClipTypeGrpcs.ClipTypeGrpcs.FirstOrDefault(x => x.Id == clip.Id);
                if (existingClip == null)
                {
                    throw new KeyNotFoundException($"ClipType with ID {clip.Id} not found for update.");
                }

                // Update the existing compositeComponent type with the new values
                existingClip.Code = clip.Code;
                existingClip.Description = clip.Description;
                existingClip.IsActive = clip.IsActive;
            }

            return _ClipTypeGrpcs;
        }

        #endregion

        #region CompositeComponent
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

            if (request == null || request.RequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentRequest or RequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RequestParameter.RequestType))
            {
                requestType = (RequestType)request.RequestParameter.RequestType;
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

            string id = request.RequestParameter.StringValue;
            if (string.IsNullOrEmpty(id) )
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

            if (request == null || request.RequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "CompositeComponentRequest or RequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.RequestParameter.RequestType))
            {
                requestType = (RequestType)request.RequestParameter.RequestType;
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

            int sheetNumber = request.RequestParameter.IntValue ?? 0;
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

        #endregion
    }
}
