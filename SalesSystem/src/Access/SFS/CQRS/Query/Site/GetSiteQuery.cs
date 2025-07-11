namespace SFS.CQRS.Query.Site
{
   public class GetSiteQuery : IQuery<List<SiteListViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

