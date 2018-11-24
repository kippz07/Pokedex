﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        private ApplicationDbContext _context;

        public PokemonController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Pokemon
        public ActionResult Index()
        {
            var pokemon = GetPokemonList();

            return View(pokemon);
        }

        public ActionResult Details(int id)
        {
            var pokemon = GetPokemonList().SingleOrDefault(p => p.Id == id);

            if (pokemon == null)
                return HttpNotFound();

            return View(pokemon);
        }

        [HttpPost]
        public ActionResult Add(Pokemon pokemon)
        {
            Entry entry = new Entry() { PokemonId = pokemon.Id, Name = pokemon.Name };

            _context.SaveChanges();

            return RedirectToAction("Index", "Pokemon");
        }

        public IEnumerable<Pokemon> GetPokemonList()
        {
            return new List<Pokemon>
            {
                new Pokemon() { Id = 1, Name = "Bulbsaur", IsInPokedex = false },
                new Pokemon() { Id = 2, Name = "Charmander", IsInPokedex = false },
                new Pokemon() { Id = 3, Name = "Squirtle", IsInPokedex = false }
            };
            
        }
    }
}