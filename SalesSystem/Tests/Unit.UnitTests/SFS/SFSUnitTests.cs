using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;

namespace Unit.Tests.SFS
{
    public class SFSGrpcServiceUnitTests
    {
         Mock<ISFSAccessService> _MockSfsAccessService;
         SFSGrpcService _GrpcService;

        [SetUp]
        public void Setup()
        {
            _MockSfsAccessService = new Mock<ISFSAccessService>();
            ILogger<SFSGrpcService> logger = new Mock<ILogger<SFSGrpcService>>().Object;
            _GrpcService = new SFSGrpcService(_MockSfsAccessService.Object, logger);
     
        }
        [Test]
        public async Task GetAllCarModels_ShouldReturnExpectedCarModel()
        {
            // Arrange
            CarModelViewGrpc car = new CarModelViewGrpc();
            car.Id = 1;
            car.ModelCode = "SUZUKI";
            car.ModelName = "SUZUKI";
            car.VehicleName = "Electric-X";

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();
            CarModelListViewGrpc carList = new CarModelListViewGrpc();
            carList.Items.Add(car);

            Expression<Func<ISFSAccessService, Task<CarModelListViewGrpc>>> setupExpression =
                s => s.GetAllCarModel(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CarModelListViewGrpc>> setup =
                _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(carList);

            Empty request = new Empty();
            ServerCallContext context = CreateServerContext(nameof(_GrpcService.GetAllCarModels));

            // Act
            Task<CarModelListViewGrpc> resultTask = _GrpcService.GetAllCarModels(request, context);
            CarModelListViewGrpc result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount = result.Items.Count;
            int expectedCount = 1;
            bool countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            CarModelViewGrpc actualCar = result.Items[0];
            string actualModelCode = actualCar.ModelCode;
            string expectedModelCode = "SUZUKI";
            bool modelCodesAreEqual = actualModelCode == expectedModelCode;
            Assert.That(modelCodesAreEqual, Is.True);
        }
        [Test]
        public async Task SayHello_ShouldReturnExpectedMessage()
        {
            // Arrange
            HelloRequest request = new HelloRequest();
            request.Name = "TestName";
            // Act
            HelloReply result = await _GrpcService.SayHello(request, null!);
            // Assert
            string actualMessage = result.Message;
            string expectedMessage = "Hello TestName";
            bool messagesAreEqual = actualMessage == expectedMessage;
            Assert.That(messagesAreEqual, Is.True);
        }
        [Test]
        public async Task GetAllProfiles_ShouldReturnExpectedProfile()
        {
            // Arrange
            ProfileViewGrpc profile;
            profile = new ProfileViewGrpc();
            profile.Id = 1;
            profile.DisplayMember = "Base";

            ProfileListViewGrpc profileList;
            profileList = new ProfileListViewGrpc();
            profileList.Items.Add(profile);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<ProfileListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllProfiles(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ProfileListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(profileList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllProfiles));

            // Act
            Task<ProfileListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllProfiles(request, context);

            ProfileListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;

            Assert.That(countsAreEqual, Is.True);

            ProfileViewGrpc actualProfile;
            actualProfile = result.Items[0];

            string actualDisplay;
            actualDisplay = actualProfile.DisplayMember;

            string expectedDisplay;
            expectedDisplay = "Base";

            bool displaysAreEqual;
            displaysAreEqual = actualDisplay == expectedDisplay;

            Assert.That(displaysAreEqual, Is.True);
        }
        [Test]
        public async Task GetAllCustomers_ShouldReturnExpectedCustomer()
        {
            // Arrange
            CustomerViewGrpc customer;
            customer = new CustomerViewGrpc();
            customer.Id = 1;
            customer.CustCode = "C123";
            customer.CustName = "SUZUKI";
            customer.Profile = "Base";

            CustomerListViewGrpc customerList;
            customerList = new CustomerListViewGrpc();
            customerList.Items.Add(customer);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<CustomerListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllCustomers(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(customerList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllCustomers));

            // Act
            Task<CustomerListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllCustomers(request, context);

            CustomerListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            CustomerViewGrpc actualCustomer;
            actualCustomer = result.Items[0];

            string actualCustCode;
            actualCustCode = actualCustomer.CustCode;

            string expectedCustCode;
            expectedCustCode = "C123";

            bool custCodesAreEqual;
            custCodesAreEqual = actualCustCode == expectedCustCode;
            Assert.That(custCodesAreEqual, Is.True);
        }

        [Test]
        public async Task GetAllPeriods_ShouldReturnExpectedPeriod()
        {
            // Arrange
            PeriodViewGrpc period;
            period = new PeriodViewGrpc();
            period.Id = 1;
            period.Profile = "Base";
            period.Period = 202401;

            PeriodListViewGrpc periodList;
            periodList = new PeriodListViewGrpc();
            periodList.Items.Add(period);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<PeriodListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllPeriods(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<PeriodListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(periodList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllPeriods));

            // Act
            Task<PeriodListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllPeriods(request, context);

            PeriodListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            PeriodViewGrpc actualPeriod;
            actualPeriod = result.Items[0];

            int actualPeriodValue;
            actualPeriodValue = actualPeriod.Period;

            int expectedPeriodValue;
            expectedPeriodValue = 202401;

            bool periodsAreEqual;
            periodsAreEqual = actualPeriodValue == expectedPeriodValue;
            Assert.That(periodsAreEqual, Is.True);
        }

        [Test]
        public async Task GetAllSites_ShouldReturnExpectedSite()
        {
            // Arrange
            SiteViewGrpc site;
            site = new SiteViewGrpc();
            site.Id = 1;
            site.Profile = "Base";
            site.SiteCode = "S1";
            site.SiteName = "MFZ";

            SiteListViewGrpc siteList;
            siteList = new SiteListViewGrpc();
            siteList.Items.Add(site);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<SiteListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllSites(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<SiteListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(siteList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllSites));

            // Act
            Task<SiteListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllSites(request, context);

            SiteListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            SiteViewGrpc actualSite;
            actualSite = result.Items[0];

            string actualSiteCode;
            actualSiteCode = actualSite.SiteCode;

            string expectedSiteCode;
            expectedSiteCode = "S1";

            bool siteCodesAreEqual;
            siteCodesAreEqual = actualSiteCode == expectedSiteCode;
            Assert.That(siteCodesAreEqual, Is.True);
        }
        [Test]
        public async Task GetAllForecasts_ShouldReturnExpectedForecast()
        {
            // Arrange
            ForecastViewGrpc forecast;
            forecast = new ForecastViewGrpc();
            forecast.Period = 202507;
            forecast.ForecastCopperLevel = 150.0;

            ForecastListViewGrpc forecastList;
            forecastList = new ForecastListViewGrpc();
            forecastList.Items.Add(forecast);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<ForecastListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllForecasts(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ForecastListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(forecastList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllForecasts));

            // Act
            Task<ForecastListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllForecasts(request, context);

            ForecastListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            ForecastViewGrpc actualForecast;
            actualForecast = result.Items[0];

            int actualPeriod;
            actualPeriod = actualForecast.Period;

            int expectedPeriod;
            expectedPeriod = 202507;

            bool periodsAreEqual;
            periodsAreEqual = actualPeriod == expectedPeriod;
            Assert.That(periodsAreEqual, Is.True);

            double actualCopperLevel;
            actualCopperLevel = actualForecast.ForecastCopperLevel;

            double expectedCopperLevel;
            expectedCopperLevel = 150.0;

            bool copperLevelsAreEqual;
            copperLevelsAreEqual = actualCopperLevel == expectedCopperLevel;
            Assert.That(copperLevelsAreEqual, Is.True);
        }

        [Test]
        public async Task GetAllDailyVolumes_ShouldReturnExpectedDailyVolume()
        {
            // Arrange
            DailyVolumeDataViewGrpc daily;
            daily = new DailyVolumeDataViewGrpc();
            daily.Profile = "Base";
            daily.ModelCode = "SUZUKI";
            daily.Volume = 100;

            DailyVolumeDataListViewGrpc dailyList;
            dailyList = new DailyVolumeDataListViewGrpc();
            dailyList.Items.Add(daily);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetAllDailyVolumes(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(dailyList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetAllDailyVolumes));

            // Act
            Task<DailyVolumeDataListViewGrpc> resultTask;
            resultTask = _GrpcService.GetAllDailyVolumes(request, context);

            DailyVolumeDataListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            DailyVolumeDataViewGrpc actualDaily;
            actualDaily = result.Items[0];

            string actualModelCode;
            actualModelCode = actualDaily.ModelCode;

            string expectedModelCode;
            expectedModelCode = "SUZUKI";

            bool modelCodesAreEqual;
            modelCodesAreEqual = actualModelCode == expectedModelCode;
            Assert.That(modelCodesAreEqual, Is.True);

            double actualVolume;
            actualVolume = actualDaily.Volume;

            double expectedVolume;
            expectedVolume = 100;

            bool volumesAreEqual;
            volumesAreEqual = actualVolume == expectedVolume;
            Assert.That(volumesAreEqual, Is.True);
        }

        [Test]
        public async Task GetMonthlyVolumes_ShouldReturnExpectedMonthlyVolume()
        {
            // Arrange
            MonthlyVolumeDataViewGrpc monthly;
            monthly = new MonthlyVolumeDataViewGrpc();
            monthly.Profile = "Base";
            monthly.Year = 2024;
            monthly.Month = 7;
            monthly.Volume = 500;
            monthly.CarModel = "SUZUKI";

            MonthlyVolumeDataListViewGrpc monthlyList;
            monthlyList = new MonthlyVolumeDataListViewGrpc();
            monthlyList.Items.Add(monthly);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetMonthlyVolumes(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(monthlyList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetMonthlyVolumes));

            // Act
            Task<MonthlyVolumeDataListViewGrpc> resultTask;
            resultTask = _GrpcService.GetMonthlyVolumes(request, context);

            MonthlyVolumeDataListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            MonthlyVolumeDataViewGrpc actualMonthly;
            actualMonthly = result.Items[0];

            string actualCarModel;
            actualCarModel = actualMonthly.CarModel;

            string expectedCarModel;
            expectedCarModel = "SUZUKI";

            bool carModelsAreEqual;
            carModelsAreEqual = actualCarModel == expectedCarModel;
            Assert.That(carModelsAreEqual, Is.True);

            int actualMonth;
            actualMonth = actualMonthly.Month;

            int expectedMonth;
            expectedMonth = 7;

            bool monthsAreEqual;
            monthsAreEqual = actualMonth == expectedMonth;
            Assert.That(monthsAreEqual, Is.True);

            double actualVolume;
            actualVolume = actualMonthly.Volume;

            double expectedVolume;
            expectedVolume = 500;

            bool volumesAreEqual;
            volumesAreEqual = actualVolume == expectedVolume;
            Assert.That(volumesAreEqual, Is.True);
        }
        [Test]
        public async Task GetCustomerNonWorkingDay_ShouldReturnExpectedDay()
        {
            // Arrange
            CustomerNonWorkingDayViewGrpc nonWorkingDay;
            nonWorkingDay = new CustomerNonWorkingDayViewGrpc();
            nonWorkingDay.Profile = "Base";
            nonWorkingDay.Year = 2024;
            nonWorkingDay.DelPoint = "Kenitra";
            nonWorkingDay.NonWorkingDay = "2025-07-01";

            CustomerNonWorkingDayListViewGrpc nonWorkingDayList;
            nonWorkingDayList = new CustomerNonWorkingDayListViewGrpc();
            nonWorkingDayList.Items.Add(nonWorkingDay);

            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            Expression<Func<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>>> setupExpression;
            setupExpression = s => s.GetCustomerNonWorkingDay(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>> setup;
            setup = _MockSfsAccessService.Setup(setupExpression);

            setup.ReturnsAsync(nonWorkingDayList);

            Empty request;
            request = new Empty();

            ServerCallContext context;
            context = CreateServerContext(nameof(_GrpcService.GetCustomerNonWorkingDay));

            // Act
            Task<CustomerNonWorkingDayListViewGrpc> resultTask;
            resultTask = _GrpcService.GetCustomerNonWorkingDay(request, context);

            CustomerNonWorkingDayListViewGrpc result;
            result = await resultTask;

            // Assert
            Assert.That(result, Is.Not.Null);

            int actualCount;
            actualCount = result.Items.Count;

            int expectedCount;
            expectedCount = 1;

            bool countsAreEqual;
            countsAreEqual = actualCount == expectedCount;
            Assert.That(countsAreEqual, Is.True);

            CustomerNonWorkingDayViewGrpc actualDay;
            actualDay = result.Items[0];

            string actualDelPoint;
            actualDelPoint = actualDay.DelPoint;

            string expectedDelPoint;
            expectedDelPoint = "Kenitra";

            bool delPointsAreEqual;
            delPointsAreEqual = actualDelPoint == expectedDelPoint;
            Assert.That(delPointsAreEqual, Is.True);

            string actualNonWorkingDay;
            actualNonWorkingDay = actualDay.NonWorkingDay;

            string expectedNonWorkingDay;
            expectedNonWorkingDay = "2025-07-01";

            bool nonWorkingDaysAreEqual;
            nonWorkingDaysAreEqual = actualNonWorkingDay == expectedNonWorkingDay;
            Assert.That(nonWorkingDaysAreEqual, Is.True);
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
