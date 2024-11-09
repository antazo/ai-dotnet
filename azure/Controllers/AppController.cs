using Microsoft.AspNetCore.Mvc;

namespace azure.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Home(string name = "visitor")
        {
            ViewData["Name"] = name;
            return View();
        }
    }
}