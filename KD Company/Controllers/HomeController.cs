using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KD_Company.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Forlogin(string email, string password)
        {
            string Email = email;
            string Password = password;
            if (Email == "kd&company@gmail.com" && Password == "kdcompany")
            {

                return View();
            }
            else
            {
                return null;
            }
        }

            public IActionResult Payment()
            {
                return View();
            }

    }
}

