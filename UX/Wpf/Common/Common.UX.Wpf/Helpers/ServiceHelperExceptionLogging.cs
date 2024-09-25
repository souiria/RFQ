using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Logging;

namespace Common.UX.Wpf.Helpers
{
    public static class ServiceHelperExceptionLogging
    {
        #region Exception Handling & Logging Methods
        public static IEnumerable<ErrorLogModel> ValidationMessage(string content, Guid loginId, byte[] snapShootData, [CallerMemberName] string memberName = "")
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.Content = content;
            errorLog.ErrorType = ErrorType.ValidationMessage;
            errorLog.ExceptionType = null;
            errorLog.CallingMethod = null;// memberName;
            errorLog.ClassName = null;
            errorLog.MethodName = null;
            errorLog.PhysicalFileName = null;
            errorLog.StackTrace = null;
            errorLog.InnerException = null;
            errorLog.CreatedBy = loginId;
            errorLog.ModifiedBy = loginId;
            errorLog.CrudOperationType = CrudOperationType.Create;
            errorLog.SnapShotData = snapShootData;
            lstErrorLog.Add(errorLog);
            return lstErrorLog;
        }
        public static IEnumerable<ErrorLogModel> Info(string content, Guid loginId, [CallerMemberName] string memberName = "")
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.Content = content;
            errorLog.ErrorType = ErrorType.Logging;
            errorLog.ExceptionType = null;
            errorLog.CallingMethod = null;// memberName;
            errorLog.ClassName = null;
            errorLog.MethodName = null;
            errorLog.PhysicalFileName = null;
            errorLog.StackTrace = null;
            errorLog.InnerException = null;
            errorLog.CreatedBy = loginId;
            errorLog.ModifiedBy = loginId;
            errorLog.CrudOperationType = CrudOperationType.Create;
            errorLog.SnapShotData = null;
            lstErrorLog.Add(errorLog);
            return lstErrorLog;
        }
        public static IEnumerable<ErrorLogModel> Exception(Exception exceptionRaised, Guid loginId, [CallerMemberName] string memberName = "")
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.ErrorType = ErrorType.Exception;
            var stackTrace = new System.Diagnostics.StackTrace(exceptionRaised, true); // create the stack trace
            var classNames = stackTrace.GetFrames().GroupBy(it => it.GetFileName()).Select(it => it.Key).Aggregate((i, j) => i + " | " + j);
            var methods = stackTrace.GetFrames().GroupBy(it => it.GetMethod().Name).Select(it => it.Key).Aggregate((i, j) => i + " | " + j);
            errorLog.MethodName = methods;
            errorLog.ClassName = exceptionRaised.TargetSite.ReflectedType.Name;
            errorLog.Content = exceptionRaised.Message;
            errorLog.ExceptionType = exceptionRaised.GetType().Name;
            errorLog.CallingMethod = exceptionRaised.TargetSite.Name;
            errorLog.InnerException = exceptionRaised.InnerException == null ? null : exceptionRaised.InnerException.Message;
            errorLog.MethodName = exceptionRaised.TargetSite.Name;
            errorLog.PhysicalFileName = classNames;
            errorLog.StackTrace = exceptionRaised.StackTrace;
            errorLog.CreatedBy = loginId;
            errorLog.ModifiedBy = loginId;
            errorLog.CrudOperationType = CrudOperationType.Create;
            lstErrorLog.Add(errorLog);
            return lstErrorLog;
        }
        #endregion
    }
}
