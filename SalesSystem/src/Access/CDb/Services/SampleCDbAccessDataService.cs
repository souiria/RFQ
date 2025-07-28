namespace CDb.Services
{
    public static class SampleCDbAccessDataService
    {
        static readonly Guid _CompositeComponentId0;    // cable
        static readonly Guid _CompositeComponentId1;    // clip
        static SampleCDbAccessDataService()
        {
            _CompositeComponentId0 = Guid.Parse("83e2c52d-3728-4ceb-a57b-b9234995b45e");
            _CompositeComponentId1 = Guid.Parse("83e2c52d-3728-4ceb-a57b-b9234995b45f");
        }
        public static ListClipTypeGrpc PopulateClipTypeInitData()
        {
            ListClipTypeGrpc clipTypeGrpcs = new ListClipTypeGrpc();
            ClipTypeGrpc doubleClip = new ClipTypeGrpc();
            doubleClip.Id = "cdd0d832-7ed0-4141-953c-2a1909dd5181";
            doubleClip.Code = "DOUBLE";
            doubleClip.Description = "Double";
            doubleClip.IsActive = true;

            ClipTypeGrpc ovalShapedClip = new ClipTypeGrpc();
            ovalShapedClip.Id = "4be87ce2-2df7-4286-8af0-765828ce9248";
            ovalShapedClip.Code = "OVALSHAPED";
            ovalShapedClip.Description = "Oval-Shaped";
            ovalShapedClip.IsActive = true;

            ClipTypeGrpc roundShapedClip = new ClipTypeGrpc();
            roundShapedClip.Id = "33d0f1ab-2430-4a50-838e-6eeb431787e4";
            roundShapedClip.Code = "ROUNDSHAPED";
            roundShapedClip.Description = "Round-Shaped";
            roundShapedClip.IsActive = true;

            ClipTypeGrpc sptClip = new ClipTypeGrpc();
            sptClip.Id = "3cd8b591-a4d3-4591-8024-5a7262dbef6a";
            sptClip.Code = "SPT";
            sptClip.Description = "SPT";
            sptClip.IsActive = true;

            ClipTypeGrpc inactiveClip = new ClipTypeGrpc();
            inactiveClip.Id = "ae91f78c-654d-47ff-bb66-7f1a7fd700cf";
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

        internal static ListCompositeComponentGrpc PopulateCompositeComponentInitData()
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

            CompositeComponentGrpc greenCableGrpc = CompositeComponentExtensions.FromDb(greenCable);
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

            CompositeComponentGrpc clipComponentGrpc = CompositeComponentExtensions.FromDb(clipComponent);
            compositeComponent.CompositeComponentGrpcs.Add(clipComponentGrpc);

            return compositeComponent;
        }

        internal static ListCrimpingProcessTypeGrpc PopulateCrimpingProcessTypeInitData()
        {
            ListCrimpingProcessTypeGrpc crimpingProcessTypeGrpcs = new ListCrimpingProcessTypeGrpc();

            CrimpingProcessTypeGrpc unknown = new CrimpingProcessTypeGrpc();
            unknown.Id = "5c427cea-d05e-42b1-871e-6e2ed2a5ace9";
            unknown.Code = "Unknown";
            unknown.Description = "Unknown";
            unknown.IsActive = true;

            CrimpingProcessTypeGrpc tubular = new CrimpingProcessTypeGrpc();
            tubular.Id = "9c8b8ede-ad94-4664-b21c-0def2e3946cd";
            tubular.Code = "TubularBarrell";
            tubular.Description = "Tubular Barrell";
            tubular.IsActive = true;

            CrimpingProcessTypeGrpc usw = new CrimpingProcessTypeGrpc();
            usw.Id = "b3e1a548-bfa6-4cf1-9e73-3bd5d6de704e";
            usw.Code = "Usw";
            usw.Description = "Usw";
            usw.IsActive = true;

            CrimpingProcessTypeGrpc open = new CrimpingProcessTypeGrpc();
            open.Id = "f8975222-8fd4-4fde-b12b-4a7b28f0e8ec";
            open.Code = "OpenBarrell";
            open.Description = "Open Barrell";
            open.IsActive = true;

            CrimpingProcessTypeGrpc notAvailableCrimpingProcess = new CrimpingProcessTypeGrpc();
            notAvailableCrimpingProcess.Id = "f8975222-8fd4-4fde-b12b-4a7b28f0e8ec";
            notAvailableCrimpingProcess.Code = "OpenBarrell";
            notAvailableCrimpingProcess.Description = "Open Barrell";
            notAvailableCrimpingProcess.IsActive = false;

            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(unknown);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(tubular);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(usw);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(open);
            crimpingProcessTypeGrpcs.CrimpingProcessTypeGrpcs.Add(notAvailableCrimpingProcess);

            return crimpingProcessTypeGrpcs;
        }
    }
}
