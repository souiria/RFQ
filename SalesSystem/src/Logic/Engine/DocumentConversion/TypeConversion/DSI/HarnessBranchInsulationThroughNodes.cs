namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessBranchInsulationThroughNodes
    {
        public static IEnumerable<BranchInsulationThroughNodeModel> GetHarnessBranchInsulationThroughNodes(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            BranchInsulationThroughNodeModel model = new BranchInsulationThroughNodeModel();
            List<BranchInsulationThroughNodeModel> collection = new List<BranchInsulationThroughNodeModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 6, line);

                bool throughOrderCheck = double.TryParse(split[1], out double throughOrder);

                model.PieceCode = split[0];
                model.ThroughOrder = throughOrder;
                model.ThroughNode = split[2];
                model.ThroughRoute = split[3];
                model.IsThroughFlag = ValueCalculator.CalculateLogicalValue(split[4], true);
                collection.Add(model);
            }

            return collection;
        }
    }
}
