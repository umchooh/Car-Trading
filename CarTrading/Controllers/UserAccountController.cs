using Microsoft.AspNetCore.Mvc;

namespace CarTrading.Controllers
{
    public class UserAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
