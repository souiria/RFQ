using Microsoft.Reporting.WinForms;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEWSE.H1.UX.Infrastructure.Core.Controls
{
    /// <summary>
    /// Interaction logic for SSRSReportControl.xaml
    /// </summary>
    public partial class SSRSReportControl : UserControl
    {
        ReportDataSource reportDataSource = null;
        Dictionary<string, string> _paramList;
        string _reportName = "";
        public SSRSReportControl(string reportName, object reportDataCollection, Dictionary<string, string> paramList)
        {
            InitializeComponent();
            _paramList = paramList;
            reportDataSource = new ReportDataSource("DS_" + reportName, reportDataCollection);
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
                        UXLogging.UXLoggingForDebug("Start: _isReportViewerLoaded");
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
                        UXLogging.UXLoggingForDebug("Parameter Initialized: _isReportViewerLoaded");

                        _reportViewer.ProcessingMode = ProcessingMode.Local;

                        _reportViewer.LocalReport.DataSources.Clear();
                        this._reportViewer.LocalReport.DataSources.Add(reportDataSource);
                        string startupPath = Environment.CurrentDirectory;
                        _reportViewer.LocalReport.ReportPath = startupPath + @"\SSRSReport\" + _reportName + ".rdl";
                        _reportViewer.LocalReport.SetParameters(reportParamList);
                        _reportViewer.RefreshReport();
                        _isReportViewerLoaded = true;
                        UXLogging.UXLoggingForDebug("ReportViewer_Load: Report Displayed");
                    }
                }

                catch (Exception ex)
                {
                    UXLogging.UXLoggingForDebug("Inner Exception Occurred: ReportViewer_Load" + ex.InnerException.Message);
                    UXLogging.UXLoggingForDebug("Exception Occurred: ReportViewer_Load" + ex.Message);
                    throw;
                }
            //}
        }

        
    }
}
