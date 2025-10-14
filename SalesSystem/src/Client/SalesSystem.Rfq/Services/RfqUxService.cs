namespace SalesSystem.Rfq.Services
{
    public class RfqUxService
    {
        readonly RfqModule.RfqModule.RfqModuleClient _RfqModuleClient;
        List<RfqModule.CustomerLocationGrpc> _CustomerLocations;

        public RfqUxService(RfqModule.RfqModule.RfqModuleClient rfqModuleClient)
        {
            _RfqModuleClient = rfqModuleClient;
            _CustomerLocations = new List<RfqModule.CustomerLocationGrpc>();
        }
        // Data and Grpc Tasks
        public async Task<List<RfqModule.CustomerGrpc>> GetCustomersAsync(Guid userId)
        {
            await Task.Delay(0);
            GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest();
#pragma warning disable CA1308 // Normalize strings to uppercase
            string v = userId.ToString().ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase
            request.UserId = v;
            GetCustomersByUserIdGrpcResponse customerResponse = _RfqModuleClient.GetCustomersByUserIdGrpc(request);
            List<CustomerGrpc> customers = new List<CustomerGrpc>();
            customers.AddRange(customerResponse.Customers);
            return customers;
        }

        public async Task<List<RfqModule.ProjectGrpc>> GetProjectsbyCustomerProjectAssociation(ICollection<CustomerProjectUx> customerProjects)
        {
            await Task.Delay(0);
            List<RfqModule.ProjectGrpc> projects = new List<RfqModule.ProjectGrpc>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            foreach (CustomerProjectUx cp in customerProjects)
            {
                stopwatch.Restart();
                RfqModule.GetProjectsByIdGrpcRequest request = new RfqModule.GetProjectsByIdGrpcRequest();
                request.Id = cp.ProjectId;
                RfqModule.GetProjectsByIdGrpcResponse response = _RfqModuleClient.GetProjectsByIdGrpc(request);
                stopwatch.Stop();
                Console.WriteLine($"GetProjectsByIdGrpc for {cp.CustomerName} / {cp.ProjectName} call duration: {stopwatch.ElapsedMilliseconds} ms");
                if (0 < response.Projects.Count)
                {
                    projects.AddRange(response.Projects);
                }
            }

            return projects;
        }

        public async Task<List<CustomerProjectUx>> GetCustomerProjectUx(
            ICollection<RfqModule.ProjectGrpc> projects,
            ICollection<RfqModule.CustomerLocationGrpc> customerLocations,
            ICollection<CustomerProjectUx> customerProjects)
        {
            await Task.Delay(0);
            List<CustomerProjectUx> customerProjectUxes = new List<CustomerProjectUx>();
            foreach (CustomerProjectUx customerProjectUx in customerProjects)
            {
                CustomerProjectUx customerProject = new CustomerProjectUx();
                customerProject.Id = customerProjectUx.Id;
                customerProject.CustomerId = customerProjectUx.CustomerId;
                customerProject.ProjectId = customerProjectUx.ProjectId;
                if(null == customerLocations.Where(c => c.Id == customerProjectUx.CustomerId).FirstOrDefault() 
                    || null == projects.Where(c => c.Id == customerProjectUx.ProjectId).FirstOrDefault())
                {
                    continue;
                }

                customerProject.CustomerName = customerLocations.Where(c => c.Id == customerProjectUx.CustomerId).First().CustomerName;

                customerProject.ProjectName = projects.Where(c => c.Id == customerProjectUx.ProjectId).First().ProjectName;
                customerProjectUxes.Add(customerProject);
            }

            return customerProjectUxes;
        }

        public async Task<List<CustomerProjectUx>> GetCustomerProjectAssociations()
        {
            await Task.Delay(0);
            List<CustomerProjectUx> customerProjectAssociations = new List<CustomerProjectUx>();
            foreach (RfqModule.CustomerLocationGrpc location in _CustomerLocations)
            {
                RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcRequest request = new RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcRequest();
                request.LocationId = location.Id;
                RfqModule.GetCustomerProjectAssociationsByLocationIdGrpcResponse response = _RfqModuleClient.GetCustomerProjectAssociationsByLocationIdGrpc(request);
                foreach(RfqModule.CustomerProjectAssociationGrpc? association in response.CustomerProjectAssociation)
                {
                    CustomerProjectUx customerProjectUx = new CustomerProjectUx();
                    customerProjectUx.CustomerId = association.CustomerLocationGuid;
                    customerProjectUx.ProjectId = association.ProjectGuid;
                    customerProjectUx.Id = association.Id;
                    customerProjectAssociations.Add(customerProjectUx);
                }
            }

            return customerProjectAssociations;
        }

        public async Task<List<RfqModule.CustomerLocationGrpc>> GetLocationsByCustomer(string customerId)
        {
            await Task.Delay(0);
            RfqModule.GetLocationsByCustomerIdGrpcRequest request = new RfqModule.GetLocationsByCustomerIdGrpcRequest();
            request.CustomerId = customerId;
            RfqModule.GetLocationsByCustomerIdGrpcResponse locationResponse = _RfqModuleClient.GetLocationsByCustomerIdGrpc(request);
            List<RfqModule.CustomerLocationGrpc> locations = new List<RfqModule.CustomerLocationGrpc>();
            _CustomerLocations.AddRange(locationResponse.Locations);
            locations.AddRange(locationResponse.Locations);
            return locations;
        }

        public async Task<List<RfqModule.RfqReasonGrpc>> GetReasons()
        {
            await Task.Delay(0);
            RfqModule.GetRfqReasonsGrpcRequest request = new RfqModule.GetRfqReasonsGrpcRequest();
            request.RequestType = 1;
            RfqModule.GetRfqReasonsGrpcResponse response = _RfqModuleClient.GetRfqReasonsGrpc(request);
            List<RfqModule.RfqReasonGrpc> reasons = new List<RfqModule.RfqReasonGrpc>();
            reasons.AddRange(response.RfqReasons);
            return reasons;
        }

        //public async Task<List<RfqModule.CustomerLocationGrpc>> GetLocationByProject()
        //{
        //    await Task.Delay(0);
        //    List<RfqModule.CustomerLocationGrpc> locations = new List<RfqModule.CustomerLocationGrpc>();

        //}

        public async Task<List<RfqItemUx>> GetRfqUxItemsAsync()
        {
            await Task.Delay(0);
            List<RfqItemUx> items = new List<RfqItemUx>();
            return items;
        }

        public async Task<int> CreateRfqProject(
            //RfqModule.CustomerGrpc customer,
            //RfqModule.ProjectGrpc project,
            //RfqModule.CustomerLocationGrpc location,
            //RfqModule.RfqReasonGrpc reason,
            //int vehicleVolume,
            //DateTime createdDate,
            //string fileName,
            //byte[] fileContent
            )
        {
            await Task.Delay(0);
            //RfqModule.GetVehicleByProjectCodeGrpcRequest request = new RfqModule.GetVehicleByProjectCodeGrpcRequest();
            //request.ProjectCode = project.ProjectCode;
            //RfqModule.GetVehicleByProjectCodeGrpcResponse s = _RfqModuleClient.GetVehiclesByProjectCodeGrpc(request);
            //if(0 == s.Vehicles.Count)
            //{
            //    return -1;
            //}

            //RfqModule.VehicleGrpc vehicle = s.Vehicles.First();
            //if (reason.RowId != null) 
            //{
            //    RfqModule.UploadPartsRequestGrpcRequest request = new RfqModule.UploadPartsRequestGrpcRequest();
            //    RfqModule.RfqProject rfqProject = new RfqModule.RfqProject();
            //    rfqProject.CustomerBusinessUnitGuid = customer.Id;
            //    rfqProject.CustomerLocationGuid = location.CustomerBusinessHierarchyGuid;
            //    rfqProject.ProjectGuid = project.Id;
            //    rfqProject.RfqReasonId = (int)reason.RowId;
            //    rfqProject.CarModelGuid = vehicle.Id;
            //    rfqProject.VehicleVolume = vehicleVolume;
            //    rfqProject.RfqResponseDeadline = createdDate.ToUniversalTime().ToTimestamp();
            //    request.Project = rfqProject;
            //}

            //request.CustomerId = customerId;
            //request.LocationId = _CustomerLocations.Where(x => x.Id == rfqProject.CustomerLocationGuid);
            //request.ProjectCode = projectCode;
            //request.ProjectName = projectName;
            //RfqModule.CreateRfqProjectGrpcResponse response = _RfqModuleClient.CreateRfqProjectGrpc(request);
            return 1;
        }
    }
}
