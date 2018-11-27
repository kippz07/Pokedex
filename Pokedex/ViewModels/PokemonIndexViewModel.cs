using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pokedex.Models;

namespace Pokedex.ViewModels
{
    public class PokemonIndexViewModel
    {
        public IEnumerable<Pokemon> Pokemon { get; set; }
        public int Gen { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}