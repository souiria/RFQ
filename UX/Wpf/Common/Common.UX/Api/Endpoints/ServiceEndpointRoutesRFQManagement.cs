using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
      //  public static readonly ServiceEndpointRoutes NPRBackLog = new ServiceEndpointRoutes("NPRBackLog");
       // public static readonly ServiceEndpointRoutes NPRBackLogstateless = new ServiceEndpointRoutes("NPRWebService/NPRBackLog");
        public static readonly ServiceEndpointRoutes RFQ = new ServiceEndpointRoutes("RFQ");
        public static readonly ServiceEndpointRoutes RFQSupplierSelection = new ServiceEndpointRoutes("RFQSupplierSelection");
        public static readonly ServiceEndpointRoutes FunctionControlSequenceGenerator = new ServiceEndpointRoutes("FunctionControlSequenceGenerator");
        public static readonly ServiceEndpointRoutes GetSequenceNumber = new ServiceEndpointRoutes("FunctionControlSequenceGenerator/GenerateSequenceNumber");
        public static readonly ServiceEndpointRoutes RFQSupplierSelectionDataPropagation = new ServiceEndpointRoutes("NPAToH1DataSynchronization/MaterialDataSync");
        public static readonly ServiceEndpointRoutes RFQSupplierSelectionActiveDataPropagation = new ServiceEndpointRoutes("NPRWebService/PropagateNPRToH1/NPRToH1ActiveDataSync");
        public static readonly ServiceEndpointRoutes PropagateNPRToH1ValidationsOnSQLServer = new ServiceEndpointRoutes("NPRWebService/PropagateNPRToH1/PropagateNPRToH1ValidationsOnSQLServer");
        public static readonly ServiceEndpointRoutes NPRBackLogStateless = new ServiceEndpointRoutes("NPRWebService/NPRBacklog");
        public static readonly ServiceEndpointRoutes GetNPRBackLogFilterByIdStateless = new ServiceEndpointRoutes("NPRWebService/NPRBacklog/GetNPRBackLogFilterById");
    }
}
