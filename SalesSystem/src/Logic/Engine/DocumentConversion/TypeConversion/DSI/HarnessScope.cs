using SharedModels.DocumentConverter.DSI.DTOs;

namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessScope
    {
        public static IEnumerable<HarnessScopeDto> GetHarnessScope(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            HarnessScopeDto model = new HarnessScopeDto();
            List<HarnessScopeDto> collection = new List<HarnessScopeDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 7, line);

                model.HarnessName1 = split[0];
                model.HarnessIssue1 = split[1];
                model.HarnessName2 = split[2];
                model.HarnessIssue2 = split[3];
                model.ScopeCategory = split[4];

                List<string> scope = new List<string>();
                for (int i = 5; i < split.Length; i++)
                {
                    string s = split[i].Trim();
                    if (!string.IsNullOrEmpty(s))
                    {
                        scope.Add(split[i]);
                    }
                }

                model.Scope = string.Join(", ", scope);

                collection.Add(model);
            }

            return collection;
        }
    }
}
