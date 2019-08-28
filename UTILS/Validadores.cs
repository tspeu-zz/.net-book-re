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

        /*
            DateTime date1 = new DateTime(2019,04,28,20,30,00);
            DateTime date2 = new DateTime(2019, 04, 29, 00, 30, 00);

            DateTime dateR1 = new DateTime(date1.Year, date1.Month,date1.Day,13,00,00);
            DateTime dateR2= new DateTime(date2.Year, date2.Month, date2.Day, 08, 00, 00);
// Calculate the interval between the two dates.
/*
{
   "shifts":[
      {
         "id":1,
         "start":"2019-04-28 20:30:00",
         "end":"2019-04-29 00:30:00"
      },
      {
         "id":2,
         "start":"2019-04-29 22:10:00",
         "end":"2019-04-30 01:10:00"
      }
   ],
   "rules":[
      {
         "id":1,
         "type":"FIXED",
         "start":"13:00",
         "end":"08:00",
         "payRate":10.50
      }
   ]
}*/
        //TimeSpan interval = date2 - date1;
        //TimeSpan intervalR = dateR1 - dateR2;
        //Console.WriteLine("END {0} - START {1} = {2}", date2, date1, interval.ToString());
        //Console.WriteLine(" STARTR {1} - ENDR {0 }  = {2}", dateR2, dateR1, intervalR.ToString());

        // Display individual properties of the resulting TimeSpan object.
        //Console.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
        //Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
        //Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
        //Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
        // Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours RULE:", intervalR.TotalHours);


        //Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
        //Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
        //Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
        //Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
        //Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);


        /*
         //var dat1 = new DateTime();
     // Define two dates.
     DateTime date1 = new DateTime(2019,04,28,20,30,00);
     DateTime date2 = new DateTime(2019, 04, 29, 00, 30, 00);
     //DateTime.Parse("01:00 PM");
     DateTime dateR1 = new DateTime(date1.Year, date1.Month,date1.Day,13,00,00);
     DateTime dateR2= new DateTime(date2.Year, date2.Month, date2.Day, 08, 00, 00);
     DateTime HORA_24= new DateTime(date1.Year, date1.Month, date1.Day, 23, 00, 00);
     Console.WriteLine(" HORA_24 -------------> " +  HORA_24);
     //Console.WriteLine(" HORA_24 ToString()-------------> " +  HORA_24.ToString("hh:mm:ss"));

     // Calculate the interval between the two dates.
     /*
     {
        "shifts":[
           {
              "id":1,
              "start":"2019-04-28 20:30:00",
              "end":"2019-04-29 00:30:00"
           },
           {
              "id":2,
              "start":"2019-04-29 22:10:00",
              "end":"2019-04-30 01:10:00"
           }
        ],
        "rules":[
           {
              "id":1,
              "type":"FIXED",
              "start":"13:00",
              "end":"08:00",
              "payRate":10.50
           }
        ]
     }*/
//        TimeSpan interval = date2 - date1;
//        TimeSpan intervalR = dateR1 - dateR2;
//        Console.WriteLine("END {0} - START {1} = {2}", date2, date1, interval.ToString());
//Console.WriteLine(" STARTR {1} - ENDR {0 }  = {2}", dateR2, dateR1, intervalR);
//TimeSpan DIA = HORA_24 - date1;
//        Console.WriteLine(" STARTR HORA_24 {0} - ENDR {1 }  = {2}", HORA_24, date1, DIA);
//TimeSpan DIA_COMPLETO = new TimeSpan(0, 0, 0, 0);
//        TimeSpan.FromHours(24);
//Console.WriteLine(" DIA +1" +DIA.);
  //TimeSpan baseTimeSpan = new TimeSpan(13, 0, 0, 0);
  //      // Create an array of timespan intervals.
  //      TimeSpan[] intervals = { TimeSpan.FromDays(1),
  //                             TimeSpan.FromHours(24),
  //                             TimeSpan.FromMinutes(30),
  //                             TimeSpan.FromMilliseconds(505),
  //                             new TimeSpan(20,30,00),
  //                             new TimeSpan(00, 30, 0) };

      // Calculate a new time interval by adding each element to the base interval.
    //  foreach (var inter in intervals) {

    //Console.WriteLine(@"{0,-10:g} {3} {1,15:%d\:hh\:mm\:ss\.ffff} = {2:%d\:hh\:mm\:ss\.ffff}", 
    //                       baseTimeSpan, inter, baseTimeSpan.Add(inter), 
    //                       interval<TimeSpan.Zero? "-" : "+");
    //  }

    //var dateTime1= System.DateTime.ParseExact("03/14/2012 11:00:00 PM", "MM/dd/yyyy hh:mm:ss ",System.Globalization.CultureInfo.InvariantCulture);
    //Console.WriteLine(" dateTime1 --> " + dateTime1);
    //System.DateTime.ParseExact("03/14/2012 01:00:00 PM", "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
    // Display individual properties of the resulting TimeSpan object.
    //Console.WriteLine("   {0,-35} {1,20}", "Value of Days Component:", interval.Days);
    //Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
//    Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
//Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
//Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours RULE:", intervalR.TotalHours);
//Console.WriteLine( "Value of Hours ComponentR : "+ intervalR.Hours);


//Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
//Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
//Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
//Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
//Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);

           

    }
}
