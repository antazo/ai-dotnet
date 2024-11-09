using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace azure.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index(string name = "visitor")
        {
            ViewData["Name"] = name;
            return View();
        }

        [HttpGet("/planet_distances")]
        public IActionResult PlanetDistances()
        {
            var distances = new Dictionary<string, double>
            {
                { "Mercury", 91.7 },
                { "Venus", 41.4 },
                { "Earth", 0.0 },
                { "Mars", 78.3 },
                { "Jupiter", 628.7 },
                { "Saturn", 1277.4 },
                { "Uranus", 2721.8 },
                { "Neptune", 4351.4 }
            };
            ViewData["Distances"] = distances;
            return View();
        }
    }
}