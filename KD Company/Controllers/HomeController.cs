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
                
                var list = dbContext.cardetails.ToList();

                return View(list);
               
            }
        }

            public IActionResult Payment()
            {
                return View();
            }
        [HttpPost]
        public IActionResult Registration(UserDetails register)
        {
            using (UserAppDbContext user = new UserAppDbContext())
            {
                UserDetails us = new UserDetails();
                Email em = new Email();
                string pass = em.SendEmail(register.Email);
                register.Password = pass;
                //user.Add(us);
               
                user.userDetails.Add(register);
                user.SaveChanges();

            }
            
           

            return View();
        }

        public IActionResult AddFeedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForAddFeedback(Feedback feedbacks)
        {
            UserAppDbContext dbcontext = new UserAppDbContext();
            dbcontext.Feedbacks.Add(feedbacks);
            dbcontext.SaveChanges();
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }


    }
}

