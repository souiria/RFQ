using DocumentFormat.OpenXml.Vml;

namespace SalesSystem.Rfq.Models
{
    public class AlternativePartUxModel
    {
        static readonly Random _Random;

        // Attributes
        public string? SumitomoNumber
        { get; set; }

        public string? SumitomoDescription
        { get; set; }

        public bool? MainSupplier
        { get; set; }

        public string? SupplierName
        { get; set; }

        public string? SupplierNumber
        { get; set; }

        public double? Price
        { get; set; }

        public string? CurrencyCode
        { get; set; }

        public string? UnitOfMeasure
        { get; set; }

        public string? PartGroup
        { get; set; }

        public string? GroupDescription
        { get; set; }

        public string? Class1
        { get; set; }

        public string? Class1Name
        { get; set; }

        public double? Class2
        { get; set; }

        public string? Class2Name
        { get; set; }

        public string? ColourCode
        { get; set; }

        public string? ColorName
        { get; set; }

        public string? MaterialGroup
        { get; set; }

        public string? Expr1
        { get; set; }

        public string? MaterialType
        { get; set; }

        public string? TypeDescription
        { get; set; }

        public string? CategoryCode
        { get; set; }

        public double? DetailedCategoryCode
        { get; set; }

        public string? CategoryName
        { get; set; }

        public string? PartGroupCode
        { get; set; }

        public string? Description
        { get; set; }

        public string? OldPartClass
        { get; set; }

        public string? OldMaterial
        { get; set; }

        public string? ClassDetailGroupCode
        { get; set; }

        public string? ClassDetailId
        { get; set; }

        public string? MaterialGroupId
        { get; set; }

        public string? MaterialTypeId
        { get; set; }

        public string? ColorCode
        { get; set; }

        public int? NumberOfCavity
        { get; set; }

        public double? InsideDiameter
        { get; set; }

        public double? WallThickness
        { get; set; }

        public double? Length
        { get; set; }

        public double? WidthOrOutsideDiameter
        { get; set; }

        public int? HoleDiameter
        { get; set; }

        public int? ShrinkRateLength
        { get; set; }

        public int? NumberOfTapingSpots
        { get; set; }

        public double? MassOrWeight
        { get; set; }

        public double? Quantity
        { get; set; }

        public string? UoM
        { get; set; }

        public string? Group1
        { get; set; }

        public string? Group2
        { get; set; }

        public string? Group3
        { get; set; }

        public string? Group4
        { get; set; }

        public string? Group5
        { get; set; }

        public string? Group6
        { get; set; }

        public string? Group7
        { get; set; }

        public string? Group8
        { get; set; }

        public string? CustomerId
        { get; set; }

        public string? CustomerCode
        { get; set; }

        public double? MassOrWeight2
        { get; set; }

        public int? L1
        { get; set; }

        public int? L2
        { get; set; }

        public int? L3
        { get; set; }

        public double? PitchWidth
        { get; set; }

        public int? Tilt
        { get; set; }

        public int? Grease
        { get; set; }

        public string? CategoryCode2
        { get; set; }

