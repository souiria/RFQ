namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessCenterStrips
    {
        public static IEnumerable<CentreStripModel> GetHarnessCenterStrips(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            CentreStripModel model = new CentreStripModel();
            List<CentreStripModel> collection = new List<CentreStripModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 9, line);

                bool stripLengthCheck = double.TryParse(split[3], out double stripLength);
                bool lengthChangeValueCheck = double.TryParse(split[5], out double lengthChangeValue);
                bool throughOrderCheck = double.TryParse(split[7], out double throughOrder);
                
                model.NodeName = split[0];
                model.Route = split[1];
                model.WireName = split[2];
                model.StripLength = stripLength;
                model.LengthChangeType = split[4];
                model.LengthChangeValue = lengthChangeValue;
                model.Option = split[6];
                model.ThroughOrder = throughOrder;
                collection.Add(model);
            }

            return collection;
        }
    }
}
