using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarTrading.Models;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace CarTrading.Controllers
{
    public class ProductListController : Controller
    {
        private readonly string connectionString = "Data Source = NLAUZON; Initial Catalog = CarTrading; Integrated Security = True"; //; Trust Server Certificate=True";
        private readonly ILogger<HomeController> _logger;

        public ProductListController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(List<ProductList> model)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Index");
            }
            model = new List<ProductList>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from Product inner join PContent on Product.ID = PContent.productID where postStatus = 'AVAILABLE';";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        { 
                            string Product_ID = reader["ID"].ToString();
                            string User_ID = reader["userID"].ToString();
                            string Product_title = reader["pTitle"].ToString();
                            string Product_desc = reader["pDesc"].ToString();
                            string Product_price = reader["pPrice"].ToString();
                            string Product_loc = reader["pLocation"].ToString();
                            string Product_color = reader["pColour"].ToString();
                            string Product_make = reader["pMake"].ToString();
                            string Product_model = reader["pModel"].ToString();
                            string Product_year = reader["pYear"].ToString();
                            string Product_milage = reader["pMileage"].ToString();
                            string Product_trans = reader["pTransmission"].ToString();
                            string Product_fuel = reader["pFuelType"].ToString();
                            ProductList product = new ProductList();
                            product.Product_ID = Product_ID;
                            product.User_ID = User_ID;
                            product.Product_title = Product_title;
                            product.Product_desc = Product_desc;
                            product.Product_price = Product_price;
                            product.Product_loc = Product_loc;
                            product.Product_color = Product_color;
                            product.Product_make = Product_make;
                            product.Product_model = Product_model;
                            product.Product_year = Product_year;
                            product.Product_milage = Product_milage;
                            product.Product_trans = Product_trans;
                            product.Product_fuel = Product_fuel;
                            model.Add(product);
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
        public string GetMyNameRight() 
        {
            return "Nicolas";
        }
        public int AddNumbers(int a, int b) 
        {
            return a + b;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
