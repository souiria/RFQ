/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name          :   ISSRSReportViewer.cs
Function           :   Interface for SSRSReportViewer 
Created By         :   Yati Mathur
Created on         :   03-Apr-2019
Revision History   :  [27-Mar-2023]:Dharmendra 
                   : [] Add New Method for Save SSRS in pdf format
                   : [28-Mar-2023] : Ranjay 
                   : [] Added New Method for Save SSRS in excel format
                   : [07-Jul-2023] : Dharmendra 
                   : [] Modidifed Methods SaveSSRSReportAsExcel and SaveSSRSReportAsPdf for print ssrs report in excel and pdf format
                   :     from multiple data set
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Common.UX.Logging;
using Microsoft.Reporting.WinForms;

namespace Common.UX.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for SSRSReportControl.xaml
    /// </summary>
    public partial class SSRSReportControl
    {
        ReportDataSource reportDataSources = null;
        List<ReportDataSource> reportDataSourceColletion = null;
        Dictionary<string, string> _paramList;
        string _reportName = "";
        public SSRSReportControl(string reportName, object reportDataCollection, Dictionary<string, string> paramList)
        {
            InitializeComponent();
            _paramList = paramList;
            reportDataSources = new ReportDataSource("DS_" + reportName, reportDataCollection);
            reportDataSourceColletion = new List<ReportDataSource>();
            reportDataSourceColletion.Add(reportDataSources);
            _reportName = reportName;
            _reportViewer.Load += ReportViewer_Load;
        }

        public SSRSReportControl(string reportName, Dictionary<string, string> paramList, Dictionary<string, object> dataSource)
        {
            InitializeComponent();
            _paramList = paramList;
            reportDataSourceColletion = new List<ReportDataSource>();
            foreach (var item in dataSource)
            {
                reportDataSourceColletion.Add(new ReportDataSource(item.Key, item.Value));
            }

            _reportName = reportName;
            _reportViewer.Load += ReportViewer_Load;
        }

        private bool _isReportViewerLoaded;
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            //if (!Directory.Exists("Logs"))
            //{
            //    Directory.CreateDirectory("Logs"); 
            //}
            //using (StreamWriter w = File.AppendText("Logs\\log.txt"))
            //{
            try
            {
                if (!_isReportViewerLoaded)
                {
                    UXLogger.UXLoggingForDebug("Start: _isReportViewerLoaded");
                    List<ReportParameter> reportParamList = new List<ReportParameter>();

                    foreach (var param in _paramList)
                    {
                        reportParamList.Add(new ReportParameter(param.Key, param.Value));
                    }
                    reportParamList.Add(new ReportParameter("p_cmnhdr_ProgramId", "Program"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Page", "Page"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Date", "Date"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Time", "Time"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_EOF", "End of Report"));
                    //reportParamList.Add(new ReportParameter("p_Cap_PrintBy", "Printed By"));
                    //reportParamList.Add(new ReportParameter("p_Cap_NoRowMessage", "No Data Found......"));
                    // reportParamList.Add(new ReportParameter("p_UserId", Convert.ToString(UserPreferenceSetupHelper.CurrentUser.UserGuid)));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_DateFormat", "dd/MM/yyyy"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontName", "Courier New"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontSize", "8pt"));
                    UXLogger.UXLoggingForDebug("Parameter Initialized: _isReportViewerLoaded");

                    _reportViewer.ProcessingMode = ProcessingMode.Local;

                    _reportViewer.LocalReport.DataSources.Clear();
                    foreach (var reportDataSource in reportDataSourceColletion)
                    {
                        this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                    }
                    string startupPath = Environment.CurrentDirectory;
                    _reportViewer.LocalReport.ReportPath = startupPath + @"\SSRSReport\" + _reportName + ".rdl";
                    _reportViewer.LocalReport.SetParameters(reportParamList);
                    _reportViewer.RefreshReport();
                    _isReportViewerLoaded = true;
                    UXLogger.UXLoggingForDebug("ReportViewer_Load: Report Displayed");
                }
            }

            catch (Exception ex)
            {
                UXLogger.UXLoggingForDebug("Inner Exception Occurred: ReportViewer_Load" + ex.InnerException.Message);
                UXLogger.UXLoggingForDebug("Exception Occurred: ReportViewer_Load" + ex.Message);
                throw;
            }
            //}
        }

        public void SaveAsPdf()
        {
            try
            {
                if (!_isReportViewerLoaded)
                {
                    UXLogger.UXLoggingForDebug("Start: SaveAsPdf");
                    List<ReportParameter> reportParamList = new List<ReportParameter>();

                    foreach (var param in _paramList)
                    {
                        reportParamList.Add(new ReportParameter(param.Key, param.Value));
                    }
                    reportParamList.Add(new ReportParameter("p_cmnhdr_ProgramId", "Program"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Page", "Page"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Date", "Date"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Time", "Time"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_EOF", "End of Report"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_DateFormat", "dd/MM/yyyy"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontName", "Courier New"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontSize", "8pt"));
                    UXLogger.UXLoggingForDebug("Parameter Initialized: SaveAsPdf");

                    _reportViewer.ProcessingMode = ProcessingMode.Local;
                    _reportViewer.LocalReport.DataSources.Clear();
                  //  _reportViewer.LocalReport.DataSources.Add(reportDataSources);
                    foreach (var reportDataSource in reportDataSourceColletion)
                    {
                        this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                    }

                    _reportViewer.LocalReport.ReportPath = Environment.CurrentDirectory + @"\SSRSReport\" + _reportName + ".rdl";
                    _reportViewer.LocalReport.SetParameters(reportParamList);
                    _isReportViewerLoaded = true;

                    using (SaveFileDialog savepdfDialog = new SaveFileDialog())
                    {
                        savepdfDialog.Filter = "PDF (*.pdf)|*.pdf";
                        savepdfDialog.FileName = _reportName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"); ;
                        savepdfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        savepdfDialog.RestoreDirectory = false;
                        DialogResult dlgResSaveFile = savepdfDialog.ShowDialog();
                        if (dlgResSaveFile == DialogResult.OK)
                        {
                            string FileName = savepdfDialog.FileName;

                            var dataByte = _reportViewer.LocalReport.Render("PDF", null, out _, out _, out _, out _, out _);
                            using (FileStream fs = File.Create(FileName))
                            {
                                fs.Write(dataByte, 0, dataByte.Length);
                            }

                            Process.Start(FileName);
                            UXLogger.UXLoggingForDebug("SaveAsPdf: Report Saved.");
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                UXLogger.UXLoggingForDebug("Inner Exception Occurred: SaveAsPdf" + ex.InnerException.Message);
                UXLogger.UXLoggingForDebug("Exception Occurred: SaveAsPdf" + ex.Message);
                throw;
            }
        }

        public void SaveAsExcel()
        {
            try
            {
                if (!_isReportViewerLoaded)
                {
                    UXLogger.UXLoggingForDebug("Start: SaveAsExcel");
                    List<ReportParameter> reportParamList = new List<ReportParameter>();

                    foreach (var param in _paramList)
                    {
                        reportParamList.Add(new ReportParameter(param.Key, param.Value));
                    }
                    reportParamList.Add(new ReportParameter("p_cmnhdr_ProgramId", "Program"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Page", "Page"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Date", "Date"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_Time", "Time"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_EOF", "End of Report"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_DateFormat", "dd/MM/yyyy"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontName", "Courier New"));
                    reportParamList.Add(new ReportParameter("p_cmnhdr_FontSize", "8pt"));
                    UXLogger.UXLoggingForDebug("Parameter Initialized: SaveAsExcel");

                    _reportViewer.ProcessingMode = ProcessingMode.Local;
                    _reportViewer.LocalReport.DataSources.Clear();
                    foreach (var reportDataSource in reportDataSourceColletion)
                    {
                        this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                    }
                    _reportViewer.LocalReport.ReportPath = Environment.CurrentDirectory + @"\SSRSReport\" + _reportName + ".rdl";
                    _reportViewer.LocalReport.SetParameters(reportParamList);
                    _isReportViewerLoaded = true;

                    using (SaveFileDialog savepdfDialog = new SaveFileDialog())
                    {
                        savepdfDialog.Filter = "Excel (*.xls)|*.xls";
                        savepdfDialog.FileName = _reportName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"); ;
                        savepdfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        savepdfDialog.RestoreDirectory = false;
                        DialogResult dlgResSaveFile = savepdfDialog.ShowDialog();
                        if (dlgResSaveFile == DialogResult.OK)
                        {
                            string FileName = savepdfDialog.FileName;
                            var dataByte = _reportViewer.LocalReport.Render("Excel", null, out _, out _, out _, out _, out _);
                            using (FileStream fs = File.Create(FileName))
                            {
                                fs.Write(dataByte, 0, dataByte.Length);
                            }

                            Process.Start(FileName);
                            UXLogger.UXLoggingForDebug("SaveAsExcel: Report Saved.");
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                UXLogger.UXLoggingForDebug("Inner Exception Occurred: SaveAsExcel" + ex.InnerException.Message);
                UXLogger.UXLoggingForDebug("Exception Occurred: SaveAsExcel" + ex.Message);
                throw;
            }
        }

    }
}
