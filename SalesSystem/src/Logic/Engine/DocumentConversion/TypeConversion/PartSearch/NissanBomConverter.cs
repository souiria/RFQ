namespace DocumentConversion.TypeConversion.PartSearch
{
    class NissanBomConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertNissanExcelBom(ExcelPackage package)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets[0];
            ExcelCellAddress start = ws.Dimension.Start;
            ExcelCellAddress end = ws.Dimension.End;

            //process first parts column (nissan has several)
            ws.InsertColumn(25, 1);
            ws.Cells[1, 24].Copy(ws.Cells[1, 25]);
            ws.Cells[1, 25].Value = "SWS NUMBER";

            IEnumerable<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();
            customerNumbers = ws.Cells["X4:Y" + end.Row].ToCollectionWithMappings(row =>
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                reference.CustomerNumber = row.GetValue<string>("FROM");
                return reference;
            }, options => options.SetCustomHeaders("FROM"));

            //process first parts column (nissan has several)
            ws.InsertColumn(33, 1);
            ws.Cells[1, 32].Copy(ws.Cells[1, 33]);
            ws.Cells[1, 33].Value = "SWS NUMBER";
            IEnumerable<CrossReferenceDto> customerNumbers2 = new List<CrossReferenceDto>();

            customerNumbers2 = ws.Cells["AF4:AG" + end.Row].ToCollectionWithMappings(row =>
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                reference.CustomerNumber = row.GetValue<string>("FROM");
                return reference;
            }, options => options.SetCustomHeaders("FROM"));

            if (customerNumbers2.Any())
            {
                customerNumbers.ToList().AddRange(customerNumbers2);
            }

            return customerNumbers;
        }
    }
}
