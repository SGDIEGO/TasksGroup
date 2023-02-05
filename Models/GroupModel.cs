using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    public class GroupModel
    {
        [Key]
        public int group_id { get; set; }
        public string group_name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        [ForeignKey("user_id")]
        public UserModel? coord_id { get; set; }
        public int members { get; set; } = 0;
    }
}