using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Common.UX.Wpf.Base;
using Common.UX.Wpf.Contracts.Interfaces;

namespace UX.Core.ShellDialog.Views
{
	/// <summary>
	/// Interaction logic for RibbonDialog.xaml
	/// </summary>
	public partial class RibbonDialog : IDialog
	{
		#region Members

		IDialogAware _viewModel;

		#endregion //Members

		#region Constructors

		public RibbonDialog()
		{
			InitializeComponent();
			Closed += RibbonDialog_Closed;
			Closing += RibbonDialog_Closing;
		}

        #endregion //Constructors

        #region IDialog

        public void Show(bool isModal = true)
        {

            //base.Show();
            var fe = _contentRegion.Content as FrameworkElement;
            if (fe != null)
            {
                _viewModel = fe.DataContext as IDialogAware;

                if (_viewModel != null)
                {
                    _viewModel.RequestClose += ViewModel_RequestClose;

                    var viewModelBase = (ViewModelBase)fe.DataContext;

                    if (!string.IsNullOrEmpty(viewModelBase.IconSource))
                    {
                        Uri iconUri = new Uri(viewModelBase.IconSource, UriKind.RelativeOrAbsolute);
                        this.Icon = BitmapFrame.Create(iconUri);
                    }

                    viewModelBase.PropertyChanged += (s, a) =>
                    {
                        if (a.PropertyName == "Title")
                            if (viewModelBase.Title != null)
                                this.Title = viewModelBase.Title;
                    };

                    viewModelBase.RefreshTitle();
                }
            }
            CalculateDialogWindowsPosition();
            if (isModal)
            {
                if (((ViewModelBase)fe.DataContext).Header!=null)
                {
                    this.Title = ((ViewModelBase)fe.DataContext).Header;
                }
                base.ShowDialog();
            }
            else
            {
                base.Show();
            }
        }
        public void ShowForBaseViewModel(bool isModal = true)
		{
			
			//base.Show();
			var fe = _contentRegion.Content as FrameworkElement;
			if (fe != null)
			{
				_viewModel = fe.DataContext as IDialogAware;

				if (_viewModel != null)
				{
					_viewModel.RequestClose += ViewModel_RequestClose;

					var viewModelBase = (BaseViewModel)fe.DataContext;

					//if (!string.IsNullOrEmpty(viewModelBase.IconSource))
					//{
					//	Uri iconUri = new Uri(viewModelBase.IconSource, UriKind.RelativeOrAbsolute);
					//	this.Icon = BitmapFrame.Create(iconUri);
					//}

					viewModelBase.PropertyChanged += (s, a) =>
					{
						if (a.PropertyName == "Title")
							if (viewModelBase.Header != null)
								this.Title = viewModelBase.Header;
					};

					//viewModelBase.RefreshTitle();
				}
			}
			CalculateDialogWindowsPosition();
			if (isModal)
			{
				if (((BaseViewModel)fe.DataContext).Header!=null)
				{
					this.Title = ((BaseViewModel)fe.DataContext).Header;
				}
				base.ShowDialog();
			}
			else
			{
				base.Show();
			}
		}

		#endregion //IDialog

		#region Event Handlers

		void ViewModel_RequestClose()
		{
			try
			{
				//this.Close();
				CloseDialogWindow();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		void RibbonDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				if (_viewModel != null && !_viewModel.CanCloseDialog())
				{
					e.Cancel = true;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		void RibbonDialog_Closed(object sender, EventArgs e)
		{
			try
			{
				if (_viewModel != null)
				{
					_viewModel.RequestClose -= ViewModel_RequestClose;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void btnClose_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				//this.Close();
				CloseDialogWindow();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		#endregion //Event Handlers

		#region Methods
		private void CloseDialogWindow()
		{
			var windows = Application.Current.Windows;

			int x = 0;
			foreach (var window in windows)
			{
				if (window is IDialog)
				{
					if (window == this)
					{
						if (x > 1) //don't want the Shell
						{
							this.Close();

						}

						break;
					}
				}

				x++;
			}
		}
		private void CalculateDialogWindowsPosition()
		{
			var windows = Application.Current.Windows;

			int x = 0;
			foreach (var window in windows)
			{
				if (window is IDialog)
				{
					if (window == this)
					{
						if (x > 1) //don't want the Shell
						{
							for (int i = x - 1; i > 0; i--)
							{
								if (windows[i] is IDialog)
								{
									var priorWindow = windows[i];
									Left = priorWindow.Left - 40;
									Top = priorWindow.Top + 40;
									break;
								}
							}

						}

						break;
					}
				}

				x++;
			}
		}

		#endregion //Methods
	}
}
