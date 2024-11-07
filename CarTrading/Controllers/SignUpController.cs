using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CarTrading.Controllers
{

    public class SignUpController : Controller
    {
        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public SignUpController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        //Not complete
        public IActionResult SignUpMethod(SignUpViewModel model)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SignUp";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        command.Parameters.AddWithValue("@User_name", model.Username);
                        command.Parameters.AddWithValue("@Role_type", model.Password);
                        command.Parameters.AddWithValue("@Email", model.Username);
                        command.Parameters.AddWithValue("@Password", model.Password);

                        // Output parameters
                        SqlParameter resultParameter = new SqlParameter("@result", SqlDbType.Int)
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

                        SqlParameter messageParameter = new SqlParameter("@message", SqlDbType.NVarChar, 250)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(messageParameter);

                        command.ExecuteNonQuery(); // Execute the stored procedure

                        // Retrieve output parameter values safely
                        int result = resultParameter.Value != DBNull.Value ? (int)resultParameter.Value : 0;
                        string roleType = roleTypeParameter.Value != DBNull.Value ? (string)roleTypeParameter.Value : string.Empty;
                        string username = usernameParameter.Value != DBNull.Value ? (string)usernameParameter.Value : string.Empty;
                        int userID = userIDParameter.Value != DBNull.Value ? (int)userIDParameter.Value : 0;
                        string message = messageParameter.Value != DBNull.Value ? (string)messageParameter.Value : string.Empty;

                        if (result == 1)
                        {


                            model.ErrorMessage = message;
                            return RedirectToAction("Index", "Login");


                        }
                        else if (result == -1)
                        {
                            model.ErrorMessage = message;
                        }
                        else
                        {
                            model.ErrorMessage = message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                Console.WriteLine(ex.Message);
                model.ErrorMessage = "An unexpected error occurred during signup.";
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
