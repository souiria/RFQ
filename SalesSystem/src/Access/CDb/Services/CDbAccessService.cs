using CDb.CQRS.Command.Masters.ClipType;
using CDb.CQRS.Command.Masters.CoverType;
using CDb.CQRS.Command.Masters.CrimpingProcessType;
using CDb.CQRS.Command.Masters.FileType;
using CDb.CQRS.Command.Masters.FuseType;
using CDb.CQRS.Command.Masters.MaterialType;
using CDb.CQRS.Command.Masters.MiscellaneousComponentType;
using CDb.CQRS.Command.Masters.Partner;
using CDb.CQRS.Command.Masters.Person;
using CDb.CQRS.Command.Masters.TemperatureRange;
using CDb.CQRS.Command.Masters.TerminalFamily;
using CDb.CQRS.Command.Masters.TerminalSize;
using CDb.CQRS.Command.Masters.TypeCode;
using CDb.CQRS.Command.Masters.WaterproofType;
using CDb.CQRS.Command.Masters.WireProtectionType;
using CDb.CQRS.Command.Masters.WireType;
using CDb.CQRS.Query.Masters.ClipType;
using CDb.CQRS.Query.Masters.CrimpingProcessType;
using CDb.CQRS.Query.Masters.FileType;
using CDb.CQRS.Query.Masters.FuseType;
using CDb.CQRS.Query.Masters.MaterialType;
using CDb.CQRS.Query.Masters.MiscellaneousComponent;
using CDb.CQRS.Query.Masters.Partner;
using CDb.CQRS.Query.Masters.Person;
using CDb.CQRS.Query.Masters.TemperatureRange;
using CDb.CQRS.Query.Masters.TerminalFamily;
using CDb.CQRS.Query.Masters.TerminalSize;
using CDb.CQRS.Query.Masters.TypeCode;
using CDb.CQRS.Query.Masters.WaterproofType;
using CDb.CQRS.Query.Masters.WireProtectionType;
using CDb.CQRS.Query.Masters.WireType;

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

        ListTemperatureRangeGrpc _TemperatureRangeGrpcs;
        ListTemperatureRangeGrpc _FilteredTemperatureRangeGrpcs;

        ListTerminalFamilyGrpc _TerminalFamilyGrpcs;
        ListTerminalFamilyGrpc _FilteredTerminalFamilyGrpcs;

        ListTerminalSizeGrpc _TerminalSizeGrpcs;
        ListTerminalSizeGrpc _FilteredTerminalSizeGrpcs;

        ListTypeCodeGrpc _TypeCodeGrpcs;
        ListTypeCodeGrpc _FilteredTypeCodeGrpcs;

        ListWaterproofTypeGrpc _WaterproofTypeGrpcs;
        ListWaterproofTypeGrpc _FilteredWaterproofTypeGrpcs;

        ListWireProtectionTypeGrpc _WireProtectionTypeGrpcs;
        ListWireProtectionTypeGrpc _FilteredWireProtectionTypeGrpcs;

        ListWireTypeGrpc _WireTypeGrpcs;
        ListWireTypeGrpc _FilteredWireTypeGrpcs;

        // Main
        ListFileNameGrpc _FileNameGrpcs;
        ListFileNameGrpc _FilteredFileNameGrpcs;

        // Components
        ListCompositeComponentGrpc _CompositeComponentGrpcs;
        ListCompositeComponentGrpc _FilteredCompositeComponentGrpcs;

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

        #region TemperatureRange
        bool _TemperatureRangeRefreshInProgress;
        IQueryHandler<GetTemperatureRangesQuery, List<TemperatureRangeGrpc>>? _QueryTemperatureRangeHandler;
        ICommandHandler<TemperatureRangeCommand>? _CommandTemperatureRangeHandler;
        #endregion

        #region TerminalFamily
        bool _TerminalFamilyRefreshInProgress;
        IQueryHandler<GetTerminalFamilysQuery, List<TerminalFamilyGrpc>>? _QueryTerminalFamilyHandler;
        ICommandHandler<TerminalFamilyCommand>? _CommandTerminalFamilyHandler;
        #endregion

        #region TerminalSize
        bool _TerminalSizeRefreshInProgress;
        IQueryHandler<GetTerminalSizesQuery, List<TerminalSizeGrpc>>? _QueryTerminalSizeHandler;
        ICommandHandler<TerminalSizeCommand>? _CommandTerminalSizeHandler;
        #endregion

        #region TypeCode
        bool _TypeCodeRefreshInProgress;
        IQueryHandler<GetTypeCodesQuery, List<TypeCodeGrpc>>? _QueryTypeCodeHandler;
        ICommandHandler<TypeCodeCommand>? _CommandTypeCodeHandler;
        #endregion

        #region WaterproofType
        bool _WaterproofTypeRefreshInProgress;
        IQueryHandler<GetWaterproofTypesQuery, List<WaterproofTypeGrpc>>? _QueryWaterproofTypeHandler;
        ICommandHandler<WaterproofTypeCommand>? _CommandWaterproofTypeHandler;
        #endregion

        #region WireProtectionType
        bool _WireProtectionTypeRefreshInProgress;
        IQueryHandler<GetWireProtectionTypesQuery, List<WireProtectionTypeGrpc>>? _QueryWireProtectionTypeHandler;
        ICommandHandler<WireProtectionTypeCommand>? _CommandWireProtectionTypeHandler;
        #endregion

        #region WireType
        bool _WireTypeRefreshInProgress;
        IQueryHandler<GetWireTypesQuery, List<WireTypeGrpc>>? _QueryWireTypeHandler;
        ICommandHandler<WireTypeCommand>? _CommandWireTypeHandler;
        #endregion

        #region CompositeComponent
        bool _CompositeComponentRefreshInProgress;
        IQueryHandler<GetComponentsQuery, List<CompositeComponentGrpc>>? _QueryComponentHandler;
        ICommandHandler<ComponentCommand>? _CommandComponentHandler;
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

            _MiscellaneousComponentTypeGrpcs = new ListMiscellaneousComponentTypeGrpc();
            _FilteredMiscellaneousComponentTypeGrpcs = new ListMiscellaneousComponentTypeGrpc();

            _PartnerGrpcs = new ListPartnerGrpc();
            _FilteredPartnerGrpcs = new ListPartnerGrpc();

            _PersonGrpcs = new ListPersonGrpc();
            _FilteredPersonGrpcs = new ListPersonGrpc();

            _TemperatureRangeGrpcs = new ListTemperatureRangeGrpc();
            _FilteredTemperatureRangeGrpcs = new ListTemperatureRangeGrpc();

            _TerminalFamilyGrpcs = new ListTerminalFamilyGrpc();
            _FilteredTerminalFamilyGrpcs = new ListTerminalFamilyGrpc();

            _TerminalSizeGrpcs = new ListTerminalSizeGrpc();
            _FilteredTerminalSizeGrpcs = new ListTerminalSizeGrpc();

            _TypeCodeGrpcs = new ListTypeCodeGrpc();
            _FilteredTypeCodeGrpcs = new ListTypeCodeGrpc();

            _WaterproofTypeGrpcs = new ListWaterproofTypeGrpc();
            _FilteredWaterproofTypeGrpcs = new ListWaterproofTypeGrpc();

            _WireProtectionTypeGrpcs = new ListWireProtectionTypeGrpc();
            _FilteredWireProtectionTypeGrpcs = new ListWireProtectionTypeGrpc();

            _WireTypeGrpcs = new ListWireTypeGrpc();
            _FilteredWireTypeGrpcs = new ListWireTypeGrpc();

            // Main
            _FileNameGrpcs = new ListFileNameGrpc();
            _FilteredFileNameGrpcs = new ListFileNameGrpc();

            // Components
            _CompositeComponentGrpcs = new ListCompositeComponentGrpc();
            _FilteredCompositeComponentGrpcs = new ListCompositeComponentGrpc();

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
            _TemperatureRangeRefreshInProgress = false;
            _TerminalFamilyRefreshInProgress = false;
            _TerminalSizeRefreshInProgress = false;
            _TypeCodeRefreshInProgress = false;
            _WaterproofTypeRefreshInProgress = false;
            _WireProtectionTypeRefreshInProgress = false;
            _WireTypeRefreshInProgress = false;
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
