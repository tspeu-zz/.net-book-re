﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_FreeCodeCamp.Domain.Models
{
    public class Entrada
    {
        public List<Shift> shifts { get; set; }

        public List<Rule> rules { get; set; }
    }
}