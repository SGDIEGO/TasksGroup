
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class UserModel{
        public int user_id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password{ get; set; } = string.Empty;
    }    
}