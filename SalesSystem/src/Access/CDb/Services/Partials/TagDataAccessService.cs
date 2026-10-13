namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTagData(CancellationToken cancellationToken)
        {
            if (!_TagRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTagHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTagsQuery, List<TagGrpc>>>();
                    _TagRefreshInProgress = true;
                    GetTagsQuery query = new GetTagsQuery();
                    Result<List<TagGrpc>> results = await _QueryTagHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _TagGrpcs.TagGrpcs.Clear();
                        _TagGrpcs.TagGrpcs.AddRange(results.Value);
                    }

                    _TagRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListTagGrpc> ReadAllTags(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_TagGrpcs.TagGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _TagGrpcs;
                }

                ListTagGrpc returnList = new ListTagGrpc();
                IQueryable<TagGrpc> query = _TagGrpcs.TagGrpcs.AsQueryable().Skip(position).Take(takeAmount);
                returnList.TagGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateTagData(cancellationToken);
            return _TagGrpcs;
        }

        public async Task<bool> CreateTags(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.TagGrpcsToCreate == null || request.TagGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TagGrpcRequest or TagGrpcsToCreate cannot be null or empty.");
            }

            if (!_TagRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTagHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TagCommand>>();
                    TagCommand command = new TagCommand(CommandType.Create, request.TagGrpcsToCreate);

                    Result result = await _CommandTagHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TagRefreshInProgress = true;
                        _TagGrpcs.TagGrpcs.Clear();
                        _TagRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdateTags(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.TagGrpcsToUpdate == null || request.TagGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TagGrpcRequest or TagGrpcsToUpdate cannot be null or empty.");
            }

            if (!_TagRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTagHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TagCommand>>();
                    TagCommand command = new TagCommand(CommandType.Update, request.TagGrpcsToUpdate);

                    Result result = await _CommandTagHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TagRefreshInProgress = true;
                        _TagGrpcs.TagGrpcs.Clear();
                        _TagRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
        public async Task<bool> DeleteTags(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            if (request == null || request.TagGrpcsToDelete == null || request.TagGrpcsToDelete.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "TagGrpcRequest or TagGrpcsToDelete cannot be null or empty.");
            }

            if (!_TagRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandTagHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TagCommand>>();
                    TagCommand command = new TagCommand(CommandType.Delete, request.TagGrpcsToDelete);

                    Result result = await _CommandTagHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _TagRefreshInProgress = true;
                        _TagGrpcs.TagGrpcs.Clear();
                        _TagRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
