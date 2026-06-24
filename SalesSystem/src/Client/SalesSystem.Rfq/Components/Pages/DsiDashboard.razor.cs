namespace SalesSystem.Rfq.Components.Pages
{

    public partial class DsiDashboard
    {
        bool _LoadingHarnesses;
        bool _LoadingCompositeDetails;
        bool _LoadingComponents;

        List<DSIHarnessGrpc> _Harnesses = new();
        List<DSICompositeDetailGrpc> _CompositeDetails = new();
        List<DSIComponentGrpc> _Components = new();

        DSIHarnessGrpc? _SelectedHarness;

        HashSet<DSICompositeDetailGrpc> _SelectedCompositeDetails = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadHarnesses();
        }

        async Task LoadHarnesses()
        {
            try
            {
                _LoadingHarnesses = true;

                await DsiUxClientService.GetAllHarnessAsync();
                _Harnesses = DsiUxClientService.Harnesses.ToList();

                _SelectedHarness = null;
                _CompositeDetails.Clear();
                _Components.Clear();
                _SelectedCompositeDetails.Clear();
            }
            finally
            {
                _LoadingHarnesses = false;
            }
        }

        async Task OnHarnessRowClick(TableRowClickEventArgs<DSIHarnessGrpc> args)
        {
            DSIHarnessGrpc? clicked = args.Item;
            if (clicked == null)
            {
                return;
            }

            _SelectedHarness = clicked;

            _Components.Clear();
            _SelectedCompositeDetails.Clear();

            await LoadCompositeDetailsByHarnessId(clicked.Id);
        }

        async Task LoadCompositeDetailsByHarnessId(string harnessId)
        {
            try
            {
                _LoadingCompositeDetails = true;

                await DsiUxClientService.GetCompositeDetailByHarnessIdAsync(harnessId);
                _CompositeDetails = DsiUxClientService.CompositeDetails.ToList();
            }
            finally
            {
                _LoadingCompositeDetails = false;
            }
        }

        async Task LoadComponentsByHarnessAndCircuitOption()
        {
            if (_SelectedHarness == null || !_SelectedCompositeDetails.Any())
            {
                return;
            }

            try
            {
                _LoadingComponents = true;
                _Components.Clear();

                List<string> harnessNames = new List<string>
            {
                _SelectedHarness.HarnessName1!
            };

                List<string> compositeOptions = _SelectedCompositeDetails
                    .Where(x => !string.IsNullOrWhiteSpace(x.CircuitOption))
                    .SelectMany(x => x.CircuitOption!
                        .Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToList();

                await DsiUxClientService.GetComponentsByHarnessAndOptionsAsync(
                    harnessNames,
                    compositeOptions);

                _Components = DsiUxClientService.Components.ToList();
            }
            finally
            {
                _LoadingComponents = false;
            }
        }

        string GetHarnessRowClass(DSIHarnessGrpc item, int row)
        {
            return _SelectedHarness?.Id == item.Id ? "selected-row" : string.Empty;
        }
    }
}    