namespace Emacs.Data.Model
{
    public class DbPartCategoryDetail : IAggregateRoot
    {
        public string? CategoryCode
        { get; set; }
        public double DetailedCategoryCode
        { get; set; }
        public string? CategoryName
        { get; set; }
    }
}
