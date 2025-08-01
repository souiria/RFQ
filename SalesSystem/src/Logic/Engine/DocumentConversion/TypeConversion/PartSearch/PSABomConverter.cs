using SharedModels.DocumentConverter.PartsSearch.DTOs;

namespace DocumentConversion.TypeConversion.PartSearch
{
    public static class PSABomConverter
    {
        public static IEnumerable<CrossReferenceDto> ConvertPSAExcelBom(ExcelPackage package)
        {
            //PSA BOM Identified
            // Get the Worksheet created in the previous codesample. 
            ExcelWorksheet ws = package.Workbook.Worksheets[0];
            ExcelCellAddress start = ws.Dimension.Start;
            ExcelCellAddress end = ws.Dimension.End;
            //  ws.Cells[1, 3].Value = "CustomerNumber";
            ws.InsertColumn(4, 1);
            ws.Cells[1, 3].Copy(ws.Cells[1, 4]);
            ws.Cells[1, 4].Value = "SWS NUMBER";
            IEnumerable<CrossReferenceDto> customerNumbers = new List<CrossReferenceDto>();
            customerNumbers = ws.Cells["C2:D" + end.Row].ToCollectionWithMappings(row =>
            {
                CrossReferenceDto reference = new CrossReferenceDto();
                reference.CustomerNumber = row.GetValue<string>("N.PIECE") ?? "NO DATA";
                return reference;
            }, options => options.SetCustomHeaders("N.PIECE"));

            return customerNumbers;
        }
    }
}
