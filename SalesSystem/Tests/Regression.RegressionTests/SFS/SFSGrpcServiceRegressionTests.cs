using System.Linq.Expressions;
using Google.Protobuf.WellKnownTypes;
using SFS;
using SFS.Endpoints.GrpcServices;
using SFS.Services;
namespace Regression.Tests.SFS
{
    public class SFSGrpcServiceRegressionTests
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
        public async Task RegressionTest_AllEndpoints_ShouldReturnExpectedResults()
        {
            CancellationToken anyToken;
            anyToken = It.IsAny<CancellationToken>();

            // --- SayHello ---
            CommonTypes.HelloRequest helloRequest;
            helloRequest = new CommonTypes.HelloRequest();
            helloRequest.Name = "TestName";

            Task<CommonTypes.HelloReply> helloTask;
            helloTask = _GrpcService.SayHello(helloRequest, null!);

            CommonTypes.HelloReply helloResult;
            helloResult = await helloTask;

            string actualHello;
            actualHello = helloResult.Message;

            string expectedHello;
            expectedHello = "Hello TestName";

            bool helloEqual;
            helloEqual = actualHello == expectedHello;
            Assert.That(helloEqual, Is.True);

            // --- GetAllCarModels ---
            CarModelViewGrpc car;
            car = new CarModelViewGrpc();
            car.Id = 1;
            car.ModelCode = "SUZUKI";
            car.ModelName = "SUZUKI";
            car.VehicleName = "Electric-X";

            CarModelListViewGrpc carList;
            carList = new CarModelListViewGrpc();
            carList.Items.Add(car);

            Expression<Func<ISFSAccessService, Task<CarModelListViewGrpc>>> carSetupExpression;
            carSetupExpression = s => s.GetAllCarModel(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CarModelListViewGrpc>> carSetup;
            carSetup = _MockSfsAccessService.Setup(carSetupExpression);
            carSetup.ReturnsAsync(carList);

            Empty carRequest;
            carRequest = new Empty();

            ServerCallContext carContext;
            carContext = CreateServerContext(nameof(_GrpcService.GetAllCarModels));

            Task<CarModelListViewGrpc> carTask;
            carTask = _GrpcService.GetAllCarModels(carRequest, carContext);

            CarModelListViewGrpc carResult;
            carResult = await carTask;

            Assert.That(carResult.Items[0].ModelCode == "SUZUKI", Is.True);

            // --- GetAllProfiles ---
            ProfileViewGrpc profile;
            profile = new ProfileViewGrpc();
            profile.Id = 1;
            profile.DisplayMember = "Base";

            ProfileListViewGrpc profileList;
            profileList = new ProfileListViewGrpc();
            profileList.Items.Add(profile);

            Expression<Func<ISFSAccessService, Task<ProfileListViewGrpc>>> profileSetupExpression;
            profileSetupExpression = s => s.GetAllProfiles(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ProfileListViewGrpc>> profileSetup;
            profileSetup = _MockSfsAccessService.Setup(profileSetupExpression);
            profileSetup.ReturnsAsync(profileList);

            Empty profileRequest;
            profileRequest = new Empty();

            ServerCallContext profileContext;
            profileContext = CreateServerContext(nameof(_GrpcService.GetAllProfiles));

            Task<ProfileListViewGrpc> profileTask;
            profileTask = _GrpcService.GetAllProfiles(profileRequest, profileContext);

            ProfileListViewGrpc profileResult;
            profileResult = await profileTask;

            Assert.That(profileResult.Items[0].DisplayMember == "Base", Is.True);

            // --- GetAllCustomers ---
            CustomerViewGrpc customer;
            customer = new CustomerViewGrpc();
            customer.Id = 1;
            customer.CustCode = "C123";
            customer.CustName = "SUZUKI";
            customer.Profile = "Base";

            CustomerListViewGrpc customerList;
            customerList = new CustomerListViewGrpc();
            customerList.Items.Add(customer);

            Expression<Func<ISFSAccessService, Task<CustomerListViewGrpc>>> customerSetupExpression;
            customerSetupExpression = s => s.GetAllCustomers(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerListViewGrpc>> customerSetup;
            customerSetup = _MockSfsAccessService.Setup(customerSetupExpression);
            customerSetup.ReturnsAsync(customerList);

            Empty customerRequest;
            customerRequest = new Empty();

            ServerCallContext customerContext;
            customerContext = CreateServerContext(nameof(_GrpcService.GetAllCustomers));

            Task<CustomerListViewGrpc> customerTask;
            customerTask = _GrpcService.GetAllCustomers(customerRequest, customerContext);

            CustomerListViewGrpc customerResult;
            customerResult = await customerTask;

            Assert.That(customerResult.Items[0].CustCode == "C123", Is.True);

            // --- GetAllPeriods ---
            PeriodViewGrpc period;
            period = new PeriodViewGrpc();
            period.Id = 1;
            period.Profile = "Base";
            period.Period = 202401;

            PeriodListViewGrpc periodList;
            periodList = new PeriodListViewGrpc();
            periodList.Items.Add(period);

            Expression<Func<ISFSAccessService, Task<PeriodListViewGrpc>>> periodSetupExpression;
            periodSetupExpression = s => s.GetAllPeriods(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<PeriodListViewGrpc>> periodSetup;
            periodSetup = _MockSfsAccessService.Setup(periodSetupExpression);
            periodSetup.ReturnsAsync(periodList);

            Empty periodRequest;
            periodRequest = new Empty();

            ServerCallContext periodContext;
            periodContext = CreateServerContext(nameof(_GrpcService.GetAllPeriods));

            Task<PeriodListViewGrpc> periodTask;
            periodTask = _GrpcService.GetAllPeriods(periodRequest, periodContext);

            PeriodListViewGrpc periodResult;
            periodResult = await periodTask;

            Assert.That(periodResult.Items[0].Period == 202401, Is.True);

            // --- GetAllSites ---
            SiteViewGrpc site;
            site = new SiteViewGrpc();
            site.Id = 1;
            site.Profile = "Base";
            site.SiteCode = "S1";
            site.SiteName = "MFZ";

            SiteListViewGrpc siteList;
            siteList = new SiteListViewGrpc();
            siteList.Items.Add(site);

            Expression<Func<ISFSAccessService, Task<SiteListViewGrpc>>> siteSetupExpression;
            siteSetupExpression = s => s.GetAllSites(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<SiteListViewGrpc>> siteSetup;
            siteSetup = _MockSfsAccessService.Setup(siteSetupExpression);
            siteSetup.ReturnsAsync(siteList);

            Empty siteRequest;
            siteRequest = new Empty();

            ServerCallContext siteContext;
            siteContext = CreateServerContext(nameof(_GrpcService.GetAllSites));

            Task<SiteListViewGrpc> siteTask;
            siteTask = _GrpcService.GetAllSites(siteRequest, siteContext);

            SiteListViewGrpc siteResult;
            siteResult = await siteTask;

            Assert.That(siteResult.Items[0].SiteCode == "S1", Is.True);

            // --- GetAllForecasts ---
            ForecastViewGrpc forecast;
            forecast = new ForecastViewGrpc();
            forecast.Period = 202507;
            forecast.ForecastCopperLevel = 150.0;

            ForecastListViewGrpc forecastList;
            forecastList = new ForecastListViewGrpc();
            forecastList.Items.Add(forecast);

            Expression<Func<ISFSAccessService, Task<ForecastListViewGrpc>>> forecastSetupExpression;
            forecastSetupExpression = s => s.GetAllForecasts(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<ForecastListViewGrpc>> forecastSetup;
            forecastSetup = _MockSfsAccessService.Setup(forecastSetupExpression);
            forecastSetup.ReturnsAsync(forecastList);

            Empty forecastRequest;
            forecastRequest = new Empty();

            ServerCallContext forecastContext;
            forecastContext = CreateServerContext(nameof(_GrpcService.GetAllForecasts));

            Task<ForecastListViewGrpc> forecastTask;
            forecastTask = _GrpcService.GetAllForecasts(forecastRequest, forecastContext);

            ForecastListViewGrpc forecastResult;
            forecastResult = await forecastTask;

            Assert.That(forecastResult.Items[0].Period == 202507, Is.True);
            // --- GetAllDailyVolumes ---
            DailyVolumeDataViewGrpc daily;
            daily = new DailyVolumeDataViewGrpc();
            daily.Profile = "Base";
            daily.ModelCode = "SUZUKI";
            daily.Volume = 100;

            DailyVolumeDataListViewGrpc dailyList;
            dailyList = new DailyVolumeDataListViewGrpc();
            dailyList.Items.Add(daily);

            Expression<Func<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>>> dailySetupExpression;
            dailySetupExpression = s => s.GetAllDailyVolumes(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<DailyVolumeDataListViewGrpc>> dailySetup;
            dailySetup = _MockSfsAccessService.Setup(dailySetupExpression);
            dailySetup.ReturnsAsync(dailyList);
            dailySetup.ReturnsAsync(dailyList);

            Empty dailyRequest;
            dailyRequest = new Empty();

            ServerCallContext dailyContext;
            dailyContext = CreateServerContext(nameof(_GrpcService.GetAllDailyVolumes));

            Task<DailyVolumeDataListViewGrpc> dailyTask;
            dailyTask = _GrpcService.GetAllDailyVolumes(dailyRequest, dailyContext);

            DailyVolumeDataListViewGrpc dailyResult;
            dailyResult = await dailyTask;

            // Assert
            Assert.That(dailyResult, Is.Not.Null);

            int actualDailyCount;
            actualDailyCount = dailyResult.Items.Count;

            int expectedDailyCount;
            expectedDailyCount = 1;

            bool dailyCountsAreEqual;
            dailyCountsAreEqual = actualDailyCount == expectedDailyCount;
            Assert.That(dailyCountsAreEqual, Is.True);

            DailyVolumeDataViewGrpc actualDaily;
            actualDaily = dailyResult.Items[0];

            string actualDailyModelCode;
            actualDailyModelCode = actualDaily.ModelCode;

            string expectedDailyModelCode;
            expectedDailyModelCode = "SUZUKI";

            bool dailyModelCodesAreEqual;
            dailyModelCodesAreEqual = actualDailyModelCode == expectedDailyModelCode;
            Assert.That(dailyModelCodesAreEqual, Is.True);

            double actualDailyVolume;
            actualDailyVolume = actualDaily.Volume;

            double expectedDailyVolume;
            expectedDailyVolume = 100;

            bool dailyVolumesAreEqual;
            dailyVolumesAreEqual = actualDailyVolume == expectedDailyVolume;
            Assert.That(dailyVolumesAreEqual, Is.True);

            // --- GetMonthlyVolumes ---
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

            Expression<Func<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>>> monthlySetupExpression;
            monthlySetupExpression = s => s.GetMonthlyVolumes(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<MonthlyVolumeDataListViewGrpc>> monthlySetup;
            monthlySetup = _MockSfsAccessService.Setup(monthlySetupExpression);
            monthlySetup.ReturnsAsync(monthlyList);

            Empty monthlyRequest;
            monthlyRequest = new Empty();

            ServerCallContext monthlyContext;
            monthlyContext = CreateServerContext(nameof(_GrpcService.GetMonthlyVolumes));

            Task<MonthlyVolumeDataListViewGrpc> monthlyTask;
            monthlyTask = _GrpcService.GetMonthlyVolumes(monthlyRequest, monthlyContext);

            MonthlyVolumeDataListViewGrpc monthlyResult;
            monthlyResult = await monthlyTask;

            // Assert
            Assert.That(monthlyResult, Is.Not.Null);

            int actualMonthlyCount;
            actualMonthlyCount = monthlyResult.Items.Count;

            int expectedMonthlyCount;
            expectedMonthlyCount = 1;

            bool monthlyCountsAreEqual;
            monthlyCountsAreEqual = actualMonthlyCount == expectedMonthlyCount;
            Assert.That(monthlyCountsAreEqual, Is.True);

            MonthlyVolumeDataViewGrpc actualMonthly;
            actualMonthly = monthlyResult.Items[0];

            string actualMonthlyCarModel;
            actualMonthlyCarModel = actualMonthly.CarModel;

            string expectedMonthlyCarModel;
            expectedMonthlyCarModel = "SUZUKI";

            bool monthlyCarModelsAreEqual;
            monthlyCarModelsAreEqual = actualMonthlyCarModel == expectedMonthlyCarModel;
            Assert.That(monthlyCarModelsAreEqual, Is.True);

            int actualMonth;
            actualMonth = actualMonthly.Month;

            int expectedMonth;
            expectedMonth = 7;

            bool monthsAreEqual;
            monthsAreEqual = actualMonth == expectedMonth;
            Assert.That(monthsAreEqual, Is.True);

            double actualMonthlyVolume;
            actualMonthlyVolume = actualMonthly.Volume;

            double expectedMonthlyVolume;
            expectedMonthlyVolume = 500;

            bool monthlyVolumesAreEqual;
            monthlyVolumesAreEqual = actualMonthlyVolume == expectedMonthlyVolume;
            Assert.That(monthlyVolumesAreEqual, Is.True);

            // --- GetCustomerNonWorkingDay ---
            CustomerNonWorkingDayViewGrpc nonWorkingDay;
            nonWorkingDay = new CustomerNonWorkingDayViewGrpc();
            nonWorkingDay.Profile = "Base";
            nonWorkingDay.Year = 2024;
            nonWorkingDay.DelPoint = "Kenitra";
            nonWorkingDay.NonWorkingDay = "2025-07-01";

            CustomerNonWorkingDayListViewGrpc nonWorkingDayList;
            nonWorkingDayList = new CustomerNonWorkingDayListViewGrpc();
            nonWorkingDayList.Items.Add(nonWorkingDay);

            Expression<Func<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>>> nonWorkingDaySetupExpression;
            nonWorkingDaySetupExpression = s => s.GetCustomerNonWorkingDay(anyToken);

            Moq.Language.Flow.ISetup<ISFSAccessService, Task<CustomerNonWorkingDayListViewGrpc>> nonWorkingDaySetup;
            nonWorkingDaySetup = _MockSfsAccessService.Setup(nonWorkingDaySetupExpression);
            nonWorkingDaySetup.ReturnsAsync(nonWorkingDayList);

            Empty nonWorkingDayRequest;
            nonWorkingDayRequest = new Empty();

            ServerCallContext nonWorkingDayContext;
            nonWorkingDayContext = CreateServerContext(nameof(_GrpcService.GetCustomerNonWorkingDay));

            Task<CustomerNonWorkingDayListViewGrpc> nonWorkingDayTask;
            nonWorkingDayTask = _GrpcService.GetCustomerNonWorkingDay(nonWorkingDayRequest, nonWorkingDayContext);

            CustomerNonWorkingDayListViewGrpc nonWorkingDayResult;
            nonWorkingDayResult = await nonWorkingDayTask;

            // Assert
            Assert.That(nonWorkingDayResult, Is.Not.Null);

            int actualNonWorkingDayCount;
            actualNonWorkingDayCount = nonWorkingDayResult.Items.Count;

            int expectedNonWorkingDayCount;
            expectedNonWorkingDayCount = 1;

            bool nonWorkingDayCountsAreEqual;
            nonWorkingDayCountsAreEqual = actualNonWorkingDayCount == expectedNonWorkingDayCount;
            Assert.That(nonWorkingDayCountsAreEqual, Is.True);

            CustomerNonWorkingDayViewGrpc actualDay;
            actualDay = nonWorkingDayResult.Items[0];

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

