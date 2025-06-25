namespace Master.CQRS.Handler.Project
{
    sealed class QueryHandler : IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneData>>,
        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformData>>,
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramData>>,
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectData>>
    {
        readonly IMastersReadRepository<DbMilestoneHierarchy> _MilestoneHierarchyRepository;
        readonly IMastersReadRepository<DbPlatformHierarchy> _PlatformHierarchyRepository;
        readonly IMastersReadRepository<DbProgramHierarchy> _ProgramHierarchyRepository;
        readonly IMastersReadRepository<DbProjectHierarchy> _ProjectHierarchyRepository;

        List<MilestoneData> _Milestones;
        List<PlatformData> _Platforms;
        List<ProgramData> _Programs;
        List<ProjectData> _Projects;

        public QueryHandler(IMastersReadRepository<DbMilestoneHierarchy> milestoneHierarchyRepository, IMastersReadRepository<DbPlatformHierarchy> platformHierarchyRepository, IMastersReadRepository<DbProgramHierarchy> programHierarchyRepository, IMastersReadRepository<DbProjectHierarchy> projectHierarchyRepository)
        {
            _MilestoneHierarchyRepository = milestoneHierarchyRepository;
            _PlatformHierarchyRepository = platformHierarchyRepository;
            _ProgramHierarchyRepository = programHierarchyRepository;
            _ProjectHierarchyRepository = projectHierarchyRepository;
            _Milestones = [];
            _Platforms = [];
            _Programs = [];
            _Projects = [];
        }

        async Task<Result<List<MilestoneData>>> IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneData>>.Handle(GetAllMilestoneHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Milestones.Clear();
            GetMilestoneHierarchyReadOnlySpec spec = new GetMilestoneHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMilestoneHierarchy> results = await _MilestoneHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbMilestoneHierarchy result in results)
            {
                MilestoneData mapping = result.MapToMilestoneData();
                _Milestones.Add(mapping);
            }

            return _Milestones;
        }

        async Task<Result<List<PlatformData>>> IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformData>>.Handle(GetAllPlatformHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Platforms.Clear();
            GetPlatformHierarchyReadOnlySpec spec = new GetPlatformHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPlatformHierarchy> results = await _PlatformHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbPlatformHierarchy result in results)
            {
                PlatformData mapping = result.MapToPlatformData();
                _Platforms.Add(mapping);
            }

            return _Platforms;
        }

        async Task<Result<List<ProgramData>>> IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramData>>.Handle(GetAllProgramHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Programs.Clear();
            GetProgramHierarchyReadOnlySpec spec = new GetProgramHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProgramHierarchy> results = await _ProgramHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProgramHierarchy result in results)
            {
                ProgramData mapping = result.MapToProgramData();
                _Programs.Add(mapping);
            }

            return _Programs;
        }

        async Task<Result<List<ProjectData>>> IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectData>>.Handle(GetAllProjectHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Projects.Clear();
            GetProjectHierarchyReadOnlySpec spec = new GetProjectHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProjectHierarchy> results = await _ProjectHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProjectHierarchy result in results)
            {
                ProjectData mapping = result.MapToProjectData();
                _Projects.Add(mapping);
            }

            return _Projects;
        }
    }
}
