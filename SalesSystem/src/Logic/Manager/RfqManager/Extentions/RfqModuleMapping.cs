namespace RfqModule.Extentions
{
    public static class RfqModuleMapping
    {
        public static CustomerGrpc ToCustomerGrpc(this Master.CustomerGrpc masterCustomer)
        {
            CustomerGrpc customer = new CustomerGrpc();
            customer.Id = masterCustomer.Id;
            customer.CustomerBusinessGroupCode = masterCustomer.CustomerBusinessGroupCode;
            customer.CustomerBusinessGroupName = masterCustomer.CustomerBusinessGroupName;
            customer.SEWSEBusinessTeam = masterCustomer.SEWSEBusinessTeam;
            customer.IsActive = masterCustomer.IsActive;
            return customer;
        }

        public static CustomerLocationGrpc ToCustomerLocation(this Master.CustomerLocationGrpc masterLocationGrpc)
        {
            CustomerLocationGrpc location = new CustomerLocationGrpc();
            location.Id = masterLocationGrpc.Id;
            location.CustomerCode = masterLocationGrpc.CustomerCode;
            location.CustomerBusinessHierarchyGuid = masterLocationGrpc.CustomerBusinessHierarchyGuid;
            location.CustomerName = masterLocationGrpc.CustomerName;
            location.IsActive = masterLocationGrpc.IsActive;
            return location;
        }

        public static ProjectGrpc ToProject(this ProjectGrpc masterProjectGrpc)
        {
            ProjectGrpc projectAssociation = new ProjectGrpc();
            projectAssociation.Id = masterProjectGrpc.Id;
            projectAssociation.ProjectCode = masterProjectGrpc.ProjectCode;
            projectAssociation.ProjectName = masterProjectGrpc.ProjectName;
            projectAssociation.CustomerProjectCode = masterProjectGrpc.CustomerProjectCode;
            projectAssociation.ProjectDescription = masterProjectGrpc.ProjectDescription;
            projectAssociation.ProjectAnnualVolume = masterProjectGrpc.ProjectAnnualVolume;
            projectAssociation.ProgramHierarchyGuid = masterProjectGrpc.ProgramHierarchyGuid;
            projectAssociation.IsActive = masterProjectGrpc.IsActive;
            return projectAssociation;
        }

        public static VehicleGrpc ToVehicle(this Master.VehicleGrpc masterVehicleGrpc)
        {
            VehicleGrpc vehicle = new VehicleGrpc();
            vehicle.Id = masterVehicleGrpc.Id;
            vehicle.VehicleName = masterVehicleGrpc.VehicleName;
            vehicle.VehicleDisplay = masterVehicleGrpc.VehicleDisplay;
            vehicle.IsActive = masterVehicleGrpc.IsActive;
            return vehicle;
        }

        public static CustomerProjectAssociationGrpc ToCustomerProjectAssociation(this Master.CustomerProjectAssociationGrpc masterCustomerProjectAssociationGrpc)
        {
            CustomerProjectAssociationGrpc customerProjectAssociation = new CustomerProjectAssociationGrpc();
            customerProjectAssociation.Id = masterCustomerProjectAssociationGrpc.Id;
            customerProjectAssociation.CustomerLocationGuid = masterCustomerProjectAssociationGrpc.CustomerLocationGuid;
            customerProjectAssociation.ProjectGuid = masterCustomerProjectAssociationGrpc.ProjectGuid;
            customerProjectAssociation.IsActive = masterCustomerProjectAssociationGrpc.IsActive;
            return customerProjectAssociation;
        }

        public static RfqReasonGrpc ToReason(this Rfq.RfqReasonGrpc rfqRfqReasonGrpc)
        {
            RfqReasonGrpc reason = new RfqReasonGrpc();
            reason.RowId = rfqRfqReasonGrpc.RowId;
            reason.RfqReasonTitle = rfqRfqReasonGrpc.ReasonTitle;
            return reason;
        }

        public static RfqProject ToRfqProject(this RfqProjectGrpc rfqProjectGrpc)
        {
            RfqProject project = new RfqProject();
            project.RowId = rfqProjectGrpc.RowId;
            project.RfqNumber = rfqProjectGrpc.RfqNumber;
            project.CustomerBusinessUnitGuid = rfqProjectGrpc.CustomerBusinessUnitGuid;
            project.CustomerLocationGuid = rfqProjectGrpc.CustomerLocationGuid;
            project.ProjectGuid = rfqProjectGrpc.ProjectGuid;
            project.RfqReasonId = rfqProjectGrpc.RfqReasonId ??0;
            project.RfqResponseDeadline = rfqProjectGrpc.RfqResponseDeadline;
            project.CarModelGuid = rfqProjectGrpc.CarModelGuid;
            project.VehicleVolume = rfqProjectGrpc.VehicleVolume ??0;
            project.CreatedDate = rfqProjectGrpc.CreatedDate;
            project.RfqReasonName = rfqProjectGrpc.RfqReasonName;
            project.IsActive = rfqProjectGrpc.IsActive; 
            project.ProjectName = rfqProjectGrpc.ProjectName;
            project.CustomerBusinessGroupCode= rfqProjectGrpc.CustomerBusinessGroupCode;
            project.CustomerLocationName = rfqProjectGrpc.CustomerLocationName;
            project.CarModelName = rfqProjectGrpc.CarModelName;
            return project;
        }
        public static RfqDrawingPartNumber ToRfqDrawingPartNumber(this RfqDrawingPartNumbersGrpc rfqPartGrpc)
        {
            RfqDrawingPartNumber part = new RfqDrawingPartNumber();
            part.RowId = rfqPartGrpc.RowId;
            part.RfqId = rfqPartGrpc.RfqId;
            part.OriginalPartNumber = rfqPartGrpc.OriginalPartNumber;
            part.OriginalPartNumberPrice = rfqPartGrpc.OriginalPartNumberPrice ??0;
            part.SwappedPartNumber = rfqPartGrpc.SwappedPartNumber;
            part.SwappedPartNumberPrice = rfqPartGrpc.SwappedPartNumberPrice??0;
            part.PriceSource = rfqPartGrpc.PriceSource;
            part.IsExactMatch = rfqPartGrpc.IsExactMatch ?? false;
            part.IsSwapped = rfqPartGrpc.IsSwapped ?? false;
            part.Comments = rfqPartGrpc.Comments;
            part.SumitomoPartNumber = rfqPartGrpc.SumitomoPartNumber;
            return part;
        }
    }
}
