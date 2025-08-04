namespace CDb.Services
{
    public static partial class SampleCDbAccessDataService
    {
        public static ListCompositeComponentGrpc PopulateCompositeComponentInitData()
        {
            ListCompositeComponentGrpc compositeComponent = new ListCompositeComponentGrpc();

            // A cable component    
            DbCable greenCable = new DbCable();
            // Generic properties for the cable
            greenCable.Id = _CompositeComponentId0;
            greenCable.ComponentType = ComponentType.Cable;
            greenCable.Name = $"{ComponentType.Cable.GetEnumDescription()}-001";
            greenCable.Comment = "A standard green cable used in various applications.";
            greenCable.SheetNumber = 90001;
            greenCable.Issue = "Test cable";
            greenCable.ComponentStatus = ComponentStatus.CurrentValid;
            // Set properties for the green cable
            greenCable.WireCount = 12;
            greenCable.IsShielded = false;
            greenCable.Length = 100;
            greenCable.Color = ColorType.G;

            CompositeComponentGrpc greenCableGrpc = CompositeComponentExtensions.FromEntity(greenCable);
            compositeComponent.CompositeComponentGrpcs.Add(greenCableGrpc);

            // A clip component
            DbClip clipComponent = new DbClip();
            clipComponent.Id = _CompositeComponentId1;
            clipComponent.ComponentType = ComponentType.Clip;
            clipComponent.Name = $"{ComponentType.Clip.GetEnumDescription()}-001";
            clipComponent.Comment = "A standard clip used in various applications.";
            clipComponent.SheetNumber = 90002;
            clipComponent.Issue = "Test clip";
            clipComponent.ComponentStatus = ComponentStatus.CurrentValid;
            // Set properties for the clip component
            clipComponent.ClipTypeId = Guid.Parse("ae91f78c-654d-47ff-bb66-7f1a7fd700cf");
            clipComponent.TieType = TieType.BO;
            clipComponent.DimensionCode = "D1";
            clipComponent.ThicknessCode = "T1";
            clipComponent.Length = 50;
            clipComponent.IsDoubleHarness = true;
            clipComponent.ClipOrientationStart = 0;
            clipComponent.ClipOrientationEnd = 180;
            clipComponent.AdditionalInformation = "This is a test clip component.";

            CompositeComponentGrpc clipComponentGrpc = CompositeComponentExtensions.FromEntity(clipComponent);
            compositeComponent.CompositeComponentGrpcs.Add(clipComponentGrpc);

            return compositeComponent;
        }
    }
}
