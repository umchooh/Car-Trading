using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CarTrading.Controllers
{

    public class DashboardController : Controller
    {

        private readonly string connectionString;
        private readonly ILogger<HomeController> _logger;

        public DashboardController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }



        // GET: TesterForCRUD
        public ActionResult Index()
        {
            return View();
        }

        // GET: TesterForCRUD/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult List()
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
                    string sql = "ReadProductByUserID";

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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            string? currentRole = HttpContext.Session.GetString("RoleType");
            int? currentID = HttpContext.Session.GetInt32("UserID");

            if (string.IsNullOrEmpty(currentRole) || !currentID.HasValue)
            {
                return RedirectToAction("Login", "Index");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = currentRole switch
                    {
                        "Dealer" => "CreateProductByDealer",
                        "Regular" => "CreateProductByRegular",
                        _ => throw new Exception("Invalid user role.")
                    };

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("@userID", currentID);
                        command.Parameters.AddWithValue("@pTitle", model.Product_title);
                        command.Parameters.AddWithValue("@pDesc", model.Product_desc);
                        command.Parameters.AddWithValue("@pPrice", model.Product_price);
                        command.Parameters.AddWithValue("@pLocation", model.Product_loc);
                        command.Parameters.AddWithValue("@pColour", model.Product_color);
                        command.Parameters.AddWithValue("@pMake", model.Product_make);
                        command.Parameters.AddWithValue("@pModel", model.Product_model);
                        command.Parameters.AddWithValue("@pYear", model.Product_year);
                        command.Parameters.AddWithValue("@pMileage", model.Product_mileage);
                        command.Parameters.AddWithValue("@pTransmission", model.Product_trans);
                        command.Parameters.AddWithValue("@pFuelType", model.Product_fuel);
                        command.Parameters.AddWithValue("@pUrl", model.Product_url);

                        // Define output parameters
                        SqlParameter resultParameter = new SqlParameter("@result", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(resultParameter);

                        SqlParameter messageParameter = new SqlParameter("@message", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(messageParameter);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();

                        int result = resultParameter.Value != DBNull.Value ? (int)resultParameter.Value : 0;
                        string message = messageParameter.Value?.ToString() ?? "Operation failed.";

                        if (result == 1)
                        {
                            TempData["SuccessMessage"] = message;
                            return RedirectToAction("List"); // Redirect without passing model
                        }
                        else
                        {
                            model.ErrorMessage = message;
                            return View("Create", model); // Show Create page with error
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                model.ErrorMessage = "An error occurred while processing your request.";
                return View("Create", model); // Return to Create view with error message
            }
        }

        // GET: TesterForCRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TesterForCRUD/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesterForCRUD/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TesterForCRUD/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
