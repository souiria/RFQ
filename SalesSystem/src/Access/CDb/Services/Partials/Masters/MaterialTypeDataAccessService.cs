using CDb.CQRS.Command.Masters.MaterialType;
using CDb.CQRS.Query.Masters.MaterialType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateMaterialTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialTypesQuery, List<MaterialTypeGrpc>>>();
                    _MaterialTypeRefreshInProgress = true;
                    GetMaterialTypesQuery query = new GetMaterialTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialTypeGrpc>> results = await _QueryMaterialTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.AddRange(results.Value);
                    }

                    _MaterialTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListMaterialTypeGrpc> ReadAllMaterialTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_MaterialTypeGrpcs.MaterialTypeGrpcs.Any())
            {
                await PopulateMaterialTypeData(cancellationToken);
            }

            return _MaterialTypeGrpcs;
        }

        public async Task<ListMaterialTypeGrpc> ReadManyMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            // either all actives or non actives
            switch (requestType)
            {
                case RequestType.ReadByIsActive:
                {
                    bool isActive = request.GrpcRequestParameter.BoolValue ?? false;
                    await Task.Delay(1, cancellationToken);
                    if (!_MaterialTypeGrpcs.MaterialTypeGrpcs.Any())
                    {
                        await PopulateMaterialTypeData(cancellationToken);
                    }

                    _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                    List<MaterialTypeGrpc> filteredList = _MaterialTypeGrpcs.MaterialTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.AddRange(filteredList);
                    return _FilteredMaterialTypeGrpcs;
                }
                case RequestType.ReadByCode:
                {
                    string code = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(code))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_MaterialTypeGrpcs.MaterialTypeGrpcs.Any())
                    {
                        await PopulateMaterialTypeData(cancellationToken);
                    }

                    _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                    List<MaterialTypeGrpc> filteredList = _MaterialTypeGrpcs.MaterialTypeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.AddRange(filteredList);
                    return _FilteredMaterialTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListMaterialTypeGrpc> ReadMaterialTypeById(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeRequest or GrpcRequestParameter cannot be null.");
            }

            RequestType requestType = RequestType.None;

            if (System.Enum.IsDefined(typeof(RequestType), request.GrpcRequestParameter.RequestType))
            {
                requestType = (RequestType)request.GrpcRequestParameter.RequestType;
            }
            else
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid request type parameter value.");
                throw new RpcException(status);
            }

            if (requestType != RequestType.ReadById)
            {
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a compositeComponent type by ID.");
                throw new RpcException(status);
            }

            Guid id = request.GrpcRequestParameter.StringValue != null ? Guid.Parse(request.GrpcRequestParameter.StringValue) : Guid.Empty;
            if (id == Guid.Empty)
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid ID parameter value.");
                throw new RpcException(status);
            }

            await Task.Delay(1, cancellationToken);
            if (!_MaterialTypeGrpcs.MaterialTypeGrpcs.Any())
            {
                await PopulateMaterialTypeData(cancellationToken);
            }

            _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
            List<MaterialTypeGrpc> filteredList = _MaterialTypeGrpcs.MaterialTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredMaterialTypeGrpcs.MaterialTypeGrpcs.AddRange(filteredList);
            return _FilteredMaterialTypeGrpcs;
        }

        public async Task<bool> CreateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.MaterialTypeGrpcsToCreate == null || request.MaterialTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeGrpcRequest or MaterialTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MaterialTypeCommand>>();
                    MaterialTypeCommand command = new MaterialTypeCommand(CommandType.Create, request.MaterialTypeGrpcsToCreate);

                    Result result = await _CommandMaterialTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MaterialTypeRefreshInProgress = true;
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateMaterialTypes(MaterialTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.MaterialTypeGrpcsToUpdate == null || request.MaterialTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "MaterialTypeGrpcRequest or MaterialTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_MaterialTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandMaterialTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<MaterialTypeCommand>>();
                    MaterialTypeCommand command = new MaterialTypeCommand(CommandType.Update, request.MaterialTypeGrpcsToUpdate);

                    Result result = await _CommandMaterialTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _MaterialTypeRefreshInProgress = true;
                        _MaterialTypeGrpcs.MaterialTypeGrpcs.Clear();
                        _MaterialTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
