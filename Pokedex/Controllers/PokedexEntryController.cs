using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokedex.Controllers
{
    public class PokedexEntryController : Controller
    {
        // GET: PokedexEntry
        public ActionResult Index()
        {
            return View();
        }
    }
}