using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CarTrading.Controllers
{
    public class LoginController : Controller
    {
        //private readonly string connectionString = "Data Source=CHOO-LAPTOP;Initial Catalog=Car_Trading;User ID=sa;Password=JavaDev2024!;TrustServerCertificate=True";

        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection");
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
                string query = "Login";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    command.Parameters.AddWithValue("@User_name", model.Username);
                    command.Parameters.AddWithValue("@Password", model.Password);

                    // Output parameters
                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(resultParameter);

                    SqlParameter roleTypeParameter = new SqlParameter("@RoleType", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(roleTypeParameter);

                    SqlParameter usernameParameter = new SqlParameter("@username", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(usernameParameter);

                    SqlParameter userIDParameter = new SqlParameter("@UserID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(userIDParameter);

                    command.ExecuteNonQuery(); // Execute the stored procedure

                    // Get the result from the output parameter
                    int result = (int)resultParameter.Value;
                    string roleType = (string)roleTypeParameter.Value;
                    string username = (string)usernameParameter.Value;
                    int userID = (int)userIDParameter.Value;

                    if (result == 1) // Successful login
                    {
                        // Set session variables
                        HttpContext.Session.SetString("Username", username);
                        HttpContext.Session.SetInt32("UserID", userID);
                        HttpContext.Session.SetString("RoleType", roleType);

                        HttpContext.Session.SetString("IsAuthenticated", "Y");
                        return RedirectToAction("Index", "ProductList", model);
                    }
                    else if (result == -1)
                    {
                        model.ErrorMessage = "Your username/password is incorrect";
                    }
                    else
                    {
                        model.ErrorMessage = "User does not exist";
                    }

                    return View("Index", model); // Return to login view with error message
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
