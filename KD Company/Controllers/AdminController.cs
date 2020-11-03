using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KD_Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace KD_Company.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Home(string email,string password)
        {
            string Email = email;

            string Password = password;
            UserAppDbContext dbContext = new UserAppDbContext();
            var userlist = dbContext.adminlogins.ToList();
            var user = userlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();

            if (user != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

           
        }
        public IActionResult ViewUsers()
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            var list = dbContext.userDetails.ToList();

            return View(list);
        }
        public IActionResult CarList()
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            var list = dbContext.cardetails.ToList();

            return View(list);
        }
        public IActionResult AddCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveCar(CarDetails cars)
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            dbContext.Add(cars);
            dbContext.SaveChanges();
            return View();
        }
    }
}
