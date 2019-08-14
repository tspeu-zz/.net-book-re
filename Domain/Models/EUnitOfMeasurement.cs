using System;
using System.ComponentModel;

namespace webapi_FreeCodeCamp.Domain.Models
{

    public enum EUnitOfMeasurement: byte
    {
        [Description("UN")]  Unity = 1,

        [Description("MG")] Milligram = 2,

        [Description("G")] Gram = 3,

        [Description("KG")] Kilogram = 4,

        [Description("L")] Liter = 5


    }
/*Notice the Description attribute applied over every enumeration possibility. 
 * An attribute is a way to define metadata over classes, interfaces, 
 * properties and other components of the C# language. 
 * In this case, we’ll use it to simplify the responses of the products API endpoint,
 * but you don’t have to care about it for now. We’ll come back here later.*/
}
