using Master.Data.Model;

namespace Master.Services
{
    public static class SampleMasterDataService
    {

        #region Currency
        public static IEnumerable<CurrencyDto> PopulateCurrencyData()
        {
            List<CurrencyDto> currencyList = new List<CurrencyDto>();
            for (int i = 0; i < 5; i++)
            {
                CurrencyDto currencyDto = new CurrencyDto();
                currencyDto.CurrencyName = $"TestName{i}";
                currencyDto.CurrencyCode = $"TestCode{i}";
                currencyDto.Id = Guid.NewGuid();
                currencyDto.IsActive = true;
                currencyDto.EuroRate = $"TestEuroRate{i}";
                currencyList.Add(currencyDto);
            }

            CurrencyDto fixedCurrencyDto = new CurrencyDto();
            fixedCurrencyDto.CurrencyName = $"TestName";
            fixedCurrencyDto.CurrencyCode = $"TestCode";
            fixedCurrencyDto.Id = Guid.Parse("ec44e5cd-5832-48dd-b5a3-440b5cb49450");
            fixedCurrencyDto.IsActive = true;
            fixedCurrencyDto.EuroRate = $"TestEuroRate";
            currencyList.Add(fixedCurrencyDto);
            return currencyList;
        }
        #endregion
        #region Customer
        public static IEnumerable<CustomerBusinessHierarchyDto> PopulateCustomerData()
        {
            List<CustomerBusinessHierarchyDto> currencyList = new List<CustomerBusinessHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                CustomerBusinessHierarchyDto currency = new CustomerBusinessHierarchyDto();
                currency.Id = Guid.NewGuid();
                currency.CustomerBusinessGroupCode = $"TestGroupCode{i}";
                currency.CustomerBusinessGroupName = $"TestGroupName{i}";
                currency.SEWSEBusinessTeam = $"TestSEWSETeam{i}";
                currency.IsActive = true;
                currencyList.Add(currency);
            }

            CustomerBusinessHierarchyDto fixedCustomerDto = new CustomerBusinessHierarchyDto();
            fixedCustomerDto.Id = Guid.Parse("46711693-0ea4-4f9a-86c1-4973308bf795");
            fixedCustomerDto.CustomerBusinessGroupCode = "TestGroupCode";
            fixedCustomerDto.CustomerBusinessGroupName = "TestGroupName";
            fixedCustomerDto.SEWSEBusinessTeam = "TestSEWSETeam";
            fixedCustomerDto.IsActive = true;
            currencyList.Add(fixedCustomerDto);
            return currencyList;
        }

        public static IEnumerable<CustomerHierarchyDto> PopulateCustomerLocationsData()
        {
            List<CustomerHierarchyDto> locationList = new List<CustomerHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                CustomerHierarchyDto customerLocation = new CustomerHierarchyDto();
                customerLocation.Id = Guid.NewGuid();
                customerLocation.CustomerCode = $"TestCustomerCode{i}";
                customerLocation.CustomerName = $"TestCustomerName{i}";
                customerLocation.StreetNumber = $"TestStreetNumber{i}";
                customerLocation.StreetName = $"TestStreetName{i}";
                customerLocation.City = $"TestCity{i}";
                customerLocation.Region = $"TestRegion{i}";
                customerLocation.ZipCode = $"TestZipCode{i}";
                customerLocation.Country = $"TestCountry{i}";
                customerLocation.CustomerBusinessType = $"TestCustomerBusinessType{i}";
                customerLocation.IndexedMaterial = $"TestIndexedMaterial{i}";
                customerLocation.CustomerBusinessHierarchyGuid = Guid.NewGuid();
                customerLocation.CustomerBusinessQualityManagerName = $"TestCustomerBusinessQualityManagerName{i}";
                customerLocation.CustomerCountryGuid = Guid.NewGuid();
                customerLocation.IndexedMaterial = $"TestIndexedMaterial{i}";
                customerLocation.IsActive = true;
                locationList.Add(customerLocation);
            }

