namespace Master.Services
{
    public static class SampleMasterDataService
    {

        #region Currency
        public static ListCurrencyData PopulateCurrencyData()
        {
            ListCurrencyData listCurrencyData = new ListCurrencyData();
            for (int i = 0; i < 5; i++)
            {
                CurrencyData currencyData = new CurrencyData();
                currencyData.CurrencyName = $"TestName{i}";
                currencyData.CurrencyCode = $"TestCode{i}";
                currencyData.Id = Guid.NewGuid().ToString();
                currencyData.IsActive = true;
                currencyData.EuroRate = $"TestEuroRate{i}";
                listCurrencyData.CurrencyData.Add(currencyData);
            }

            CurrencyData fixedCurrencyData = new CurrencyData();
            fixedCurrencyData.CurrencyName = $"TestName";
            fixedCurrencyData.CurrencyCode = $"TestCode";
            fixedCurrencyData.Id = "ec44e5cd-5832-48dd-b5a3-440b5cb49450";
            fixedCurrencyData.IsActive = true;
            fixedCurrencyData.EuroRate = $"TestEuroRate";
            listCurrencyData.CurrencyData.Add(fixedCurrencyData);
            return listCurrencyData;
        }
        #endregion

        #region Customer
        public static ListCustomerData PopulateCustomerData()
        {
            ListCustomerData currencyList = new ListCustomerData();
            for (int i = 0; i < 5; i++)
            {
                CustomerData currency = new CustomerData();
                currency.Id = Guid.NewGuid().ToString();
                currency.CustomerBusinessGroupCode = $"TestGroupCode{i}";
                currency.CustomerBusinessGroupName = $"TestGroupName{i}";
                currency.SEWSEBusinessTeam = $"TestSEWSETeam{i}";
                currency.IsActive = true;
                currencyList.CustomerData.Add(currency);
            }

            CustomerData fixedCustomerDto = new CustomerData();
            fixedCustomerDto.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";
            fixedCustomerDto.CustomerBusinessGroupCode = "TestGroupCode";
            fixedCustomerDto.CustomerBusinessGroupName = "TestGroupName";
            fixedCustomerDto.SEWSEBusinessTeam = "TestSEWSETeam";
            fixedCustomerDto.IsActive = true;
            currencyList.CustomerData.Add(fixedCustomerDto);
            return currencyList;
        }

        public static ListCustomerLocationData PopulateCustomerLocationsData()
        {
            ListCustomerLocationData locationList = new ListCustomerLocationData();
            for (int i = 0; i < 5; i++)
            {
                CustomerLocationData customerLocation = new CustomerLocationData();
                customerLocation.Id = Guid.NewGuid().ToString();
                customerLocation.CustomerCode = $"TestCustomerCode{i}";
                customerLocation.CustomerName = $"TestCustomerName{i}";
                customerLocation.CustomerBusinessHierarchyGuid = Guid.NewGuid().ToString();
                customerLocation.IsActive = true;
                locationList.CustomerLocationData.Add(customerLocation);
            }

            CustomerLocationData fixedCustomerLocationData = new CustomerLocationData();
            fixedCustomerLocationData.Id = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerLocationData.CustomerCode = "TestCustomerCode";
            fixedCustomerLocationData.CustomerName = "TestCustomerName";
            fixedCustomerLocationData.CustomerBusinessHierarchyGuid = "04707931-2cff-4b2c-8fbd-bef614c6a99a";
            fixedCustomerLocationData.IsActive = true;
            locationList.CustomerLocationData.Add(fixedCustomerLocationData);
            return locationList;
        }

        public static ListCustomerSalesEntityData PopulateCustomerSalesEntityData()
        {
            ListCustomerSalesEntityData customerSalesEntityList = new ListCustomerSalesEntityData();
            for (int i = 0; i < 5; i++)
            {
                CustomerSalesEntityData customerSalesEntity = new CustomerSalesEntityData();
                customerSalesEntity.Id = Guid.NewGuid().ToString();
                customerSalesEntity.CustomerSalesEntityCode = $"TestCustomerSalesEntityCode{i}";
                customerSalesEntity.CustomerSalesEntityName = $"TestCustomerSalesEntityName{i}";
                customerSalesEntity.FinanceCode = $"TestFinanceCode{i}";
                customerSalesEntity.CustomerHierarchyGuid = Guid.NewGuid().ToString();
                customerSalesEntity.IsActive = true;
                customerSalesEntityList.CustomerSalesEntityData.Add(customerSalesEntity);
            }

            CustomerSalesEntityData fixedCustomerSalesEntityData = new CustomerSalesEntityData();
            fixedCustomerSalesEntityData.Id = "84e51c97-4da5-460e-b918-3d70edd87d88";
            fixedCustomerSalesEntityData.CustomerSalesEntityCode = "TestfixedCustomerSalesEntityCode";
            fixedCustomerSalesEntityData.CustomerSalesEntityName = "TestfixedCustomerSalesEntityName";
            fixedCustomerSalesEntityData.FinanceCode = "TestFinanceCode";
            fixedCustomerSalesEntityData.CustomerHierarchyGuid = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerSalesEntityData.IsActive = true;
            customerSalesEntityList.CustomerSalesEntityData.Add(fixedCustomerSalesEntityData);
            return customerSalesEntityList;
        }

