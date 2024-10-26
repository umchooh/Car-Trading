using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CarTrading.Controllers
{
    
    public class SignUpController : Controller
    {
        private readonly string connectionString = "Data Source=DESKTOP-OEAERTJ;Initial Catalog=Car_Trading;Integrated Security=True;TrustServerCertificate=True;"; //; Trust Server Certificate=True";
        private readonly ILogger<HomeController> _logger;

        public SignUpController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Not complete
        public IActionResult SignUpMethod(SignUpViewModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"";
                
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", model.Username);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@Password", model.Password);

                }

            }
            return View("Index", model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
