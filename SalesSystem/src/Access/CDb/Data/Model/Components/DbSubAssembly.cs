namespace CDb.Data.Model.Components
{
    public class DbSubAssembly : DbComponent
    {
        public string Content
        { get; set; }
        public string Function
        { get; set; }
        public string AdditionalInformation
        { get; set; }
        public Guid? TerminalFamilyId
        { get; set; }
        public DbTerminalFamily TerminalFamily
        { get; set; }
        public Guid? TerminalSizeId
        { get; set; }
        public DbTerminalSize TerminalSize
        { get; set; }
        public ColorType Color
        { get; set; }

        public DbSubAssembly()
        {
            // Initialize properties with default values
            Content = string.Empty;
            Function = string.Empty;
            AdditionalInformation = string.Empty;
            TerminalFamily = null!;
            TerminalSize = null!;
            Color = ColorType.X; // Default value
        }
    }
}
