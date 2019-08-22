using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Entrada
    {
        //[JsonProperty("shifts")]
        // public Shift[] shifts { get;  }
        //public List<Shift> shifts { get; set; }        

       public Shift shifts { get; set; }

    //[JsonProperty("rules")]
    //public Rule[] rules { get;  }
}
}
