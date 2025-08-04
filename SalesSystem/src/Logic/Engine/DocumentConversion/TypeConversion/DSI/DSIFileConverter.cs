namespace DocumentConversion.TypeConversion.DSI
{
    public static class DSIFileConverter
    {
        public static DsiAggregate CreateDsiModel(byte[] file)
        {
            DsiAggregate dsiModel = new DsiAggregate();
            List<string> lineList = new List<string>();
            CultureInfo culture = new CultureInfo("en-gb");
            char commentCharacter = '!';
            char sectionCharacter = '%';
            List<string> sectionList = new List<string>();
            int section = 0;
            byte[] lineBytes = [];
            foreach (byte b in file)
            {
                lineBytes = AddByteToArray(lineBytes, b);
                if (b == '\n')
                {
                    lineBytes = lineBytes.Reverse().ToArray();
                    string newLine = Encoding.Default.GetString(lineBytes);
                    newLine = newLine.Replace("\r\n",  string.Empty, StringComparison.InvariantCulture);
                    lineList.Add(newLine);
                    lineBytes = [];
                }
            }

            if (lineList[6].Contains("Comment Marker", StringComparison.Ordinal))
            {
                string commentLine = lineList[6];
                commentCharacter = commentLine[commentLine.Length - 1];
            }

            if (lineList[7].Contains("Section Separator", StringComparison.Ordinal))
            {
                string sectionline = lineList[7];
                sectionCharacter = sectionline[sectionline.Length - 1];
            }

            foreach (string line in lineList) 
            {
                // Comment line so skip
                if (line.StartsWith(commentCharacter))
                {
                    continue;
                }

                //new section
                if (line.StartsWith(sectionCharacter))
                {
                    dsiModel = GetDataFromSection(section, sectionList, dsiModel);
                    sectionList.Clear();
                    section++;
                    continue;
                }

                sectionList.Add(line);
            }

            return dsiModel;
        }

        static DsiAggregate GetDataFromSection(int section, List<string> sectionList, DsiAggregate dsiModel)
        {
            string splitter = ":";
            switch (section) 
            {
                case 0: dsiModel.Harness = HarnessNameInformation.GetHarnessNameInformation(sectionList,splitter);
                        return dsiModel;
                case 1: if (dsiModel.Harness != null)
                        {
                            dsiModel.Harness = HarnessNoteInformation.GetHarnessNoteInformation(dsiModel.Harness, sectionList);
                        }

                        return dsiModel;
                case 2: dsiModel.CompositeDetailList = HarnessCircuitInformation.GetHarnessCircuitInformantion(sectionList,splitter);
                        return dsiModel;
                case 3: dsiModel.BranchConfigurationList = HarnessBranchConfiguration.GetHarnessBranchConfiguration(sectionList,splitter);
                        return dsiModel;
                case 4: dsiModel.WireSpecificationList = HarnessWireSpecification.GetHarnessWireSpecification(sectionList, splitter);
                        return dsiModel;
                case 5: dsiModel.ComponentList = HarnessMainNodeComponents.GetHarnessMainNodeComponents(sectionList,splitter);
                        return dsiModel;
                case 6: dsiModel.BranchInsulationList = HarnessBranchInsulations.GetHarnessBranchInsulations(sectionList,splitter);
                        return dsiModel;
                case 7: dsiModel.CentreStripList = HarnessCenterStrips.GetHarnessCenterStrips(sectionList,splitter);
                        return dsiModel;
                case 8: dsiModel.MulticoreSpecificationList = HarnessMulticores.GetHarnessMulticores(sectionList,splitter);
                        return dsiModel;
                case 9: dsiModel.ModuleChildDetailList = ModuleChildDetails.GetModuleChildDetails(sectionList,splitter);
                        return dsiModel;
                case 10: dsiModel.ModuleCompatibilityList = ModuleCompatibilityDetails.GetModuleCompatibilityDetails(sectionList,splitter); 
                        return dsiModel;
                case 11: dsiModel.ManualBomQuantityList = ManualBOMQuantities.GetManualBOMQuantities(sectionList,splitter);
                        return dsiModel;
                case 12: dsiModel.CompositeOptionList = CompositeOptionCodes.GetCompositeOptionCodes(sectionList,splitter);
                        return dsiModel;
                case 13: dsiModel.WireThroughNodeList = HarnessWireThroughNodes.GetHarnessWireThroughNodes(sectionList,splitter);
                        return dsiModel;
                case 14: dsiModel.BranchInsulationThroughNodeList = HarnessBranchInsulationThroughNodes.GetHarnessBranchInsulationThroughNodes(sectionList,splitter);
                        return dsiModel;
                case 15: dsiModel.MidWireComponentList = HarnessMidWireComponents.GetHarnessMidWireComponents(sectionList,splitter);
                        return dsiModel;
                case 16: dsiModel.WireMulticoreMarkerList = HarnessWireMulticoreMarkers.GetHarnessWireMulticoreMarkers(sectionList,splitter);
                        return dsiModel;
                case 17: dsiModel.PinMappingList = HarnessPinMappings.GetHarnessPinMappings(sectionList,splitter);
                        return dsiModel;
                case 18: dsiModel.HarnessScopeList = HarnessScope.GetHarnessScope(sectionList, splitter);
                        return dsiModel;
            }

            return dsiModel;
        }

        public static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 1);
            newArray[0] = newByte;
            return newArray;
        }
    }
}
