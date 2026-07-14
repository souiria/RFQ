namespace Transformation.TypeConversion.DSI
{
    public static class HarnessBranchInsulations
    {
        public static IEnumerable<BranchInsulationDto> GetHarnessBranchInsulations(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            BranchInsulationDto model = new BranchInsulationDto();
            List<BranchInsulationDto> collection = new List<BranchInsulationDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 39, line);

                bool diameterCheck = double.TryParse(split[6], out double diameter);
                bool manualAmountCheck = double.TryParse(split[13], out double manualAmount);
                bool joinNumberCheck = double.TryParse(split[15], out double joinNumber);
                bool assemblyItemNumberCheck = double.TryParse(split[16], out double assemblyItemNumber);
                bool layerCheck = double.TryParse(split[17], out double layer);
                bool wallThicknessCheck = double.TryParse(split[25], out double wallThickness);
                bool numberOfTurnsCheck = double.TryParse(split[26], out double numberOfTurns);
                bool turnPerBreakoutCheck = double.TryParse(split[27], out double turnsPerBreakout);
                bool turnsPerBranchCheck = double.TryParse(split[28], out double turnsPerBranch);
                bool distanceBetweenItemsCheck = double.TryParse(split[29], out double distanceBetweenItems);
                bool longestDistanceCheck = double.TryParse(split[30], out double longestDistance);
                bool distanceFromConnectorCheck = double.TryParse(split[31], out double distanceFromConnector);
                bool tubeSelectionFactorCheck = double.TryParse(split[33], out double tubeSelectionFactor);
                bool cutBackCheck = double.TryParse(split[34], out double cutBack);

                model.StartNode = split[0];
                model.StartRoute = split[1];
                model.EndNode = split[2];
                model.EndRoute = split[3];
                model.PieceCode = split[4];
                model.InsulationCode = split[5];
                model.Diameter = diameter;
                model.CircuitOption = split[7];
                model.InsulationNote = split[8];
                model.UserModule = split[9];
                model.AssignedModule = split[10];
                model.ModuleFrom = split[11];
                model.CalculationMethod = split[12];
                model.ManualAmount = manualAmount;
                model.SplitValue = split[14];
                model.JoinNumber = joinNumber;
                model.AssemblyItemNumber = assemblyItemNumber;
                model.Layer = layer;
                model.InsulationType = split[18];
                model.PartNumber1 = split[19];
                model.PartNumber2 = split[20];
                model.PartNumber3 = split[21];
                model.Colour = split[22];
                model.Type = split[23];
                model.Material = split[24];
                model.WallThickness = wallThickness;
                model.NumberOfTurns = numberOfTurns;
                model.TurnsPerBreakout = turnsPerBreakout;
                model.TurnsPerBranch = turnsPerBranch;
                model.DistanceBetweenItems = distanceBetweenItems;
                model.LongestDistance = longestDistance;
                model.DistanceFromConnector = distanceFromConnector;
                model.TubeSelectionType = split[32];
                model.TubeSelectionFactor = tubeSelectionFactor;
                model.CutBack = cutBack;
                model.IsConvoluted = ValueCalculator.CalculateLogicalValue(split[35], true);
                model.IsSlit = ValueCalculator.CalculateLogicalValue(split[36], true);
                model.ModuleSpecificData = split[37];
                collection.Add(model);
            }

            return collection;
        }
    }
}
