namespace SalesSystem.Rfq.ViewModels
{
    public partial class RfqDashboardViewModel : ObservableObject, IAsyncInitializable
    {
        [ObservableProperty]
        GlobalValue? _GlobalValue;

        public Collection<KpiCard> Kpis { get; } =
        [
            new("RFQ KPI 1", "3,125,000", Icons.Material.Filled.AttachMoney, Color.Primary),
            new("RFQ KPI 2", "150,000", Icons.Material.Filled.Layers, Color.Secondary),
            new("RFQ KPI 3", "12%", Icons.Material.Filled.Public, Color.Success),
            new("RFQ KPI 4", "3.6", Icons.Material.Filled.TrendingUp, Color.Warning)
        ];

        public Collection<SuccessRow> Successes { get; } =
        [
            new("GM", "Garderoben", "CSS Magician", "High", Color.Primary, 1337),
            new("LR", "Lunees", "Reactor Engineer", "Low", Color.Success, 1),
            new("MG", "Mikes-gh", "Developer", "Medium", Color.Secondary, 19120)
        ];

        public async Task InitializeAsync()
        {
            await Task.Delay(0); // Simulate async work
        }
    }

    public sealed record KpiCard(string Label, string Value, string Icon, Color Color);

    public sealed record SuccessRow(
        string Initials,
        string Company,
        string Contact,
        string Priority,
        Color PriorityColor,
        decimal BusinessWon);
}