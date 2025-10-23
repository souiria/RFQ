using SalesSystem.Rfq.Extensions;
using static RfqModule.RfqModule;

namespace SalesSystem.Rfq.Services
{
    public class RfqUxClientService
    {
        readonly RfqModuleClient _RfqModuleClient;
        readonly ILogger<RfqUxClientService> _Logger;
        List<CustomerGrpc> _Customers;
        List<RfqReasonGrpc> _Reasons;
        List<CustomerProjectUx> _CustomerProjectAssociations;

        public IReadOnlyCollection<CustomerGrpc> Customers => _Customers.AsReadOnly();
        public IReadOnlyCollection<RfqReasonGrpc> Reasons => _Reasons.AsReadOnly();
        public IReadOnlyCollection<CustomerProjectUx> CustomerProjectAssociations => _CustomerProjectAssociations.AsReadOnly();

        public RfqUxClientService(RfqModuleClient rfqModuleClient, ILogger<RfqUxClientService> logger)
        {
            _RfqModuleClient = rfqModuleClient;
            _Logger = logger;
            _Customers = new();
            _Reasons = new();
            _CustomerProjectAssociations = new();
        }

        public async Task<HelloReply> SayHelloAsync(string name)
        {
            try
            {
                HelloRequest request = new HelloRequest();
                request.Name = name;
                HelloReply response = await _RfqModuleClient.SayHelloAsync(request);
                _Logger.GenericLogInformation($"SayHello completed successfully for name: {name}");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error calling SayHello for name: {name}", ex);
                throw;
            }
        }

        public async Task<GetAllCustomersGrpcResponse> GetAllCustomersAsync(int position = 0, int take = 100)
        {
            try
            {
                GetAllCustomersGrpcRequest request = new GetAllCustomersGrpcRequest();
                request.Position = position;
                request.Take = take;
                GetAllCustomersGrpcResponse response = await _RfqModuleClient.GetAllCustomersGrpcAsync(request);
                _Logger.GenericLogInformation($"GetAllCustomers completed successfully. Retrieved {response.Customers.Count} customers");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error getting all customers with position: {position}, take: {take}", ex);
                throw;
            }
        }

        public async Task<int> GetCustomersByUserIdAsync(Guid userId)
        {
            try
            {
                GetCustomersByUserIdGrpcRequest request = new GetCustomersByUserIdGrpcRequest();
                string userIdString = userId.ToString().ToUpperInvariant();
                request.UserId = userIdString;

                GetCustomersByUserIdGrpcResponse response = await _RfqModuleClient.GetCustomersByUserIdGrpcAsync(request);
                _Logger.GenericLogInformation($"GetCustomersByUserId completed successfully for user: {userId}. Retrieved {response.Customers.Count} customers");
                _Customers.Clear();
                _Customers.AddRange(response.Customers);
                return _Customers.Count;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error getting customers for user ID: {userId}", ex);
                throw;
            }
        }

        public async Task<int> GetProjectAssociationsByCustomerIdAsync(string customerId)
        {
            try
            {
                _CustomerProjectAssociations.Clear();
                GetProjectAssociationsByCustomerIdRequest request = new GetProjectAssociationsByCustomerIdRequest();
                request.CustomerId = customerId;
                GetProjectAssociationsByCustomerIdResponse response = await _RfqModuleClient.GetProjectAssociationsByCustomerIdAsync(request);
                _Logger.GenericLogInformation($"GetProjectAssociationsByCustomerId completed successfully for customer: {customerId}. Retrieved {response.ProjectAssociation.Count} associations");
                
                foreach (ProjectAssociation? association in response.ProjectAssociation)
                {
                    CustomerProjectUx? projectAssociation = association.ToCustomerProjectUx();
                    if (null == projectAssociation)
                    {
                        continue;
                    }

                    _CustomerProjectAssociations.Add(projectAssociation);
                }

                return _CustomerProjectAssociations.Count;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error getting project associations for customer ID: {customerId}", ex);
                throw;
            }
        }

