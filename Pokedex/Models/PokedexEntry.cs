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
        public int? Move1Id { get; set; }
        public Stat Move1 { get; set; }

        [Display(Name = "Move 2")]
        public int? Move2Id { get; set; }
        public Stat Move2 { get; set; }

        [Display(Name = "Move 3")]
        public int? Move3Id { get; set; }
        public Stat Move3 { get; set; }

        [Display(Name = "Move 4")]
        public int? Move4Id  { get; set; }
        public Stat Move4  { get; set; }
    }
}