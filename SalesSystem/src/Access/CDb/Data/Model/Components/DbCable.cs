namespace CDb.Data.Model.Components
{
    public class DbCable : DbComponent
    {
        public ColorType Color
        { get; set; }
        public int WireCount
        { get; set; }
        public string WireCountCode
        { get; set; }
        public decimal Length
        { get; set; }
        public bool IsShielded
        { get; set; }

        public DbCable() : base()
        {
            Color = ColorType.X; // Default to "N/A"
            WireCountCode = string.Empty;
            Length = 0.0m;
            IsShielded = false;
        }
    }
}
