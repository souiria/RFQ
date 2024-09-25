/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name           :   XamDataGridExportHelper.cs
Function            :   Contains Code for Export of Grid data
Created By          :   Yati
Created on          :   02-Sep-2019
Revision History    :   Yati: 02-Sep-2019
*                       [ ]: Added null check for Label code value while exporting header of XamDataGrid 
*                       :   Amit: 19-Jan-2021
*                       [ ]: Added new handler to expose the export ended event to append any information on the data output.
****************************************************************************************************/
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media;
using Infragistics.Documents.Excel;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.ExcelExporter;
using System.Linq;

namespace Common.UX.Wpf.Helpers
{
	public class XamDataGridExportHelper
	{
		/// <summary>
		/// Occurs when export ended
		/// </summary>
		public EventHandler<ExportEndedEventArgs> ExportEnded { get; set; }
		/// <summary>
		/// This is a common function through which grid data will be exported
		/// <para>
		/// If true(1) means exported successful else error or user cancelled the operation
		/// </para>
		/// </summary>
		/// <param name="dataPresenter">XamDataGrid presenter object</param>
		/// <param name="targetFileName">Name of the screen as default target excel document name</param>        
		public int ExportGridToExcel(DataPresenterBase dataPresenter, string targetFileName)

		{
			DataPresenterExcelExporter excelExporter = new DataPresenterExcelExporter();
			if (ExportEnded != null)
			{
				excelExporter.ExportEnded += ExportEnded; ;
			}
			excelExporter.HeaderLabelExporting += ExcelExporter_HeaderLabelExporting;
			excelExporter.CellExporting += exporter_CellExporting;
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

				//Dialog.showSuccessMessage(ResourceBase.mst1065, targetFileName); 
				//Open Excel on export
				if (CheckExcelExport)
					Process.Start(saveFileDialogExcel.FileName);

				return 1;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		//private void DataPresenter_FieldLayoutInitializing(object sender, Infragistics.Windows.DataPresenter.Events.FieldLayoutInitializingEventArgs e)
		//{
		// e.FieldLayout.Fields.Lab
		//}

		public int NPRExportGridToExcel(DataPresenterBase dataPresenter, string targetFileName)
		{
			DataPresenterExcelExporter excelExporter = new DataPresenterExcelExporter();
			excelExporter.HeaderLabelExporting += ExcelExporter_HeaderLabelExporting;
			excelExporter.CellExporting += exporter_CellExporting;
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
						tmpWorkbook.ActiveWorksheet.Rows[0].Height = 1000;
						tmpWorkbook.ActiveWorksheet.Columns[0].Width = 11000;
						tmpWorkbook.ActiveWorksheet.Columns[1].Width = 5000;
						tmpWorkbook.ActiveWorksheet.Columns[2].Width = 2500;
						tmpWorkbook.ActiveWorksheet.Columns[3].Width = 2500;
						tmpWorkbook.ActiveWorksheet.Columns[4].Width = 2500;
						tmpWorkbook.ActiveWorksheet.Columns[5].Width = 2500;
						tmpWorkbook.ActiveWorksheet.Columns[6].Width = 2200;
						tmpWorkbook.ActiveWorksheet.Columns[7].Width = 2200;
						tmpWorkbook.ActiveWorksheet.Columns[8].Width = 1900;
						tmpWorkbook.ActiveWorksheet.Columns[9].Width = 3300;
						tmpWorkbook.ActiveWorksheet.Columns[10].Width = 2600;
						tmpWorkbook.ActiveWorksheet.Columns[11].Width = 2900;
						tmpWorkbook.ActiveWorksheet.Columns[13].Width = 2700;
						tmpWorkbook.ActiveWorksheet.Columns[14].Width = 2800;
						tmpWorkbook.ActiveWorksheet.Columns[16].Width = 3500;
						tmpWorkbook.ActiveWorksheet.Columns[19].Width = 4000;
						tmpWorkbook.ActiveWorksheet.Columns[20].Width = 4200;
						tmpWorkbook.ActiveWorksheet.Columns[21].Width = 3000;
						tmpWorkbook.ActiveWorksheet.Columns[22].Width = 2900;
						tmpWorkbook.ActiveWorksheet.Columns[23].Width = 4300;
						tmpWorkbook.ActiveWorksheet.Columns[24].Width = 4000;
						tmpWorkbook.ActiveWorksheet.Columns[25].Width = 3500;
						tmpWorkbook.ActiveWorksheet.Columns[26].Width = 3500;
						tmpWorkbook.ActiveWorksheet.Columns[27].Width = 2000;
						tmpWorkbook.ActiveWorksheet.Columns[28].Width = 4400;
						tmpWorkbook.ActiveWorksheet.Columns[29].Width = 3000;
						tmpWorkbook.ActiveWorksheet.Columns[30].Width = 3000;
						tmpWorkbook.ActiveWorksheet.Columns[31].Width = 2500;
						tmpWorkbook.ActiveWorksheet.Rows[0].CellFormat.WrapText = ExcelDefaultableBoolean.True;
						//tmpWorkbook.ActiveWorksheet.Rows.CellFormat.ShrinkToFit = ExcelDefaultableBoolean.True;
						//tmpWorkbook.ActiveWorksheet.Rows[0].CellFormat.FormatOptions = AutoFitMode.ExtendLastField;
						tmpWorkbook.Save(exportStream);
						//exportStream.Close();
					}
				}

				//Dialog.showSuccessMessage(ResourceBase.mst1065, targetFileName); 
				//Open Excel on export
				if (CheckExcelExport)
					Process.Start(saveFileDialogExcel.FileName);

				return 1;
			}
			catch (Exception)
			{
				return 0;
			}
		}

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

			if (e.Field != null && e.Field.Label.ToString().Contains("~"))
			{
				e.Field.Label = e.Field.Label.ToString().TrimEnd('~');
			}
			if (e.Field != null && e.Field.Label.ToString().Contains("*"))
			{
				e.Field.Label = e.Field.Label.ToString().TrimEnd('*');
			}
			e.FormatSettings.FillPattern = FillPatternStyle.Solid;
			e.FormatSettings.FillPatternForegroundColor = Color.FromRgb(10, 118, 196);
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
			catch (Exception)
			{
				// ignored
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
