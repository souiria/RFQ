using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.NPR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Sales.AlternativePart
{
    [Serializable]
    public class AlternativePartSwap 
    {
        public string OriginalPart { get; set; }
        public ObservableCollection<AlternativePartPrice> OrgPriceList { get; set; }
        public AlternativePartPrice SelectedOrgPrice { get;
            set ; }
        public string OrgSource { get {
                if (SelectedOrgPrice == null)
                {
                    return "N/A";
                }
                return SelectedOrgPrice.Source;
            }
        }
        public decimal? OrgPrice {
            get
            {
                if (SelectedOrgPrice == null)
                {
                    return 0;
                }
                return SelectedOrgPrice.Price;
            }
        }
        public string OrgCurrency {
            get
            {
                if (SelectedOrgPrice == null)
                {
                    return "N/A";
                }
                return SelectedOrgPrice.Currency;
            }
        }
        public string OrgSupplier {
            get
            {
                if (SelectedOrgPrice == null)
                {
                    return "N/A";
                }
                return SelectedOrgPrice.Supplier;
            }
        }
        public string SwappedPart { get; set; }
        public List<AlternativePartPrice> SwapPriceList { get; set; }
        public AlternativePartPrice SelectedSwapPrice { get; set; }

        public string SwapSource
        {
            get
            {
                if (SelectedSwapPrice == null)
                {
                    return "N/A";
                }

                return SelectedSwapPrice.Source;
            }
        }

        public decimal? SwapPrice
        {
            get
            {
                if (SelectedSwapPrice == null)
                {
                    return 0;
                }

                return SelectedSwapPrice.Price;
            }
        }

        public string SwapCurrency
        {
            get
            {
                if (SelectedSwapPrice == null)
                {
                    return "N/A";
                }

                return SelectedSwapPrice.Currency;
            }
        }

        public string SwapSupplier
        {
            get
            {
                if (SelectedSwapPrice == null)
                {
                    return "N/A";
                }

                return SelectedSwapPrice.Supplier;
            }
        }
    }
}
