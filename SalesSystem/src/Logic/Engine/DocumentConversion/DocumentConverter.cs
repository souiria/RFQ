namespace DocumentConversion
{
    static class DocumentConverter
    {
        public static DsiModel ConvertDsiFile(byte[] file)
        {
            DsiModel dsiModel = DSIFileConverter.CreateDsiModel(file);
            return dsiModel;
        }
    }
}
