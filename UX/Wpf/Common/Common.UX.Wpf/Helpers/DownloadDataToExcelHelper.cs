using Common.UX.Wpf.Contracts.Interfaces;
using Infragistics.Windows.DataPresenter;
using System.Collections.Generic;

namespace Common.UX.Wpf.Helpers
{
    public class DownloadDataToExcelHelper<T>: IDownloadDataToExcelHelper<T>
    {
        public void ExportToExcel(List<T> list, string ExcelSheetName, string tempworkbook)
        {
            XamDataGridExportHelper ObjExport = new XamDataGridExportHelper();
            XamDataGrid dataGrid = new XamDataGrid();
            dataGrid.BeginInit();
            dataGrid.DataSource = list;
            dataGrid.EndInit();
            ObjExport.ExcelSheetName = ExcelSheetName;
            int Result = ObjExport.ExportGridToExcelAsync(dataGrid, tempworkbook);
            if (Result == 0) { }
        }
    }
}
