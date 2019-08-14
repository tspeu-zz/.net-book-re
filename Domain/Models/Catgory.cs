using System;
using System.Collections.Generic;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();


    }
}
