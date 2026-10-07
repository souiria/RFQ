namespace SalesSystem.Rfq.ViewModels
{
    public abstract class MvvmComponentBase<TViewModel> : ComponentBase, IDisposable
        where TViewModel : INotifyPropertyChanged
    {
        // Resolved from DI so ViewModels can take constructor-injected dependencies
        // (e.g. client services, ILogger, ISnackbar) instead of only supporting
        // parameterless construction.
        [Inject]
        IServiceProvider ServiceProvider { get; set; } = null!;

        TViewModel? _ViewModel;

        protected TViewModel ViewModel => _ViewModel ??= ServiceProvider.GetRequiredService<TViewModel>();

        bool _Disposed;
        bool _AsyncInitialized;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            // Cascading parameters (e.g. GlobalValue) are guaranteed to be applied
            // to the ViewModel by the time OnParametersSet/OnParametersSetAsync runs,
            // unlike OnInitializedAsync which can fire before parameters are set.
            // Guard ensures InitializeAsync only runs once per component instance.
            if (!_AsyncInitialized)
            {
                _AsyncInitialized = true;

                if (ViewModel is IAsyncInitializable initializable)
                {
                    await initializable.InitializeAsync();
                }
            }
        }

        void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        // Implement proper disposable pattern
        protected virtual void Dispose(bool disposing)
        {
            if (_Disposed)
            {
                return;
            }

            if (disposing)
            {
                // dispose managed resources
                if (_ViewModel is not null)
                {
                    _ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
                    if (_ViewModel is IDisposable disposableVm)
                    {
                        disposableVm.Dispose();
                    }
                }
            }

            // free unmanaged resources here if any

            _Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Finalizer in case Dispose isn't called
        ~MvvmComponentBase()
        {
            Dispose(false);
        }
    }
}