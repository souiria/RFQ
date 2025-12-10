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
        readonly ILogger<RfqManagerService> _Logger;

        List<ProjectGrpc> _Projects;

        public RfqManagerService(ILogger<RfqManagerService> logger,
              MasterClient masterClient,
            Rfq.Rfq.RfqClient rfqClient,
            Emacs.Emacs.EmacsClient emacsClient,
            Adss.AdssGrpc.AdssGrpcClient adssGrpcClient,
            NPR.NPR.NPRClient nprClient,
            CPD.CPD.CPDClient cPDClient
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
        }

        public async Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc (GetAllCustomersGrpcRequest request)
        {
            try
            {
                // Call the Master service to get all customers
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
                _Logger.GenericLogError("Error fetching customers from Master service", ex);
                throw;
            }
        }
        public async Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request)
        {
            try
            {
                // Call the Master service to get customers
                await Task.Delay(1);
                CustomerByUserIdGrpcRequest getCustomersRequest = new CustomerByUserIdGrpcRequest();
                getCustomersRequest.Id = request.UserId.ToUpperInvariant();
                ListCustomerGrpc customers = _MasterClient.GetCustomerGrpcByUserId(getCustomersRequest);
                GetCustomersByUserIdGrpcResponse response = new GetCustomersByUserIdGrpcResponse();
                foreach (Master.CustomerGrpc? masterCustomer in customers.CustomerGrpc)
                {
                    CustomerGrpc customer = masterCustomer.ToCustomerGrpc();
                    response.Customers.Add(customer);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching customers from Master service", ex);
                throw;
            }
        }

        public async Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request)
        {
            try
            {
                await Task.Delay(1);
                _Projects.Clear();
                GetProjectAssociationsByCustomerIdResponse response = new GetProjectAssociationsByCustomerIdResponse();
                MastersFilterRequestGrpc filterRequest = new MastersFilterRequestGrpc();
                filterRequest.DatabaseList = "CUSTOMERLOCATIONGRPC";
                //filterRequest.FilterExpression = $"CustomerId != null && CustomerId == \"{request.CustomerId.ToUpperInvariant()}\"";
                filterRequest.FilterExpression = $"Id != null && Id == \"{request.CustomerId.ToUpperInvariant()}\"";
                MastersFilterResponseGrpc locations = _MasterClient.FilterMasterDataGrpc(filterRequest);
                List<CustomerLocationGrpc> extractedLocations = ExtractMastersResponseData<CustomerLocationGrpc>(locations).ToList();
                if (extractedLocations.Count <= 0)
                {
                    response.Message = "No locations found for customer";
                    response.Success = false;
                    return response;
                }

                foreach (CustomerLocationGrpc? location in extractedLocations)
                {
                    filterRequest.DatabaseList = "CUSTOMERPROJECTASSOCIATIONGRPC";
                    filterRequest.FilterExpression = $"CustomerGuid != null && CustomerGuid == \"{location.Id.ToUpperInvariant()}\"";
                    MastersFilterResponseGrpc projectAssociations = _MasterClient.FilterMasterDataGrpc(filterRequest);
                    List<CustomerProjectAssociationGrpc> extractedProjectAssociations = ExtractMastersResponseData<CustomerProjectAssociationGrpc>(projectAssociations).ToList();

                    foreach (CustomerProjectAssociationGrpc? customerProjectAssociation in extractedProjectAssociations)
                    {
                        if (customerProjectAssociation.ProjectGuid == null)
                        {
                            continue;
                        }

                        filterRequest.DatabaseList = "PROJECTGRPC";
                        filterRequest.FilterExpression = $"Id != null && Id == \"{customerProjectAssociation.ProjectGuid.ToUpperInvariant()}\"";
                        MastersFilterResponseGrpc projects = _MasterClient.FilterMasterDataGrpc(filterRequest);
                        List<ProjectGrpc> extractedProjects = ExtractMastersResponseData<ProjectGrpc>(projects).ToList();

                        if(extractedProjects.Count <= 0)
                        {
                            continue;
                        }

                        _Projects.AddRange(extractedProjects);
                        foreach (ProjectGrpc? project in extractedProjects)
                        {
                            ProjectAssociation projectAssociation = new ProjectAssociation();
                            projectAssociation.CustomerLocationGuid = location.Id.ToUpperInvariant();
                            projectAssociation.CustomerLocationName = location.CustomerName;
                            projectAssociation.CustomerProjectGuid = project.Id.ToUpperInvariant();
                            projectAssociation.CustomerProjectName = project.CustomerProjectCode;
                            projectAssociation.Id = customerProjectAssociation.Id;
                            response.ProjectAssociation.Add(projectAssociation);
                        }
                    }
                }

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
                    _Logger.GenericLogInformation("Vehicle from Master Service: " + vehicle.ToString());
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

                return filteredVehicles;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching vehicles from Master service", ex);
                throw;
            }
        }

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

                ListRfqReasonGrpc rfqReasons = _RfqClient.ReadRfqReasonGrpc(rfqReasonRequest);
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

                // Prepare RFQ project request
                RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();
                RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqGrpcRequestParameter.Position = request.Position;
                rfqGrpcRequestParameter.Take = request.Take;
                rfqGrpcRequestParameter.RequestType = 1;
                rfqProjectRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;

                // Fetch RFQ projects
                ListRfqProjectGrpc rfqProjects = _RfqClient.ReadRfqProjectGrpc(rfqProjectRequest);

                // Fetch RFQ reasons
                RfqReasonGrpcRequest rfqReasonRequest = new RfqReasonGrpcRequest();
                RfqGrpcRequestParameter reasonRequestParameter = new RfqGrpcRequestParameter();
                reasonRequestParameter.Position = 0;
                reasonRequestParameter.Take = 100;
                reasonRequestParameter.RequestType = 1;
                rfqReasonRequest.RfqGrpcRequestParameter = reasonRequestParameter;

                ListRfqReasonGrpc rfqReasons = _RfqClient.ReadRfqReasonGrpc(rfqReasonRequest);

                // Build reason lookup
                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId != 0 && r.ReasonTitle != null)
                    .ToDictionary(r => r.RowId, r => r.ReasonTitle);

                // Fetch customers
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

                // Prepare RFQ project request
                //RfqGrpcRequestParameter rfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                //rfqGrpcRequestParameter.RequestType = 2;

                //RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();
                //rfqProjectRequest.RfqGrpcRequestParameter = rfqGrpcRequestParameter;
                //rfqProjectRequest.RowId = request.RowId;

                GetRfqProjectByIdGrpcResponse response = new();

                // Fetch RFQ project
                //ListRfqProjectGrpc rfqProjects = _RfqClient.ReadRfqProjectGrpc(rfqProjectRequest);
                RfqFilterRequest rfqGrpcRequestParameter = new RfqFilterRequest();
                rfqGrpcRequestParameter.DatabaseList = "RfqProjectGrpc".ToUpperInvariant();
                rfqGrpcRequestParameter.FilterExpression = $"RowId != null && RowId == {request.RowId}";
                RfqFilterResponse filterResponse = _RfqClient.FilterRfqGrpc(rfqGrpcRequestParameter);
                List<RfqProjectGrpc> rfqProjects = filterResponse.ListRfqProjectGrpc.RfqProjects.ToList();

                // Fetch RFQ reasons
                RfqReasonGrpcRequest rfqReasonRequest = new RfqReasonGrpcRequest();
                RfqGrpcRequestParameter reasonRequestParameter = new RfqGrpcRequestParameter();
                reasonRequestParameter.Position = 0;
                reasonRequestParameter.Take = 100;
                reasonRequestParameter.RequestType = 1;
                rfqReasonRequest.RfqGrpcRequestParameter = reasonRequestParameter;

                ListRfqReasonGrpc rfqReasons = _RfqClient.ReadRfqReasonGrpc(rfqReasonRequest);

                Dictionary<int, string> reasonLookup = rfqReasons.RfqReasons
                    .Where(r => r.RowId != 0 && r.ReasonTitle != null)
                    .ToDictionary(r => r.RowId, r => r.ReasonTitle);

                // Fetch customers
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

                int projectCount = rfqProjects.Count;
                bool hasProjects = 0 < projectCount;

                if (hasProjects)
                {
                    RfqProjectGrpc grpcProject = rfqProjects.First();
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

                RfqDrawingPartNumbersGrpcRequest rfqGrpcRequestParameter = new RfqDrawingPartNumbersGrpcRequest();
                rfqGrpcRequestParameter.RfqGrpcRequestParameter = new RfqGrpcRequestParameter();
                rfqGrpcRequestParameter.RfqGrpcRequestParameter.RequestType = 2;
                rfqGrpcRequestParameter.RfqId = request.RfqId;
                ListRfqDrawingPartNumbersGrpc rfqParts = await _RfqClient.ReadRfqDrawingPartNumbersGrpcAsync(rfqGrpcRequestParameter);

                GetRfqDrawingPartNumbersByRfqIdGrpcResponse response = new GetRfqDrawingPartNumbersByRfqIdGrpcResponse();

                int partCount = rfqParts.RfqDrawingPartNumbers.Count;
                bool hasParts = !(partCount <= 0);
                if (hasParts)
                {
                    List<RfqDrawingPartNumber> mappedParts = new List<RfqDrawingPartNumber>();

                    foreach (RfqDrawingPartNumbersGrpc grpcPart in rfqParts.RfqDrawingPartNumbers)
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
        public async Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request)
        {
            UploadPartsRequestGrpcResponse uploadResponse = new UploadPartsRequestGrpcResponse();
            List<CustomerParts> customerParts = await ConvertDocumentAsync(request);

            RfqCrudGrpcResponse partResponse = CreateRfqDrawingPartNumbers(request.ProjectId, customerParts);

            if (partResponse.SaveSuccess == false)
            {
                uploadResponse.Success = false;
                uploadResponse.Message = "Failed to create RFQ Parts";
                return uploadResponse;
            }

            uploadResponse.Success = true;
            uploadResponse.Message = $"{request.FileName} processed and RFQ Parts created successfully";

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
            if(request.Project == null
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

        RfqCrudGrpcResponse CreateRfqDrawingPartNumbers(string projectId, List<CustomerParts> customerParts)
        {
            RfqDrawingPartNumbersGrpcRequest partRequest = new RfqDrawingPartNumbersGrpcRequest();
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

            RfqCrudGrpcResponse partResponse = _RfqClient.CreateRfqDrawingPartNumbersGrpc(partRequest);
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
            part.IsExactMatch = true;
            part.IsSwapped = false;
            part.Comments = "";
            return part;
        }

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
            foreach (MatSuppMstViewGrpc part in filteredList)
            {
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
                filterExpression = $"{filterType} != null && {filterType}.ToUpperInvariant() {filterOpperator} \"{partNumber.ToUpperInvariant()}\"";
            }
            else if (filterOpperator == ".Contains")
            {
                filterExpression = $"{filterType} != null && {filterType}.ToUpperInvariant(){filterOpperator}(\"{partNumber.ToUpperInvariant()}\")";
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
    }
}