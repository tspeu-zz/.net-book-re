using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.UTILS
{
    public class Validadores
    {

        //
        public Boolean Validarfechas(DateTime date1, DateTime date2)
        {
            Boolean valida = false;
            //DateTime date1 = new DateTime(2009, 8, 1, 0, 0, 0);
            //DateTime date2 = new DateTime(2009, 8, 1, 12, 0, 0);
            int result = DateTime.Compare(date1, date2);
            string relationship;

            if (result < 0)
            {
                relationship = "is earlier than";
                valida = true;
            }
            //TEST
            else if (result == 0)
            {
                relationship = "is the same time as";
            }
            else
            {
                relationship = "is later than";
            }
            Console.WriteLine("{0} {1} {2}", date1, relationship, date2);
            //TEST
            return valida;
        }


        /*
         * 
              var dat1 = new DateTime(2019,04,28,20,30,0);
            //2019-04-28 20:30:00
            var dat2 = new DateTime(2019,04,29,00,30,0);
            //2019-04-29 00:30:00
            Console.WriteLine(dat1);
            Console.WriteLine(dat2);
            System.TimeSpan diff1 = dat2.Subtract(dat1);
            Console.WriteLine(diff1);
            Console.WriteLine(diff1.TotalSeconds);
            // "start":"2019-04-29 22:10:00",
            var dat3 = new DateTime(2019,04,29,22,10,0);
            //"end":"2019-04-30 01:10:00",
            var dat4 = new DateTime(2019,04,30,01,10,0);
            Console.WriteLine(dat3);
            Console.WriteLine(dat4);
            System.TimeSpan diff2 = dat4 - dat3;
            Console.WriteLine(diff2);
            Console.WriteLine(diff2.TotalSeconds);
         */

    }
}
