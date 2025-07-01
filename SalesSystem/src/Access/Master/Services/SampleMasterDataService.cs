namespace Master.Services
{
    public static class SampleMasterDataService
    {

        #region Currency
        public static ListCurrencyGrpc PopulateCurrencyGrpc()
        {
            ListCurrencyGrpc listCurrencyGrpc = new ListCurrencyGrpc();
            for (int i = 0; i < 5; i++)
            {
                CurrencyGrpc currencyGrpc = new CurrencyGrpc();
                currencyGrpc.CurrencyName = $"TestName{i}";
                currencyGrpc.CurrencyCode = $"TestCode{i}";
                currencyGrpc.Id = Guid.NewGuid().ToString();
                currencyGrpc.IsActive = true;
                currencyGrpc.EuroRate = $"TestEuroRate{i}";
                listCurrencyGrpc.CurrencyGrpc.Add(currencyGrpc);
            }

            CurrencyGrpc fixedCurrencyGrpc = new CurrencyGrpc();
            fixedCurrencyGrpc.CurrencyName = $"TestName";
            fixedCurrencyGrpc.CurrencyCode = $"TestCode";
            fixedCurrencyGrpc.Id = "ec44e5cd-5832-48dd-b5a3-440b5cb49450";
            fixedCurrencyGrpc.IsActive = true;
            fixedCurrencyGrpc.EuroRate = $"TestEuroRate";
            listCurrencyGrpc.CurrencyGrpc.Add(fixedCurrencyGrpc);
            return listCurrencyGrpc;
        }
        #endregion

        #region Customer
        public static ListCustomerGrpc PopulateCustomerGrpc()
        {
            ListCustomerGrpc currencyList = new ListCustomerGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerGrpc currency = new CustomerGrpc();
                currency.Id = Guid.NewGuid().ToString();
                currency.CustomerBusinessGroupCode = $"TestGroupCode{i}";
                currency.CustomerBusinessGroupName = $"TestGroupName{i}";
                currency.SEWSEBusinessTeam = $"TestSEWSETeam{i}";
                currency.IsActive = true;
                currencyList.CustomerGrpc.Add(currency);
            }

            CustomerGrpc fixedCustomerDto = new CustomerGrpc();
            fixedCustomerDto.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";
            fixedCustomerDto.CustomerBusinessGroupCode = "TestGroupCode";
            fixedCustomerDto.CustomerBusinessGroupName = "TestGroupName";
            fixedCustomerDto.SEWSEBusinessTeam = "TestSEWSETeam";
            fixedCustomerDto.IsActive = true;
            currencyList.CustomerGrpc.Add(fixedCustomerDto);
            return currencyList;
        }

        public static ListCustomerLocationGrpc PopulateCustomerLocationsData()
        {
            ListCustomerLocationGrpc locationList = new ListCustomerLocationGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerLocationGrpc customerLocation = new CustomerLocationGrpc();
                customerLocation.Id = Guid.NewGuid().ToString();
                customerLocation.CustomerCode = $"TestCustomerCode{i}";
                customerLocation.CustomerName = $"TestCustomerName{i}";
                customerLocation.CustomerBusinessHierarchyGuid = Guid.NewGuid().ToString();
                customerLocation.IsActive = true;
                locationList.CustomerLocationGrpc.Add(customerLocation);
            }

            CustomerLocationGrpc fixedCustomerLocationGrpc = new CustomerLocationGrpc();
            fixedCustomerLocationGrpc.Id = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerLocationGrpc.CustomerCode = "TestCustomerCode";
            fixedCustomerLocationGrpc.CustomerName = "TestCustomerName";
            fixedCustomerLocationGrpc.CustomerBusinessHierarchyGuid = "04707931-2cff-4b2c-8fbd-bef614c6a99a";
            fixedCustomerLocationGrpc.IsActive = true;
            locationList.CustomerLocationGrpc.Add(fixedCustomerLocationGrpc);
            return locationList;
        }

        public static ListCustomerSalesEntityGrpc PopulateCustomerSalesEntityGrpc()
        {
            ListCustomerSalesEntityGrpc customerSalesEntityList = new ListCustomerSalesEntityGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerSalesEntityGrpc customerSalesEntity = new CustomerSalesEntityGrpc();
                customerSalesEntity.Id = Guid.NewGuid().ToString();
                customerSalesEntity.CustomerSalesEntityCode = $"TestCustomerSalesEntityCode{i}";
                customerSalesEntity.CustomerSalesEntityName = $"TestCustomerSalesEntityName{i}";
                customerSalesEntity.FinanceCode = $"TestFinanceCode{i}";
                customerSalesEntity.CustomerHierarchyGuid = Guid.NewGuid().ToString();
                customerSalesEntity.IsActive = true;
                customerSalesEntityList.CustomerSalesEntityGrpc.Add(customerSalesEntity);
            }

            CustomerSalesEntityGrpc fixedCustomerSalesEntityGrpc = new CustomerSalesEntityGrpc();
            fixedCustomerSalesEntityGrpc.Id = "84e51c97-4da5-460e-b918-3d70edd87d88";
            fixedCustomerSalesEntityGrpc.CustomerSalesEntityCode = "TestfixedCustomerSalesEntityCode";
            fixedCustomerSalesEntityGrpc.CustomerSalesEntityName = "TestfixedCustomerSalesEntityName";
            fixedCustomerSalesEntityGrpc.FinanceCode = "TestFinanceCode";
            fixedCustomerSalesEntityGrpc.CustomerHierarchyGuid = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerSalesEntityGrpc.IsActive = true;
            customerSalesEntityList.CustomerSalesEntityGrpc.Add(fixedCustomerSalesEntityGrpc);
            return customerSalesEntityList;
        }

        public static ListCustomerProjectAssociationGrpc PopulateCustomerProjectAssociationGrpc()
        {
            ListCustomerProjectAssociationGrpc customerProjectAssociationList = new ListCustomerProjectAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerProjectAssociationGrpc customerProjectAssociation = new CustomerProjectAssociationGrpc();
                customerProjectAssociation.Id = Guid.NewGuid().ToString();
                customerProjectAssociation.ProjectGuid = Guid.NewGuid().ToString();
                customerProjectAssociation.CustomerLocationGuid = Guid.NewGuid().ToString();
                customerProjectAssociation.IsActive = true;
                customerProjectAssociationList.CustomerProjectAssociationGrpc.Add(customerProjectAssociation);
            }

            CustomerProjectAssociationGrpc fixedCustomerProjectAssociationGrpc = new CustomerProjectAssociationGrpc();
            fixedCustomerProjectAssociationGrpc.Id = "fd994af4-57a3-4d95-b75d-b8d502e6a023";
            fixedCustomerProjectAssociationGrpc.ProjectGuid = Guid.NewGuid().ToString();
            fixedCustomerProjectAssociationGrpc.CustomerLocationGuid = "3759c3b6-aceb-475e-9ba3-74f13e441e2d";
            fixedCustomerProjectAssociationGrpc.IsActive = true;
            customerProjectAssociationList.CustomerProjectAssociationGrpc.Add(fixedCustomerProjectAssociationGrpc);
            return customerProjectAssociationList;
        }

        public static ListCustomerBusinessUserAssociationGrpc PopulateCustomerBusinessUserAssociationGrpc()
        {
            ListCustomerBusinessUserAssociationGrpc customerBusinessUserAssociationList = new ListCustomerBusinessUserAssociationGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerBusinessUserAssociationGrpc customerBusinessUserAssociation = new CustomerBusinessUserAssociationGrpc();
                customerBusinessUserAssociation.Id = Guid.NewGuid().ToString();
                customerBusinessUserAssociation.UserGuid = Guid.NewGuid().ToString();
                customerBusinessUserAssociation.CustomerBusinessHierarchyList = $"TestCustomerBusinessHierarchyList{i}";
                customerBusinessUserAssociation.IsActive = true;
                customerBusinessUserAssociationList.CustomerBusinessUserAssociationGrpc.Add(customerBusinessUserAssociation);
            }

            CustomerBusinessUserAssociationGrpc fixedCustomerBusinessUserAssociationGrpc = new CustomerBusinessUserAssociationGrpc();
            fixedCustomerBusinessUserAssociationGrpc.Id = "fb54307a-2d16-4ebc-9f70-ed55a5b6e326";
            fixedCustomerBusinessUserAssociationGrpc.UserGuid = "83853662-6d20-41b0-b6ac-fd3271406b6b";
            fixedCustomerBusinessUserAssociationGrpc.CustomerBusinessHierarchyList = "[{\"CustomerBusinessHierarchyGuid\":\"04707931-2cff-4b2c-8fbd-bef614c6a99a\",\"IsActive\":true}]";
            fixedCustomerBusinessUserAssociationGrpc.IsActive = true;
            customerBusinessUserAssociationList.CustomerBusinessUserAssociationGrpc.Add(fixedCustomerBusinessUserAssociationGrpc);
            return customerBusinessUserAssociationList;
        }

        #endregion

        #region Project

        public static ListPlatformGrpc PopulatePlatformGrpc()
        {
            ListPlatformGrpc platformList = new ListPlatformGrpc();
            for (int i = 0; i < 5; i++)
            {
                PlatformGrpc platform = new PlatformGrpc();
                platform.Id = Guid.NewGuid().ToString();
                platform.PlatformName = $"TestPlatformName{i}";
                platform.CustomerHierarchyGuid = Guid.NewGuid().ToString();
                platform.PlatformManagerName = $"TestPlatformManagerName{i}";
                platform.IsActive = true;
                platformList.PlatformGrpc.Add(platform);
            }

            PlatformGrpc fixedPlatformDto = new PlatformGrpc();
            fixedPlatformDto.Id = "46711693-0ea4-4f9a-86c1-4973308bf795";
            fixedPlatformDto.PlatformName = "TestPlatformName";
            fixedPlatformDto.CustomerHierarchyGuid = Guid.NewGuid().ToString();
            fixedPlatformDto.PlatformManagerName = "TestPlatformManagerName";
            fixedPlatformDto.IsActive = true;
            platformList.PlatformGrpc.Add(fixedPlatformDto);
            return platformList;
        }

        public static ListProgramGrpc PopulateProgramGrpc()
        {
            ListProgramGrpc programList = new ListProgramGrpc();
            for (int i = 0; i < 5; i++)
            {
                ProgramGrpc program = new ProgramGrpc();
                program.Id = Guid.NewGuid().ToString();
                program.ProgramName = $"TestProgramName{i}";
                program.PlatformHierarchyGuid = Guid.NewGuid().ToString();
                program.IsActive = true;
                programList.ProgramGrpc.Add(program);
            }

            ProgramGrpc fixedProgramDto = new ProgramGrpc();
            fixedProgramDto.Id = "aea9e204-0353-4297-a9ff-bbe75f9b4a93";
            fixedProgramDto.ProgramName = "TestProgramName";
            fixedProgramDto.PlatformHierarchyGuid = Guid.NewGuid().ToString();
            fixedProgramDto.IsActive = true;
            programList.ProgramGrpc.Add(fixedProgramDto);
            return programList;
        }

        public static ListProjectGrpc PopulateProjectGrpc()
        {
            ListProjectGrpc projectList = new ListProjectGrpc();
            for (int i = 0; i < 5; i++)
            {
                ProjectGrpc project = new ProjectGrpc();
                project.Id = Guid.NewGuid().ToString();
                project.ProjectCode = $"TestProjectCode{i}";
                project.ProjectName = $"TestProjectName{i}";
                project.CustomerProjectCode = $"TestCustomerProjectCode{i}";
                project.ProjectDescription = $"TestProjectDescription{i}";
                project.ProjectAnnualVolume = i;
                project.ProgramHierarchyGuid = Guid.NewGuid().ToString();
                project.IsActive = true;
                projectList.ProjectGrpc.Add(project);
            }

            ProjectGrpc fixedProjectDto = new ProjectGrpc();
            fixedProjectDto.Id = "461616e5-fd7b-491c-9592-8453182e7e72";
            fixedProjectDto.ProjectCode = "TestProjectCode";
            fixedProjectDto.ProjectName = "TestProjectName";
            fixedProjectDto.CustomerProjectCode = "TestCustomerProjectCode";
            fixedProjectDto.ProjectDescription = "TestProjectDescription";
            fixedProjectDto.ProjectAnnualVolume = 0;
            fixedProjectDto.ProgramHierarchyGuid = Guid.NewGuid().ToString();
            fixedProjectDto.IsActive = true;
            projectList.ProjectGrpc.Add(fixedProjectDto);
            return projectList;
        }

        public static ListMilestoneGrpc PopulateMilestoneGrpc()
        {
            ListMilestoneGrpc milestoneList = new ListMilestoneGrpc();
            for (int i = 0; i < 5; i++)
            {
                MilestoneGrpc project = new MilestoneGrpc();
                project.Id = Guid.NewGuid().ToString();
                project.EventStartDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                project.EventEndDate = DateTime.Now.ToUniversalTime().ToTimestamp();
                project.ProjectHierarchyGuid = Guid.NewGuid().ToString();
                project.IsActive = true;
                milestoneList.MilestoneGrpc.Add(project);
            }

            MilestoneGrpc fixedProjectDto = new MilestoneGrpc();
            fixedProjectDto.Id = "50365c14-734c-406a-b18e-9a3eff9e2d17";
            fixedProjectDto.MilestoneEventName = "TestMilestoneEventName";
            fixedProjectDto.EventStartDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedProjectDto.EventEndDate = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedProjectDto.ProjectHierarchyGuid = Guid.NewGuid().ToString();
            fixedProjectDto.IsActive = true;
            milestoneList.MilestoneGrpc.Add(fixedProjectDto);
            return milestoneList;
        }
        #endregion

        #region Vehicle
        public static ListVehicleGrpc PopulateVehicleGrpc()
        {
            ListVehicleGrpc platformList = new ListVehicleGrpc();
            for (int i = 0; i < 5; i++)
            {
                VehicleGrpc platform = new VehicleGrpc();
                platform.Id = Guid.NewGuid().ToString();
                platform.VehicleName = $"TestVehicleName{i}";
                platform.ProjectReference = $"TestProjectReference{i}";
                platform.VehicleDisplay = $"TestVehicleDisplay{i}";
                platform.IsActive = true;
                platformList.VehicleGrpc.Add(platform);
            }

            VehicleGrpc fixedPlatformDto = new VehicleGrpc();
            fixedPlatformDto.Id = "766612a1-5c65-4d17-950d-2841e1888f0b";
            fixedPlatformDto.VehicleName = "TestVehicleName";
            fixedPlatformDto.ProjectReference = "TestProjectReference";
            fixedPlatformDto.VehicleDisplay = "TestVehicleDisplay";
            fixedPlatformDto.IsActive = true;
            platformList.VehicleGrpc.Add(fixedPlatformDto);
            return platformList;
        }
        #endregion
    }
}
