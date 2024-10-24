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

        private readonly string connectionString = "Data Source=DESKTOP-OEAERTJ;Initial Catalog=CarTrading;Integrated Security=True;TrustServerCertificate=True;";    

        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Tried using jays Vanier app
        public IActionResult LoginMethod(LoginViewModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Users WHERE Username = @Username and Password =@Password";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Username", model.Username);
                    command.Parameters.AddWithValue("@Password", model.Password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string roletype = reader["roletype"].ToString();

                            HttpContext.Session.SetString("Username", model.Username);
                            HttpContext.Session.SetString("roletype", roletype);
                            HttpContext.Session.SetString("IsAuthenticated", "Y");



                            if (roletype.Equals("Admin"))
                                return RedirectToAction("Index", "Home");
                            else
                                return RedirectToAction("Index", "Home");

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
