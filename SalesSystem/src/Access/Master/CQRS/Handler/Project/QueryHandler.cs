namespace Master.CQRS.Handler.Project
{
    sealed class QueryHandler : IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneGrpc>>,
        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformGrpc>>,
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramGrpc>>,
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectGrpc>>,
        IQueryHandler<GetAllProjectEngineeringAssociationQuery, List<ProjectEngineeringAssociationGrpc>>
    {
        readonly IMastersReadRepository<DbMilestoneHierarchy> _MilestoneHierarchyRepository;
        readonly IMastersReadRepository<DbPlatformHierarchy> _PlatformHierarchyRepository;
        readonly IMastersReadRepository<DbProgramHierarchy> _ProgramHierarchyRepository;
        readonly IMastersReadRepository<DbProjectHierarchy> _ProjectHierarchyRepository;
        readonly IMastersReadRepository<DbProjectEngineeringAssociation> _ProjectEngineeringAssociationRepository;

        List<MilestoneGrpc> _Milestones;
        List<PlatformGrpc> _Platforms;
        List<ProgramGrpc> _Programs;
        List<ProjectGrpc> _Projects;
        List<ProjectEngineeringAssociationGrpc> _ProjectEngineeringAssociations;

        public QueryHandler(IMastersReadRepository<DbMilestoneHierarchy> milestoneHierarchyRepository, IMastersReadRepository<DbPlatformHierarchy> platformHierarchyRepository, IMastersReadRepository<DbProgramHierarchy> programHierarchyRepository, IMastersReadRepository<DbProjectHierarchy> projectHierarchyRepository, IMastersReadRepository<DbProjectEngineeringAssociation> projectEngineeringAssociationHierarchyRepository)
        {
            _MilestoneHierarchyRepository = milestoneHierarchyRepository;
            _PlatformHierarchyRepository = platformHierarchyRepository;
            _ProgramHierarchyRepository = programHierarchyRepository;
            _ProjectHierarchyRepository = projectHierarchyRepository;
            _ProjectEngineeringAssociationRepository = projectEngineeringAssociationHierarchyRepository;
            _Milestones = [];
            _Platforms = [];
            _Programs = [];
            _Projects = [];
            _ProjectEngineeringAssociations = [];
        }

        async Task<Result<List<MilestoneGrpc>>> IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneGrpc>>.Handle(GetAllMilestoneHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Milestones.Clear();
            GetMilestoneHierarchyReadOnlySpec spec = new GetMilestoneHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMilestoneHierarchy> results = await _MilestoneHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbMilestoneHierarchy result in results)
            {
                MilestoneGrpc mapping = result.MapToMilestoneGrpc();
                _Milestones.Add(mapping);
            }

            return _Milestones;
        }

        async Task<Result<List<PlatformGrpc>>> IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformGrpc>>.Handle(GetAllPlatformHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Platforms.Clear();
            GetPlatformHierarchyReadOnlySpec spec = new GetPlatformHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPlatformHierarchy> results = await _PlatformHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbPlatformHierarchy result in results)
            {
                PlatformGrpc mapping = result.MapToPlatformGrpc();
                _Platforms.Add(mapping);
            }

            return _Platforms;
        }

        async Task<Result<List<ProgramGrpc>>> IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramGrpc>>.Handle(GetAllProgramHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Programs.Clear();
            GetProgramHierarchyReadOnlySpec spec = new GetProgramHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProgramHierarchy> results = await _ProgramHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProgramHierarchy result in results)
            {
                ProgramGrpc mapping = result.MapToProgramGrpc();
                _Programs.Add(mapping);
            }

            return _Programs;
        }

        async Task<Result<List<ProjectGrpc>>> IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectGrpc>>.Handle(GetAllProjectHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Projects.Clear();
            GetProjectHierarchyReadOnlySpec spec = new GetProjectHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProjectHierarchy> results = await _ProjectHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProjectHierarchy result in results)
            {
                ProjectGrpc mapping = result.MapToProjectGrpc();
                _Projects.Add(mapping);
            }

            return _Projects;
        }

        async Task<Result<List<ProjectEngineeringAssociationGrpc>>> IQueryHandler<GetAllProjectEngineeringAssociationQuery, List<ProjectEngineeringAssociationGrpc>>.Handle(GetAllProjectEngineeringAssociationQuery query, CancellationToken cancellationToken)
        {
            _ProjectEngineeringAssociations.Clear();
            GetProjectEngineeringAssociationReadOnlySpec spec = new GetProjectEngineeringAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProjectEngineeringAssociation> results = await _ProjectEngineeringAssociationRepository.ListAsync(spec, cancellationToken);
            foreach (DbProjectEngineeringAssociation result in results)
            {
                ProjectEngineeringAssociationGrpc mapping = result.MapToProjectEngineeringAssociationGrpc();
                _ProjectEngineeringAssociations.Add(mapping);
            }

            return _ProjectEngineeringAssociations;
        }
    }
}
