using Transformation.Helpers;

namespace Transformation.TypeConversion.DSI
{
    public static class HarnessWireSpecification
    {
        public static IEnumerable<WireSpecificationDto> GetHarnessWireSpecification(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            WireSpecificationDto model = new WireSpecificationDto();
            List<WireSpecificationDto> collection = new List<WireSpecificationDto>();
            foreach (string line in lines)
            {
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 33, line);

                bool crossSectionalAreaCheck = double.TryParse(split[4], out double crossSectionalArea);
                bool wireLengthChangeValueCheck = double.TryParse(split[21], out double wireLengthChangeValue);
                bool assemblyItemNumberCheck = double.TryParse(split[22], out double assemblyItemNumber);
                bool unmodifiedWireLengthCheck = double.TryParse(split[24], out double unmodifiedWireLength);
                bool modifiedWireLengthCheck = double.TryParse(split[25], out double modifiedWireLength);
                bool cutbackAtEnd1Check = double.TryParse(split[26], out double cutbackAtEnd1);
                bool cutbackAtEnd2Check = double.TryParse(split[27], out double cutbackAtEnd2);

                model.WireName = split[0];
                model.CompositeOptionString = split[1];
                model.WireType = split[2];
                model.Colour = split[3];
                model.CrossSectionalArea = crossSectionalArea;
                model.Material = split[5];
                model.UserModule = split[6];
                model.MulticoreName = split[7];
                model.End1NodeName = split[8];
                model.End1Route = split[9];
                model.End1Cavity = split[10];
                model.End1MaterialCode = split[11];
                model.End2NodeName = split[12];
                model.End2Route = split[13];
                model.End2Cavity = split[14];
                model.End2MaterialCode = split[15];
                model.IsIncludedOnBom = ValueCalculator.CalculateLogicalValue(split[16], true);
                model.IsIncludedOnChart = ValueCalculator.CalculateLogicalValue(split[17], true);
                model.WireTag = split[18];
                model.WireNote = split[19];
                model.WireLengthChangeType = split[20];
                model.WireLengthChangeValue = wireLengthChangeValue;
                model.AssemblyItemNumber = assemblyItemNumber;
                model.MulticoreOption = split[23];
                model.UnmodifiedWireLength = unmodifiedWireLength;
                model.ModifiedWireLength = modifiedWireLength;
                model.CutbackAtEnd1 = cutbackAtEnd1;
                model.CutbackAtEnd2 = cutbackAtEnd2;
                model.PartNumber1 = split[28];
                model.PartNumber2 = split[29];
                model.PartNumber3 = split[30];
                model.Signal = split[31];
                collection.Add(model);
            }

            return collection;
        }
    }
}
