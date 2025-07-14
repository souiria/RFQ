namespace SFS.CQRS.Query.Site
{
   public class GetSiteQuery : IQuery<List<SiteViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

