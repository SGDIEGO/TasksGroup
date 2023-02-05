
using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class AssignmentModel
    {
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int group_id { get; set; }
        public bool administrator { get; set; } = false;
    }
}