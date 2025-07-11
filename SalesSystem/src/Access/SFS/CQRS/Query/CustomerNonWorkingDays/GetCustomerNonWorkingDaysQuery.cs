namespace SFS.CQRS.Query.CustomerNonWorkingDays
{
   public class GetCustomerNonWorkingDaysQuery : IQuery<List<CustomerNonWorkingDayViewGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}

