namespace SFS.CQRS.Query.Profile
{
  public class GetProfileQuery : IQuery<List<ProfileListViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

