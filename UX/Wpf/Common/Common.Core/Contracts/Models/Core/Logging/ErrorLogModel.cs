using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Logging
{
    [DataContract, Serializable, Table("ApplicationErrorLog")]
    public class ErrorLogModel : BaseModel<Guid>
    {
        private string _content = null;
        [DataMember, Required, Column(TypeName = "varchar"), MaxLength]
        public string Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }

        private ErrorType _errorType;
        [DataMember]
        public ErrorType ErrorType
        {
            get => _errorType;
            set => SetProperty(ref _errorType, value);
        }

        private string _exceptionType;
        [DataMember, StringLength(100)]
        public string ExceptionType
        {
            get => _exceptionType;
            set => SetProperty(ref _exceptionType, value);
        }

        private string _callingMethod;
        [StringLength(100), DataMember]
        public string CallingMethod
        {
            get => _callingMethod;
            set => SetProperty(ref _callingMethod, value);
        }

        private string _className;
        [StringLength(100), DataMember]
        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }

        private string _methodName;
        [StringLength(100), DataMember]
        public string MethodName
        {
            get => _methodName;
            set => SetProperty(ref _methodName, value);
        }

        private string _physicalFileName;
        [DataMember, Column(TypeName = "varchar"), MaxLength]
        public string PhysicalFileName
        {
            get => _physicalFileName;
            set => SetProperty(ref _physicalFileName, value);
        }

        private string _stackTrace;
        [DataMember, Column(TypeName = "varchar"), MaxLength]
        public string StackTrace
        {
            get => _stackTrace;
            set => SetProperty(ref _stackTrace, value);
        }

        private string _innerException;
        [DataMember, Column(TypeName = "varchar"), MaxLength]
        public string InnerException
        {
            get => _innerException;
            set => SetProperty(ref _innerException, value);
        }

        private byte[] _snapShotData;
        [DataMember, MaxLength, Column(TypeName = "image")]
        public byte[] SnapShotData
        {
            get => _snapShotData;
            set => SetProperty(ref _snapShotData, value);
        }
    }
}
