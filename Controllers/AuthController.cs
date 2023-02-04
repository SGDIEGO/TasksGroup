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
        public UserModel userR = new();
        // Session storage
        public const string userName = "_user";

        public AuthController()
        {
            
        }

        public async Task<IActionResult> Login()
        {
            await Task.Yield();

            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            HttpContext.Session.SetString(userName, user.userName);
            return RedirectToAction(actionName: "Index", controllerName: "Principal");
        }
    }
}