        // just ux
        public bool HasImage
        { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "<Pending>")]
        public static List<AlternativePartUxModel> GenerateRandomList(int count = 1000)
        {
            List<AlternativePartUxModel> list = new List<AlternativePartUxModel>(count);

            for (int i = 0; i < count; i++)
            {
                AlternativePartUxModel item = new AlternativePartUxModel();
                item.SumitomoNumber = $"SN-{_Random.Next(1000, 9999)}";
                item.SumitomoDescription = $"Description {_Random.Next(1, 100)}";
                item.MainSupplier = _Random.Next(0, 2) == 1;
                item.SupplierName = $"Supplier {_Random.Next(1, 50)}";
                item.SupplierNumber = $"SUP-{_Random.Next(100, 999)}";
                item.Price = Math.Round(_Random.NextDouble() * 1000, 2);
                item.CurrencyCode = "USD";
                item.UnitOfMeasure = "pcs";
                item.PartGroup = $"PG{_Random.Next(1, 10)}";
                item.GroupDescription = $"Group Desc {_Random.Next(1, 10)}";
                item.Class1 = $"C1-{_Random.Next(1, 5)}";
                item.Class1Name = $"Class1Name {_Random.Next(1, 5)}";
                item.Class2 = Math.Round(_Random.NextDouble() * 10, 2);
                item.Class2Name = $"Class2Name {_Random.Next(1, 5)}";
                item.ColourCode = $"CC{_Random.Next(1, 20)}";
                item.ColorName = $"Color {_Random.Next(1, 20)}";
                item.MaterialGroup = $"MG{_Random.Next(1, 10)}";
                item.Expr1 = $"Expr {_Random.Next(1, 10)}";
                item.MaterialType = $"MT{_Random.Next(1, 10)}";
                item.TypeDescription = $"Type Desc {_Random.Next(1, 10)}";
                item.CategoryCode = $"CAT{_Random.Next(1, 10)}";
                item.DetailedCategoryCode = Math.Round(_Random.NextDouble() * 100, 2);
                item.CategoryName = $"Category {_Random.Next(1, 10)}";
                item.PartGroupCode = $"PGC{_Random.Next(1, 10)}";
                item.Description = $"Description {_Random.Next(1, 100)}";
                item.OldPartClass = $"OldClass {_Random.Next(1, 10)}";
                item.OldMaterial = $"OldMaterial {_Random.Next(1, 10)}";
                item.ClassDetailGroupCode = $"CDGC{_Random.Next(1, 10)}";
                item.ClassDetailId = $"CDID{_Random.Next(1, 100)}";
                item.MaterialGroupId = $"MGID{_Random.Next(1, 10)}";
                item.MaterialTypeId = $"MTID{_Random.Next(1, 10)}";
                item.ColorCode = $"CC{_Random.Next(1, 20)}";
                item.NumberOfCavity = _Random.Next(1, 10);
                item.InsideDiameter = Math.Round(_Random.NextDouble() * 50, 2);
                item.WallThickness = Math.Round(_Random.NextDouble() * 10, 2);
                item.Length = Math.Round(_Random.NextDouble() * 100, 2);
                item.WidthOrOutsideDiameter = Math.Round(_Random.NextDouble() * 100, 2);
                item.HoleDiameter = _Random.Next(1, 20);
                item.ShrinkRateLength = _Random.Next(1, 10);
                item.NumberOfTapingSpots = _Random.Next(1, 10);
                item.MassOrWeight = Math.Round(_Random.NextDouble() * 100, 2);
                item.Quantity = Math.Round(_Random.NextDouble() * 1000, 2);
                item.UoM = "pcs";
                item.Group1 = $"G1-{_Random.Next(1, 10)}";
                item.Group2 = $"G2-{_Random.Next(1, 10)}";
                item.Group3 = $"G3-{_Random.Next(1, 10)}";
                item.Group4 = $"G4-{_Random.Next(1, 10)}";
                item.Group5 = $"G5-{_Random.Next(1, 10)}";
                item.Group6 = $"G6-{_Random.Next(1, 10)}";
                item.Group7 = $"G7-{_Random.Next(1, 10)}";
                item.Group8 = $"G8-{_Random.Next(1, 10)}";
                item.CustomerId = $"CID{_Random.Next(1, 1000)}";
                item.CustomerCode = $"CCODE{_Random.Next(1, 1000)}";
                item.MassOrWeight2 = Math.Round(_Random.NextDouble() * 100, 2);
                item.L1 = _Random.Next(1, 100);
                item.L2 = _Random.Next(1, 100);
                item.L3 = _Random.Next(1, 100);
                item.PitchWidth = Math.Round(_Random.NextDouble() * 50, 2);
                item.Tilt = _Random.Next(0, 360);
                item.Grease = _Random.Next(0, 2);
                item.CategoryCode2 = $"CAT2-{_Random.Next(1, 10)}";

                list.Add(item);
            }

            return list;
        }
        static AlternativePartUxModel()
        {
            _Random = new();
        }
        public AlternativePartUxModel()
        {
            HasImage = false;
            PartImage = new PartImageData();
        }
        public PartImageData PartImage
        { get; set; }
        public string Source
        {
            get
            {   
                //if (AlternativePartNumber?.PartImage == null
                //    || AlternativePartNumber.PartImage.ImageBytes == null)
                //{
                //    return string.Empty;
                //}

                //var imageData = AlternativePartNumber?.PartImage;
                //if (imageData == null)
                //{
                //    return string.Empty;
                //}
                //string? base64Image = Convert.ToBase64String(imageData.ImageBytes.ToArray());
                return HasImage 
                    ? $"data:{PartImage.MimeType};base64,{PartImage.Source}"
                    : $"data:{PartImageData.NoImage.MimeType};base64,{PartImageData.NoImage.Source}";
            }
        }
    }
}
