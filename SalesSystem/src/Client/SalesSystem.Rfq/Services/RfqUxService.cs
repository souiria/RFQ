using System.Collections.Generic;

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
        public async Task<List<RfqModule.CustomerGrpc>> GetCustomersAsync()
        {
            await Task.Delay(0);
            RfqModule.GetAllCustomersGrpcRequest request = new RfqModule.GetAllCustomersGrpcRequest();
            request.Position = 0;
            request.Take = 100;
            RfqModule.GetAllCustomersGrpcResponse customerResponse = _RfqModuleClient.GetAllCustomersGrpc(request);
            List<RfqModule.CustomerGrpc> customers = new List<RfqModule.CustomerGrpc>();
            customers.AddRange(customerResponse.Customers);
            return customers;
        }

        public async Task<List<RfqModule.ProjectGrpc>> GetProjectByCustomer(string customerId)
        {
            await Task.Delay(0);
            RfqModule.GetLocationsByCustomerIdGrpcRequest request = new RfqModule.GetLocationsByCustomerIdGrpcRequest();
            request.CustomerId = customerId;
            RfqModule.GetLocationsByCustomerIdGrpcResponse locationResponse = _RfqModuleClient.GetLocationsByCustomerIdGrpc(request);
            _CustomerLocations.Clear();
            _CustomerLocations.AddRange(locationResponse.Locations);
            List<RfqModule.ProjectGrpc> projects = new List<RfqModule.ProjectGrpc>();
            foreach (RfqModule.CustomerLocationGrpc location in locationResponse.Locations)
            {
                RfqModule.GetProjectsByLocationIdGrpcRequest projectRequest = new RfqModule.GetProjectsByLocationIdGrpcRequest();
                projectRequest.LocationId = location.Id;
                RfqModule.GetProjectsByLocationIdGrpcResponse projectResponse = _RfqModuleClient.GetProjectsByLocationIdGrpc(projectRequest);
                projects.AddRange(projectResponse.Projects);
            }

            return projects;
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
        public async Task<List<RfqItemUx>> GetRfqUxItemsAsync()
        {
            await Task.Delay(0);
            List<RfqItemUx> items = new List<RfqItemUx>();
            return items;
        }

        public async Task<int> CreateRfqProject(
            //RfqModule.CustomerGrpc customer,
            //RfqModule.ProjectGrpc project,
            //RfqModule.RfqReasonGrpc reason,
            //int vehicleVolume,
            //DateTime createdDate
            )
        {
            await Task.Delay(0);
            RfqModule.UploadPartsRequestGrpcRequest request = new RfqModule.UploadPartsRequestGrpcRequest();
            RfqModule.RfqProject rfqProject = new RfqModule.RfqProject();
            //rfqProject.CustomerBusinessUnitGuid = customer.Id;
            //rfqProject.CustomerLocationGuid = _CustomerLocations.Where(x => x.Id == project).First().Id;
            //rfqProject.ProjectGuid = project.Id;
            //rfqProject.RfqReasonId = reason.RowId;

            //request.CustomerId = customerId;
            //request.LocationId = _CustomerLocations.Where(x => x.Id == rfqProject.CustomerLocationGuid);
            //request.ProjectCode = projectCode;
            //request.ProjectName = projectName;
            //RfqModule.CreateRfqProjectGrpcResponse response = _RfqModuleClient.CreateRfqProjectGrpc(request);
            return 1;
        }
    }
}
