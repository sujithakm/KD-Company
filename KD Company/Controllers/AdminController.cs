using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KD_Company.Migrations;
using KD_Company.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

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
        public async Task<IActionResult> SaveCarAsync(CarDetails cars)
        {
        

            if (cars.FileToUpload == null || cars.FileToUpload.Length == 0)
                return Content("file not selected");
            //string path = (@"C:\Users\nithe\Source\Repos\KD-Company\KD Company\wwwroot\Car\");
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Car",
                       cars.FileToUpload.FileName);
            Console.WriteLine(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await cars.FileToUpload.CopyToAsync(stream);
            }
            
            cars.FileName = cars.FileToUpload.FileName;
            UserAppDbContext dbContext = new UserAppDbContext();
            dbContext.cardetails.Add(cars);
            dbContext.SaveChanges();
            return View();
        }
        public IActionResult ViewFeedback()
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            var list = dbContext.Feedbacks.ToList();

            return View(list);
        }
        public IActionResult ViewnNotification()
        {
           

            return View();
        }
        public IActionResult Delete(int id)
        {
            UserAppDbContext dbContext = new UserAppDbContext();
            var list = dbContext.cardetails.Where(x => x.Id == id).First();
            dbContext.cardetails.Remove(list);
            dbContext.SaveChanges();

            return RedirectToAction("CarList");
        }
        public IActionResult Update(int id)
        {
            UserAppDbContext dbContext = new UserAppDbContext();
           var car= dbContext.cardetails.Where(x => x.Id == id).FirstOrDefault();
            return View(car);
        }
        [HttpPost]
        public IActionResult UpdateCar(CarDetails cars)
        {
           using( UserAppDbContext dbContext = new UserAppDbContext())
           {
                dbContext.cardetails.Update(cars);
                dbContext.SaveChanges();

            }
            return RedirectToAction("CarList");
        }
    }
}
