using CarTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;

namespace CarTrading.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly string connectionString = "Data Source = NLAUZON; Initial Catalog = CarTrading; Integrated Security = True"; //; Trust Server Certificate=True";
        private readonly ILogger<HomeController> _logger;

        public ProductDetailsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Product_ID)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Index");
            }
            ProductList model = new ProductList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from Product inner join PContent on Product.ID = PContent.productID where ID = '"+ Product_ID + "';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Product_ID = reader["ID"].ToString();
                            model.User_ID = reader["userID"].ToString();
                            model.Product_title = reader["pTitle"].ToString();
                            model.Product_desc = reader["pDesc"].ToString();
                            model.Product_price = reader["pPrice"].ToString();
                            model.Product_loc = reader["pLocation"].ToString();
                            model.Product_color = reader["pColour"].ToString();
                            model.Product_make = reader["pMake"].ToString();
                            model.Product_model = reader["pModel"].ToString();
                            model.Product_year = reader["pYear"].ToString();
                            model.Product_milage = reader["pMileage"].ToString();
                            model.Product_trans = reader["pTransmission"].ToString();
                            model.Product_fuel = reader["pFuelType"].ToString();
                        }
                    }
                }
            }
            return View(model);
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
