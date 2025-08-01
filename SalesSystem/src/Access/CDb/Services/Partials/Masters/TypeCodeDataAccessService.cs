using CDb.CQRS.Command.Masters.TypeCode;
using CDb.CQRS.Query.Masters.TypeCode;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTypeCodeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTypeCodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTypeCodesQuery, List<TypeCodeGrpc>>>();
                    _TypeCodeRefreshInProgress = true;
                    GetTypeCodesQuery query = new GetTypeCodesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<TypeCodeGrpc>> results = await _QueryTypeCodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeGrpcs.TypeCodeGrpcs.AddRange(results.Value);
                    }

                    _TypeCodeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTypeCodeGrpc> ReadAllTypeCodes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TypeCodeGrpcs.TypeCodeGrpcs.Any())
            {
                await PopulateTypeCodeData(cancellationToken);
            }

            return _TypeCodeGrpcs;
        }

        public async Task<ListTypeCodeGrpc> ReadManyTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_TypeCodeGrpcs.TypeCodeGrpcs.Any())
                    {
                        await PopulateTypeCodeData(cancellationToken);
                    }

                    _FilteredTypeCodeGrpcs.TypeCodeGrpcs.Clear();
                    List<TypeCodeGrpc> filteredList = _TypeCodeGrpcs.TypeCodeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredTypeCodeGrpcs.TypeCodeGrpcs.AddRange(filteredList);
                    return _FilteredTypeCodeGrpcs;
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
                    if (!_TypeCodeGrpcs.TypeCodeGrpcs.Any())
                    {
                        await PopulateTypeCodeData(cancellationToken);
                    }

                    _FilteredTypeCodeGrpcs.TypeCodeGrpcs.Clear();
                    List<TypeCodeGrpc> filteredList = _TypeCodeGrpcs.TypeCodeGrpcs.Where(x => x.Code == code).ToList();
                    _FilteredTypeCodeGrpcs.TypeCodeGrpcs.AddRange(filteredList);
                    return _FilteredTypeCodeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListTypeCodeGrpc> ReadTypeCodeById(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_TypeCodeGrpcs.TypeCodeGrpcs.Any())
            {
                await PopulateTypeCodeData(cancellationToken);
            }

            _FilteredTypeCodeGrpcs.TypeCodeGrpcs.Clear();
            List<TypeCodeGrpc> filteredList = _TypeCodeGrpcs.TypeCodeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredTypeCodeGrpcs.TypeCodeGrpcs.AddRange(filteredList);
            return _FilteredTypeCodeGrpcs;
        }

        public async Task<bool> CreateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TypeCodeGrpcsToCreate == null || request.TypeCodeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeGrpcRequest or TypeCodeGrpcsToCreate cannot be null or empty.");
            }

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTypeCodeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TypeCodeCommand>>();
                    TypeCodeCommand command = new TypeCodeCommand(CommandType.Create, request.TypeCodeGrpcsToCreate);

                    Result result = await _CommandTypeCodeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TypeCodeRefreshInProgress = true;
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTypeCodes(TypeCodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.TypeCodeGrpcsToUpdate == null || request.TypeCodeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TypeCodeGrpcRequest or TypeCodeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TypeCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTypeCodeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TypeCodeCommand>>();
                    TypeCodeCommand command = new TypeCodeCommand(CommandType.Update, request.TypeCodeGrpcsToUpdate);

                    Result result = await _CommandTypeCodeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TypeCodeRefreshInProgress = true;
                        _TypeCodeGrpcs.TypeCodeGrpcs.Clear();
                        _TypeCodeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
