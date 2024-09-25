using Common.UX.Wpf.Contracts.Interfaces;
using Infragistics.Documents.Excel;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Common.UX.Wpf.Helpers
{
    public class ExcelCommunicatorHelper: IExcelCommunicatorHelper
    {
        private static Microsoft.Win32.OpenFileDialog _openFileDialog;
        public void DownloadTemplateFile(string fileName)
        {
            string[] words = fileName.Split('\\');
            if (!File.Exists(Environment.CurrentDirectory + fileName))
            {
                return;
            }
            SaveFileDialog dialogSaveUpdResult = new SaveFileDialog();
            dialogSaveUpdResult.Filter = "Excel WorkBook (*.xlsx)|.xlsx";
            dialogSaveUpdResult.FileName = words[words.Length - 1];
            dialogSaveUpdResult.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogResult dlgResSaveFile = dialogSaveUpdResult.ShowDialog();
            if (dlgResSaveFile == DialogResult.Cancel)
            {
                return;
            }
            File.Copy(Environment.CurrentDirectory + fileName, dialogSaveUpdResult.FileName, true);
            Workbook w1 = Workbook.Load(dialogSaveUpdResult.FileName);
            Worksheet ws = w1.Worksheets[0];
            w1.Save(dialogSaveUpdResult.FileName);
            Process.Start(dialogSaveUpdResult.FileName);
        }
        public string BrowseExcelFile(string title, string fileName)
        {
            string result = string.Empty;
            _openFileDialog = new Microsoft.Win32.OpenFileDialog();
            _openFileDialog.DefaultExt = ".xlsx";
            _openFileDialog.Filter = "ExcelWorksheet (.xlsx)|*.xlsx";
            _openFileDialog.Title = title;
            _openFileDialog.FileName = fileName;
            bool? dialogResult = _openFileDialog.ShowDialog();
            if (dialogResult == true)
            {
                result = _openFileDialog.FileName;
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public Workbook GetDataFromExcel(string filePath)
        {
            using (Stream fs = File.OpenRead(filePath))
            {
                var WorkbookData = Workbook.Load(filePath);
                return WorkbookData;
            }
        }
    }
}
