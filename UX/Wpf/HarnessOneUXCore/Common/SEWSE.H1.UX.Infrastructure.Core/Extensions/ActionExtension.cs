using System;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Extensions
{
    public static class ActionExtension
    {
        /// <summary>
		/// This extension is used to call this Action again after some delay.
		/// </summary>
		/// <param name="act">Action</param>
		/// <param name="delay">Timespan</param>
		public static async void DelayFor(this Action act, TimeSpan delay)
        {
            await Task.Delay(delay);
            act();
        }
    }
}
