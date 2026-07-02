namespace EngSol.Services
{
    public static class SampleEngSolDataService
    {
        #region Derivative
        public static ListDerivatives PopulateDerivatives()
        {
            ListDerivatives listDerivativesGrpc = new ListDerivatives();
            for(int i = 1; i <= 5; i++)
            {
                DerivativeGrpc derivativeGrpc = new DerivativeGrpc();
                derivativeGrpc.CompositeId = i;
                derivativeGrpc.DerivativeID = i;
                derivativeGrpc.IHSDerivativePartNumber = $"IHSDerivativePartNumber{i}";
                derivativeGrpc.DrawingChangeControlStatus = i;
                derivativeGrpc.DerivativeName = $"DerivativeName_{i}";
                derivativeGrpc.HarnessType = $"HarnessType_{i}";
                derivativeGrpc.ExpiryDate = DateTime.UtcNow.AddDays(i).ToUniversalTime().ToTimestamp();
                derivativeGrpc.WireCount = i;
                derivativeGrpc.MultiCoreLeadGroupCount = i;
                derivativeGrpc.TwistedLeadGroupCount = i;
                derivativeGrpc.MultiCoreInnerCoreLeadsCount = i;
                derivativeGrpc.DerivativeUploadStatusFlag = false;
                listDerivativesGrpc.DerivativeGrpc.Add(derivativeGrpc);
            }

            DerivativeGrpc fixedDerivativeGrpc = new DerivativeGrpc();
            fixedDerivativeGrpc.CompositeId = 0;
            fixedDerivativeGrpc.DerivativeID = 0;
            fixedDerivativeGrpc.IHSDerivativePartNumber = $"IHSDerivativePartNumber";
            fixedDerivativeGrpc.DrawingChangeControlStatus = 0;
            fixedDerivativeGrpc.DerivativeName = $"DerivativeName";
            fixedDerivativeGrpc.HarnessType = $"HarnessType";
            fixedDerivativeGrpc.ExpiryDate = DateTime.UtcNow.ToUniversalTime().ToTimestamp();
            fixedDerivativeGrpc.WireCount = 0;
            fixedDerivativeGrpc.MultiCoreLeadGroupCount = 0;
            fixedDerivativeGrpc.TwistedLeadGroupCount = 0;
            fixedDerivativeGrpc.MultiCoreInnerCoreLeadsCount = 0;
            fixedDerivativeGrpc.DerivativeUploadStatusFlag = false;
            listDerivativesGrpc.DerivativeGrpc.Add(fixedDerivativeGrpc);

            return listDerivativesGrpc;
        }

        #endregion
    }
}