        public static ListCustomerProjectAssociationData PopulateCustomerProjectAssociationData()
        {
            ListCustomerProjectAssociationData customerProjectAssociationList = new ListCustomerProjectAssociationData();
            for (int i = 0; i < 5; i++)
            {
                CustomerProjectAssociationData customerProjectAssociation = new CustomerProjectAssociationData();
                customerProjectAssociation.Id = Guid.NewGuid().ToString();
                customerProjectAssociation.ProjectGuid = Guid.NewGuid().ToString();
                customerProjectAssociation.CustomerLocationGuid = Guid.NewGuid().ToString();
                customerProjectAssociation.IsActive = true;
                customerProjectAssociationList.CustomerProjectAssociationData.Add(customerProjectAssociation);
            }

            CustomerProjectAssociationData fixedCustomerProjectAssociationData = new CustomerProjectAssociationData();
            fixedCustomerProjectAssociationData.Id = "fd994af4-57a3-4d95-b75d-b8d502e6a023";
            fixedCustomerProjectAssociationData.ProjectGuid = Guid.NewGuid().ToString();
            fixedCustomerProjectAssociationData.CustomerLocationGuid = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerProjectAssociationData.IsActive = true;
            customerProjectAssociationList.CustomerProjectAssociationData.Add(fixedCustomerProjectAssociationData);
            return customerProjectAssociationList;
        }

        public static ListCustomerBusinessUserAssociationData PopulateCustomerBusinessUserAssociationData()
        {
            ListCustomerBusinessUserAssociationData customerBusinessUserAssociationList = new ListCustomerBusinessUserAssociationData();
            for (int i = 0; i < 5; i++)
            {
                CustomerBusinessUserAssociationData customerBusinessUserAssociation = new CustomerBusinessUserAssociationData();
                customerBusinessUserAssociation.Id = Guid.NewGuid().ToString();
                customerBusinessUserAssociation.UserGuid = Guid.NewGuid().ToString();
                customerBusinessUserAssociation.CustomerBusinessHierarchyList = $"TestCustomerBusinessHierarchyList{i}";
                customerBusinessUserAssociation.IsActive = true;
                customerBusinessUserAssociationList.CustomerBusinessUserAssociationData.Add(customerBusinessUserAssociation);
            }

            CustomerBusinessUserAssociationData fixedCustomerBusinessUserAssociationData = new CustomerBusinessUserAssociationData();
            fixedCustomerBusinessUserAssociationData.Id = "fb54307a-2d16-4ebc-9f70-ed55a5b6e326";
            fixedCustomerBusinessUserAssociationData.UserGuid = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            fixedCustomerBusinessUserAssociationData.CustomerBusinessHierarchyList = "[{\"CustomerBusinessHierarchyGuid\":\"04707931-2cff-4b2c-8fbd-bef614c6a99a\",\"IsActive\":true}]";
            fixedCustomerBusinessUserAssociationData.IsActive = true;
            customerBusinessUserAssociationList.CustomerBusinessUserAssociationData.Add(fixedCustomerBusinessUserAssociationData);
            return customerBusinessUserAssociationList;
        }

        #endregion

        #region Project

        public static ListPlatformData PopulatePlatformData()
        {
            ListPlatformData platformList = new ListPlatformData();
            for (int i = 0; i < 5; i++)
            {
                PlatformData platform = new PlatformData();
                platform.Id = Guid.NewGuid().ToString();
                platform.PlatformName = $"TestPlatformName{i}";
                platform.CustomerHierarchyGuid = Guid.NewGuid().ToString();
                platform.PlatformManagerName = $"TestPlatformManagerName{i}";
                platform.IsActive = true;
                platformList.PlatformData.Add(platform);
            }

            PlatformData fixedPlatformDto = new PlatformData();
            fixedPlatformDto.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";
            fixedPlatformDto.PlatformName = "TestPlatformName";
            fixedPlatformDto.CustomerHierarchyGuid = Guid.NewGuid().ToString();
            fixedPlatformDto.PlatformManagerName = "TestPlatformManagerName";
            fixedPlatformDto.IsActive = true;
            platformList.PlatformData.Add(fixedPlatformDto);
            return platformList;
        }

