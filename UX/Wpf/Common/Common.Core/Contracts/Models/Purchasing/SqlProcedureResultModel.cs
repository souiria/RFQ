using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SqlProcedureResultModel : BaseModel<Guid>
    {
        private int _errorNo;

        public int ErrorNo
        {
            get => _errorNo;
            set =>   _errorNo= value;
        }
        private string _errorDesc;

        public string ErrorDesc
        {
            get => _errorDesc;
            set =>  _errorDesc = value;
        }

    }

    [DataContract, Serializable]
    public class SqlProcedureResultExceptionModel : BaseModel<Guid>
    {
        private int _errorNumber;

        public int ERRORNUMBER
        {
            get => _errorNumber;
            set => _errorNumber = value;
        }
        private string _errorMessage;

        public string ERRORMESSAGE
        {
            get => _errorMessage;
            set => _errorMessage = value;
        }

    }
}
