using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CarTrading.Controllers
{
    public class LoginController : Controller
    {

        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private void UpdateLogRegistry(string msg)
        {
            string logEntry = "date: " + DateTime.Now + ", " + msg;
            string dir = Directory.GetCurrentDirectory();
            string path = Path.Combine(dir, "Resources\\Log.txt");
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(logEntry);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult LoginMethod(LoginViewModel model)
        {
            try
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

                        // Retrieve output parameter values safely
                        int result = resultParameter.Value != DBNull.Value ? (int)resultParameter.Value : 0;
                        string roleType = roleTypeParameter.Value != DBNull.Value ? (string)roleTypeParameter.Value : string.Empty;
                        string username = usernameParameter.Value != DBNull.Value ? (string)usernameParameter.Value : string.Empty;
                        int userID = userIDParameter.Value != DBNull.Value ? (int)userIDParameter.Value : 0;

                        if (result == 1) // Successful login
                        {
                            UpdateLogRegistry("userName: " + model.Username + ", result: Successful login");

                            // Set session variables
                            HttpContext.Session.SetString("Username", username);
                            HttpContext.Session.SetInt32("UserID", userID);
                            HttpContext.Session.SetString("RoleType", roleType);
                            HttpContext.Session.SetString("IsAuthenticated", "Y");

                            // Redirect to different pages based on role type if needed
                            if (roleType == "Admin")
                            {
                                return RedirectToAction("Index", "ProductList");

                            }
                            else
                            {
                                return RedirectToAction("Index", "ProductList");

                            }

                        }
                        else if (result == -1)
                        {
                            UpdateLogRegistry("userName: " + model.Username + ", result: Unsuccessful login");
                            model.ErrorMessage = "Your username/password is incorrect";
                        }
                        else
                        {
                            UpdateLogRegistry("userName: " + model.Username + ", result: Unsuccessful login");
                            model.ErrorMessage = "User does not exist";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.Message);
                model.ErrorMessage = "An unexpected error occurred during login.";
            }

            return View("Index", model); // Return to login view with error message
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