        public static ListProgramData PopulateProgramData()
        {
            ListProgramData programList = new ListProgramData();
            for (int i = 0; i < 5; i++)
            {
                ProgramData program = new ProgramData();
                program.Id = Guid.NewGuid().ToString();
                program.ProgramName = $"TestProgramName{i}";
                program.PlatformHierarchyGuid = Guid.NewGuid().ToString();
                program.IsActive = true;
                programList.ProgramData.Add(program);
            }

            ProgramData fixedProgramDto = new ProgramData();
            fixedProgramDto.Id = "aea9e204-0353-4297-a9ff-bbe75f9b4a93";
            fixedProgramDto.ProgramName = "TestProgramName";
            fixedProgramDto.PlatformHierarchyGuid = Guid.NewGuid().ToString();
            fixedProgramDto.IsActive = true;
            programList.ProgramData.Add(fixedProgramDto);
            return programList;
        }

        public static ListProjectData PopulateProjectData()
        {
            ListProjectData projectList = new ListProjectData();
            for (int i = 0; i < 5; i++)
            {
                ProjectData project = new ProjectData();
                project.Id = Guid.NewGuid().ToString();
                project.ProjectCode = $"TestProjectCode{i}";
                project.ProjectName = $"TestProjectName{i}";
                project.CustomerProjectCode = $"TestCustomerProjectCode{i}";
                project.ProjectDescription = $"TestProjectDescription{i}";
                project.ProjectAnnualVolume = i;
                project.ProgramHierarchyGuid = Guid.NewGuid().ToString();
                project.IsActive = true;
                projectList.ProjectData.Add(project);
            }

            ProjectData fixedProjectDto = new ProjectData();
            fixedProjectDto.Id = "461616e5-fd7b-491c-9592-8453182e7e72";
            fixedProjectDto.ProjectCode = "TestProjectCode";
            fixedProjectDto.ProjectName = "TestProjectName";
            fixedProjectDto.CustomerProjectCode = "TestCustomerProjectCode";
            fixedProjectDto.ProjectDescription = "TestProjectDescription";
            fixedProjectDto.ProjectAnnualVolume = 0;
            fixedProjectDto.ProgramHierarchyGuid = Guid.NewGuid().ToString();
            fixedProjectDto.IsActive = true;
            projectList.ProjectData.Add(fixedProjectDto);
            return projectList;
        }

        public static ListMilestoneData PopulateMilestoneData()
        {
            ListMilestoneData milestoneList = new ListMilestoneData();
            for (int i = 0; i < 5; i++)
            {
                MilestoneData project = new MilestoneData();
                project.Id = Guid.NewGuid().ToString();
                project.EventStartDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                project.EventEndDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                project.ProjectHierarchyGuid = Guid.NewGuid().ToString();
                project.IsActive = true;
                milestoneList.MilestoneData.Add(project);
            }

            MilestoneData fixedProjectDto = new MilestoneData();
            fixedProjectDto.Id = "50365c14-734c-406a-b18e-9a3eff9e2d17";
            fixedProjectDto.MilestoneEventName = "TestMilestoneEventName";
            fixedProjectDto.EventStartDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedProjectDto.EventEndDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedProjectDto.ProjectHierarchyGuid = Guid.NewGuid().ToString();
            fixedProjectDto.IsActive = true;
            milestoneList.MilestoneData.Add(fixedProjectDto);
            return milestoneList;
        }
        #endregion

        #region Vehicle
        public static ListVehicleData PopulateVehicleData()
        {
            ListVehicleData platformList = new ListVehicleData();
            for (int i = 0; i < 5; i++)
            {
                VehicleData platform = new VehicleData();
                platform.Id = Guid.NewGuid().ToString();
                platform.VehicleName = $"TestVehicleName{i}";
                platform.ProjectReference = $"TestProjectReference{i}";
                platform.VehicleDisplay = $"TestVehicleDisplay{i}";
                platform.IsActive = true;
                platformList.VehicleData.Add(platform);
            }

            VehicleData fixedPlatformDto = new VehicleData();
            fixedPlatformDto.Id = "766612a1-5c65-4d17-950d-2841e1888f0b";
            fixedPlatformDto.VehicleName = "TestVehicleName";
            fixedPlatformDto.ProjectReference = "TestProjectReference";
            fixedPlatformDto.VehicleDisplay = "TestVehicleDisplay";
            fixedPlatformDto.IsActive = true;
            platformList.VehicleData.Add(fixedPlatformDto);
            return platformList;
        }
        #endregion
    }
}
