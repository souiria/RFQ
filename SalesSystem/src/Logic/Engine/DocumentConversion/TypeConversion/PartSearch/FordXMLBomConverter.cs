namespace Transformation.TypeConversion.PartSearch
{
    public static class FordXMLBomConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertHarnessItemBom(XDocument xmlDocument, IEnumerable<CrossReferenceDto> customerNumbers)
        {
            List<CrossReferenceDto> customerNumbersList = customerNumbers.ToList();
            if (xmlDocument.Root != null)
            {
                //Harness Part Items (use commented line below if Protection parts are not required. They may be in Eng Sol Parts list, so left in for now.)
                // IEnumerable<XElement> Parts1 = xmlDocument.Root.Descendants("HarnessItem").Where(x => x.Attribute("type").Value != "Protection");
                IEnumerable<XElement> parts = xmlDocument.Root.Descendants("HarnessItem");
                foreach (XElement element in parts)
                {
                    IEnumerable<XAttribute> attributes = element.Attributes();
                    foreach (XAttribute x in attributes)
                    {
                        if (x.Name.ToString().EndsWith("type", StringComparison.InvariantCulture) && x.Value == "Fixing" ||
                            x.Name.ToString().EndsWith("type", StringComparison.InvariantCulture) && x.Value == "Device" ||
                            x.Name.ToString().EndsWith("type", StringComparison.InvariantCulture) && x.Value == "Protection")
                        {
                            XAttribute? attribute = element.Attribute("compType");
                            if (attribute != null)
                            {
                                string partNo = attribute.Value;
                                CrossReferenceDto reference = new CrossReferenceDto();
                                reference.CustomerNumber = partNo;
                                customerNumbersList.Add(reference);
                            }
                        }
                    }
                }

                //Additional part items in BOM
                parts = xmlDocument.Root.Descendants("AdditionalPart");
                foreach (XElement element in parts)
                {
                    XAttribute? attribute = element.Attribute("compType");
                    if (attribute != null)
                    {
                        string partNo = attribute.Value;
                        CrossReferenceDto reference = new CrossReferenceDto();
                        reference.CustomerNumber = partNo;
                        customerNumbersList.Add(reference);
                    }
                }

                //Terminals on wire
                parts = xmlDocument.Root.Descendants("Property");
                foreach (XElement element in parts)
                {
                    IEnumerable<XAttribute> attributes = element.Attributes();
                    foreach (XAttribute x in attributes)
                    {
                        if (element.Parent != null)
                        {
                            if (x.Name.ToString().EndsWith("name", StringComparison.InvariantCulture) && x.Value == "WIRE_END1_TERM" ||
                                x.Name.ToString().EndsWith("name", StringComparison.InvariantCulture) && x.Value == "WIRE_END2_TERM" ||
                                element.Parent.Name == "DeviceItem")
                            {
                                XAttribute? attribute = element.Attribute("value");
                                if (attribute != null)
                                {
                                    string partNo = attribute.Value;
                                    Regex rgx = new Regex("[^a-zA-Z0-9]");
                                    CrossReferenceDto reference = new CrossReferenceDto();
                                    reference.CustomerNumber = partNo;
                                    customerNumbersList.Add(reference);
                                }
                            }
                        }
                    }
                }
            }

            return customerNumbersList;
        }

        public static IEnumerable<CrossReferenceDto> ConvertHarnessDesignBom(XDocument xmlDocument, IEnumerable<CrossReferenceDto> customerNumbers)
        {
            List<CrossReferenceDto> customerNumbersList = customerNumbers.ToList();
            if (xmlDocument.Root != null)
            {
                //Alternative FORD BOM CapitolHarness
                IEnumerable<XElement> parts = xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}contact");
                customerNumbersList.GetPartNumbers(parts);

                parts = xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}connector");
                customerNumbersList.GetPartNumbers(parts);

                parts = xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}addpart");
                customerNumbersList.GetPartNumbers(parts);

                parts = xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}pin");
                customerNumbersList.GetPartNumbers(parts);

                parts = xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}seal");
                customerNumbersList.GetPartNumbers(parts);
            }

            return customerNumbersList;
        }

        static List<CrossReferenceDto> GetPartNumbers(this List<CrossReferenceDto> customerNumbersList, IEnumerable<XElement> parts)
        {
            foreach (XElement element in parts)
            {
                XAttribute? attribute = element.Attribute("partnumber");
                CrossReferenceDto reference = new CrossReferenceDto();
                if (attribute != null)
                {
                    string partNo = attribute.Value;
                    reference.CustomerNumber = partNo;
                }

                customerNumbersList.Add(reference);
            }

            return customerNumbersList;
        }
    }

}
