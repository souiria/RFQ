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
        //readonly DSI.DSI.DSIClient _DSIClient;
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
            //DSI.DSI.DSIClient dSIClient,
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
            //_DSIClient = dSIClient;
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
                    if (masterCustomer != null)
                    {
                        CustomerGrpc customer = masterCustomer.ToCustomerGrpc();
                        getAllCustomersGrpcResponse.Customers.Add(customer);
                    }
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
                filterRequest.FilterExpression = $"CustomerBusinessHierarchyGuid != null && IsActive == true && CustomerBusinessHierarchyGuid.ToUpperInvariant() == \"{request.CustomerId.ToUpperInvariant()}\"";
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
                filterRequest.FilterExpression = $"Id != null && IsActive == true";
                MastersFilterResponseGrpc projects = _MasterClient.FilterMasterDataGrpc(filterRequest);
                List<ProjectGrpc> allProjects = ExtractMastersResponseData<ProjectGrpc>(projects).ToList();

                // load second loop in memory
                filterRequest.DatabaseList = "CUSTOMERPROJECTASSOCIATIONGRPC";
#pragma warning disable CA1308
                filterRequest.FilterExpression = $"CustomerLocationGuid != null && IsActive == true";
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
                List<ProjectGrpc> extractedProjects = new List<ProjectGrpc>();
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
                        extractedProjects = allProjects
                                .Where(p => p.Id != null && p.Id.Equals(customerProjectAssociation.ProjectGuid, StringComparison.OrdinalIgnoreCase))
                                .ToList();

                        if (extractedProjects.Count <= 0)
                        {
                            continue;
                        }

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

                VehicleGrpcRequest vehicleRequest = new VehicleGrpcRequest();
                ListVehicleGrpc vehicles = _MasterClient.GetVehicleGrpc(vehicleRequest);
                List<ProjectAssociation> matchedProjectAssociations = response.ProjectAssociation
                    .Where(pa => HasMatchingVehicle(pa.CustomerProjectCode, vehicles.VehicleGrpc))
                    .ToList();

                response.ProjectAssociation.Clear();
                response.ProjectAssociation.AddRange(matchedProjectAssociations);

                foreach(ProjectGrpc project in extractedProjects)
                {
                    response.ProjectAssociation.Where(x => x.CustomerProjectGuid.ToUpperInvariant() == project.Id.ToUpperInvariant()).ToList().ForEach(pa =>
                    {
                        _Projects = extractedProjects.Where(p => p.Id.ToUpperInvariant() == pa.CustomerProjectGuid.ToUpperInvariant()).ToList();
                    });
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

        static bool HasMatchingVehicle(string customerProjectCode, Google.Protobuf.Collections.RepeatedField<Master.VehicleGrpc> vehicles)
        {
            if (string.IsNullOrWhiteSpace(customerProjectCode))
            {
                return false;
            }

            foreach (Master.VehicleGrpc? vehicle in vehicles)
            {
                if (vehicle.ProjectReference.Contains('+', StringComparison.InvariantCulture))
                {
                    string[] vehiclprojectReferenceSplit = vehicle.ProjectReference.Split('+');
                    foreach (string code in vehiclprojectReferenceSplit)
                    {
                        if (!string.IsNullOrWhiteSpace(code) &&
                            customerProjectCode.Contains(code, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
                else if (customerProjectCode.Contains(vehicle.ProjectReference, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
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
                reasonFilterRequest.FilterExpression = "RfqReasonTitle != null && RfqReasonTitle != \"\"";
                RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();

                GetRfqReasonsGrpcResponse response = new GetRfqReasonsGrpcResponse();
                response.RfqReasons.Clear();
                response.RfqReasons.AddRange(rfqReasons.RfqReasons);
                //foreach (RfqReasonGrpc? reason in rfqReasons.RfqReasons)
                //{
                //    RfqReasonGrpc rfqReason = reason.ToReason();
                //    response.RfqReasons.Add(rfqReason);
                //}

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
                RfqCrudGrpcResponse grpcResponse = _RfqClient.DeleteRfqProjectByRowIdGrpc(rfqProjectRequest);
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
                reasonFilterRequest.FilterExpression = "RfqReasonTitle != null && RfqReasonTitle != \"\"";

                RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();
                // Build reason lookup
                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId.HasValue && r.RowId.Value != 0 && !string.IsNullOrEmpty(r.RfqReasonTitle))
                    .Select(r => new { Key = r.RowId ?? 0, Value = r.RfqReasonTitle })
                    .ToDictionary(x => x.Key, x => x.Value);    

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
                reasonFilterRequest.FilterExpression = "RfqReasonTitle != null && RfqReasonTitle != \"\"";

                RfqFilterResponse reasonFilterResponse = _RfqClient.FilterRfqGrpc(reasonFilterRequest);

                ListRfqReasonGrpc rfqReasons = reasonFilterResponse.ListRfqReasonGrpc ?? new ListRfqReasonGrpc();

                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId != 0 && r.RfqReasonTitle != null)
                    .ToDictionary(r => r.RowId ?? 0, r => r.RfqReasonTitle ?? string.Empty);

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
            GetProjectAssociationsByCustomerIdRequest req = new GetProjectAssociationsByCustomerIdRequest();
            req.CustomerId = request.Project.CustomerBusinessUnitGuid;
            await GetProjectAssociationsByCustomerId(req);

            ProjectGrpc? project = _Projects.FirstOrDefault(p => p.Id.ToUpperInvariant() == request.Project.ProjectGuid.ToUpperInvariant());
            if (project == null)
            {
                CreateRfqProjectGrpcResponse errorResponse = new CreateRfqProjectGrpcResponse();
                errorResponse.Success = false;
                errorResponse.Message = $"No project association by customer id found!";
                return errorResponse;
            }

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
                rfqProject.JsonData = request.Project.JsonData;

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
        public async Task<RfqCrudResponse> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                // Map each incoming part into a gRPC access DTO
                // it'a RfqDrawingPartNumbersGrpc vs RfqModule.RfqDrawingPartNumberGrpc
                // why a type is named RfqDrawingPartNumbersGrpc (plural) if accepted
                // convention is singular? I don't know, but it is what it is. Retorical.
                List<RfqDrawingPartNumberGrpc> partsToUpdate = new List<RfqDrawingPartNumberGrpc>();
                foreach (RfqDrawingPartNumberGrpc? part in request.RfqDrawingPartNumbersGrpcsToUpdate)
                {
                    RfqDrawingPartNumberGrpc grpcPart = part; //.ToAccessDto();
                    partsToUpdate.Add(grpcPart);
                }

                RfqDrawingPartNumbersGrpcRequest rfqProjectRequest = new RfqDrawingPartNumbersGrpcRequest();
                rfqProjectRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqProjectRequest.RfqGrpcRequestParameter.RequestType = 80;
                rfqProjectRequest.RfqDrawingPartNumbersGrpcsToUpdate.AddRange(partsToUpdate);
                RfqCrudGrpcResponse updateResponse = _RfqClient.UpdateRfqDrawingPartNumbersGrpc(rfqProjectRequest);
                RfqCrudResponse response = new RfqCrudResponse();
                response.SaveSuccess = updateResponse.SaveSuccess;  
                response.Message = updateResponse.Message;
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error Updating RFQ drawing part numbers", ex);
                throw;
            }
        }
        public async Task<ListRfqDrawingPartNumberGrpc> GetRfqDrawingPartNumbersByRfqIdGrpc(RfqDrawingPartNumbersGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                ListRfqDrawingPartNumberGrpc response = new ListRfqDrawingPartNumberGrpc();

                RfqFilterRequest rfqFilterRequest = new RfqFilterRequest();

                rfqFilterRequest.DatabaseList = "RFQDRAWINGPARTNUMBERGRPC";
                rfqFilterRequest.FilterExpression = $"(RfqId != null && RfqId == {request.RfqId})";

                RfqFilterResponse rfqFilterResponse = _RfqClient.FilterRfqGrpc(rfqFilterRequest);

                if(rfqFilterResponse == null
                    || rfqFilterResponse.ListRfqDrawingPartNumbersGrpc == null
                    || rfqFilterResponse.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers == null)
                {
                    return response;
                }

                List<RfqDrawingPartNumberGrpc> rfqPartNumbers = rfqFilterResponse.ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.ToList();

                int partNumberCount = rfqPartNumbers.Count;
                bool hasParts = !(partNumberCount <= 0);
                if (hasParts)
                {
                    List<RfqDrawingPartNumberGrpc> mappedParts = new List<RfqDrawingPartNumberGrpc>();

                    foreach (RfqDrawingPartNumberGrpc grpcPart in rfqPartNumbers)
                    {
                        RfqDrawingPartNumberGrpc mappedPart = grpcPart; //.ToClientDto();
                        mappedParts.Add(mappedPart);
                    }

                    response.RfqDrawingPartNumbers.AddRange(mappedParts);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error fetching RFQ drawing parts by RfqId: {request.RfqId}", ex);
                throw;
            }
        }
        public async Task<RfqCrudResponse> DeleteRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                RfqDrawingPartNumbersGrpcRequest accessGgrpcRequest = new RfqDrawingPartNumbersGrpcRequest();

                accessGgrpcRequest.RfqGrpcRequestParameter = new();
                accessGgrpcRequest.RfqGrpcRequestParameter.RequestType = 90;
                List<RfqDrawingPartNumberGrpc> accessDtos = request.RfqDrawingPartNumbersGrpcsToDelete.Select(p => p).ToList();
                accessGgrpcRequest.RfqDrawingPartNumbersGrpcsToDelete.AddRange(accessDtos);

                RfqCrudGrpcResponse grpcResponse = await _RfqClient.DeleteRfqDrawingPartNumbersGrpcAsync(accessGgrpcRequest);
                bool result = grpcResponse.SaveSuccess;

                string message;
                if (result)
                {
                    message = $"DeleteRfqDrawingPartNumbersGrpc removed {accessDtos.Count} parts.";
                }
                else
                {
                    message = $"DeleteRfqDrawingPartNumbersGrpc failed to delete {accessDtos.Count} parts.";
                }

                RfqCrudResponse response = new();
                response.SaveSuccess = result;
                response.Message = message;

                return response;
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error deleting drawing parts for RFQ.";
                _Logger.GenericLogError(errorMessage, ex);
                throw;
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        RfqCrudGrpcResponse CreateRfqDrawingPartNumbers(string projectId, List<CustomerParts> customerParts)
        {
            RfqDrawingPartNumbersGrpcRequest partRequest = new RfqDrawingPartNumbersGrpcRequest();
            RfqCrudGrpcResponse partResponse = new RfqCrudGrpcResponse();
            partResponse.SaveSuccess = false;

            try
            {
                _Logger.GenericLogInformation($"III RfqManagerService.CreateRfqDrawingPartNumbers - start GRPC to the access layer - sending {customerParts.Count} parts");

                partRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                partRequest.RfqGrpcRequestParameter.RequestType = 70;
                foreach (CustomerParts customerPart in customerParts)
                {
                    RfqDrawingPartNumberGrpc part = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber1);
                    //part.Quantity = customerPart.Qua
                    partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part);
                    if (customerPart.PartNumber2 != null)
                    {
                        RfqDrawingPartNumberGrpc part2 = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber2);
                        partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part2);
                    }

                    if (customerPart.PartNumber3 != null)
                    {
                        RfqDrawingPartNumberGrpc  part3 = ToRfqDrawingPartNumbers(projectId, customerPart.PartNumber3);
                        partRequest.RfqDrawingPartNumbersGrpcsToCreate.Add(part3);
                    }
                }

                partResponse = _RfqClient.CreateRfqDrawingPartNumbersGrpc(partRequest);

                string msg = partResponse.SaveSuccess == true ? "successfully" : "failed somehow";
                _Logger.GenericLogInformation($"III RfqManagerService.CreateRfqDrawingPartNumbers - access layer returned over GRPC - {msg}");
                return partResponse;

            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"EEE RfqManagerService.CreateRfqDrawingPartNumbers - access layer returned over GRPC - {ex.Message}", ex);
            }

            return partResponse;

        }
        RfqDrawingPartNumberGrpc ToRfqDrawingPartNumbers(string projectId, string partNumber)
        {
            RfqDrawingPartNumberGrpc part = new RfqDrawingPartNumberGrpc();
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
            (List<CustomerParts> customerParts, bool hasDerivatives) = await ConvertDocumentAsync(request);

            // if the file has derivatives, don't create a part list as the user needs to select which derivatives to create RFQ parts for
            if (hasDerivatives)
            {
                uploadResponse.Success = true;
                uploadResponse.Message = $"{request.FileName} processed successfully. Please select one or more derivatives to create RFQ Parts.";
                _Logger.GenericLogInformation($"III RfqManagerService.UploadPartsGrpc Successfully uploaded - {customerParts.Count} parts incoming, but no RFQ parts created because the file was a DSI file with derivatives.");
                return uploadResponse;
            }

            // unique list of customer parts, create this part list to send to the access layer to create the RFQ parts in the database
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

        async Task<(List<CustomerParts> partList, bool hasDerivatives)> ConvertDocumentAsync(UploadPartsRequestGrpcRequest request)
        {
            List<CrossReferenceDto> crossReferenceDtos = new List<CrossReferenceDto>();
            List<FordCsvDto> fordCsvDtos = new List<FordCsvDto>();
            DsiAggregate dsiAggregate = new DsiAggregate();
            List<CustomerParts> customerParts = new List<CustomerParts>();
            bool hasDerivatives = false;
            try
            {
                // Check if file data exists
                if (request.FileData == null || request.FileData.Length == 0)
                {
                    return (customerParts, false);
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
                        _ = Task.Run(async () => await SaveDsiAggregateAsync(dsiAggregate, request.UserId));
                        hasDerivatives = dsiAggregate.ComponentList != null && dsiAggregate.ComponentList.Any();    
                        break;
                    default:
                    _Logger.GenericLogInformation("Unsupported file type:" + fileExtension);
                    return (customerParts, false);
                }
            }
            catch (FileFormatException ex)
            {
                _Logger.GenericLogError("Error processing file upload for " + request.FileName, ex);
                return (customerParts, false);
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

            if (dsiAggregate.ComponentList != null && hasDerivatives)
            {
                List<ComponentDto> components = new List<ComponentDto>();
                components = dsiAggregate.ComponentList
                    .Where(cr => !string.IsNullOrWhiteSpace(cr.PartNumber1)
                    && !string.IsNullOrWhiteSpace(cr.PartNumber2)
                    && !string.IsNullOrWhiteSpace(cr.PartNumber3))
                    .ToList();

                if(!components.Any())
                {
                    // didn't found anything, it's probably a flat DSI file, so we will take any component that has at least one part number
                    components = dsiAggregate.ComponentList
                        .Where(cr => !string.IsNullOrWhiteSpace(cr.PartNumber1)
                        || !string.IsNullOrWhiteSpace(cr.PartNumber2)
                        || !string.IsNullOrWhiteSpace(cr.PartNumber3))
                        .ToList();
                }

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

                return (customerParts, true);
            }

            return (customerParts, false);
        }

        async Task SaveDsiAggregateAsync(DsiAggregate dsiAggregate, string userId)
        {
            try
            {
                await Task.Delay(1);
                DsiHarnessGrpc harness = await SaveHarness(dsiAggregate, userId);
                if(harness == null)
                {
                    _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save harness");
                    return;
                }

                if(dsiAggregate.Harness != null)
                {
                    dsiAggregate.Harness.HarnessId = Guid.Parse(harness.HarnessId);
                }

                GetAllRfqProjectGrpcRequest rfqRequest = new GetAllRfqProjectGrpcRequest();
                rfqRequest.Position = 0;
                rfqRequest.Take = 1000;

                GetAllRfqProjectGrpcResponse rfqResponse = await GetAllRfqProjectGrpc(rfqRequest);

                RfqProject? lastRfqProject = rfqResponse.RfqProjects
                    .OrderByDescending(x => x.RowId)
                    .FirstOrDefault();

                if (lastRfqProject != null && dsiAggregate.Harness != null)
                {
                    JObject jsonObject = new JObject();
                    jsonObject["HarnessId"] = dsiAggregate.Harness.HarnessId.ToString();

                    string jsonData = jsonObject.ToString(Formatting.None);

                    lastRfqProject.JsonData = jsonData;

                    UpdateRfqProjectGrpcRequest updateRequest = new UpdateRfqProjectGrpcRequest();
                    updateRequest.Project = lastRfqProject;
                         UpdateRfqProjectGrpcResponse updateResponse =
                        await UpdateRfqProject(updateRequest);

                    _Logger.GenericLogInformation(
                        $"RFQ Project {lastRfqProject.RfqNumber} updated. JsonData={jsonData}");
                }

                await SaveHarness(dsiAggregate, userId);
                await SaveBranchConfigurationAsync(dsiAggregate, userId);
                await SaveBranchInsulationAsync(dsiAggregate, userId);
                await SaveBranchInsulationThroughNodeAsync(dsiAggregate, userId);
                await SaveComponentAsync(dsiAggregate, userId);
                await SaveCircuitOptionAsync(dsiAggregate, userId);
                await SaveCompositeDetailsAsync(dsiAggregate, userId);
                await SaveCompositeOptionAsync(dsiAggregate, userId);
                await SaveScopeAsync(dsiAggregate, userId);
                await SaveHarnessScope(dsiAggregate, userId);
                await SaveManualBomQuantity(dsiAggregate, userId);
                await SaveMidWireComponent(dsiAggregate, userId);
                await SaveModuleChildDetail(dsiAggregate, userId);
                await SaveModuleCompatibility(dsiAggregate, userId);
                await SaveMulticoreSpecification(dsiAggregate, userId);
                await SavePinMapping(dsiAggregate, userId);
                await SaveWireMulticoreMarker(dsiAggregate, userId);
                await SaveWireSpecification(dsiAggregate, userId);
                await SaveWireThroughNode(dsiAggregate, userId);

             
           }
            catch (IOException ex)
            {
                _Logger.GenericLogError("Error saving DSI aggregate", ex);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                _Logger.GenericLogError("Error saving DSI aggregate", ex);
                throw;
            }
            // Optionally, catch other specific exceptions as needed
        }
        #region DsiSave
        async Task SaveBranchConfigurationAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiBendGrpcRequest bendRequest = new DsiBendGrpcRequest();
            DsiBranchConfigurationGrpcRequest branchConfigurationRequest = new DsiBranchConfigurationGrpcRequest();
            DsiBranchConfigurationBendAssociationGrpcRequest bendAssociationGrpcRequest = new DsiBranchConfigurationBendAssociationGrpcRequest();
            List<DsiBranchConfigurationBendAssociationGrpc> bendAssociations = new List<DsiBranchConfigurationBendAssociationGrpc>();

            // Handle bend
            if (dsiAggregate.BranchConfigurationList != null && dsiAggregate.BranchConfigurationList.Any())
            {
                
                foreach (BranchConfigurationDto branch in dsiAggregate.BranchConfigurationList)
                {
                    DsiBranchConfigurationGrpc branchGrpc = branch.ToBranchConfiguration();
                    if (!string.IsNullOrWhiteSpace(branch.CircuitOption))
                    {
                        DsiCircuitOptionGrpcRequest circuitOptionRequest = new DsiCircuitOptionGrpcRequest();
                        circuitOptionRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                        circuitOptionRequest.RfqGrpcRequestParameter.RequestType = 1;
                        ListDsiCircuitOptionGrpc circuitOptions = await _RfqClient.ReadDsiCircuitOptionGrpcAsync(circuitOptionRequest);

                        branchGrpc.CircuitOptionId = circuitOptions.DsiCircuitOptionGrpcs.FirstOrDefault(m => m.OptionName == branch.CircuitOption)?.CircuitOptionId;
                    }

                    branchConfigurationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                    branchConfigurationRequest.RfqGrpcRequestParameter.RequestType = 70;
                    branchGrpc.HarnessId = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId.ToString() : null;
                    branchGrpc.CreatedBy = userId;
                    branchConfigurationRequest.DsiBranchConfigurationGrpcsToCreate.Add(branchGrpc);

                    if (!string.IsNullOrEmpty(branch.Bend))
                    {
                        List<string> bendList = branch.Bend.Split(',').Select(x => x.Trim()).ToList();
                        foreach (string bend in bendList)
                        {
                            DsiBranchConfigurationBendAssociationGrpc dsiBranchConfigurationBendAssociation = new DsiBranchConfigurationBendAssociationGrpc();
                            DsiBendGrpc bendGrpc = new DsiBendGrpc();
                            bendGrpc.Bend = bend;
                            bendGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            bendGrpc.CreatedBy = userId;
                            bendRequest.DsiBendGrpcsToCreate.Add(bendGrpc);
                            dsiBranchConfigurationBendAssociation.BendId = bendGrpc.BendId;
                            dsiBranchConfigurationBendAssociation.BranchConfigurationId = branchGrpc.BranchConfigurationId;
                            dsiBranchConfigurationBendAssociation.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            dsiBranchConfigurationBendAssociation.CreatedBy = userId;
                            dsiBranchConfigurationBendAssociation.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            dsiBranchConfigurationBendAssociation.ModifiedBy = userId;
                            bendAssociations.Add(dsiBranchConfigurationBendAssociation);
                        }
                    }
                }

                DsiBranchConfigurationBendAssociationGrpc dsiBranchConfigurationBendAssociationGrpc = new DsiBranchConfigurationBendAssociationGrpc();
                bendAssociationGrpcRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                bendAssociationGrpcRequest.RfqGrpcRequestParameter.RequestType = 70;
                bendAssociationGrpcRequest.DsiBranchConfigurationBendAssociationGrpcsToCreate.AddRange(bendAssociations);
                bendRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                bendRequest.RfqGrpcRequestParameter.RequestType = 70;
                RfqCrudGrpcResponse bendReturn = await _RfqClient.CreateDsiBendGrpcAsync(bendRequest);
                RfqCrudGrpcResponse branchConfigurationReturn = _RfqClient.CreateDsiBranchConfigurationGrpc(branchConfigurationRequest);
                if(bendReturn == null || branchConfigurationReturn == null || bendReturn.SaveSuccess == false || branchConfigurationReturn.SaveSuccess == false)
                {
                    _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save bend or branch configuration");
                }
            }
        }
        async Task SaveBranchInsulationAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiBranchInsulationGrpcRequest branchInsulationRequest = new DsiBranchInsulationGrpcRequest();
            if (dsiAggregate.BranchInsulationList != null && dsiAggregate.BranchInsulationList.Any())
            {
                foreach (BranchInsulationDto branchInsulation in dsiAggregate.BranchInsulationList)
                {
                    branchInsulation.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiBranchInsulationGrpc branchInsulationGrpc = branchInsulation.ToBranchInsulation();
                    branchInsulationGrpc.CreatedBy = userId;
                    branchInsulationGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    branchInsulationGrpc.ModifiedBy = userId;
                    branchInsulationGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    branchInsulationGrpc.HarnessId = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId.ToString() : null;
                    branchInsulationRequest.DsiBranchInsulationGrpcsToCreate.Add(branchInsulationGrpc);
                }
            }

            branchInsulationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            branchInsulationRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiBranchInsulationGrpcAsync(branchInsulationRequest);
            if(clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save branch insulation");
            }
        }
        async Task SaveBranchInsulationThroughNodeAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiBranchInsulationThroughNodeGrpcRequest branchInsulationThroughNodeRequest = new DsiBranchInsulationThroughNodeGrpcRequest();
            if (dsiAggregate.BranchInsulationThroughNodeList != null && dsiAggregate.BranchInsulationThroughNodeList.Any())
            {
                foreach (BranchInsulationThroughNodeDto branchInsulationThroughNode in dsiAggregate.BranchInsulationThroughNodeList)
                {
                    DsiBranchInsulationThroughNodeGrpc branchInsulationThroughNodeGrpc = branchInsulationThroughNode.ToBranchInsulationThroughNode();
                    if (dsiAggregate.Harness != null)
                    {
                        branchInsulationThroughNodeGrpc.HarnessId = dsiAggregate.Harness.HarnessId.ToString();
                    }

                    branchInsulationThroughNodeGrpc.CreatedBy = userId;
                    branchInsulationThroughNodeGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    branchInsulationThroughNodeGrpc.ModifiedBy = userId;
                    branchInsulationThroughNodeGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    branchInsulationThroughNodeRequest.DsiBranchInsulationThroughNodeGrpcsToCreate.Add(branchInsulationThroughNodeGrpc);
                }
            }

            branchInsulationThroughNodeRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            branchInsulationThroughNodeRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiBranchInsulationThroughNodeGrpcAsync(branchInsulationThroughNodeRequest);
            if(clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save branch insulation through node");
            }
        }
        async Task SaveComponentAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiComponentGrpcRequest componentRequest = new DsiComponentGrpcRequest();
            if (dsiAggregate.ComponentList != null && dsiAggregate.ComponentList.Any())
            {
                foreach (ComponentDto component in dsiAggregate.ComponentList)
                {
                    component.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    component.CreatedBy = Guid.Parse(userId);
                    component.CreatedDate = DateTime.UtcNow;
                    component.ModifiedDate = DateTime.UtcNow;
                    component.ModifiedBy = Guid.Parse(userId);
                    DsiComponentGrpc componentGrpc = component.ToComponent();
                    componentRequest.DsiComponentGrpcsToCreate.Add(componentGrpc);
                }
            }

            componentRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            componentRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiComponentGrpcAsync(componentRequest);
            if(clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save components");
            }
        }
        async Task SaveCircuitOptionAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiCircuitOptionGrpcRequest request = new DsiCircuitOptionGrpcRequest();
            request.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            request.RfqGrpcRequestParameter.RequestType = 1;
            ListDsiCircuitOptionGrpc currentCircuitOptions = await _RfqClient.ReadDsiCircuitOptionGrpcAsync(request);

            // Build a HashSet of all existing option names for O(1) lookup
            HashSet<string> existingOptionNames = currentCircuitOptions.DsiCircuitOptionGrpcs
                .Where(o => !string.IsNullOrWhiteSpace(o.OptionName))
                .Select(o => o.OptionName)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            DsiCircuitOptionGrpcRequest circuitOptionGrpcRequest = new DsiCircuitOptionGrpcRequest();
            circuitOptionGrpcRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            circuitOptionGrpcRequest.RfqGrpcRequestParameter.RequestType = 70;

            if (dsiAggregate.CompositeDetailList != null && dsiAggregate.CompositeDetailList.Any())
            {
                foreach (CompositeDetailDto compositeDetail in dsiAggregate.CompositeDetailList)
                {
                    if (string.IsNullOrWhiteSpace(compositeDetail.CircuitOption))
                    {
                        continue;
                    }

                    string[] options = compositeDetail.CircuitOption.Split(',');
                    foreach (string option in options)
                    {
                        string trimmedOption = option.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedOption))
                        {
                            continue;
                        }

                        if (!existingOptionNames.Contains(trimmedOption))
                        {
                            DsiCircuitOptionGrpc newCircuitOption = new DsiCircuitOptionGrpc();
                            newCircuitOption.CircuitOptionId = Guid.NewGuid().ToString();
                            newCircuitOption.OptionName = trimmedOption;
                            newCircuitOption.CreatedBy = userId;
                            newCircuitOption.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            newCircuitOption.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            newCircuitOption.ModifiedBy = userId;
                            circuitOptionGrpcRequest.DsiCircuitOptionGrpcsToCreate.Add(newCircuitOption);

                            existingOptionNames.Add(trimmedOption);
                        }
                    }
                }
            }

            if (0 < circuitOptionGrpcRequest.DsiCircuitOptionGrpcsToCreate.Count)
            {
                RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiCircuitOptionGrpcAsync(circuitOptionGrpcRequest);
                if (clientReturn == null || clientReturn.SaveSuccess == false)
                {
                    _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save circuit options");
                }
            }
        }
        async Task SaveCompositeOptionAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiCompositeOptionGrpcRequest compositeOptionRequest = new DsiCompositeOptionGrpcRequest();
            if (dsiAggregate.CompositeOptionList != null && dsiAggregate.CompositeOptionList.Any())
            {
                foreach (CompositeOptionDto compositeOption in dsiAggregate.CompositeOptionList)
                {
                    compositeOption.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    compositeOption.CompositeOptionId = Guid.NewGuid();
                    DsiCompositeOptionGrpc compositeOptionGrpc = compositeOption.ToCompositeOption();
                    compositeOptionGrpc.CreatedBy = userId;
                    compositeOptionGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    compositeOptionGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    compositeOptionGrpc.ModifiedBy = userId;
                    compositeOptionRequest.DsiCompositeOptionGrpcsToCreate.Add(compositeOptionGrpc);
                }
            }

            compositeOptionRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            compositeOptionRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiCompositeOptionGrpcAsync(compositeOptionRequest);
            if(clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save composite options");
            }
        }
        async Task SaveCompositeDetailsAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiCircuitOptionGrpcRequest request = new DsiCircuitOptionGrpcRequest();
            request.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            request.RfqGrpcRequestParameter.RequestType = 1;
            ListDsiCircuitOptionGrpc currentCircuitOptions = await _RfqClient.ReadDsiCircuitOptionGrpcAsync(request);

            DsiCompositeDetailGrpcRequest compositeDetailGrpcRequest = new DsiCompositeDetailGrpcRequest();
            compositeDetailGrpcRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            compositeDetailGrpcRequest.RfqGrpcRequestParameter.RequestType = 70;

            DsiCompositeDetailCircuitOptionAssociationGrpcRequest compositeDetailCircuitOptionAssociationRequest = new DsiCompositeDetailCircuitOptionAssociationGrpcRequest();
            compositeDetailCircuitOptionAssociationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            compositeDetailCircuitOptionAssociationRequest.RfqGrpcRequestParameter.RequestType = 70;

            if (dsiAggregate.CompositeDetailList != null && dsiAggregate.CompositeDetailList.Any())
            {
                foreach (CompositeDetailDto compositeDetail in dsiAggregate.CompositeDetailList)
                {
                    compositeDetail.HarnessId = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiCompositeDetailGrpc compositeDetailGrpc = compositeDetail.ToCompositeDetail();
                    compositeDetailGrpc.CompositeDetailId = Guid.NewGuid().ToString();
                    compositeDetailGrpc.CreatedBy = userId;
                    compositeDetailGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    compositeDetailGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    compositeDetailGrpc.ModifiedBy = userId;
                    if (compositeDetail.CircuitOption != null)
                    {
                        DsiCompositeDetailCircuitOptionAssociationGrpc dsiCompositeDetailCircuitOptionAssociationGrpc = new DsiCompositeDetailCircuitOptionAssociationGrpc();
                        string[] options = compositeDetail.CircuitOption.Split(',');
                        foreach(string option in options)
                        {
                            DsiCircuitOptionGrpc? existingOption = currentCircuitOptions.DsiCircuitOptionGrpcs.Where(x => x.OptionName == option).FirstOrDefault();
                            if (existingOption == null)
                            {
                                continue;
                            }

                            dsiCompositeDetailCircuitOptionAssociationGrpc.CircuitOptionId = existingOption.CircuitOptionId;
                            dsiCompositeDetailCircuitOptionAssociationGrpc.CompositeDetailId = compositeDetailGrpc.CompositeDetailId;
                            dsiCompositeDetailCircuitOptionAssociationGrpc.CreatedBy = userId;
                            dsiCompositeDetailCircuitOptionAssociationGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            compositeDetailCircuitOptionAssociationRequest.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate.Add(dsiCompositeDetailCircuitOptionAssociationGrpc);
                        }
                    }

                    compositeDetailGrpcRequest.DsiCompositeDetailGrpcsToCreate.Add(compositeDetailGrpc);
                }

                RfqCrudGrpcResponse compositeDetailResponse = await _RfqClient.CreateDsiCompositeDetailGrpcAsync(compositeDetailGrpcRequest);
                RfqCrudGrpcResponse associationResponse = await _RfqClient.CreateDsiCompositeDetailCircuitOptionAssociationGrpcAsync(compositeDetailCircuitOptionAssociationRequest);

                if (compositeDetailResponse == null || compositeDetailResponse.SaveSuccess == false || associationResponse == null || associationResponse.SaveSuccess == false)
                {
                    _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save compositeDetail or compositeDetailOptionAssociation");
                }
            }

            DsiCompositeDetailGrpc generatedCompositeDetailGrpc = GenerateCompositeDetailGrpc();

            generatedCompositeDetailGrpc.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId.ToString() : null;
            generatedCompositeDetailGrpc.HarnessName1 = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessName1 : null;
            generatedCompositeDetailGrpc.CompositeDetailId = Guid.NewGuid().ToString();
            generatedCompositeDetailGrpc.CreatedBy = userId;
            generatedCompositeDetailGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            generatedCompositeDetailGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            generatedCompositeDetailGrpc.ModifiedBy = userId;
            compositeDetailGrpcRequest.DsiCompositeDetailGrpcsToCreate.Add(generatedCompositeDetailGrpc);
            RfqCrudGrpcResponse generatedCompositeDetailResponse = await _RfqClient.CreateDsiCompositeDetailGrpcAsync(compositeDetailGrpcRequest);
        }
        async Task<DsiHarnessGrpc> SaveHarness(DsiAggregate dsiAggregate, string userId)
        {
            DsiHarnessGrpcRequest harnessRequest = new DsiHarnessGrpcRequest();
            harnessRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            harnessRequest.RfqGrpcRequestParameter.RequestType = 1;
            ListDsiHarnessGrpc allHarnesses = await _RfqClient.ReadDsiHarnessGrpcAsync(harnessRequest);
            if(dsiAggregate.Harness != null)
            {
                DsiHarnessGrpc? existingHarness = allHarnesses.DsiHarnessGrpcs.Where(x => x.HarnessName1 == dsiAggregate.Harness.HarnessName1).FirstOrDefault();
                if (existingHarness != null)
                {
                    dsiAggregate.Harness.HarnessId = Guid.Parse(existingHarness.HarnessId);
                    return existingHarness;
                }
            }

            harnessRequest.RfqGrpcRequestParameter.RequestType = 70;
            if (dsiAggregate.Harness != null)
            {
                dsiAggregate.Harness.HarnessId = Guid.NewGuid();
                DsiHarnessGrpc harnessGrpc = dsiAggregate.Harness.ToHarness();
                harnessGrpc.CreatedBy = userId;
                harnessGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                harnessGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                harnessGrpc.ModifiedBy = userId;
                harnessRequest.DsiHarnessGrpcsToCreate.Add(harnessGrpc);
            }

            RfqCrudGrpcResponse response = await _RfqClient.CreateDsiHarnessGrpcAsync(harnessRequest);
            if (response == null || response.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save harness");
            }

            return harnessRequest.DsiHarnessGrpcsToCreate.FirstOrDefault() ?? new DsiHarnessGrpc();
        }
        async Task SaveScopeAsync(DsiAggregate dsiAggregate, string userId)
        {
            DsiScopeGrpcRequest request = new DsiScopeGrpcRequest();
            request.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            request.RfqGrpcRequestParameter.RequestType = 1;
            ListDsiScopeGrpc currentScopes = await _RfqClient.ReadDsiScopeGrpcAsync(request);

            HashSet<string> existingOptionNames = currentScopes.DsiScopeGrpcs
                .Where(o => !string.IsNullOrWhiteSpace(o.Scope))
                .Select(o => o.Scope)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            DsiScopeGrpcRequest scopeGrpcRequest = new DsiScopeGrpcRequest();
            scopeGrpcRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            scopeGrpcRequest.RfqGrpcRequestParameter.RequestType = 70;

            if (dsiAggregate.HarnessScopeList != null && dsiAggregate.HarnessScopeList.Any())
            {
                foreach (HarnessScopeDto harnessScope in dsiAggregate.HarnessScopeList)
                {
                    if (string.IsNullOrWhiteSpace(harnessScope.Scope))
                    {
                        continue;
                    }

                    string[] scopes = harnessScope.Scope.Split(',');
                    foreach (string scope in scopes)
                    {
                        string trimmedOption = scope.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedOption))
                        {
                            continue;
                        }

                        // Only add if this option does NOT already exist in the current list
                        if (!existingOptionNames.Contains(trimmedOption))
                        {
                            DsiScopeGrpc newScope = new DsiScopeGrpc();
                            newScope.Scope = trimmedOption;
                            newScope.CreatedBy = userId;
                            newScope.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            newScope.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                            newScope.ModifiedBy = userId;
                            scopeGrpcRequest.DsiScopeGrpcsToCreate.Add(newScope);

                            // Track it so we don't add duplicates within this same batch
                            existingOptionNames.Add(trimmedOption);
                        }
                    }
                }

                if (0 < scopeGrpcRequest.DsiScopeGrpcsToCreate.Count)
                {
                    RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiScopeGrpcAsync(scopeGrpcRequest);
                    if (clientReturn == null || clientReturn.SaveSuccess == false)
                    {
                        _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save scope");
                    }
                }
            }
        }
        async Task SaveHarnessScope(DsiAggregate dsiAggregate, string userId)
        {
            DsiScopeGrpcRequest request = new DsiScopeGrpcRequest();
            request.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            request.RfqGrpcRequestParameter.RequestType = 1;
            ListDsiScopeGrpc currentScopes = await _RfqClient.ReadDsiScopeGrpcAsync(request);

            DsiHarnessScopeGrpcRequest harnessScopeRequest = new DsiHarnessScopeGrpcRequest();
            harnessScopeRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            harnessScopeRequest.RfqGrpcRequestParameter.RequestType = 70;

            DsiHarnessScopeScopeAssociationGrpcRequest harnessScopeAssociationRequest = new DsiHarnessScopeScopeAssociationGrpcRequest();
            harnessScopeAssociationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            harnessScopeAssociationRequest.RfqGrpcRequestParameter.RequestType = 70;
            if (dsiAggregate.HarnessScopeList != null && dsiAggregate.HarnessScopeList.Any())
            {

                foreach (HarnessScopeDto harnessScope in dsiAggregate.HarnessScopeList)
                {
                    DsiHarnessScopeGrpc harnessScopeGrpc = harnessScope.ToHarnessScope();
                    if (dsiAggregate.Harness != null)
                    {
                        harnessScopeGrpc.HarnessScopeId = dsiAggregate.Harness.HarnessId.ToString();
                    }

                    if (harnessScope.Scope != null)
                    {
                        DsiHarnessScopeScopeAssociationGrpc dsiHarnessScopeScopeAssociationGrpc = new DsiHarnessScopeScopeAssociationGrpc();
                        string[] scopes = harnessScope.Scope.Split(',');
                        foreach (string scope in scopes)
                        {
                            DsiScopeGrpc? existingScope = currentScopes.DsiScopeGrpcs.Where(x => x.Scope == scope).FirstOrDefault();
                            if (existingScope == null)
                            {
                                continue;
                            }

                            dsiHarnessScopeScopeAssociationGrpc.ScopeID = existingScope.RowId.ToString(CultureInfo.InvariantCulture);
                            dsiHarnessScopeScopeAssociationGrpc.HarnessScopeID = harnessScopeGrpc.HarnessScopeId;
                            harnessScopeAssociationRequest.DsiHarnessScopeScopeAssociationGrpcsToCreate.Add(dsiHarnessScopeScopeAssociationGrpc);
                        }
                    }

                    harnessScopeGrpc.CreatedBy = userId;
                    harnessScopeGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    harnessScopeRequest.DsiHarnessScopeGrpcsToCreate.Add(harnessScopeGrpc);
                }
            }

            RfqCrudGrpcResponse harnessScopeResponse = await _RfqClient.CreateDsiHarnessScopeGrpcAsync(harnessScopeRequest);
            if(harnessScopeResponse == null || harnessScopeResponse.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save harness scope");
            }

            RfqCrudGrpcResponse associationResponse = await _RfqClient.CreateDsiHarnessScopeScopeAssociationGrpcAsync(harnessScopeAssociationRequest);
            if(associationResponse == null || associationResponse.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save harness scope association");
            }
        }
        async Task SaveManualBomQuantity(DsiAggregate dsiAggregate, string userId)
        {
            DsiManualBomQuantityGrpcRequest manualBomQuantityGrpcRequest = new DsiManualBomQuantityGrpcRequest();
            if (dsiAggregate.ManualBomQuantityList != null && dsiAggregate.ManualBomQuantityList.Any())
            {
                foreach (ManualBomQuantityDto bomQuantityDto in dsiAggregate.ManualBomQuantityList)
                {
                    bomQuantityDto.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiManualBomQuantityGrpc manualBomQuantityGrpc = bomQuantityDto.ToManualBomQuantity();
                    manualBomQuantityGrpc.CreatedBy = userId;
                    manualBomQuantityGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    manualBomQuantityGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    manualBomQuantityGrpc.ModifiedBy = userId;
                    manualBomQuantityGrpcRequest.DsiManualBomQuantityGrpcsToCreate.Add(manualBomQuantityGrpc);
                }
            }

            manualBomQuantityGrpcRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            manualBomQuantityGrpcRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiManualBomQuantityGrpcAsync(manualBomQuantityGrpcRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save manualBomQuantity");
            }
        }
        async Task SaveMidWireComponent(DsiAggregate dsiAggregate, string userId)
        {
            DsiMidWireComponentGrpcRequest midWireComponentRequest = new DsiMidWireComponentGrpcRequest();
            if (dsiAggregate.MidWireComponentList != null && dsiAggregate.MidWireComponentList.Any())
            {
                foreach (MidWireComponentDto midWireComponent in dsiAggregate.MidWireComponentList)
                {
                    midWireComponent.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiMidWireComponentGrpc midWireComponentGrpc = midWireComponent.ToMidWireComponent();
                    midWireComponentGrpc.CreatedBy = userId;
                    midWireComponentGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    midWireComponentRequest.DsiMidWireComponentGrpcsToCreate.Add(midWireComponentGrpc);
                }
            }

            midWireComponentRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            midWireComponentRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiMidWireComponentGrpcAsync(midWireComponentRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save mid wire component");
            }
        }   
        async Task SaveModuleChildDetail(DsiAggregate dsiAggregate, string userId)
        {
            DsiModuleChildDetailGrpcRequest moduleChildDetailRequest = new DsiModuleChildDetailGrpcRequest();
            if (dsiAggregate.ModuleChildDetailList != null && dsiAggregate.ModuleChildDetailList.Any())
            {
                foreach (ModuleChildDetailDto moduleChildDetail in dsiAggregate.ModuleChildDetailList)
                {
                    moduleChildDetail.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiModuleChildDetailGrpc moduleChildDetailGrpc = moduleChildDetail.ToModuleChildDetail();
                    moduleChildDetailGrpc.CreatedBy = userId;
                    moduleChildDetailGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    moduleChildDetailGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    moduleChildDetailGrpc.ModifiedBy = userId;
                    moduleChildDetailRequest.DsiModuleChildDetailGrpcsToCreate.Add(moduleChildDetailGrpc);
                }
            }

            moduleChildDetailRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            moduleChildDetailRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiModuleChildDetailGrpcAsync(moduleChildDetailRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save module child detail");
            }
        }
        async Task SaveModuleCompatibility(DsiAggregate dsiAggregate, string userId)
        {
            DsiModuleCompatibilityGrpcRequest moduleCompatibilityRequest = new DsiModuleCompatibilityGrpcRequest();
            if (dsiAggregate.ModuleCompatibilityList != null && dsiAggregate.ModuleCompatibilityList.Any())
            {
                foreach (ModuleCompatibilityDto moduleCompatibility in dsiAggregate.ModuleCompatibilityList)
                {
                    moduleCompatibility.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiModuleCompatibilityGrpc moduleCompatibilityGrpc = moduleCompatibility.ToModuleCompatibility();
                    moduleCompatibilityGrpc.CreatedBy = userId;
                    moduleCompatibilityGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    moduleCompatibilityGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    moduleCompatibilityGrpc.ModifiedBy = userId;
                    moduleCompatibilityRequest.DsiModuleCompatibilityGrpcsToCreate.Add(moduleCompatibilityGrpc);
                }
            }

            moduleCompatibilityRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            moduleCompatibilityRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiModuleCompatibilityGrpcAsync(moduleCompatibilityRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save module compatibility");
            }
        }
        async Task SaveMulticoreSpecification(DsiAggregate dsiAggregate, string userId)
        {
            DsiMulticoreSpecificationGrpcRequest multicoreSpecificationRequest = new DsiMulticoreSpecificationGrpcRequest();
            if (dsiAggregate.MulticoreSpecificationList != null && dsiAggregate.MulticoreSpecificationList.Any())
            {
                foreach (MulticoreSpecificationDto multicoreSpecification in dsiAggregate.MulticoreSpecificationList)
                {
                    multicoreSpecification.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiMulticoreSpecificationGrpc multicoreSpecificationGrpc = multicoreSpecification.ToMulticoreSpecification();
                    multicoreSpecificationGrpc.CreatedBy = userId;
                    multicoreSpecificationGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    multicoreSpecificationGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    multicoreSpecificationGrpc.ModifiedBy = userId;
                    multicoreSpecificationRequest.DsiMulticoreSpecificationGrpcsToCreate.Add(multicoreSpecificationGrpc);
                }
            }

            multicoreSpecificationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            multicoreSpecificationRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiMulticoreSpecificationGrpcAsync(multicoreSpecificationRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save multicore specification");
            }
        }
        async Task SavePinMapping(DsiAggregate dsiAggregate, string userId)
        {
            DsiPinMappingGrpcRequest pinMappingRequest = new DsiPinMappingGrpcRequest();
            if (dsiAggregate.PinMappingList != null && dsiAggregate.PinMappingList.Any())
            {
                foreach (PinMappingDto pinMapping in dsiAggregate.PinMappingList)
                {
                    pinMapping.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiPinMappingGrpc pinMappingGrpc = pinMapping.ToPinMapping();
                    pinMappingGrpc.CreatedBy = userId;
                    pinMappingGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    pinMappingGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    pinMappingGrpc.ModifiedBy = userId;
                    pinMappingRequest.DsiPinMappingGrpcsToCreate.Add(pinMappingGrpc);
                }
            }

            pinMappingRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            pinMappingRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiPinMappingGrpcAsync(pinMappingRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save pin mapping");
            }
        }
        async Task SaveWireMulticoreMarker(DsiAggregate dsiAggregate, string userId)
        {
            DsiWireMulticoreMarkerGrpcRequest wireMulticoreMarkerRequest = new DsiWireMulticoreMarkerGrpcRequest();
            if (dsiAggregate.WireMulticoreMarkerList != null && dsiAggregate.WireMulticoreMarkerList.Any())
            {
                foreach (WireMulticoreMarkerDto wireMulticoreMarker in dsiAggregate.WireMulticoreMarkerList)
                {
                    wireMulticoreMarker.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiWireMulticoreMarkerGrpc wireMulticoreMarkerGrpc = wireMulticoreMarker.ToWireMulticoreMarker();
                    wireMulticoreMarkerGrpc.CreatedBy = userId;
                    wireMulticoreMarkerGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireMulticoreMarkerGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireMulticoreMarkerGrpc.ModifiedBy = userId;
                    wireMulticoreMarkerRequest.DsiWireMulticoreMarkerGrpcsToCreate.Add(wireMulticoreMarkerGrpc);
                }
            }

            wireMulticoreMarkerRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            wireMulticoreMarkerRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiWireMulticoreMarkerGrpcAsync(wireMulticoreMarkerRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save wire multicore marker");
            }
        }
        async Task SaveWireSpecification(DsiAggregate dsiAggregate, string userId)
        {
            DsiWireSpecificationGrpcRequest wireSpecificationRequest = new DsiWireSpecificationGrpcRequest();
            if (dsiAggregate.WireSpecificationList != null && dsiAggregate.WireSpecificationList.Any())
            {
                foreach (WireSpecificationDto wireSpecification in dsiAggregate.WireSpecificationList)
                {
                    wireSpecification.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiWireSpecificationGrpc wireSpecificationGrpc = wireSpecification.ToWireSpecification();
                    wireSpecificationGrpc.CreatedBy = userId;
                    wireSpecificationGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireSpecificationGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireSpecificationGrpc.ModifiedBy = userId;
                    wireSpecificationRequest.DsiWireSpecificationGrpcsToCreate.Add(wireSpecificationGrpc);
                }
            }

            wireSpecificationRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            wireSpecificationRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiWireSpecificationGrpcAsync(wireSpecificationRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save wire specification");
            }
        }
        async Task SaveWireThroughNode(DsiAggregate dsiAggregate, string userId)
        {
            DsiWireThroughNodeGrpcRequest dsiWireThroughNodeRequest = new DsiWireThroughNodeGrpcRequest();
            if (dsiAggregate.WireThroughNodeList != null && dsiAggregate.WireThroughNodeList.Any())
            {
                foreach(WireThroughNodeDto wireThroughNode in dsiAggregate.WireThroughNodeList)
                {
                    wireThroughNode.HarnessID = dsiAggregate.Harness != null ? dsiAggregate.Harness.HarnessId : null;
                    DsiWireThroughNodeGrpc wireThroughNodeGrpc = wireThroughNode.ToWireThroughNode();
                    wireThroughNodeGrpc.CreatedBy = userId;
                    wireThroughNodeGrpc.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireThroughNodeGrpc.ModifiedDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                    wireThroughNodeGrpc.ModifiedBy = userId;
                    dsiWireThroughNodeRequest.DsiWireThroughNodeGrpcsToCreate.Add(wireThroughNodeGrpc);
                }
            }

            dsiWireThroughNodeRequest.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            dsiWireThroughNodeRequest.RfqGrpcRequestParameter.RequestType = 70;
            RfqCrudGrpcResponse clientReturn = await _RfqClient.CreateDsiWireThroughNodeGrpcAsync(dsiWireThroughNodeRequest);
            if (clientReturn == null || clientReturn.SaveSuccess == false)
            {
                _Logger.GenericLogInformation("Error saving DSI aggregate - failed to save wire through node");
            }
        }
        #endregion
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

            EmacsFilterRequestGrpc emacsFilterRequest = new EmacsFilterRequestGrpc();
            emacsFilterRequest.DatabaseList = "AlternativePartsGrpc";
            emacsFilterRequest.FilterExpression = $"SumitomoNumber != null && SumitomoNumber == \"{sumitomoNumber}\"";
            EmacsFilterResponseGrpc alternativeParts = _EmacsClient.FilterEmacsDataGrpc(emacsFilterRequest);
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
                    ListAlternativePartsGrpc accessResponse = await _EmacsClient.GetAlternativePartsGrpcAsync(requestAll, callOptions);
                    //2026 - 01 - 26T10: 32:06 info: Grpc.Net.Client.Internal.GrpcCall[17]
                    //2026 - 01 - 26T10: 32:06 Error reading message.
                    //2026 - 01 - 26T10: 32:06 System.Net.Http.HttpIOException: The response ended prematurely, with at least 4105 additional bytes expected. (ResponseEnded)

                    ListAlternativePartsGrpc partsList = accessResponse ?? new ListAlternativePartsGrpc();

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
                            // TODO Search RFQ
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
            Collection<RfqShared.RfqNprRequestGrpc> filteredList = new Collection<RfqShared.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"RfqNumber != null && RfqNumber == \"{request.RfqNumber}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<RfqShared.RfqNprRequestGrpc>(rfqNprRequests);
                response.RfqNprRequestGrpcs.AddRange(filteredList);
                //foreach(RfqShared.RfqNprRequestGrpc accessItem in filteredList)
                //{
                //    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                //    response.RfqNprRequestGrpcs.Add(item);
                //}
            }

            return response;
        }
        public async Task<GetRfqNprRequestByRfqProjectIdGrpcResponse> GetRfqNprRequestByRfqProjectIdGrpc(GetRfqNprRequestByRfqProjectIdGrpcRequest request)
        {
            await Task.Delay(1);
            GetRfqNprRequestByRfqProjectIdGrpcResponse response = new GetRfqNprRequestByRfqProjectIdGrpcResponse();
            Collection<RfqShared.RfqNprRequestGrpc> filteredList = new Collection<RfqShared.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"Project != null && Project == \"{request.RfqProjectId}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<RfqShared.RfqNprRequestGrpc>(rfqNprRequests);
                response.RfqNprRequestGrpcs.AddRange(filteredList);
                //foreach (RfqNprRequestGrpc accessItem in filteredList)
                //{
                //    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                //    response.RfqNprRequestGrpcs.Add(item);
                //}
            }

            return response;
        }
        public async Task<GetRfqNprRequestByIdGrpcResponse> GetRfqNprRequestByIdGrpc(GetRfqNprRequestByIdGrpcRequest request)
        {
            await Task.Delay(1);
            GetRfqNprRequestByIdGrpcResponse response = new GetRfqNprRequestByIdGrpcResponse();
            Collection<RfqShared.RfqNprRequestGrpc> filteredList = new Collection<RfqShared.RfqNprRequestGrpc>();

            RfqFilterRequest rfqFilterRequestGrpc = new RfqFilterRequest();
            rfqFilterRequestGrpc.DatabaseList = "RfqNprRequestGrpc";
            rfqFilterRequestGrpc.FilterExpression = $"Id != null && Id.ToUpperInvariant() == \"{request.Id.ToUpperInvariant()}\"";
            RfqFilterResponse rfqNprRequests = await _RfqClient.FilterRfqGrpcAsync(rfqFilterRequestGrpc);
            if (rfqNprRequests.ListRfqNprRequestGrpc != null)
            {
                filteredList = ExtractRFQResponseData<RfqShared.RfqNprRequestGrpc>(rfqNprRequests);
                response.RfqNprRequestGrpcs.AddRange(filteredList);
                //foreach (RfqNprRequestGrpc accessItem in filteredList)
                //{
                //    RfqNprRequestGrpc item = accessItem.ToRfqNprRequest();
                //    response.RfqNprRequestGrpcs.Add(item);
                //}
            }

            return response;
        }

        public async Task<GetAllRfqNprRequestGrpcResponse> GetAllRfqNprRequestGrpc(GetAllRfqNprRequestGrpcRequest request)
        {
            await Task.Delay(1);
            GetAllRfqNprRequestGrpcResponse response = new GetAllRfqNprRequestGrpcResponse();
            Collection<RfqShared.RfqNprRequestGrpc> filteredList = new Collection<RfqShared.RfqNprRequestGrpc>();

            RfqNprRequestGrpcRequest rfqRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.Position = request.Position;
            rfqGrpcRequestParameter.Take = request.Take;
            rfqGrpcRequestParameter.RequestType = 1;
            rfqRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
            ListRfqNprRequestGrpc rfqNprRequests = _RfqClient.ReadRfqNprRequestGrpc(rfqRequest);
            response.RfqNprRequestGrpcs.AddRange(rfqNprRequests.RfqNprRequestGrpcs);
            //foreach (RfqNprRequestGrpc? item in rfqNprRequests.RfqNprRequestGrpcs)
            //{
            //    RfqNprRequestGrpc rfqNpr = item.ToRfqNprRequest();

            //    response.RfqNprRequestGrpcs.Add(rfqNpr);
            //}

            return response;
        }

        public async Task<CreateRfqNprRequestGrpcResponse> CreateRfqNprRequestGrpc(CreateRfqNprRequestGrpcRequest request)
        {
            await Task.Delay(0);
            CreateRfqNprRequestGrpcResponse response = new CreateRfqNprRequestGrpcResponse();
            RfqNprRequestGrpcRequest rfqNprRequest = new RfqNprRequestGrpcRequest();
            RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
            rfqGrpcRequestParameter.RequestType = 70;
            rfqNprRequest.RfqNprRequestGrpcsToCreate.AddRange(request.RfqNprRequestGrpc);
            //foreach (RfqShared.RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            //{
            //    RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
            //    rfqNprRequest.RfqNprRequestGrpcsToCreate.Add(accessRfqNprRequest);
            //}

            rfqNprRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter; // new RfqGrpcRequestParameter();
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
        //    rfqNprRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
        //    rfqNprRequest.RfqNprRequestGrpcsToUpdate.AddRange(request.RfqNprRequestGrpc);
        //    //foreach (RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
        //    //{
        //    //    RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
        //    //    rfqNprRequest.RfqNprRequestGrpcsToUpdate.Add(accessRfqNprRequest);
        //    //}

        //    RfqCrudResponse accessResponse = _RfqClient.UpdateRfqNprRequestGrpc(rfqNprRequest);

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
            rfqNprRequest.RfqNprRequestGrpcsToUpdate.AddRange(request.RfqNprRequestGrpc);
            //foreach (RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            //{
            //    RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
            //    rfqNprRequest.RfqNprRequestGrpcsToUpdate.Add(accessRfqNprRequest);
            //}

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
            foreach (RfqShared.RfqNprRequestGrpc? npr in allRfqNprRequests.RfqNprRequestGrpcs)
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
                    RfqShared.RfqNprRequestGrpc accessRfqNprRequest = npr; //.ToRfqNprRequestGrpcAccess();

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
            rfqNprRequest.RfqNprRequestGrpcsToDelete.AddRange(request.RfqNprRequestGrpc);
            //foreach(RfqNprRequestGrpc? rfqNpr in request.RfqNprRequestGrpc)
            //{
            //    RfqNprRequestGrpc accessRfqNprRequest = rfqNpr.ToRfqNprRequestGrpcAccess();
            //    rfqNprRequest.RfqNprRequestGrpcsToDelete.Add(accessRfqNprRequest);
            //}

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
                accessRequest.Items.AddRange(request.Items);
                //foreach (RfqNprRequestGrpc? mgrItem in request.Items)
                //{
                //    RfqNprRequestGrpc accessItem = mgrItem.ToRfqNprRequestGrpcAccess();
                //    accessRequest.Items.Add(accessItem);
                //}
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
                        foreach (Rfq.ValidationError err in accessLine.Errors)
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
        public async Task<CreateNprGrpcResponse> CreateNprGrpc (CreateNprGrpcRequest request) // this comes from the client and contains a RfqShared.RfqNprRequestGrpc for each line to be submitted to NPR API
        {
            await Task.Delay(0);
            CreateNprGrpcResponse response = new CreateNprGrpcResponse();
            // ValidateNprRequestRequest validateRequest = new ValidateNprRequestRequest();
            List<NPR.NprApiDataGrpc> nprAccessDataList = new List<NPR.NprApiDataGrpc>();
            List<RfqShared.RfqNprRequestGrpc> rfqNprRequestList = new List<RfqShared.RfqNprRequestGrpc>();

            //Validate the incoming request first
            for(int i = 0; i < request.NprApiData.Count; i++)
            {
                RfqShared.RfqNprRequestGrpc rfqNprRequest = request.NprApiData[i].RfqNprRequest; //.ToRfqNprRequestGrpcAccess(i);
                rfqNprRequestList.Add(rfqNprRequest);
                // validateRequest.Items.Add(rfqNprRequest);
            }

            // ValidateNprRequestResponse validateResponse = await _RfqClient.ValidateNprRequestGrpcAsync(validateRequest);
            // List<RfqNprRequestGrpc> validRequests = validateRequest.Items.Where(item => item.Id != null && validateResponse.LineStatuses.Any(line => line.Id == item.Id && line.IsValid)).ToList();  
            // send all requests to create RfqNprRequests replacing with the ones from NPR API for the valid requests to capture any additional data from NPR API and to update the status of the RfqNprRequest
            NprApiDataGrpc nprApiDataGrpc = new NprApiDataGrpc();

            foreach (RfqShared.RfqNprRequestGrpc validRequest in rfqNprRequestList) //validRequests)
            {
                nprApiDataGrpc.RfqNprRequest = validRequest; //.ToRfqNprRequest();
                NPR.NprApiDataGrpc nprAccessData = nprApiDataGrpc.ToNprApiAccessData();
                nprAccessDataList.Add(nprAccessData);
            }

            CreateNprApiGrpcRequest createNprApiGrpcRequest = new CreateNprApiGrpcRequest();
            createNprApiGrpcRequest.NprApiData.AddRange(nprAccessDataList);
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
            Collection<RfqDrawingPartNumberGrpc> filteredList = new Collection<RfqDrawingPartNumberGrpc>();
            RfqFilterResponse rfqResponse = FilterSumitomoNumber<RfqFilterResponse>(request.StringValue, "SumitomoPartNumber", "==");
            filteredList = ExtractRFQResponseData<RfqDrawingPartNumberGrpc>(rfqResponse);
            response.Success = true;
            foreach (RfqDrawingPartNumberGrpc part in filteredList)
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

                RfqFilterRequest filterRequest = new RfqFilterRequest();
                filterRequest.DatabaseList = "DSIHARNESSGRPC";
                filterRequest.FilterExpression = "1 == 1";

                RfqFilterResponse filterResponse =
                    await _RfqClient.FilterRfqGrpcAsync(filterRequest);

                ListDsiHarnessGrpc harnessList =
                    filterResponse.ListDsiHarnessGrpc ?? new ListDsiHarnessGrpc();

                GetAllHarnessModuleResponse response =
                    new GetAllHarnessModuleResponse();

                foreach (DsiHarnessGrpc? item in harnessList.DsiHarnessGrpcs)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    HarnessGrpc harness = new HarnessGrpc();

                    harness.Id = item.HarnessId;
                    harness.HarnessName1 = item.HarnessName1;
                    harness.Customer = item.Customer;
                    harness.Site = item.Site;

                    DSIHarnessGrpc? dsiHarness = harness.ToDSIHarness();
                    response.HarnessList.Add(dsiHarness);
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
        public async Task<GetHarnessByIdGrpcResponse> GetHarnessByIdGrpc(GetHarnessByIdGrpcRequest request)
        {
            try
            {
                await Task.Delay(1);

                RfqFilterRequest filterRequest = new RfqFilterRequest();
                filterRequest.DatabaseList = "DSIHARNESSGRPC";
                filterRequest.FilterExpression = $"HarnessId == \"{request.Id}\"";

                RfqFilterResponse filterResponse =
                           await _RfqClient.FilterRfqGrpcAsync(filterRequest);

                ListDsiHarnessGrpc harnessList =
                    filterResponse.ListDsiHarnessGrpc ?? new ListDsiHarnessGrpc();

                GetHarnessByIdGrpcResponse response =
                    new GetHarnessByIdGrpcResponse();

                DsiHarnessGrpc? item = harnessList.DsiHarnessGrpcs.FirstOrDefault();

                if (item != null)
                {
                    HarnessGrpc harness = new HarnessGrpc();

                    harness.Id = item.HarnessId;
                    harness.HarnessName1 = item.HarnessName1;
                    harness.Customer = item.Customer;
                    harness.Site = item.Site;

                    response.Harness = harness.ToDSIHarness();
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching Harness by ID from DSI", ex);
                throw;
            }
        }
        public async Task<GetCompositeDetailByHarnessResponse> GetCompositeDetailByHarnessGrpc(GetCompositeDetailByHarnessRequest request)
        {
            _ = request;
            try
            {
                await Task.Delay(1);
                RfqFilterRequest filterRequest = new RfqFilterRequest();
                filterRequest.DatabaseList = "DSICOMPOSITEDETAILGRPC";
                filterRequest.FilterExpression =
                    $"HarnessID == \"{request.HarnessId}\"";

                RfqFilterResponse filterResponse =
                    await _RfqClient.FilterRfqGrpcAsync(filterRequest);

                ListDsiCompositeDetailGrpc compositeDetailList =
                    filterResponse.ListDsiCompositeDetailGrpc ?? new ListDsiCompositeDetailGrpc();

                GetCompositeDetailByHarnessResponse response =
                    new GetCompositeDetailByHarnessResponse();

                foreach (DsiCompositeDetailGrpc? item in compositeDetailList.DsiCompositeDetailGrpcs)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    CompositeDetailGrpc compositeDetail =
                        new CompositeDetailGrpc();

                    compositeDetail.Id = item.RowId;

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

                    DSICompositeDetailGrpc? dsiCompositeDetail = compositeDetail.ToDSICompositeDetail();
                    response.CompositeDetails.Add(dsiCompositeDetail);
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

                RfqFilterRequest filterRequest = new RfqFilterRequest();
                filterRequest.DatabaseList = "DSICOMPOSITEDETAILGRPC";
                filterRequest.FilterExpression =
                filterRequest.FilterExpression =
                    $"HarnessID == \"{request.HarnessId}\" && HarnessName1 == \"{request.HarnessName1}\"";
                RfqFilterResponse filterResponse =
                       await _RfqClient.FilterRfqGrpcAsync(filterRequest);

                ListDsiCompositeDetailGrpc compositeDetailList =
               filterResponse.ListDsiCompositeDetailGrpc ?? new ListDsiCompositeDetailGrpc();

                GetCompositeDetailByHarnessNameResponse response =
                    new GetCompositeDetailByHarnessNameResponse();

                foreach (DsiCompositeDetailGrpc? item in compositeDetailList.DsiCompositeDetailGrpcs)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    CompositeDetailGrpc compositeDetail =
                        new CompositeDetailGrpc();

                    compositeDetail.Id = item.RowId;

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

                    DSICompositeDetailGrpc? dsiCompositeDetail = compositeDetail.ToDSICompositeDetail();
                    response.CompositeDetails.Add(dsiCompositeDetail);
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
                RfqFilterRequest filterRequest = new RfqFilterRequest();

                filterRequest.DatabaseList = "DSIWIRESPECIFICATIONGRPC";
                filterRequest.FilterExpression =
                    $"Compositeoptionstring == \"{request.CompositeOptionString}\"";

                RfqFilterResponse filterResponse =
                     await _RfqClient.FilterRfqGrpcAsync(filterRequest);

                ListDsiWireSpecificationGrpc wireSpecificationList =
                    filterResponse.ListDsiWireSpecificationGrpc ?? new ListDsiWireSpecificationGrpc();

                GetWireSpecificationByCompositeOptionResponse response =
                    new GetWireSpecificationByCompositeOptionResponse();

                foreach (DsiWireSpecificationGrpc? item in wireSpecificationList.DsiWireSpecificationGrpcs)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    WireSpecificationGrpc wire =
                        new WireSpecificationGrpc();

                    wire.Id = item.RowId;
                    wire.WireName = item.WireName;
                    wire.Compositeoptionstring = item.CompositeOptionString;
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

                    DSIWireSpecificationGrpc? dsiWireSpecification = wire.ToDSIWireSpecification();
                    response.WireSpecifications.Add(dsiWireSpecification);
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
        public async Task<ListComponentGrpc> GetComponentsByHarnessAndOptionsGrpc(GetComponentsByHarnessAndOptionsRequest request)
        {
            try
            {
                await Task.Delay(1);

                GetDSIComponentByHarnessRequest dsiRequest = new GetDSIComponentByHarnessRequest();

                List<string> validHarnessNames = request.HarnessName
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                List<string> validCompositeOptions = request.CompositeOptions
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - HarnessName count: {validHarnessNames.Count}");
                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - HarnessName values: [{string.Join(", ", validHarnessNames)}]");

                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - CompositeOptions count: {validCompositeOptions.Count}");
                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - CompositeOptions values: [{string.Join(", ", validCompositeOptions)}]");

                dsiRequest.HarnessName.AddRange(validHarnessNames);
                dsiRequest.CompositeOptions.AddRange(validCompositeOptions);

                ListDsiComponentGrpc? dsiResponse =
                    await _RfqClient.GetDSIComponentsByHarnessAndOptionsAsync(dsiRequest);

                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - DSI returned {dsiResponse?.DsiComponentGrpcs?.Count ?? 0} component(s)");

                ListComponentGrpc response = new ListComponentGrpc();

                if (dsiResponse?.DsiComponentGrpcs != null)
                {
                    foreach (DsiComponentGrpc? item in dsiResponse.DsiComponentGrpcs)
                    {
                        if (item == null)
                        {
                            continue;
                        }

                        DSIComponentGrpc component = new DSIComponentGrpc();

                        component.Id = item.RowId;
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
                }

                _Logger.GenericLogInformation(
                    $"GetComponentsByHarnessAndOptionsGrpc - Manager mapped {response.ComponentList.Count} component(s)");

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

        DsiCompositeDetailGrpc GenerateCompositeDetailGrpc()
        {
            DsiCompositeDetailGrpc compositeDetailGrpc = new DsiCompositeDetailGrpc();
            compositeDetailGrpc.HarnessName1 = "Harness1";
            compositeDetailGrpc.SimilarHarnessName1 = "SimilarHarness1";
            compositeDetailGrpc.HarnessIssue1 = "Issue1";
            compositeDetailGrpc.SimilarHarnessIssue1 = "SimilarIssue1";
            compositeDetailGrpc.HarnessDate1 = Timestamp.FromDateTime(DateTime.UtcNow);
            compositeDetailGrpc.HarnessName2 = "Harness2";
            compositeDetailGrpc.SimilarHarnessName2 = "SimilarHarness2";
            compositeDetailGrpc.HarnessIssue2 = "Issue2";
            compositeDetailGrpc.SimilarHarnessIssue2 = "SimilarIssue2";
            compositeDetailGrpc.HarnessDate2 = Timestamp.FromDateTime(DateTime.UtcNow);
            compositeDetailGrpc.Customer = "Customer1";
            compositeDetailGrpc.Site = "Site1";
            compositeDetailGrpc.Range = "Range1";
            compositeDetailGrpc.BoardLength = 0;
            compositeDetailGrpc.BoardWidth = 0;
            compositeDetailGrpc.Datum = "Datum1";
            compositeDetailGrpc.UserField1 = "UserField1";
            compositeDetailGrpc.UserField2 = "UserField2";
            compositeDetailGrpc.UserField3 = "UserField3";
            compositeDetailGrpc.UserField4 = "UserField4";
            compositeDetailGrpc.UserField5 = "UserField5";
            compositeDetailGrpc.Checker = "Checker1";
            compositeDetailGrpc.Inputter = "Inputter1";
            compositeDetailGrpc.DraftedBy = "DraftedBy1";
            compositeDetailGrpc.PreparedBy = "PreparedBy1";
            compositeDetailGrpc.Type = "Type1";
            compositeDetailGrpc.Title = "Title1";
            compositeDetailGrpc.EngineSize = "EngineSize1";
            compositeDetailGrpc.ManufacturingCell = "ManufacturingCell1";
            compositeDetailGrpc.Trim = "Trim1";
            compositeDetailGrpc.HandDrive = "HandDrive1";
            compositeDetailGrpc.TubeAddOnType = "TubeAddOnType1";
            compositeDetailGrpc.TubeAddOnFactor = 0;
            compositeDetailGrpc.IsManualTerminal = false;
            compositeDetailGrpc.IsAllConnectorsSealed = false;
            compositeDetailGrpc.AlphaCode = "AlphaCode1";
            compositeDetailGrpc.HarnessID = "HarnessID1";
            compositeDetailGrpc.CircuitOption = "ALL";
            compositeDetailGrpc.CreatedDate = Timestamp.FromDateTime(DateTime.UtcNow);
            compositeDetailGrpc.ModifiedDate = Timestamp.FromDateTime(DateTime.UtcNow);
            compositeDetailGrpc.CreatedBy = "CreatedBy1";
            compositeDetailGrpc.ModifiedBy = "ModifiedBy1";
            return compositeDetailGrpc;
        }
        #endregion
    }
}