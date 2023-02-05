using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class GroupModel
    {
        [Key]
        public int group_id { get; set; }
        public string group_name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int coord_id { get; set; }
        public int members { get; set; }
        
    }
}