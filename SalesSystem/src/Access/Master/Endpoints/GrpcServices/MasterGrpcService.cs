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
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        #region Currency
        public override async Task<ListCurrencyData> GetCurrencyData(CurrencyGrpcRequest request, ServerCallContext context)
        {
            ListCurrencyData listCurrencyData = new();
            Result<List<CurrencyDto>> results = await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
            foreach (CurrencyDto result in results.Value)
            {
                listCurrencyData.CurrencyData.Add(result.MapToCurrencyData());
            }

            return listCurrencyData;
        }

        public override async Task GetCurrencyDataStream(CurrencyGrpcRequest request, IServerStreamWriter<CurrencyData> responseStream, ServerCallContext context)
        {
            Result<List<CurrencyDto>> results = await _MasterAccessService.GetAllCurrencies(context.CancellationToken);
            foreach (CurrencyDto result in results.Value)
            {
                CurrencyData item = result.MapToCurrencyData();
                await responseStream.WriteAsync(item);
            }
        }
        #endregion

        #region Customer

        public override async Task<ListCustomerData> GetCustomerData(CustomerGrpcRequest request, ServerCallContext context)
        {
            ListCustomerData listCustomerData = new();
            Result<List<CustomerBusinessHierarchyDto>> results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
            foreach (CustomerBusinessHierarchyDto result in results.Value)
            {
                listCustomerData.CustomerData.Add(result.MapToCustomerData());
            }

            return listCustomerData;
        }

        public override async Task GetCustomerDataStream(CustomerGrpcRequest request, IServerStreamWriter<CustomerData> responseStream, ServerCallContext context)
        {
            Result<List<CustomerBusinessHierarchyDto>> results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
            foreach (CustomerBusinessHierarchyDto result in results.Value)
            {
                CustomerData item = result.MapToCustomerData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListCustomerLocationData> GetCustomerLocationData(CustomerLocationGrpcRequest request, ServerCallContext context)
        {
            ListCustomerLocationData listCustomerLocationData = new();
            Result<List<CustomerHierarchyDto>> results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
            foreach (CustomerHierarchyDto result in results.Value)
            {
                listCustomerLocationData.CustomerLocationData.Add(result.MapToCustomerLocationData());
            }

            return listCustomerLocationData;
        }

        public override async Task GetCustomerLocationDataStream(CustomerLocationGrpcRequest request, IServerStreamWriter<CustomerLocationData> responseStream, ServerCallContext context)
        {
            Result<List<CustomerHierarchyDto>> results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
            foreach (CustomerHierarchyDto result in results.Value)
            {
                CustomerLocationData item = result.MapToCustomerLocationData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListCustomerSalesEntityData> GetCustomerSalesEntityData(CustomerSalesEntityGrpcRequest request, ServerCallContext context)
        {
            ListCustomerSalesEntityData listCustomerSalesEntityData = new();
            Result<List<CustomerSalesEntityDto>> results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
            foreach (CustomerSalesEntityDto result in results.Value)
            {
                listCustomerSalesEntityData.CustomerSalesEntityData.Add(result.MapToCustomerSalesEntityData());
            }

            return listCustomerSalesEntityData;
        }

        public override async Task GetCustomerSalesEntityDataStream(CustomerSalesEntityGrpcRequest request, IServerStreamWriter<CustomerSalesEntityData> responseStream, ServerCallContext context)
        {
            Result<List<CustomerSalesEntityDto>> results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
            foreach (CustomerSalesEntityDto result in results.Value)
            {
                CustomerSalesEntityData item = result.MapToCustomerSalesEntityData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListCustomerProjectAssociationData> GetCustomerProjectAssociationData(CustomerProjectAssociationGrpcRequest request, ServerCallContext context)
        {
            ListCustomerProjectAssociationData listCustomerProjectAssociationData = new();
            Result<List<CustomerProjectAssociationDto>> results = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
            foreach (CustomerProjectAssociationDto result in results.Value)
            {
                listCustomerProjectAssociationData.CustomerProjectAssociationData.Add(result.MapToCustomerProjectAssociationData());
            }

            return listCustomerProjectAssociationData;
        }

        public override async Task GetCustomerProjectAssociationDataStream(CustomerProjectAssociationGrpcRequest request, IServerStreamWriter<CustomerProjectAssociationData> responseStream, ServerCallContext context)
        {
            Result<List<CustomerProjectAssociationDto>> results = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
            foreach (CustomerProjectAssociationDto result in results.Value)
            {
                CustomerProjectAssociationData item = result.MapToCustomerProjectAssociationData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationData(CustomerBusinessUserAssociationGrpcRequest request, ServerCallContext context)
        {
            ListCustomerBusinessUserAssociationData listCustomerBusinessUserAssociationData = new();
            Result<List<CustomerBusinessUserAssociationDto>> results = await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
            foreach (CustomerBusinessUserAssociationDto result in results.Value)
            {
                listCustomerBusinessUserAssociationData.CustomerBusinessUserAssociationData.Add(result.MapToCustomerBusinessUserAssociationData());
            }

            return listCustomerBusinessUserAssociationData;
        }

        public override async Task GetCustomerBusinessUserAssociationDataStream(CustomerBusinessUserAssociationGrpcRequest request, IServerStreamWriter<CustomerBusinessUserAssociationData> responseStream, ServerCallContext context)
        {
            Result<List<CustomerBusinessUserAssociationDto>> results = await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken);
            foreach (CustomerBusinessUserAssociationDto result in results.Value)
            {
                CustomerBusinessUserAssociationData item = result.MapToCustomerBusinessUserAssociationData();
                await responseStream.WriteAsync(item);
            }
        }

        #endregion

        #region Project

        public override async Task<ListPlatformData> GetPlatformData(PlatformGrpcRequest request, ServerCallContext context)
        {
            ListPlatformData listPlatformData = new();
            Result<List<PlatformHierarchyDto>> results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
            foreach (PlatformHierarchyDto result in results.Value)
            {
                listPlatformData.PlatformData.Add(result.MapToData());
            }

            return listPlatformData;
        }

        public override async Task GetPlatformDataStream(PlatformGrpcRequest request, IServerStreamWriter<PlatformData> responseStream, ServerCallContext context)
        {
            Result<List<PlatformHierarchyDto>> results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
            foreach (PlatformHierarchyDto result in results.Value)
            {
                PlatformData item = result.MapToData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListProgramData> GetProgramData(ProgramGrpcRequest request, ServerCallContext context)
        {
            ListProgramData listProgramData = new();
            Result<List<ProgramHierarchyDto>> results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
            foreach (ProgramHierarchyDto result in results.Value)
            {
                listProgramData.ProgramData.Add(result.MapToData());
            }

            return listProgramData;
        }

        public override async Task GetProgramDataStream(ProgramGrpcRequest request, IServerStreamWriter<ProgramData> responseStream, ServerCallContext context)
        {
            Result<List<ProgramHierarchyDto>> results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
            foreach (ProgramHierarchyDto result in results.Value)
            {
                ProgramData item = result.MapToData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListProjectData> GetProjectData(ProjectGrpcRequest request, ServerCallContext context)
        {
            ListProjectData data = new();
            Result<List<ProjectHierarchyDto>> results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
            foreach (ProjectHierarchyDto result in results.Value)
            {
                data.ProjectData.Add(result.MapToData());
            }

            return data;
        }

        public override async Task GetProjectDataStream(ProjectGrpcRequest request, IServerStreamWriter<ProjectData> responseStream, ServerCallContext context)
        {
            Result<List<ProjectHierarchyDto>> results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
            foreach (ProjectHierarchyDto result in results.Value)
            {
                ProjectData item = result.MapToData();
                await responseStream.WriteAsync(item);
            }
        }

        public override async Task<ListMilestoneData> GetMilestoneData(MilestoneGrpcRequest request, ServerCallContext context)
        {
            ListMilestoneData data = new();
            Result<List<MilestoneHierarchyDto>> results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
            foreach (MilestoneHierarchyDto result in results.Value)
            {
                data.MilestoneData.Add(result.MapToData());
            }

            return data;
        }

        public override async Task GetMilestoneDataStream(MilestoneGrpcRequest request, IServerStreamWriter<MilestoneData> responseStream, ServerCallContext context)
        {
            Result<List<MilestoneHierarchyDto>> results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
            foreach (MilestoneHierarchyDto result in results.Value)
            {
                MilestoneData item = result.MapToData();
                await responseStream.WriteAsync(item);
            }
        }

        #endregion

        #region Vehicle

        public override async Task<ListVehicleData> GetVehicleData(VehicleGrpcRequest request, ServerCallContext context)
        {
            ListVehicleData data = new();
            Result<List<VehicleDto>> results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
            foreach (VehicleDto result in results.Value)
            {
                data.VehicleData.Add(result.MapToData());
            }

            return data;
        }

        public override async Task GetVehicleDataStream(VehicleGrpcRequest request, IServerStreamWriter<VehicleData> responseStream, ServerCallContext context)
        {
            Result<List<VehicleDto>> results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
            foreach (VehicleDto result in results.Value)
            {
                VehicleData item = result.MapToData();
                await responseStream.WriteAsync(item);
            }
        }

        #endregion
    }
}
