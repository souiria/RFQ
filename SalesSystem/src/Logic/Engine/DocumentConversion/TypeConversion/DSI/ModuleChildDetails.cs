namespace DocumentConversion.TypeConversion.DSI
{
    public static class ModuleChildDetails
    {
        public static IEnumerable<ModuleChildDetailDto> GetModuleChildDetails(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            ModuleChildDetailDto model = new ModuleChildDetailDto();
            List<ModuleChildDetailDto> collection = new List<ModuleChildDetailDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 39, line);

                bool boardLengthCheck = double.TryParse(split[15], out double boardLength);
                bool boardWidthCheck = double.TryParse(split[16], out double boardWidth);
                bool tubeAddOnFactorCheck = double.TryParse(split[34], out double tubeAddOnFactor);

                model.ModuleCode = split[0];
                model.IsCoreModule = ValueCalculator.CalculateLogicalValue(split[1], false);
                model.HarnessName1 = split[2];
                model.HarnessIssue1 = split[3];
                model.HarnessDate1 = !string.IsNullOrWhiteSpace(split[4]) ? ErrorCheckHelper.CheckDateTimeFormatException(split[4]) : (DateTime?)null;
                model.SimilarHarnessName1 = split[5];
                model.SimilarHarnessIssue1 = split[6];
                model.HarnessName2 = split[7];
                model.HarnessIssue2 = split[8];
                model.HarnessDate2 = !string.IsNullOrWhiteSpace(split[9]) ? ErrorCheckHelper.CheckDateTimeFormatException(split[9]) : (DateTime?)null;
                model.SimilarHarnessName2 = split[10];
                model.SimilarHarnessIssue2 = split[11];
                model.Customer = split[12];
                model.Site = split[13];
                model.Range = split[14];
                model.BoardLength = boardLength;
                model.BoardWidth = boardWidth;
                model.Datum = split[17];
                model.UserField1 = split[18];
                model.UserField2 = split[19];
                model.UserField3 = split[20];
                model.UserField4 = split[21];
                model.UserField5 = split[22];
                model.Checker = split[23];
                model.Inputter = split[24];
                model.DraftedBy = split[25];
                model.PreparedBy = split[26];
                model.Type = split[27];
                model.Title = split[28];
                model.EngineSize = split[29];
                model.ManufacturingCell = split[30];
                model.Trim = split[31];
                model.HandDrive = split[32];
                model.TubeAddOnType = split[33];
                model.TubeAddOnFactor = tubeAddOnFactor;
                model.IsManualTerminal = ValueCalculator.CalculateLogicalValue(split[35], false);
                model.IsAllConnectorSealed = ValueCalculator.CalculateLogicalValue(split[36], false);
                model.AlphaCode = split[37];
                collection.Add(model);
            }

            return collection;
        }
    }
}
