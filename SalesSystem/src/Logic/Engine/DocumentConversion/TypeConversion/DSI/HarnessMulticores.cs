using SharedModels.DocumentConverter.DSI.DTOs;

namespace DocumentConversion.TypeConversion.DSI
{
    public static class HarnessMulticores
    {
        public static IEnumerable<MulticoreSpecificationDto> GetHarnessMulticores(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            MulticoreSpecificationDto model = new MulticoreSpecificationDto();
            List<MulticoreSpecificationDto> collection = new List<MulticoreSpecificationDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 23, line);

                bool lengthChangeValueCheck = double.TryParse(split[6], out double lengthChangeValue);
                bool outerSheathCutBackAtEnd1ValueCheck = double.TryParse(split[8], out double outerSheathCutBackAtEnd1Value);
                bool outerSheathCutBackAtEnd2ValueCheck = double.TryParse(split[10], out double outerSheathCutBackAtEnd2Value);
                bool assemblyItemNumberCheck = double.TryParse(split[16], out double assemblyItemNumber);
                double unmodifiedMulticoreLength = 0;
                double modifiedMulticoreLength = 0;
                string itemPart1Value = "";
                string itemPart2Value = "";
                string itemPart3Value = "";

                if (split.Length == 26)
                {
                    bool unmodifiedMulticoreLengthCheck = double.TryParse(split[20], out unmodifiedMulticoreLength);
                    bool modifiedMulticoreLengthCheck = double.TryParse(split[21], out modifiedMulticoreLength);
                    itemPart1Value = split[22];
                    itemPart2Value = split[23];
                    itemPart3Value = split[24];
                }
                else if (split.Length == 25)
                {
                    if (!double.TryParse(split[20], out unmodifiedMulticoreLength))
                    {
                        itemPart1Value = split[20];
                        itemPart2Value = split[21];
                        itemPart3Value = split[22];
                    }

                    if (!double.TryParse(split[21], out modifiedMulticoreLength))
                    {
                        itemPart1Value = split[21];
                        itemPart2Value = split[22];
                        itemPart3Value = split[23];
                    }
                    else
                    {
                        itemPart1Value = split[22];
                        itemPart2Value = split[23];
                    }
                }
                else if (split.Length == 24)
                {
                    if (!double.TryParse(split[20], out unmodifiedMulticoreLength))
                    {
                        itemPart1Value = split[20];
                        itemPart2Value = split[21];
                        itemPart3Value = split[22];
                    }

                    if (!double.TryParse(split[21], out modifiedMulticoreLength))
                    {
                        itemPart1Value = split[21];
                        itemPart2Value = split[22];
                    }
                    else
                    {
                        itemPart1Value = split[22];
                    }
                }
                else if (split.Length == 23)
                {
                    if (!double.TryParse(split[20], out unmodifiedMulticoreLength))
                    {
                        itemPart1Value = split[20];
                        itemPart2Value = split[21];
                    }
                }
                else if (split.Length == 22)
                {
                    itemPart1Value = split[20];
                }

                model.MulticoreName = split[0];
                model.IsIncludedOnBom = ValueCalculator.CalculateLogicalValue(split[1], true);
                model.IsIncludedOnChart = ValueCalculator.CalculateLogicalValue(split[2], true);
                model.Tag = split[3];
                model.Note = split[4];
                model.LengthChangeType = split[5];
                model.LengthChangeValue = lengthChangeValue;
                model.OuterSheathCutBackAtEnd1Type = split[7];
                model.OuterSheathCutBackAtEnd1Value = outerSheathCutBackAtEnd1Value;
                model.OuterSheathCutBackAtEnd2Type = split[9];
                model.OuterSheathCutBackAtEnd2Value = outerSheathCutBackAtEnd2Value;
                model.Colour = split[11];
                model.Material = split[12];
                model.Specification = split[13];
                model.IsSheathed = ValueCalculator.CalculateLogicalValue(split[14], false);
                model.UserModule = split[15];
                model.AssemblyItemNumber = assemblyItemNumber;
                model.ParentMulticoreName = split[17];
                model.MulticoreOption = split[18];
                model.ParentMulticoreOption = split[19];
                model.UnmodifiedMulticoreLength = unmodifiedMulticoreLength;
                model.ModifiedMulticoreLength = modifiedMulticoreLength;
                model.PartNumber1 = itemPart1Value;
                model.PartNumber2 = itemPart2Value;
                model.PartNumber3 = itemPart3Value;
                collection.Add(model);
            }

            return collection;
        }
    }
}
