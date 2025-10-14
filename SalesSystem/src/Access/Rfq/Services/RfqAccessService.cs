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

        #region DsiBend
        ListDsiBendGrpc _ListDsiBends;
        #endregion

        #region DsiBranchConfiguration
        ListDsiBranchConfigurationGrpc _ListDsiBranchConfigurations;
        #endregion

        #region DsiBranchConfigurationBendAssociation
        ListDsiBranchConfigurationBendAssociationGrpc _ListDsiBranchConfigurationBendAssociations;
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

        #region DsiBend
        IQueryHandler<GetDsiBendQuery, List<DsiBendGrpc>>? _DsiBendHandler;
        bool _DsiBendRefreshInProgress;
        #endregion

        #region DsiBranchConfiguration
        IQueryHandler<GetDsiBranchConfigurationQuery, List<DsiBranchConfigurationGrpc>>? _DsiBranchConfigurationHandler;
        bool _DsiBranchConfigurationRefreshInProgress;
        #endregion

        #region DsiBranchConfigurationBendAssociation
        IQueryHandler<GetDsiBranchConfigurationBendAssociationQuery, List<DsiBranchConfigurationBendAssociationGrpc>>? _DsiBranchConfigurationBendAssociationHandler;
        bool _DsiBranchConfigurationBendAssociationRefreshInProgress;
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

            #region DsiBend

            _ListDsiBends = new ListDsiBendGrpc();
            _DsiBendRefreshInProgress = false;

            #endregion

            #region DsiBranchConfiguration

            _ListDsiBranchConfigurations = new ListDsiBranchConfigurationGrpc();
            _DsiBranchConfigurationRefreshInProgress = false;

            #endregion

            #region DsiBranchConfigurationBendAssociation

            _ListDsiBranchConfigurationBendAssociations = new ListDsiBranchConfigurationBendAssociationGrpc();
            _DsiBranchConfigurationBendAssociationRefreshInProgress = false;

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

        #region DsiBend

        public async Task<ListDsiBendGrpc> GetAllDsiBends(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasons.RfqReasons.Any())
            {
                return _ListDsiBends;
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
                return _ListDsiBends;
            }
        }

        public async Task<ListDsiBendGrpc> GetDsiBendsByRowId(DsiBendGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBends.DsiBends.Any())
            {
            }
            else
            {
                await PopulateDsiBends(cancellationToken);
            }

            ListDsiBendGrpc responseList = new ListDsiBendGrpc();
            List<DsiBendGrpc> bends = _ListDsiBends.DsiBends.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (bends != null)
            {
                responseList.DsiBends.AddRange(bends);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListDsiBendGrpc> CreateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBendGrpc responseList = new ListDsiBendGrpc();
            if (request == null || request.DsiBendGrpcsToCreate == null || request.DsiBendGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBendCommand, List<DbDsiBend>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBendCommand, List<DbDsiBend>>>();
                DsiBendCommand command = new DsiBendCommand(CommandType.Create, request.DsiBendGrpcsToCreate);
                Result<List<DbDsiBend>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBend> createdComponents = result.Value;
                    List<DsiBendGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBends.DsiBends.AddRange(updatedGrpcComponents);
                    responseList.DsiBends.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBendGrpc responseList = new ListDsiBendGrpc();
            if (request == null || request.DsiBendGrpcsToUpdate == null || request.DsiBendGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBendCommand, List<DbDsiBend>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBendCommand, List<DbDsiBend>>>();
                DsiBendCommand command = new DsiBendCommand(CommandType.Update, request.DsiBendGrpcsToUpdate);
                Result<List<DbDsiBend>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBendGrpc updatedComponent in request.DsiBendGrpcsToUpdate)
                    {
                        DsiBendGrpc? foundItem = _ListDsiBends.DsiBends.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBends.DsiBends.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBends.DsiBends[index] = updatedComponent;
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

        #region DsiBranchConfiguration

        public async Task<ListDsiBranchConfigurationGrpc> GetAllDsiBranchConfigurations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasons.RfqReasons.Any())
            {
                return _ListDsiBranchConfigurations;
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
                return _ListDsiBranchConfigurations;
            }
        }

        public async Task<ListDsiBranchConfigurationGrpc> GetDsiBranchConfigurationsByRowId(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchConfigurations.DsiBranchConfigurations.Any())
            {
            }
            else
            {
                await PopulateDsiBranchConfigurations(cancellationToken);
            }

            ListDsiBranchConfigurationGrpc responseList = new ListDsiBranchConfigurationGrpc();
            List<DsiBranchConfigurationGrpc> banchConfigurations = _ListDsiBranchConfigurations.DsiBranchConfigurations.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (banchConfigurations != null)
            {
                responseList.DsiBranchConfigurations.AddRange(banchConfigurations);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListDsiBranchConfigurationGrpc> CreateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationGrpc responseList = new ListDsiBranchConfigurationGrpc();
            if (request == null || request.DsiBranchConfigurationGrpcsToCreate == null || request.DsiBranchConfigurationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>>>();
                DsiBranchConfigurationCommand command = new DsiBranchConfigurationCommand(CommandType.Create, request.DsiBranchConfigurationGrpcsToCreate);
                Result<List<DbDsiBranchConfiguration>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchConfiguration> createdComponents = result.Value;
                    List<DsiBranchConfigurationGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchConfigurations.DsiBranchConfigurations.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchConfigurations.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationGrpc responseList = new ListDsiBranchConfigurationGrpc();
            if (request == null || request.DsiBranchConfigurationGrpcsToUpdate == null || request.DsiBranchConfigurationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>>>();
                DsiBranchConfigurationCommand command = new DsiBranchConfigurationCommand(CommandType.Update, request.DsiBranchConfigurationGrpcsToUpdate);
                Result<List<DbDsiBranchConfiguration>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchConfigurationGrpc updatedComponent in request.DsiBranchConfigurationGrpcsToUpdate)
                    {
                        DsiBranchConfigurationGrpc? foundItem = _ListDsiBranchConfigurations.DsiBranchConfigurations.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchConfigurations.DsiBranchConfigurations.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchConfigurations.DsiBranchConfigurations[index] = updatedComponent;
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

        #region DsiBranchConfigurationBendAssociation

        public async Task<ListDsiBranchConfigurationBendAssociationGrpc> GetAllDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasons.RfqReasons.Any())
            {
                return _ListDsiBranchConfigurationBendAssociations;
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
                return _ListDsiBranchConfigurationBendAssociations;
            }
        }

        public async Task<ListDsiBranchConfigurationBendAssociationGrpc> GetDsiBranchConfigurationBendAssociationsByRowId(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.Any())
            {
            }
            else
            {
                await PopulateDsiBranchConfigurationBendAssociations(cancellationToken);
            }

            ListDsiBranchConfigurationBendAssociationGrpc responseList = new ListDsiBranchConfigurationBendAssociationGrpc();
            List<DsiBranchConfigurationBendAssociationGrpc> banchConfigurations = _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.Where(x => x.RowId == request.GrpcRequestParameter.IntValue).ToList();
            if (banchConfigurations != null)
            {
                responseList.DsiBranchConfigurationBendAssociations.AddRange(banchConfigurations);
                return responseList;
            }

            return responseList;
        }

        public async Task<ListDsiBranchConfigurationBendAssociationGrpc> CreateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationBendAssociationGrpc responseList = new ListDsiBranchConfigurationBendAssociationGrpc();
            if (request == null || request.DsiBranchConfigurationBendAssociationGrpcsToCreate == null || request.DsiBranchConfigurationBendAssociationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>>>();
                DsiBranchConfigurationBendAssociationCommand command = new DsiBranchConfigurationBendAssociationCommand(CommandType.Create, request.DsiBranchConfigurationBendAssociationGrpcsToCreate);
                Result<List<DbDsiBranchConfigurationBendAssociation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchConfigurationBendAssociation> createdComponents = result.Value;
                    List<DsiBranchConfigurationBendAssociationGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchConfigurationBendAssociations.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationBendAssociationGrpc responseList = new ListDsiBranchConfigurationBendAssociationGrpc();
            if (request == null || request.DsiBranchConfigurationBendAssociationGrpcsToUpdate == null || request.DsiBranchConfigurationBendAssociationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>>>();
                DsiBranchConfigurationBendAssociationCommand command = new DsiBranchConfigurationBendAssociationCommand(CommandType.Update, request.DsiBranchConfigurationBendAssociationGrpcsToUpdate);
                Result<List<DbDsiBranchConfigurationBendAssociation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchConfigurationBendAssociationGrpc updatedComponent in request.DsiBranchConfigurationBendAssociationGrpcsToUpdate)
                    {
                        DsiBranchConfigurationBendAssociationGrpc? foundItem = _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations[index] = updatedComponent;
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

        #region DsiBend

        public async Task<bool> PopulateDsiBends(CancellationToken cancellationToken)
        {
            if (!_DsiBendRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBendHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBendQuery, List<DsiBendGrpc>>>();
                    _DsiBendRefreshInProgress = true;
                    GetDsiBendQuery query = new GetDsiBendQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBendGrpc>> results = await _DsiBendHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBends.DsiBends.Clear();
                        _ListDsiBends.DsiBends.AddRange(results.Value);
                    }

                    _DsiBendRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchConfiguration

        public async Task<bool> PopulateDsiBranchConfigurations(CancellationToken cancellationToken)
        {
            if (!_DsiBranchConfigurationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchConfigurationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchConfigurationQuery, List<DsiBranchConfigurationGrpc>>>();
                    _DsiBranchConfigurationRefreshInProgress = true;
                    GetDsiBranchConfigurationQuery query = new GetDsiBranchConfigurationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchConfigurationGrpc>> results = await _DsiBranchConfigurationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchConfigurations.DsiBranchConfigurations.Clear();
                        _ListDsiBranchConfigurations.DsiBranchConfigurations.AddRange(results.Value);
                    }

                    _DsiBranchConfigurationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchConfigurationBendAssociation

        public async Task<bool> PopulateDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken)
        {
            if (!_DsiBranchConfigurationBendAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchConfigurationBendAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchConfigurationBendAssociationQuery, List<DsiBranchConfigurationBendAssociationGrpc>>>();
                    _DsiBranchConfigurationBendAssociationRefreshInProgress = true;
                    GetDsiBranchConfigurationBendAssociationQuery query = new GetDsiBranchConfigurationBendAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchConfigurationBendAssociationGrpc>> results = await _DsiBranchConfigurationBendAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.Clear();
                        _ListDsiBranchConfigurationBendAssociations.DsiBranchConfigurationBendAssociations.AddRange(results.Value);
                    }

                    _DsiBranchConfigurationBendAssociationRefreshInProgress = false;
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
            _ListDsiBends = SampleRfqDataService.PopulateDsiBendGrpc();
            _ListDsiBranchConfigurations = SampleRfqDataService.PopulateDsiBranchConfigurationGrpc();
            _ListDsiBranchConfigurationBendAssociations = SampleRfqDataService.PopulateDsiBranchConfigurationBendAssociationGrpc();
        }
    }
}
