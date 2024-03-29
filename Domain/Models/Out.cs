﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Out
    {
        /*      "id":1,
               "start":"2019-04-28 21:00:00",
               "end":"2019-04-29 00:00:00",
               "session":10800,
               "pay":31.50
         */

        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public double session { get; set; }
        public float pay { get; set; }
    }
}
