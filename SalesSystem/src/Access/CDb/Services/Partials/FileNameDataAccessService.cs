namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateFileNameData(CancellationToken cancellationToken)
        {
            if (!_FileNameRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryFileNameHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetFileNamesQuery, List<FileNameGrpc>>>();
                    _FileNameRefreshInProgress = true;
                    GetFileNamesQuery query = new GetFileNamesQuery();
                    Result<List<FileNameGrpc>> results = await _QueryFileNameHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _FileNameGrpcs.FileNameGrpcs.Clear();
                        _FileNameGrpcs.FileNameGrpcs.AddRange(results.Value);
                    }

                    _FileNameRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListFileNameGrpc> ReadAllFileNames(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_FileNameGrpcs.FileNameGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _FileNameGrpcs;
                }

                ListFileNameGrpc returnList = new ListFileNameGrpc();
                IQueryable<FileNameGrpc> query = _FileNameGrpcs.FileNameGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.FileNameGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateFileNameData(cancellationToken);
            return _FileNameGrpcs;
        }

        public async Task<bool> CreateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.FileNameGrpcsToCreate == null || request.FileNameGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FileNameGrpcRequest or FileNameGrpcsToCreate cannot be null or empty.");
            }

            if (!_FileNameRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFileNameHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FileNameCommand>>();
                    FileNameCommand command = new FileNameCommand(CommandType.Create, request.FileNameGrpcsToCreate);

                    Result result = await _CommandFileNameHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FileNameRefreshInProgress = true;
                        _FileNameGrpcs.FileNameGrpcs.Clear();
                        _FileNameRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.FileNameGrpcsToUpdate == null || request.FileNameGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FileNameGrpcRequest or FileNameGrpcsToUpdate cannot be null or empty.");
            }

            if (!_FileNameRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFileNameHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FileNameCommand>>();
                    FileNameCommand command = new FileNameCommand(CommandType.Update, request.FileNameGrpcsToUpdate);

                    Result result = await _CommandFileNameHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FileNameRefreshInProgress = true;
                        _FileNameGrpcs.FileNameGrpcs.Clear();
                        _FileNameRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
        public async Task<bool> DeleteFileNames(FileNameGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.FileNameGrpcsToDelete == null || request.FileNameGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "FileNameGrpcRequest or FileNameGrpcsToDelete cannot be null or empty.");
            }

            if (!_FileNameRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandFileNameHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<FileNameCommand>>();
                    FileNameCommand command = new FileNameCommand(CommandType.Delete, request.FileNameGrpcsToDelete);

                    Result result = await _CommandFileNameHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _FileNameRefreshInProgress = true;
                        _FileNameGrpcs.FileNameGrpcs.Clear();
                        _FileNameRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
