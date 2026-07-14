namespace Transformation.TypeConversion.PartSearch
{
    public static class PSABomConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertPSAExcelBom(SLDocument sl)
        {
            //PSA BOM Identified
            // Get the Worksheet created in the previous codesample. 
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            sl.InsertColumn(4, 1);
            string cellValue = sl.GetCellValueAsString(1, 3);
            sl.SetCellValue(1, 4, cellValue);
            sl.SetCellValue(1, 4, "SWS NUMBER");
            IEnumerable<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();
            int startRow = 2;
            int endRow = stats.EndRowIndex;
            List<CrossReferenceDto> customerNumbersList = customerNumbers.ToList();

            for (int row = startRow; row <= endRow; row++)
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                if (sl.GetCellValueAsString(1, 3) == "N.PIECE")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 3);
                }
                else if (sl.GetCellValueAsString(1, 4) == "N.PIECE")
                {
                    reference.CustomerNumber = sl.GetCellValueAsString(row, 4);
                }

                customerNumbersList.Add(reference);
            }

            return customerNumbersList;
        }
    }
}
