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
            model = new List<ProductList>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from Product where postStatus = 'AVAILABLE';";
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
                            ProductList product = new ProductList();
                            product.Product_ID = Product_ID;
                            product.User_ID = User_ID;
                            product.Product_title = Product_title;
                            product.Product_desc = Product_desc;
                            product.Product_price = Product_price;
                            product.Product_loc = Product_loc;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
