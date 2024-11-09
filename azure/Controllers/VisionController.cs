using Microsoft.AspNetCore.Mvc;

namespace azure.Controllers
{
    public class VisionController : Controller
    {
        public IActionResult Vision(string name = "visitor")
        {
            ViewData["Name"] = name;
            return View();
        }
        public IActionResult Face(string name = "visitor")
        {
            ViewData["Name"] = name;
            return View();
        }
    }
}