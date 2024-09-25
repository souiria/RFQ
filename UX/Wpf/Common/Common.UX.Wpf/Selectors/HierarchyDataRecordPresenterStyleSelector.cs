using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Common.Core.Contracts.Models.Base;
using Infragistics.Windows.DataPresenter;

namespace Common.UX.Wpf.Selectors
{
    public class HierarchyDataRecordPresenterStyleSelector : StyleSelector
    {
        public Type ChildType0 { get; set; }
        public Type ChildType1 { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (!(item is Record record)) return null;
            var dataItem = GetDataItem(record);
            if (dataItem == null) return null;

            if (!(dataItem is NodeCollection node)) return null;

            Style defaultStyle = null;

            try
            {
                var resourceDictionary = new ResourceDictionary();
                const string path =
                    "pack://application:,,,/UX.Core.Themes;component/Themes/CorporateTheme/Controls/XamDataGrid.xaml";
                resourceDictionary.Source = new Uri(path, UriKind.Absolute);

                defaultStyle = (Style)resourceDictionary[typeof(DataRecordPresenter)];

                if (ChildType0 != null && ChildType0.IsInstanceOfType(node.Value))
                {
                    defaultStyle.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Color.FromArgb(25, 255, 255, 255))));
                    if(record.DataPresenter is XamDataGrid)
                        defaultStyle.Setters.Add(new Setter(DataRecordPresenter.HeaderAreaBackgroundProperty, new SolidColorBrush(Color.FromArgb(255, 2, 138, 205))));
                    return defaultStyle;
                }

                if (ChildType1 != null && ChildType1.IsInstanceOfType(node.Value))
                {
                    defaultStyle.Setters.Add(new Setter(Control.BackgroundProperty, new SolidColorBrush(Color.FromArgb(50, 255, 255, 255))));
                    if (record.DataPresenter is XamDataGrid)
                        defaultStyle.Setters.Add(new Setter(DataRecordPresenter.HeaderAreaBackgroundProperty, new SolidColorBrush(Color.FromArgb(255, 104, 164, 217))));
                    return defaultStyle;
                }
            }
            catch (FileNotFoundException ex)
            {
                if (!DesignerProperties.GetIsInDesignMode(container))
                    throw ex;
            }

            return defaultStyle;
        }

        private static object GetDataItem(Record record)
        {
            while (true)
            {
                switch (record)
                {
                    case FilterRecord filterRecord:
                        return filterRecord.DataItem;
                    case HeaderRecord headerRecord:
                        record = headerRecord.AttachedToRecord;
                        continue;
                    case DataRecord dataRecord:
                        return dataRecord.DataItem;
                    case ExpandableFieldRecord expandableFieldRecord:
                        record = expandableFieldRecord.GetAssociatedRecord();
                        continue;
                    case GroupByRecord groupByRecord:
                        record = groupByRecord.GetAssociatedRecord();
                        continue;
                    case SummaryRecord summaryRecord:
                        record = summaryRecord.GetAssociatedRecord();
                        continue;
                }

                break;
            }

            return null;
        }
    }
}
