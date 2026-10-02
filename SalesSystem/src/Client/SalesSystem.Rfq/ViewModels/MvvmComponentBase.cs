using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace SalesSystem.Rfq.ViewModels
{
    public abstract class MvvmComponentBase<TViewModel> : ComponentBase, IDisposable
        where TViewModel : INotifyPropertyChanged, new()
    {
        protected TViewModel ViewModel { get; } = new();

        bool _Disposed;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (ViewModel is IAsyncInitializable initializable)
            {
                await initializable.InitializeAsync();
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
                ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
                if (ViewModel is IDisposable disposableVm)
                {
                    disposableVm.Dispose();
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