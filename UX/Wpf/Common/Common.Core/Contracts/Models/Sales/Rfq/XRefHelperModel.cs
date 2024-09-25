using System.Collections.Generic;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    public class XRefHelperModel
    {
        public string MatchedNumber { get; set; }
        public List<string> SEWSENumberList { get; set; }
    }
}
