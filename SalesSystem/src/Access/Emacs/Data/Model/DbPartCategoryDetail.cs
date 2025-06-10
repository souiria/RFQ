namespace Emacs.Data.Model
{
    public class DbPartCategoryDetail : IAggregateRoot
    {
        [Column("Category Code")]
        public string? CategoryCode
        { get; set; }
        [Column("Detailed Category Code")]
        public double DetailedCategoryCode
        { get; set; }
        [Column("Category Name")]
        public string? CategoryName
        { get; set; }
    }
}
