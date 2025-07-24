namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessWireMulticoreMarkers
    {
        public static IEnumerable<WireMulticoreMarkerModel> GetHarnessWireMulticoreMarkers(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            WireMulticoreMarkerModel model = new WireMulticoreMarkerModel();
            List<WireMulticoreMarkerModel> collection = new List<WireMulticoreMarkerModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 8, line);

                bool spacingCheck = double.TryParse(split[6], out double spacing);

                model.ItemType = split[0];
                model.ItemName = split[1];
                model.Option = split[2];
                model.Location = split[3];
                model.Text = split[4];
                model.ColourCode = split[5];
                model.Spacing = spacing;
                collection.Add(model);
            }

            return collection;
        }
    }
}
