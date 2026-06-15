namespace RfqModule.Services
{
    public class RfqManagerService : IRfqManagerService
    {

        readonly MasterClient _MasterClient;
        readonly Rfq.Rfq.RfqClient _RfqClient;
        readonly Emacs.Emacs.EmacsClient _EmacsClient;
        readonly Adss.AdssGrpc.AdssGrpcClient _AdssGrpcClient;
        readonly NPR.NPR.NPRClient _NPRGrpcClient;
        readonly CPD.CPD.CPDClient _CPDClient;
        readonly DSI.DSI.DSIClient _DSIClient;
        readonly ILogger<RfqManagerService> _Logger;
        readonly IHttpContextAccessor _HttpContextAccessor;
        List<ProjectGrpc> _Projects;

        public RfqManagerService(ILogger<RfqManagerService> logger,
              MasterClient masterClient,
            Rfq.Rfq.RfqClient rfqClient,
            Emacs.Emacs.EmacsClient emacsClient,
            Adss.AdssGrpc.AdssGrpcClient adssGrpcClient,
            NPR.NPR.NPRClient nprClient,
            CPD.CPD.CPDClient cPDClient,
            DSI.DSI.DSIClient dSIClient,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _Logger = logger;
            _MasterClient = masterClient;
            _RfqClient = rfqClient;
            _Projects = new List<ProjectGrpc>();
            _EmacsClient = emacsClient;
            _AdssGrpcClient = adssGrpcClient;
            _NPRGrpcClient = nprClient;
            _CPDClient = cPDClient;
            _DSIClient = dSIClient;
            _HttpContextAccessor = httpContextAccessor;
        }
        #region Master Requests
        public async Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc (GetAllCustomersGrpcRequest request)
        {
            try
            {
                // Call the Master service to get all masterCustomers
                await Task.Delay(1);
                CustomerGrpcRequest getCustomersRequest = new CustomerGrpcRequest();
                getCustomersRequest.Position = request.Position;
                getCustomersRequest.Takeamount = request.Take;
                ListCustomerGrpc customers = _MasterClient.GetCustomerGrpc(getCustomersRequest);
                GetAllCustomersGrpcResponse getAllCustomersGrpcResponse = new GetAllCustomersGrpcResponse();                
                foreach (Master.CustomerGrpc? masterCustomer in customers.CustomerGrpc)
                {
                    CustomerGrpc customer = masterCustomer.ToCustomerGrpc();
                    getAllCustomersGrpcResponse.Customers.Add(customer);
                }

                return getAllCustomersGrpcResponse;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching masterCustomers from Master service", ex);
                throw;
            }
        }
        // add adlogin to request 
        public async Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request)
        {
            try
            {
                await Task.Delay(1);
                _Projects.Clear();
                GetProjectAssociationsByCustomerIdResponse response = new GetProjectAssociationsByCustomerIdResponse();

                MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
                filterRequest.DatabaseList = "CUSTOMERLOCATIONGRPC";
#pragma warning disable CA1308
                filterRequest.FilterExpression = $"CustomerBusinessHierarchyGuid != null && CustomerBusinessHierarchyGuid.ToUpperInvariant() == \"{request.CustomerId.ToUpperInvariant()}\"";
#pragma warning restore CA1308
                MastersFilterResponseGrpc locations = _MasterClient.FilterMasterDataGrpc(filterRequest);
                // List<CustomerLocationGrpc> extractedLocations = ExtractMastersResponseData<CustomerLocationGrpc>(locations).ToList();
                List<CustomerLocationGrpc> extractedLocations = locations.CustomerLocationGrpcList.CustomerLocationGrpc
                    .Select(loc => loc.ToCustomerLocation())
                    .Where(loc => loc.CustomerBusinessHierarchyGuid != null && loc.CustomerBusinessHierarchyGuid.Equals(request.CustomerId, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                if (extractedLocations.Count <= 0)
                {
                    response.Message = "No locations found for customer";
                    response.Success = false;
                    return response;
                }

                // load innermost loop in memory
                filterRequest.DatabaseList = "PROJECTGRPC";
                filterRequest.FilterExpression = $"Id != null";
                MastersFilterResponseGrpc projects = _MasterClient.FilterMasterDataGrpc(filterRequest);
                List<ProjectGrpc> allProjects = ExtractMastersResponseData<ProjectGrpc>(projects).ToList();

                // load second loop in memory
                filterRequest.DatabaseList = "CUSTOMERPROJECTASSOCIATIONGRPC";
#pragma warning disable CA1308
                filterRequest.FilterExpression = $"CustomerLocationGuid != null";
#pragma warning restore CA1308
                MastersFilterResponseGrpc projectAssociations = _MasterClient.FilterMasterDataGrpc(filterRequest);
                // List<CustomerProjectAssociationGrpc> allProjectAssociations = ExtractMastersResponseData<CustomerProjectAssociationGrpc>(projectAssociations).ToList();
                List<CustomerProjectAssociationGrpc> allProjectAssociations = projectAssociations.CustomerProjectAssociationGrpcList.CustomerProjectAssociationGrpc
                    .Select(assoc => assoc.ToCustomerProjectAssociation())
                    .Where(assoc => assoc.CustomerLocationGuid != null)
                    .ToList();
                // get all projectbusiness associations and filter if ADLogon matches allProjectAssociations project guid, if yes add to list, then filter projects based on login, then add to response
                //filterRequest.DatabaseList = "PROJECTBUSINESSASSOCIATIONGRPC";
                //filterRequest.FilterExpression = $"IsActive == true && AdLogin != null && AdLogin.ToUpperInvariant() == \"{request.ADlogin.ToUpperInvariant()}\"";
                //MastersFilterResponseGrpc projectEngineeringAssociations = _MasterClient.FilterMasterDataGrpc(filterRequest);

                //// this needs to be filtered by customerlocation id == ProjectEngineeringAssociationGrpc.CustomerId
                ////List<ProjectEngineeringAssociationGrpc> extractedAssociations = projectEngineeringAssociations.ProjectEngineeringAssociationGrpcList.ProjectEngineeringAssociationGrpc
                ////                    .Where(x => x.Id != null && x.Id.Equals(, StringComparison.OrdinalIgnoreCase))
                ////                    .ToList();

                foreach (CustomerLocationGrpc? location in extractedLocations)
                {
                    //                    filterRequest.DatabaseList = "CUSTOMERPROJECTASSOCIATIONGRPC";
                    //#pragma warning disable CA1308
                    //                    // filterRequest.FilterExpression = $"CustomerGuid != null && CustomerGuid == \"{location.Id.ToUpperInvariant()}\"";
                    //                    filterRequest.FilterExpression = $"CustomerLocationGuid != null && CustomerLocationGuid.ToUpperInvariant() == \"{location.Id.ToUpperInvariant()}\"";
                    //#pragma warning restore CA1308
                    //                    MastersFilterResponseGrpc projectAssociations = _MasterClient.FilterMasterDataGrpc(filterRequest);
                    List<CustomerProjectAssociationGrpc> extractedProjectAssociations = allProjectAssociations
                        .Where(assoc => assoc.CustomerLocationGuid != null && assoc.CustomerLocationGuid.Equals(location.Id, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    //List<ProjectEngineeringAssociationGrpc> extractedProjectEngineeringAssociations = projectEngineeringAssociations.ProjectEngineeringAssociationGrpcList.ProjectEngineeringAssociationGrpc
                    //    .Where(x => x.CustomerGuid != null && x.Id.Equals(location.Id, StringComparison.OrdinalIgnoreCase))
                    //    .ToList();

                    //List<CustomerProjectAssociationGrpc> customerAndEngineerProjects = new List<CustomerProjectAssociationGrpc>();

                    //foreach (ProjectEngineeringAssociationGrpc? projectEngineeringAssociation in extractedProjectEngineeringAssociations)
                    //{
                    //    IEnumerable<CustomerProjectAssociationGrpc> associatedProjects = extractedProjectAssociations.Where(p => p.ProjectGuid == projectEngineeringAssociation.ProjectGuid);
                    //    customerAndEngineerProjects.AddRange(associatedProjects);
                    //}

                    foreach (CustomerProjectAssociationGrpc? customerProjectAssociation in extractedProjectAssociations)
                    {
                        if (customerProjectAssociation.ProjectGuid == null)
                        {
                            continue;
                        }

                        //filterRequest.DatabaseList = "PROJECTGRPC";
                        //filterRequest.FilterExpression = $"Id != null && Id.ToUpperInvariant() == \"{customerProjectAssociation.ProjectGuid.ToUpperInvariant()}\"";
                        //MastersFilterResponseGrpc projects = _MasterClient.FilterMasterDataGrpc(filterRequest);
                        //List<ProjectGrpc> extractedProjects = ExtractMastersResponseData<ProjectGrpc>(projects).ToList();
                        List<ProjectGrpc> extractedProjects = allProjects
                            .Where(p => p.Id != null && p.Id.Equals(customerProjectAssociation.ProjectGuid, StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        if (extractedProjects.Count <= 0)
                        {
                            continue;
                        }

                        _Projects.AddRange(extractedProjects);
                        foreach (ProjectGrpc? project in extractedProjects)
                        {
                            ProjectAssociation projectAssociation = new ProjectAssociation();
                            projectAssociation.CustomerLocationGuid = location.Id.ToUpperInvariant();
                            projectAssociation.CustomerLocationName = location.CustomerName;
                            projectAssociation.CustomerCode = location.CustomerCode;
                            projectAssociation.CustomerProjectGuid = project.Id.ToUpperInvariant();
                            projectAssociation.CustomerProjectName = project.ProjectName;
                            projectAssociation.CustomerProjectCode = project.CustomerProjectCode;
                            projectAssociation.Id = customerProjectAssociation.Id;
                            response.ProjectAssociation.Add(projectAssociation);
                        }
                    }
                }

                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching project associations from Master service", ex);
                throw;
            }
        }

        public async Task<List<VehicleGrpc>> GetVehiclesByProjectCodeGrpc(string projectCode)
        {
            try
            {
                // Call the Master service to get vehicles by project reference
                await Task.Delay(1);
                VehicleGrpcRequest vehicleRequest = new VehicleGrpcRequest();
                ListVehicleGrpc vehicles = _MasterClient.GetVehicleGrpc(vehicleRequest);
                List<VehicleGrpc> filteredVehicles = new List<VehicleGrpc>();
                foreach (Master.VehicleGrpc? vehicle in vehicles.VehicleGrpc)
                {
                    //_Logger.GenericLogInformation("Vehicle from Master Service: " + vehicle.ToString());
                    if (vehicle.ProjectReference.Contains('+', StringComparison.InvariantCulture))
                    {
                        string[] codes = vehicle.ProjectReference.Split('+');
                        foreach (string code in codes)
                        {
                            if (string.IsNullOrWhiteSpace(code))
                            {
                                continue;
                            }

                            if (projectCode.Contains(code, StringComparison.OrdinalIgnoreCase))
                            {
                                VehicleGrpc filteredVehicle = vehicle.ToVehicle();
                                filteredVehicles.Add(filteredVehicle);
                            }
                        }
                    }

                    if (projectCode.Contains(vehicle.ProjectReference, StringComparison.OrdinalIgnoreCase))
                    {
                        VehicleGrpc filteredVehicle = vehicle.ToVehicle();
                        filteredVehicles.Add(filteredVehicle);
                    }
                }

                _Logger.GenericLogInformation($"III RfqManagerService.GetVehiclesByProjectCodeGrpc Filtered vehicles from Master Service: {filteredVehicles.Count}");

                return filteredVehicles;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching vehicles from Master service", ex);
                throw;
            }
        }
        #endregion

        public async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request)
        {
            try
            {
                // Call the Rfq service to get RFQ reasons
                await Task.Delay(1);
                RfqReasonGrpcRequest rfqReasonRequest = new RfqReasonGrpcRequest();
                RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqGrpcRequestParameter.Position = request.Position;
                rfqGrpcRequestParameter.Take = request.Take;
                rfqGrpcRequestParameter.RequestType = request.RequestType;
                rfqReasonRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
                RfqFilterRequest reasonFilterRequest = new RfqFilterRequest();
                reasonFilterRequest.DatabaseList = "RFQREASONGRPC";
                reasonFilterRequest.FilterExpression = "ReasonTitle != null && ReasonTitle != \"\"";
               RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();

                GetRfqReasonsGrpcResponse response = new GetRfqReasonsGrpcResponse();
                foreach (Rfq.RfqReasonGrpc? reason in rfqReasons.RfqReasons)
                {
                    RfqReasonGrpc rfqReason = reason.ToReason();
                    response.RfqReasons.Add(rfqReason);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching RFQ reasons from Master service", ex);
                throw;
            }
        }

        public async Task<GetAllUnitOfMeasuresResponse> GetAllUnitOfMeasuresGrpc(GetAllUnitOfMeasuresRequest request)
        {
            try
            {
                await Task.Delay(1);
                GetAllUnitOfMeasuresResponse response = new GetAllUnitOfMeasuresResponse();
                UnitOfMeasureGrpcRequest unitOfMeasureRequest = new UnitOfMeasureGrpcRequest();
                unitOfMeasureRequest.Position = request.Position;
                unitOfMeasureRequest.Takeamount = request.Take;
                ListUnitOfMeasureGrpc allUnitOfMeasures =  await _MasterClient.GetUnitOfMeasureGrpcAsync(unitOfMeasureRequest);
                
                foreach(Master.UnitOfMeasureGrpc unitOfMeasure in allUnitOfMeasures.UnitOfMeasureGrpc)
                {
                    UnitOfMeasureGrpc uom = unitOfMeasure.ToUnitOfMeasureGrpc();
                    response.UnitOfMeasureGrpc.Add(uom);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching Unit of Measures from Master service", ex);
                throw;
            }
        }

        public async Task<GetAllBusinessUnitsGrpcResponse> GetAllBusinessUnitsGrpc(GetAllBusinessUnitsGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);
                GetAllBusinessUnitsGrpcResponse response = new GetAllBusinessUnitsGrpcResponse();
                BusinessUnitGrpcRequest businessUnitsGrpcRequest = new BusinessUnitGrpcRequest();
                businessUnitsGrpcRequest.Position = request.Position;
                businessUnitsGrpcRequest.Takeamount = request.Take;
                ListBusinessUnitGrpc allBusinessUnits = await _MasterClient.GetBusinessUnitGrpcAsync(businessUnitsGrpcRequest);

                foreach (Master.BusinessUnitGrpc unitOfMeasure in allBusinessUnits.BusinessUnitGrpc)
                {
                    BusinessUnitGrpc businessUnit = unitOfMeasure.ToBusinessUnitGrpc();
                    response.BusinessUnitGrpc.Add(businessUnit);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching Unit of Measures from Master service", ex);
                throw;
            }
        }
        #region RfqProject
        public async Task<RfqCrudResponse> DeleteRfqProjectByRowIdGrpc(RfqProjectRequest request)
        {
            try
            {
                await Task.Delay(1);

                long rowId = request.RowId;

                RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqGrpcRequestParameter.RequestType = 3;

                RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();
                rfqProjectRequest.RowId = rowId;
                rfqProjectRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
                RfqCrudGrpcResponse grpcResponse =  _RfqClient.DeleteRfqProjectByRowIdGrpc(rfqProjectRequest);
                bool result = grpcResponse.SaveSuccess;
          
                string message;
                if (result)
                {
                    message = $"RFQ project with RowId {rowId} marked as inactive.";
                }
                else
                {
                    message = $"RFQ project with RowId {rowId} not found.";
                }

                RfqCrudResponse response = new RfqCrudResponse();
                response.SaveSuccess = result;
                response.Message = message;

                return response;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error deleting RFQ project by RowId: {request.RowId}";
                _Logger.GenericLogError(errorMessage, ex);
                throw;
            }
        }
        public async Task<GetAllRfqProjectGrpcResponse> GetAllRfqProjectGrpc(GetAllRfqProjectGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);
                RfqFilterRequest rfqFilterRequest = new RfqFilterRequest();

                rfqFilterRequest.DatabaseList = "RFQPROJECTGRPC";
                rfqFilterRequest.FilterExpression = "(IsActive == true)";

                RfqFilterResponse rfqFilterResponse = _RfqClient.FilterRfqGrpc(rfqFilterRequest);

                // Single declaration; no duplicate variable names
                ListRfqProjectGrpc rfqProjects = rfqFilterResponse.ListRfqProjectGrpc ?? new ListRfqProjectGrpc();

                // Fetch RFQ reasons=
                RfqReasonGrpcRequest rfqReasonRequest = new RfqReasonGrpcRequest();
                RfqGrpcRequestParameter reasonRequestParameter = new RfqGrpcRequestParameter();
                reasonRequestParameter.Position = 0;
                reasonRequestParameter.Take = 100;
                reasonRequestParameter.RequestType = 1;
                rfqReasonRequest.RfqGrpcRequestParameter = reasonRequestParameter;
                RfqFilterRequest reasonFilterRequest = new RfqFilterRequest();
                reasonFilterRequest.DatabaseList = "RFQREASONGRPC";
                reasonFilterRequest.FilterExpression = "ReasonTitle != null && ReasonTitle != \"\"";

                RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();
                // Build reason lookup
                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId != 0 && r.ReasonTitle != null)
                    .ToDictionary(r => r.RowId, r => r.ReasonTitle);

                // Fetch masterCustomers
                GetAllCustomersGrpcRequest customerRequest = new GetAllCustomersGrpcRequest();
                customerRequest.Position = 0;
                customerRequest.Take = 1000;

                GetAllCustomersGrpcResponse customerResponse = await GetAllCustomersGrpc(customerRequest);

                // Build customer lookup
                Dictionary<string, string> customerLookup = customerResponse.Customers
                    .Where(c => c.Id != null && c.CustomerBusinessGroupCode != null)
                    .ToDictionary(c => c.Id, c => c.CustomerBusinessGroupCode);

                // Fetch customer locations
                CustomerLocationGrpcRequest customerLocationRequest = new CustomerLocationGrpcRequest();
                customerLocationRequest.Position = 0;
                customerLocationRequest.Takeamount = 1000;
                ListCustomerLocationGrpc listCustomerLocationLookup = _MasterClient.GetCustomerLocationGrpc(customerLocationRequest);

                Dictionary<string, string> locationLookup = listCustomerLocationLookup.CustomerLocationGrpc
                    .Where(l => l.Id != null && l.CustomerCode != null)
                    .ToDictionary(l => l.Id, l => l.CustomerCode);

                // Fetch projects
                ProjectGrpcRequest projectGrpcRequest = new ProjectGrpcRequest();
                projectGrpcRequest.Position = 0;
                projectGrpcRequest.Takeamount = 1000;
                ListProjectGrpc listProjectLookup = _MasterClient.GetProjectGrpc(projectGrpcRequest);

                Dictionary<string, string> projectLookup = listProjectLookup.ProjectGrpc
                    .Where(p => p.Id != null && p.ProjectName != null)
                    .ToDictionary(p => p.Id, p => p.ProjectName);

                // Fetch vehicles
                VehicleGrpcRequest vehicleGrpcRequest = new VehicleGrpcRequest();
                vehicleGrpcRequest.Position = 0;
                vehicleGrpcRequest.Takeamount = 1000;
                ListVehicleGrpc listVehicleLookup = _MasterClient.GetVehicleGrpc(vehicleGrpcRequest);

                Dictionary<string, string> vehicleLookup = listVehicleLookup.VehicleGrpc
                    .Where(v => v.Id != null && v.VehicleName != null)
                    .ToDictionary(v => v.Id, v => v.VehicleName);

                // Prepare response
                GetAllRfqProjectGrpcResponse response = new GetAllRfqProjectGrpcResponse();

                foreach (RfqProjectGrpc project in rfqProjects.RfqProjects)
                {
                    RfqProject mappedProject = project.ToRfqProject();

                    // Attach reason title
                    if (reasonLookup.TryGetValue(mappedProject.RfqReasonId, out string? reasonTitle))
                    {
                        mappedProject.GetType().GetProperty("RfqReasonName")?.SetValue(mappedProject, reasonTitle ?? string.Empty);
                    }

                    // Attach customer business group code
                    if (customerLookup.TryGetValue(mappedProject.CustomerBusinessUnitGuid, out string? groupCode))
                    {
                        mappedProject.GetType().GetProperty("CustomerBusinessGroupCode")?.SetValue(mappedProject, groupCode ?? string.Empty);
                    }

                    // Attach customer location name
                    if (locationLookup.TryGetValue(mappedProject.CustomerLocationGuid, out string? locationName))
                    {
                        mappedProject.GetType().GetProperty("CustomerLocationName")?.SetValue(mappedProject, locationName ?? string.Empty);
                    }

                    // Attach project name
                    if (projectLookup.TryGetValue(mappedProject.ProjectGuid, out string? projectName))
                    {
                        mappedProject.GetType().GetProperty("ProjectName")?.SetValue(mappedProject, projectName ?? string.Empty);
                    }

                    // Attach car model name
                    if (vehicleLookup.TryGetValue(mappedProject.CarModelGuid, out string? carModelName))
                    {
                        mappedProject.GetType().GetProperty("CarModelName")?.SetValue(mappedProject, carModelName ?? string.Empty);
                    }

                    response.RfqProjects.Add(mappedProject);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching RFQ projects from Master service", ex);
                throw;
            }
        }
        public async Task<GetRfqProjectByIdGrpcResponse> GetRfqProjectByIdGrpc(GetRfqProjectByIdGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);
                RfqFilterRequest filterRequest = new RfqFilterRequest();
                filterRequest.DatabaseList = "RFQPROJECTGRPC";
                filterRequest.FilterExpression = $"RowId == {request.RowId}";
                RfqFilterResponse filterResponse = _RfqClient.FilterRfqGrpc(filterRequest);
                ListRfqProjectGrpc rfqProjects = filterResponse.ListRfqProjectGrpc ?? new ListRfqProjectGrpc();
                RfqFilterRequest reasonFilterRequest = new RfqFilterRequest();
                reasonFilterRequest.DatabaseList = "RFQREASONGRPC";
                reasonFilterRequest.FilterExpression = "ReasonTitle != null && ReasonTitle != \"\"";

                RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();

                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId != 0 && r.ReasonTitle != null)
                    .ToDictionary(r => r.RowId, r => r.ReasonTitle);

                // Fetch masterCustomers
                GetAllCustomersGrpcRequest customerRequest = new GetAllCustomersGrpcRequest();
                customerRequest.Position = 0;
                customerRequest.Take = 1000;

                GetAllCustomersGrpcResponse customerResponse = await GetAllCustomersGrpc(customerRequest);

                Dictionary<string, string> customerLookup = customerResponse.Customers
                    .Where(c => c.Id != null && c.CustomerBusinessGroupCode != null)
                    .ToDictionary(c => c.Id, c => c.CustomerBusinessGroupCode);

                // Fetch customer locations
                CustomerLocationGrpcRequest customerLocationRequest = new CustomerLocationGrpcRequest();
                customerLocationRequest.Position = 0;
                customerLocationRequest.Takeamount = 1000;
                ListCustomerLocationGrpc listCustomerLocationLookup = _MasterClient.GetCustomerLocationGrpc(customerLocationRequest);

                Dictionary<string, string> locationLookup = listCustomerLocationLookup.CustomerLocationGrpc
                    .Where(l => l.Id != null && l.CustomerCode != null)
                    .ToDictionary(l => l.Id, l => l.CustomerCode);

                // Fetch projects
                ProjectGrpcRequest projectGrpcRequest = new ProjectGrpcRequest();
                projectGrpcRequest.Position = 0;
                projectGrpcRequest.Takeamount = 1000;
                ListProjectGrpc listProjectLookup = _MasterClient.GetProjectGrpc(projectGrpcRequest);

                Dictionary<string, string> projectLookup = listProjectLookup.ProjectGrpc
                    .Where(p => p.Id != null && p.ProjectName != null)
                    .ToDictionary(p => p.Id, p => p.ProjectName);

                // Fetch vehicles
                VehicleGrpcRequest vehicleGrpcRequest = new VehicleGrpcRequest();
                vehicleGrpcRequest.Position = 0;
                vehicleGrpcRequest.Takeamount = 1000;
                ListVehicleGrpc listVehicleLookup = _MasterClient.GetVehicleGrpc(vehicleGrpcRequest);

                Dictionary<string, string> vehicleLookup = listVehicleLookup.VehicleGrpc
                    .Where(v => v.Id != null && v.VehicleName != null)
                    .ToDictionary(v => v.Id, v => v.VehicleName);

                GetRfqProjectByIdGrpcResponse response = new GetRfqProjectByIdGrpcResponse();

                //int projectCount = rfqProjects.ListRfqProjectGrpc.RfqProjects.Count;

                int projectCount = rfqProjects.RfqProjects.Count;
                bool hasProjects = 0 < projectCount;

                if (hasProjects)
                {
                    RfqProjectGrpc grpcProject = rfqProjects.RfqProjects.First();
                    RfqProject mappedProject = grpcProject.ToRfqProject();

                    // Attach reason title
                    if (reasonLookup.TryGetValue(mappedProject.RfqReasonId, out string? reasonTitle))
                    {
                        mappedProject.GetType().GetProperty("RfqReasonName")?.SetValue(mappedProject, reasonTitle ?? string.Empty);
                    }

                    // Attach customer business group code
                    if (customerLookup.TryGetValue(mappedProject.CustomerBusinessUnitGuid, out string? groupCode))
                    {
                        mappedProject.GetType().GetProperty("CustomerBusinessGroupCode")?.SetValue(mappedProject, groupCode ?? string.Empty);
                    }

                    // Attach customer location name
                    if (locationLookup.TryGetValue(mappedProject.CustomerLocationGuid, out string? locationName))
                    {
                        mappedProject.GetType().GetProperty("CustomerLocationName")?.SetValue(mappedProject, locationName ?? string.Empty);
                    }

                    // Attach project name
                    if (projectLookup.TryGetValue(mappedProject.ProjectGuid, out string? projectName))
                    {
                        mappedProject.GetType().GetProperty("ProjectName")?.SetValue(mappedProject, projectName ?? string.Empty);
                    }

                    // Attach car model name
                    if (vehicleLookup.TryGetValue(mappedProject.CarModelGuid, out string? carModelName))
                    {
                        mappedProject.GetType().GetProperty("CarModelName")?.SetValue(mappedProject, carModelName ?? string.Empty);
                    }

                    response.Project = mappedProject;
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error fetching RFQ project by RowId: {request.RowId}", ex);
                throw;
            }
        }

        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProject(CreateRfqProjectGrpcRequest request)
        {
            //GetProjectAssociationsByCustomerIdRequest req = new GetProjectAssociationsByCustomerIdRequest();
            //req.CustomerId = request.Project.CustomerBusinessUnitGuid;

            //await GetProjectAssociationsByCustomerId(req);

            ProjectGrpc project = _Projects.First(p => p.Id.ToUpperInvariant() == request.Project.ProjectGuid.ToUpperInvariant());
            string projectCode = project.CustomerProjectCode;
            List<VehicleGrpc> vehiclesResponse = await GetVehiclesByProjectCodeGrpc(projectCode);
            CreateRfqProjectGrpcResponse response = new CreateRfqProjectGrpcResponse();
            if (0 == vehiclesResponse.Count)
            {
                response.Success = false;
                response.Message = $"No vehicles found for the project code {projectCode} (id {request.Project.ProjectGuid.ToUpperInvariant()})";
                return response;
            }

            VehicleGrpc vehicle = vehiclesResponse.First();
            request.Project.CarModelGuid = vehicle.Id;

            RfqProjectGrpc rfqProject = new RfqProjectGrpc();
            RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();

            rfqProject.CustomerBusinessUnitGuid = request.Project.CustomerBusinessUnitGuid.ToUpperInvariant();
            rfqProject.CustomerLocationGuid = request.Project.CustomerLocationGuid.ToUpperInvariant();
            rfqProject.ProjectGuid = request.Project.ProjectGuid.ToUpperInvariant();
            rfqProject.RfqReasonId = request.Project.RfqReasonId;
            rfqProject.RfqResponseDeadline = request.Project.RfqResponseDeadline;
            rfqProject.CarModelGuid = request.Project.CarModelGuid.ToUpperInvariant();
            rfqProject.VehicleVolume = request.Project.VehicleVolume;
            rfqProject.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            rfqProject.IsActive = request.Project.IsActive ?? false;

            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqProjectRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            rfqProjectRequest.RfqGrpcRequestParameter.RequestType = 70;
            rfqProjectRequest.RfqProjectGrpcsToCreate.Add(rfqProject);
            RfqCrudGrpcResponse createResponse = _RfqClient.CreateRfqProjectGrpc(rfqProjectRequest);
            if (createResponse.SaveSuccess == false)
            {
                response.Success = false;
                response.Message = "Failed to create RFQ Project";
                return response;
            }

            response.Success = true; // haha
            response.Message = createResponse.Message;
            response.CreatedProjectId = createResponse.StringValue.Split(',').First();
            return response;
        }

        public async Task<UpdateRfqProjectGrpcResponse> UpdateRfqProject(UpdateRfqProjectGrpcRequest request)
        {
            if (request.Project == null
                || string.IsNullOrEmpty(request.Project.RfqNumber))
            {
                throw new ArgumentNullException(nameof(request), "Project or RFQ Number cannot be null");
            }

            try
            {
                await Task.Delay(1);

                RfqProjectGrpc rfqProject = new RfqProjectGrpc();
                rfqProject.RowId = request.Project.RowId;
                rfqProject.RfqNumber = request.Project.RfqNumber; // it is needed to identify the record to update
                rfqProject.CustomerBusinessUnitGuid = request.Project.CustomerBusinessUnitGuid.ToUpperInvariant();
                rfqProject.CustomerLocationGuid = request.Project.CustomerLocationGuid.ToUpperInvariant();
                rfqProject.ProjectGuid = request.Project.ProjectGuid.ToUpperInvariant();
                rfqProject.RfqReasonId = request.Project.RfqReasonId;
                rfqProject.RfqResponseDeadline = request.Project.RfqResponseDeadline;
                rfqProject.CarModelGuid = request.Project.CarModelGuid.ToUpperInvariant();
                rfqProject.VehicleVolume = request.Project.VehicleVolume;
                rfqProject.IsActive = request.Project.IsActive ?? false;

                RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();
                rfqProjectRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqProjectRequest.RfqGrpcRequestParameter.RequestType = 80;
                rfqProjectRequest.RfqProjectGrpcsToUpdate.Add(rfqProject);

                RfqCrudGrpcResponse updateResponse = _RfqClient.UpdateRfqProjectGrpc(rfqProjectRequest);

                UpdateRfqProjectGrpcResponse response = new UpdateRfqProjectGrpcResponse();
                response.Success = updateResponse.SaveSuccess;
                response.Message = updateResponse.Message;

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error Updating RFQ project", ex);
                throw;
            }
        }
        #endregion
        #region RfqDrawingPartNumbers
        public async Task<UpdateRfqDrawingPartNumbersGrpcResponse> UpdateRfqDrawingPartNumbers(UpdateRfqDrawingPartNumbersGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                // Map each incoming part into a gRPC DTO
                List<RfqDrawingPartNumbersGrpc> partsToUpdate = new List<RfqDrawingPartNumbersGrpc>();
                foreach (RfqDrawingPartNumber part in request.RfqDrawingPartNumbersGrpcsToUpdate)
                {
                    RfqDrawingPartNumbersGrpc grpcPart = new RfqDrawingPartNumbersGrpc();
                    grpcPart.RowId = part.RowId;
                    grpcPart.RfqId = part.RfqId;
                    grpcPart.SumitomoPartNumber = part.SumitomoPartNumber;
                    grpcPart.OriginalPartNumber = part.OriginalPartNumber;
                    grpcPart.OriginalPartNumberPrice = part.OriginalPartNumberPrice;
                    grpcPart.SwappedPartNumber = part.SwappedPartNumber;
                    grpcPart.SwappedPartNumberPrice = part.SwappedPartNumberPrice;
                    grpcPart.PriceSource = part.PriceSource;
                    grpcPart.IsExactMatch = part.IsExactMatch;
                    grpcPart.IsSwapped = part.IsSwapped;
                    grpcPart.Comments = part.Comments;
                    partsToUpdate.Add(grpcPart);
                }

                RfqDrawingPartNumbersGrpcRequest rfqProjectRequest = new RfqDrawingPartNumbersGrpcRequest();
                rfqProjectRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqProjectRequest.RfqGrpcRequestParameter.RequestType = 80;
                rfqProjectRequest.RfqDrawingPartNumbersGrpcsToUpdate.Add(partsToUpdate);
                RfqCrudGrpcResponse updateResponse = _RfqClient.UpdateRfqDrawingPartNumbersGrpc(rfqProjectRequest);
                UpdateRfqDrawingPartNumbersGrpcResponse response = new UpdateRfqDrawingPartNumbersGrpcResponse();
                response.Success = updateResponse.SaveSuccess;
                response.Message = updateResponse.Message;
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error Updating RFQ drawing part numbers", ex);
                throw;
            }
        }
        public async Task<GetRfqDrawingPartNumbersByRfqIdGrpcResponse> GetRfqDrawingPartNumbersByRfqIdGrpc(GetRfqDrawingPartNumbersByRfqIdGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                GetRfqDrawingPartNumbersByRfqIdGrpcResponse response = new GetRfqDrawingPartNumbersByRfqIdGrpcResponse();

                RfqFilterRequest rfqFilterRequest = new RfqFilterRequest();

                rfqFilterRequest.DatabaseList = "RFQDRAWINGPARTNUMBERSGRPC";
                rfqFilterRequest.FilterExpression = $"(RfqId != null && RfqId == {request.RfqId})";

                RfqFilterResponse rfqFilterResponse = _RfqClient.FilterRfqGrpc(rfqFilterRequest);

                if(rfqFilterResponse == null
                    || rfqFilterResponse.ListRfqDrawingPartNumbersGrpc == null
                    || rfqFilterResponse.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers == null)
                {
                    return response;
                }

                List<RfqDrawingPartNumbersGrpc> rfqPartNumbers = rfqFilterResponse.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.ToList();

                int partNumberCount = rfqPartNumbers.Count;
                bool hasParts = !(partNumberCount <= 0);
                if (hasParts)
                {
                    List<RfqDrawingPartNumber> mappedParts = new List<RfqDrawingPartNumber>();

                    foreach (RfqDrawingPartNumbersGrpc grpcPart in rfqPartNumbers)
                    {
                        RfqDrawingPartNumber mappedPart = grpcPart.ToRfqDrawingPartNumber();
                        mappedParts.Add(mappedPart);
                    }

                    response.Parts.AddRange(mappedParts);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error fetching RFQ drawing parts by RfqId: {request.RfqId}", ex);
                throw;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        RfqCrudGrpcResponse CreateRfqDrawingPartNumbers(string projectId, List<CustomerParts> customerParts)
        {
            RfqDrawingPartNumbersGrpcRequest partRequest = new RfqDrawingPartNumbersGrpcRequest();
            RfqCrudGrpcResponse partResponse = new();
            partResponse.SaveSuccess = false;

            try
            {
                _Logger.GenericLogInformation($"III RfqManaerService.CreateRfqDrawingPartNumbers - start GRPC to the access layer - sending {customerParts.Count} parts");

                partRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                partRequest.RfqGrpcRequestParameter.RequestType = 70;
                foreach (CustomerParts customerPart in customerParts)
                {
                    RfqDrawingPartNumbersGrpc part = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber1);
                    partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part);
                    if (customerPart.PartNumber2 != null)
                    {
                        RfqDrawingPartNumbersGrpc part2 = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber2);
                        partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part2);
                    }

                    if (customerPart.PartNumber3 != null)
                    {
                        RfqDrawingPartNumbersGrpc part3 = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber3);
                        partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part3);
                    }
                }

                partResponse = _RfqClient.CreateRfqDrawingPartNumbersGrpc(partRequest);

                string msg = partResponse.SaveSuccess == true ? "successfully" : "failed somehow";
                _Logger.GenericLogInformation($"III RfqManaerService.CreateRfqDrawingPartNumbers - access layer returned over GRPC - {msg}");
                return partResponse;

            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"EEE RfqManaerService.CreateRfqDrawingPartNumbers - access layer returned over GRPC - {ex.Message}", ex);
            }

            return partResponse;

        }

        RfqDrawingPartNumbersGrpc ToRfqDrawingPartNumbers(string projectId, string partNumber)
        {
            RfqDrawingPartNumbersGrpc part = new RfqDrawingPartNumbersGrpc();
            part.RfqId = (long)Convert.ToDouble(projectId, CultureInfo.InvariantCulture);
            part.OriginalPartNumber = partNumber;
            part.OriginalPartNumberPrice = 0;
            part.SwappedPartNumber = "";
            part.SwappedPartNumberPrice = 0;
            part.PriceSource = "";
            // part.IsExactMatch = true;
            part.IsExactMatch = false; // assume no exact match on upload
            part.IsSwapped = false;
            part.Comments = "";
            return part;
        }
        #endregion
        public async Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request)
        {
            UploadPartsRequestGrpcResponse uploadResponse = new UploadPartsRequestGrpcResponse();
            List<CustomerParts> customerParts = await ConvertDocumentAsync(request);

            RfqCrudGrpcResponse partResponse = CreateRfqDrawingPartNumbers(request.ProjectId, customerParts);

            if (partResponse.SaveSuccess == false)
            {
                uploadResponse.Success = false;
                uploadResponse.Message = "Failed to create RFQ Parts";
                _Logger.GenericLogInformation($"FFF RfqManagerService.UploadPartsGrpc Failed uploading - {customerParts.Count} parts incoming");

                return uploadResponse;
            }

            uploadResponse.Success = true;
            uploadResponse.Message = $"{request.FileName} processed and RFQ Parts created successfully";
            _Logger.GenericLogInformation($"III RfqManagerService.UploadPartsGrpc Successfully uploaded - {customerParts.Count} parts incoming");

            return uploadResponse;

        }

        async Task<List<CustomerParts>> ConvertDocumentAsync(UploadPartsRequestGrpcRequest request)
        {
            List<CrossReferenceDto> crossReferenceDtos = new List<CrossReferenceDto>();
            List<FordCsvDto> fordCsvDtos = new List<FordCsvDto>();
            DsiAggregate dsiAggregate = new DsiAggregate();
            List<CustomerParts> customerParts = new List<CustomerParts>();
            try
            {
                // Check if file data exists
                if (request.FileData == null || request.FileData.Length == 0)
                {
                    return customerParts;
                }

                crossReferenceDtos.Clear();
                fordCsvDtos.Clear();
                // Process the file based on its extension
                string fileName = request.FileName;
                string fileExtension = Path.GetExtension(fileName).ToUpperInvariant();
                byte[] fileData = request.FileData.ToByteArray();
                switch (fileExtension)
                {
                    case ".CSV":
                    // Handle CSV file processing
                    _Logger.GenericLogInformation("Processing CSV file: " + fileName);
                    object csvData = DocumentTransformer.ConvertCSV(fileData, fileName);
                    fordCsvDtos = (List<FordCsvDto>)csvData;
                    break;
                    case ".XML":
                    // Handle XML file processing
                    _Logger.GenericLogInformation("Processing XML file: " + fileName);
                    crossReferenceDtos = DocumentTransformer.ConvertFordXMLFile(fileData).ToList();
                    break;
                    case ".XLSX":
                    // Handle Excel file processing
                    _Logger.GenericLogInformation("Processing Excel file: " + fileName);
                    crossReferenceDtos = DocumentTransformer.ConvertExcelFile(fileData).ToList();
                    break;
                    case ".MTF":
                    // Handle MTF file processing
                    _Logger.GenericLogInformation("Processing MTF file: " + fileName);
                    crossReferenceDtos = DocumentTransformer.ConvertToyotaXMLFile(fileData).ToList();
                    break;
                    case ".TXT":
                    // Handle TXT file processing
                    _Logger.GenericLogInformation("Processing TXT file: " + fileName);
                    crossReferenceDtos = DocumentTransformer.ConvertRenaultCSVFile(fileData).ToList();
                    break;
                    case ".DSI":
                    // Handle DSI file processing
                    _Logger.GenericLogInformation("Processing DSI file: " + fileName);
                    dsiAggregate = DocumentTransformer.ConvertDsiFile(fileData);
                    break;
                    default:
                    _Logger.GenericLogInformation("Unsupported file type:" + fileExtension);
                    return customerParts;
                }
            }
            catch (FileFormatException ex)
            {
                _Logger.GenericLogError("Error processing file upload for " + request.FileName, ex);
                return customerParts;
            }
            // Go to the access service to save the data to the database
            await Task.Delay(1);

            _Logger.GenericLogInformation("File " + request.FileName + " processed successfully");
            List<string> crossReferences = crossReferenceDtos
                .Where(cr => !string.IsNullOrWhiteSpace(cr.CustomerNumber))
                .Select(cr => cr.CustomerNumber!)
                .Distinct()
                .ToList();
            List<CustomerParts> crossReferenceParts = GetCustomerParts(crossReferences, customerParts);
            customerParts.AddRange(crossReferenceParts);

            List<string> fordDtos = fordCsvDtos.Select(cr => cr.CustomerNumber).Distinct().ToList();
            List<CustomerParts> fordParts = GetCustomerParts(fordDtos, customerParts);
            customerParts.AddRange(fordParts);

            if (dsiAggregate.ComponentList != null)
            {
                List<ComponentDto> components = new List<ComponentDto>();
                components = dsiAggregate.ComponentList
                    .Where(cr => !string.IsNullOrWhiteSpace(cr.PartNumber1)
                    && !string.IsNullOrWhiteSpace(cr.PartNumber2)
                    && !string.IsNullOrWhiteSpace(cr.PartNumber3))
                    .ToList();
                foreach (ComponentDto component in components)
                {

                    CustomerParts part = new CustomerParts();
                    part.PartNumber1 = component.PartNumber1;
                    part.PartNumber2 = component.PartNumber2;
                    part.PartNumber3 = component.PartNumber3;
                    if (!customerParts.Contains(part))
                    {
                        customerParts.Add(part);
                    }
                }
            }

            return customerParts;
        }

        List<CustomerParts> GetCustomerParts(List<string> newParts, List<CustomerParts> customerParts)
        {
            List<CustomerParts> newCustomerParts = new List<CustomerParts>();
            if (0 < newParts.Count)
            {
                foreach (string newPart in newParts)
                {
                    if (!string.IsNullOrWhiteSpace(newPart))
                    {
                        CustomerParts part = new CustomerParts();
                        part.PartNumber1 = newPart;
                        if (!customerParts.Contains(part))
                        {
                            newCustomerParts.Add(part);
                        }
                    }
                }
            }

            return newCustomerParts;
        }

        public async Task<GetCustomerLocationsByUserIdResponse> GetCustomerLocationsByUserId(string userId)
        {
            await Task.Delay(0);
            MastersFilterRequestGrpc mastersFilterRequestGrpc = new MastersFilterRequestGrpc();
            mastersFilterRequestGrpc.DatabaseList = "CUSTOMERBUSINESSUSERASSOCIATIONGRPC";
            mastersFilterRequestGrpc.FilterExpression = $"UserGuid != null && UserGuid.ToUpperInvariant() == \"{userId.ToUpperInvariant()}\"";

            MastersFilterResponseGrpc associationFilter = _MasterClient.FilterMasterDataGrpc(mastersFilterRequestGrpc);
            List<Master.CustomerBusinessUserAssociationGrpc> userList = ExtractMastersResponseData<Master.CustomerBusinessUserAssociationGrpc>(associationFilter).ToList();
            Master.CustomerBusinessUserAssociationGrpc? user = userList.FirstOrDefault();
            List<Master.CustomerLocationGrpc> filteredLocations = new List<Master.CustomerLocationGrpc>();
            GetCustomerLocationsByUserIdResponse response = new GetCustomerLocationsByUserIdResponse();
            if (user == null)
            {
                return response;
            }

            if (user.CustomerBusinessHierarchyList == null)
            {
                return response;
            }

            List<CustomerLocationGrpc>? userLocations = JsonConvert.DeserializeObject<List<CustomerLocationGrpc>>(user.CustomerBusinessHierarchyList);
            if (userLocations == null)
            {
                return response;
            }

            foreach (CustomerLocationGrpc userLocation in userLocations)
            {
                if (userLocation.IsActive == true)
                {
                    mastersFilterRequestGrpc.DatabaseList = "CUSTOMERLOCATIONGRPC";
                    mastersFilterRequestGrpc.FilterExpression = $"CustomerBusinessHierarchyGuid != null && CustomerBusinessHierarchyGuid.ToUpperInvariant() == \"{userLocation.CustomerBusinessHierarchyGuid.ToUpperInvariant()}\"";
                    MastersFilterResponseGrpc locationsFilter = _MasterClient.FilterMasterDataGrpc(mastersFilterRequestGrpc);
                    List<Master.CustomerLocationGrpc> customerLocations = ExtractMastersResponseData<Master.CustomerLocationGrpc>(locationsFilter).ToList();
                    foreach (Master.CustomerLocationGrpc location in customerLocations)
                    {
                        CustomerLocationGrpc customerLocationGrpc = location.ToCustomerLocation();
                        response.CustomerLocations.Add(customerLocationGrpc);
                    }
                }
            }

            return response;
        }

        public async Task<GetCustomerBusinessUnitsByUserIdResponse> GetCustomerBusinessUnitsByUserId(string userId)
        {
            await Task.Delay(1);
            GetCustomerBusinessUnitsByUserIdResponse response = new GetCustomerBusinessUnitsByUserIdResponse();

            MastersFilterRequestGrpc mastersFilterRequestGrpc = new MastersFilterRequestGrpc();
            //
            mastersFilterRequestGrpc.DatabaseList = "CUSTOMERGRPC";
            mastersFilterRequestGrpc.FilterExpression = $"Id != null";
            MastersFilterResponseGrpc allCustomersResponse = _MasterClient.FilterMasterDataGrpc(mastersFilterRequestGrpc);
            List<Master.CustomerGrpc> allCustomers = ExtractMastersResponseData<Master.CustomerGrpc>(allCustomersResponse).ToList();

            // Get all customer business user associations for the specified user
            mastersFilterRequestGrpc.DatabaseList = "CUSTOMERBUSINESSUSERASSOCIATIONGRPC";
            mastersFilterRequestGrpc.FilterExpression = $"UserGuid != null && UserGuid.ToUpperInvariant() == \"{userId.ToUpperInvariant()}\"";
            MastersFilterResponseGrpc assiciationFilter = _MasterClient.FilterMasterDataGrpc(mastersFilterRequestGrpc);
            List<Master.CustomerBusinessUserAssociationGrpc> businessUserAssociation = ExtractMastersResponseData<Master.CustomerBusinessUserAssociationGrpc>(assiciationFilter).ToList();
            Master.CustomerBusinessUserAssociationGrpc? userAssociation = businessUserAssociation.FirstOrDefault();
            if (userAssociation == null || userAssociation.CustomerBusinessHierarchyList == null)
            {
                return response;
            }

            List<CustomerBuisnessHirarchyListDto>? associatedCustomers = JsonConvert.DeserializeObject<List<CustomerBuisnessHirarchyListDto>>(userAssociation.CustomerBusinessHierarchyList);

            if (associatedCustomers == null)
            {
                return response;
            }

            foreach (CustomerBuisnessHirarchyListDto customer in associatedCustomers)
            {
                if (customer.IsActive == true)
                {
                    List<Master.CustomerGrpc> userCustomers = allCustomers.Where(c => c.Id != null && c.Id.ToUpperInvariant() == customer.CustomerBusinessHierarchyGuid.ToString().ToUpperInvariant()).ToList();

                    foreach (Master.CustomerGrpc masterCustomer in userCustomers)
                    {
                        CustomerGrpc customerGrpc = masterCustomer.ToCustomerGrpc();
                        response.Customers.Add(customerGrpc);
                    }
                }
            }

            return response;
        }

        public async Task<GetAlternativePartInfoBySumitomoNumberResponse> GetAlternativePartInfoBySumitomoNumberResponse(string sumitomoNumber)
        {
            await Task.Delay(1);
            GetAlternativePartInfoBySumitomoNumberResponse response = new GetAlternativePartInfoBySumitomoNumberResponse();
            Collection<AlternativePartsGrpc> alternativePartsFilteredList = new Collection<AlternativePartsGrpc>();
            Collection<PartImageDataInfo> partImageFilteredList = new Collection<PartImageDataInfo>();

            EmacsFilterRequestGrpc emacsFilterRequestGrpc = new EmacsFilterRequestGrpc();
            emacsFilterRequestGrpc.DatabaseList = "AlternativePartsGrpc";
            emacsFilterRequestGrpc.FilterExpression = $"SumitomoNumber != null && SumitomoNumber == \"{sumitomoNumber}\"";
            EmacsFilterResponseGrpc alternativeParts = _EmacsClient.FilterEmacsDataGrpc(emacsFilterRequestGrpc);
            if (alternativeParts.ListAlternativePartsGrpc != null)
            {
                alternativePartsFilteredList = ExtractEmacsResponseData<AlternativePartsGrpc>(alternativeParts);
                RfqAlternativePartsGrpc part = alternativePartsFilteredList.First().ToRfqAlternativeParts();
                response.AlternativePartsGrpc = part;
            }

            FilterGrpcRequest adssFilterRequest = new FilterGrpcRequest();
            adssFilterRequest.StringValue = sumitomoNumber;
            FilterGrpcResponse adssFilterResponse = await FilterAdssBySumitomoPartNumber(adssFilterRequest);
            RfqPartImageDataInfo rfqPartImageDataInfo = new RfqPartImageDataInfo();
            PartImageReply partImageReply = new PartImageReply();
            partImageReply.Data = adssFilterResponse.ByteList.First();
            partImageReply.ContentType = adssFilterResponse.StringList2.First();

            rfqPartImageDataInfo.PartImage.Add(partImageReply);
            response.PartImageDataInfo = rfqPartImageDataInfo;

            return response;

        }
        public async Task<GetAllAlternativePartsGrpcResponse> GetAllAlternativePartsGrpc(GetAllAlternativePartsGrpcRequest request, CancellationToken cancellation)
        {
            try
            {
                TimeSpan ts = TimeSpan.FromSeconds(120);
                using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellation))
                {
                    // Use cts.Token here
                    //cts.CancelAfter(ts);

                    GetAlternativePartsGrpcRequest requestAll = new GetAlternativePartsGrpcRequest();
                    requestAll.Position = request.Position;
                    requestAll.TakeAmount = request.Take;

                    // the next line fails:
                    DateTime deadline = DateTime.UtcNow.AddSeconds(60);
                    CallOptions callOptions = new CallOptions(deadline: deadline);
                    ListAlternativePartsGrpc listResponse = await _EmacsClient.GetAlternativePartsGrpcAsync(requestAll, callOptions);
                    //2026 - 01 - 26T10: 32:06 info: Grpc.Net.Client.Internal.GrpcCall[17]
                    //2026 - 01 - 26T10: 32:06 Error reading message.
                    //2026 - 01 - 26T10: 32:06 System.Net.Http.HttpIOException: The response ended prematurely, with at least 4105 additional bytes expected. (ResponseEnded)

                    ListAlternativePartsGrpc partsList = listResponse ?? new ListAlternativePartsGrpc();

                    GetAllAlternativePartsGrpcResponse response = new GetAllAlternativePartsGrpcResponse();
                    foreach (AlternativePartsGrpc part in partsList.AlternativePartsGrpc)
                    {
                        RfqAlternativePartsGrpc alternativePart = part.ToRfqAlternativeParts();
                        response.AlternativeParts.Add(alternativePart);
                    }

                    _Logger.GenericLogInformation($"RfqManagerService.GetAllAlternativePartsGrpc sending {response.AlternativeParts.Count} RfqAlternativePartsGrpc to client with size {response.CalculateSize()}");

                    return response;
                }
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching alternative parts from EMACS service", ex);
                throw;
            }
        }

        public async Task<SearchPartPricesGrpcResponse> SearchPartPricesGrpc(SearchPartPricesGrpcRequest request)
        {
            await Task.Delay(1);
            SearchPartPricesGrpcResponse response = new SearchPartPricesGrpcResponse();

            if (request.PartNumbers == null || request.PartNumbers.Count == 0)
            {
                return response;
            }

            // Step 1: Resolve all part numbers to Sumitomo numbers in parallel
            IEnumerable<Task<PriceResponse?>> emacsLookupTasks = request.PartNumbers
                .Where(pn => !string.IsNullOrWhiteSpace(pn))
                .Select(async partNumber =>
                {
                    FilterGrpcRequest filterRequest = new FilterGrpcRequest();
                    filterRequest.StringValue = partNumber;

                    FilterGrpcResponse exactResponse = await FilterEmacsByExactPartNumber(filterRequest);
                    if (0 < exactResponse.StringList.Count)
                    {
                        PriceResponse priceResponse = new PriceResponse();
                        priceResponse.CustomerPartNumber = partNumber;
                        priceResponse.ExactMatch = true;

                        PriceInformation priceInformation = new PriceInformation();
                        priceInformation.SumitomoNumber = exactResponse.StringList.First();
                        priceResponse.PriceInformation.Add(priceInformation);
                        return priceResponse;
                    }

                    string cleanedUpPn = partNumber
                        .Replace("-", "", StringComparison.InvariantCulture)
                        .Replace(" ", "", StringComparison.InvariantCulture)
                        .ToUpperInvariant();

                    filterRequest.StringValue = cleanedUpPn;
                    FilterGrpcResponse containsResponse = await FilterEmacsByContainingPartNumber(filterRequest);
                    if (0 < containsResponse.StringList.Count)
                    {
                        PriceResponse priceResponse = new PriceResponse();
                        priceResponse.CustomerPartNumber = partNumber;
                        priceResponse.ExactMatch = true;

                        foreach (string sumitomoNumber in containsResponse.StringList)
                        {
                            PriceInformation priceInformation = new PriceInformation();
                            priceInformation.SumitomoNumber = sumitomoNumber;
                            priceResponse.PriceInformation.Add(priceInformation);
                        }

                        return priceResponse;
                    }

                    return null;
                });

            PriceResponse?[] emacsResults = await Task.WhenAll(emacsLookupTasks);
            List<PriceResponse> sumitomoNumberSearchResults = emacsResults
                .Where(r => r != null)
                .Select(r => r!)
                .ToList();

            // Step 2: Resolve prices for all PriceInformation entries in parallel
            // if price > 0 then add to response with price source, if not then skip (don't return zero price)
            IEnumerable<Task> priceLookupTasks = sumitomoNumberSearchResults
                .Select(async item =>
                {
                    IEnumerable<Task> innerTasks = item.PriceInformation
                        .Select(async priceInfo =>
                        {
                            FilterGrpcRequest filterRequest = new FilterGrpcRequest();
                            filterRequest.StringValue = priceInfo.SumitomoNumber;

                            FilterGrpcResponse cpdResponse = await FilterCPDBySumitomoPartNumber(filterRequest);
                            if (0 < cpdResponse.StringList.Count)
                            {
                                priceInfo.Price = cpdResponse.DoubleList.First();
                                priceInfo.PriceSource = "CPD";
                                return;
                            }

                            FilterGrpcResponse nprResponse = await FilterNPRBySumitomoPartNumber(filterRequest);
                            if (0 < nprResponse.StringList.Count)
                            {
                                priceInfo.Price = nprResponse.DoubleList.First();
                                priceInfo.PriceSource = "NPR";
                            }
                        });

                    await Task.WhenAll(innerTasks);
                });

            await Task.WhenAll(priceLookupTasks);

            response.PriceResponse.AddRange(sumitomoNumberSearchResults);
            return response;
        }

        #region RfqNprRequest
        public async Task<GetRfqNprRequestByRfqNumberGrpcResponse> GetRfqNprRequestByRfqNumberGrpc(GetRfqNprRequestByRfqNumberGrpcRequest request)
        {
            await Task.Delay(1);
            GetRfqNprRequestByRfqNumberGrpcResponse response = new GetRfqNprRequestByRfqNumberGrpcResponse();
            Collection<Rfq.RfqNprRequestGrpc> filteredList = new Collection<Rfq.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"RfqNumber != null && RfqNumber == \"{request.RfqNumber}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<Rfq.RfqNprRequestGrpc>(rfqNprRequests);
                foreach(Rfq.RfqNprRequestGrpc accessItem in filteredList)
                {
                    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                    response.RfqNprRequestGrpcs.Add(item);
                }
            }

            return response;
        }
        public async Task<GetRfqNprRequestByRfqProjectIdGrpcResponse> GetRfqNprRequestByRfqProjectIdGrpc(GetRfqNprRequestByRfqProjectIdGrpcRequest request)
        {
            await Task.Delay(1);
            GetRfqNprRequestByRfqProjectIdGrpcResponse response = new GetRfqNprRequestByRfqProjectIdGrpcResponse();
            Collection<Rfq.RfqNprRequestGrpc> filteredList = new Collection<Rfq.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"Project != null && Project == \"{request.RfqProjectId}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<Rfq.RfqNprRequestGrpc>(rfqNprRequests);
                foreach (Rfq.RfqNprRequestGrpc accessItem in filteredList)
                {
                    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                    response.RfqNprRequestGrpcs.Add(item);
                }
            }

            return response;
        }
        public async Task<GetRfqNprRequestByIdGrpcResponse> GetRfqNprRequestByIdGrpc(GetRfqNprRequestByIdGrpcRequest request)
        {
            await Task.Delay(1);
            GetRfqNprRequestByIdGrpcResponse response = new GetRfqNprRequestByIdGrpcResponse();
            Collection<Rfq.RfqNprRequestGrpc> filteredList = new Collection<Rfq.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"Id != null && Id.ToUpperInvariant() == \"{request.Id.ToUpperInvariant()}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<Rfq.RfqNprRequestGrpc>(rfqNprRequests);
                foreach (Rfq.RfqNprRequestGrpc accessItem in filteredList)
                {
                    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                    response.RfqNprRequestGrpcs.Add(item);
                }
            }

            return response;
        }

        public async Task<GetAllRfqNprRequestGrpcResponse> GetAllRfqNprRequestGrpc(GetAllRfqNprRequestGrpcRequest request)
        {
            await Task.Delay(1);
            GetAllRfqNprRequestGrpcResponse response = new GetAllRfqNprRequestGrpcResponse();
            Collection<RfqNprRequestGrpc> filteredList = new Collection<RfqNprRequestGrpc>();

            RfqNprRequestGrpcRequest rfqRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.Position = request.Position;
            rfqGrpcRequestParameter.Take = request.Take;
            rfqGrpcRequestParameter.RequestType = 1;
            rfqRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            ListRfqNprRequestGrpc rfqNprRequests = _RfqClient.ReadRfqNprRequestGrpc(rfqRequest);
            foreach(Rfq.RfqNprRequestGrpc? item in rfqNprRequests.RfqNprRequestGrpcs)
            {
                RfqNprRequestGrpc rfqNpr = item.ToRfqNprRequest();
                response.RfqNprRequestGrpcs.Add(rfqNpr);
            }

            return response;
        }

        public async Task<CreateRfqNprRequestGrpcResponse> CreateRfqNprRequestGrpc(CreateRfqNprRequestGrpcRequest request)
        {
            await Task.Delay(0);
            CreateRfqNprRequestGrpcResponse response = new CreateRfqNprRequestGrpcResponse();
            RfqNprRequestGrpcRequest rfqNprRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.RequestType = 70;
            foreach (RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            {
                Rfq.RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
                rfqNprRequest.RfqNprRequestGrpcsToCreate.Add(accessRfqNprRequest);
            }

            rfqNprRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            RfqCrudGrpcResponse accessResponse = _RfqClient.CreateRfqNprRequestGrpc(rfqNprRequest);
            for (int i = 0; i < request.RfqNprRequestGrpc.Count; i++)
            {
                string[] rfqNprRequestIds = accessResponse.StringValue.Split(",", i);
                response.CreatedRfqNprRequestId.Add(rfqNprRequestIds);
            }

            response.Message = accessResponse.Message;
            response.Success = accessResponse.SaveSuccess;
            return response;
        }

        //public async Task<UpdateRfqNprRequestGrpcResponse> UpdateRfqNprRequestGrpc(UpdateRfqNprRequestGrpcRequest request)
        //{
        //    await Task.Delay(0);
        //    UpdateRfqNprRequestGrpcResponse response = new UpdateRfqNprRequestGrpcResponse();
        //    RfqNprRequestGrpcRequest rfqNprRequest = new RfqNprRequestGrpcRequest();
        //    RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
        //    rfqGrpcRequestParameter.RequestType = 80;
        //    foreach (RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
        //    {
        //        Rfq.RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRquestGrpcAccess();
        //        rfqNprRequest.RfqNprRequestGrpcsToUpdate.Add(accessRfqNprRequest);
        //    }

        //    RfqCrudGrpcResponse accessResponse = _RfqClient.UpdateRfqNprRequestGrpc(rfqNprRequest);

        //    response.Message = accessResponse.Message;

        //    return response;
        //}

        public async Task<UpdateRfqNprRequestGrpcResponse> UpdateRfqNprRequestGrpc(UpdateRfqNprRequestGrpcRequest request)
        {
            await Task.Delay(0);
            UpdateRfqNprRequestGrpcResponse response = new UpdateRfqNprRequestGrpcResponse();
            RfqNprRequestGrpcRequest rfqNprRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.RequestType = 80;
            rfqNprRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            foreach (RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            {
                Rfq.RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
                rfqNprRequest.RfqNprRequestGrpcsToUpdate.Add(accessRfqNprRequest);
            }

            RfqCrudGrpcResponse accessResponse = _RfqClient.UpdateRfqNprRequestGrpc(rfqNprRequest);
            response.Success = accessResponse.SaveSuccess;
            response.Message = accessResponse.Message;
            return response;
        }

        public async Task<UpdateRfqNprRequestStatusGrpcResponse> UpdateRfqNprRequestStatusGrpc(UpdateRfqNprRequestStatusGrpcRequest request)
        {
            await Task.Delay(0);
            UpdateRfqNprRequestStatusGrpcResponse response = new UpdateRfqNprRequestStatusGrpcResponse();
            GetAllRfqNprRequestGrpcRequest rfqNprRequest = new GetAllRfqNprRequestGrpcRequest();
            GetAllRfqNprRequestGrpcResponse allRfqNprRequests = await GetAllRfqNprRequestGrpc(rfqNprRequest);
            NPRFilterRequest nprFilterRequest = new NPRFilterRequest();
            nprFilterRequest.DatabaseList = "H1NPRVIEWGRPC";
            foreach (RfqNprRequestGrpc? npr in allRfqNprRequests.RfqNprRequestGrpcs)
            {
                if (npr == null)
                {
                    continue;
                }

                nprFilterRequest.FilterExpression = $"RefNo != null && RefNo.ToUpperInvariant().TrimEnd() == \"{npr.RequestID.ToUpperInvariant().TrimEnd()}\"";
                NPRFilterResponse s = await _NPRGrpcClient.FilterNPRGrpcAsync(nprFilterRequest);

                H1NPRViewGrpc firstNpr = s.ListH1NPRViewGrpc.H1NPRViewGrpc.First();
                if (firstNpr.Status != npr.Status?.ToString(CultureInfo.InvariantCulture))
                {
                    RfqNprRequestGrpcRequest rfqNprRequestToUpdate = new RfqNprRequestGrpcRequest();
                    RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                    rfqGrpcRequestParameter.RequestType = 80;
                    rfqNprRequestToUpdate.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
                    Rfq.RfqNprRequestGrpc accessRfqNprRequest = npr.ToRfqNprRequestGrpcAccess();

                    if (int.TryParse(firstNpr.Status, out int parsedStatus))
                    {
                        accessRfqNprRequest.Status = parsedStatus;
                    }

                    rfqNprRequestToUpdate.RfqNprRequestGrpcsToUpdate.Add(accessRfqNprRequest);
                    _RfqClient.UpdateRfqNprRequestGrpc(rfqNprRequestToUpdate);
                }
            }

            return response;
        }

        public async Task<DeleteRfqNprRequestByIdGrpcResponse> DeleteRfqNprRequestByIdGrpc(DeleteRfqNprRequestByIdGrpcRequest request)
        {
            await Task.Delay(0);
            DeleteRfqNprRequestByIdGrpcResponse response = new DeleteRfqNprRequestByIdGrpcResponse();
            RfqNprRequestGrpcRequest rfqNprRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.RequestType = 90;
            rfqNprRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            foreach(RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            {
                Rfq.RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
                rfqNprRequest.RfqNprRequestGrpcsToDelete.Add(accessRfqNprRequest);
            }

            RfqCrudGrpcResponse accessResponse = _RfqClient.DeleteRfqNprRequestByIdGrpc(rfqNprRequest);
            response.Success = accessResponse.SaveSuccess;
            response.Message = accessResponse.Message;
            return response;
        }
        public async Task<MgrValidateNprRequestResponse> ValidateNprRequestGrpc(MgrValidateNprRequestRequest request)
        {
            await Task.Delay(1);

           ValidateNprRequestRequest accessRequest = new ValidateNprRequestRequest();
            if (request?.Items != null && 0 < request.Items.Count )
            {
                foreach (RfqNprRequestGrpc? mgrItem in request.Items)
                {
                                    Rfq.RfqNprRequestGrpc accessItem = mgrItem.ToRfqNprRequestGrpcAccess();
                    accessRequest.Items.Add(accessItem);
                }
            }
                      
            ValidateNprRequestResponse? accessResponse = await _RfqClient.ValidateNprRequestGrpcAsync(accessRequest);
                 
            MgrValidateNprRequestResponse response = new MgrValidateNprRequestResponse();
            response.AllValid = accessResponse?.AllValid ?? false;
            response.ItemCount = accessResponse?.ItemCount ?? 0;
            response.TotalQuantity = accessResponse?.TotalQuantity ?? 0;
          
          
            if (accessResponse?.ByCustomerCounts != null)
            {
                foreach (KeyValuePair<string, int> kv in accessResponse.ByCustomerCounts)
                {
                    response.ByCustomerCounts[kv.Key] = kv.Value;
                }
            }

            // Map LineStatuses & Errors
            if (accessResponse?.LineStatuses != null && 0 < accessResponse.LineStatuses.Count )
            {
                foreach (SubmitNprLineStatus? accessLine in accessResponse.LineStatuses)
                {
                    MgrSubmitNprLineStatus mgrLine = new MgrSubmitNprLineStatus();
                    mgrLine.Id = accessLine?.Id ?? string.Empty;
                    mgrLine.IsValid = accessLine?.IsValid ?? false;

                    if (accessLine?.Errors != null && 0 < accessLine.Errors.Count)
                    {
                        foreach (Rfq.ValidationError? err in accessLine.Errors)
                        {
                            MgrValidationError mgrValidationError = new MgrValidationError();
                            mgrValidationError.Field = err?.Field ?? string.Empty;
                            mgrValidationError.Message = err?.Message ?? string.Empty;
                         }
                    }

                    response.LineStatuses.Add(mgrLine);
                }
            }

            return response;
        }
        //string GetCurrentUser()
        //{

        //    ClaimsPrincipal? user = _HttpContextAccessor.HttpContext?.User;

        //    if (user == null || !user.Identity?.IsAuthenticated == true)
        //    {
        //        return "UNKNOWN";
        //    }

        //    return user.FindFirst(ClaimTypes.Name)?.Value
        //        ?? user.FindFirst("preferred_username")?.Value
        //        ?? user.FindFirst("email")?.Value
        //        ?? "UNKNOWN";

        //}
        public async Task<CreateNprGrpcResponse> CreateNprGrpc (CreateNprGrpcRequest request)
        {
            await Task.Delay(0);
            CreateNprGrpcResponse response = new CreateNprGrpcResponse();
            // ValidateNprRequestRequest validateRequest = new ValidateNprRequestRequest();
            List<NPR.NprApiDataGrpc> accessDataList = new List<NPR.NprApiDataGrpc>();
            List<Rfq.RfqNprRequestGrpc> rfqNprRequestList = new List<Rfq.RfqNprRequestGrpc>();

            //Validate the incoming request first
            for(int i = 0; i < request.NprApiData.Count; i++)
            {
                Rfq.RfqNprRequestGrpc rfqNprRequest = request.NprApiData[i].RfqNprRequest.ToRfqNprRequestGrpcAccess(i);
                rfqNprRequestList.Add(rfqNprRequest);
                // validateRequest.Items.Add(rfqNprRequest);
            }

            // ValidateNprRequestResponse validateResponse = await _RfqClient.ValidateNprRequestGrpcAsync(validateRequest);
            // List<Rfq.RfqNprRequestGrpc> validRequests = validateRequest.Items.Where(item => item.Id != null && validateResponse.LineStatuses.Any(line => line.Id == item.Id && line.IsValid)).ToList();  
            // send all requests to create RfqNprRequests replacing with the ones from NPR API for the valid requests to capture any additional data from NPR API and to update the status of the RfqNprRequest
            NprApiDataGrpc nprApiDataGrpc = new NprApiDataGrpc();
        
            foreach (Rfq.RfqNprRequestGrpc validRequest in rfqNprRequestList) //validRequests)
            {
                nprApiDataGrpc.RfqNprRequest = validRequest.ToRfqNprRequest();
                NPR.NprApiDataGrpc nprAccessData = nprApiDataGrpc.ToNprApiAccessData();
                accessDataList.Add(nprAccessData);
            }

            CreateNprApiGrpcRequest createNprApiGrpcRequest = new CreateNprApiGrpcRequest();
            createNprApiGrpcRequest.NprApiData.AddRange(accessDataList);
            CreateNprApiGrpcResponse apiResponse = await _NPRGrpcClient.CreateNprApiGrpcAsync(createNprApiGrpcRequest);
            response.HttpStatusCode = apiResponse.HttpStatusCode;
            response.Message = apiResponse.Message;

            UpdateRfqNprRequestGrpcRequest updateRequest = new UpdateRfqNprRequestGrpcRequest();
            foreach (NPR.NprApiDataGrpc? accessData in apiResponse.NprApiData)
            {
                NprApiDataGrpc mgrData = accessData.ToNprApiData();

                NprApiDataGrpc? matchedRequest = request.NprApiData
                    .FirstOrDefault(r => string.Equals(
                        r.RfqNprRequest.CustomerPartNumber,
                        mgrData.RfqNprRequest.CustomerPartNumber,
                        StringComparison.OrdinalIgnoreCase));

                if (matchedRequest != null && !string.IsNullOrEmpty(mgrData.RfqNprRequest.RequestID))
                {
                    matchedRequest.RfqNprRequest.CustomerRfqNo = mgrData.RfqNprRequest.RequestID;
                    updateRequest.RfqNprRequestGrpc.Add(matchedRequest.RfqNprRequest);
                }

                response.NprApiData.Add(mgrData);
            }

            UpdateRfqNprRequestGrpcResponse updateResponse = new UpdateRfqNprRequestGrpcResponse();
            if (0 < updateRequest.RfqNprRequestGrpc.Count)
            {
                updateResponse = await UpdateRfqNprRequestGrpc(updateRequest);
            }

            response.Message = response.Message + $" {updateResponse.Message}";

            return response;
        }
        #endregion
        #region Suppliers

        public async Task<GetAllSuppliersGrpcResponse> GetAllSuppliersGrpc(GetAllSuppliersGrpcRequest request)
        {
            await Task.Delay(0);
            GetAllSuppliersGrpcResponse response = new GetAllSuppliersGrpcResponse();
            SupplierGrpcRequest accessRequest = new SupplierGrpcRequest();
            accessRequest.Position = request.Position;
            accessRequest.Takeamount = request.Take;
            ListSupplierGrpc accessResponse = await _MasterClient.GetSupplierGrpcAsync(accessRequest);
            foreach (Master.SupplierGrpc? supplier in accessResponse.SupplierGrpc)
            {
                SupplierGrpc supplierGrpc = supplier.ToSupplierGrpc();
                response.SupplierGrpc.Add(supplierGrpc);
            }

            return response;
        }

        public async Task<GetAllSupplierGroupsGrpcResponse> GetAllSupplierGroupsGrpc(GetAllSupplierGroupsGrpcRequest request)
        {
            await Task.Delay(0);
            GetAllSupplierGroupsGrpcResponse response = new GetAllSupplierGroupsGrpcResponse();
            SupplierGroupGrpcRequest accessRequest = new SupplierGroupGrpcRequest();
            accessRequest.Position = request.Position;
            accessRequest.Takeamount = request.Take;
            ListSupplierGroupGrpc accessResponse = await _MasterClient.GetSupplierGroupGrpcAsync(accessRequest);
            foreach(Master.SupplierGroupGrpc? supplierGroup in accessResponse.SupplierGroupGrpc)
            {
                SupplierGroupGrpc supplierGroupGrpc = supplierGroup.ToSupplierGroupGrpc();
                response.SupplierGroupGrpc.Add(supplierGroupGrpc);
            }

            return response;
        }
        #endregion

        #region Filtering

        public Task<FilterGrpcResponse> FilterByCustomerId(FilterGrpcRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FilterGrpcResponse> FilterByLocationId(FilterGrpcRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<FilterGrpcResponse> FilterByProjectCode(FilterGrpcRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<FilterGrpcResponse> FilterEmacsByExactPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            EmacsFilterRequestGrpc emacsRequest = new EmacsFilterRequestGrpc();
            Collection<CombinedPartsGrpc> filteredList = new Collection<CombinedPartsGrpc>();
            FilterGrpcResponse response = new FilterGrpcResponse();
            string[] parametersToSearch = ["CustomerNumber", "SupplierNumber", "SumitomoNumber"];
            foreach (string parameter in parametersToSearch)
            {
                EmacsFilterResponseGrpc partNumberResponse = FilterSumitomoNumber<EmacsFilterResponseGrpc>(request.StringValue, parameter, "==");
                if (partNumberResponse.ListCombinedPartsGrpc != null)
                {
                    filteredList = ExtractEmacsResponseData<CombinedPartsGrpc>(partNumberResponse);
                    foreach (CombinedPartsGrpc part in filteredList)
                    {
                        string sumitmoNumberString = part.SumitomoNumber.ToString();
                        response.StringList.Add(sumitmoNumberString);
                    }

                    response.Success = true;
                    return response;
                }
            }

            return response;
        }

        public async Task<FilterGrpcResponse> FilterEmacsByContainingPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            EmacsFilterRequestGrpc emacsRequest = new EmacsFilterRequestGrpc();
            Collection<CombinedPartsGrpc> filteredList = new Collection<CombinedPartsGrpc>();
            FilterGrpcResponse response = new FilterGrpcResponse();
            string[] parametersToSearch = ["UniformCustomerNumber", "UniformSupplierNumber", "UniformSumitomoNumber"];
            Regex regexFilter = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            string uniformStringValue = regexFilter.Replace(request.StringValue, String.Empty);
            uniformStringValue = uniformStringValue.ToUpperInvariant().Trim();
            foreach (string parameter in parametersToSearch)
            {
                EmacsFilterResponseGrpc partNumberResponse = FilterSumitomoNumber<EmacsFilterResponseGrpc>(uniformStringValue, parameter, ".Contains");
                if (partNumberResponse.ListCombinedPartsGrpc != null)
                {
                    filteredList = ExtractEmacsResponseData<CombinedPartsGrpc>(partNumberResponse);
                    foreach (CombinedPartsGrpc part in filteredList)
                    {
                        string sumitmoNumberString = part.SumitomoNumber.ToString();
                        response.StringList.Add(sumitmoNumberString);
                    }

                    response.Success = true;
                    return response;
                }
            }

            return response;
        }

        public async Task<FilterGrpcResponse> FilterAdssBySumitomoPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            Adss.PartImageRequest adssRequest = new Adss.PartImageRequest();
            adssRequest.PartNumber = request.StringValue;
            Adss.PartImageReply partImageReply = _AdssGrpcClient.GetPartImage(adssRequest);
            FilterGrpcResponse response = new FilterGrpcResponse();
            if (partImageReply != null)
            {
                response.StringList.Add(adssRequest.PartNumber);
                response.ByteList.Add(partImageReply.Data);
                response.StringList2.Add(partImageReply.ContentType);
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
        public async Task<FilterGrpcResponse> FilterNPRBySumitomoPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            FilterGrpcResponse response = new FilterGrpcResponse();
            NPRFilterRequest filterRequest = new NPRFilterRequest();
            Collection<H1NPRViewGrpc> filteredList = new Collection<H1NPRViewGrpc>();
            NPRFilterResponse nprResponse = FilterSumitomoNumber<NPRFilterResponse>(request.StringValue, "SumitomoNo", "==");
            filteredList = ExtractNRPResponseData<H1NPRViewGrpc>(nprResponse);
            response.Success = true;
            foreach( H1NPRViewGrpc part in filteredList)
            {
                if (part.ExpiryDate == null || part.ExpiryDate.ToDateTime() < DateTime.UtcNow)
                {
                    continue;
                }

                string sumitmoNumberString = part.SumitomoNo.ToString();
                double price = part.Price ?? 0;
                response.StringList.Add(sumitmoNumberString);
                response.DoubleList.Add(price);
            }

            return response;
        }

        public async Task<FilterGrpcResponse> FilterCPDBySumitomoPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            FilterGrpcResponse response = new FilterGrpcResponse();
            CPDFilterRequest filterRequest = new CPDFilterRequest();
            Collection<MatSuppMstViewGrpc> filteredList = new Collection<MatSuppMstViewGrpc>();
            CPDFilterResponse cpdResponse = FilterSumitomoNumber<CPDFilterResponse>(request.StringValue, "MaterialNo", "==");
            filteredList = ExtractCPDResponseData<MatSuppMstViewGrpc>(cpdResponse);
            response.Success = true;

            DateTime sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);

            foreach (MatSuppMstViewGrpc part in filteredList)
            {
                if (part.UpdDt == null || part.UpdDt.ToDateTime() < sixMonthsAgo)
                {
                    continue;
                }

                string sumitmoNumberString = part.MaterialNo.ToString();
                double price = part.PoPrice ?? 0;
                response.StringList.Add(sumitmoNumberString);
                response.DoubleList.Add(price);
            }

            return response;
        }
        public async Task<FilterGrpcResponse> FilterRFQBySumitomoPartNumber(FilterGrpcRequest request)
        {
            await Task.Delay(1);
            FilterGrpcResponse response = new FilterGrpcResponse();
            RfqFilterRequest filterRequest = new RfqFilterRequest();
            Collection<RfqDrawingPartNumbersGrpc> filteredList = new Collection<RfqDrawingPartNumbersGrpc>();
            RfqFilterResponse rfqResponse = FilterSumitomoNumber<RfqFilterResponse>(request.StringValue, "SumitomoPartNumber", "==");
            filteredList = ExtractRFQResponseData<RfqDrawingPartNumbersGrpc>(rfqResponse);
            response.Success = true;
            foreach (RfqDrawingPartNumbersGrpc part in filteredList)
            {
                string sumitmoNumberString = part.SumitomoPartNumber.ToString();
                double price = price = part.OriginalPartNumberPrice ?? 0;
                if (part.IsSwapped == true)
                {
                    price = part.SwappedPartNumberPrice ?? 0;
                }

                response.StringList.Add(sumitmoNumberString);
                response.DoubleList.Add(price);
            }

            return response;
        }

        Collection<TItem> ExtractEmacsResponseData<TItem>(EmacsFilterResponseGrpc response)
        {
            Collection<TItem> results = new Collection<TItem>();

            TryExtractList(response.ListCombinedPartsGrpc?.CombinedPartsGrpc, results);
            TryExtractList(response.ListPartCategoryDetailGrpc?.PartCategoryDetailGrpc, results);
            TryExtractList(response.ListPartClassDetailGrpc?.PartClassDetailGrpc, results);
            TryExtractList(response.ListPartGroupsGrpc?.PartGroupsGrpc, results);
            TryExtractList(response.ListPartGroupsConstGrpc?.PartGroupsConstGrpc, results);
            TryExtractList(response.ListCustomerDataGrpc?.CustomerDataGrpc, results);
            TryExtractList(response.ListColourCodeGrpc?.ColourCodeGrpc, results);
            TryExtractList(response.ListMaterialGroupsGrpc?.MaterialGroupsGrpc, results);
            TryExtractList(response.ListMaterialTypesGrpc?.MaterialTypesGrpc, results);
            TryExtractList(response.ListNPACustomerGrpc?.NPACustomerGrpc, results);
            TryExtractList(response.ListNPASupplierGrpc?.NPASupplierGrpc, results);
            TryExtractList(response.ListSuppliersGrpc?.SuppliersGrpc, results);
            TryExtractList(response.ListEmacsRFIViewGrpc?.EmacsRFIViewGrpc, results);
            TryExtractList(response.ListPARTMSGrpc?.PARTMSGrpc, results);
            TryExtractList(response.ListAlternativePartsGrpc?.AlternativePartsGrpc, results);

            return results;
        }
        Collection<TItem> ExtractCPDResponseData<TItem>(CPDFilterResponse response)
        {
            Collection<TItem> results = new Collection<TItem>();

            TryExtractList(response.ListMatSuppMstGrpc?.MatSuppMstViewGrpc, results);

            return results;
        }
        Collection<TItem> ExtractNRPResponseData<TItem>(NPRFilterResponse response)
        {
            Collection<TItem> results = new Collection<TItem>();

            TryExtractList(response.ListH1NPRViewGrpc?.H1NPRViewGrpc, results);

            return results;
        }
        Collection<TItem> ExtractRFQResponseData<TItem>(RfqFilterResponse response)
        {
            Collection<TItem> results = new Collection<TItem>();

            TryExtractList(response.ListRfqDrawingPartNumbersGrpc?.RfqDrawingPartNumbers, results);
            TryExtractList(response.ListRfqReasonGrpc?.RfqReasons, results);
            TryExtractList(response.ListRfqNotesGrpc?.RfqNotes, results);
            TryExtractList(response.ListRfqProjectGrpc?.RfqProjects, results);
            TryExtractList(response.ListRfqNprRequestGrpc?.RfqNprRequestGrpcs, results);

            return results;
        }
        Collection<TItem> ExtractMastersResponseData<TItem>(MastersFilterResponseGrpc response)
        {
            Collection<TItem> results = new Collection<TItem>();

            TryExtractList(response.CurrencyGrpcList?.CurrencyGrpc, results);
            TryExtractList(response.CustomerGrpcList?.CustomerGrpc, results);
            TryExtractList(response.CustomerLocationGrpcList?.CustomerLocationGrpc, results);
            TryExtractList(response.CustomerSalesEntityGrpcList?.CustomerSalesEntityGrpc, results);
            TryExtractList(response.CustomerProjectAssociationGrpcList?.CustomerProjectAssociationGrpc, results);
            TryExtractList(response.CustomerBusinessUserAssociationGrpcList?.CustomerBusinessUserAssociationGrpc, results);
            TryExtractList(response.MilestoneGrpcList?.MilestoneGrpc, results);
            TryExtractList(response.PlatformGrpcList?.PlatformGrpc, results);
            TryExtractList(response.ProgramGrpcList?.ProgramGrpc, results);
            TryExtractList(response.ProjectGrpcList?.ProjectGrpc, results);
            TryExtractList(response.VehicleGrpcList?.VehicleGrpc, results);

            return results;
        }
        bool TryExtractList<TItem, T>(IEnumerable<TItem>? items, Collection<T> results) where TItem : class
        {
            if (items != null && typeof(T) == typeof(TItem))
            {
                foreach (TItem item in items)
                {
                    results.Add((T)(object)item);
                }

                return true;
            }

            return false;
        }
        T FilterSumitomoNumber<T>(string partNumber, string filterType, string filterOpperator)
        {
            string filterExpression = string.Empty;
            if (filterOpperator == "==")
            {
                filterExpression = $"{filterType} != null && {filterType}.ToUpperInvariant().TrimEnd() {filterOpperator} \"{partNumber.ToUpperInvariant().TrimEnd()}\"";
            }
            else if (filterOpperator == ".Contains")
            {
                filterExpression = $"{filterType} != null && {filterType}.ToUpperInvariant().TrimEnd(){filterOpperator}(\"{partNumber.ToUpperInvariant().TrimEnd()}\")";
            }
            else
            {
                throw new ArgumentException("Invalid filter operator");
            }

            switch (typeof(T).Name)
            {
                case "EmacsFilterResponseGrpc":
                EmacsFilterRequestGrpc emacsRequest = new EmacsFilterRequestGrpc();
                emacsRequest.FilterExpression = filterExpression;
                emacsRequest.DatabaseList = "CombinedPartsGrpc";
                EmacsFilterResponseGrpc filterResponse = _EmacsClient.FilterEmacsDataGrpc(emacsRequest);
                return (T)(object)filterResponse;
                case "NPRFilterResponse":
                NPRFilterRequest nprRequest = new NPRFilterRequest();
                nprRequest.FilterExpression = filterExpression;
                nprRequest.DatabaseList = "H1NPRViewGrpc";
                NPRFilterResponse filterNprResponse = _NPRGrpcClient.FilterNPRGrpc(nprRequest);
                return (T)(object)filterNprResponse;
                case "CPDFilterResponse":
                CPDFilterRequest cpdRequest = new CPDFilterRequest();
                cpdRequest.FilterExpression = filterExpression;
                cpdRequest.DatabaseList = "MatSuppMstViewGrpc";
                CPDFilterResponse filterCpdResponse = _CPDClient.FilterCPDGrpc(cpdRequest);
                return (T)(object)filterCpdResponse;
                case "RfqFilterResponse":
                RfqFilterRequest rfqRequest = new RfqFilterRequest();
                rfqRequest.FilterExpression = filterExpression;
                rfqRequest.DatabaseList = "RfqDrawingPartNumbersGrpc";
                RfqFilterResponse filterRfqResponse = _RfqClient.FilterRfqGrpc(rfqRequest);
                return (T)(object)filterRfqResponse;
                default:
                throw new ArgumentException("Invalid type parameter");
            }
          }
        #endregion

        #region DSI
        public async Task<GetAllHarnessModuleResponse> GetAllHarnessGrpc(GetAllHarnessModuleRequest request)
        {
            _ = request; 

            try
            {
                await Task.Delay(1);

                DSIFilterRequest filterRequest = new DSIFilterRequest();
                filterRequest.DatabaseList = "HARNESSGRPC";
                filterRequest.FilterExpression = "1 == 1";

                DSIFilterResponse filterResponse =
                    await _DSIClient.FilterDSIGrpcAsync(filterRequest);

                ListHarnessGrpc harnessList =
                    filterResponse.HarnessList ?? new ListHarnessGrpc();

                GetAllHarnessModuleResponse response =
                    new GetAllHarnessModuleResponse();

                foreach (HarnessGrpc? item in harnessList.HarnessList)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    DSIHarnessGrpc harness = new DSIHarnessGrpc();

                    harness.Id = item.Id;
                    harness.HarnessName1 = item.HarnessName1;
                    harness.Customer = item.Customer;
                    harness.Site = item.Site;

                    response.HarnessList.Add(harness);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching Harness list from DSI", ex);
                throw;
            }
        }
        //get All derivatibe by composite
        public async Task<GetCompositeDetailByHarnessResponse> GetCompositeDetailByHarnessGrpc(GetCompositeDetailByHarnessRequest request)
        {
            _ = request;
            try
            {
                await Task.Delay(1);
                DSIFilterRequest filterRequest = new DSIFilterRequest();
                filterRequest.DatabaseList = "COMPOSITEDETAILGRPC";
                filterRequest.FilterExpression =
                    $"HarnessID == \"{request.HarnessId}\"";

                DSIFilterResponse filterResponse =
                    await _DSIClient.FilterDSIGrpcAsync(filterRequest);

                ListCompositeDetailGrpc compositeDetailList =
                    filterResponse.CompositeDetailList ?? new ListCompositeDetailGrpc();

                GetCompositeDetailByHarnessResponse response =
                    new GetCompositeDetailByHarnessResponse();

                foreach (CompositeDetailGrpc? item in compositeDetailList.CompositeDetailList)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    DSICompositeDetailGrpc compositeDetail =
                        new DSICompositeDetailGrpc();

                    compositeDetail.Id = item.Id;

                    compositeDetail.HarnessName1 = item.HarnessName1;
                    compositeDetail.SimilarHarnessName1 = item.SimilarHarnessName1;
                    compositeDetail.HarnessIssue1 = item.HarnessIssue1;
                    compositeDetail.SimilarHarnessIssue1 = item.SimilarHarnessIssue1;
                    compositeDetail.HarnessDate1 = item.HarnessDate1;

                    compositeDetail.HarnessName2 = item.HarnessName2;
                    compositeDetail.SimilarHarnessName2 = item.SimilarHarnessName2;
                    compositeDetail.HarnessIssue2 = item.HarnessIssue2;
                    compositeDetail.SimilarHarnessIssue2 = item.SimilarHarnessIssue2;
                    compositeDetail.HarnessDate2 = item.HarnessDate2;

                    compositeDetail.Customer = item.Customer;
                    compositeDetail.Site = item.Site;
                    compositeDetail.Range = item.Range;

                    compositeDetail.BoardLength = item.BoardLength;
                    compositeDetail.BoardWidth = item.BoardWidth;

                    compositeDetail.Datum = item.Datum;

                    compositeDetail.UserField1 = item.UserField1;
                    compositeDetail.UserField2 = item.UserField2;
                    compositeDetail.UserField3 = item.UserField3;
                    compositeDetail.UserField4 = item.UserField4;
                    compositeDetail.UserField5 = item.UserField5;

                    compositeDetail.Checker = item.Checker;
                    compositeDetail.Inputter = item.Inputter;
                    compositeDetail.DraftedBy = item.DraftedBy;
                    compositeDetail.PreparedBy = item.PreparedBy;

                    compositeDetail.Type = item.Type;
                    compositeDetail.Title = item.Title;
                    compositeDetail.EngineSize = item.EngineSize;
                    compositeDetail.ManufacturingCell = item.ManufacturingCell;
                    compositeDetail.Trim = item.Trim;
                    compositeDetail.HandDrive = item.HandDrive;

                    compositeDetail.TubeAddOnType = item.TubeAddOnType;
                    compositeDetail.TubeAddOnFactor = item.TubeAddOnFactor;

                    compositeDetail.IsManualTerminal = item.IsManualTerminal;
                    compositeDetail.IsAllConnectorsSealed = item.IsAllConnectorsSealed;

                    compositeDetail.AlphaCode = item.AlphaCode;

                    compositeDetail.HarnessID = item.HarnessID;
                    compositeDetail.CircuitOption = item.CircuitOption;

                    compositeDetail.CreatedDate = item.CreatedDate;
                    compositeDetail.ModifiedDate = item.ModifiedDate;

                    compositeDetail.CreatedBy = item.CreatedBy;
                    compositeDetail.ModifiedBy = item.ModifiedBy;

                    response.CompositeDetails.Add(compositeDetail);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(
                    "Error fetching CompositeDetail list from DSI by HarnessId",
                    ex);

                throw;
            }
          }
        public async Task<GetCompositeDetailByHarnessNameResponse> GetCompositeDetailByHarnessNameGrpc(GetCompositeDetailByHarnessNameRequest request)
        {
            _ = request;
            try
            {
                await Task.Delay(1);

                DSIFilterRequest filterRequest = new DSIFilterRequest();

                filterRequest.DatabaseList = "COMPOSITEDETAILGRPC";
                filterRequest.FilterExpression =
                    $"HarnessID == \"{request.HarnessId}\" && HarnessName1 == \"{request.HarnessName1}\"";
                DSIFilterResponse filterResponse =
                    await _DSIClient.FilterDSIGrpcAsync(filterRequest);
                ListCompositeDetailGrpc compositeDetailList =
                    filterResponse.CompositeDetailList ?? new ListCompositeDetailGrpc();
                GetCompositeDetailByHarnessNameResponse response =
                    new GetCompositeDetailByHarnessNameResponse();

                foreach (CompositeDetailGrpc? item in compositeDetailList.CompositeDetailList)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    DSICompositeDetailGrpc compositeDetail =
                        new DSICompositeDetailGrpc();

                    compositeDetail.Id = item.Id;

                    compositeDetail.HarnessName1 = item.HarnessName1;
                    compositeDetail.SimilarHarnessName1 = item.SimilarHarnessName1;
                    compositeDetail.HarnessIssue1 = item.HarnessIssue1;
                    compositeDetail.SimilarHarnessIssue1 = item.SimilarHarnessIssue1;
                    compositeDetail.HarnessDate1 = item.HarnessDate1;

                    compositeDetail.HarnessName2 = item.HarnessName2;
                    compositeDetail.SimilarHarnessName2 = item.SimilarHarnessName2;
                    compositeDetail.HarnessIssue2 = item.HarnessIssue2;
                    compositeDetail.SimilarHarnessIssue2 = item.SimilarHarnessIssue2;
                    compositeDetail.HarnessDate2 = item.HarnessDate2;

                    compositeDetail.Customer = item.Customer;
                    compositeDetail.Site = item.Site;
                    compositeDetail.Range = item.Range;

                    compositeDetail.BoardLength = item.BoardLength;
                    compositeDetail.BoardWidth = item.BoardWidth;

                    compositeDetail.Datum = item.Datum;

                    compositeDetail.UserField1 = item.UserField1;
                    compositeDetail.UserField2 = item.UserField2;
                    compositeDetail.UserField3 = item.UserField3;
                    compositeDetail.UserField4 = item.UserField4;
                    compositeDetail.UserField5 = item.UserField5;

                    compositeDetail.Checker = item.Checker;
                    compositeDetail.Inputter = item.Inputter;
                    compositeDetail.DraftedBy = item.DraftedBy;
                    compositeDetail.PreparedBy = item.PreparedBy;

                    compositeDetail.Type = item.Type;
                    compositeDetail.Title = item.Title;
                    compositeDetail.EngineSize = item.EngineSize;
                    compositeDetail.ManufacturingCell = item.ManufacturingCell;
                    compositeDetail.Trim = item.Trim;
                    compositeDetail.HandDrive = item.HandDrive;

                    compositeDetail.TubeAddOnType = item.TubeAddOnType;
                    compositeDetail.TubeAddOnFactor = item.TubeAddOnFactor;

                    compositeDetail.IsManualTerminal = item.IsManualTerminal;
                    compositeDetail.IsAllConnectorsSealed = item.IsAllConnectorsSealed;

                    compositeDetail.AlphaCode = item.AlphaCode;

                    compositeDetail.HarnessID = item.HarnessID;
                    compositeDetail.CircuitOption = item.CircuitOption;

                    compositeDetail.CreatedDate = item.CreatedDate;
                    compositeDetail.ModifiedDate = item.ModifiedDate;

                    compositeDetail.CreatedBy = item.CreatedBy;
                    compositeDetail.ModifiedBy = item.ModifiedBy;

                    response.CompositeDetails.Add(compositeDetail);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(
                    "Error fetching CompositeDetail list from DSI by HarnessId",
                    ex);

                throw;
            }
        }
        public async Task<GetWireSpecificationByCompositeOptionResponse> GetWireSpecificationByCompositeOptionGrpc( GetWireSpecificationByCompositeOptionRequest request)
        {
            try
            {
                await Task.Delay(1);
                 DSIFilterRequest filterRequest = new DSIFilterRequest();

                filterRequest.DatabaseList = "WIRESPECIFICATIONGRPC";
                filterRequest.FilterExpression =
                    $"Compositeoptionstring == \"{request.CompositeOptionString}\"";

                DSIFilterResponse filterResponse =
                    await _DSIClient.FilterDSIGrpcAsync(filterRequest);

                ListWireSpecificationGrpc wireSpecificationList =
                    filterResponse.WireSpecificationList ?? new ListWireSpecificationGrpc();

                GetWireSpecificationByCompositeOptionResponse response =
                    new GetWireSpecificationByCompositeOptionResponse();

                foreach (WireSpecificationGrpc? item in wireSpecificationList.WireSpecificationList)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    DSIWireSpecificationGrpc wire =
                        new DSIWireSpecificationGrpc();

                    wire.Id = item.Id;
                    wire.WireName = item.WireName;
                    wire.Compositeoptionstring = item.Compositeoptionstring;
                    wire.WireType = item.WireType;
                    wire.Colour = item.Colour;
                    wire.CrossSectionalArea = item.CrossSectionalArea;
                    wire.Material = item.Material;

                    wire.End1NodeName = item.End1NodeName;
                    wire.End2NodeName = item.End2NodeName;

                    wire.IsIncludedOnBom = item.IsIncludedOnBom;
                    wire.IsIncludedOnChart = item.IsIncludedOnChart;

                    wire.WireTag = item.WireTag;
                    wire.WireNote = item.WireNote;

                    wire.UnmodifiedWireLength = item.UnmodifiedWireLength;
                    wire.ModifiedWireLength = item.ModifiedWireLength;

                    wire.PartNumber1 = item.PartNumber1;
                    wire.PartNumber2 = item.PartNumber2;
                    wire.PartNumber3 = item.PartNumber3;

                    wire.Signal = item.Signal;
                    wire.HarnessID = item.HarnessID;

                    wire.CreatedDate = item.CreatedDate;
                    wire.ModifiedDate = item.ModifiedDate;

                    response.WireSpecifications.Add(wire);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(
                    "Error fetching WireSpecification list from DSI by CompositeOptionString",
                    ex);

                throw;
            }
        }
        public async Task<ListComponentGrpc> GetComponentsByHarnessAndOptionsGrpc(
     GetComponentsByHarnessAndOptionsRequest request)
        {
            try
            {
                await Task.Delay(1);

                //////////////////////////////////////////////////////
                //  BUILD DSI REQUEST
                //////////////////////////////////////////////////////
                GetComponentByHarnessRequest dsiRequest = new GetComponentByHarnessRequest();

                dsiRequest.HarnessName = request.HarnessName;
                dsiRequest.CompositeOptions.AddRange(request.CompositeOptions);

                //////////////////////////////////////////////////////
                //  CALL DSI DIRECT METHOD
                //////////////////////////////////////////////////////
                DSI.ListComponentGrpc dsiResponse =
                    await _DSIClient.GetComponentsByHarnessAndOptionsAsync(dsiRequest);

                //////////////////////////////////////////////////////
                //  BUILD MANAGER RESPONSE
                //////////////////////////////////////////////////////
                ListComponentGrpc response = new ListComponentGrpc();

                //////////////////////////////////////////////////////
                //  MAPPING
                //////////////////////////////////////////////////////
                foreach (ComponentGrpc? item in dsiResponse.ComponentList)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    DSIComponentGrpc component = new DSIComponentGrpc();

                    component.Id = item.Id;

                    component.NodeName = item.NodeName;
                    component.CavityName = item.CavityName;
                    component.WireName = item.WireName;
                    component.SequenceNumber = item.SequenceNumber;

                    component.ComponentTypeCode1 = item.ComponentTypeCode1;
                    component.ComponentOption = item.ComponentOption;
                    component.ServiceFunction = item.ServiceFunction;

                    component.Route = item.Route;

                    component.PartNumber1 = item.PartNumber1;
                    component.PartNumber2 = item.PartNumber2;
                    component.PartNumber3 = item.PartNumber3;

                    component.Quantity = item.Quantity;
                    component.CrossSectionalArea = item.CrossSectionalArea;

                    component.IsSelectTerminal = item.IsSelectTerminal;
                    component.IsSeal = item.IsSeal;
                    component.IsPlugged = item.IsPlugged;

                    component.BlockNumber = item.BlockNumber;
                    component.TerminationMethod = item.TerminationMethod;
                    component.MaterialCode = item.MaterialCode;

                    component.ComponentTypeCode2 = item.ComponentTypeCode2;
                    component.InsulationType = item.InsulationType;

                    component.UserModule = item.UserModule;
                    component.HarnessID = item.HarnessID;

                    component.CreatedDate = item.CreatedDate;
                    component.ModifiedDate = item.ModifiedDate;

                    response.ComponentList.Add(component);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError(
                    "Error fetching Components by HarnessName and CompositeOptions from DSI",
                    ex);

                throw;
            }
        }
        #endregion
    }
}