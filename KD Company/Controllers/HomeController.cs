using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using KD_Company.Models;
using KD_Company.utill;
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
            UserAppDbContext dbContext = new UserAppDbContext();
          var userlist = dbContext.userDetails.ToList();
            var user=userlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();

            if (user !=null)
            {

                return View();
            }
            else
            {
               return RedirectToAction("Login");
            }
        }

            public IActionResult Payment()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Registration(UserDetails register)
        {
            UserAppDbContext user = new UserAppDbContext();
            UserDetails us = new UserDetails();
            us.Name = register.Name;
            us.Phonenumber = register.Phonenumber;
            us.Pincode = register.Pincode;
            us.Place = register.Place;
            us.Email = register.Email;
            us.City = register.City;
            Console.WriteLine(register.Phonenumber);
            Email em = new Email();
           string pass=em.SendEmail(register.Email);
            us.Password = pass;
            user.Add(us);
            user.SaveChanges();

            return View();
        }

    }
}

