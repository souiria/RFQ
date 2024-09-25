namespace Common.UX.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar
    {
        //private static readonly SolidColorBrush InvalidColorBrush = new SolidColorBrush(Colors.Red);

        //private static readonly SolidColorBrush DefaultColorBrush =
        //    (SolidColorBrush)Application.Current.Resources["Highlights"];

        //public static readonly DependencyProperty IsValidProperty =
        //    DependencyProperty.Register("IsValid", typeof(bool), typeof(SearchBar),
        //        new FrameworkPropertyMetadata(IsValidChanged)
        //        {
        //            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
        //            DefaultValue = true
        //        });

        //public bool IsValid
        //{
        //    get => (bool)GetValue(IsValidProperty);
        //    set => SetValue(IsValidProperty, value);
        //}

        //private static void IsValidChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    if (d is SearchBar searchBar) searchBar.IsValidChanged(e);
        //}

        //private void IsValidChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    if (DataContext != null) ((Searcher)DataContext).IsValid = (bool)e.NewValue;
        //    if (!(bool)e.NewValue) Border.BorderBrush = InvalidColorBrush;
        //    else Border.BorderBrush = DefaultColorBrush;
        //}

        public SearchBar()
        {
            InitializeComponent();
            //Border.BorderBrush = DefaultColorBrush;
        }
    }
}
