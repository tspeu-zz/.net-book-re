using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Portions
    {
        public Portions(List<Out> portionsList )
        {
            this.portionsList = portionsList;
        }
        public List<Out> portionsList { get; set; }
    }
}
