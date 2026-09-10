namespace Transformation.TypeConversion.DSI
{
    public static class HarnessWireThroughNodes
    {
        public static IEnumerable<WireThroughNodeDto> GetHarnessWireThroughNodes(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            List<WireThroughNodeDto> collection = new List<WireThroughNodeDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 7, line);

                bool throughOrderCheck = double.TryParse(split[2], out double throughOrder);
                WireThroughNodeDto model = new WireThroughNodeDto();

                model.WireName = split[0];
                model.Option = split[1];
                model.ThroughOrder = throughOrder;
                model.ThroughNode = split[3];
                model.ThroughRoute = split[4];
                model.IsThroughFlag = ValueCalculator.CalculateLogicalValue(split[5], true);
                collection.Add(model);
            }

            return collection;
        }
    }
}
