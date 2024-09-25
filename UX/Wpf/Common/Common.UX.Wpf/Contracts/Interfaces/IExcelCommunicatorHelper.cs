using Infragistics.Documents.Excel;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface IExcelCommunicatorHelper
    {
        void DownloadTemplateFile(string fileName);
        string BrowseExcelFile(string title, string fileName);
        Workbook GetDataFromExcel(string filePath);
    }
}
