using Microsoft.EntityFrameworkCore;
using AspNetCore.Models;

namespace AspNetCore.Data
{
    public class TaskGroupsContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<AssignmentModel> Assingments { get; set; }
        public TaskGroupsContext(DbContextOptions<TaskGroupsContext> options) : base(options) { }
    }
}