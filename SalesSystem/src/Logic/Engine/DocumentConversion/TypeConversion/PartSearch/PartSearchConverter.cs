namespace DocumentConversion.TypeConversion.PartSearch
{
    public static class PartSearchConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertExcelFile(byte[] file)
        {
            MemoryStream stream = new MemoryStream(file);
            List<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();
            //Nissan has several columns so customerNumber2 will be for second column in BOM
            List<CrossReferenceDto> customerNumbers2 = new List<CrossReferenceDto>();
            try 
            {
                ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    if (package.Workbook.Worksheets[0].Cells[1, 1].Value.ToString() == "Note")
                    {
                        customerNumbers = PSABomConverter.ConvertPSAExcelBom(package).ToList();
                    }

                    if (package.Workbook.Worksheets[0].Cells[1, 1].Value.ToString() == "WIRE" &&
                        package.Workbook.Worksheets[0].Cells[1, 2].Value.ToString() == "FROM")
                    {
                        customerNumbers = NissanBomConverter.ConvertNissanExcelBom(package).ToList();
                    }
                }

                return customerNumbers;
            }
            catch (FieldValidationException ex)
            {
                Console.WriteLine(ex.Message);
                return customerNumbers;
            }
        }

        public static IEnumerable<CrossReferenceDto> ConvertFordXMLFile(byte[] file)
        {
            string fileString = "";

            fileString = Encoding.Default.GetString(file);

            byte[] encodingPreamble = Encoding.UTF8.GetPreamble();
            string byteOrderMarkUtf8 = Encoding.UTF8.GetString(encodingPreamble);
            if (fileString.StartsWith(byteOrderMarkUtf8, StringComparison.Ordinal))
            {
                fileString = fileString.Remove(0, byteOrderMarkUtf8.Length);
            }

            XDocument xmlDocument = XDocument.Parse(fileString);
            List<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();

            if (xmlDocument.Root != null)
            {
                //Check if signature matches Ford BOM
                if (xmlDocument.Root.Descendants("HarnessItem").Any())
                {

                    customerNumbers = FordXMLBomConverter.ConvertHarnessItemBom(xmlDocument, customerNumbers).ToList();
                }

                if (xmlDocument.Root.Descendants("{http://www.mentor.com/harness/Schema/bridgesharness}contact").Any())
                {
                    customerNumbers = FordXMLBomConverter.ConvertHarnessDesignBom(xmlDocument, customerNumbers).ToList();
                }
            }

            return customerNumbers;
        }

        public static IEnumerable<CrossReferenceDto> ConvertToyotaXMLFile(byte[] file)
        {
            string fileString = "";

            fileString = Encoding.Default.GetString(file);
            int startXML = fileString.IndexOf("<?xml", 0, StringComparison.Ordinal);
            int endXML = fileString.LastIndexOf("</HarnessFile>", StringComparison.Ordinal);
            string xmlString = fileString.Substring(startXML, endXML - startXML + 14);

            XDocument xmlDocument = XDocument.Parse(xmlString);
            List<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();

            if (fileString.Contains("Toyota", StringComparison.InvariantCulture) && xmlDocument.Root != null)
            {
                IEnumerable<XElement> parts = xmlDocument.Root.Descendants("Property");
                foreach (XElement element in parts)
                {
                    XAttribute? attribute = element.Attribute("name");
                    if (attribute != null)
                    {
                        if (attribute.Value == "partName")
                        {
                            string partNo = element.Value;
                            CrossReferenceDto reference = new CrossReferenceDto();
                            reference.CustomerNumber = partNo;
                            customerNumbers.Add(reference);
                        }
                    }
                }
            }

            return customerNumbers;
        }

        public static IEnumerable<CrossReferenceDto> ConvertRenaultCSVFile(byte[] file)
        {
            List<CrossReferenceDto> customerNumber = new List<CrossReferenceDto>();
            MemoryStream ms = new MemoryStream(file);
            StreamReader reader = new StreamReader(ms, Encoding.Default);

            List<RenaultBomDto> renaultBoms = new List<RenaultBomDto>();
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                renaultBoms = csv.GetRecords<RenaultBomDto>().ToList();
            }

            //Remove any WIRE type parts, as not required for search
            renaultBoms = renaultBoms.Where(a => !a.DESIGNATION.StartsWith("WIRE", StringComparison.InvariantCulture)).ToList();

            //Add the renaultBom parts to th customer number CrossReference list
            foreach (RenaultBomDto part in renaultBoms)
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                reference.CustomerNumber = part.REFERENCE;
                customerNumber.Add(reference);
            }

            return customerNumber;
        }

        public static IEnumerable<FordCsvDto> ConvertFordCSVFile(byte[] file)
        {
            MemoryStream ms = new MemoryStream(file);
            List<FordCsvDto> fordCsvData = new List<FordCsvDto>();
            bool inCatchBlock = false;
            using (TextReader reader = new StreamReader(ms))
            {
                inCatchBlock = false;
                string? line = reader.ReadLine();
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.StartsWith("%Component used_on", StringComparison.InvariantCulture))
                        {
                            inCatchBlock = true;
                            continue;
                        }

                        if (inCatchBlock == true && !line.StartsWith("%", StringComparison.InvariantCulture))
                        {
                            inCatchBlock = true;
                            Console.WriteLine(line);
                            string[] partdata = line.Split(',');
                            try
                            {
                                FordCsvDto dto = new FordCsvDto();
                                dto.CustomerNumber = partdata[2];
                                if (!string.IsNullOrWhiteSpace(partdata[3]))
                                {
                                    dto.Quantity = Convert.ToInt32(partdata[3], CultureInfo.InvariantCulture);
                                }

                                fordCsvData.Add(dto);
                            }
                            catch (FileLoadException ex)
                            {
                                Console.WriteLine(ex.Message);
                                continue;
                            }

                            continue;
                        }

                        if (inCatchBlock == true && line.StartsWith("%", StringComparison.InvariantCulture))
                        {
                            inCatchBlock = false;
                            continue;
                        }
                    }
                }
            }

            return fordCsvData;
        }
    }
}
