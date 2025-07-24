namespace DocumentConversion.TypeConversion.DSI
{
    public static class ModuleCompatibilityDetails
    {
        public static IEnumerable<ModuleCompatibilityModel> GetModuleCompatibilityDetails(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            ModuleCompatibilityModel model = new ModuleCompatibilityModel();
            List<ModuleCompatibilityModel> collection = new List<ModuleCompatibilityModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 4, line);

                model.ModuleCode1 = split[0];
                model.ModuleCode2 = split[1];
                model.Relationship = split[2];
                collection.Add(model);
            }

            return collection;
        }
    }
}
