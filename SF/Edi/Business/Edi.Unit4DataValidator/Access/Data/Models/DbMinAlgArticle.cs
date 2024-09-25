namespace Edi.Unit4DataValidator.Access.Data.Models;

public class DbMinAlgArticle : IAggregateRoot
{
    public long Id { get; set; }
    public string Article { get; set; }
    public string Description { get; set; }
    public string AgressoClient { get; set; }
}
