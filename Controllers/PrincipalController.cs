using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Models;

namespace AspNetCore.Controllers
{
    public class PrincipalController : Controller
    {
        public PrincipalController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View(new UserSessionModel(){
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

            return View();
        }
    }
}