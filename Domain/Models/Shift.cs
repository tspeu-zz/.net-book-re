using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Shift
    {
        public int id { get; set; }

        //var dat1 = new DateTime();      
        //Console.WriteLine(dat1);   01/01/0001 00:00:00
        //public DateTime(int year, int month, int day, int hour, int minute, int second);
        public DateTime start { get; set; }

        public DateTime end { get; set; }

    }
}
