namespace Unit4.Data.Model
{
    public class DbMinAlgArticle : IAggregateRoot
    {
        public long Id
        { get; set; }
        public string Article
        { get; set; } = string.Empty;
        public string Description
        { get; set; } = string.Empty;
        public string AgressoClient
        { get; set; } = string.Empty;
    }
}
