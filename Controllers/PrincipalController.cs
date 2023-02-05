using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;
using AspNetCore.Data;

namespace AspNetCore.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly TaskGroupsContext db;
        public AssignmentModel AM = new AssignmentModel();

        public PrincipalController(TaskGroupsContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Index()
        {
            return View(new UserSessionModel()
            {
                user_name = HttpContext.Session.GetString("user_name")!,
                email = HttpContext.Session.Id!,
                password = HttpContext.Session.GetString("password")!,
                isAvailable = HttpContext.Session.IsAvailable,
                Keys = HttpContext.Session.Keys
            });
        }

        public async Task<IActionResult> Groups()
        {
            await Task.Yield();
            var groups = db.Groups.ToList();

            return View( (groups, HttpContext.Session.Keys.Count()) );
        }

        public async Task<IActionResult> CreateGroups()
        {
            // TODO: Your code here
            await Task.Yield();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroups(GroupModel group)
        {
            group.coord_id = (int)HttpContext.Session.GetInt32("user_id");

            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }

            group.members++;
            await db.Groups.AddAsync(group);

            AM.user_id = (int)HttpContext.Session.GetInt32("user_id");
            AM.group_id = group.group_id;
            AM.administrator = true;
            await db.Assingments.AddAsync(AM);

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Users()
        {
            await Task.Yield();

            IEnumerable<UserModel> UsersList = db.Users.ToList();

            return View(UsersList);
        }

    }
}