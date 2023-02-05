using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class AuthController : Controller
    {
        public AuthController() { }

        public async Task<IActionResult> Login()
        {
            await Task.Yield();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            // TODO: Your code here
            await Task.Yield();

            HttpContext.Session.SetInt32("user_id", user.user_id);
            HttpContext.Session.SetString("userName", user.user_name);
            HttpContext.Session.SetString("email", user.email);
            HttpContext.Session.SetString("password", user.password);

            return RedirectToAction(actionName: "Index", controllerName: "Principal");
        }


        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            HttpContext.Session.SetInt32("user_id", user.user_id);
            HttpContext.Session.SetString("userName", user.user_name);
            HttpContext.Session.SetString("email", user.email);
            HttpContext.Session.SetString("password", user.password);

            return RedirectToAction(actionName: "Index", controllerName: "Principal");
        }

        public async Task<IActionResult> LogOut()
        {
            await Task.Yield();

            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Principal");
        }

    }
}