namespace Transformation.TypeConversion.DSI
{
    public static class HarnessMainNodeComponents
    {
        public static IEnumerable<ComponentDto> GetHarnessMainNodeComponents(IEnumerable<string> lines, string splitter)
        {
            string[] separator = [splitter];
            List<ComponentDto> collection = new List<ComponentDto>();
            foreach (string line in lines)
            {
                ComponentDto model = new ComponentDto();
                string[] split = line.Split(separator, StringSplitOptions.None);
                ErrorCheckHelper.CheckLineLengthException(split.Length, 31, line);

                bool quantityCheck = double.TryParse(split[9], out double quantity);
                bool crossSectionalAreaCheck = double.TryParse(split[10], out double crossSectionalArea);
                bool assemblyItemNumberCheck = double.TryParse(split[26], out double assemblyItemNumber);
                bool numberOfCavitiesCheck = double.TryParse(split[28], out double numberOfCavities);

                model.NodeName = split[0];
                model.CavityName = split[1];
                model.WireName = split[2];
                model.SequenceNumber = split[3];
                model.ComponentTypeCode1 = split[4];
                model.ComponentOption = split[5];
                model.ServiceFunction = split[6];
                model.Route = split[7];
                model.PartNumber1 = split[8].Trim();
                model.PartNumber2 = split[11].Trim();
                model.PartNumber3 = split[12].Trim();
                model.Quantity = quantity;
                model.CrossSectionalArea = crossSectionalArea;
                model.IsSelectTerminal = ValueCalculator.CalculateLogicalValue(split[13], false);
                model.IsSeal = ValueCalculator.CalculateLogicalValue(split[14], false);
                model.IsPlugged = ValueCalculator.CalculateLogicalValue(split[15], false);
                model.BlockNumber = split[16];
                model.TerminationMethod = split[17];
                model.MaterialCode = split[18];
                model.ComponentTypeCode2 = split[19];
                model.InsulationType = split[20];
                model.UserModule = split[21];
                model.AssignedModule = split[22];
                model.ModuleFrom = split[23];
                model.SplitValue = split[24];
                model.Datum = split[25];
                model.AssemblyItemNumber = assemblyItemNumber;
                model.ColourCode = split[27];
                model.NumberOfCavities = numberOfCavities;
                model.IsBackshell = ValueCalculator.CalculateLogicalValue(split[29], false);
                model.WireOption = split[30];
                collection.Add(model);
            }

            List<ComponentDto> s = collection.Where(x => !string.IsNullOrWhiteSpace(x.PartNumber1)).ToList();
            return collection;
        }
    }
}
