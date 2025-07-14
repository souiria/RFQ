namespace SFS.CQRS.Query.Profile
{
  public class GetProfileQuery : IQuery<List<ProfileViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

