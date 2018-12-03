using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pokedex.Models;

namespace Pokedex.ViewModels
{
    public class EntryEditViewModel
    {
        public Pokemon Pokemon { get; set; }
        public PokedexEntry Entry { get; set; }
    }
}