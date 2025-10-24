namespace Transformation.TypeConversion.DSI
{
    public static class HarnessCircuitInformation
    {
        public static IEnumerable<CompositeDetailDto> GetHarnessCircuitInformantion(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            List<CompositeDetailDto> collection = new List<CompositeDetailDto>();
            CompositeDetailDto model = new CompositeDetailDto();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 37, line);

                bool boardLengthCheck = double.TryParse(split[13], out double boardLength);
                bool boardWidthCheck = double.TryParse(split[14], out double boardWidth);
                bool tubeAddOnFactorCheck = double.TryParse(split[32], out double tubeAddOnFactor);
                model.HarnessName1 = split[0];
                model.SimilarHarnessName1 = split[7];
                model.HarnessIssue1 = split[1];
                model.SimilarHarnessIssue1 = split[8];
                model.HarnessDate1 = ErrorCheckHelper.CheckDateTimeFormatException(split[2]);
                model.HarnessName2 = split[4];
                model.SimilarHarnessName2 = split[9];
                model.HarnessIssue2 = split[5];
                model.SimilarHarnessIssue2 = split[10];
                model.HarnessDate2 = ErrorCheckHelper.CheckDateTimeFormatException(split[6]);
                model.Customer = split[3];
                model.Site = split[11];
                model.Range = split[12];
                model.BoardLength = boardLength;
                model.BoardWidth = boardWidth;
                model.Datum = split[15];
                model.UserField1 = split[16];
                model.UserField2 = split[17];
                model.UserField3 = split[18];
                model.UserField4 = split[19];
                model.UserField5 = split[20];
                model.Checker = split[21];
                model.Inputter = split[22];
                model.DraftedBy = split[23];
                model.PreparedBy = split[24];
                model.Type = split[25];
                model.Title = split[26];
                model.EngineSize = split[27];
                model.ManufacturingCell = split[28];
                model.Trim = split[29];
                model.HandDrive = split[30];
                model.TubeAddOnType = split[31];
                model.TubeAddOnFactor = tubeAddOnFactor;
                model.IsManualTerminal = ValueCalculator.CalculateLogicalValue(split[33], false);
                model.IsAllConnectorsSealed = ValueCalculator.CalculateLogicalValue(split[34], false);
                model.AlphaCode = split[35];

                List<string> circuitOption = new List<string>();
                for (int i = 36; i < split.Length; i++)
                {
                    string currentSplit = split[i].Trim();
                    if (!string.IsNullOrEmpty(currentSplit))
                    {
                        circuitOption.Add(split[i]);
                    }
                }

                model.CircuitOption = string.Join(", ", circuitOption);

                collection.Add(model);
            }

            return collection;
        }
    }
}
