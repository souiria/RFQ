using System.Threading;

namespace CDb.Services
{
    public class CDbAccessService : ICDbAccessService
    {
        #region In Memory Datasets

        ListClipTypeGrpc _ClipTypeGrpcs;
        ListClipTypeGrpc _FilteredClipTypeGrpcs;

        #endregion

        #region Fields and Properties
        bool _ClipTypeRefreshInProgress;
        #endregion

        readonly IServiceProvider _ServiceProvider;

        public CDbAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            _ClipTypeGrpcs = new ListClipTypeGrpc();
            _FilteredClipTypeGrpcs = new ListClipTypeGrpc();
            _ClipTypeRefreshInProgress = false;

            _ServiceProvider = serviceProvider;
            if (testing)
            {
                _ClipTypeGrpcs = SampleCDbAccessDataService.PopulateClipTypeSampleData();
            }
        }

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

        public async Task<ListClipTypeGrpc> GetAllClipTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_ClipTypeGrpcs.ClipTypeGrpcs.Any())
            {
                await PopulateClipTypeData(cancellationToken);
            }

            return _ClipTypeGrpcs;
        }

        public async Task<ListClipTypeGrpc> GetManyClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
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

        public async Task<ListClipTypeGrpc> GetClipTypeById(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken)
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
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a clip type by ID.");
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

            if (clipTypeRequest == null || clipTypeRequest.ClipTypeGrpcsToAdd == null || clipTypeRequest.ClipTypeGrpcsToAdd.Count == 0)
            {
                throw new ArgumentNullException(nameof(clipTypeRequest), "ClipTypeGrpcRequest or ClipTypeGrpcsToAdd cannot be null or empty.");
            }

            foreach (ClipTypeGrpc? clip in clipTypeRequest.ClipTypeGrpcsToAdd)
            {
                // for now, we just add a new clip type with a new ID into the cache
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
                // for now, we just add a new clip type with a new ID into the cache
                
                _ClipTypeGrpcs.ClipTypeGrpcs.Add(clip);
            }

            return _ClipTypeGrpcs;
        }
    }
}
