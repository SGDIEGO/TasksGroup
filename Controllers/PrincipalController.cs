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
            var username = (HttpContext.Session.GetString("_user") == string.Empty) ? "null" : HttpContext.Session.GetString("_user");
            return View("Index", username);
        }

        public async Task<IActionResult> Groups()
        {
            await Task.Yield();

            return View();
        }
    }
}