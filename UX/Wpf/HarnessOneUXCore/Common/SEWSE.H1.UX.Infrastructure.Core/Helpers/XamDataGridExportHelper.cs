using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using Infragistics.Documents.Excel;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.ExcelExporter;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
	public class XamDataGridExportHelper
	{
		/// <summary>
		/// This is a common function through which griddata will be exported
		/// <para>
		/// If true(1) means exported successfull else error or user cancelled the operation
		/// </para>
		/// </summary>
		/// <param name="dataPresenter">XamDatagrid presenter object</param>
		/// <param name="targetFileName">Name of the screen as default target excel document name</param>        
		public int ExportGridToExcel(DataPresenterBase dataPresenter, string targetFileName)
		{
			DataPresenterExcelExporter excelExporter = new DataPresenterExcelExporter();
            excelExporter.HeaderLabelExporting += ExcelExporter_HeaderLabelExporting;
            excelExporter.CellExporting += new EventHandler<CellExportingEventArgs>(exporter_CellExporting);
            try
			{
           

				bool isExportSuccessFul = false;
				SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
				Workbook tmpWorkbook = new Workbook(WorkbookFormat.Excel2007);
               


                excelExporter.Export(dataPresenter, tmpWorkbook);
               
				saveFileDialogExcel.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";

				string FileName = targetFileName;
				FileName = FileName.Replace("(", "");
				FileName = FileName.Replace(")", "");
				FileName = FileName.Replace("&amp;", "_");

				FileName = FileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
				FileName = FileName + ".xlsx";
				saveFileDialogExcel.FileName = FileName;
				saveFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				saveFileDialogExcel.RestoreDirectory = false;
				DialogResult dlgResSaveFile = saveFileDialogExcel.ShowDialog();
				if (dlgResSaveFile == DialogResult.Cancel)
				{
					isExportSuccessFul = false;
					return 0;
				}
				isExportSuccessFul = true;
                ExportedExcelValue = saveFileDialogExcel.FileName;
                if (saveFileDialogExcel.FileName != "")
				{
					using (Stream exportStream = saveFileDialogExcel.OpenFile())
					{
                        tmpWorkbook.ActiveWorksheet.Name = string.IsNullOrEmpty(ExcelSheetName) ? "Sheet1" : ExcelSheetName;
                        tmpWorkbook.ActiveWorksheet.Rows[0].CellFormat.VerticalAlignment = VerticalCellAlignment.Center;
                        tmpWorkbook.Save(exportStream);
                        //exportStream.Close();
                    }
                }
				if (isExportSuccessFul == true)
				{
                    //Dialog.showSuccessMessage(ResourceBase.mst1065, targetFileName); 
                    //Open Excel on export
                    if (CheckExcelExport == true)
                        Process.Start(saveFileDialogExcel.FileName);
					return 1;
				}
				return 0;
			}
			catch (Exception )
			{
				return 0;
			}
		}

        //private void DataPresenter_FieldLayoutInitializing(object sender, Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializingEventArgs e)
        //{
        // e.FieldLayout.Fields.Lab
        //}

        public int ExportGridToExcelAsync(DataPresenterBase dataPresenter, string targetFileName)
        {
            DataPresenterExcelExporter excelExporter = new DataPresenterExcelExporter();
            excelExporter.HeaderLabelExporting += ExcelExporter_HeaderLabelExporting;
            try
            {
                bool isExportSuccessFul = false;
                SaveFileDialog saveFileDialogExcel = new SaveFileDialog();
                Workbook tmpWorkbook = new Workbook(WorkbookFormat.Excel2007);


                excelExporter.Export(dataPresenter, tmpWorkbook);
                saveFileDialogExcel.Filter = "Excel WorkBook (*.xlsx)|*.xlsx";

                string FileName = targetFileName;
                FileName = FileName.Replace("(", "");
                FileName = FileName.Replace(")", "");
                FileName = FileName.Replace("&amp;", "_");

                FileName = FileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                FileName = FileName + ".xlsx";
                saveFileDialogExcel.FileName = FileName;
                saveFileDialogExcel.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialogExcel.RestoreDirectory = false;
                DialogResult dlgResSaveFile = saveFileDialogExcel.ShowDialog();
                if (dlgResSaveFile == DialogResult.Cancel)
                {
                    isExportSuccessFul = false;
                    return 0;
                }
                isExportSuccessFul = true;
                ExportedExcelValue = saveFileDialogExcel.FileName;
                if (saveFileDialogExcel.FileName != "")
                {
                    using (Stream exportStream = saveFileDialogExcel.OpenFile())
                    {
                        tmpWorkbook.ActiveWorksheet.Name = string.IsNullOrEmpty(ExcelSheetName) ? "Sheet1" : ExcelSheetName;
                        tmpWorkbook.Save(exportStream);
                        //exportStream.Close();
                    }
                }
                if (isExportSuccessFul == true)
                {
                    //Dialog.showSuccessMessage(ResourceBase.mst1065, targetFileName); 
                    //Open Excel on export
                    if (CheckExcelExport == true)
                        Process.Start(saveFileDialogExcel.FileName);
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void ExcelExporter_HeaderLabelExporting(object sender, HeaderLabelExportingEventArgs e)
        {
            if (e.Field.Label.ToString().Contains("~"))
            {
                e.Field.Label = e.Field.Label.ToString().TrimEnd('~');
            }
            if (e.Field.Label.ToString().Contains("*"))
            {
                e.Field.Label = e.Field.Label.ToString().TrimEnd('*');
            }
            e.FormatSettings.FillPattern = FillPatternStyle.Solid;
            e.FormatSettings.FillPatternForegroundColor = Color.FromRgb(10,118,196);
            e.FormatSettings.FontColor = Color.FromRgb(255, 255, 255);
           // e.FormatSettings.FontStyle = System.Windows.FontStyle.Equals(object a , );
        }

        private void exporter_CellExporting(object sender, CellExportingEventArgs e)
        {
            try
            {

              
                if (e.Field.DataType.Name == "DateTime")
                {
                    e.FormatSettings.FormatString = "dd/MM/yyyy";
                }

            }
            catch (Exception ex)
            {
            }
        }


        private static string _exportedExcelValue;        
        public static string ExportedExcelValue
        {
            get { return _exportedExcelValue; }
            set { _exportedExcelValue = value; }
        }

        private bool _checkExcelExport = true;
        public bool CheckExcelExport
        {
            get { return _checkExcelExport; }
            set { _checkExcelExport = value; } 
        }

        private string _excelSheetName;

        public string ExcelSheetName
        {
            get { return _excelSheetName; }
            set { _excelSheetName = value; }
        }



    }
}