        public async Task<int> GetRfqReasonsAsync()
        {
            GetRfqReasonsGrpcRequest request = new GetRfqReasonsGrpcRequest();
            request.RequestType = 1; // read

            try
            {
                GetRfqReasonsGrpcResponse response = await _RfqModuleClient.GetRfqReasonsGrpcAsync(request);
                _Logger.GenericLogInformation($"GetRfqReasons completed successfully. Retrieved {response.RfqReasons.Count} reasons");
                _Reasons.Clear();
                _Reasons.AddRange(response.RfqReasons);
                return _Reasons.Count;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error getting RFQ reasons with requestType: {request.RequestType}", ex);
                throw;
            }
        }

        public async Task<UploadPartsRequestGrpcResponse> UploadPartsAsync(string projectId, IBrowserFile file, long maxAllowedSize = 10_000_000)
        {
            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                await file.OpenReadStream(maxAllowedSize: maxAllowedSize).CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                UploadPartsRequestGrpcRequest request = new UploadPartsRequestGrpcRequest();
                request.ProjectId = projectId;
                request.FileName = file.Name;
                request.FileData = Google.Protobuf.ByteString.CopyFrom(fileBytes);

                UploadPartsRequestGrpcResponse response = await _RfqModuleClient.UploadPartsGrpcAsync(request);
                _Logger.GenericLogInformation($"UploadParts completed successfully for project: {projectId}, file: {file.Name}");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error uploading parts file: {file?.Name} for project: {projectId}", ex);
                throw;
            }
        }

        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectAsync(RfqProject project)
        {
            try
            {
                CreateRfqProjectGrpcRequest request = new CreateRfqProjectGrpcRequest();
                request.Project = project;
                CreateRfqProjectGrpcResponse response = await _RfqModuleClient.CreateRfqProjectGrpcAsync(request);
                _Logger.GenericLogInformation($"CreateRfqProject completed successfully. Created project ID: {response.CreatedProjectId}");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error creating RFQ project", ex);
                throw;
            }
        }

        public async Task<CreateRfqProjectGrpcResponse> CreateRfqProjectAsync(
            CustomerGrpc customer,
            CustomerProjectUx project,
            RfqReasonGrpc reason,
            int vehicleVolume,
            DateTime responseDeadline)
        {
            try
            {
                if (reason.RowId == null)
                {
                    throw new ArgumentException("RFQ reason must have a valid RowId", nameof(reason));
                }

                RfqProject rfqProject = new RfqProject();
                rfqProject.CustomerBusinessUnitGuid = customer.Id;
                rfqProject.CustomerLocationGuid = project.CustomerId;
                rfqProject.ProjectGuid = project.ProjectId;
                rfqProject.RfqReasonId = (int)reason.RowId;
                rfqProject.VehicleVolume = vehicleVolume;
                rfqProject.RfqResponseDeadline = responseDeadline.ToUniversalTime().ToTimestamp();

                CreateRfqProjectGrpcResponse response = await CreateRfqProjectAsync(rfqProject);
                _Logger.GenericLogInformation($"CreateRfqProject with UX models completed successfully. Created project ID: {response.CreatedProjectId}");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error creating RFQ project", ex);
                throw;
            }
        }

        public async Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeAsync(string projectCode)
        {
            try
            {
                GetVehicleByProjectCodeGrpcRequest request = new GetVehicleByProjectCodeGrpcRequest();
                request.ProjectCode = projectCode;
                GetVehicleByProjectCodeGrpcResponse response = await _RfqModuleClient.GetVehicleByProjectCodeGrpcAsync(request);
                _Logger.GenericLogInformation($"GetVehiclesByProjectCode completed successfully for project code: {projectCode}. Retrieved {response.Vehicles.Count} vehicles");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error getting vehicles for project code: {projectCode}", ex);
                throw;
            }
        }

        public async Task<FileUploadResponse> UploadFileAsync(IBrowserFile file, long maxAllowedSize = 10_000_000)
        {
            try
            {
                using MemoryStream memoryStream = new MemoryStream();
                await file.OpenReadStream(maxAllowedSize: maxAllowedSize).CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                FileUploadRequest request = new FileUploadRequest();
                request.FileName = file.Name;
                request.FileData = Google.Protobuf.ByteString.CopyFrom(fileBytes);

                FileUploadResponse response = await _RfqModuleClient.UploadFileAsync(request);
                _Logger.GenericLogInformation($"UploadFile completed successfully for file: {file.Name}");
                return response;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error uploading file: {file?.Name}", ex);
                throw;
            }
        }
    }
}