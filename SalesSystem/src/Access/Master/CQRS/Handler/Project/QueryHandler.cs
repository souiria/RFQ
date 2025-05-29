using System.Reflection.Metadata;

namespace Master.CQRS.Handler.Project
{
    sealed class QueryHandler : IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneHierarchyDto>>,
        IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformHierarchyDto>>,
        IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramHierarchyDto>>,
        IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectHierarchyDto>>
    {
        readonly IMastersReadRepository<DbMilestoneHierarchy> _MilestoneHierarchyRepository;
        readonly IMastersReadRepository<DbPlatformHierarchy> _PlatformHierarchyRepository;
        readonly IMastersReadRepository<DbProgramHierarchy> _ProgramHierarchyRepository;
        readonly IMastersReadRepository<DbProjectHierarchy> _ProjectHierarchyRepository;

        List<MilestoneHierarchyDto> _Milestones;
        List<PlatformHierarchyDto> _Platforms;
        List<ProgramHierarchyDto> _Programs;
        List<ProjectHierarchyDto> _Projects;

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

        async Task<Result<List<MilestoneHierarchyDto>>> IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneHierarchyDto>>.Handle(GetAllMilestoneHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Milestones.Clear();
            GetMilestoneHierarchyReadOnlySpec spec = new GetMilestoneHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbMilestoneHierarchy> results = await _MilestoneHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbMilestoneHierarchy result in results)
            {
                MilestoneHierarchyDto mapping = result.MapToDto();
                _Milestones.Add(mapping);
            }

            return _Milestones;
        }

        async Task<Result<List<PlatformHierarchyDto>>> IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformHierarchyDto>>.Handle(GetAllPlatformHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Platforms.Clear();
            GetPlatformHierarchyReadOnlySpec spec = new GetPlatformHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbPlatformHierarchy> results = await _PlatformHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbPlatformHierarchy result in results)
            {
                PlatformHierarchyDto mapping = result.MapToDto();
                _Platforms.Add(mapping);
            }

            return _Platforms;
        }

        async Task<Result<List<ProgramHierarchyDto>>> IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramHierarchyDto>>.Handle(GetAllProgramHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Programs.Clear();
            GetProgramHierarchyReadOnlySpec spec = new GetProgramHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProgramHierarchy> results = await _ProgramHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProgramHierarchy result in results)
            {
                ProgramHierarchyDto mapping = result.MapToDto();
                _Programs.Add(mapping);
            }

            return _Programs;
        }

        async Task<Result<List<ProjectHierarchyDto>>> IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectHierarchyDto>>.Handle(GetAllProjectHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Projects.Clear();
            GetProjectHierarchyReadOnlySpec spec = new GetProjectHierarchyReadOnlySpec(query.Position, query.TakeAmount);
            List<DbProjectHierarchy> results = await _ProjectHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbProjectHierarchy result in results)
            {
                ProjectHierarchyDto mapping = result.MapToDto();
                _Projects.Add(mapping);
            }

            return _Projects;
        }
    }
}
