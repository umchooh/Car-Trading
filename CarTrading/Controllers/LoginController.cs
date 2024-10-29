using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarTrading.Controllers
{
    public class LoginController : Controller
    {
        //private readonly string connectionString = "Data Source=CHOO-LAPTOP;Initial Catalog=Car_Trading;User ID=sa;Password=JavaDev2024!;TrustServerCertificate=True";

        //private readonly string connectionString = "Data Source=DESKTOP-OEAERTJ;Initial Catalog=CarTrading;Integrated Security=True;TrustServerCertificate=True;";    
        private readonly string connectionString = "Data Source = NLAUZON; Initial Catalog = CarTrading; Integrated Security = True"; //; Trust Server Certificate=True";

        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        public IActionResult LoginMethod(LoginViewModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //string sql = "SELECT * FROM Users WHERE Username = @Username and Password =@Password";
                string sql = "SELECT * FROM Users WHERE username = @Username;";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", model.Username);
                    //command.Parameters.AddWithValue("@Password", model.Password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string roletype = reader["roletype"].ToString();
                            HttpContext.Session.SetString("Username", model.Username);
                            HttpContext.Session.SetString("roletype", roletype);
                            HttpContext.Session.SetString("IsAuthenticated", "Y");
                            return RedirectToAction("Index", "ProductList");

                        }
                        else
                        {
                            model.ErrorMessage = "Your username/password is incorrect";
                            return View("Index", model);
                        }
                    }
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
