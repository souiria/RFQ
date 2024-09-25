using System;
using System.Collections.Generic;
using System.Linq;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Logging;

namespace Common.SF.Infrastructure.Helpers
{
    public class ExceptionMethods
    {
        public static IEnumerable<ErrorLogModel> LogValidationMessage(string content, Guid loginId, byte[] snapShootData)
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.Content = content;
            errorLog.ErrorType = ErrorType.ValidationMessage;
            errorLog.ExceptionType = null;
            errorLog.CallingMethod = null;
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
        public static IEnumerable<ErrorLogModel> LogInfo(string content, Guid loginId)
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.Content = content;
            errorLog.ErrorType = ErrorType.Logging;
            errorLog.ExceptionType = null;
            errorLog.CallingMethod = null;
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

        public static IEnumerable<ErrorLogModel> LogException(Exception exceptionRaised, Guid loginId)
        {
            List<ErrorLogModel> lstErrorLog = new List<ErrorLogModel>();
            ErrorLogModel errorLog = new ErrorLogModel();
            errorLog.ErrorType = ErrorType.Exception;
            var stackTrace = new System.Diagnostics.StackTrace(exceptionRaised, true); // create the stack trace
            var classNames = stackTrace.GetFrames().GroupBy(it => it.GetFileName()).Select(it => it.Key).Aggregate((i, j) => i + " | " + j);
            var Methods = stackTrace.GetFrames().GroupBy(it => it.GetMethod().Name).Select(it => it.Key).Aggregate((i, j) => i + " | " + j);
            errorLog.MethodName = Methods;
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
    }
}
