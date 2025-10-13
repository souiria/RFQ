using SharedModels.DocumentConverter.EDI.Aggregates;
using Transformation;

namespace DocumentConversionEngine.Tests
{
    class EDIIntegraionTest
    {
        EdiFileDataAggregate _EdiFileDataAggregates;
        public EDIIntegraionTest()
        {
            _EdiFileDataAggregates = new EdiFileDataAggregate();
        }

        [Test]
        public void CovertEdiFile1Test()
        {
            string fileName = Path.GetFileNameWithoutExtension("../../../EDI/12001010_AIHX18472AW3.csv");
            byte[] file = File.ReadAllBytes("../../../EDI/12001010_AIHX18472AW3.csv");
            object result = DocumentConverter.ConvertCSV(file, fileName);
            switch (result)
            {
                case EdiFileDataAggregate ediFileData:
                _EdiFileDataAggregates = ediFileData;
                break;
                default:
                Assert.Fail("Expected result to be of type IEnumerable<EdiFileDataDto>");
                return;
            }

            Assert.That(_EdiFileDataAggregates, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint ediCountConstraint = Is.EqualTo(1);
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.Count, ediCountConstraint);
            NUnit.Framework.Constraints.EqualConstraint duplicateEdiCountConstraint = Is.EqualTo(4);
            Assert.That(_EdiFileDataAggregates.DuplicateEdiFileDataDtos.Count, duplicateEdiCountConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("IHX18472AW");
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.ElementAt(0).DispatchNumber, customerNumberConstraint);
            NUnit.Framework.Constraints.EqualConstraint fileNameConstraint = Is.EqualTo("12001010_AIHX18472AW3");
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.ElementAt(0).FileName, fileNameConstraint);
        }
        [Test]
        public void CovertEdiFile2Test()
        {
            string fileName = Path.GetFileNameWithoutExtension("../../../EDI/12001010_plu_280425_58312351.csv");
            byte[] file = File.ReadAllBytes("../../../EDI/12001010_plu_280425_58312351.csv");
            object result = DocumentConverter.ConvertCSV(file, fileName);
            switch(result)
            {
                case EdiFileDataAggregate ediFileData:
                    _EdiFileDataAggregates = ediFileData;
                    break;
                default:
                    Assert.Fail("Expected result to be of type IEnumerable<EdiFileDataDto>");
                    return;
            }

            Assert.That(_EdiFileDataAggregates, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint ediCountConstraint = Is.EqualTo(8);
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.Count, ediCountConstraint);
            NUnit.Framework.Constraints.EqualConstraint duplicateEdiCountConstraint = Is.EqualTo(128);
            Assert.That(_EdiFileDataAggregates.DuplicateEdiFileDataDtos.Count, duplicateEdiCountConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("33271");
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.ElementAt(0).DispatchNumber, customerNumberConstraint);
            NUnit.Framework.Constraints.EqualConstraint orderPriceConstraint = Is.EqualTo(0);
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.ElementAt(0).OrderPrice, orderPriceConstraint);
            NUnit.Framework.Constraints.EqualConstraint fileNameConstraint = Is.EqualTo("12001010_plu_280425_58312351");
            Assert.That(_EdiFileDataAggregates.EdiFileDataDtos.ElementAt(0).FileName, fileNameConstraint);
        }
    }
}
