using SharedModels.DocumentConverter.DSI.DTOs;

namespace DocumentConversion.TypeConversion.DSI
{
   public static class HarnessNoteInformation
    {
        public static HarnessDto GetHarnessNoteInformation(HarnessDto model, IEnumerable<string> lines)
        {
            if (lines.Any())
            {
                model.AdditionalComments = string.Join(", ", lines);
            }

            return model;
        }
    }
}
