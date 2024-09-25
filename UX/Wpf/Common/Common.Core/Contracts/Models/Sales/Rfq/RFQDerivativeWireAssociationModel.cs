using System.Collections.Generic;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    public class RFQDerivativeWireAssociationModel
    {
        public string HarnessName { get; set; }
        public string WireName { get; set; }
        public string CompositeOptionString { get; set; }
        public string WireSize { get; set; }
        public string Colour { get; set; }
        public string Type { get; set; }
        public string MulticoreName { get; set; }
        public string End1NodeName { get; set; }
        public string End1Cavity { get; set; }
        public string End2NodeName { get; set; }
        public string End2Cavity { get; set; }
        public double Length { get; set; }
        public List<string> DerivativesContainingCollection { get; set; }
    }
}
