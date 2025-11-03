using Azure;
using Google.Protobuf.WellKnownTypes;

namespace RfqModule.Services
{
    public class RfqManagerService : IRfqManagerService
    {

        readonly MasterClient _MasterClient;
        readonly Rfq.Rfq.RfqClient _RfqClient;
        readonly Emacs.Emacs.EmacsClient _EmacsClient;
        readonly Adss.AdssGrpc.AdssGrpcClient _AdssGrpcClient;
        readonly ILogger<RfqManagerService> _Logger;
        //readonly IFilter _FilteringService;

        public RfqManagerService(ILogger<RfqManagerService> logger,
              MasterClient masterClient,
            Rfq.Rfq.RfqClient rfqClient,
            Emacs.Emacs.EmacsClient emacsClient,
            Adss.AdssGrpc.AdssGrpcClient adssGrpcClient

            )
        {
            _Logger = logger;
            _MasterClient = masterClient;
            _RfqClient = rfqClient;
            _EmacsClient = emacsClient;
            _AdssGrpcClient = adssGrpcClient;
        }

        public async Task<GetCustomersGrpcResponse> GetCustomersGrpc(GetCustomersGrpcRequest request)
        {
            try
            {
                // Call the Master service to get customers
                await Task.Delay(1000);
                CustomerGrpcRequest getCustomersRequest = new CustomerGrpcRequest();
                getCustomersRequest.Position = request.Position;
                getCustomersRequest.Takeamount = request.Takeamount;
                ListCustomerGrpc customers = _MasterClient.GetCustomerGrpc(getCustomersRequest);
                GetCustomersGrpcResponse response = new GetCustomersGrpcResponse();
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

        public async Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request)
        {
            try
            {
                // Call the Master service to get locations by customer ID
                await Task.Delay(1000);
                CustomerLocationByCustomerIdGrpcRequest locationRequest = new CustomerLocationByCustomerIdGrpcRequest();
                locationRequest.CustomerId = request.CustomerId;
                ListCustomerLocationGrpc locations = _MasterClient.GetCustomerLocationGrpcByCustomerId(locationRequest);
                GetLocationsByCustomerIdGrpcResponse response = new GetLocationsByCustomerIdGrpcResponse();
                foreach (Master.CustomerLocationGrpc? masterLocation in locations.CustomerLocationGrpc)
                {
                    CustomerLocationGrpc location = masterLocation.ToCustomerLocation();
                    response.Locations.Add(location);
                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching locations from Master service", ex);
                throw;
            }
        }

        public async Task<GetProjectsByLocationIdGrpcResponse> GetProjectsByLocationIdGrpc(GetProjectsByLocationIdGrpcRequest request)
        {
            try
            {
                // Call the Master service to get projects by location ID
                await Task.Delay(1000);
                CustomerProjectAssociationByLocationIdGrpcRequest projectRequest = new CustomerProjectAssociationByLocationIdGrpcRequest();
                projectRequest.LocationId = request.LocationId;
                ListCustomerProjectAssociationGrpc projectAssociations = _MasterClient.GetCustomerProjectAssociationGrpcByLocationId(projectRequest);
                List<Master.ProjectGrpc> projects = new List<Master.ProjectGrpc>();
                foreach (CustomerProjectAssociationGrpc? association in projectAssociations.CustomerProjectAssociationGrpc)
                {
                    _Logger.GenericLogInformation("Project Association from Master Service: " + association.ToString());
                    ProjectByIdGrpcRequest projectRequestById = new ProjectByIdGrpcRequest();
                    projectRequestById.Id = association.ProjectGuid;
                    ListProjectGrpc project = _MasterClient.GetProjectGrpcById(projectRequestById);
                    projects.AddRange(project.ProjectGrpc);
                }

                GetProjectsByLocationIdGrpcResponse response = new GetProjectsByLocationIdGrpcResponse();
                foreach (Master.ProjectGrpc? masterProject in projects)
                {
                    ProjectGrpc location = masterProject.ToProject();
                    response.Projects.Add(location);

                }

                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError("Error fetching projects from Master service", ex);
                throw;
            }
        }

        public async Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request)
        {
            try
            {
                // Call the Master service to get vehicles by project reference
                await Task.Delay(1000);
                VehicleGrpcRequest vehicleRequest = new VehicleGrpcRequest();
                ListVehicleGrpc vehicles = _MasterClient.GetVehicleGrpc(vehicleRequest);
                List<VehicleGrpc> filteredVehicles = new List<VehicleGrpc>();
                foreach (Master.VehicleGrpc? vehicle in vehicles.VehicleGrpc)
                {
                    _Logger.GenericLogInformation("Vehicle from Master Service: " + vehicle.ToString());
                    if (vehicle.ProjectReference.Contains(request.ProjectCode, StringComparison.OrdinalIgnoreCase))
                    {
                        VehicleGrpc filteredVehicle = vehicle.ToVehicle();
                        filteredVehicles.Add(filteredVehicle);
                    }
                }

                GetVehicleByProjectCodeGrpcResponse response = new GetVehicleByProjectCodeGrpcResponse();
                response.Vehicles.AddRange(filteredVehicles);
                return response;
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
                await Task.Delay(1000);
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
            //string file = File.ReadAllText("Services/Ford.xml");
            //ByteString bytes = ByteString.CopyFrom(file, Encoding.UTF8);
            //byte[] fileBytes = await File.ReadAllBytesAsync("Services/Ford_Mega_Bom.csv");
            //ByteString bytes = ByteString.CopyFrom(fileBytes);
            //request.FileData = bytes;
            UploadPartsRequestGrpcResponse uploadResponse = new UploadPartsRequestGrpcResponse();
            List<CustomerParts> customerParts = await ConvertDocumentAsync(request);
            RfqCrudGrpcResponse createRfqProjectResponse = CreateRfqProject(request);

            if (createRfqProjectResponse.SaveSuccess == false)
            {
                uploadResponse.Success = false;
                uploadResponse.Message = "Failed to create RFQ Project";
                return uploadResponse;
            }

            List<string> projectIds = createRfqProjectResponse.StringValue.Split(",").ToList();
            string projectId = projectIds.First();

            RfqCrudGrpcResponse partResponse = CreateRfqDrawingPartNumbers(projectId, customerParts);

            if (partResponse.SaveSuccess == false)
            {
                uploadResponse.Success = false;
                uploadResponse.Message = "Failed to create RFQ Parts";
                return uploadResponse;
            }

            uploadResponse.Success = true;
            uploadResponse.Message = "File processed and RFQ Project and Parts created successfully";
            uploadResponse.PartNumbers.AddRange(customerParts);

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
                    object csvData = DocumentConverter.ConvertCSV(fileData, fileName);
                    fordCsvDtos = (List<FordCsvDto>)csvData;
                    break;
                    case ".XML":
                    // Handle XML file processing
                    _Logger.GenericLogInformation("Processing XML file: " + fileName);
                    crossReferenceDtos = DocumentConverter.ConvertFordXMLFile(fileData).ToList();
                    break;
                    case ".XLSX":
                    // Handle Excel file processing
                    _Logger.GenericLogInformation("Processing Excel file: " + fileName);
                    crossReferenceDtos = DocumentConverter.ConvertExcelFile(fileData).ToList();
                    break;
                    case ".MTF":
                    // Handle MTF file processing
                    _Logger.GenericLogInformation("Processing MTF file: " + fileName);
                    crossReferenceDtos = DocumentConverter.ConvertToyotaXMLFile(fileData).ToList();
                    break;
                    case ".TXT":
                    // Handle TXT file processing
                    _Logger.GenericLogInformation("Processing TXT file: " + fileName);
                    crossReferenceDtos = DocumentConverter.ConvertRenaultCSVFile(fileData).ToList();
                    break;
                    case ".DSI":
                    // Handle DSI file processing
                    _Logger.GenericLogInformation("Processing DSI file: " + fileName);
                    dsiAggregate = DocumentConverter.ConvertDsiFile(fileData);
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

        RfqCrudGrpcResponse CreateRfqProject(UploadPartsRequestGrpcRequest request)
        {
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
            return createResponse;
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
            string[] parametersToSearch = ["UniformCustomerNumber", "UniformSupplierNumber", "UniformSumitomoNumber"];
            foreach (string parameter in parametersToSearch)
            {
                EmacsFilterResponseGrpc partNumberResponse = FilterEmacsSumitomoNumber(request.StringValue, parameter, "==");
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
            foreach (string parameter in parametersToSearch)
            {
                EmacsFilterResponseGrpc partNumberResponse = FilterEmacsSumitomoNumber(request.StringValue, parameter, ".Contains");
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

        EmacsFilterResponseGrpc FilterEmacsSumitomoNumber(string partNumber, string filterType, string filterOpperator)
        {
            EmacsFilterRequestGrpc emacsRequest = new EmacsFilterRequestGrpc();
            if(filterOpperator == "==")
            {
                emacsRequest.FilterExpression = $"{filterType} != null && {filterType} {filterOpperator} \"{partNumber}\"";
            }
            else if(filterOpperator == ".Contains")
            {
                emacsRequest.FilterExpression =  $"{filterType} != null && {filterType}{filterOpperator}(\"{partNumber}\")";
            }
            else
            {
                throw new ArgumentException("Invalid filter operator");
            }

            emacsRequest.DatabaseList = "CombinedPartsGrpc";
            EmacsFilterResponseGrpc filterResponse = _EmacsClient.FilterEmacsDataGrpc(emacsRequest);
            return filterResponse;
        }
    }
}