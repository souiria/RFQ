using Transformation.Helpers;

namespace Transformation.TypeConversion.DSI
{
    class CompositeOptionCodes
    {
        public static IEnumerable<CompositeOptionDto> GetCompositeOptionCodes(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            CompositeOptionDto model = new CompositeOptionDto();
            List<CompositeOptionDto> collection = new List<CompositeOptionDto>();
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
