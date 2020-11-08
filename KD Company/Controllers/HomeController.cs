﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using KD_Company.Migrations;
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
            //string Email = email;
           
            //string Password = password;
            UserAppDbContext dbContext = new UserAppDbContext();
          var userlist = dbContext.userDetails.ToList();
            var user=userlist.Where(X => X.Email == email && X.Password == password).FirstOrDefault();
            var list = dbContext.cardetails.ToList();
            if (user != null)
            {

                return View(list);
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
        [HttpGet]
        public IActionResult SingleProduct(int id)
        {
            //var id = cars.Id;
           
            UserAppDbContext dbContext = new UserAppDbContext();
            var list = dbContext.cardetails.ToList();
            CarDetails car = new CarDetails();
            car = list.Where(x => x.Id == id).FirstOrDefault();
            //ViewBag.name=car.FileName;
            
            return View(car);
        }
        public IActionResult Search()
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            var carlist = dbContext.cardetails.ToList();

            return View(carlist);
        }
        
        public IActionResult Forsearch(string searchtext)
        {
            UserAppDbContext dbcontext = new UserAppDbContext();
            var car = dbcontext.cardetails.ToList();
            var user = car.Where(X => X.BrandName == searchtext);

            return View(user);
        }
        public IActionResult ForBooking(Rentdays Rent)
        {
            int No = Rent.NoOfDays;
            int Id = Rent.Id;
            UserAppDbContext dbContext = new UserAppDbContext();
            var car = dbContext.cardetails.ToList();
            var cars = car.Where(X => X.Id == Id).FirstOrDefault();
            var Price = cars.Price;

            int Totalamount = Price * No;
            ViewBag.Number = No;
            ViewBag.id = Id;
            ViewBag.Total = Totalamount;


            return View(cars);
        }
        public IActionResult pay()
        {
           
            return View();
        }



    }
}

