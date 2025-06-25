namespace Master.Endpoints.GrpcServices
{
    public class MasterGrpcService : Master.MasterBase
    {
        readonly IMasterAccessService _MasterAccessService;
        readonly ILogger<MasterGrpcService> _Logger;

        public MasterGrpcService(IMasterAccessService masterAccessService, ILogger<MasterGrpcService> logger)
        {
            _MasterAccessService = masterAccessService;
            _Logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply reply = new HelloReply();
            reply.Message = "Hello " + request.Name;
            Task<HelloReply> result = Task.FromResult(reply);
            return result;
        }

        #region Currency
        public override async Task<ListCurrencyData> GetCurrencyData(CurrencyGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyData starting");
            return await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
        }

        public override async Task GetCurrencyDataStream(CurrencyGrpcRequest request, IServerStreamWriter<CurrencyData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyDataStream starting");
            ListCurrencyData results = await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
            foreach (CurrencyData result in results.CurrencyData)
            {
                await responseStream.WriteAsync(result);
            }
        }

        public override async Task<ListCurrencyData> GetCurrencyDataById(CurrencyByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyDataById starting");
            return await _MasterAccessService.GetCurrenciesById(request.Id, context.CancellationToken);
        }
        #endregion

        #region Customer

        public override async Task<ListCustomerData> GetCustomerData(CustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerData starting");
            return await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task GetCustomerDataStream(CustomerGrpcRequest request, IServerStreamWriter<CustomerData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerDataStream starting");
            ListCustomerData results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task<ListCustomerData> GetCustomerDataById(CustomerByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerDataById starting");
            return await _MasterAccessService.GetCustomerBusinessUnitsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListCustomerLocationData> GetCustomerLocationData(CustomerLocationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationData starting");
            return await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task GetCustomerLocationDataStream(CustomerLocationGrpcRequest request, IServerStreamWriter<CustomerLocationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationDataStream starting");
            ListCustomerLocationData results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task<ListCustomerLocationData> GetCustomerLocationDataById(CustomerLocationByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationDataById starting");
            return await _MasterAccessService.GetCustomerLocationsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListCustomerLocationData> GetCustomerLocationDataByUserId(CustomerLocationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationDataByUserId starting");
            return await _MasterAccessService.GetCustomerLocationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityData> GetCustomerSalesEntityData(CustomerSalesEntityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityData starting");
            return await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task GetCustomerSalesEntityDataStream(CustomerSalesEntityGrpcRequest request, IServerStreamWriter<CustomerSalesEntityData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityDataStream starting");
            ListCustomerSalesEntityData results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityData> GetCustomerSalesEntityDataByUserId(CustomerSalesEntityByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityDataByUserId starting");
            return await _MasterAccessService.GetAllCustomerSalesByUserIdEntities(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerProjectAssociationData> GetCustomerProjectAssociationData(CustomerProjectAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationData starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerProjectAssociationData> GetCustomerProjectAssociationDataByUserId(CustomerProjectAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationDataByUserId starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociationsByUserId(request.UserId ,context.CancellationToken);
        }

        public override async Task GetCustomerProjectAssociationDataStream(CustomerProjectAssociationGrpcRequest request, IServerStreamWriter<CustomerProjectAssociationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationDataStream starting");
            ListCustomerProjectAssociationData result = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }

        public override async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationData(CustomerBusinessUserAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationData starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationDataByUserId(CustomerBusinessUserAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationDataByUserId starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task GetCustomerBusinessUserAssociationDataStream(CustomerBusinessUserAssociationGrpcRequest request, IServerStreamWriter<CustomerBusinessUserAssociationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationDataStream starting");
            ListCustomerBusinessUserAssociationData result = await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }

        #endregion

        #region Project

        public override async Task<ListPlatformData> GetPlatformData(PlatformGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformData starting");
            return await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task GetPlatformDataStream(PlatformGrpcRequest request, IServerStreamWriter<PlatformData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformDataStream starting");
            ListPlatformData results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task<ListPlatformData> GetPlatformDataById(PlatformByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformDataById starting");
            return await _MasterAccessService.GetPlatformsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListProgramData> GetProgramData(ProgramGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramData starting");
            return await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task GetProgramDataStream(ProgramGrpcRequest request, IServerStreamWriter<ProgramData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramDataStream starting");
            ListProgramData results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task<ListProgramData> GetProgramDataById(ProgramByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramDataById starting");
            return await _MasterAccessService.GetProgramsById(request.Id , context.CancellationToken);
        }

        public override async Task<ListProjectData> GetProjectData(ProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectData starting");
            return await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }

        public override async Task GetProjectDataStream(ProjectGrpcRequest request, IServerStreamWriter<ProjectData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectDataStream starting");
            ListProjectData results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }
        public override async Task<ListProjectData> GetProjectDataById(ProjectByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectDataById starting");
            return await _MasterAccessService.GetProjectsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListMilestoneData> GetMilestoneData(MilestoneGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneData starting");
            return await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task GetMilestoneDataStream(MilestoneGrpcRequest request, IServerStreamWriter<MilestoneData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneDataStream starting");
            ListMilestoneData results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task<ListMilestoneData> GetMilestoneDataById(MilestoneByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneDataById starting");
            return await _MasterAccessService.GetMilestonesById(request.Id, context.CancellationToken);
        }

        #endregion

        #region Vehicle

        public override async Task<ListVehicleData> GetVehicleData(VehicleGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleData starting");
            return await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }

        public override async Task GetVehicleDataStream(VehicleGrpcRequest request, IServerStreamWriter<VehicleData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleDataStream starting");
            ListVehicleData results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }
        public override async Task<ListVehicleData> GetVehicleDataById(VehicleByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleDataById starting");
            return await _MasterAccessService.GetVehiclesById(request.Id ,context.CancellationToken);
        }

        public override async Task<ListVehicleData> GetVehicleDataByDisplay(VehicleByDisplayGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleDataByDisplay starting");
            return await _MasterAccessService.GetVehiclesByDisplay(request.VehicleDisplay ,context.CancellationToken);
        }

        #endregion
    }
}
