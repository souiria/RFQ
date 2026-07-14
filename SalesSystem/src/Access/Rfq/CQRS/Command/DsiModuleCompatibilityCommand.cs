namespace Rfq.CQRS.Command
{
    public record DsiModuleCompatibilityCommand(
       CommandType CommandType,
       ICollection<DsiModuleCompatibilityGrpc> DsiModuleCompatibilityGrpcs
   ) : ICommand<List<DbDsiModuleCompatibility>>;

}
