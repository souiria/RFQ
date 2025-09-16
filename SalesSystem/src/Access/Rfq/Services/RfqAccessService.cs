namespace Rfq.Services
{
    public partial class RfqAccessService : IRfqAccessService
    {
        #region In Memory Datasets

        #region RfqDrawingPartNumbers

        ListRfqDrawingPartNumbersGrpc _ListRfqDrawingPartNumbers;
        #endregion

        #region RfqProject
        ListRfqProjectGrpc _ListRfqProjects;
        #endregion

        #region RfqNotes
        ListRfqNotesGrpc _ListRfqNotes;
        #endregion

        #region RfqReason
        ListRfqReasonGrpc _ListRfqReasons;
        #endregion

        #endregion

        #region Fields and Properties

        #region RfqDrawingPartNumbers

        IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumbersGrpc>>? _RfqDrawingPartNumbersHandler;
        bool _RfqDrawingPartNumbersRefreshInProgress;

        #endregion

        #region RfqProject

        IQueryHandler<GetRfqProjectQuery, List<RfqProjectGrpc>>? _RfqProjectHandler;
        bool _RfqProjectRefreshInProgress;

        #endregion

        #region RfqNotes

        IQueryHandler<GetRfqNotesQuery, List<RfqNotesGrpc>>? _RfqNotesHandler;
        bool _RfqNotesRefreshInProgress;

        #endregion

        #region RfqReason

        IQueryHandler<GetRfqReasonQuery, List<RfqReasonGrpc>>? _RfqReasonHandler;
        bool _RfqReasonRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public RfqAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region RfqDrawingPartNumbers

            _ListRfqDrawingPartNumbers = new ListRfqDrawingPartNumbersGrpc();
            _RfqDrawingPartNumbersRefreshInProgress = false;

            #endregion

            #region RfqProject

            _ListRfqProjects = new ListRfqProjectGrpc();
            _RfqProjectRefreshInProgress = false;

            #endregion

            #region RfqNotes

            _ListRfqNotes = new ListRfqNotesGrpc();
            _RfqNotesRefreshInProgress = false;

            #endregion

            #region RfqReason

            _ListRfqReasons = new ListRfqReasonGrpc();
            _RfqReasonRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region RfqDrawingPartNumbers
        public async Task<ListRfqDrawingPartNumbersGrpc> GetAllRfqDrawingPartNumbers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.Any())
            {
                return _ListRfqDrawingPartNumbers;
            }
            else
            {
                await PopulateRfqDrawingPartNumbers(cancellationToken);
                return _ListRfqDrawingPartNumbers;
            }
        }

        public async Task<ListRfqDrawingPartNumbersGrpc> GetRfqDrawingPartNumbersByRowId(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.Any())
            {
            }
            else
            {
                await PopulateRfqDrawingPartNumbers(cancellationToken);
            }

            ListRfqDrawingPartNumbersGrpc responseList = new ListRfqDrawingPartNumbersGrpc();
            List<RfqDrawingPartNumbersGrpc> projects = _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (projects != null)
            {
                responseList.RfqDrawingPartNumbers.AddRange(projects);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListRfqDrawingPartNumbersGrpc> CreateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqDrawingPartNumbersGrpc responseList = new ListRfqDrawingPartNumbersGrpc();
            if (request == null || request.RfqDrawingPartNumbersGrpcsToCreate == null || request.RfqDrawingPartNumbersGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>>();
                RfqDrawingPartNumberCommand command = new RfqDrawingPartNumberCommand(CommandType.Create, request.RfqDrawingPartNumbersGrpcsToCreate);
                Result<List<DbRfqDrawingPartNumber>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqDrawingPartNumber> createdComponents = result.Value;
                    List<RfqDrawingPartNumbersGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.AddRange(updatedGrpcComponents);
                    responseList.RfqDrawingPartNumbers.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqDrawingPartNumbersGrpc responseList = new ListRfqDrawingPartNumbersGrpc();
            if (request == null || request.RfqDrawingPartNumbersGrpcsToUpdate == null || request.RfqDrawingPartNumbersGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>>();
                RfqDrawingPartNumberCommand command = new RfqDrawingPartNumberCommand(CommandType.Update, request.RfqDrawingPartNumbersGrpcsToUpdate);
                Result<List<DbRfqDrawingPartNumber>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqDrawingPartNumbersGrpc updatedComponent in request.RfqDrawingPartNumbersGrpcsToUpdate)
                    {
                        RfqDrawingPartNumbersGrpc? foundItem = _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if(foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region RfqProject
        public async Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqProjects.RfqProjects.Any())
            {
                return _ListRfqProjects;
            }
            else
            {
                await PopulateRfqProjects(cancellationToken);
                return _ListRfqProjects;
            }
        }

        public async Task<ListRfqProjectGrpc> GetRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqProjects.RfqProjects.Any())
            {
            }
            else
            {
                await PopulateRfqProjects(cancellationToken);
            }

            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();
            List<RfqProjectGrpc> projects = _ListRfqProjects.RfqProjects.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (projects != null)
            {
                responseList.RfqProjects.AddRange(projects);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();
            if (request == null || request.RfqProjectGrpcsToCreate == null || request.RfqProjectGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqProjectCommand, List<DbRfqProject>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqProjectCommand, List<DbRfqProject>>>();
                RfqProjectCommand command = new RfqProjectCommand(CommandType.Create, request.RfqProjectGrpcsToCreate);
                Result<List<DbRfqProject>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqProject> createdProjects = result.Value;
                    List<RfqProjectGrpc> updatedGrpcProjects = createdProjects.Select(p => p.FromEntity()).ToList();
                    _ListRfqProjects.RfqProjects.AddRange(updatedGrpcProjects);
                    responseList.RfqProjects.AddRange(updatedGrpcProjects);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();
            if (request == null || request.RfqProjectGrpcsToUpdate == null || request.RfqProjectGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqProjectCommand, List<DbRfqProject>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqProjectCommand, List<DbRfqProject>>>();
                RfqProjectCommand command = new RfqProjectCommand(CommandType.Update, request.RfqProjectGrpcsToUpdate);
                Result<List<DbRfqProject>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqProjectGrpc updatedComponent in request.RfqProjectGrpcsToUpdate)
                    {
                        RfqProjectGrpc? foundItem = _ListRfqProjects.RfqProjects.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqProjects.RfqProjects.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqProjects.RfqProjects[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region RfqNotes

        public async Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqNotes.RfqNotes.Any())
            {
                return _ListRfqNotes;
            }
            else
            {
                await PopulateRfqNotes(cancellationToken);
                return _ListRfqNotes;
            }
        }

        public async Task<ListRfqNotesGrpc> GetRfqNotesByRowId(RfqNotesGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqNotes.RfqNotes.Any())
            {
            }
            else
            {
                await PopulateRfqNotes(cancellationToken);
            }

            ListRfqNotesGrpc responseList = new ListRfqNotesGrpc();
            List<RfqNotesGrpc> projects = _ListRfqNotes.RfqNotes.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (projects != null)
            {
                responseList.RfqNotes.AddRange(projects);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqNotesGrpc responseList = new ListRfqNotesGrpc();
            if (request == null || request.RfqNotesGrpcsToCreate == null || request.RfqNotesGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNotesCommand, List<DbRfqNotes>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNotesCommand, List<DbRfqNotes>>>();
                RfqNotesCommand command = new RfqNotesCommand(CommandType.Create, request.RfqNotesGrpcsToCreate);
                Result<List<DbRfqNotes>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqNotes> createdComponents = result.Value;
                    List<RfqNotesGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqNotes.RfqNotes.AddRange(updatedGrpcComponents);
                    responseList.RfqNotes.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqNotesGrpc responseList = new ListRfqNotesGrpc();
            if (request == null || request.RfqNotesGrpcsToUpdate == null || request.RfqNotesGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNotesCommand, List<DbRfqNotes>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNotesCommand, List<DbRfqNotes>>>();
                RfqNotesCommand command = new RfqNotesCommand(CommandType.Update, request.RfqNotesGrpcsToUpdate);
                Result<List<DbRfqNotes>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqNotesGrpc updatedComponent in request.RfqNotesGrpcsToUpdate)
                    {
                        RfqNotesGrpc? foundItem = _ListRfqNotes.RfqNotes.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqNotes.RfqNotes.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqNotes.RfqNotes[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region RfqReason

        public async Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasons.RfqReasons.Any())
            {
                return _ListRfqReasons;
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
                return _ListRfqReasons;
            }
        }

        public async Task<ListRfqReasonGrpc> GetRfqReasonsByRowId(RfqReasonGrpcRequest reason, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasons.RfqReasons.Any())
            {
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
            }

            ListRfqReasonGrpc responseList = new ListRfqReasonGrpc();
            List<RfqReasonGrpc> projects = _ListRfqReasons.RfqReasons.Where(x => x.RowId == reason.GrpcRequestParameter.IntValue).ToList();
            if (projects != null)
            {
                responseList.RfqReasons.AddRange(projects);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqReasonGrpc responseList = new ListRfqReasonGrpc();
            if (request == null || request.RfqReasonGrpcsToCreate == null || request.RfqReasonGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqReasonCommand, List<DbRfqReason>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqReasonCommand, List<DbRfqReason>>>();
                RfqReasonCommand command = new RfqReasonCommand(CommandType.Create, request.RfqReasonGrpcsToCreate);
                Result<List<DbRfqReason>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqReason> createdComponents = result.Value;
                    List<RfqReasonGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqReasons.RfqReasons.AddRange(updatedGrpcComponents);
                    responseList.RfqReasons.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqReasonGrpc responseList = new ListRfqReasonGrpc();
            if (request == null || request.RfqReasonGrpcsToUpdate == null || request.RfqReasonGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqReasonCommand, List<DbRfqReason>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqReasonCommand, List<DbRfqReason>>>();
                RfqReasonCommand command = new RfqReasonCommand(CommandType.Update, request.RfqReasonGrpcsToUpdate);
                Result<List<DbRfqReason>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqReasonGrpc updatedComponent in request.RfqReasonGrpcsToUpdate)
                    {
                        RfqReasonGrpc? foundItem = _ListRfqReasons.RfqReasons.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqReasons.RfqReasons.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqReasons.RfqReasons[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion 

        #endregion

        #region Data Imports

        #region RfqDrawingPartNumbers
        public async Task<bool> PopulateRfqDrawingPartNumbers(CancellationToken cancellationToken)
        {
            if (!_RfqDrawingPartNumbersRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqDrawingPartNumbersHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumbersGrpc>>>();
                    _RfqDrawingPartNumbersRefreshInProgress = true;
                    GetRfqDrawingPartNumberQuery query = new GetRfqDrawingPartNumberQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqDrawingPartNumbersGrpc>> results = await _RfqDrawingPartNumbersHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.Clear();
                        _ListRfqDrawingPartNumbers.RfqDrawingPartNumbers.AddRange(results.Value);
                    }

                    _RfqDrawingPartNumbersRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqAccessService
        public async Task<bool> PopulateRfqProjects(CancellationToken cancellationToken)
        {
            if (!_RfqProjectRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqProjectHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqProjectQuery, List<RfqProjectGrpc>>>();
                    _RfqProjectRefreshInProgress = true;
                    GetRfqProjectQuery query = new GetRfqProjectQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqProjectGrpc>> results = await _RfqProjectHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqProjects.RfqProjects.Clear();
                        _ListRfqProjects.RfqProjects.AddRange(results.Value);
                    }

                    _RfqProjectRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqNotes
        public async Task<bool> PopulateRfqNotes(CancellationToken cancellationToken)
        {
            if (!_RfqNotesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqNotesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqNotesQuery, List<RfqNotesGrpc>>>();
                    _RfqNotesRefreshInProgress = true;
                    GetRfqNotesQuery query = new GetRfqNotesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqNotesGrpc>> results = await _RfqNotesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqNotes.RfqNotes.Clear();
                        _ListRfqNotes.RfqNotes.AddRange(results.Value);
                    }

                    _RfqNotesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqReason

        public async Task<bool> PopulateRfqReasons(CancellationToken cancellationToken)
        {
            if (!_RfqReasonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqReasonHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqReasonQuery, List<RfqReasonGrpc>>>();
                    _RfqReasonRefreshInProgress = true;
                    GetRfqReasonQuery query = new GetRfqReasonQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqReasonGrpc>> results = await _RfqReasonHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqReasons.RfqReasons.Clear();
                        _ListRfqReasons.RfqReasons.AddRange(results.Value);
                    }

                    _RfqReasonRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #endregion

        void PopulateSampleData()
        {
            _ListRfqDrawingPartNumbers = SampleRfqDataService.PopulateRfqDrawingPartNumbersGrpc();
            _ListRfqProjects = SampleRfqDataService.PopulateRfqProjectGrpc();
            _ListRfqNotes = SampleRfqDataService.PopulateRfqNotesGrpc();
            _ListRfqReasons = SampleRfqDataService.PopulateRfqReasonGrpc();
        }
    }
}
