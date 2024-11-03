using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarTrading.Models
{
    public class ProductViewModel
    {
        public string Product_ID { get; set; }
        public string User_ID { get; set; }
        public string Product_title { get; set; }
        public string Product_desc { get; set; }
        public string Product_price { get; set; }
        public string Post_status { get; set; }
        public string Product_loc { get; set; }
        public string Product_color { get; set; }
        public string Product_make { get; set; }
        public string Product_model { get; set; }
        public string Product_year { get; set; }
        public string Product_mileage { get; set; }
        public string Product_trans { get; set; }
        public string Product_fuel { get; set; }
        public string Product_url { get; set; }

        public string ErrorMessage { get; set; }

        // For user selection
        public int SelectedUserId { get; set; } // To hold the selected user ID
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>(); // List of users for selection
    }
}
