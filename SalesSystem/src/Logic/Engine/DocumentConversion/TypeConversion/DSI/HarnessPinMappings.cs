using SharedModels.DocumentConverter.DSI.DTOs;

namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessPinMappings
    {
        public static IEnumerable<PinMappingDto> GetHarnessPinMappings(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            PinMappingDto model = new PinMappingDto();
            List<PinMappingDto> collection = new List<PinMappingDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 10, line);

                model.Node1 = split[0];
                model.Node2 = split[1];
                model.HarnessName1 = split[2];
                model.HarnessIssue1 = split[3];
                model.HarnessName2 = split[4];
                model.HarnessIssue2 = split[5];
                model.Separator = split[6];
                string[] cavitySplit = split[7].Split(split[6], StringSplitOptions.RemoveEmptyEntries);
                model.CavityMapping1 = string.Join("; ", cavitySplit);
                cavitySplit = split[8].Split(split[6], StringSplitOptions.RemoveEmptyEntries);
                model.CavityMapping2 = string.Join("; ", cavitySplit);
                collection.Add(model);
            }

            return collection;
        }
    }
}
