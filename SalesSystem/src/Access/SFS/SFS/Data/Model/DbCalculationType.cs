using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
namespace SFS.Data.Model
{
    public class DbCalculationType : IAggregateRoot
    {
        public int? Id
        { get; set; }
        public string? DisplayMember 
        { get; set; }
    }
}
