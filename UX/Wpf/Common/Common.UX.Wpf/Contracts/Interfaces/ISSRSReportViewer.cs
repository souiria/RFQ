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
                   : [] Added two New Methods SaveSSRSReportAsExcel and SaveSSRSReportAsPdf for print ssrs report in excel and pdf format
                   :     from multiple data set

****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Wpf.Contracts.Interfaces
{
    public interface ISSRSReportViewer<T>
    {
        void OpenSSRSReport(ObservableCollection<T> itemCollection, string header, Dictionary<string, string> paramsObject);
        void SaveSSRSReportAsPdf(ObservableCollection<T> itemCollection, string header, Dictionary<string, string> paramsObject);
        void SaveSSRSReportAsExcel(ObservableCollection<T> itemCollection, string header, Dictionary<string, string> paramsObject);
        void SaveSSRSReportAsExcel(string header, Dictionary<string, string> paramsObject, Dictionary<string, object> dataSource);
        void SaveSSRSReportAsPdf(string header, Dictionary<string, string> paramsObject, Dictionary<string, object> dataSource);
    }

}
