using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class PokedexEntry
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public string Name { get; set; }

        [StringLength(255)]
        public string Nickname { get; set; }

        [Display(Name = "Move 1")]
        public string Move1 { get; set; }

        [Display(Name = "Move 2")]
        public string Move2 { get; set; }

        [Display(Name = "Move 3")]
        public string Move3 { get; set; }

        [Display(Name = "Move 4")]
        public string Move4  { get; set; }
    }
}