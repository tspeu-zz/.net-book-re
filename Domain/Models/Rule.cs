using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Rule
    {
        /*   "id":1,
         "type":"FIXED",
         "start":"13:00",
         "end":"08:00",
         "payRate":10.50*/

        public int id { get; set; }

        public string type { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public float payRate { get; set; }

    }

}
