using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi_FreeCodeCamp.Domain.Models;

namespace webapi_FreeCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class BillingController : ControllerBase
    {
        // GET: api/Billing
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Billing/5
        [HttpGet("{id}", Name = "GetBilling")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Billing
        //[Route("Billing2")]
        [Route("[action]")]
        [HttpPost]
        public async Task<Salida> Inicio ([FromBody] InputData value) {
            List<Shift> ListaEntradaShifts = new List<Shift>();

            ListaEntradaShifts.Add(new Shift()
            {
                id = 1,
                start = new DateTime(2019, 04, 28, 20, 30, 00),
                end = new DateTime(2019, 04, 29, 00, 30, 00)
            });

            ListaEntradaShifts.Add(new Shift()
            {
                id = 2,
                start = new DateTime(2019, 04, 29, 22, 10, 00),
                end = new DateTime(2019, 04, 30, 01, 10, 00)
            });

            value.shifts = ListaEntradaShifts;

            //
            List<Rule> ListaEntradaRule = new List<Rule>();

            ListaEntradaRule.Add(new Rule()
            {
                id = 1,
                type = "FIXED",
                start = new DateTime().AddHours(13).AddMinutes(00),
                end = new DateTime().AddHours(08).AddMinutes(00),
                payRate = 10.50F
            });
            value.rules = ListaEntradaRule;

            //var itemShift = ListaEntradaShifts.Find(s => r.id == s.id);
            ListaEntradaShifts.ForEach(s => {

                int HORAS_TRABAJO_S_RULE1 = 0;
                int HORAS_TRABAJO_S_RULE2 = 0;
                int HORAS_TRABAJO_S_RULE3 = 0;
                int TOTAL_HORAS_TRABAJO_SHIFT = 0;
             
                ListaEntradaRule.ForEach(r => {

                var itemShift = ListaEntradaShifts.Find(it => r.id == it.id);

                DateTime startRULE = new DateTime(s.start.Year, s.start.Month, s.start.Day, r.start.Hour, r.start.Minute, 00);
                DateTime endRule = new DateTime(s.end.Year, s.end.Month, s.end.Day, r.end.Hour, r.end.Minute, 00);

                TimeSpan intervalRUle = endRule - startRULE;
                var PayRangeRULE_TOTAL = r.payRate * intervalRUle.Hours;
                Console.WriteLine("PayRangeRULE --> " + PayRangeRULE_TOTAL);
                //TimeSpan startRULE_HORAS = TimeSpan.FromHours(startRULE.Ticks);

                    if (r.type == "FIXED") {
                        int iStart = startRULE.Hour == 0 ? 24 : startRULE.Hour;
                        int iEnd = endRule.Hour == 0 ? 24 : endRule.Hour;

                        int startSHIFT = s.start.Hour == 0 ? 24 : s.start.Hour;
                        int endSHIFT = s.end.Hour == 0 ? 24 : s.end.Hour;

                        int startSHIFT_TOTAL = (s.start.Hour * 3600) + (s.start.Minute * 60);
                        int endSHIFT_TOTAL = (s.end.Hour * 3600) + (s.end.Minute * 60);

                        int iterarot = startSHIFT;

                        var endShihtCONVERT = endSHIFT == 24 ? 0 : endSHIFT;
                        while (iterarot <= endSHIFT) {

                            if (startSHIFT > startRULE.Hour) {

                                if (endShihtCONVERT  < iEnd) {

                                HORAS_TRABAJO_S_RULE1 ++;

                                }
                            }


                        iterarot++;
                        }
                    }

                    if (r.type == "DURATION") {

                    }
                       


                });


            });


                Salida n = new Salida();
            n.pay = 111112;
            n.billedShifts = null;
            return n;
        }


        int converTo24(int value) {

            return value = 24;
        }

        // POST: api/Billing
        [HttpPost]
        public async Task<Salida> Postter2([FromBody] InputData value)
        {
            List<Shift> ListaEntradaShifts = new List<Shift>();

            ListaEntradaShifts.Add(new Shift()
            {
                id = 1,
                start = new DateTime(2019, 04, 28, 20, 30, 00),
                end = new DateTime(2019, 04, 29, 00, 30, 00)
            });

            ListaEntradaShifts.Add(new Shift()
            {
                id = 2,
                start = new DateTime(2019, 04, 29, 22, 10, 00),
                end = new DateTime(2019, 04, 30, 01, 10, 00)
            });

            value.shifts = ListaEntradaShifts;

            //
            List<Rule> ListaEntradaRule = new List<Rule>();

            ListaEntradaRule.Add(new Rule()
            {
                id = 1,
                type = "FIXED",
                start = new DateTime().AddHours(13).AddMinutes(00),
                end = new DateTime().AddHours(08).AddMinutes(00),
                payRate = 10.50F
            });
            value.rules = ListaEntradaRule;

            //var itemShift = ListaEntradaShifts.Find(s => r.id == s.id);
            ListaEntradaShifts.ForEach(s => {

                int HORAS_TRABAJO_S_RULE1 = 0;
                int HORAS_TRABAJO_S_RULE2 = 0;
                int HORAS_TRABAJO_S_RULE3 = 0;
                int TOTAL_HORAS_TRABAJO_SHIFT = 0;

                ListaEntradaRule.ForEach(r => {

                    var itemShift = ListaEntradaShifts.Find(it => r.id == it.id);

                    DateTime startRULE = new DateTime(s.start.Year, s.start.Month, s.start.Day, r.start.Hour, r.start.Minute, 00);
                    DateTime endRule = new DateTime(s.end.Year, s.end.Month, s.end.Day, r.end.Hour, r.end.Minute, 00);

                    TimeSpan intervalRUle = endRule - startRULE;
                    var PayRangeRULE_TOTAL = r.payRate * intervalRUle.Hours;
                    Console.WriteLine("PayRangeRULE --> " + PayRangeRULE_TOTAL);
                    //TimeSpan startRULE_HORAS = TimeSpan.FromHours(startRULE.Ticks);

                    if (r.type == "FIXED")
                    {

                        int iStart = startRULE.Hour == 0 ? 24 : startRULE.Hour;
                        int iEnd = endRule.Hour == 0 ? 24 : endRule.Hour;

                        int startSHIFT = s.start.Hour == 0 ? 24 : s.start.Hour;
                        int endSHIFT = s.end.Hour == 0 ? 24 : s.end.Hour;


                        int startSHIFT_TOTAL = (s.start.Hour * 3600) + (s.start.Minute * 60);
                        int endSHIFT_TOTAL = (s.end.Hour * 3600) + (s.end.Minute * 60);

                        int iterarot = 1;

                        while (iterarot < intervalRUle.Hours)
                        {

                            if (startSHIFT > startRULE.Hour)
                            {

                                if (endSHIFT < iEnd)
                                {


                                }

                                HORAS_TRABAJO_S_RULE1++;
                            }



                            iterarot++;
                            //if (iStart == 24) {
                            //    iStart = 0;
                            //}
                        }


                    }

                    if (r.type == "DURATION")
                    {

                    }



                });


            });


            Salida n = new Salida();
            n.pay = 12;
            n.billedShifts = null;
            return n;
        }

        // PUT: api/Billing/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
