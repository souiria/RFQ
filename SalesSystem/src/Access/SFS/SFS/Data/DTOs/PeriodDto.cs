using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS.Data.DTOs
{
    public class PeriodDto
    {
        public int Id
        { get; set; }
        public string? Profile
        { get; set; }
        public int Period
        { get; set; }
        public DateTime EffectiveFrom
        { get; set; }
        public DateTime EffectiveTo
        { get; set; }
        public DateTime UpdatedDate
        { get; set; }
        public string? UpdatedBy
        { get; set; }
    }
}
