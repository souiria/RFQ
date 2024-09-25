using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace SEWSE.H1.UX.Infrastructure.Core.AttachedProperties
{
    public static class ScrollToNewItemAttachment
    {
        private static XamDataGrid grid;
        private static INotifyCollectionChanged collection;
        private static bool subscribed;

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
            if (!subscribed)
            {
                collection = e.NewValue as INotifyCollectionChanged;
                if (collection != null)
                {
                    collection.CollectionChanged += (collectionSender, collectionChangedEvent) =>
                    {
                        var grid = (XamDataGrid)sender;
                        if (collectionChangedEvent.NewItems != null)
                        {
                            var record = grid.GetRecordFromDataItem(collectionChangedEvent.NewItems[0], false);
                            if (record != null)
                            {
                                grid.BringRecordIntoView(record);
                                CellValuePresenter.FromCell(record.Cells[GetCellFocus(grid)]).Editor.StartEditMode();
                            }
                        }
                    };
                    subscribed = true;
                }
            }
            else
            {
                var newCollection = e.NewValue as INotifyCollectionChanged;
                if (newCollection != null && newCollection != collection)
                {
                    collection.CollectionChanged -= (collectionSender, collectionChangedEvent) =>
                    {
                        var grid = (XamDataGrid)sender;
                        if (collectionChangedEvent.NewItems != null)
                        {
                            var record = grid.GetRecordFromDataItem(collectionChangedEvent.NewItems[0], false);
                            if (record != null)
                            {
                                grid.BringRecordIntoView(record);
                                CellValuePresenter.FromCell(record.Cells[GetCellFocus(grid)]).Editor.StartEditMode();
                            }
                        }
                    };
                    newCollection.CollectionChanged += (collectionSender, collectionChangedEvent) =>
                    {
                        var grid = (XamDataGrid)sender;
                        if (collectionChangedEvent.NewItems != null)
                        {
                            var record = grid.GetRecordFromDataItem(collectionChangedEvent.NewItems[0], false);
                            if (record != null)
                            {
                                grid.BringRecordIntoView(record);
                                CellValuePresenter.FromCell(record.Cells[GetCellFocus(grid)]).Editor.StartEditMode();
                            }
                        }
                    };
                    collection = newCollection;
                }                
            }
        }
    }
}
