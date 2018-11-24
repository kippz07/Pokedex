using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pokedex.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public string Name { get; set; }
    }
}