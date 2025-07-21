using DocumentConversion.TypeConversion.DSI;

namespace DocumentConverterEngine.Tests
{
    public class Tests
    {
        byte[] _File;
        [SetUp]
        public void Setup()
        {
            _File = File.ReadAllBytes("../../../TestData.dsi");
        }

        [Test]
        public void Test1()
        {
            SharedModels.DocumentConverter.DSI.DsiModel s = DSIFileConverter.CreateDsiModel(_File);
            if(s.Harness != null)
            {
                string? d = s.Harness.AdditionalComments;
            }
        }
    }
}
