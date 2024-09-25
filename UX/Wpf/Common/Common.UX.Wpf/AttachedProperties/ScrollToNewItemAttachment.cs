using System.Collections.Specialized;
using System.Windows;
using Infragistics.Windows.DataPresenter;

namespace Common.UX.Wpf.AttachedProperties
{
    public static class ScrollToNewItemAttachment
    {
        private static INotifyCollectionChanged _collection;
        private static bool _subscribed;

        public static string GetCellFocus(DependencyObject obj)
        {
            return (string)obj.GetValue(CellFocusProperty);
        }

        public static void SetCellFocus(DependencyObject obj, string value)
        {
            obj.SetValue(CellFocusProperty, value);
        }

        public static readonly DependencyProperty CellFocusProperty = DependencyProperty.RegisterAttached("CellFocus", typeof(string), typeof(ScrollToNewItemAttachment), new UIPropertyMetadata(string.Empty, OnScrollOnNewItemChanged));

        public static void OnScrollOnNewItemChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            ((XamDataGrid)d).DataSourceChanged += Grid_DataSourceChanged;
        }

        //private static void DataGrid_Loaded(object sender, RoutedEventArgs e)
        //{
        //    grid.DataSourceChanged += Grid_DataSourceChanged;
        //    grid.Unloaded += DataGrid_Unloaded;
        //}

        private static void Grid_DataSourceChanged(object sender, RoutedPropertyChangedEventArgs<System.Collections.IEnumerable> e)
        {

            void CollectionOnCollectionChanged(object collectionSender, NotifyCollectionChangedEventArgs collectionChangedEvent)
            {
                var grid = (XamDataGrid)sender;
                if (collectionChangedEvent.NewItems == null) return;
                var record = grid.GetRecordFromDataItem(collectionChangedEvent.NewItems[0], false);
                if (record == null) return;
                grid.BringRecordIntoView(record);
                CellValuePresenter.FromCell(record.Cells[GetCellFocus(grid)]).Editor.StartEditMode();
            }


            if (!_subscribed)
            {
                _collection = e.NewValue as INotifyCollectionChanged;

                if (_collection == null) return;

                _collection.CollectionChanged += CollectionOnCollectionChanged;
                _subscribed = true;
            }
            else
            {
                if (!(e.NewValue is INotifyCollectionChanged newCollection) || Equals(newCollection, _collection)) return;

                _collection.CollectionChanged -= CollectionOnCollectionChanged;
                newCollection.CollectionChanged += CollectionOnCollectionChanged;
                _collection = newCollection;
            }
        }
    }
}
