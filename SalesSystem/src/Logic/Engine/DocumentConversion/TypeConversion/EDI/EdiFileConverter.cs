namespace DocumentConversion.TypeConversion.EDI
{
    public static class EdiFileConverter
    {
        public static EdiFileDataAggregate ConvertEdiCSVFile(byte[] file, string fileName)
        {
            List<EdiFileDataDto> ediFileData = new List<EdiFileDataDto>();
            List<EdiFileDataDto> duplicateEdiFileData = new List<EdiFileDataDto>();
            EdiFileDataAggregate ediFileDataAggregate = new EdiFileDataAggregate();

            string fileContents = Encoding.UTF8.GetString(file);
            string[] newLineChars = { "\r\n", "\r", "\n" };
            string[] fileData = fileContents.Split(newLineChars,
                                      StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in fileData)
            {
                string[] lineData = line.Split(',');

                try
                {
                    EdiFileDataDto data = ConvertEdiCSVRow(lineData, fileName);

                    if(ediFileData.Any(x => x.FileName == data.FileName && x.DispatchNumber == data.DispatchNumber && x.DispatchDate == data.DispatchDate))
                    {
                        // If the data already exists, add it to the duplicate list
                        duplicateEdiFileData.Add(data);
                        continue; // Skip adding this duplicate entry to the main list
                    }

                     ediFileData.Add(data);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ediFileDataAggregate.EdiFileDataDtos = ediFileData;
            ediFileDataAggregate.DuplicateEdiFileDataDtos = duplicateEdiFileData;
            return ediFileDataAggregate;
        }

        static EdiFileDataDto ConvertEdiCSVRow(string[] lineData, string fileName)
        {
            string[] fileNameSplit = Path.GetFileNameWithoutExtension(fileName).Split('_');
            if (lineData.Length < 20)
            {
                throw new FormatException("Unsupported file content length.");
            }

            EdiFileDataDto returnData = new EdiFileDataDto();
            returnData.FileName = fileName;
            returnData.FinanceCode = fileNameSplit[0];
            returnData.DispatchNumber = lineData[0];
            returnData.DispatchDate = Convert.ToDateTime(lineData[1], CultureInfo.InvariantCulture);
            returnData.CustomerOrderNumber = lineData[2];
            returnData.PartNumber = lineData[3];
            returnData.PartDescription = string.IsNullOrEmpty(lineData[4]) ? lineData[3] : lineData[4];
            returnData.Quantity = string.IsNullOrEmpty(lineData[5]) ? 0d : double.Parse(lineData[5], CultureInfo.InvariantCulture);
            returnData.UnloadingPoint = lineData[6];
            returnData.WmsSiteCode = lineData[7];
            returnData.WmsCustomerCode = lineData[8];
            returnData.CustomerDispatchNumber = lineData[9];
            returnData.MessageType = lineData[10];
            returnData.ExchangeRate = string.IsNullOrEmpty(lineData[11]) ? 0d : double.Parse(lineData[11], CultureInfo.InvariantCulture);
            returnData.CustomerPartNumber = lineData[12];
            returnData.TotalGrossWeight = string.IsNullOrEmpty(lineData[13]) ? 0d : double.Parse(lineData[13], CultureInfo.InvariantCulture);
            returnData.TotalNetWeight = string.IsNullOrEmpty(lineData[14]) ? 0d : double.Parse(lineData[14], CultureInfo.InvariantCulture);
            returnData.UnitOfMeasure = lineData[15];
            returnData.TariffCode = lineData[16];
            returnData.DeliveryTerms = lineData[17];
            returnData.TransportDetails = lineData[18];
            returnData.WmsInvoiceNumber = lineData[19];

            if (lineData.Length <= 20)
            {
                return returnData;
            }
            else
            {
                returnData.OrderPrice = (decimal)(string.IsNullOrEmpty(lineData[20]) ? 0d : double.Parse(lineData[20], CultureInfo.InvariantCulture));
            }

            if (lineData.Length <= 21)
            {
                return returnData;
            }

            returnData.PalletQuantity = Convert.ToString(lineData[21], CultureInfo.InvariantCulture);
            return returnData;

        }
    }
}
