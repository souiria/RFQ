using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [Serializable]
    public class AlternativePartPrice
    {
        public string Source { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string Supplier { get; set; }
        public string DisplayName { get { return (Source+" "+Price+" "+Currency+ " " + Supplier); } set { } }
    }
}
