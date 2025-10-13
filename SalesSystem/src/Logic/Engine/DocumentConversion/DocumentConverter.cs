using Transformation.TypeConversion.DSI;
using Transformation.TypeConversion.EDI;
using Transformation.TypeConversion.PartSearch;

namespace Transformation
{
    public static class DocumentConverter
    {
        public static DsiAggregate ConvertDsiFile(byte[] file)
        {
            DsiAggregate dsiModel = DSIFileConverter.CreateDsiModel(file);
            return dsiModel;
        }

        /// <summary>
        /// Method to convert the Nissan and PSA excel BOM files
        /// </summary>
        /// <param name="file"></param>
        /// <returns>customerNumbers in the file</returns>
        public static IEnumerable<CrossReferenceDto> ConvertExcelFile(byte[] file)
        {
            IEnumerable<CrossReferenceDto> crossReferences = PartSearchConverter.ConvertExcelFile(file);
            return crossReferences;
        }

        /// <summary>
        /// Method to convert the Ford XML BOM files
        /// </summary>
        /// <param name="file"></param>
        /// <returns>customerNumbers in the file</returns>
        public static IEnumerable<CrossReferenceDto> ConvertFordXMLFile(byte[] file)
        {
            IEnumerable<CrossReferenceDto> crossReferences = PartSearchConverter.ConvertFordXMLFile(file);
            return crossReferences;
        }

        /// <summary>
        /// Method to convert the Toyota XML BOM files
        /// </summary>
        /// <param name="file"></param>
        /// <returns>customerNumbers in the file</returns>
        public static IEnumerable<CrossReferenceDto> ConvertToyotaXMLFile(byte[] file)
        {
            IEnumerable<CrossReferenceDto> crossReferences = PartSearchConverter.ConvertToyotaXMLFile(file);
            return crossReferences;
        }

        /// <summary>
        /// Method to convert the Renault CSV BOM files
        /// </summary>
        /// <param name="file"></param>
        /// <returns>customerNumbers in the file</returns>
        public static IEnumerable<CrossReferenceDto> ConvertRenaultCSVFile(byte[] file)
        {
            IEnumerable<CrossReferenceDto> crossReferences = PartSearchConverter.ConvertRenaultCSVFile(file);
            return crossReferences;
        }

        public static object ConvertCSV(byte[] file, string fileName)
        {
            MemoryStream ms = new MemoryStream(file);
            using StreamReader reader = new StreamReader(ms, Encoding.UTF8);
            string? line = reader.ReadLine();
            while (line == null)
            {
                line = reader.ReadLine();
            }

            if (line.Contains('%', StringComparison.InvariantCulture))
            {
                IEnumerable<FordCsvDto> fordCsvData = ConvertFordCSVFile(file);
                return fordCsvData;
            }
            else
            {
                EdiFileDataAggregate ediFileData = ConvertEdiCSVFile(file, fileName);
                return ediFileData;
            }
        }

        /// <summary>
        /// Method to convert the Ford CSV BOM files
        /// </summary>
        /// <param name="file"></param>
        /// <returns>customerNumbers and quantities in the file</returns>
        static IEnumerable<FordCsvDto> ConvertFordCSVFile(byte[] file)
        {
            IEnumerable<FordCsvDto> crossReferences = PartSearchConverter.ConvertFordCSVFile(file);
            return crossReferences;
        }

        static EdiFileDataAggregate ConvertEdiCSVFile(byte[] file, string fileName)
        {
            EdiFileDataAggregate ediFileData = EdiFileConverter.ConvertEdiCSVFile(file, fileName);
            return ediFileData;
        }
    }
}
