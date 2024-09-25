using System;

namespace Common.UX.Api.Exceptions
{
    public class ExceptionResponse : Exception
    {
        public new string Message { get => ExceptionMessage; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public new string StackTrace { get; set; }
        public new ExceptionResponse InnerException { get; set; }
    }
}
