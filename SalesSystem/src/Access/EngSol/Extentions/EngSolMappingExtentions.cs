namespace EngSol.Extentions
{
    public static class EngSolMappingExtentions
    {
        public static DerivativeWiresGrpc MapToDerivativeWiresGrpc(this DbDerivativeWires entity)
        {
            DerivativeWiresGrpc data = new DerivativeWiresGrpc();
            data.DerivativeID = entity.DerivativeId;
            data.EndA = entity.EndA;
            data.EndB = entity.EndB;
            data.WireType = entity.WireType;
            data.WireSize = entity.WireSize;
            data.WireFlex = entity.WireFlex;
            data.WireColour = entity.WireColour;
            data.WireLength = entity.WireLength;
            data.WDrgLength = entity.WDrgLength;
            data.WChgLength = entity.WChgLength;
            data.WireGroupType = entity.WireGroupType;
            data.WireGroupSize = entity.WireGroupSize;
            data.WireGroupNumber = entity.WireGroupNumber;
            data.TerminalNumberA = entity.TerminalNumberA;
            data.SealNumberA = entity.SealnumberA;
            data.AttPartNumber1A = entity.AttPartNumber1A;
            data.AttPartNumber2A = entity.AttPartNumber2A;
            data.StripLengthA = entity.StripLengthA;
            data.ConnectorNumberA = entity.ConnectorNumberA;
            data.ConnectorNameA = entity.ConnectorNameA;
            data.CavityNumberA = entity.CavityNumberA;
            data.DoubleCrimpA = entity.DoubleCrimpA;
            data.TerminalNumberB = entity.TerminalNumberB;
            data.SealNumberB = entity.SealNumberB;
            data.AttPartNumber1B = entity.AttPartNumber1B;
            data.AttPartNumber2B = entity.AttPartNumber2B;
            data.StripLengthB = entity.StripLengthB;
            data.ConnectorNumberB = entity.ConnectorNumberB;
            data.ConnectorNameB = entity.ConnectorNameB;
            data.CavityNumberB = entity.CavityNumberB;
            data.DoubleCrimpB = entity.DoubleCrimpB;
            data.SolderA = entity.SolderA;
            data.SolderB = entity.SolderB;
            data.WeldA = entity.WeldA;
            data.WeldB = entity.WeldB;
            data.WireLengthPlus = (int?)entity.WireLengthPlus;
            data.WireLengthMinus = (int?)entity.WireLengthMinus;
            data.WICFlag = entity.WICFlag;
            data.UTurnLen = entity.UTurnLen.HasValue ? (double)entity.UTurnLen.Value : 0;
            return data;
        }

        public static DerivativePartsGrpc MapToDerivativePartsGrpc(this DbDerivativeParts entity)
        {
            DerivativePartsGrpc data = new DerivativePartsGrpc();
            data.DerivativeID = entity.DerivativeId;
            data.PartNumber = entity.PartNumber;
            data.PartDescription = entity.PartDescription;
            data.PartQuantity = entity.PartQuantity;
            data.PartLength = (int?)entity.PartLength;
            data.PartSlit = entity.PartSlit;
            data.PartClass = entity.PartClass;
            return data;
        }

        public static DerivativeGrpc MapToDerivativeGrpc(this DbDerivatives entity)
        {
            DerivativeGrpc data = new DerivativeGrpc();
            data.CompositeId = entity.CompositeId;
            data.DerivativeID = entity.DerivativeId;
            data.IHSDerivativePartNumber = entity.IHSDerivativePartNumber;
            data.DerivativeName = entity.DerivativeName;
            data.DrawingChangeControlStatus = entity.DrawingChangeControlStatus;
            data.HarnessType = entity.HarnessType;
            data.ExpiryDate = entity.ExpiryDate!.Value.ToUniversalTime().ToTimestamp();
            data.WireCount = entity.WireCount;
            data.MultiCoreLeadGroupCount = entity.MultiCoreLeadGroupCount;
            data.TwistedLeadGroupCount = entity.TwistedLeadGroupCount;
            data.MultiCoreInnerCoreLeadsCount = entity.MultiCoreInnerCoreLeadsCount;
            data.DerivativeUploadStatusFlag = entity.DerivativeUploadStatusFlag;
            return data;
        }
    }
}
