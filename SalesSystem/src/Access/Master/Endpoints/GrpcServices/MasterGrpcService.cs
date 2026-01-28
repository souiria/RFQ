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
            return await _MasterAccessService.GetAllCurrencies(context.CancellationToken, request.Position, request.Takeamount);
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
        #endregion

        #region Customer

        public override async Task<ListCustomerGrpc> GetCustomerGrpc(CustomerGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpc starting");
            return await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetCustomerGrpcStream(CustomerGrpcRequest request, IServerStreamWriter<CustomerGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerGrpcStream starting");
            ListCustomerGrpc results = await _MasterAccessService.GetAllCustomerBusinessUnits(context.CancellationToken);
        }

        public override async Task<ListCustomerLocationGrpc> GetCustomerLocationGrpc(CustomerLocationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpc starting");
            return await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetCustomerLocationGrpcStream(CustomerLocationGrpcRequest request, IServerStreamWriter<CustomerLocationGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerLocationGrpcStream starting");
            ListCustomerLocationGrpc results = await _MasterAccessService.GetAllCustomerLocations(context.CancellationToken);
        }

        public override async Task<ListCustomerSalesEntityGrpc> GetCustomerSalesEntityGrpc(CustomerSalesEntityGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpc starting");
            return await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetCustomerSalesEntityGrpcStream(CustomerSalesEntityGrpcRequest request, IServerStreamWriter<CustomerSalesEntityGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerSalesEntityGrpcStream starting");
            ListCustomerSalesEntityGrpc results = await _MasterAccessService.GetAllCustomerSalesEntities(context.CancellationToken);
        }

        public override async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationGrpc(CustomerProjectAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpc starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken, request.Position, request.Takeamount);
        }
        public override async Task<ListCustomerProjectAssociationGrpc> GetCustomerProjectAssociationGrpcByUserId(CustomerProjectAssociationByUserIdGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcByUserId starting");
            return await _MasterAccessService.GetAllCustomerProjectAssociationsByUserId(request.UserId, context.CancellationToken);
        }

        public override async Task GetCustomerProjectAssociationGrpcStream(CustomerProjectAssociationGrpcRequest request, IServerStreamWriter<CustomerProjectAssociationGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerProjectAssociationGrpcStream starting");
            ListCustomerProjectAssociationGrpc result = await _MasterAccessService.GetAllCustomerProjectAssociations(context.CancellationToken);
        }

        public override async Task<ListCustomerBusinessUserAssociationGrpc> GetCustomerBusinessUserAssociationGrpc(CustomerBusinessUserAssociationGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetCustomerBusinessUserAssociationGrpc starting");
            return await _MasterAccessService.GetCustomerBusinessUserAssociations(context.CancellationToken, request.Position, request.Takeamount);
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
            return await _MasterAccessService.GetAllPlatforms(context.CancellationToken, request.Position, request.Takeamount);
        }
        public override async Task GetPlatformGrpcStream(PlatformGrpcRequest request, IServerStreamWriter<PlatformGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetPlatformGrpcStream starting");
            ListPlatformGrpc results = await _MasterAccessService.GetAllPlatforms(context.CancellationToken);
        }
        public override async Task<ListProgramGrpc> GetProgramGrpc(ProgramGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpc starting");
            return await _MasterAccessService.GetAllPrograms(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetProgramGrpcStream(ProgramGrpcRequest request, IServerStreamWriter<ProgramGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProgramGrpcStream starting");
            ListProgramGrpc results = await _MasterAccessService.GetAllPrograms(context.CancellationToken);
        }

        public override async Task<ListProjectGrpc> GetProjectGrpc(ProjectGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpc starting");
            return await _MasterAccessService.GetAllProjects(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetProjectGrpcStream(ProjectGrpcRequest request, IServerStreamWriter<ProjectGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetProjectGrpcStream starting");
            ListProjectGrpc results = await _MasterAccessService.GetAllProjects(context.CancellationToken);
        }

        public override async Task<ListMilestoneGrpc> GetMilestoneGrpc(MilestoneGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpc starting");
            return await _MasterAccessService.GetAllMilestones(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetMilestoneGrpcStream(MilestoneGrpcRequest request, IServerStreamWriter<MilestoneGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetMilestoneGrpcStream starting");
            ListMilestoneGrpc results = await _MasterAccessService.GetAllMilestones(context.CancellationToken);
        }

        #endregion

        #region Vehicle

        public override async Task<ListVehicleGrpc> GetVehicleGrpc(VehicleGrpcRequest request, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpc starting");
            return await _MasterAccessService.GetAllVehicles(context.CancellationToken, request.Position, request.Takeamount);
        }

        public override async Task GetVehicleGrpcStream(VehicleGrpcRequest request, IServerStreamWriter<VehicleGrpc> responseStream, ServerCallContext context)
        {
            _Logger.GenericLogInformation("GetVehicleGrpcStream starting");
            ListVehicleGrpc results = await _MasterAccessService.GetAllVehicles(context.CancellationToken);
        }

        #endregion

        public override async Task<MastersFilterResponseGrpc> FilterMasterDataGrpc(MastersFilterRequestGrpc request, ServerCallContext context)
        {
            ParsingConfig parsingConfig = new ParsingConfig();
            string filterExpressionString = request.FilterExpression;

            MastersFilterResponseGrpc returnResponse = new MastersFilterResponseGrpc();

            switch (request.DatabaseList.ToUpperInvariant())
            {
                case "CURRENCYGRPC":
                await _MasterAccessService.HandleFilterCase<CurrencyGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCurrencyGrpc returnList = new ListCurrencyGrpc();
                    returnList.CurrencyGrpc.AddRange(filterList);
                    returnResponse.CurrencyGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "CUSTOMERGRPC":
                await _MasterAccessService.HandleFilterCase<CustomerGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCustomerGrpc returnList = new ListCustomerGrpc();
                    returnList.CustomerGrpc.AddRange(filterList);
                    returnResponse.CustomerGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "CUSTOMERLOCATIONGRPC":
                try
                {
                    await _MasterAccessService.HandleFilterCase<CustomerLocationGrpc>(filterExpressionString, parsingConfig,
                    filterList =>
                    {
                        ListCustomerLocationGrpc returnList = new ListCustomerLocationGrpc();
                        returnList.CustomerLocationGrpc.AddRange(filterList);
                        returnResponse.CustomerLocationGrpcList = returnList;
                        returnResponse.Success = true;
                    }, context.CancellationToken);
                }
                catch (ParseException ex)
                {
                    _Logger.GenericLogError($"Filter parsing failed. Expression: '{filterExpressionString}'. Error: {ex.Message}", ex);
                    throw;
                }

                break;
                case "CUSTOMERSALESENTITYGRPC":
                await _MasterAccessService.HandleFilterCase<CustomerSalesEntityGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCustomerSalesEntityGrpc returnList = new ListCustomerSalesEntityGrpc();
                    returnList.CustomerSalesEntityGrpc.AddRange(filterList);
                    returnResponse.CustomerSalesEntityGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "CUSTOMERPROJECTASSOCIATIONGRPC":
                await _MasterAccessService.HandleFilterCase<CustomerProjectAssociationGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCustomerProjectAssociationGrpc returnList = new ListCustomerProjectAssociationGrpc();
                    returnList.CustomerProjectAssociationGrpc.AddRange(filterList);
                    returnResponse.CustomerProjectAssociationGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "CUSTOMERBUSINESSUSERASSOCIATIONGRPC":
                await _MasterAccessService.HandleFilterCase<CustomerBusinessUserAssociationGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListCustomerBusinessUserAssociationGrpc returnList = new ListCustomerBusinessUserAssociationGrpc();
                    returnList.CustomerBusinessUserAssociationGrpc.AddRange(filterList);
                    returnResponse.CustomerBusinessUserAssociationGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "MILESTONEGRPC":
                await _MasterAccessService.HandleFilterCase<MilestoneGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListMilestoneGrpc returnList = new ListMilestoneGrpc();
                    returnList.MilestoneGrpc.AddRange(filterList);
                    returnResponse.MilestoneGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "PLATFORMGRPC":
                await _MasterAccessService.HandleFilterCase<PlatformGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListPlatformGrpc returnList = new ListPlatformGrpc();
                    returnList.PlatformGrpc.AddRange(filterList);
                    returnResponse.PlatformGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "PROGRAMGRPC":
                await _MasterAccessService.HandleFilterCase<ProgramGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListProgramGrpc returnList = new ListProgramGrpc();
                    returnList.ProgramGrpc.AddRange(filterList);
                    returnResponse.ProgramGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "PROJECTGRPC":
                await _MasterAccessService.HandleFilterCase<ProjectGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListProjectGrpc returnList = new ListProjectGrpc();
                    returnList.ProjectGrpc.AddRange(filterList);
                    returnResponse.ProjectGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;
                case "VEHICLEGRPC":
                await _MasterAccessService.HandleFilterCase<VehicleGrpc>(filterExpressionString, parsingConfig,
                filterList =>
                {
                    ListVehicleGrpc returnList = new ListVehicleGrpc();
                    returnList.VehicleGrpc.AddRange(filterList);
                    returnResponse.VehicleGrpcList = returnList;
                    returnResponse.Success = true;
                }, context.CancellationToken);
                break;

            }

            return returnResponse;
        }
    }
}
