using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edi.Common.DTOs;
public class ExternalSalesPriceInformationViewDto
{
    public string CustomerName { get; set; }
    public string FinanceCode { get; set; }
    public string ProductNumber { get; set; }
    public string CurrencyCode { get; set; }
    public double OrderPrice { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string OrderNumber { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Status { get; set; }
    public string? SchedulingAgreement { get; set; }
}
