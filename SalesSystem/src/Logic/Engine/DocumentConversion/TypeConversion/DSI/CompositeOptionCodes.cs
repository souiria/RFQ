namespace DocumentConversion.TypeConversion.DSI
{
    class CompositeOptionCodes
    {
        public static IEnumerable<CompositeOptionModel> GetCompositeOptionCodes(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            CompositeOptionModel model = new CompositeOptionModel();
            List<CompositeOptionModel> collection = new List<CompositeOptionModel>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 2, line);

                model.OptionName = split[0];
                model.Description = split[1];
                collection.Add(model);
            }

            return collection;
        }
    }
}