            CustomerHierarchyDto fixedCustomerLocationDto = new CustomerHierarchyDto();
            fixedCustomerLocationDto.Id = Guid.Parse("3759c3b6-aceb-475e-9ba3-74f13e441e2d");
            fixedCustomerLocationDto.CustomerCode = "TestCustomerCode";
            fixedCustomerLocationDto.CustomerName = "TestCustomerName";
            fixedCustomerLocationDto.StreetNumber = "TestStreetNumber";
            fixedCustomerLocationDto.StreetName = "TestStreetName";
            fixedCustomerLocationDto.City = "TestCit";
            fixedCustomerLocationDto.Region = "TestRegion";
            fixedCustomerLocationDto.ZipCode = "TestZipCode";
            fixedCustomerLocationDto.Country = "TestCountry";
            fixedCustomerLocationDto.CustomerBusinessType = "TestCustomerBusinessType";
            fixedCustomerLocationDto.IndexedMaterial = "TestIndexedMaterial";
            fixedCustomerLocationDto.CustomerBusinessHierarchyGuid = Guid.Parse("04707931-2cff-4b2c-8fbd-bef614c6a99a");
            fixedCustomerLocationDto.CustomerBusinessQualityManagerName = "TestCustomerBusinessQualityManagerName";
            fixedCustomerLocationDto.CustomerCountryGuid = Guid.NewGuid();
            fixedCustomerLocationDto.IndexedMaterial = "TestIndexedMaterial";
            fixedCustomerLocationDto.IsActive = true;
            locationList.Add(fixedCustomerLocationDto);
            return locationList;
        }

        public static IEnumerable<CustomerSalesEntityDto> PopulateCustomerSalesEntityData()
        {
            List<CustomerSalesEntityDto> customerSalesEntityList = new List<CustomerSalesEntityDto>();
            for (int i = 0; i < 5; i++)
            {
                CustomerSalesEntityDto customerSalesEntity = new CustomerSalesEntityDto();
                customerSalesEntity.Id = Guid.NewGuid();
                customerSalesEntity.CustomerSalesEntityCode = $"TestCustomerSalesEntityCode{i}";
                customerSalesEntity.CustomerSalesEntityName = $"TestCustomerSalesEntityName{i}";
                customerSalesEntity.FinanceCode = $"TestFinanceCode{i}";
                customerSalesEntity.StreetNumber = $"TestStreetNumber{i}";
                customerSalesEntity.StreetName = $"TestStreetName{i}";
                customerSalesEntity.City = $"TestCity{i}";
                customerSalesEntity.Region = $"TestRegion{i}";
                customerSalesEntity.ZipCode = $"TestZipCode{i}";
                customerSalesEntity.Country = $"TestCountry{i}";
                customerSalesEntity.CustomerHierarchyGuid = Guid.NewGuid();
                customerSalesEntity.CustomerSalesCountryGuid = Guid.NewGuid();
                customerSalesEntity.IsActive = true;
                customerSalesEntityList.Add(customerSalesEntity);
            }

            CustomerSalesEntityDto fixedCustomerSalesEntityDto = new CustomerSalesEntityDto();
            fixedCustomerSalesEntityDto.Id = Guid.Parse("84e51c97-4da5-460e-b918-3d70edd87d88");
            fixedCustomerSalesEntityDto.CustomerSalesEntityCode = "TestfixedCustomerSalesEntityCode";
            fixedCustomerSalesEntityDto.CustomerSalesEntityName = "TestfixedCustomerSalesEntityName";
            fixedCustomerSalesEntityDto.FinanceCode = "TestFinanceCode";
            fixedCustomerSalesEntityDto.StreetNumber = "TestStreetNumber";
            fixedCustomerSalesEntityDto.StreetName = "TestStreetName";
            fixedCustomerSalesEntityDto.City = "TestCity";
            fixedCustomerSalesEntityDto.Region = "TestRegion";
            fixedCustomerSalesEntityDto.ZipCode = "TestZipCode";
            fixedCustomerSalesEntityDto.Country = "TestCountry";
            fixedCustomerSalesEntityDto.CustomerHierarchyGuid = Guid.Parse("3759c3b6-aceb-475e-9ba3-74f13e441e2d");
            fixedCustomerSalesEntityDto.CustomerSalesCountryGuid = Guid.NewGuid();
            fixedCustomerSalesEntityDto.IsActive = true;
            customerSalesEntityList.Add(fixedCustomerSalesEntityDto);
            return customerSalesEntityList;
        }

        public static IEnumerable<CustomerProjectAssociationDto> PopulateCustomerProjectAssociationData()
        {
            List<CustomerProjectAssociationDto> customerProjectAssociationList = new List<CustomerProjectAssociationDto>();
            for (int i = 0; i < 5; i++)
            {
                CustomerProjectAssociationDto customerProjectAssociation = new CustomerProjectAssociationDto();
                customerProjectAssociation.Id = Guid.NewGuid();
                customerProjectAssociation.ProjectGuid = Guid.NewGuid();
                customerProjectAssociation.CustomerLocationGuid = Guid.NewGuid();
                customerProjectAssociation.IsActive = true;
                customerProjectAssociationList.Add(customerProjectAssociation);
            }

            CustomerProjectAssociationDto fixedCustomerProjectAssociationDto = new CustomerProjectAssociationDto();
            fixedCustomerProjectAssociationDto.Id = Guid.Parse("fd994af4-57a3-4d95-b75d-b8d502e6a023");
            fixedCustomerProjectAssociationDto.ProjectGuid = Guid.NewGuid();
            fixedCustomerProjectAssociationDto.CustomerLocationGuid = Guid.Parse("3759c3b6-aceb-475e-9ba3-74f13e441e2d");
            fixedCustomerProjectAssociationDto.IsActive = true;
            customerProjectAssociationList.Add(fixedCustomerProjectAssociationDto);
            return customerProjectAssociationList;
        }

        public static IEnumerable<CustomerBusinessUserAssociationDto> PopulateCustomerBusinessUserAssociationData()
        {
            List<CustomerBusinessUserAssociationDto> customerBusinessUserAssociationList = new List<CustomerBusinessUserAssociationDto>();
            for (int i = 0; i < 5; i++)
            {
                CustomerBusinessUserAssociationDto customerBusinessUserAssociation = new CustomerBusinessUserAssociationDto();
                customerBusinessUserAssociation.Id = Guid.NewGuid();
                customerBusinessUserAssociation.UserGuid = Guid.NewGuid();
                customerBusinessUserAssociation.CustomerBusinessHierarchyList = $"TestCustomerBusinessHierarchyList{i}";
                customerBusinessUserAssociation.IsActive = true;
                customerBusinessUserAssociationList.Add(customerBusinessUserAssociation);
            }

            CustomerBusinessUserAssociationDto fixedCustomerBusinessUserAssociationDto = new CustomerBusinessUserAssociationDto();
            fixedCustomerBusinessUserAssociationDto.Id = Guid.Parse("fb54307a-2d16-4ebc-9f70-ed55a5b6e326");
            fixedCustomerBusinessUserAssociationDto.UserGuid = Guid.Parse("83853662-6d20-41b0-b6ac-fd3271406b6b");
            fixedCustomerBusinessUserAssociationDto.CustomerBusinessHierarchyList = "[{\"CustomerBusinessHierarchyGuid\":\"04707931-2cff-4b2c-8fbd-bef614c6a99a\",\"IsActive\":true}]";
            fixedCustomerBusinessUserAssociationDto.IsActive = true;
            customerBusinessUserAssociationList.Add(fixedCustomerBusinessUserAssociationDto);
            return customerBusinessUserAssociationList;
        }

        #endregion
        #region Project

        public static IEnumerable<PlatformHierarchyDto> PopulatePlatformData()
        {
            List<PlatformHierarchyDto> platformList = new List<PlatformHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                PlatformHierarchyDto platform = new PlatformHierarchyDto();
                platform.Id = Guid.NewGuid();
                platform.PlatformName = $"TestPlatformName{i}";
                platform.CustomerHierarchyGuid = Guid.NewGuid();
                platform.PlatformManagerName = $"TestPlatformManagerName{i}";
                platform.IsActive = true;
                platformList.Add(platform);
            }

            PlatformHierarchyDto fixedPlatformDto = new PlatformHierarchyDto();
            fixedPlatformDto.Id = Guid.Parse("46711693-0ea4-4f9a-86c1-4973308bf795");
            fixedPlatformDto.PlatformName = "TestPlatformName";
            fixedPlatformDto.CustomerHierarchyGuid = Guid.NewGuid();
            fixedPlatformDto.PlatformManagerName = "TestPlatformManagerName";
            fixedPlatformDto.IsActive = true;
            platformList.Add(fixedPlatformDto);
            return platformList;
        }

        public static IEnumerable<ProgramHierarchyDto> PopulateProgramData()
        {
            List<ProgramHierarchyDto> programList = new List<ProgramHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                ProgramHierarchyDto program = new ProgramHierarchyDto();
                program.Id = Guid.NewGuid();
                program.ProgramName = $"TestProgramName{i}";
                program.PlatformHierarchyGuid = Guid.NewGuid();
                program.IsActive = true;
                programList.Add(program);
            }

            ProgramHierarchyDto fixedProgramDto = new ProgramHierarchyDto();
            fixedProgramDto.Id = Guid.Parse("aea9e204-0353-4297-a9ff-bbe75f9b4a93");
            fixedProgramDto.ProgramName = "TestProgramName";
            fixedProgramDto.PlatformHierarchyGuid = Guid.NewGuid();
            fixedProgramDto.IsActive = true;
            programList.Add(fixedProgramDto);
            return programList;
        }

        public static IEnumerable<ProjectHierarchyDto> PopulateProjectData()
        {
            List<ProjectHierarchyDto> projectList = new List<ProjectHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                ProjectHierarchyDto project = new ProjectHierarchyDto();
                project.Id = Guid.NewGuid();
                project.ProjectCode = $"TestProjectCode{i}";
                project.ProjectName = $"TestProjectName{i}";
                project.CustomerProjectCode = $"TestCustomerProjectCode{i}";
                project.ProjectDescription = $"TestProjectDescription{i}";
                project.ProjectAnnualVolume = i;
                project.ProgramHierarchyGuid = Guid.NewGuid();
                project.IsActive = true;
                projectList.Add(project);
            }

            ProjectHierarchyDto fixedProjectDto = new ProjectHierarchyDto();
            fixedProjectDto.Id = Guid.Parse("461616e5-fd7b-491c-9592-8453182e7e72");
            fixedProjectDto.ProjectCode = "TestProjectCode";
            fixedProjectDto.ProjectName = "TestProjectName";
            fixedProjectDto.CustomerProjectCode = "TestCustomerProjectCode";
            fixedProjectDto.ProjectDescription = "TestProjectDescription";
            fixedProjectDto.ProjectAnnualVolume = 0;
            fixedProjectDto.ProgramHierarchyGuid = Guid.NewGuid();
            fixedProjectDto.IsActive = true;
            projectList.Add(fixedProjectDto);
            return projectList;
        }

        public static IEnumerable<MilestoneHierarchyDto> PopulateMilestoneData()
        {
            List<MilestoneHierarchyDto> milestoneList = new List<MilestoneHierarchyDto>();
            for (int i = 0; i < 5; i++)
            {
                MilestoneHierarchyDto project = new MilestoneHierarchyDto();
                project.Id = Guid.NewGuid();
                project.EventStartDate = DateTime.Now;
                project.EventEndDate = DateTime.Now;
                project.ProjectHierarchyGuid = Guid.NewGuid();
                project.IsActive = true;
                milestoneList.Add(project);
            }

            MilestoneHierarchyDto fixedProjectDto = new MilestoneHierarchyDto();
            fixedProjectDto.Id = Guid.Parse("50365c14-734c-406a-b18e-9a3eff9e2d17");
            fixedProjectDto.MilestoneEventName = "TestMilestoneEventName";
            fixedProjectDto.EventStartDate = DateTime.Now;
            fixedProjectDto.EventEndDate = DateTime.Now;
            fixedProjectDto.ProjectHierarchyGuid = Guid.NewGuid();
            fixedProjectDto.IsActive = true;
            milestoneList.Add(fixedProjectDto);
            return milestoneList;
        }
        #endregion
        #region Vehicle
        public static IEnumerable<VehicleDto> PopulateVehicleData()
        {
            List<VehicleDto> platformList = new List<VehicleDto>();
            for (int i = 0; i < 5; i++)
            {
                VehicleDto platform = new VehicleDto();
                platform.Id = Guid.NewGuid();
                platform.VehicleName = $"TestVehicleName{i}";
                platform.ProjectReference = $"TestProjectReference{i}";
                platform.VehicleDisplay = $"TestVehicleDisplay{i}";
                platform.IsActive = true;
                platformList.Add(platform);
            }

            VehicleDto fixedPlatformDto = new VehicleDto();
            fixedPlatformDto.Id = Guid.Parse("766612a1-5c65-4d17-950d-2841e1888f0b");
            fixedPlatformDto.VehicleName = "TestVehicleName";
            fixedPlatformDto.ProjectReference = "TestProjectReference";
            fixedPlatformDto.VehicleDisplay = "TestVehicleDisplay";
            fixedPlatformDto.IsActive = true;
            platformList.Add(fixedPlatformDto);
            return platformList;
        }
        #endregion
    }
}
