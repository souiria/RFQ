namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        #region In Memory Datasets

        ListClipTypeGrpc _ClipTypeGrpcs;
        ListClipTypeGrpc _FilteredClipTypeGrpcs;

        ListCoverTypeGrpc _CoverTypeGrpcs;
        ListCoverTypeGrpc _FilteredCoverTypeGrpcs;

        ListCrimpingProcessTypeGrpc _CrimpingProcessTypeGrpcs;
        ListCrimpingProcessTypeGrpc _FilteredCrimpingProcessTypeGrpcs;

        ListCompositeComponentGrpc _CompositeComponentGrpcs;
        ListCompositeComponentGrpc _FilteredCompositeComponentGrpcs;

        ListFileTypeGrpc _FileTypeGrpcs;
        ListFileTypeGrpc _FilteredFileTypeGrpcs;

        ListFuseTypeGrpc _FuseTypeGrpcs;
        ListFuseTypeGrpc _FilteredFuseTypeGrpcs;

        ListMaterialTypeGrpc _MaterialTypeGrpcs;
        ListMaterialTypeGrpc _FilteredMaterialTypeGrpcs;

        ListMiscellaneousComponentTypeGrpc _MiscellaneousComponentTypeGrpcs;
        ListMiscellaneousComponentTypeGrpc _FilteredMiscellaneousComponentTypeGrpcs;

        ListPartnerGrpc _PartnerGrpcs;
        ListPartnerGrpc _FilteredPartnerGrpcs;

        ListPersonGrpc _PersonGrpcs;
        ListPersonGrpc _FilteredPersonGrpcs;

        // Main
        ListFileNameGrpc _FileNameGrpcs;
        ListFileNameGrpc _FilteredFileNameGrpcs;

        // Components
        ListMiscellaneousComponentGrpc _MiscellaneousComponentGrpcs;
        ListMiscellaneousComponentGrpc _FilteredMiscellaneousComponentGrpcs;

        #endregion

        #region Fields and Properties

        #region ClipType
        bool _ClipTypeRefreshInProgress;
        IQueryHandler<GetClipTypesQuery, List<ClipTypeGrpc>>? _QueryClipTypeHandler;
        ICommandHandler<ClipTypeCommand>? _CommandClipTypeHandler;
        #endregion

        #region CoverType
        bool _CoverTypeRefreshInProgress;
        IQueryHandler<GetCoverTypesQuery, List<CoverTypeGrpc>>? _QueryCoverTypeHandler;
        ICommandHandler<CoverTypeCommand>? _CommandCoverTypeHandler;
        #endregion

        #region CrimpingProcessType
        bool _CrimpingProcessTypeRefreshInProgress;
        IQueryHandler<GetCrimpingProcessTypesQuery, List<CrimpingProcessTypeGrpc>>? _QueryCrimpingProcessTypeHandler;
        ICommandHandler<CrimpingProcessTypeCommand>? _CommandCrimpingProcessTypeHandler;
        #endregion

        #region FileType
        bool _FileTypeRefreshInProgress;
        IQueryHandler<GetFileTypesQuery, List<FileTypeGrpc>>? _QueryFileTypeHandler;
        ICommandHandler<FileTypeCommand>? _CommandFileTypeHandler;
        #endregion

        #region FuseType
        bool _FuseTypeRefreshInProgress;
        IQueryHandler<GetFuseTypesQuery, List<FuseTypeGrpc>>? _QueryFuseTypeHandler;
        ICommandHandler<FuseTypeCommand>? _CommandFuseTypeHandler;
        #endregion

        #region MaterialType
        bool _MaterialTypeRefreshInProgress;
        IQueryHandler<GetMaterialTypesQuery, List<MaterialTypeGrpc>>? _QueryMaterialTypeHandler;
        ICommandHandler<MaterialTypeCommand>? _CommandMaterialTypeHandler;
        #endregion

        #region MiscellaneousComponentType
        bool _MiscellaneousComponentTypeRefreshInProgress;
        IQueryHandler<GetMiscellaneousComponentTypesQuery, List<MiscellaneousComponentTypeGrpc>>? _QueryMiscellaneousComponentTypeHandler;
        ICommandHandler<MiscellaneousComponentTypeCommand>? _CommandMiscellaneousComponentTypeHandler;
        #endregion

        #region Partner
        bool _PartnerRefreshInProgress;
        IQueryHandler<GetPartnersQuery, List<PartnerGrpc>>? _QueryPartnerHandler;
        ICommandHandler<PartnerCommand>? _CommandPartnerHandler;
        #endregion

        #region Person
        bool _PersonRefreshInProgress;
        IQueryHandler<GetPersonsQuery, List<PersonGrpc>>? _QueryPersonHandler;
        ICommandHandler<PersonCommand>? _CommandPersonHandler;
        #endregion

        #region CompositeComponent
        bool _CompositeComponentRefreshInProgress;
        #endregion

        #endregion // Fields and Properties

        readonly IServiceProvider _ServiceProvider;

        public CDbAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            _ClipTypeGrpcs = new ListClipTypeGrpc();
            _FilteredClipTypeGrpcs = new ListClipTypeGrpc();

            _CoverTypeGrpcs = new ListCoverTypeGrpc();
            _FilteredCoverTypeGrpcs = new ListCoverTypeGrpc();

            _CrimpingProcessTypeGrpcs = new ListCrimpingProcessTypeGrpc();
            _FilteredCrimpingProcessTypeGrpcs = new ListCrimpingProcessTypeGrpc();

            _CompositeComponentGrpcs = new ListCompositeComponentGrpc();
            _FilteredCompositeComponentGrpcs = new ListCompositeComponentGrpc();

            _FileTypeGrpcs = new ListFileTypeGrpc();
            _FilteredFileTypeGrpcs = new ListFileTypeGrpc();

            _FuseTypeGrpcs = new ListFuseTypeGrpc();
            _FilteredFuseTypeGrpcs = new ListFuseTypeGrpc();

            _MaterialTypeGrpcs = new ListMaterialTypeGrpc();
            _FilteredMaterialTypeGrpcs = new ListMaterialTypeGrpc();

            _PartnerGrpcs = new ListPartnerGrpc();
            _FilteredPartnerGrpcs = new ListPartnerGrpc();

            _PersonGrpcs = new ListPersonGrpc();
            _FilteredPersonGrpcs = new ListPersonGrpc();

            // Components
            _MiscellaneousComponentTypeGrpcs = new ListMiscellaneousComponentTypeGrpc();
            _FilteredMiscellaneousComponentTypeGrpcs = new ListMiscellaneousComponentTypeGrpc();

            // Main
            _FileNameGrpcs = new ListFileNameGrpc();
            _FilteredFileNameGrpcs = new ListFileNameGrpc();

            // Components
            _MiscellaneousComponentGrpcs = new ListMiscellaneousComponentGrpc();
            _FilteredMiscellaneousComponentGrpcs = new ListMiscellaneousComponentGrpc();

            _ClipTypeRefreshInProgress = false;
            _CoverTypeRefreshInProgress = false;
            _CrimpingProcessTypeRefreshInProgress = false;
            _FileTypeRefreshInProgress = false;
            _FuseTypeRefreshInProgress = false;
            _MaterialTypeRefreshInProgress = false;
            _MiscellaneousComponentTypeRefreshInProgress = false;
            _PartnerRefreshInProgress = false;
            _PersonRefreshInProgress = false;
            _CompositeComponentRefreshInProgress = false;

            _ServiceProvider = serviceProvider;
            if (testing)
            {
                _ClipTypeGrpcs = SampleCDbAccessDataService.PopulateClipTypeInitData();
                _CoverTypeGrpcs = SampleCDbAccessDataService.PopulateCoverTypeInitData();
                _CrimpingProcessTypeGrpcs = SampleCDbAccessDataService.PopulateCrimpingProcessTypeInitData();
                _CompositeComponentGrpcs = SampleCDbAccessDataService.PopulateCompositeComponentInitData();
            }
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
    }
}
