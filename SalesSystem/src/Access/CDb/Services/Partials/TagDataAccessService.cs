namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulateTagData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_TagRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryTagHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetTagsQuery, List<TagGrpc>>>();
                    _TagRefreshInProgress = true;
                    GetTagsQuery query = new GetTagsQuery();
                    await Task.Delay(1, cancellationToken);
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

        public async Task<ListTagGrpc> ReadAllTags(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_TagGrpcs.TagGrpcs.Any())
            {
                await PopulateTagData(cancellationToken);
            }

            return _TagGrpcs;
        }

        public async Task<ListTagGrpc> ReadManyTags(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TagRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_TagGrpcs.TagGrpcs.Any())
                    {
                        await PopulateTagData(cancellationToken);
                    }

                    _FilteredTagGrpcs.TagGrpcs.Clear();
                    List<TagGrpc> filteredList = _TagGrpcs.TagGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredTagGrpcs.TagGrpcs.AddRange(filteredList);
                    return _FilteredTagGrpcs;
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
                    if (!_TagGrpcs.TagGrpcs.Any())
                    {
                        await PopulateTagData(cancellationToken);
                    }

                    _FilteredTagGrpcs.TagGrpcs.Clear();
                    List<TagGrpc> filteredList = _TagGrpcs.TagGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredTagGrpcs.TagGrpcs.AddRange(filteredList);
                    return _FilteredTagGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListTagGrpc> ReadTagById(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "TagRequest or GrpcRequestParameter cannot be null.");
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
                status = new Status(StatusCode.InvalidArgument, "Request type must be ReadById to get a tag type by ID.");
                throw new RpcException(status);
            }

            Guid id = request.GrpcRequestParameter.StringValue != null ? Guid.Parse(request.GrpcRequestParameter.StringValue) : Guid.Empty;
            if (id == Guid.Empty)
            {
                status = new Status(StatusCode.InvalidArgument, "Invalid ID parameter value.");
                throw new RpcException(status);
            }

            await Task.Delay(1, cancellationToken);
            if (!_TagGrpcs.TagGrpcs.Any())
            {
                await PopulateTagData(cancellationToken);
            }

            _FilteredTagGrpcs.TagGrpcs.Clear();
            List<TagGrpc> filteredList = _TagGrpcs.TagGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredTagGrpcs.TagGrpcs.AddRange(filteredList);
            return _FilteredTagGrpcs;
        }

        public async Task<bool> CreateTags(TagGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

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
            await Task.Delay(1, cancellationToken);

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
            await Task.Delay(1, cancellationToken);

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
