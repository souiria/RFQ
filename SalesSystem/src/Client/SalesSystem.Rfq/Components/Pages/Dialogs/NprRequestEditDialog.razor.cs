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
        MudAutocomplete<RfqReasonGrpc>? _ReasonAutocomplete;
        MudAutocomplete<UnitOfMeasureUxModel>? _UnitOfMeasureAutocomplete;
        MudAutocomplete<BusinessUnitUxModel>? _BusinessUnitAutocomplete;

        // Simplified supplier group selection
        SupplierGroupUxModel? _SelectedSupplierGroup;
        SupplierUxModel? _SelectedSupplier;
        RfqReasonGrpc? _SelectedReason;
        UnitOfMeasureUxModel? _SelectedUnitOfMeasure;
        BusinessUnitUxModel? _SelectedBusinessUnit;

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

        RfqReasonGrpc? SelectedReason 
        { 
            get => _SelectedReason;
            set
            {
                if (_SelectedReason != value)
                {
                    _SelectedReason = value;
                    NprRequest.ReasonDescription = value?.RfqReasonTitle;
                }
            }
        }

        UnitOfMeasureUxModel? SelectedUnitOfMeasure 
        { 
            get => _SelectedUnitOfMeasure;
            set
            {
                if (_SelectedUnitOfMeasure != value)
                {
                    _SelectedUnitOfMeasure = value;
                    NprRequest.BOMUnitOfMeasurement = value?.Code;
                }
            }
        }

        BusinessUnitUxModel? SelectedBusinessUnit
        {
            get => _SelectedBusinessUnit;
            set
            {
                if (_SelectedBusinessUnit != value)
                {
                    _SelectedBusinessUnit = value;
                    NprRequest.ManufacturingSite = value?.LegacyBusinessUnitCode;
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
        List<RfqReasonGrpc> _Reasons;
        List<UnitOfMeasureUxModel> _UnitOfMeasures;
        List<BusinessUnitUxModel> _BusinessUnits;

        public NprRequestEditDialog()
        {
            _SupplierGroups = new List<SupplierGroupUxModel>();
            _Suppliers = new List<SupplierUxModel>();
            _Reasons = new List<RfqReasonGrpc>();
            _UnitOfMeasures = new List<UnitOfMeasureUxModel>();
            _BusinessUnits = new List<BusinessUnitUxModel>();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            
            // Load supplier groups
            await LoadSupplierGroups();
            await LoadSuppliers();
            GetReasons();
            await LoadUnitOfMeasures();
            await LoadBusinessUnits();

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

            if(!string.IsNullOrEmpty(NprRequest.ReasonDescription))
            {
                SelectedReason = _Reasons
                    .FirstOrDefault(r => r.RfqReasonTitle == NprRequest.ReasonDescription);
            }

            if(!string.IsNullOrEmpty(NprRequest.BOMUnitOfMeasurement))
            {
                SelectedUnitOfMeasure = _UnitOfMeasures
                    .FirstOrDefault(u => u.Code == NprRequest.BOMUnitOfMeasurement);
            }

            if (!string.IsNullOrEmpty(NprRequest.ManufacturingSite))
            {
                SelectedBusinessUnit = _BusinessUnits
                    .FirstOrDefault(b => b.LegacyBusinessUnitCode == NprRequest.ManufacturingSite);
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

        void GetReasons()
        {
            _Reasons = RfqClientService.Reasons.ToList();
        }

        async Task<IEnumerable<RfqReasonGrpc>> SearchReasons(string searchText, CancellationToken token)
        {
            await Task.Delay(0, token);
            // If search text is empty, return all
            if (string.IsNullOrWhiteSpace(searchText))
            {
                List<RfqReasonGrpc> reasons = _Reasons.Take(50).ToList();
                return reasons;
            }

            List<RfqReasonGrpc> filteredReasons = _Reasons
                .Where(r => r.RfqReasonTitle?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Take(50)
                .ToList();
            return filteredReasons;
        }

        async Task LoadUnitOfMeasures()
        {
            try
            {
                // Assuming you have a method in RfqClientService to get unit of measures
                _UnitOfMeasures = await RfqClientService.GetAllUnitOfMeasuresAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine($"HTTP error loading units of measure: {ex.Message}");
                _UnitOfMeasures = new List<UnitOfMeasureUxModel>();
            }
            catch (OperationCanceledException ex)
            {
                // Handle cancellation
                Console.WriteLine($"Operation canceled loading units of measure: {ex.Message}");
                _UnitOfMeasures = new List<UnitOfMeasureUxModel>();
            }
        }

        async Task<IEnumerable<UnitOfMeasureUxModel>> SearchUnitOfMeasure(string searchText, CancellationToken token)
        {
            await Task.Delay(0, token);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                List<UnitOfMeasureUxModel> unitOfMeasures = _UnitOfMeasures.Take(50).ToList();
                return unitOfMeasures;
            }

            List<UnitOfMeasureUxModel> filteredUnitOfMeasures = _UnitOfMeasures
                .Where(uom => uom.Code?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Take(50)
                .ToList();
            return filteredUnitOfMeasures;
        }

        async Task LoadBusinessUnits()
        {
            try
            {
                // Assuming you have a method in RfqClientService to get unit of measures
                _BusinessUnits = await RfqClientService.GetAllBusinessunitsAsync();
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors
                Console.WriteLine($"HTTP error loading units of measure: {ex.Message}");
                _BusinessUnits = new List<BusinessUnitUxModel>();
            }
            catch (OperationCanceledException ex)
            {
                // Handle cancellation
                Console.WriteLine($"Operation canceled loading units of measure: {ex.Message}");
                _BusinessUnits = new List<BusinessUnitUxModel>();
            }
        }

        async Task<IEnumerable<BusinessUnitUxModel>> SearchBusinessUnit(string searchText, CancellationToken token)
        {
            await Task.Delay(0, token);
            if (string.IsNullOrWhiteSpace(searchText))
            {
                List<BusinessUnitUxModel> businessUnits = _BusinessUnits.Take(50).ToList();
                return businessUnits;
            }

            List<BusinessUnitUxModel> filteredBusinessUnit = _BusinessUnits
                .Where(b => b.LegacyBusinessUnitCode?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true)
                .Take(50)
                .ToList();
            return filteredBusinessUnit;
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
            
            if(SelectedReason != null)
            {
                NprRequest.ReasonDescription = SelectedReason.RfqReasonTitle;
            }

            if (SelectedBusinessUnit != null)
            {
                NprRequest.ManufacturingSite = SelectedBusinessUnit.LegacyBusinessUnitCode;
            }

            if (SelectedUnitOfMeasure != null)
            {
                NprRequest.BOMUnitOfMeasurement = SelectedUnitOfMeasure.Code;
            } 

            DialogResult result = DialogResult.Ok(NprRequest);
            MudDialog.Close(result);
        }
    }
}