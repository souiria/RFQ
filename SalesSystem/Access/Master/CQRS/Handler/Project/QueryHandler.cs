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

        List<MilestoneHierarchyDto> _Milestones = new();
        List<PlatformHierarchyDto> _Platforms = new();
        List<ProgramHierarchyDto> _Programs = new();
        List<ProjectHierarchyDto> _Projects = new();

        public QueryHandler(IMastersReadRepository<DbMilestoneHierarchy> milestoneHierarchyRepository, IMastersReadRepository<DbPlatformHierarchy> platformHierarchyRepository, IMastersReadRepository<DbProgramHierarchy> programHierarchyRepository, IMastersReadRepository<DbProjectHierarchy> projectHierarchyRepository)
        {
            _MilestoneHierarchyRepository = milestoneHierarchyRepository;
            _PlatformHierarchyRepository = platformHierarchyRepository;
            _ProgramHierarchyRepository = programHierarchyRepository;
            _ProjectHierarchyRepository = projectHierarchyRepository;
        }

        async Task<Result<List<MilestoneHierarchyDto>>> IQueryHandler<GetAllMilestoneHierarchiesQuery, List<MilestoneHierarchyDto>>.Handle(GetAllMilestoneHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Milestones.Clear();
            List<DbMilestoneHierarchy> results = await _MilestoneHierarchyRepository.ListAsync(new GetMilestoneHierarchyReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbMilestoneHierarchy result in results)
            {
                _Milestones.Add(result.MapToDto());
            }

            return _Milestones;
        }

        async Task<Result<List<PlatformHierarchyDto>>> IQueryHandler<GetAllPlatformHierarchiesQuery, List<PlatformHierarchyDto>>.Handle(GetAllPlatformHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Platforms.Clear();
            List<DbPlatformHierarchy> results = await _PlatformHierarchyRepository.ListAsync(new GetPlatformHierarchyReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbPlatformHierarchy result in results)
            {
                _Platforms.Add(result.MapToDto());
            }

            return _Platforms;
        }

        async Task<Result<List<ProgramHierarchyDto>>> IQueryHandler<GetAllProgramHierarchiesQuery, List<ProgramHierarchyDto>>.Handle(GetAllProgramHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Programs.Clear();
            List<DbProgramHierarchy> results = await _ProgramHierarchyRepository.ListAsync(new GetProgramHierarchyReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbProgramHierarchy result in results)
            {
                _Programs.Add(result.MapToDto());
            }

            return _Programs;
        }

        async Task<Result<List<ProjectHierarchyDto>>> IQueryHandler<GetAllProjectHierarchiesQuery, List<ProjectHierarchyDto>>.Handle(GetAllProjectHierarchiesQuery query, CancellationToken cancellationToken)
        {
            _Projects.Clear();
            List<DbProjectHierarchy> results = await _ProjectHierarchyRepository.ListAsync(new GetProjectHierarchyReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbProjectHierarchy result in results)
            {
                _Projects.Add(result.MapToDto());
            }

            return _Projects;
        }
    }
}
