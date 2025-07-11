
using System;

namespace SFS.Extensions
{
    public static class SFSMappingExtentions
    {
        #region CalculationTyope

        public static CalculationTypeViewGrpc MapToCalculationTypeGrpc(this DbCalculationType entity)
        {
            CalculationTypeViewGrpc data = new CalculationTypeViewGrpc();
            data.Id = entity.Id;
            data.DisplayMember = entity.DisplayMember;
            return data;
        }

        #endregion

        #region CarModel
        public static CarModelViewGrpc MapToCarModelGrpc(this DbCarModel entity)
        {
            CarModelViewGrpc data = new CarModelViewGrpc();
            data.Id = entity.Id ?? 0;
            data.ModelCode = entity.ModelCode;
            data.ModelName = entity.ModelName;
            data.VehicleName = entity.VehicleName;
            data.CustCode = entity.CustCode;
            data.CuWtKg = entity.CuWtKg;
            data.CuBase = entity.CuBase;
            data.Development = entity.Development;
            data.DeliverTo = entity.DeliverTo;
            data.DeliveryPoint = entity.DeliveryPoint;
            data.FinancialYearOffset = entity.FinancialYearOffset;
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            data.Profile = entity.Profile;
            data.H1Id = entity.H1Id.ToString();
            return data;
        }
        #endregion

        #region Customer
        public static CustomerViewGrpc MapToCustomerGrpc(this DbCustomer entity)
        {
            CustomerViewGrpc data = new CustomerViewGrpc();
            data.Id = entity.Id;
            data.Profile = entity.Profile;
            data.CustCode = entity.CustCode;
            data.CustName = entity.CustName;
            data.CustType = entity.CustType;
            data.ApplyCuAdj = entity.ApplyCuAdj;
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            return data;
        }
        #endregion

        #region CutomerNonWorkingDays
        public static CustomerNonWorkingDayViewGrpc MapToCustomerNonWorkingDaysGrpc(this DbCustomerNonWorkingDays entity)
        {
            CustomerNonWorkingDayViewGrpc data = new CustomerNonWorkingDayViewGrpc();
            data.Profile = entity.Profile;
            data.Year = entity.Year;
            data.DelPoint = entity.DelPoint;
            data.NonWorkingDay = entity.NonWorkingDay.ToTimestamp();
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            data.State = entity.State;
            return data;
        }
        #endregion

        #region DailyVolumeData
        public static DailyVolumeDataViewGrpc MapToDailyVolumeDataGrpc(this DbDailyVolumeData entity)
        {
            DailyVolumeDataViewGrpc data = new DailyVolumeDataViewGrpc();
            data.Id = entity.Id;
            data.Profile = entity.Profile;
            data.ModelCode = entity.ModelCode;
            data.Volume = entity.Volume;
            data.VolDate = entity.VolDate.ToTimestamp();
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            return data;
        }
        #endregion

        #region Forecast
        public static ForecastViewGrpc MapToForecastGrpc(this DbForecast entity)
        {
            ForecastViewGrpc data = new ForecastViewGrpc();
            data.Period = entity.Period;
            data.ForecastCopperLevel = entity.ForecastCopperLevel;
            data.ForecastCopperWeight = entity.ForecastCopperWeight;
            data.PriceAdjustment = entity.PriceAdjustment;
            return data;
        }
        #endregion

        #region MonthlyVolumeData
        public static MonthlyVolumeDataViewGrpc MapToMonthlyVolumeDataGrpc(this DbMonthlyVolumeData entity)
        {
            MonthlyVolumeDataViewGrpc data = new MonthlyVolumeDataViewGrpc();
            data.Profile = entity.Profile;
            data.CarModel = entity.CarModel;
            data.Volume = entity.Volume;
            data.Year = entity.Year;
            data.Month = entity.Month;
            return data;
        }
        #endregion

        #region Period
        public static PeriodViewGrpc MapToPeriodGrpc(this DbPeriod entity)
        {
            PeriodViewGrpc data = new PeriodViewGrpc();
            data.Id = entity.Id;
            data.Period = entity.Period;
            data.EffectiveFrom = entity.EffectiveFrom.ToTimestamp();
            data.EffectiveTo = entity.EffectiveTo.ToTimestamp();
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            return data;
        }
        #endregion

        #region Profile
        public static ProfileViewGrpc MapToProfileGrpc(this DbProfile entity)
        {
            ProfileViewGrpc data = new ProfileViewGrpc();
            data.Id = entity.Id;
            data.DisplayMember = entity.DisplayMember;
            return data;
        }
        #endregion

        #region Site
        public static SiteViewGrpc MapToSiteGrpc(this DbSite entity)
        {
            SiteViewGrpc data = new SiteViewGrpc();
            data.Id = entity.Id;
            data.SiteCode = entity.SiteCode;
            data.SiteName = entity.SiteName;
            data.Profile = entity.Profile;
            data.UpdatedDate = entity.UpdatedDate.ToTimestamp();
            data.UpdatedBy = entity.UpdatedBy;
            return data;
        }
        #endregion
    }
}
