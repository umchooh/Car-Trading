using Microsoft.AspNetCore.Mvc;

namespace CarTrading.Controllers
{
    public class ErrorController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Title"] = "Error";
            return View();
        }
    }
}
