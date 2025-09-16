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
        public override async Task<ListCurrencyGrpc> GetCurrencyGrpc(CurrencyGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpc starting");
            return await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
        }

        public override async Task GetCurrencyGrpcStream(CurrencyGrpcRequest request, IServerStreamWriter<CurrencyGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpcStream starting");
            ListCurrencyGrpc results = await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
            foreach (CurrencyGrpc result in results.CurrencyGrpc)
            {
                await responseStream.WriteAsync(result);
            }
        }

        public override async Task<ListCurrencyGrpc> GetCurrencyGrpcById(CurrencyByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCurrencyGrpcById starting");
            return await _MasterAccessService.GetCurrenciesById(request.Id, context.CancellationToken);
        }
        #endregion

        #region Customer

        public override async Task<ListCustomerGrpc> GetCustomerGrpc(CustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpc starting");
            return await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task GetCustomerGrpcStream(CustomerGrpcRequest request, IServerStreamWriter<CustomerGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpcStream starting");
            ListCustomerGrpc results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task<ListCustomerGrpc> GetCustomerGrpcById(CustomerByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpcById starting");
            return await _MasterAccessService.GetCustomerBusinessUnitsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListCustomerLocationGrpc> GetCustomerLocationGrpc(CustomerLocationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpc starting");
            return await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task GetCustomerLocationGrpcStream(CustomerLocationGrpcRequest request, IServerStreamWriter<CustomerLocationGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcStream starting");
            ListCustomerLocationGrpc results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task<ListCustomerLocationGrpc> GetCustomerLocationGrpcById(CustomerLocationByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcById starting");
            return await _MasterAccessService.GetCustomerLocationsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListCustomerLocationGrpc> GetCustomerLocationGrpcByCustomerId(CustomerLocationByCustomerIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcById starting");
            return await _MasterAccessService.GetCustomerLocationsByCustomerId(request.CustomerId, context.CancellationToken);
        }
        public override async Task<ListCustomerLocationGrpc> GetCustomerLocationGrpcByUserId(CustomerLocationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcByUserId starting");
            return await _MasterAccessService.GetCustomerLocationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityGrpc> GetCustomerSalesEntityGrpc(CustomerSalesEntityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpc starting");
            return await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task GetCustomerSalesEntityGrpcStream(CustomerSalesEntityGrpcRequest request, IServerStreamWriter<CustomerSalesEntityGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpcStream starting");
            ListCustomerSalesEntityGrpc results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityGrpc> GetCustomerSalesEntityGrpcByUserId(CustomerSalesEntityByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpcByUserId starting");
            return await _MasterAccessService.GetAllCustomerSalesByUserIdEntities(request.UserId, context.CancellationToken);
        }

        public override async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationGrpc(CustomerProjectAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpc starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationGrpcByUserId(CustomerProjectAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcByUserId starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociationsByUserId(request.UserId ,context.CancellationToken);
        }

        public override async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationGrpcByLocationId(CustomerProjectAssociationByLocationIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcByLocationId starting");
            return await _MasterAccessService.GetCustomerProjectAssociationsByLocationId(request.LocationId, context.CancellationToken);
        }

        public override async Task GetCustomerProjectAssociationGrpcStream(CustomerProjectAssociationGrpcRequest request, IServerStreamWriter<CustomerProjectAssociationGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcStream starting");
            ListCustomerProjectAssociationGrpc result = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }

        public override async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociationGrpc(CustomerBusinessUserAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpc starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }
        public override async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociationGrpcByUserId(CustomerBusinessUserAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpcByUserId starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task GetCustomerBusinessUserAssociationGrpcStream(CustomerBusinessUserAssociationGrpcRequest request, IServerStreamWriter<CustomerBusinessUserAssociationGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpcStream starting");
            ListCustomerBusinessUserAssociationGrpc result = await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
        }

        #endregion

        #region Project

        public override async Task<ListPlatformGrpc> GetPlatformGrpc(PlatformGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpc starting");
            return await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task GetPlatformGrpcStream(PlatformGrpcRequest request, IServerStreamWriter<PlatformGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpcStream starting");
            ListPlatformGrpc results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task<ListPlatformGrpc> GetPlatformGrpcById(PlatformByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpcById starting");
            return await _MasterAccessService.GetPlatformsById(request.Id, context.CancellationToken);
        }

        public override async Task<ListProgramGrpc> GetProgramGrpc(ProgramGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpc starting");
            return await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task GetProgramGrpcStream(ProgramGrpcRequest request, IServerStreamWriter<ProgramGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpcStream starting");
            ListProgramGrpc results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task<ListProgramGrpc> GetProgramGrpcById(ProgramByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpcById starting");
            return await _MasterAccessService.GetProgramsById(request.Id , context.CancellationToken);
        }

        public override async Task<ListProjectGrpc> GetProjectGrpc(ProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpc starting");
            return await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }

        public override async Task GetProjectGrpcStream(ProjectGrpcRequest request, IServerStreamWriter<ProjectGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpcStream starting");
            ListProjectGrpc results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }
        public override async Task<ListProjectGrpc> GetProjectGrpcById(ProjectByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpcById starting");
            return await _MasterAccessService.GetProjectsById(request.Id, context.CancellationToken);
        }
        public override async Task<ListMilestoneGrpc> GetMilestoneGrpc(MilestoneGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpc starting");
            return await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task GetMilestoneGrpcStream(MilestoneGrpcRequest request, IServerStreamWriter<MilestoneGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpcStream starting");
            ListMilestoneGrpc results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        public override async Task<ListMilestoneGrpc> GetMilestoneGrpcById(MilestoneByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpcById starting");
            return await _MasterAccessService.GetMilestonesById(request.Id, context.CancellationToken);
        }

        #endregion

        #region Vehicle

        public override async Task<ListVehicleGrpc> GetVehicleGrpc(VehicleGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpc starting");
            return await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }

        public override async Task GetVehicleGrpcStream(VehicleGrpcRequest request, IServerStreamWriter<VehicleGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcStream starting");
            ListVehicleGrpc results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }
        public override async Task<ListVehicleGrpc> GetVehicleGrpcById(VehicleByIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcById starting");
            return await _MasterAccessService.GetVehiclesById(request.Id ,context.CancellationToken);
        }

        public override async Task<ListVehicleGrpc> GetVehicleGrpcByDisplay(VehicleByDisplayGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcByDisplay starting");
            return await _MasterAccessService.GetVehiclesByDisplay(request.VehicleDisplay ,context.CancellationToken);
        }

        #endregion
    }
}
