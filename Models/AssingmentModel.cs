
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCore.Models
{
    public class AssignmentModel
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("user_id")]
        public UserModel? user_id { get; set; }
        [ForeignKey("group_id")]
        public GroupModel? group_id { get; set; }
        public bool administrator { get; set; } = false;
    }
}