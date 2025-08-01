using CDb.CQRS.Command.Masters.Person;
using CDb.CQRS.Query.Masters.Person;

namespace CDb.Services
{
    public partial class CDbAccessService : ICDbAccessService
    {
        async Task<bool> PopulatePersonData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _QueryPersonHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPersonsQuery, List<PersonGrpc>>>();
                    _PersonRefreshInProgress = true;
                    GetPersonsQuery query = new GetPersonsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PersonGrpc>> results = await _QueryPersonHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {

                    }
                    else
                    {
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonGrpcs.PersonGrpcs.AddRange(results.Value);
                    }

                    _PersonRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<ListPersonGrpc> ReadAllPersons(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (!_PersonGrpcs.PersonGrpcs.Any())
            {
                await PopulatePersonData(cancellationToken);
            }

            return _PersonGrpcs;
        }

        public async Task<ListPersonGrpc> ReadManyPersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PersonRequest or GrpcRequestParameter cannot be null.");
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
                    if (!_PersonGrpcs.PersonGrpcs.Any())
                    {
                        await PopulatePersonData(cancellationToken);
                    }

                    _FilteredPersonGrpcs.PersonGrpcs.Clear();
                    List<PersonGrpc> filteredList = _PersonGrpcs.PersonGrpcs.Where(x => x.IsActive == isActive).ToList();
                    _FilteredPersonGrpcs.PersonGrpcs.AddRange(filteredList);
                    return _FilteredPersonGrpcs;
                }
                case RequestType.ReadByCode:
                {
                    string name = request.GrpcRequestParameter.StringValue;
                    if (string.IsNullOrEmpty(name))
                    {
                        status = new Status(StatusCode.InvalidArgument, "Invalid StringValue parameter value.");
                        throw new RpcException(status);
                    }

                    await Task.Delay(1, cancellationToken);
                    if (!_PersonGrpcs.PersonGrpcs.Any())
                    {
                        await PopulatePersonData(cancellationToken);
                    }

                    _FilteredPersonGrpcs.PersonGrpcs.Clear();
                    List<PersonGrpc> filteredList = _PersonGrpcs.PersonGrpcs.Where(x => x.Name == name).ToList();
                    _FilteredPersonGrpcs.PersonGrpcs.AddRange(filteredList);
                    return _FilteredPersonGrpcs;
                }
                default:
                status = new Status(StatusCode.InvalidArgument, "Unsupported request type.");
                throw new RpcException(status);
            }
        }

        public async Task<ListPersonGrpc> ReadPersonById(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            Status status;
            await Task.Delay(1, cancellationToken);

            if (request == null || request.GrpcRequestParameter == null)
            {
                throw new ArgumentNullException(nameof(request), "PersonRequest or GrpcRequestParameter cannot be null.");
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
            if (!_PersonGrpcs.PersonGrpcs.Any())
            {
                await PopulatePersonData(cancellationToken);
            }

            _FilteredPersonGrpcs.PersonGrpcs.Clear();
            List<PersonGrpc> filteredList = _PersonGrpcs.PersonGrpcs.Where(x => x.Id == id.ToString()).ToList();
            _FilteredPersonGrpcs.PersonGrpcs.AddRange(filteredList);
            return _FilteredPersonGrpcs;
        }

        public async Task<bool> CreatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PersonGrpcsToCreate == null || request.PersonGrpcsToCreate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PersonGrpcRequest or PersonGrpcsToCreate cannot be null or empty.");
            }

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPersonHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PersonCommand>>();
                    PersonCommand command = new PersonCommand(CommandType.Create, request.PersonGrpcsToCreate);

                    Result result = await _CommandPersonHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PersonRefreshInProgress = true;
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UpdatePersons(PersonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);

            if (request == null || request.PersonGrpcsToUpdate == null || request.PersonGrpcsToUpdate.Count == 0)
            {
                throw new ArgumentNullException(nameof(request), "PersonGrpcRequest or PersonGrpcsToUpdate cannot be null or empty.");
            }

            if (!_PersonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CommandPersonHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<PersonCommand>>();
                    PersonCommand command = new PersonCommand(CommandType.Update, request.PersonGrpcsToUpdate);

                    Result result = await _CommandPersonHandler.Handle(command, cancellationToken);
                    if (result.IsSuccess)
                    {
                        // invalidate the cache
                        _PersonRefreshInProgress = true;
                        _PersonGrpcs.PersonGrpcs.Clear();
                        _PersonRefreshInProgress = false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
