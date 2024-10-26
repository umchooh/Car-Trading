using System.Globalization;
namespace CarTrading.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string roletype { get; set; }
    }
}
