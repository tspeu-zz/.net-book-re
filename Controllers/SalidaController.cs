using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi_FreeCodeCamp.Domain.Models;
using webapi_FreeCodeCamp.UTILS;

namespace webapi_FreeCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
  
    public class SalidaController : Controller
    {
            Validadores _validadores = new Validadores();

        // GET: api/Salida
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Salida/5
        [HttpGet("{id}", Name = "GetSalida")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Salida
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}
        //[Produces("application/json")]
        //public async Task<ActionResult<Salida>> PostSalida(Entrada entrada) 
        [HttpPost]
        public ActionResult<Salida> PostSalida()
        //public ActionResult<Salida> PostSalida(Entrada entrada)
        {
            //_context.TodoItems.Add(item);
            //string result = await Request.Content.ReadAsStringAsync();
            // await 
            //var jsonT = JsonConvertJsonConvert.SerializeObject(entrada);

            // List<Shift> ListaEntradaShifts = entrada.shifts;
            //  List<Boolean> ListaShiftValidados = new List<Boolean>();

            //List<Rule> ListaEntradaRule = entrada.rules;
            // Rule ruleEntrada = null;

            Entrada entra = new Entrada();
            //entra.shifts

            List<Shift> ListaEntradaShifts = new List<Shift>();

            ListaEntradaShifts.Add(new Shift()
            {
                id = 1,
                start = new DateTime(2019, 04, 28, 20, 30, 00),
                end = new DateTime(2019,04,29,00,30,00)
            });

            ListaEntradaShifts.Add(new Shift()
            {
                id = 2,
                start = new DateTime(2019,04,29,22,10,00),
                end = new DateTime(2019,04,30,01,10,00)
            });

            entra.shifts = ListaEntradaShifts;

            List<Rule> ListaEntradaRule = new List<Rule>();

            ListaEntradaRule.Add(new Rule()
                {    id=1, type="FIXED",
                     start = new DateTime().AddHours(13).AddMinutes(00),
                     end= new DateTime().AddHours(08).AddMinutes(00),
                     payRate= 10.50F
                });
            entra.rules = ListaEntradaRule;

            //if (entrada.rules == null)
            //{
            //    //* return HttpBadRequest();
            //     Console.WriteLine("TODO entrada > " + entrada);
            //}
            // entra = entrada;
            var entradaData = JsonConvert.SerializeObject(entra);
            Salida sal = new Salida();
            Console.WriteLine("TODO entrada > " + entradaData);

            //TODO VALIDAR ENTRADA
            //ListaEntradaShifts.ForEach(S => {
            //    ListaShiftValidados[S.id] = ValidarShiftEntrada(S);
            //});

            // "id":1,//"type":"FIXED",//"start":"21:00",//"end":"00:00",//"payRate":10.50

            /*
                        ListaEntradaRule.ForEach(r => {

                            Console.WriteLine("EMPIEZA  PARA RULE > " + r.id);

                            if (r.type == "FIXED")
                            {

                                if (r.id == ListaEntradaShifts[r.id].id)
                                {
                                    //OJO TRANSFORMAR HORAS
                                    var CantidadhorasTurno = r.end - r.start;
                                    var PayRange = r.payRate * CantidadhorasTurno;

                                    //TODO
                                    calculatedShiftTurns(r, ListaEntradaShifts);

                                }
                                else {
                                    Console.WriteLine("TODO trow ERROR NO HAY SHIFT  PARA RULE > " + r.id);

                                }

                            }
                            else if (r.type == "DURATION")
                            {

                            }
                            else {
                                Console.WriteLine("TODO trow ERROR -> NO HAY RULE TIPO ->" + r.type);

                            }


                        });
            */
            //TODO
            sal.pay = 10.89F;
            sal.billedShifts = null;

            return sal;
        }




         /*VALIDAR FECHA SHIFT //VALIDAR SHIFT*/
        //public Boolean ValidarListaShiftEntrada(List<Shift> ListaEntradaShifts) {   
        //    // • A shift can’t end before it starts 
        //    Shift shiftAntual = null;
        //    Boolean empieza = false;

        //    ListaEntradaShifts.ForEach(s => {
        //        shiftAntual = s;
        //        if (_validadores.Validarfechas(shiftAntual.start, shiftAntual.end))
        //        {
        //            Console.WriteLine("FECHA OK en id: " + shiftAntual.id);
        //            empieza = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("trow Error  TODO");
        //        }

        //    });

          //  Console.WriteLine("VALIDAD FECHA ES--> " + empieza);
            // • Shifts can start in one day and end in the following day 
            //TODO

            // The shift maximum duration can be assumed to be 24 hours 
            // TODO
          //  return empieza;
      //  }


        //SOLO SHIFT
        /*VALIDAR FECHA SHIFT //VALIDAR SHIFT*/
        //public Boolean ValidarShiftEntrada(Shift shift)
        //{
        //    // • A shift can’t end before it starts 
        //    Shift shiftAntual = null;
        //    Boolean empieza = false;
        //        if (_validadores.Validarfechas(shiftAntual.start, shiftAntual.end))
        //        {
        //            Console.WriteLine("FECHA OK en id: " + shiftAntual.id);
        //            empieza = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("trow Error  TODO");
        //        }

        //    Console.WriteLine("VALIDAD FECHA ES--> " + empieza);
        //    // • Shifts can start in one day and end in the following day 
        //    //TODO

        //    // The shift maximum duration can be assumed to be 24 hours 
        //    // TODO
        //    return empieza;
        //}

        //
        public List<Shift> getShifts(Shift s) {
            List<Shift> listaShifts = null;
            listaShifts.Add(s);

            return listaShifts;
        }

        /*
         *  "shifts":[
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
     */

        void calculatedShiftTurns(Rule r, List<Shift> ListaEntradaShifts) {

            // var diffStarTurno = r.start - ListaEntradaShifts[r.id].start;
            var itemShift = ListaEntradaShifts.First(item => item.id == r.id);
            var startShitf = itemShift.start;
            var endShift = itemShift.end;

            var startRule = r.start;
            var endRule = r.end;

            //TODO OJO check RULE fixed/duration
         //  Console.WriteLine("startShitf" +  startShitf.Hour); 
          // Console.WriteLine("endShift " + endShift.Hour);
            // date.Hour;
            //date.Minute;
            Console.WriteLine("startRule " + startRule);
            Console.WriteLine("endRule " + endRule);


        }


        /* "rules":[
         {
            "id":1,
            "type":"FIXED",
            "start":"21:00",
            "end":"00:00",
            "payRate":10.50
         },
         {
            "id":2,
            "type":"DURATION",
            "start":3600,
            "end":7200,
            "payRate": 20.23
         },
         {
            "id":3,
            "type":"DURATION",
            "start":7200,
            "end":10801,
            "payRate": 30.50
         }
        ]
         * 
         */




        // PUT: api/Salida/5
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
