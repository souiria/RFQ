using CDb.CQRS.Command.Masters.FileType;
using CDb.CQRS.Query.Masters.FileType;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateFileTypeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_FileTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryFileTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetFileTypesQuery, List<FileTypeGrpc>>>();
                    _FileTypeRefreshInProgress = true;
                    GetFileTypesQuery query = new GetFileTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<FileTypeGrpc>> results = await _QueryFileTypeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _FileTypeGrpcs.FileTypeGrpcs.Clear();
                        _FileTypeGrpcs.FileTypeGrpcs.AddRange(results.Value);
                    }

                    _FileTypeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListFileTypeGrpc> ReadAllFileTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_FileTypeGrpcs.FileTypeGrpcs.Any())
            {
                await PopulateFileTypeData(cancellationToken);
            }

            return _FileTypeGrpcs;
        }

        public async Task<ListFileTypeGrpc> ReadManyFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "FileTypeRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_FileTypeGrpcs.FileTypeGrpcs.Any())
                    {
                        await PopulateFileTypeData(cancellationToken);
                    }

                    _FilteredFileTypeGrpcs.FileTypeGrpcs.Clear();
                    List<FileTypeGrpc> filteredList = _FileTypeGrpcs.FileTypeGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredFileTypeGrpcs.FileTypeGrpcs.AddRange(filteredList);
                    return _FilteredFileTypeGrpcs;
                }
                case RequestType.ReadByName:
                {
                    string name = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(name))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_FileTypeGrpcs.FileTypeGrpcs.Any())
                    {
                        await PopulateFileTypeData(cancellationToken);
                    }

                    _FilteredFileTypeGrpcs.FileTypeGrpcs.Clear();
                    List<FileTypeGrpc> filteredList = _FileTypeGrpcs.FileTypeGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredFileTypeGrpcs.FileTypeGrpcs.AddRange(filteredList);
                    return _FilteredFileTypeGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListFileTypeGrpc> ReadFileTypeById(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "FileTypeRequest or GrpcRequestParameter cannot be null.");
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
            if (!_FileTypeGrpcs.FileTypeGrpcs.Any())
            {
                await PopulateFileTypeData(cancellationToken);
            }

            _FilteredFileTypeGrpcs.FileTypeGrpcs.Clear();
            List<FileTypeGrpc> filteredList = _FileTypeGrpcs.FileTypeGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredFileTypeGrpcs.FileTypeGrpcs.AddRange(filteredList);
            return _FilteredFileTypeGrpcs;
        }

        public async Task<bool> CreateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.FileTypeGrpcsToCreate == null || request.FileTypeGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FileTypeGrpcRequest or FileTypeGrpcsToCreate cannot be null or empty.");
            }

            if (!_FileTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFileTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FileTypeCommand>>();
                    FileTypeCommand command = new FileTypeCommand(CommandType.Create, request.FileTypeGrpcsToCreate);

                    Result result = await _CommandFileTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FileTypeRefreshInProgress = true;
                        _FileTypeGrpcs.FileTypeGrpcs.Clear();
                        _FileTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.FileTypeGrpcsToUpdate == null || request.FileTypeGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FileTypeGrpcRequest or FileTypeGrpcsToUpdate cannot be null or empty.");
            }

            if (!_FileTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFileTypeHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FileTypeCommand>>();
                    FileTypeCommand command = new FileTypeCommand(CommandType.Update, request.FileTypeGrpcsToUpdate);

                    Result result = await _CommandFileTypeHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FileTypeRefreshInProgress = true;
                        _FileTypeGrpcs.FileTypeGrpcs.Clear();
                        _FileTypeRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
