using SalesSystem.Rfq.Models;
using System.Collections.Generic;

namespace SalesSystem.Rfq.Services
{
    public class RfqUxService
    {
        // Data and Grpc Tasks
        public async Task<List<RfqItemUx>> GetCustomersAsync()
        {
            await Task.Delay(0);
            List<RfqItemUx> items = new List<RfqItemUx>();
            return items;
        }
        public async Task<List<RfqItemUx>> GetRfqUxItemsAsync()
        {
            await Task.Delay(0);
            List<RfqItemUx> items = new List<RfqItemUx>();
            return items;
        }
    }
}
