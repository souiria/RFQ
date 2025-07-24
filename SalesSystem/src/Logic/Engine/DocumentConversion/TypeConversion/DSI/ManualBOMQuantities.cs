namespace DocumentConversion.TypeConversion.DSI
{
    public static class ManualBOMQuantities
    {
        public static IEnumerable<ManualBomQuantityModel> GetManualBOMQuantities(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            ManualBomQuantityModel model = new ManualBomQuantityModel();
            List<ManualBomQuantityModel> collection = new List<ManualBomQuantityModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 4, line);

                bool percentageCheck = double.TryParse(split[2], out double percentage);

                model.SplitValue = split[0];
                model.ModuleCode = split[1];
                model.Percentage = percentage;
                collection.Add(model);
            }

            return collection;
        }
    }
}
