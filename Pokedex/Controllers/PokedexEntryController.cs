using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokedex.Controllers
{
    public class PokedexEntryController : Controller
    {
        private ApplicationDbContext _context;

        public PokedexEntryController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: PokedexEntry
        public ActionResult Index()
        {
            var entries = _context.PokedexEntry.ToList();

            return View(entries);
        }
    }
}