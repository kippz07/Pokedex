﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInPokedex { get; set; }
    }
}