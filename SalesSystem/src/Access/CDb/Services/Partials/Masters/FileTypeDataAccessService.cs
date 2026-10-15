namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateFileTypeData(CancellationToken cancellationToken)
        {
            if (!_FileTypeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryFileTypeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetFileTypesQuery, List<FileTypeGrpc>>>();
                    _FileTypeRefreshInProgress = true;
                    GetFileTypesQuery query = new GetFileTypesQuery();
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

        public async Task<ListFileTypeGrpc> ReadAllFileTypes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_FileTypeGrpcs.FileTypeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _FileTypeGrpcs;
                }

                ListFileTypeGrpc returnList = new ListFileTypeGrpc();
                IQueryable<FileTypeGrpc> query = _FileTypeGrpcs.FileTypeGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.FileTypeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateFileTypeData(cancellationToken);
            return _FileTypeGrpcs;
        }

        public async Task<bool> CreateFileTypes(FileTypeGrpcRequest request, CancellationToken cancellationToken)
        {
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
