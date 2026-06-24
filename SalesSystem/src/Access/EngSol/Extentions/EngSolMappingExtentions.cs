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
            data.WireLengthPlus = entity.WireLengthPlus;
            data.WireLengthMinus = entity.WireLengthMinus;
            data.UTurnLen = entity.UTurnLen;
            return data;
        }
    }
}
