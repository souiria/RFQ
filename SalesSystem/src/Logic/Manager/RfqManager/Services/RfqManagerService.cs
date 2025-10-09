namespace RfqModule.Services
{
    public class RfqManagerService : IRfqManagerService
    {

        readonly Master.Master.MasterClient _MasterClient;
        readonly Rfq.Rfq.RfqClient _RfqClient;
        readonly ILogger<RfqManagerService> _Logger;

        List<ProjectGrpc> _Projects;

        public RfqManagerService(ILogger<RfqManagerService> logger,
            Master.Master.MasterClient masterClient,
            Rfq.Rfq.RfqClient rfqClient
            )
        {
            _Logger = logger;
            _MasterClient = masterClient;
            _RfqClient = rfqClient;
            _Projects = new List<ProjectGrpc>();
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
                CustomerByIdGrpcRequest getCustomersRequest = new CustomerByIdGrpcRequest();
                getCustomersRequest.Id = request.UserId;
                ListCustomerGrpc customers = _MasterClient.GetCustomerGrpcById(getCustomersRequest);
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
                CustomerLocationByCustomerIdGrpcRequest locationRequest = new CustomerLocationByCustomerIdGrpcRequest();
                locationRequest.CustomerId = request.CustomerId;
                ListCustomerLocationGrpc locations = _MasterClient.GetCustomerLocationGrpcByCustomerId(locationRequest);
                if (locations.CustomerLocationGrpc.Count <= 0)
                {
                    response.Message = "No locations found for customer";
                    response.Success = false;
                    return response;
                }

                foreach (CustomerLocationGrpc? location in locations.CustomerLocationGrpc)
                {
                    CustomerProjectAssociationByLocationIdGrpcRequest customerProjectRequest = new CustomerProjectAssociationByLocationIdGrpcRequest();
                    customerProjectRequest.LocationId = location.Id;
                    ListCustomerProjectAssociationGrpc customerProjectAssociations = _MasterClient.GetCustomerProjectAssociationGrpcByLocationId(customerProjectRequest);

                    foreach (CustomerProjectAssociationGrpc? customerProjectAssociation in customerProjectAssociations.CustomerProjectAssociationGrpc)
                    {
                        if (customerProjectAssociation.ProjectGuid == null)
                        {
                            continue;
                        }

                        ProjectByIdGrpcRequest projectRequest = new ProjectByIdGrpcRequest();
                        projectRequest.Id = customerProjectAssociation.ProjectGuid;
                        ListProjectGrpc projects = _MasterClient.GetProjectGrpcById(projectRequest);
                        if(projects.ProjectGrpc.Count <= 0)
                        {
                            continue;
                        }

                        _Projects.AddRange(projects.ProjectGrpc);
                        foreach (ProjectGrpc? project in projects.ProjectGrpc)
                        {
                            ProjectAssociation projectAssociation = new ProjectAssociation();
                            projectAssociation.CustomerLocationGuid = location.Id;
                            projectAssociation.CustomerLocationName = location.CustomerName;
                            projectAssociation.CustomerProjectGuid = project.Id;
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

        //public async Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request)
        //{
        //    try
        //    {
        //        // Call the Master service to get locations by customer ID
        //        await Task.Delay(1000);
        //        CustomerLocationByCustomerIdGrpcRequest locationRequest = new CustomerLocationByCustomerIdGrpcRequest();
        //        locationRequest.CustomerId = request.CustomerId;
        //        ListCustomerLocationGrpc locations = _MasterClient.GetCustomerLocationGrpcByCustomerId(locationRequest);
        //        GetLocationsByCustomerIdGrpcResponse response = new GetLocationsByCustomerIdGrpcResponse();
        //        foreach (Master.CustomerLocationGrpc? masterLocation in locations.CustomerLocationGrpc)
        //        {
        //            CustomerLocationGrpc location = masterLocation.ToCustomerLocation();
        //            response.Locations.Add(location);
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger.GenericLogError("Error fetching locations from Master service", ex);
        //        throw;
        //    }
        //}

        //public async Task<GetProjectsByIdGrpcResponse> GetProjectsByIdGrpc(GetProjectsByIdGrpcRequest request)
        //{
        //    try
        //    {
        //        // Call the Master service to get projects by location ID
        //        await Task.Delay(1000);
        //        List<Master.ProjectGrpc> projects = new List<Master.ProjectGrpc>();

        //        GetProjectsByIdGrpcResponse response = new GetProjectsByIdGrpcResponse();
        //        ProjectByIdGrpcRequest projectRequest = new ProjectByIdGrpcRequest();
        //        projectRequest.Id = request.Id;
        //        ListProjectGrpc projectList = _MasterClient.GetProjectGrpcById(projectRequest);
        //        projects.AddRange(projectList.ProjectGrpc);
        //        foreach (Master.ProjectGrpc? masterProject in projects)
        //        {
        //            ProjectGrpc project = masterProject.ToProject();
        //            response.Projects.Add(project);

        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger.GenericLogError("Error fetching projects from Master service", ex);
        //        throw;
        //    }
        //}

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

        

        //public async Task<GetCustomerProjectAssociationsByLocationIdGrpcResponse> GetCustomerProjectAssociationsByLocationIdGrpc(GetCustomerProjectAssociationsByLocationIdGrpcRequest request)
        //{
        //    try
        //    {
        //        await Task.Delay(1000);
        //        CustomerProjectAssociationByLocationIdGrpcRequest customerProjectRequest = new CustomerProjectAssociationByLocationIdGrpcRequest();
        //        customerProjectRequest.LocationId = request.LocationId;
        //        ListCustomerProjectAssociationGrpc customerProjectAssociations = _MasterClient.GetCustomerProjectAssociationGrpcByLocationId(customerProjectRequest);
        //        GetCustomerProjectAssociationsByLocationIdGrpcResponse response = new GetCustomerProjectAssociationsByLocationIdGrpcResponse();
        //        foreach (Master.CustomerProjectAssociationGrpc? association in customerProjectAssociations.CustomerProjectAssociationGrpc)
        //        {
        //            CustomerProjectAssociationGrpc customerProjectAssociation = association.ToCustomerProjectAssociation();
        //            response.CustomerProjectAssociation.Add(customerProjectAssociation);
        //        }

        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger.GenericLogError("Error fetching customerProjectAssociations from Master service", ex);
        //        throw;
        //    }
        //}

        public async Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request)
        {
            try
            {
                // Call the Rfq service to get RFQ reasons
                await Task.Delay(1);
                RfqReasonGrpcRequest rfqReasonRequest = new RfqReasonGrpcRequest();
                GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
                grpcRequestParameter.Position = request.Position;
                grpcRequestParameter.Take = request.Take;
                grpcRequestParameter.RequestType = request.RequestType;
                rfqReasonRequest.GrpcRequestParameter = grpcRequestParameter;

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
            uploadResponse.Message = "File processed and RFQ Project and Parts created successfully";

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
            await Task.Delay(1000);

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
            ProjectGrpc project = _Projects.First(p => p.Id == request.Project.ProjectGuid);
            string projectCode = project.CustomerProjectCode;
            List<VehicleGrpc> vehiclesResponse = await GetVehiclesByProjectCodeGrpc(projectCode);
            CreateRfqProjectGrpcResponse response = new CreateRfqProjectGrpcResponse();
            if (0 == vehiclesResponse.Count)
            {
                response.Success = false;
                return response;
            }

            VehicleGrpc vehicle = vehiclesResponse.First();

            request.Project.CarModelGuid = vehicle.Id;

            RfqProjectGrpc rfqProject = new RfqProjectGrpc();
            RfqProjectGrpcRequest rfqProjectRequest = new RfqProjectGrpcRequest();

            rfqProject.CustomerBusinessUnitGuid = request.Project.CustomerBusinessUnitGuid;
            rfqProject.CustomerLocationGuid = request.Project.CustomerLocationGuid;
            rfqProject.ProjectGuid = request.Project.ProjectGuid;
            rfqProject.RfqReasonId = request.Project.RfqReasonId;
            rfqProject.RfqResponseDeadline = request.Project.RfqResponseDeadline;
            rfqProject.CarModelGuid = request.Project.CarModelGuid;
            rfqProject.VehicleVolume = request.Project.VehicleVolume;
            rfqProject.CreatedDate = DateTime.Now.ToUniversalTime().ToTimestamp();

            GrpcRequestParameter grpcRequestParameter = new GrpcRequestParameter();
            rfqProjectRequest.GrpcRequestParameter = grpcRequestParameter;
            rfqProjectRequest.GrpcRequestParameter.RequestType = 70;
            rfqProjectRequest.RfqProjectGrpcsToCreate.Add(rfqProject);
            RfqCrudGrpcResponse createResponse = _RfqClient.CreateRfqProjectGrpc(rfqProjectRequest);
            if (createResponse.SaveSuccess == false)
            {
                response.Success = false;
                response.Message = "Failed to create RFQ Project";
                return response;
            }

            response.Message = createResponse.Message;
            response.CreatedProjectId = createResponse.StringValue.Split(',').First();
            return response;
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
            partRequest.GrpcRequestParameter = new GrpcRequestParameter();
            partRequest.GrpcRequestParameter.RequestType = 70;

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
    }
}