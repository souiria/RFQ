namespace DocumentConversion.TypeConversion.DSI
{
   public static class HarnessNoteInformation
    {
        public static HarnessModel GetHarnessNoteInformation(HarnessModel model, IEnumerable<string> lines)
        {
            if (lines.Any())
            {
                model.AdditionalComments = string.Join(", ", lines);
            }

            return model;
        }
    }
}
