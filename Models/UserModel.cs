
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class UserModel
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}