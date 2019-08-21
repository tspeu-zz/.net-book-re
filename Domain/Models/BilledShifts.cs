using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class BilledShiftsList
    {
        public Out Out { get; set; }
        public List<Portions> portions { get; set; }
    }
}
