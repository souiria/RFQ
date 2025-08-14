using DocumentConversion;
using SharedModels.DocumentConverter.EDI.DTO;

namespace DocumentConversionEngine.Tests
{
    class EDIIntegraionTest
    {
        IEnumerable<EdiFileDataDto> _EdiFileDataAggregates;
        public EDIIntegraionTest()
        {
            _EdiFileDataAggregates = new List<EdiFileDataDto>();
        }

        [Test]
        public void CovertEdiFile1Test()
        {
            string fileName = Path.GetFileNameWithoutExtension("../../../EDI/12001010_AIHX18472AW3.csv");
            byte[] file = File.ReadAllBytes("../../../EDI/12001010_AIHX18472AW3.csv");
            _EdiFileDataAggregates = DocumentConverter.ConvertEdiCSVFile(file, fileName);
            Assert.That(_EdiFileDataAggregates, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(5);
            Assert.That(_EdiFileDataAggregates.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("IHX18472AW");
            Assert.That(_EdiFileDataAggregates.ElementAt(0).DispatchNumber, customerNumberConstraint);
            NUnit.Framework.Constraints.EqualConstraint fileNameConstraint = Is.EqualTo("12001010_AIHX18472AW3");
            Assert.That(_EdiFileDataAggregates.ElementAt(0).FileName, fileNameConstraint);
        }
        [Test]
        public void CovertEdiFile2Test()
        {
            string fileName = Path.GetFileNameWithoutExtension("../../../EDI/12001010_plu_280425_58312351.csv");
            byte[] file = File.ReadAllBytes("../../../EDI/12001010_plu_280425_58312351.csv");
            _EdiFileDataAggregates = DocumentConverter.ConvertEdiCSVFile(file, fileName);
            Assert.That(_EdiFileDataAggregates, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(136);
            Assert.That(_EdiFileDataAggregates.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("33271");
            Assert.That(_EdiFileDataAggregates.ElementAt(0).DispatchNumber, customerNumberConstraint);
            NUnit.Framework.Constraints.EqualConstraint orderPriceConstraint = Is.EqualTo(0);
            Assert.That(_EdiFileDataAggregates.ElementAt(0).OrderPrice, orderPriceConstraint);
            NUnit.Framework.Constraints.EqualConstraint fileNameConstraint = Is.EqualTo("12001010_plu_280425_58312351");
            Assert.That(_EdiFileDataAggregates.ElementAt(0).FileName, fileNameConstraint);
        }
    }
}
