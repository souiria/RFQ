namespace Emacs.Endpoints.GrpcServices
{
    public class EMACSGrpcService : Emacs.EmacsBase
    {
        readonly IEMACSAccessService _EMACSAccessService;
        readonly ILogger<EMACSGrpcService> _Logger;

        public EMACSGrpcService(IEMACSAccessService eMACSAccessService, ILogger<EMACSGrpcService> logger)
        {
            _EMACSAccessService = eMACSAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region CombinedParts
        public override async Task<ListCombinedPartsData> GetCombinedPartsData(CombinedPartsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCombinedPartsData starting");
            ListCombinedPartsData listCombinedPartsData = new();
            Result<List<CombinedPartsDto>> results = await _EMACSAccessService.GetAllCombinedParts(context.CancellationToken);
            foreach (CombinedPartsDto result in results.Value)
            {
                CombinedPartsData combinedPartsData = result.MapToCombinePartsData();
                listCombinedPartsData.CombinedPartsData.Add(combinedPartsData);
            }

            return listCombinedPartsData;
        }

        public override async Task<CombinedPartsCountData> GetCombinedPartsDataCount(CombinedPartsCountGrpcRequest request, ServerCallContext context)
        {
            CombinedPartsCountData combinedPartsCountData = new();
            Result<int> results = await _EMACSAccessService.GetCombinedPartsDataCount(context.CancellationToken);
            combinedPartsCountData.Count = results.Value;
            return combinedPartsCountData;
        }
        #endregion

        #region PartCatogoryDetail
        public override async Task<ListPartCategoryDetail> GetPartCategoryDetailData(PartCategoryDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartCategoryDetailData starting");
            ListPartCategoryDetail listPartCatogoryDetailData = new();
            Result<List<PartCategoryDetailDto>> results = await _EMACSAccessService.GetAllPartCategoryDetail(context.CancellationToken);
            foreach (PartCategoryDetailDto result in results.Value)
            {
                PartCategoryDetail combinedPartsData = result.MapToPartCategoryDetailData();
                listPartCatogoryDetailData.PartCategoryDetail.Add(combinedPartsData);
            }

            return listPartCatogoryDetailData;
        }
        #endregion

        #region PartClassDetail
        public override async Task<ListPartClassDetail> GetPartClassDetailData(PartClassDetailGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartClassDetailData starting");
            ListPartClassDetail listPartClassDetailData = new();
            Result<List<PartClassDetailDto>> results = await _EMACSAccessService.GetAllPartClassDetail(context.CancellationToken);
            foreach (PartClassDetailDto result in results.Value)
            {
                PartClassDetail combinedPartsData = result.MapToPartClassDetailData();
                listPartClassDetailData.PartClassDetail.Add(combinedPartsData);
            }

            return listPartClassDetailData;
        }
        #endregion

        #region PartGroups
        public override async Task<ListPartGroups> GetPartGroupsData(PartGroupsGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsData starting");
            ListPartGroups listPartGroupsData = new();
            Result<List<PartGroupsDto>> results = await _EMACSAccessService.GetAllPartGroups(context.CancellationToken);
            foreach (PartGroupsDto result in results.Value)
            {
                PartGroups combinedPartsData = result.MapToPartGroupsData();
                listPartGroupsData.PartGroups.Add(combinedPartsData);
            }

            return listPartGroupsData;
        }
        #endregion

        #region PartGroupsConst
        public override async Task<ListPartGroupsConst> GetPartGroupsConstData(PartGroupsConstGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPartGroupsConstData starting");
            ListPartGroupsConst listPartGroupsConstData = new();
            Result<List<PartGroupsConstDto>> results = await _EMACSAccessService.GetAllPartGroupsConst(context.CancellationToken);
            foreach (PartGroupsConstDto result in results.Value)
            {
                PartGroupsConst combinedPartsData = result.MapToPartGroupsConstData();
                listPartGroupsConstData.PartGroupsConst.Add(combinedPartsData);
            }

            return listPartGroupsConstData;
        }
        #endregion
    }
}
