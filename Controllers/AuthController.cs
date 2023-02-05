using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Data;

namespace AspNetCore.Controllers
{
    public class AuthController : Controller
    {
        private readonly TaskGroupsContext db;

        public AuthController(TaskGroupsContext _db)
        {
            db = _db;
        }

        public async Task<IActionResult> Login()
        {
            await Task.Yield();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            var userFind = db.Users.AsEnumerable().SingleOrDefault((e) => e.email == user.email, null);

            if (userFind == null)
            {
                return BadRequest("No user register");
            }

            if (userFind.password != user.password)
            {
                return BadRequest("Password error");
            }

            HttpContext.Session.SetInt32("user_id", userFind.user_id);
            HttpContext.Session.SetString("user_name", userFind.user_name);
            HttpContext.Session.SetString("email", userFind.email);
            HttpContext.Session.SetString("password", userFind.password);

            return RedirectToAction(actionName: "Index", controllerName: "Principal");
        }


        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(500);
            }

            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();

            return RedirectToAction(actionName: "Index", controllerName: "Principal");
        }

        public async Task<IActionResult> LogOut()
        {
            await Task.Yield();

            HttpContext.Session.Clear();
            await HttpContext.Session.LoadAsync();

            return RedirectToAction("Index", "Principal");
        }

    }
}