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
        public override async Task<ListCurrencyData> GetCurrencyGrpc(CurrencyGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpc starting");
            return await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
        }

        public override async Task GetCurrencyGrpcStream(CurrencyGrpcRequest request, IServerStreamWriter<CurrencyData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpcStream starting");
            ListCurrencyData results = await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
            foreach (CurrencyData result in results.CurrencyData)
            {
                await responseStream.WriteAsync(result);
            }
        }

        public override async Task<ListCurrencyData> GetCurrencyGrpcById(CurrencyByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpcById starting");
            return await _MasterAccessService.GetCurrenciesById(request.Id, context.CancellationToken);
        }
        #endregion

        #region Customer

        public override async Task<ListCustomerData> GetCustomerGrpc(CustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpc starting");
            return await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task GetCustomerGrpcStream(CustomerGrpcRequest request, IServerStreamWriter<CustomerData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpcStream starting");
            ListCustomerData results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task<ListCustomerData> GetCustomerGrpcById(CustomerByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpcById starting");
            return await _MasterAccessService.GetCustomerBusinessUnitsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListCustomerLocationData> GetCustomerLocationGrpc(CustomerLocationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpc starting");
            return await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task GetCustomerLocationGrpcStream(CustomerLocationGrpcRequest request, IServerStreamWriter<CustomerLocationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcStream starting");
            ListCustomerLocationData results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task<ListCustomerLocationData> GetCustomerLocationGrpcById(CustomerLocationByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcById starting");
            return await _MasterAccessService.GetCustomerLocationsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListCustomerLocationData> GetCustomerLocationGrpcByUserId(CustomerLocationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcByUserId starting");
            return await _MasterAccessService.GetCustomerLocationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityData> GetCustomerSalesEntityGrpc(CustomerSalesEntityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpc starting");
            return await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task GetCustomerSalesEntityGrpcStream(CustomerSalesEntityGrpcRequest request, IServerStreamWriter<CustomerSalesEntityData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpcStream starting");
            ListCustomerSalesEntityData results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityData> GetCustomerSalesEntityGrpcByUserId(CustomerSalesEntityByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpcByUserId starting");
            return await _MasterAccessService.GetAllCustomerSalesByUserIdEntities(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerProjectAssociationData> GetCustomerProjectAssociationGrpc(CustomerProjectAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpc starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerProjectAssociationData> GetCustomerProjectAssociationGrpcByUserId(CustomerProjectAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcByUserId starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociationsByUserId(request.UserId ,context.CancellationToken);
        }

        public override async Task GetCustomerProjectAssociationGrpcStream(CustomerProjectAssociationGrpcRequest request, IServerStreamWriter<CustomerProjectAssociationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcStream starting");
            ListCustomerProjectAssociationData result = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }

        public override async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationGrpc(CustomerBusinessUserAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpc starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationGrpcByUserId(CustomerBusinessUserAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpcByUserId starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task GetCustomerBusinessUserAssociationGrpcStream(CustomerBusinessUserAssociationGrpcRequest request, IServerStreamWriter<CustomerBusinessUserAssociationData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpcStream starting");
            ListCustomerBusinessUserAssociationData result = await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }

        #endregion

        #region Project

        public override async Task<ListPlatformData> GetPlatformGrpc(PlatformGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpc starting");
            return await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task GetPlatformGrpcStream(PlatformGrpcRequest request, IServerStreamWriter<PlatformData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpcStream starting");
            ListPlatformData results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task<ListPlatformData> GetPlatformGrpcById(PlatformByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpcById starting");
            return await _MasterAccessService.GetPlatformsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListProgramData> GetProgramGrpc(ProgramGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpc starting");
            return await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task GetProgramGrpcStream(ProgramGrpcRequest request, IServerStreamWriter<ProgramData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpcStream starting");
            ListProgramData results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task<ListProgramData> GetProgramGrpcById(ProgramByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpcById starting");
            return await _MasterAccessService.GetProgramsById(request.Id , context.CancellationToken);
        }

        public override async Task<ListProjectData> GetProjectGrpc(ProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpc starting");
            return await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }

        public override async Task GetProjectGrpcStream(ProjectGrpcRequest request, IServerStreamWriter<ProjectData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpcStream starting");
            ListProjectData results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }
        public override async Task<ListProjectData> GetProjectGrpcById(ProjectByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpcById starting");
            return await _MasterAccessService.GetProjectsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListMilestoneData> GetMilestoneGrpc(MilestoneGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpc starting");
            return await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task GetMilestoneGrpcStream(MilestoneGrpcRequest request, IServerStreamWriter<MilestoneData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpcStream starting");
            ListMilestoneData results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task<ListMilestoneData> GetMilestoneGrpcById(MilestoneByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpcById starting");
            return await _MasterAccessService.GetMilestonesById(request.Id, context.CancellationToken);
        }

        #endregion

        #region Vehicle

        public override async Task<ListVehicleData> GetVehicleGrpc(VehicleGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpc starting");
            return await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }

        public override async Task GetVehicleGrpcStream(VehicleGrpcRequest request, IServerStreamWriter<VehicleData> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcStream starting");
            ListVehicleData results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }
        public override async Task<ListVehicleData> GetVehicleGrpcById(VehicleByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcById starting");
            return await _MasterAccessService.GetVehiclesById(request.Id ,context.CancellationToken);
        }

        public override async Task<ListVehicleData> GetVehicleGrpcByDisplay(VehicleByDisplayGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcByDisplay starting");
            return await _MasterAccessService.GetVehiclesByDisplay(request.VehicleDisplay ,context.CancellationToken);
        }

        #endregion
    }
}
