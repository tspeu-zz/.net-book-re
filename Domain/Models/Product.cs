using System;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Product
    {
	    public int Id { get; set; }
        public string Name { get; set; }
        public short CantidadPorPaquete { get; set; }
        public EUnitOfMeasurement UnitOfMesasurement { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
            
    }


}
