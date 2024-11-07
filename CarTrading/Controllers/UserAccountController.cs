using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CarTrading.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public UserAccountController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

   

        public IActionResult UserDetails(UserDetailsViewModel model)
        {
            //Check who logs in
            //get user id from session
            //get session from login
            //Get local connection
            string getUsername = HttpContext.Session.GetString("Username");
            Int32? getUserId = HttpContext.Session.GetInt32("UserID");
            if (string.IsNullOrEmpty(getUsername)) 
            {
                return RedirectToAction("Login", "Index");
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Users WHERE Users.userId =" + getUserId + ";";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Username = reader["username"].ToString();
                            model.Email = reader["email"].ToString();
                            model.Role = reader["roletype"].ToString();
                        }
                    }
                }
            }
            return View(model);
        }

        public IActionResult ProductBought()
        {
            return View();
        }

        public IActionResult ProductOnSale()
        {

            try
            {
                List<ProductViewModel> model = new List<ProductViewModel>();

                string? currentRole = HttpContext.Session.GetString("RoleType");
                int? currentID = HttpContext.Session.GetInt32("UserID");

                if (string.IsNullOrEmpty(currentRole) || !currentID.HasValue)
                {
                    return RedirectToAction("Login", "Index");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "ReadAvailableProductByUserID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userID", currentID.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.Add(new ProductViewModel
                                {
                                    Product_ID = reader["ID"]?.ToString() ?? "",
                                    User_ID = reader["userID"]?.ToString() ?? "",
                                    Product_title = reader["pTitle"]?.ToString() ?? "",
                                    Product_desc = reader["pDesc"]?.ToString() ?? "",
                                    Product_price = reader["pPrice"]?.ToString() ?? "",
                                    Product_loc = reader["pLocation"]?.ToString() ?? "",
                                    Post_status = reader["postStatus"]?.ToString() ?? "",
                                    Product_color = reader["pColour"]?.ToString() ?? "",
                                    Product_make = reader["pMake"]?.ToString() ?? "",
                                    Product_model = reader["pModel"]?.ToString() ?? "",
                                    Product_year = reader["pYear"]?.ToString() ?? "",
                                    Product_mileage = reader["pMileage"]?.ToString() ?? "",
                                    Product_trans = reader["pTransmission"]?.ToString() ?? "",
                                    Product_fuel = reader["pFuelType"]?.ToString() ?? "",
                                    Product_url = reader["pUrl"]?.ToString() ?? ""
                                });
                            }
                        }
                    }
                }

                return View(model); // Pass the populated model to the view
            }
            catch (Exception ex)
            {
                // Log the exception for debugging (consider using a logging framework)
                Console.WriteLine($"Error loading product list: {ex.Message}");
                return View("Error"); // Optionally, redirect to an error page
            }
        }

        public IActionResult NewProduct()
        {
            return View();
        }
    }
}
