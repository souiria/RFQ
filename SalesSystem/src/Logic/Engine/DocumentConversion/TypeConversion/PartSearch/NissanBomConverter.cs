namespace DocumentConversion.TypeConversion.PartSearch
{
    class NissanBomConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertNissanExcelBom(SLDocument sl)
        {
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            //process first parts column (nissan has several)
            sl.InsertColumn(25, 1);
            string cellValue = sl.GetCellValueAsString(1, 24);
            sl.SetCellValue(1, 25, cellValue);
            sl.SetCellValue(1, 25, "SWS NUMBER");

            IEnumerable<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();
            int startRow = 4;
            int endRow = stats.EndRowIndex;
            List<CrossReferenceDto> customerNumbersList = customerNumbers.ToList();
            for (int row = startRow; row <= endRow; row++)
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                if (sl.GetCellValueAsString(1, 24) == "FROM")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 24);
                }
                else if (sl.GetCellValueAsString(1, 25) == "FROM")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 25);
                }

                customerNumbersList.Add(reference);
            }

            //process first parts column (nissan has several)
            sl.InsertColumn(33, 1);
            cellValue = sl.GetCellValueAsString(1, 32);
            sl.SetCellValue(1, 33, cellValue);
            sl.SetCellValue(1, 33, "SWS NUMBER");

            IEnumerable<CrossReferenceDto> customerNumbers2 = new List<CrossReferenceDto>();

            List<CrossReferenceDto> customerNumbersList2 = customerNumbers.ToList();
            for (int row = startRow; row <= endRow; row++)
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                if (sl.GetCellValueAsString(1, 32) == "FROM")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 32);
                }
                else if (sl.GetCellValueAsString(1, 33) == "FROM")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 33);
                }

                customerNumbersList2.Add(reference);
            }

            if (customerNumbers2.Any())
            {
                customerNumbersList.AddRange(customerNumbersList2);
            }

            return customerNumbersList;
        }
    }
}
