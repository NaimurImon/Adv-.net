using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHun.Models;

namespace ZeroHun.Controllers
{
    public class RegController : Controller
    {
        // GET: Reg
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            var db = new ZhungerEntities5();
            db.Users.Add(user);
            db.SaveChanges();
            TempData["msg"] = "Sucessfully Added";
            return RedirectToAction("RegIndex");
        }

        public ActionResult RegIndex()
        {

            var db = new ZhungerEntities5();
            var users = db.Users.ToList();
            return View(users);
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            TempData["msg"] = "Logged in successfully.";

            if (ModelState.IsValid)
            {
                using (var db = new ZhungerEntities5())
                {
                    var obj = db.Users.Where(a => a.email.Equals(user.email) && a.password.Equals(user.password)).FirstOrDefault();
                    if (obj != null)
                    {

                            return RedirectToAction("AdminDashBoard");
                        
                    }
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult AdminDashboard()
        {
            var db = new ZhungerEntities5();
            var odetails = db.Odetails.ToList();
            return View(odetails);
        }



        [HttpGet]
        public ActionResult RestaurantDashboard()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult RestaurantDetails()
        //{
        //    var db = new ZHungerEntities1();
        //    var users = db.Users.ToList();
        //    return View(users);
        //}

        [HttpPost]
        public ActionResult RestaurantDashboard(Odetail odetail)
        {
            var db = new ZhungerEntities5();
            db.Odetails.Add(odetail);
            db.SaveChanges();
            return RedirectToAction("Odetail");
        }

        [HttpGet]
        public ActionResult Odetail()
        {

            var db = new ZhungerEntities5();
            var odetails = db.Odetails.ToList();
            TempData["msg"] = "Successfully Added";
            return View(odetails);
        }


        [HttpGet]
        public ActionResult ResAdmin()
        {
            var db = new ZhungerEntities5();
            var users = db.Users.ToList();
            return View(users);
        }



    }
}