namespace SEWSE.H1.UX.Infrastructure.Core.Models
{
    public class PostponeTime
    {
        public int TimeInhours { get; set; }
        public string DisplayTime { get; set; }

        public PostponeTime(int timeInHours, string displayTime)
        {
            this.TimeInhours = timeInHours;
            this.DisplayTime = displayTime;
        }
    }
}