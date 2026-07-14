namespace Emacs.Data.Model
{
    public class DbPartClassDetail : IAggregateRoot
    {
        public string? Class1
        { get; set; }
        public string? Class1Name
        { get; set; }
        public double Class2
        { get; set; }
        public string? Class2Name
        { get; set; }
    }
}
