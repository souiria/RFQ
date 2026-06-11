namespace DSI.Services
{
    public static class SampleDSIDataService
    {
        #region Component

        public static ListComponentGrpc PopulateComponentGrpc()
        {
            ListComponentGrpc list = new ListComponentGrpc();

            for (int i = 0; i < 5; i++)
            {
                ComponentGrpc item = new ComponentGrpc();
                item.Id = Guid.NewGuid().ToString();
                item.NodeName = $"Node{i}";
                item.CavityName = $"Cavity{i}";
                item.WireName = $"Wire{i}";
                item.SequenceNumber = $"{i}";
                item.ComponentOption = $"Option{i}";
                item.Route = $"Route{i}";
                item.PartNumber1 = $"PN{i}";
                item.Quantity = 10;
                item.CrossSectionalArea = 1.5;
                item.IsPlugged = false;
                item.MaterialCode = $"Material{i}";
                item.InsulationType = $"Type{i}";
                item.HarnessID = Guid.NewGuid().ToString();

                list.ComponentList.Add(item);
            }

            ComponentGrpc fixedItem = new ComponentGrpc();
            fixedItem.Id = Guid.NewGuid().ToString();
            fixedItem.NodeName = "FixedNode";
            fixedItem.WireName = "FixedWire";
            fixedItem.PartNumber1 = "PN-TEST";
            fixedItem.Quantity = 100;

            list.ComponentList.Add(fixedItem);

            return list;
        }

        #endregion

        #region BranchInsulation

        public static ListBranchInsulationGrpc PopulateBranchInsulationGrpc()
        {
            ListBranchInsulationGrpc list = new ListBranchInsulationGrpc();

            for (int i = 0; i < 5; i++)
            {
                BranchInsulationGrpc item = new BranchInsulationGrpc();
                item.Id = Guid.NewGuid().ToString();
                item.StartNode = $"Start{i}";
                item.EndNode = $"End{i}";
                item.PieceCode = $"PC{i}";
                item.InsulationCode = $"INS{i}";
                item.Diameter = 2.5;
                item.ManualAmount = 5;
                item.PartNumber1 = $"PN{i}";
                item.IsConvoluted = true;
                item.IsSlit = false;
                item.HarnessID = Guid.NewGuid().ToString();

                list.BranchInsulationList.Add(item);
            }

            return list;
        }

        #endregion

        #region WireSpecification

        public static ListWireSpecificationGrpc PopulateWireSpecificationGrpc()
        {
            ListWireSpecificationGrpc list = new ListWireSpecificationGrpc();

            for (int i = 0; i < 5; i++)
            {
                WireSpecificationGrpc item = new WireSpecificationGrpc();
                item.Id = Guid.NewGuid().ToString();
                item.WireName = $"Wire{i}";
                item.WireType = "TypeA";
                item.Colour = "Red";
                item.CrossSectionalArea = 1.2;
                item.Material = "Copper";
                item.IsIncludedOnBom = true;
                item.IsIncludedOnChart = false;
                item.WireTag = $"Tag{i}";
                item.PartNumber1 = $"PN{i}";
                item.Signal = "SignalX";
                item.HarnessID = Guid.NewGuid().ToString();

                list.WireSpecificationList.Add(item);
            }

            return list;
        }

        #endregion

        #region CompositeDetail

        public static ListCompositeDetailGrpc PopulateCompositeDetailGrpc()
        {
            ListCompositeDetailGrpc list = new ListCompositeDetailGrpc();

            for (int i = 0; i < 5; i++)
            {
                CompositeDetailGrpc item = new CompositeDetailGrpc();
                item.Id = Guid.NewGuid().ToString();
                item.Customer = $"Customer{i}";
                item.Site = "SiteA";
                item.Range = "RangeX";
                item.BoardLength = 100;
                item.BoardWidth = 50;
                item.Type = "TypeA";
                item.Title = $"Title{i}";
                item.EngineSize = "2.0L";
                item.ManufacturingCell = "Cell1";
                item.Trim = "Standard";
                item.HandDrive = "Left";
                item.TubeAddOnType = "Type1";
                item.TubeAddOnFactor = 1.2;
                item.IsManualTerminal = false;
                item.AlphaCode = $"AC{i}";
                item.HarnessID = Guid.NewGuid().ToString();

                list.CompositeDetailList.Add(item);
            }

            return list;
        }

        #endregion

        #region Harness

        public static ListHarnessGrpc PopulateHarnessGrpc()
        {
            ListHarnessGrpc list = new ListHarnessGrpc();

            for (int i = 0; i < 5; i++)
            {
                HarnessGrpc item = new HarnessGrpc();
                item.Id = Guid.NewGuid().ToString();
                item.HarnessName1 = $"Harness{i}";
                item.Customer = $"Customer{i}";
                item.Site = "SiteA";
                item.Range = "Range1";
                item.BoardLength = 200;
                item.BoardWidth = 100;
                item.Type = "Main";
                item.Title = $"Title{i}";
                item.EngineSize = "2.0L";
                item.ManufacturingCell = "CellA";
                item.Trim = "Sport";
                item.HandDrive = "Left";
                item.AlphaCode = $"Alpha{i}";
                item.CreatedBy = Guid.NewGuid().ToString();

                list.HarnessList.Add(item);
            }

            return list;
        }

        #endregion
    }
}

