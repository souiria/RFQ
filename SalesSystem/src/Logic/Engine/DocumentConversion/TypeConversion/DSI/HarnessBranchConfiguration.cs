namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessBranchConfiguration
    {
        public static IEnumerable<BranchConfigurationModel> GetHarnessBranchConfiguration(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            List<BranchConfigurationModel> collection = new List<BranchConfigurationModel>();
            BranchConfigurationModel model = new BranchConfigurationModel();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 14, line);

                bool lengthCheck = double.TryParse(split[6], out double length);
                bool bundleDiameterCheck = double.TryParse(split[8], out double bundleDiameter);
                model.StartNode = split[0];
                model.StartRoute = split[1];
                model.StartCoordinates = split[2];
                model.EndNode = split[3];
                model.EndRoute = split[4];
                model.EndCoordinates = split[5];
                model.Length = length;
                model.CircuitOption = split[7];
                model.BundleDiameter = bundleDiameter;
                model.UserModule = split[9];
                model.AssignedModule = split[10];
                model.ModuleFrom = split[11];
                model.BendString = split[12];

                List<string> bend = new List<string>();
                for (int i = 19; i < split.Length; i++)
                {
                    string currentSplit = split[i].Trim();
                    if (!string.IsNullOrEmpty(currentSplit))
                    {
                        bend.Add(split[i]);
                    }
                }

                model.Bend = string.Join(", ", bend);
                collection.Add(model);
            }

            return collection;
        }
    }
}
