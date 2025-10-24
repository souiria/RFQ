namespace Transformation.TypeConversion.DSI
{
    public static class HarnessWireMulticoreMarkers
    {
        public static IEnumerable<WireMulticoreMarkerDto> GetHarnessWireMulticoreMarkers(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            WireMulticoreMarkerDto model = new WireMulticoreMarkerDto();
            List<WireMulticoreMarkerDto> collection = new List<WireMulticoreMarkerDto>();
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
