using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Salida
    {
        public float pay { get; set; }

        public List<BilledShiftsList> billedShifts { get; set; }
    }
}
