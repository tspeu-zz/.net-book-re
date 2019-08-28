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
            //13 H --> 46800 SEG --> 08-->28800  * 3600
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

            
            ListaEntradaRule.ForEach(r => {

                Console.WriteLine("EMPIEZA  PARA RULE > " + r.id);
                var horaEnd = r.end.Hour;
                var horaStart = r.start.Hour;
                //TimeSpan interval = horaEnd - horaStart;
                var addHoraShiftRule = 0;
                /**/

                var CantidadhorasTurno = horaEnd - horaStart;
                var PayRange = r.payRate * CantidadhorasTurno;

                var _24H_SEGUNDOS = 86400;

                if (r.type == "FIXED") {
                    var itemShift =  ListaEntradaShifts.Find(s =>  r.id == s.id  );

                    Console.WriteLine("itemShift --> " + itemShift);

                    DateTime dateStartR = new DateTime(itemShift.start.Year, itemShift.start.Month, itemShift.start.Day, r.start.Hour, r.start.Minute, 00);
                    DateTime dataEndR = new DateTime(itemShift.end.Year, itemShift.end.Month, itemShift.end.Day, r.end.Hour, r.end.Minute, 00);
                    Console.WriteLine("dateStartR --> " + dateStartR);
                    Console.WriteLine("dataEndR --> " + dataEndR);

                    TimeSpan intervalRUle = dataEndR - dateStartR;
                    Console.WriteLine("intervalRUle --> " + itemShift);
                    var PayRangeRULE = r.payRate * intervalRUle.Hours;
                    Console.WriteLine("PayRangeRULE --> " + PayRangeRULE);

                    TimeSpan startRULE = TimeSpan.FromHours(dateStartR.Hour);
                           
                    //EMPEIZA EL RULE->TURNO
                    var START_converToSEGUNDOS = dateStartR.Hour * 3600;

                        //24 H --> 86.400 SEG * 3600 seg // 30min ->1800 TimeSpan.FromHours(24).TotalSeconds
                    //for (var i = dateStartR.Hour ; i <= 24 ; i++ ) {
     
                    var shift_START_SEGUNDOS = itemShift.start.Hour * 3600;

                    while (START_converToSEGUNDOS <= _24H_SEGUNDOS) {

                        if (shift_START_SEGUNDOS < START_converToSEGUNDOS )
                        {
                            addHoraShiftRule++;
                            Console.WriteLine("HA  TRABAJADO ESTE TURNO->");
                        }

                        START_converToSEGUNDOS = START_converToSEGUNDOS + 3600; //INCREMENTAR UNA HORA
                    }


                }
                else if (r.type == "DURATION")
                {
                    Console.WriteLine("TODO trow ERROR -> NO HAY RULE DURATION ->" + r.type);
                }
                else {
                    Console.WriteLine("TODO trow ERROR -> NO HAY RULE TIPO ->" + r.type);
                }
            });
            
            //TODO
            sal.pay = 10.89F;
            sal.billedShifts = null;

            return sal;
        }

        /*
        5-5-5-3
        18-23-4-7
                                              1-1-1-1
                                       |20:30--------00:30|
                                                     1-1-1   
                                              |22:10-----01:10|
        ---                |13 -------------------------------------08:00|
        0 ---------------12-----------------------24---------------------------------12
        1-24  

        https://codereview.stackexchange.com/questions/49205/algorithm-to-identify-a-shift-and-its-type-based-on-on-and-off-times
      https://www.c-sharpcorner.com/forums/calculate-total-timebreak-time
             */


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


        // public int convierteHoraSegundos(TimeSpan Hora) {

        //    return Hora.TotalSeconds * 3600;
        //}

       
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
