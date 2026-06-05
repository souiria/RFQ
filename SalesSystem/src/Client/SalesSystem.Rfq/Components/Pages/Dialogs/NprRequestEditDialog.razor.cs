namespace SalesSystem.Rfq.Components.Pages.Dialogs
{
    public partial class NprRequestEditDialog
    {
        [Inject]
        RfqUxClientService RfqClientService
        { get; set; } = null!;

        // Reference to autocomplete for reset
        MudAutocomplete<SupplierGroupUxModel>? _SupplierGroupAutocomplete;
        MudAutocomplete<SupplierUxModel>? _SupplierAutocomplete;

        // Simplified supplier group selection
        SupplierGroupUxModel? _SelectedSupplierGroup;
        SupplierUxModel? _SelectedSupplier;

        SupplierGroupUxModel? SelectedSupplierGroup 
        { 
            get => _SelectedSupplierGroup;
            set
            {
                if (_SelectedSupplierGroup != value)
                {
                    _SelectedSupplierGroup = value;
                    // Update the NprRequest.SupplierGroup string when selection changes
                    NprRequest.SupplierGroup = value?.SupplierGroupName;
                }
            }
        }

        SupplierUxModel? SelectedSupplier 
        { 
            get => _SelectedSupplier;
            set
            {
                if (_SelectedSupplier != value)
                {
                    _SelectedSupplier = value;
                    NprRequest.SupplierGroup = value?.SupplierName;
                }
            }
        }

        [CascadingParameter]
        public IMudDialogInstance MudDialog
        { get; set; } = null!;

        [Parameter]
        public RfqNprRequestUxModel NprRequest
        { get; set; } = new();

        MudForm? _Form;

        bool IsSamplesRequired => NprRequest.IsSampleDataRequired == true;

        // List to cache supplier groups
        List<SupplierGroupUxModel> _SupplierGroups;
        List<SupplierUxModel> _Suppliers;

        public NprRequestEditDialog()
        {
            _SupplierGroups = new List<SupplierGroupUxModel>();
            _Suppliers = new List<SupplierUxModel>();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
            // Load supplier groups
            await LoadSupplierGroups();
            await LoadSuppliers();

            // If NprRequest already has a SupplierGroup, set the selected value
            if (!string.IsNullOrEmpty(NprRequest.SupplierGroup))
            {
                SelectedSupplierGroup = _SupplierGroups
                    .FirstOrDefault(sg => sg.SupplierGroupName == NprRequest.SupplierGroup);
            }

            if (!string.IsNullOrEmpty(NprRequest.SuggestedManufacturerGroup))
            {
                SelectedSupplier = _Suppliers
                    .FirstOrDefault(sg => sg.SupplierName == NprRequest.SuggestedManufacturerGroup);
            }
        }

        async Task LoadSupplierGroups()
        {
            try
            {
                // Assuming you have a method in RfqClientService to get supplier groups
                _SupplierGroups = await RfqClientService.GetAllSupplierGroupsAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine($"HTTP error loading supplier groups: {ex.Message}");
                _SupplierGroups = new List<SupplierGroupUxModel>();
            }
            catch (OperationCanceledException ex)
            {
                // Handle cancellation
                Console.WriteLine($"Operation canceled loading supplier groups: {ex.Message}");
                _SupplierGroups = new List<SupplierGroupUxModel>();
            }
        }
        async Task<IEnumerable<SupplierGroupUxModel>> SearchSupplierGroups(string searchText, CancellationToken token)
        {
            await Task.Delay(0, token);
            // If search text is empty, return all
            if (string.IsNullOrWhiteSpace(searchText))
            {
                List<SupplierGroupUxModel> supplierGroups = _SupplierGroups.Take(50).ToList();
                return supplierGroups;
            }

            List<SupplierGroupUxModel> filteredGroups = _SupplierGroups
                .Where(sg => sg.SupplierGroupName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Take(50)
                .ToList();
            return filteredGroups;
        }
        async Task LoadSuppliers()
        {
            try
            {
                // Assuming you have a method in RfqClientService to get supplier groups
                _Suppliers = await RfqClientService.GetAllSuppliersAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine($"HTTP error loading suppliers: {ex.Message}");
                _Suppliers = new List<SupplierUxModel>();
            }
            catch (OperationCanceledException ex)
            {
                // Handle cancellation
                Console.WriteLine($"Operation canceled loading suppliers: {ex.Message}");
                _Suppliers = new List<SupplierUxModel>();
            }
        }
        async Task<IEnumerable<SupplierUxModel>> SearchSuppliers(string searchText, CancellationToken token)
        {
            await Task.Delay(0, token);
            // If search text is empty, return all
            if (string.IsNullOrWhiteSpace(searchText))
            {
                List<SupplierUxModel> suppliers = _Suppliers.Take(50).ToList();
                return suppliers;
            }

            List<SupplierUxModel> filteredGroups = _Suppliers
                .Where(s => s.SupplierName?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Take(50)
                .ToList();
            return filteredGroups;
        }

        void Cancel()
        {
            MudDialog.Cancel();
        }

        void Save()
        {
            if (SelectedSupplierGroup != null)
            {
                NprRequest.SupplierGroup = SelectedSupplierGroup.SupplierGroupName;
                NprRequest.SuggestedManufacturerGroup = SelectedSupplierGroup.SupplierGroupName;
            }

            DialogResult result = DialogResult.Ok(NprRequest);
            MudDialog.Close(result);
        }
    }
}