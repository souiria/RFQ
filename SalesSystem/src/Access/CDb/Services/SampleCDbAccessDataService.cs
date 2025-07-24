using CDb.Extensions;

namespace CDb.Services
{
    public static class SampleCDbAccessDataService
    {
        static readonly Guid _CompositeCableComponentId;
        static SampleCDbAccessDataService()
        {
            _CompositeCableComponentId = Guid.Parse("83e2c52d-3728-4ceb-a57b-b9234995b45f");
        }
        public static ListClipTypeGrpc PopulateClipTypeSampleData()
        {
            ListClipTypeGrpc clipTypeGrpcs = new ListClipTypeGrpc();
            ClipTypeGrpc doubleClip = new ClipTypeGrpc();
            doubleClip.Id = Guid.NewGuid().ToString();
            doubleClip.Code = "DOUBLE";
            doubleClip.Description = "Double";
            doubleClip.IsActive = true;

            ClipTypeGrpc ovalShapedClip = new ClipTypeGrpc();
            ovalShapedClip.Id = Guid.NewGuid().ToString();
            ovalShapedClip.Code = "OVALSHAPED";
            ovalShapedClip.Description = "Oval-Shaped";
            ovalShapedClip.IsActive = true;

            ClipTypeGrpc roundShapedClip = new ClipTypeGrpc();
            roundShapedClip.Id = Guid.NewGuid().ToString();
            roundShapedClip.Code = "ROUNDSHAPED";
            roundShapedClip.Description = "Round-Shaped";
            roundShapedClip.IsActive = true;

            ClipTypeGrpc sptClip = new ClipTypeGrpc();
            sptClip.Id = Guid.NewGuid().ToString();
            sptClip.Code = "SPT";
            sptClip.Description = "SPT";
            sptClip.IsActive = true;

            ClipTypeGrpc inactiveClip = new ClipTypeGrpc();
            inactiveClip.Id = Guid.NewGuid().ToString();
            inactiveClip.Code = "iCLIP";
            inactiveClip.Description = "Inactive Clip";
            inactiveClip.IsActive = false;

            clipTypeGrpcs.ClipTypeGrpcs.Add(doubleClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(ovalShapedClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(roundShapedClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(sptClip);
            clipTypeGrpcs.ClipTypeGrpcs.Add(inactiveClip);

            return clipTypeGrpcs;
        }

        internal static ListCompositeComponentGrpc PopulateCompositeComponentSampleData()
        {
            ListCompositeComponentGrpc compositeComponent = new ListCompositeComponentGrpc();

            // A cable component    
            DbCable greenCable = new DbCable();
            // Generic properties for the cable
            greenCable.Id = _CompositeCableComponentId;
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

            CompositeComponentGrpc greenCableGrpc = CompositeComponentExtensions.FromDb(greenCable);
            compositeComponent.CompositeComponentGrpcs.Add(greenCableGrpc);

            // A clip component
            DbClip clipComponent = new DbClip();
            clipComponent.Id = Guid.NewGuid();
            clipComponent.ComponentType = ComponentType.Clip;
            clipComponent.Name = $"{ComponentType.Clip.GetEnumDescription()}-001";
            clipComponent.Comment = "A standard clip used in various applications.";
            clipComponent.SheetNumber = 90002;
            clipComponent.Issue = "Test clip";
            clipComponent.ComponentStatus = ComponentStatus.CurrentValid;
            // Set properties for the clip component
            clipComponent.ClipTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001");
            clipComponent.TieType = TieType.BO;
            clipComponent.DimensionCode = "D1";
            clipComponent.ThicknessCode = "T1";
            clipComponent.Length = 50;
            clipComponent.IsDoubleHarness = true;
            clipComponent.ClipOrientationStart = 0;
            clipComponent.ClipOrientationEnd = 180;
            clipComponent.AdditionalInformation = "This is a test clip component.";

            CompositeComponentGrpc clipComponentGrpc = CompositeComponentExtensions.FromDb(clipComponent);
            compositeComponent.CompositeComponentGrpcs.Add(clipComponentGrpc);

            return compositeComponent;
        }
    }
}
