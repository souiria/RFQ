namespace Transformation.TypeConversion.DSI
{
    public static class HarnessMidWireComponents
    {
        public static IEnumerable<MidWireComponentDto> GetHarnessMidWireComponents(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            List<MidWireComponentDto> collection = new List<MidWireComponentDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 8, line);

                bool throughOrderCheck = double.TryParse(split[6], out double throughOrder);
                MidWireComponentDto model = new MidWireComponentDto();

                model.NodeName = split[0];
                model.Route = split[1];
                model.WireName = split[2];
                model.Option = split[3];
                model.MidWireOption = split[4];
                model.Cavity = split[5];
                model.ThroughOrder = throughOrder;
                collection.Add(model);
            }

            return collection;
        }
    }
}
