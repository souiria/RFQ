using SharedModels.DocumentConverter.EDI.DTO;
using SharedModels.DocumentConverter.PartsSearch.DTOs;
using Transformation;
namespace DocumentConversionEngine.Tests
{
    class PartSearchIntegrationTests
    {
        IEnumerable<CrossReferenceDto> _CrossReferences;
        [SetUp]
        public void Setup()
        {
            _CrossReferences = new List<CrossReferenceDto>();
        }

        [Test]
        public void CovertNissanExcelFileTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/NissanExcel.xlsx");
            _CrossReferences = DocumentTransformer.ConvertExcelFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(344);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("RH02FB-LC-CPA");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertPSAExcelFileTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/PSAExcel.xlsx");
            _CrossReferences = DocumentTransformer.ConvertExcelFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(82);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("9618585280");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertHarnessDesignBomTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/FordBomExample.xml");
            _CrossReferences = DocumentTransformer.ConvertFordXMLFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(2260);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("3F2T-14474-RA");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertHarnessItemBomTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/FordBom.xml");
            _CrossReferences = DocumentTransformer.ConvertFordXMLFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(111);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("MU5T-14D665-MA");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertToyotaXMLTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/ToyotaBom.mtf");
            _CrossReferences = DocumentTransformer.ConvertToyotaXMLFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(120);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("0_balloon");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertRenaultCSVTest()
        {
            byte[] file = File.ReadAllBytes("../../../TestBoms/RenaultBom.txt");
            _CrossReferences = DocumentTransformer.ConvertRenaultCSVFile(file);
            Assert.That(_CrossReferences, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(193);
            Assert.That(_CrossReferences.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("241384089R");
            Assert.That(_CrossReferences.ElementAt(0).CustomerNumber, customerNumberConstraint);
        }

        [Test]
        public void ConvertFordCSVTest()
        {
            string fileName = Path.GetFileNameWithoutExtension("../../../TestBoms/Ford_Mega_Bom.csv");
            byte[] file = File.ReadAllBytes("../../../TestBoms/Ford_Mega_Bom.csv");
            IEnumerable<FordCsvDto> fordCsvDtos = new List<FordCsvDto>();
            object result = DocumentTransformer.ConvertCSV(file, fileName);
            switch(result)
            {
                case IEnumerable<FordCsvDto> returnFordCsvDtos:
                    fordCsvDtos = returnFordCsvDtos;
                    break;
                default:
                    Assert.Fail("Expected result to be of type IEnumerable<FordCsvDto>");
                    return;
            }

            Assert.That(fordCsvDtos, Is.Not.Null);
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(47277);
            Assert.That(fordCsvDtos.Count, countConstraint);
            NUnit.Framework.Constraints.EqualConstraint customerNumberConstraint = Is.EqualTo("8V5T-14489-AXA");
            Assert.That(fordCsvDtos.ElementAt(0).CustomerNumber, customerNumberConstraint);
            NUnit.Framework.Constraints.EqualConstraint quantityConstraint = Is.EqualTo(2);
            Assert.That(fordCsvDtos.ElementAt(0).Quantity, quantityConstraint);
        }
    }
}
