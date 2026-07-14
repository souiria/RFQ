namespace CDb.Services
{
    public interface ICDbAccessService
    {
        //Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);

        // Masters
        #region ClipType
        Task<ListClipTypeGrpc> ReadAllClipTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region CoverType
        Task<ListCoverTypeGrpc> ReadAllCoverTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region CrimpingProcessType
        Task<ListCrimpingProcessTypeGrpc> ReadAllCrimpingProcessTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region FileType
        Task<ListFileTypeGrpc> ReadAllFileTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region FuseType
        Task<ListFuseTypeGrpc> ReadAllFuseTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region MaterialType
        Task<ListMaterialTypeGrpc> ReadAllMaterialTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region MiscellaneousComponentType
        Task<ListMiscellaneousComponentTypeGrpc> ReadAllMiscellaneousComponentTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Partner
        Task<ListPartnerGrpc> ReadAllPartners(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Person
        Task<ListPersonGrpc> ReadAllPersons(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreatePersons(PersonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdatePersons(PersonGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TemperatureRange
        Task<ListTemperatureRangeGrpc> ReadAllTemperatureRanges(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TerminalFamily
        Task<ListTerminalFamilyGrpc> ReadAllTerminalFamilys(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TerminalSize
        Task<ListTerminalSizeGrpc> ReadAllTerminalSizes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TypeCode
        Task<ListTypeCodeGrpc> ReadAllTypeCodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WaterproofType
        Task<ListWaterproofTypeGrpc> ReadAllWaterproofTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WireProtectionType
        Task<ListWireProtectionTypeGrpc> ReadAllWireProtectionTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WireType
        Task<ListWireTypeGrpc> ReadAllWireTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        // Main

        #region FileName
        Task<ListFileNameGrpc> ReadAllFileNames(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region PartNumber
        Task<ListPartNumberGrpc> ReadAllPartNumbers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdatePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> DeletePartNumbers(PartNumberGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Tag
        Task<ListTagGrpc> ReadAllTags(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateTags(TagGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateTags(TagGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteTags(TagGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        //Components
        #region CompositeComponent
        Task<ListCompositeComponentGrpc> ReadAllCompositeComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}