using CDb.Enums;

namespace CDb.Data.Model
{
    public class DbDrawingNumber
    {
        public Guid Id 
        { get; set; }
        public string Number 
        { get; set; }
        public Guid ComponentId 
        { get; set; } = Guid.Empty;
        public DbComponent Component 
        { get; set; }
        public DrawingNumberType DrawingNumberType 
        { get; set; }
        public bool IsDeleted 
        { get; set; }

        public DbDrawingNumber()
        {
            Id = Guid.NewGuid();
            Number = string.Empty;
            Component = null!;
            DrawingNumberType = DrawingNumberType.Generic_DRW;
            IsDeleted = false;
        }
    }
}
