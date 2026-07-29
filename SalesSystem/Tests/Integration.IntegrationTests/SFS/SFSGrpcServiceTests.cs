using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;
namespace Integration.Tests.SFS
{
    public class SFSGrpcServiceTests
    {
         Mock<ISFSAccessService> _MockSfsAccessService;
         SFSGrpcService _GrpcService; 
        [SetUp]
        public void Setup()
        {
            _MockSfsAccessService = new Mock<ISFSAccessService>();
            ILogger<SFSGrpcService> logger = new Mock<ILogger<SFSGrpcService>>().Object;
            // Pass the mock object to the GrpcService
            _GrpcService = new SFSGrpcService(_MockSfsAccessService.Object, logger);

            // CarModel
            CarModelViewGrpc car = new CarModelViewGrpc();
            car.Id = 1;
            car.ModelCode = "SUZUKI";
            car.ModelName = "SUZUKI";
            car.VehicleName = "Electric-X";
            car.CustCode = "C123";
            car.CuWtKg = 1200.5;
            car.CuBase = 1000.0;
            car.Development = "Dev Phase";
            car.DeliverTo = "Kenitra";
            car.DeliveryPoint = "Kenitra";
            car.FinancialYearOffset = "4";
            car.UpdatedBy = "Abdoo";
            car.Profile = "Base";
            car.H1Id = "H1X";
            CarModelListViewGrpc carModelList = new CarModelListViewGrpc();
            carModelList.Items.Add(car);
            CancellationToken cancellationToken = It.Is<CancellationToken>(c => true);
            Expression<Func<ISFSAccessService, Task<CarModelListViewGrpc>>> carModelExpression =
           s => s.GetAllCarModel(cancellationToken); 
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CarModelListViewGrpc>> carModelSetup = _MockSfsAccessService.Setup(carModelExpression);
            carModelSetup.ReturnsAsync(carModelList);

            // Profile
            ProfileViewGrpc profile = new ProfileViewGrpc();
            profile.Id = 1;
            profile.DisplayMember = "Base";
            ProfileListViewGrpc profileList = new ProfileListViewGrpc();
            profileList.Items.Add(profile);
            Expression<Func<ISFSAccessService, Task<ProfileListViewGrpc>>> profileExpression =
                s => s.GetAllProfiles(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ProfileListViewGrpc>> profileSetup = _MockSfsAccessService.Setup(profileExpression);
            profileSetup.ReturnsAsync(profileList);

            // CalculationType
            CalculationTypeViewGrpc type = new CalculationTypeViewGrpc();
            type.Id = "First";
            type.DisplayMember = "First";
            CalculationTypeListViewGrpc typeList = new CalculationTypeListViewGrpc();
            typeList.Items.Add(type);
            Expression<Func<ISFSAccessService, Task<CalculationTypeListViewGrpc>>> calculationTypeExpression =
                s => s.GetAllCalculationTypes(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CalculationTypeListViewGrpc>> calculationTypeSetup = _MockSfsAccessService.Setup(calculationTypeExpression);
            calculationTypeSetup.ReturnsAsync(typeList);

            // DailyVolume
            DailyVolumeDataViewGrpc daily = new DailyVolumeDataViewGrpc();
            daily.Profile = "Base";
            daily.Volume = 100;
            daily.ModelCode = "SUZUKI";
            DailyVolumeDataListViewGrpc dailyList = new DailyVolumeDataListViewGrpc();
            dailyList.Items.Add(daily);
            Expression<Func<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>>> dailyVolumeExpression =
                s => s.GetAllDailyVolumes(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>> dailyVolumeSetup = _MockSfsAccessService.Setup(dailyVolumeExpression);
            dailyVolumeSetup.ReturnsAsync(dailyList);

            // Period
            PeriodViewGrpc period = new PeriodViewGrpc();
            period.Id = 1;
            period.Profile = "Base";
            period.Period = 202401;
            PeriodListViewGrpc periodList = new PeriodListViewGrpc();
            periodList.Items.Add(period);
            Expression<Func<ISFSAccessService, Task<PeriodListViewGrpc>>> periodExpression =
                s => s.GetAllPeriods(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<PeriodListViewGrpc>> periodSetup = _MockSfsAccessService.Setup(periodExpression);
            periodSetup.ReturnsAsync(periodList);

            // Customer
            CustomerViewGrpc customer = new CustomerViewGrpc();
            customer.Id = 1;
            customer.CustCode = "C123";
            customer.CustName = "SUZUKI";
            customer.Profile = "Base";
            CustomerListViewGrpc customerList = new CustomerListViewGrpc();
            customerList.Items.Add(customer);
            Expression<Func<ISFSAccessService, Task<CustomerListViewGrpc>>> customerExpression =
                s => s.GetAllCustomers(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerListViewGrpc>> customerSetup = _MockSfsAccessService.Setup(customerExpression);
            customerSetup.ReturnsAsync(customerList);

            // Site
            SiteViewGrpc site = new SiteViewGrpc();
            site.Id = 1;
            site.Profile = "Base";
            site.SiteCode = "S1";
            site.SiteName = "MFZ";
            SiteListViewGrpc siteList = new SiteListViewGrpc();
            siteList.Items.Add(site);
            Expression<Func<ISFSAccessService, Task<SiteListViewGrpc>>> siteExpression =
                s => s.GetAllSites(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<SiteListViewGrpc>> siteSetup = _MockSfsAccessService.Setup(siteExpression);
            siteSetup.ReturnsAsync(siteList);

            // Forecast
            ForecastViewGrpc forecast = new ForecastViewGrpc();
            forecast.Period = 202507;
            forecast.ForecastCopperLevel = 150.0;
            ForecastListViewGrpc forecastList = new ForecastListViewGrpc();
            forecastList.Items.Add(forecast);
            Expression<Func<ISFSAccessService, Task<ForecastListViewGrpc>>> forecastExpression =
                s => s.GetAllForecasts(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ForecastListViewGrpc>> forecastSetup = _MockSfsAccessService.Setup(forecastExpression);
            forecastSetup.ReturnsAsync(forecastList);

            // MonthlyVolume
            MonthlyVolumeDataViewGrpc monthly = new MonthlyVolumeDataViewGrpc();
            monthly.Profile = "Base";
            monthly.Year = 2024;
            monthly.Month = 7;
            monthly.Volume = 500;
            monthly.CarModel = "SUZUKI";
            MonthlyVolumeDataListViewGrpc monthlyList = new MonthlyVolumeDataListViewGrpc();
            monthlyList.Items.Add(monthly);
            Expression<Func<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>>> monthlyVolumeExpression =
                s => s.GetMonthlyVolumes(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>> monthlyVolumeSetup = _MockSfsAccessService.Setup(monthlyVolumeExpression);
            monthlyVolumeSetup.ReturnsAsync(monthlyList);

            // CustomerNonWorkingDay
            CustomerNonWorkingDayViewGrpc nonWorkingDay = new CustomerNonWorkingDayViewGrpc();
            nonWorkingDay.Profile = "Base";
            nonWorkingDay.Year = 2024;
            nonWorkingDay.DelPoint = "Kenitra";
            nonWorkingDay.NonWorkingDay = "2025-07-01";
            CustomerNonWorkingDayListViewGrpc nonWorkingDayList = new CustomerNonWorkingDayListViewGrpc();
            nonWorkingDayList.Items.Add(nonWorkingDay);
            Expression<Func<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>>> customerNonWorkingDayExpression =
                s => s.GetCustomerNonWorkingDay(cancellationToken);
            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>> customerNonWorkingDaySetup = _MockSfsAccessService.Setup(customerNonWorkingDayExpression);
            customerNonWorkingDaySetup.ReturnsAsync(nonWorkingDayList);
        }

        [Test]
        [Category("Integration")]
        public void SayHelloTest()
        {
            CommonTypes.HelloRequest request = new CommonTypes.HelloRequest();
            request.Name = "TestName";
            ServerCallContext serverCallContext = CreateServerContext(nameof(_GrpcService.SayHello));

            Task<CommonTypes.HelloReply> helloReply = _GrpcService.SayHello(request, serverCallContext);
            string replyString = "Hello TestName";
            EqualConstraint equalConstraint = Is.EqualTo(replyString);
            Assert.That(helloReply, Is.Not.Null);
            Assert.That(helloReply.Result.Message, equalConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllCarModelsTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllCarModels);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();
            Task<CarModelListViewGrpc> resultTask = _GrpcService.GetAllCarModels(request, serverCallContext);
            CarModelListViewGrpc result = resultTask.Result;

            Assert.That(result, Is.Not.Null);

            int carModelCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(carModelCount, countConstraint);
            CarModelViewGrpc carModel = result.Items[0];

            string expectedModelCode = "SUZUKI";
            string expectedModelName = "SUZUKI";
            string expectedVehicleName = "Electric-X";

            NUnit.Framework.Constraints.EqualConstraint modelCodeConstraint = Is.EqualTo(expectedModelCode);
            NUnit.Framework.Constraints.EqualConstraint modelNameConstraint = Is.EqualTo(expectedModelName);
            NUnit.Framework.Constraints.EqualConstraint vehicleNameConstraint = Is.EqualTo(expectedVehicleName);

            Assert.That(carModel.ModelCode, modelCodeConstraint);
            Assert.That(carModel.ModelName, modelNameConstraint);
            Assert.That(carModel.VehicleName, vehicleNameConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllProfilesTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllProfiles);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();
            Task<ProfileListViewGrpc> resultTask = _GrpcService.GetAllProfiles(request, serverCallContext);

            ProfileListViewGrpc result = resultTask.Result;

            Assert.That(result, Is.Not.Null);
            int profileCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(profileCount, countConstraint);
            ProfileViewGrpc profile = result.Items[0];
            string expectedDisplay = "Base";

            NUnit.Framework.Constraints.EqualConstraint displayConstraint = Is.EqualTo(expectedDisplay);

            Assert.That(profile.DisplayMember, displayConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllCalculationTypesTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllCalculationTypes);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();
            Task<CalculationTypeListViewGrpc> resultTask = _GrpcService.GetAllCalculationTypes(request, serverCallContext);
            CalculationTypeListViewGrpc result = resultTask.Result;
            Assert.That(result, Is.Not.Null);
            int calculationCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(calculationCount, countConstraint);
            CalculationTypeViewGrpc calculation = result.Items[0];
            string expectedId = "First";
            string expectedDisplay = "First";
            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(expectedId);
            NUnit.Framework.Constraints.EqualConstraint displayConstraint = Is.EqualTo(expectedDisplay);
            Assert.That(calculation.Id, idConstraint);
            Assert.That(calculation.DisplayMember, displayConstraint);
        }
        [Test]
        [Category("Integration")]
        public void GetAllCustomersTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllCustomers);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();

            // Act
            Task<CustomerListViewGrpc> resultTask = _GrpcService.GetAllCustomers(request, serverCallContext);
            CustomerListViewGrpc result = resultTask.Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int customerCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(customerCount, countConstraint);

            CustomerViewGrpc customer = result.Items[0];

            string expectedCustCode = "C123";
            string expectedCustName = "SUZUKI";
            string expectedProfile = "Base";

            NUnit.Framework.Constraints.EqualConstraint custCodeConstraint = Is.EqualTo(expectedCustCode);
            NUnit.Framework.Constraints.EqualConstraint custNameConstraint = Is.EqualTo(expectedCustName);
            NUnit.Framework.Constraints.EqualConstraint profileConstraint = Is.EqualTo(expectedProfile);

            Assert.That(customer.CustCode, custCodeConstraint);
            Assert.That(customer.CustName, custNameConstraint);
            Assert.That(customer.Profile, profileConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllPeriodsTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllPeriods);
            ServerCallContext serverCallContext = CreateServerContext(methodName);
            Empty request = new Empty();

            // Act
            Task<PeriodListViewGrpc> resultTask = _GrpcService.GetAllPeriods(request, serverCallContext);
            PeriodListViewGrpc result = resultTask.Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int periodCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(periodCount, countConstraint);

            PeriodViewGrpc period = result.Items[0];

            int expectedId = 1;
            int expectedPeriodValue = 202401;
            string expectedProfile = "Base";

            NUnit.Framework.Constraints.EqualConstraint idConstraint = Is.EqualTo(expectedId);
            NUnit.Framework.Constraints.EqualConstraint periodValueConstraint = Is.EqualTo(expectedPeriodValue);
            NUnit.Framework.Constraints.EqualConstraint profileConstraint = Is.EqualTo(expectedProfile);

            Assert.That(period.Id, idConstraint);
            Assert.That(period.Period, periodValueConstraint);
            Assert.That(period.Profile, profileConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllCustomerNonWorkingDaysTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetCustomerNonWorkingDay);
            ServerCallContext context = CreateServerContext(methodName);
            Empty request = new();

            // Act
            CustomerNonWorkingDayListViewGrpc result = _GrpcService.GetCustomerNonWorkingDay(request, context).Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int itemCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(itemCount, countConstraint);

            CustomerNonWorkingDayViewGrpc item = result.Items[0];

            string expectedDelPoint = "Kenitra";
            string expectedNonWorkingDay = "2025-07-01";

            NUnit.Framework.Constraints.EqualConstraint delPointConstraint = Is.EqualTo(expectedDelPoint);
            NUnit.Framework.Constraints.EqualConstraint nonWorkingDayConstraint = Is.EqualTo(expectedNonWorkingDay);

            Assert.That(item.DelPoint, delPointConstraint);
            Assert.That(item.NonWorkingDay, nonWorkingDayConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllMonthlyVolumesTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetMonthlyVolumes);
            ServerCallContext context = CreateServerContext(methodName);
            Empty request = new();

            // Act
            MonthlyVolumeDataListViewGrpc result = _GrpcService.GetMonthlyVolumes(request, context).Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int itemCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(itemCount, countConstraint);

            MonthlyVolumeDataViewGrpc item = result.Items[0];

            string expectedCarModel = "SUZUKI";
            int expectedMonth = 7;
            double expectedVolume = 500;

            NUnit.Framework.Constraints.EqualConstraint carModelConstraint = Is.EqualTo(expectedCarModel);
            NUnit.Framework.Constraints.EqualConstraint monthConstraint = Is.EqualTo(expectedMonth);
            NUnit.Framework.Constraints.EqualConstraint volumeConstraint = Is.EqualTo(expectedVolume);

            Assert.That(item.CarModel, carModelConstraint);
            Assert.That(item.Month, monthConstraint);
            Assert.That(item.Volume, volumeConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllDailyVolumesTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllDailyVolumes);
            ServerCallContext context = CreateServerContext(methodName);
            Empty request = new();

            // Act
            DailyVolumeDataListViewGrpc result = _GrpcService.GetAllDailyVolumes(request, context).Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int itemCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(itemCount, countConstraint);

            DailyVolumeDataViewGrpc item = result.Items[0];

            string expectedModelCode = "SUZUKI";
            double expectedVolume = 100;

            NUnit.Framework.Constraints.EqualConstraint modelCodeConstraint = Is.EqualTo(expectedModelCode);
            NUnit.Framework.Constraints.EqualConstraint volumeConstraint = Is.EqualTo(expectedVolume);

            Assert.That(item.ModelCode, modelCodeConstraint);
            Assert.That(item.Volume, volumeConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllForecastsTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllForecasts);
            ServerCallContext context = CreateServerContext(methodName);
            Empty request = new();

            // Act
            ForecastListViewGrpc result = _GrpcService.GetAllForecasts(request, context).Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int itemCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(itemCount, countConstraint);

            ForecastViewGrpc item = result.Items[0];

            int expectedPeriod = 202507;
            double expectedForecastCopperLevel = 150.0;

            NUnit.Framework.Constraints.EqualConstraint periodConstraint = Is.EqualTo(expectedPeriod);
            NUnit.Framework.Constraints.EqualConstraint forecastCopperLevelConstraint = Is.EqualTo(expectedForecastCopperLevel);

            Assert.That(item.Period, periodConstraint);
            Assert.That(item.ForecastCopperLevel, forecastCopperLevelConstraint);
        }

        [Test]
        [Category("Integration")]
        public void GetAllSitesTest()
        {
            // Arrange
            string methodName = nameof(_GrpcService.GetAllSites);
            ServerCallContext context = CreateServerContext(methodName);
            Empty request = new();

            // Act
            SiteListViewGrpc result = _GrpcService.GetAllSites(request, context).Result;

            // Assert
            Assert.That(result, Is.Not.Null);

            int itemCount = result.Items.Count;
            int expectedCount = 1;
            NUnit.Framework.Constraints.EqualConstraint countConstraint = Is.EqualTo(expectedCount);
            Assert.That(itemCount, countConstraint);

            SiteViewGrpc item = result.Items[0];

            string expectedSiteCode = "S1";
            string expectedSiteName = "MFZ";

            NUnit.Framework.Constraints.EqualConstraint siteCodeConstraint = Is.EqualTo(expectedSiteCode);
            NUnit.Framework.Constraints.EqualConstraint siteNameConstraint = Is.EqualTo(expectedSiteName);

            Assert.That(item.SiteCode, siteCodeConstraint);
            Assert.That(item.SiteName, siteNameConstraint);
        }

        ServerCallContext CreateServerContext(string methodName)
        {
            DateTime deadline = DateTime.Now.AddMinutes(30);
            Metadata metadata = new Metadata();
            ServerCallContext serverCallContext = TestServerCallContext.Create(
                                                    method: methodName
                                                  , host: "localhost"
                                                  , deadline: deadline
                                                  , requestHeaders: metadata
                                                  , cancellationToken: CancellationToken.None
                                                  , peer: "10.0.0.25:5001"
                                                  , authContext: null
                                                  , contextPropagationToken: null
                                                  , writeHeadersFunc: (metadata) => Task.CompletedTask
                                                  , writeOptionsGetter: () => new WriteOptions()
                                                  , writeOptionsSetter: (writeOptions) => { }
                                                  );
            return serverCallContext;
        }
    }
}