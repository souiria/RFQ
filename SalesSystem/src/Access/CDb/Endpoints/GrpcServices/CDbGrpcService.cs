namespace CDb.Endpoints.GrpcServices
{
    public partial class CDbGrpcService : CDbService.CDbServiceBase
    {
        readonly ICDbAccessService _CDbAccessService;
        readonly ILogger<CDbGrpcService> _Logger;

        public CDbGrpcService(ICDbAccessService cDbAccessService, ILogger<CDbGrpcService> logger)
        {
            _CDbAccessService = cDbAccessService;
            _Logger = logger;
        }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<CdbFilterResponseGrpc> FilterCdbDataGrpc(CdbFilterRequestGrpc request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("FilterCDBGrpc starting");
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpression = request.FilterExpression;
            CdbFilterResponseGrpc returnResponse = new CdbFilterResponseGrpc();
            switch (request.DatabaseList.ToUpperInvariant()) 
            {
                case "CLIPTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<ClipTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListClipTypeGrpc returnList = new ListClipTypeGrpc();
                    returnList.ClipTypeGrpcs.AddRange(filterList);
                    returnResponse.ListClipTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "COVERTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<CoverTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListCoverTypeGrpc returnList = new ListCoverTypeGrpc();
                    returnList.CoverTypeGrpcs.AddRange(filterList);
                    returnResponse.ListCoverTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "CRIMPINGPROCESSTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<CrimpingProcessTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListCrimpingProcessTypeGrpc returnList = new ListCrimpingProcessTypeGrpc();
                    returnList.CrimpingProcessTypeGrpcs.AddRange(filterList);
                    returnResponse.ListCrimpingProcessTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "FILETYPEGRPC":
                await _CDbAccessService.HandleFilterCase<FileTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListFileTypeGrpc returnList = new ListFileTypeGrpc();
                    returnList.FileTypeGrpcs.AddRange(filterList);
                    returnResponse.ListFileTypes = returnList;
                    returnResponse.IsSuccess = true;
                    }, context.CancellationToken);
                break;
                case "FUSETYPEGRPC":
                await _CDbAccessService.HandleFilterCase<FuseTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListFuseTypeGrpc returnList = new ListFuseTypeGrpc();
                    returnList.FuseTypeGrpcs.AddRange(filterList);
                    returnResponse.ListFuseTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "MATERIALTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<MaterialTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListMaterialTypeGrpc returnList = new ListMaterialTypeGrpc();
                    returnList.MaterialTypeGrpcs.AddRange(filterList);
                    returnResponse.ListMaterialTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "MISCELLANEOUSCOMPONENTTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<MiscellaneousComponentTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListMiscellaneousComponentTypeGrpc returnList = new ListMiscellaneousComponentTypeGrpc();
                    returnList.MiscellaneousComponentTypeGrpcs.AddRange(filterList);
                    returnResponse.ListMiscellaneousComponentTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "PARTNERGRPC":
                await _CDbAccessService.HandleFilterCase<PartnerGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListPartnerGrpc returnList = new ListPartnerGrpc();
                    returnList.PartnerGrpcs.AddRange(filterList);
                    returnResponse.ListPartners = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "PERSONGRPC":
                await _CDbAccessService.HandleFilterCase<PersonGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListPersonGrpc returnList = new ListPersonGrpc();
                    returnList.PersonGrpcs.AddRange(filterList);
                    returnResponse.ListPersons = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "TEMPERATURERANGEGRPC":
                await _CDbAccessService.HandleFilterCase<TemperatureRangeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListTemperatureRangeGrpc returnList = new ListTemperatureRangeGrpc();
                    returnList.TemperatureRangeGrpcs.AddRange(filterList);
                    returnResponse.ListTemperatureRanges = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "TERMINALFAMILYGRPC":
                await _CDbAccessService.HandleFilterCase<TerminalFamilyGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListTerminalFamilyGrpc returnList = new ListTerminalFamilyGrpc();
                    returnList.TerminalFamilyGrpcs.AddRange(filterList);
                    returnResponse.ListTerminalFamilies = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "TERMINALSIZEGRPC":
                await _CDbAccessService.HandleFilterCase<TerminalSizeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListTerminalSizeGrpc returnList = new ListTerminalSizeGrpc();
                    returnList.TerminalSizeGrpcs.AddRange(filterList);
                    returnResponse.ListTerminalSizes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "TYPECODEGRPC":
                await _CDbAccessService.HandleFilterCase<TypeCodeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListTypeCodeGrpc returnList = new ListTypeCodeGrpc();
                    returnList.TypeCodeGrpcs.AddRange(filterList);
                    returnResponse.ListTypeCodes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "WATERPROOFTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<WaterproofTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListWaterproofTypeGrpc returnList = new ListWaterproofTypeGrpc();
                    returnList.WaterproofTypeGrpcs.AddRange(filterList);
                    returnResponse.ListWaterproofTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "WIREPROTECTIONTYPEGRPC":
                await _CDbAccessService.HandleFilterCase<WireProtectionTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListWireProtectionTypeGrpc returnList = new ListWireProtectionTypeGrpc();
                    returnList.WireProtectionTypeGrpcs.AddRange(filterList);
                    returnResponse.ListWireProtectionTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "WIRETYPEGRPC":
                await _CDbAccessService.HandleFilterCase<WireTypeGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListWireTypeGrpc returnList = new ListWireTypeGrpc();
                    returnList.WireTypeGrpcs.AddRange(filterList);
                    returnResponse.ListWireTypes = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "FILENAMEGRPC":
                await _CDbAccessService.HandleFilterCase<FileNameGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListFileNameGrpc returnList = new ListFileNameGrpc();
                    returnList.FileNameGrpcs.AddRange(filterList);
                    returnResponse.ListFileNames = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "PARTNUMBERGRPC":
                await _CDbAccessService.HandleFilterCase<PartNumberGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListPartNumberGrpc returnList = new ListPartNumberGrpc();
                    returnList.PartNumberGrpcs.AddRange(filterList);
                    returnResponse.ListPartNumbers = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "TAGGRPC":
                await _CDbAccessService.HandleFilterCase<TagGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListTagGrpc returnList = new ListTagGrpc();
                    returnList.TagGrpcs.AddRange(filterList);
                    returnResponse.ListTags = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "COMPOSITECOMPONENTGRPC":
                await _CDbAccessService.HandleFilterCase<CompositeComponentGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListCompositeComponentGrpc returnList = new ListCompositeComponentGrpc();
                    returnList.CompositeComponentGrpcs.AddRange(filterList);
                    returnResponse.ListCompositeComponents = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
                case "MISCELLANEOUSCOMPONENTGRPC":
                await _CDbAccessService.HandleFilterCase<MiscellaneousComponentGrpc>(filterExpression, parsingConfig,
                filterList =>
                {
                    ListMiscellaneousComponentGrpc returnList = new ListMiscellaneousComponentGrpc();
                    returnList.MiscellaneousComponentGrpcs.AddRange(filterList);
                    returnResponse.ListMiscellaneousComponents = returnList;
                    returnResponse.IsSuccess = true;
                }, context.CancellationToken);
                break;
            }

            return returnResponse;
        }
    }
}
