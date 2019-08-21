using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<ActionResult<Salida>> PostSalida(Entrada entrada)
        {
            //_context.TodoItems.Add(item);
            //await 

            List<Shift> ListaEntradaShifts = entrada.shifts;
            List<Boolean> ListaShiftValidados = new List<Boolean>();

            List<Rule> ListaEntradaRule = entrada.rules;
            
            Salida sal = new Salida();


            //TODO VALIDAR ENTRADA
            ListaEntradaShifts.ForEach(S => {
                ListaShiftValidados[S.id] = ValidarShiftEntrada(S);
            });







            sal.pay = 10.89F;
            sal.billedShifts = null;

            return sal;
        }




         /*VALIDAR FECHA SHIFT //VALIDAR SHIFT*/
        public Boolean ValidarListaShiftEntrada(List<Shift> ListaEntradaShifts) {   
            // • A shift can’t end before it starts 
            Shift shiftAntual = null;
            Boolean empieza = false;

            ListaEntradaShifts.ForEach(s => {
                shiftAntual = s;
                if (_validadores.Validarfechas(shiftAntual.start, shiftAntual.end))
                {
                    Console.WriteLine("FECHA OK en id: " + shiftAntual.id);
                    empieza = true;
                }
                else
                {
                    Console.WriteLine("trow Error  TODO");
                }

            });

            Console.WriteLine("VALIDAD FECHA ES--> " + empieza);
            // • Shifts can start in one day and end in the following day 
            //TODO

            // The shift maximum duration can be assumed to be 24 hours 
            // TODO
            return empieza;
        }


        //SOLO SHIFT
        /*VALIDAR FECHA SHIFT //VALIDAR SHIFT*/
        public Boolean ValidarShiftEntrada(Shift shift)
        {
            // • A shift can’t end before it starts 
            Shift shiftAntual = null;
            Boolean empieza = false;
                if (_validadores.Validarfechas(shiftAntual.start, shiftAntual.end))
                {
                    Console.WriteLine("FECHA OK en id: " + shiftAntual.id);
                    empieza = true;
                }
                else
                {
                    Console.WriteLine("trow Error  TODO");
                }

            Console.WriteLine("VALIDAD FECHA ES--> " + empieza);
            // • Shifts can start in one day and end in the following day 
            //TODO

            // The shift maximum duration can be assumed to be 24 hours 
            // TODO
            return empieza;
        }

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
