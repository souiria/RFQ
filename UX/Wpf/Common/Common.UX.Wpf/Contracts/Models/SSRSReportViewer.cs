/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name          :   SSRSReportViewer.cs
Function           :   Contains generic method for SSRSReport formation and show  
Created By         :   Yati Mathur
Created on         :   03-Apr-2019
Revision History   : [27-Mar-2023]:Dharmendra 
                   : [] Add New Method for Save SSRS in pdf format
                   : [28-Mar-2023]:Ranjay 
                   : [] Added New Method for Save SSRS in excel format
                   : [07-Jul-2023] : Dharmendra 
                   : [] Added two New Methods SaveSSRSReportAsExcel and SaveSSRSReportAsPdf for print ssrs report in excel and pdf format
                   :     from multiple data set
****************************************************************************************************/
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Common.UX.Wpf.Contracts.Models
{
    public class SSRSReportViewer<Object> : ISSRSReportViewer<Object>
    {
        public Window SSRSWindow = null;

        public void OpenSSRSReport(ObservableCollection<Object> itemCollection, string header, Dictionary<string, string> paramsObject)
        {
            Window window = new Window();
            window.WindowState = WindowState.Maximized;
            window.Title = "Harness One : " + header + " - Report";
            header = header.Replace(" ", string.Empty);
            window.Content = new SSRSReportControl(header, itemCollection, paramsObject);
            window.ResizeMode = ResizeMode.NoResize;
            window.Show();
        }

        public void SaveSSRSReportAsPdf(ObservableCollection<Object> itemCollection, string header, Dictionary<string, string> paramsObject)
        {
            var sSRSReportControl = new SSRSReportControl(header, itemCollection, paramsObject);
            sSRSReportControl.SaveAsPdf();
        }

        public void SaveSSRSReportAsExcel(ObservableCollection<Object> itemCollection, string header, Dictionary<string, string> paramsObject)
        {
            var sSRSReportControl = new SSRSReportControl(header, itemCollection, paramsObject);
            sSRSReportControl.SaveAsExcel();
        }

        public void SaveSSRSReportAsExcel(string header, Dictionary<string, string> paramsObject , Dictionary<string, object> dataSource)
        {
            var sSRSReportControl = new SSRSReportControl(header, paramsObject, dataSource);
            sSRSReportControl.SaveAsExcel();
        }
        public void SaveSSRSReportAsPdf(string header, Dictionary<string, string> paramsObject, Dictionary<string, object> dataSource)
        {
            var sSRSReportControl = new SSRSReportControl(header, paramsObject,dataSource);
            sSRSReportControl.SaveAsPdf();
        }
    }
}
