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
            switch(requestType)
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

        public async Task<ListClipTypeGrpc> CreateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToCreate == null || request.ClipTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToCreate cannot be null or empty.");
            }

            foreach (ClipTypeGrpc? clip in request.ClipTypeGrpcsToCreate)
            {
                // for now, we just add a new compositeComponent type with a new ID into the cache
                clip.Id = Guid.NewGuid().ToString();
                _ClipTypeGrpcs.ClipTypeGrpcs.Add(clip);
            }

            return _ClipTypeGrpcs;
        }

        public async Task<ListClipTypeGrpc> UpdateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.ClipTypeGrpcsToUpdate == null || request.ClipTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "ClipTypeGrpcRequest or ClipTypeGrpcsToUpdate cannot be null or empty.");
            }

            foreach (ClipTypeGrpc? clip in request.ClipTypeGrpcsToUpdate)
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

        public Task<ListCoverTypeGrpc> ReadAllCoverTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCoverTypeGrpc> ReadManyCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCoverTypeGrpc> ReadCoverTypeById(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCoverTypeGrpc> CreateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCoverTypeGrpc> UpdateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCrimpingProcessTypeGrpc> ReadAllCrimpingProcessTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCrimpingProcessTypeGrpc> ReadManyCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCrimpingProcessTypeGrpc> ReadCrimpingProcessTypeById(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCrimpingProcessTypeGrpc> CreateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListCrimpingProcessTypeGrpc> UpdateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileTypeGrpc> ReadAllFileTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileTypeGrpc> ReadManyFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileTypeGrpc> ReadFileTypeById(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileTypeGrpc> CreateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileTypeGrpc> UpdateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFuseTypeGrpc> ReadAllFuseTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFuseTypeGrpc> ReadManyFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFuseTypeGrpc> ReadFuseTypeById(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFuseTypeGrpc> CreateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFuseTypeGrpc> UpdateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMaterialTypeGrpc> ReadAllMaterialTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMaterialTypeGrpc> ReadManyMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMaterialTypeGrpc> ReadMaterialTypeById(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMaterialTypeGrpc> CreateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMaterialTypeGrpc> UpdateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMiscellaneousComponentTypeGrpc> ReadAllMiscellaneousComponentTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMiscellaneousComponentTypeGrpc> ReadManyMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMiscellaneousComponentTypeGrpc> ReadMiscellaneousComponentTypeById(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMiscellaneousComponentTypeGrpc> CreateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListMiscellaneousComponentTypeGrpc> UpdateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartnerGrpc> ReadAllPartners(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartnerGrpc> ReadManyPartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartnerGrpc> ReadPartnerById(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartnerGrpc> CreatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartnerGrpc> UpdatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPersonGrpc> ReadAllPersons(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPersonGrpc> ReadManyPersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPersonGrpc> ReadPersonById(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPersonGrpc> CreatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPersonGrpc> UpdatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTemperatureRangeGrpc> ReadAllTemperatureRanges(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTemperatureRangeGrpc> ReadManyTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTemperatureRangeGrpc> ReadTemperatureRangeById(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTemperatureRangeGrpc> CreateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTemperatureRangeGrpc> UpdateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalFamilyGrpc> ReadAllTerminalFamilys(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalFamilyGrpc> ReadManyTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalFamilyGrpc> ReadTerminalFamilyById(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalFamilyGrpc> CreateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalFamilyGrpc> UpdateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalSizeGrpc> ReadAllTerminalSizes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalSizeGrpc> ReadManyTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalSizeGrpc> ReadTerminalSizeById(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalSizeGrpc> CreateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTerminalSizeGrpc> UpdateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTypeCodeGrpc> ReadAllTypeCodes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTypeCodeGrpc> ReadManyTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTypeCodeGrpc> ReadTypeCodeById(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTypeCodeGrpc> CreateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTypeCodeGrpc> UpdateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWaterproofTypeGrpc> ReadAllWaterproofTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWaterproofTypeGrpc> ReadManyWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWaterproofTypeGrpc> ReadWaterproofTypeById(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWaterproofTypeGrpc> CreateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWaterproofTypeGrpc> UpdateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireProtectionTypeGrpc> ReadAllWireProtectionTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireProtectionTypeGrpc> ReadManyWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireProtectionTypeGrpc> ReadWireProtectionTypeById(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireProtectionTypeGrpc> CreateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireProtectionTypeGrpc> UpdateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireTypeGrpc> ReadAllWireTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireTypeGrpc> ReadManyWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireTypeGrpc> ReadWireTypeById(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireTypeGrpc> CreateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListWireTypeGrpc> UpdateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileNameGrpc> ReadAllFileNames(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileNameGrpc> ReadManyFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileNameGrpc> ReadFileNameById(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileNameGrpc> CreateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListFileNameGrpc> UpdateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartNumberGrpc> GetAllPartNumbers(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartNumberGrpc> GetManyPartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PartNumberGrpc> GetPartNumberById(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartNumberGrpc> CreatePartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListPartNumberGrpc> UpdatePartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTagGrpc> GetAllTags(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTagGrpc> GetManyTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TagGrpc> GetTagById(TagGrpcRequest tagRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTagGrpc> CreateTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ListTagGrpc> UpdateTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
