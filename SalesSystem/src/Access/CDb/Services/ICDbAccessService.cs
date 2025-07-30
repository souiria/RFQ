namespace CDb.Services
{
    public interface ICDbAccessService
    {
        //Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);

        // Masters
        #region ClipType
        Task<ListClipTypeGrpc> ReadAllClipTypes(CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> ReadManyClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> ReadClipTypeById(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateClipTypes(ClipTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region CoverType
        Task<ListCoverTypeGrpc> ReadAllCoverTypes(CancellationToken cancellationToken);
        Task<ListCoverTypeGrpc> ReadManyCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCoverTypeGrpc> ReadCoverTypeById(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateCoverTypes(CoverTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region CrimpingProcessType
        Task<ListCrimpingProcessTypeGrpc> ReadAllCrimpingProcessTypes(CancellationToken cancellationToken);
        Task<ListCrimpingProcessTypeGrpc> ReadManyCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCrimpingProcessTypeGrpc> ReadCrimpingProcessTypeById(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateCrimpingProcessTypes(CrimpingProcessTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region FileType
        Task<ListFileTypeGrpc> ReadAllFileTypes(CancellationToken cancellationToken);
        Task<ListFileTypeGrpc> ReadManyFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListFileTypeGrpc> ReadFileTypeById(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region FuseType
        Task<ListFuseTypeGrpc> ReadAllFuseTypes(CancellationToken cancellationToken);
        Task<ListFuseTypeGrpc> ReadManyFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListFuseTypeGrpc> ReadFuseTypeById(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateFuseTypes(FuseTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region MaterialType
        Task<ListMaterialTypeGrpc> ReadAllMaterialTypes(CancellationToken cancellationToken);
        Task<ListMaterialTypeGrpc> ReadManyMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListMaterialTypeGrpc> ReadMaterialTypeById(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region MiscellaneousComponentType
        Task<ListMiscellaneousComponentTypeGrpc> ReadAllMiscellaneousComponentTypes(CancellationToken cancellationToken);
        Task<ListMiscellaneousComponentTypeGrpc> ReadManyMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListMiscellaneousComponentTypeGrpc> ReadMiscellaneousComponentTypeById(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateMiscellaneousComponentTypes(MiscellaneousComponentTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Partner
        Task<ListPartnerGrpc> ReadAllPartners(CancellationToken cancellationToken);
        Task<ListPartnerGrpc> ReadManyPartners(PartnerGrpcRequest request, CancellationToken cancellationToken);
        Task<ListPartnerGrpc> ReadPartnerById(PartnerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdatePartners(PartnerGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Person
        Task<ListPersonGrpc> ReadAllPersons(CancellationToken cancellationToken);
        Task<ListPersonGrpc> ReadManyPersons(PersonGrpcRequest request, CancellationToken cancellationToken);
        Task<ListPersonGrpc> ReadPersonById(PersonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> CreatePersons(PersonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdatePersons(PersonGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TemperatureRange
        Task<ListTemperatureRangeGrpc> ReadAllTemperatureRanges(CancellationToken cancellationToken);
        Task<ListTemperatureRangeGrpc> ReadManyTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTemperatureRangeGrpc> ReadTemperatureRangeById(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTemperatureRangeGrpc> CreateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTemperatureRangeGrpc> UpdateTemperatureRanges(TemperatureRangeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TerminalFamily
        Task<ListTerminalFamilyGrpc> ReadAllTerminalFamilys(CancellationToken cancellationToken);
        Task<ListTerminalFamilyGrpc> ReadManyTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalFamilyGrpc> ReadTerminalFamilyById(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalFamilyGrpc> CreateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalFamilyGrpc> UpdateTerminalFamilys(TerminalFamilyGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TerminalSize
        Task<ListTerminalSizeGrpc> ReadAllTerminalSizes(CancellationToken cancellationToken);
        Task<ListTerminalSizeGrpc> ReadManyTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalSizeGrpc> ReadTerminalSizeById(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalSizeGrpc> CreateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTerminalSizeGrpc> UpdateTerminalSizes(TerminalSizeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region TypeCode
        Task<ListTypeCodeGrpc> ReadAllTypeCodes(CancellationToken cancellationToken);
        Task<ListTypeCodeGrpc> ReadManyTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTypeCodeGrpc> ReadTypeCodeById(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTypeCodeGrpc> CreateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListTypeCodeGrpc> UpdateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WaterproofType
        Task<ListWaterproofTypeGrpc> ReadAllWaterproofTypes(CancellationToken cancellationToken);
        Task<ListWaterproofTypeGrpc> ReadManyWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWaterproofTypeGrpc> ReadWaterproofTypeById(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWaterproofTypeGrpc> CreateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWaterproofTypeGrpc> UpdateWaterproofTypes(WaterproofTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WireProtectionType
        Task<ListWireProtectionTypeGrpc> ReadAllWireProtectionTypes(CancellationToken cancellationToken);
        Task<ListWireProtectionTypeGrpc> ReadManyWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireProtectionTypeGrpc> ReadWireProtectionTypeById(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireProtectionTypeGrpc> CreateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireProtectionTypeGrpc> UpdateWireProtectionTypes(WireProtectionTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region WireType
        Task<ListWireTypeGrpc> ReadAllWireTypes(CancellationToken cancellationToken);
        Task<ListWireTypeGrpc> ReadManyWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireTypeGrpc> ReadWireTypeById(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireTypeGrpc> CreateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListWireTypeGrpc> UpdateWireTypes(WireTypeGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        // Main

        #region FileName
        Task<ListFileNameGrpc> ReadAllFileNames(CancellationToken cancellationToken);
        Task<ListFileNameGrpc> ReadManyFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        Task<ListFileNameGrpc> ReadFileNameById(FileNameGrpcRequest request, CancellationToken cancellationToken);
        Task<ListFileNameGrpc> CreateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        Task<ListFileNameGrpc> UpdateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region PartNumber
        Task<ListPartNumberGrpc> GetAllPartNumbers(CancellationToken cancellationToken);
        Task<ListPartNumberGrpc> GetManyPartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken);
        Task<PartNumberGrpc> GetPartNumberById(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken);
        Task<ListPartNumberGrpc> CreatePartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken);
        Task<ListPartNumberGrpc> UpdatePartNumbers(PartNumberGrpcRequest partNumberRequest, CancellationToken cancellationToken);
        #endregion

        #region Tag
        Task<ListTagGrpc> GetAllTags(CancellationToken cancellationToken);
        Task<ListTagGrpc> GetManyTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken);
        Task<TagGrpc> GetTagById(TagGrpcRequest tagRequest, CancellationToken cancellationToken);
        Task<ListTagGrpc> CreateTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken);
        Task<ListTagGrpc> UpdateTags(TagGrpcRequest tagRequest, CancellationToken cancellationToken);
        #endregion

        //Components
        #region CompositeComponent
        Task<ListCompositeComponentGrpc> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadAllCompositeComponents(CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadManyCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadCompositeComponentsById(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadCompositeComponentsBySheetNumber(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        #endregion
    }
}