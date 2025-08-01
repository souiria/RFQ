using SharedModels.DocumentConverter.DSI.DTOs;

namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessNameInformation
    {
        public static HarnessDto GetHarnessNameInformation(IEnumerable<string> sectionList, string splitter)
        {
            string[] separator = [splitter];
            HarnessDto harnessModel = new HarnessDto();
            foreach (string line in sectionList)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 42, line);
                bool fileVersionCheck = double.TryParse(split[3], out double fileVersion);
                bool boardLengthCheck = double.TryParse(split[14], out double boardLength);
                bool boardWidthCheck = double.TryParse(split[15], out double boardWidth);
                bool tubeAddOnFactorCheck = double.TryParse(split[15], out double tubeAddOnFactor);

                harnessModel.HarnessName1 = split[0];
                harnessModel.SimilarHarnessName1 = split[8];
                harnessModel.HarnessIssue1 = split[1];
                harnessModel.SimilarHarnessIssue1 = split[9];
                harnessModel.HarnessDate1 = ErrorCheckHelper.CheckDateTimeFormatException(split[2]);
                harnessModel.HarnessName2 = split[5];
                harnessModel.SimilarHarnessName2 = split[10];
                harnessModel.HarnessIssue2 = split[6];
                harnessModel.SimilarHarnessIssue2 = split[11];
                harnessModel.HarnessDate2 = ErrorCheckHelper.CheckDateTimeFormatException(split[7]);
                harnessModel.FileVersion = fileVersion;
                harnessModel.Customer = split[4];
                harnessModel.Site = split[12];
                harnessModel.Range = split[13];
                harnessModel.BoardLength = boardLength;
                harnessModel.BoardWidth = boardWidth;
                harnessModel.Datum = split[16];
                harnessModel.UserField1 = split[17];
                harnessModel.UserField2 = split[18];
                harnessModel.UserField3 = split[19];
                harnessModel.UserField4 = split[20];
                harnessModel.UserField5 = split[21];
                harnessModel.Checker = split[22];
                harnessModel.Inputter = split[23];
                harnessModel.DraftedBy = split[24];
                harnessModel.PreparedBy = split[25];
                harnessModel.Type = split[26];
                harnessModel.Title = split[27];
                harnessModel.EngineSize = split[28];
                harnessModel.ManufacturingCell = split[29];
                harnessModel.Trim = split[30];
                harnessModel.HandDrive = split[31];
                harnessModel.TubeAddOnType = split[32];
                harnessModel.TubeAddOnFactor = tubeAddOnFactor;
                harnessModel.IsManualTerminal = ValueCalculator.CalculateLogicalValue(split[34], false);
                harnessModel.IsAllConnectorsSealed = ValueCalculator.CalculateLogicalValue(split[35], false);
                harnessModel.DatumNode = split[36];
                harnessModel.DatumRoute = split[37];
                harnessModel.IsModule = ValueCalculator.CalculateLogicalValue(split[38], false);
                harnessModel.AlphaCode = split[39];
                harnessModel.IsPitchTableUsed = ValueCalculator.CalculateLogicalValue(split[40], false);
            }

            return harnessModel;
        }
    }
}
