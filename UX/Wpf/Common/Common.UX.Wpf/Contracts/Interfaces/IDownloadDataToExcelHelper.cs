using System.Collections.Generic;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IDownloadDataToExcelHelper<T>
    {
        void ExportToExcel(List<T> list, string ExcelSheetName, string tempworkbook);
    }
}
