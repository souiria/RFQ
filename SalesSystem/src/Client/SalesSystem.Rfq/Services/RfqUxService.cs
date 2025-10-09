namespace SalesSystem.Rfq.Services
{
    public class RfqUxService
    {
        readonly RfqModule.RfqModule.RfqModuleClient _RfqModuleClient;

        public RfqUxService(RfqModule.RfqModule.RfqModuleClient rfqModuleClient)
        {
            _RfqModuleClient = rfqModuleClient;
        }
        // Data and Grpc Tasks
        public async Task<List<CustomerGrpc>> GetCustomersAsync(Guid userId)
        {
            await Task.Delay(0);
            GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest();
            request.UserId = userId.ToString();
            GetCustomersByUserIdGrpcResponse customerResponse = _RfqModuleClient.GetCustomersByUserIdGrpc(request);
            List<CustomerGrpc> customers = new List<CustomerGrpc>();
            customers.AddRange(customerResponse.Customers);
            return customers;
        }

        public async Task<List<CustomerProjectUx>> GetProjectAssociationsByCustomerId(string customerId)
        {
            await Task.Delay(0);
            List<CustomerProjectUx> projectAssociations = new List<CustomerProjectUx>();
            GetProjectAssociationsByCustomerIdRequest request = new GetProjectAssociationsByCustomerIdRequest();
            request.CustomerId = customerId;
            GetProjectAssociationsByCustomerIdResponse response = _RfqModuleClient.GetProjectAssociationsByCustomerId(request);
            foreach (ProjectAssociation? association in response.ProjectAssociation)
            {
                CustomerProjectUx projectAssociation = new CustomerProjectUx();
                projectAssociation.ProjectId = association.CustomerProjectGuid;
                projectAssociation.ProjectName = association.CustomerProjectName;
                projectAssociation.CustomerId = association.CustomerLocationGuid;
                projectAssociation.CustomerName = association.CustomerLocationName;
                projectAssociation.Id = association.Id;
                projectAssociations.Add(projectAssociation);
            }

            return projectAssociations;
        }

        //public async Task<List<ProjectGrpc>> GetProjectsbyCustomerProjectAssociation(ICollection<CustomerProjectUx> customerProjects)
        //{
        //    await Task.Delay(0);
        //    List<ProjectGrpc> projects = new List<ProjectGrpc>();
        //    foreach (CustomerProjectUx cp in customerProjects)
        //    {
        //        GetProjectsByIdGrpcRequest request = new GetProjectsByIdGrpcRequest();
        //        request.Id = cp.ProjectId;
        //        GetProjectsByIdGrpcResponse response = _RfqModuleClient.GetProjectsByIdGrpc(request);
        //        if (0 < response.Projects.Count)
        //        {
        //            projects.AddRange(response.Projects);
        //        }
        //    }

        //    return projects;
        //}

        //public async Task<List<CustomerProjectUx>> GetCustomerProjectUx(
        //    ICollection<ProjectGrpc> projects,
        //    ICollection<CustomerLocationGrpc> customerLocations,
        //    ICollection<CustomerProjectUx> customerProjects)
        //{
        //    await Task.Delay(0);
        //    List<CustomerProjectUx> customerProjectUxes = new List<CustomerProjectUx>();
        //    foreach (CustomerProjectUx customerProjectUx in customerProjects)
        //    {
        //        CustomerProjectUx customerProject = new CustomerProjectUx();
        //        customerProject.Id = customerProjectUx.Id;
        //        customerProject.CustomerId = customerProjectUx.CustomerId;
        //        customerProject.ProjectId = customerProjectUx.ProjectId;
        //        if(null == customerLocations.Where(c => c.Id == customerProjectUx.CustomerId).FirstOrDefault() 
        //            || null == projects.Where(c => c.Id == customerProjectUx.ProjectId).FirstOrDefault())
        //        {
        //            continue;
        //        }

        //        customerProject.CustomerName = customerLocations.Where(c => c.Id == customerProjectUx.CustomerId).First().CustomerName;

        //        customerProject.ProjectName = projects.Where(c => c.Id == customerProjectUx.ProjectId).First().ProjectName;
        //        customerProjectUxes.Add(customerProject);
        //    }

        //    return customerProjectUxes;
        //}

        //public async Task<List<CustomerProjectUx>> GetCustomerProjectAssociations()
        //{
        //    await Task.Delay(0);
        //    List<CustomerProjectUx> customerProjectAssociations = new List<CustomerProjectUx>();
        //    foreach (CustomerLocationGrpc location in _CustomerLocations)
        //    {
        //        GetCustomerProjectAssociationsByLocationIdGrpcRequest request = new GetCustomerProjectAssociationsByLocationIdGrpcRequest();
        //        request.LocationId = location.Id;
        //        GetCustomerProjectAssociationsByLocationIdGrpcResponse response = _RfqModuleClient.GetCustomerProjectAssociationsByLocationIdGrpc(request);
        //        foreach(CustomerProjectAssociationGrpc? association in response.CustomerProjectAssociation)
        //        {
        //            CustomerProjectUx customerProjectUx = new CustomerProjectUx();
        //            customerProjectUx.CustomerId = association.CustomerLocationGuid;
        //            customerProjectUx.ProjectId = association.ProjectGuid;
        //            customerProjectUx.Id = association.Id;
        //            customerProjectAssociations.Add(customerProjectUx);
        //        }
        //    }

        //    return customerProjectAssociations;
        //}

        //public async Task<List<CustomerLocationGrpc>> GetLocationsByCustomer(string customerId)
        //{
        //    await Task.Delay(0);
        //    GetLocationsByCustomerIdGrpcRequest request = new GetLocationsByCustomerIdGrpcRequest();
        //    request.CustomerId = customerId;
        //    GetLocationsByCustomerIdGrpcResponse locationResponse = _RfqModuleClient.GetLocationsByCustomerIdGrpc(request);
        //    List<CustomerLocationGrpc> locations = new List<CustomerLocationGrpc>();
        //    _CustomerLocations.AddRange(locationResponse.Locations);
        //    locations.AddRange(locationResponse.Locations);
        //    return locations;
        //}

        public async Task<List<RfqReasonGrpc>> GetReasons()
        {
            await Task.Delay(0);
            GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest();
            request.RequestType = 1;
            GetRfqReasonsGrpcResponse response = _RfqModuleClient.GetRfqReasonsGrpc(request);
            List<RfqReasonGrpc> reasons = new List<RfqReasonGrpc>();
            reasons.AddRange(response.RfqReasons);
            return reasons;
        }

        public async Task<List<RfqItemUx>> GetRfqUxItemsAsync()
        {
            await Task.Delay(0);
            List<RfqItemUx> items = new List<RfqItemUx>();
            return items;
        }

        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProject(
            CustomerGrpc customer,
            CustomerProjectUx project,
            RfqReasonGrpc reason,
            int vehicleVolume,
            DateTime createdDate
        )
        {
            await Task.Delay(0);
            RfqProject rfqProject = new RfqProject();
            CreateRfqProjectGrpcResponse response = new CreateRfqProjectGrpcResponse();
            if (reason.RowId != null)
            {
                CreateRfqProjectGrpcRequest rfqProjectRequest = new CreateRfqProjectGrpcRequest();
                RfqProject requestProject = new RfqProject();
                requestProject.CustomerBusinessUnitGuid = customer.Id;
                requestProject.CustomerLocationGuid = project.CustomerId;
                requestProject.ProjectGuid = project.ProjectId;
                requestProject.RfqReasonId = (int)reason.RowId;
                requestProject.VehicleVolume = vehicleVolume;
                requestProject.RfqResponseDeadline = createdDate.ToUniversalTime().ToTimestamp();
                rfqProjectRequest.Project = requestProject;

                CreateRfqProjectGrpcResponse rfqProjectResponse = _RfqModuleClient.CreateRfqProjectGrpc(rfqProjectRequest);

                response.Success = true;
                response.Message = rfqProjectResponse.Message;
                response.CreatedProjectId = rfqProjectResponse.CreatedProjectId;
            }

            return response;
        }

        public async Task<bool> UploadPartsAsync(string projectId,IBrowserFile file)
        {
            UploadPartsRequestGrpcResponse response = new UploadPartsRequestGrpcResponse();
            using MemoryStream ms = new MemoryStream();
            await file.OpenReadStream(maxAllowedSize: 10_000_000).CopyToAsync(ms);
            byte[] fileBytes = ms.ToArray();
            string fileName = file.Name;
            UploadPartsRequestGrpcRequest uploadPartsRequestGrpcRequest = new UploadPartsRequestGrpcRequest();
            uploadPartsRequestGrpcRequest.FileName = fileName;
            uploadPartsRequestGrpcRequest.FileData = Google.Protobuf.ByteString.CopyFrom(fileBytes);
            uploadPartsRequestGrpcRequest.ProjectId = projectId;
            response = _RfqModuleClient.UploadPartsGrpc(uploadPartsRequestGrpcRequest);
            if (!response.Success)
            {
                return false;    
            }

            return true;
        }
    }
}
