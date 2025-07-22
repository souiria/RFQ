namespace SFS.Endpoints.GrpcServices
{
    public class SFSGrpcService :SFSService.SFSServiceBase
    {
      readonly ISFSAccessService _SFSAccessService;
      readonly ILogger<SFSGrpcService> _Logger;
    public SFSGrpcService(ISFSAccessService sFSAccessService, ILogger<SFSGrpcService> logger)
    {
        _SFSAccessService = sFSAccessService;
        _Logger = logger;
    }
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        public override async Task<CarModelListViewGrpc> GetAllCarModels(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllCarModel(context.CancellationToken);
        }
        public override async Task<ProfileListViewGrpc> GetAllProfiles(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllProfiles(context.CancellationToken);
        }
        public override async Task<PeriodListViewGrpc> GetAllPeriods(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllPeriods(context.CancellationToken);
        }

        public override async Task<CustomerListViewGrpc> GetAllCustomers(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllCustomers(context.CancellationToken);
        }

        public override async Task<SiteListViewGrpc> GetAllSites(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllSites(context.CancellationToken);
        }

        public override async Task<ForecastListViewGrpc> GetAllForecasts(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetAllForecasts(context.CancellationToken);
        }

        public override async Task<MonthlyVolumeDataListViewGrpc> GetMonthlyVolumes(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetMonthlyVolumes(context.CancellationToken);
        }

        public override async Task<CustomerNonWorkingDayListViewGrpc> GetCustomerNonWorkingDay(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetCustomerNonWorkingDay(context.CancellationToken);
        }
        public override async Task<DailyVolumeDataListViewGrpc> GetDailyVolumeData(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetDailyVolumeData(context.CancellationToken);
        }
        public override async Task<CalculationTypeListViewGrpc> GetCalculationType(Empty request, ServerCallContext context)
        {
            return await _SFSAccessService.GetCalculationType(context.CancellationToken);
        }
    }
}
