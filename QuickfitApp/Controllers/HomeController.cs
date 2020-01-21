using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuickfitApp.Models;
using Models;
using LogicLayer;
using Microsoft.AspNetCore.Http;

namespace QuickfitApp.Controllers
{
    public class HomeController : Controller
    {
        UserContainer userContainer = new UserContainer(AppSettingsJson.GetConnectionstring());
        User user = new User(AppSettingsJson.GetConnectionstring());

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            try
            {
                if (user.Login(userModel.Name, userModel.Password) == null)
                {
                    ModelState.AddModelError("Password", "Account not found");
                    return View();
                }
                else
                {
                    HttpContext.Session.SetInt32("UserId", user.Login(userModel.Name, userModel.Password).Id);
                    return RedirectToAction("Index", "Account");
                }
            }
            catch
            {
                ModelState.AddModelError("Password", "Something went wrong, try again!");
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            try
            {
                userContainer.Add(userModel);
                HttpContext.Session.SetInt32("UserId", user.Login(userModel.Name, userModel.Password).Id);
                return RedirectToAction("Index", user);
            }
            catch
            {
                ModelState.AddModelError("Gender", "Something was not filled in correctly, try again!");
                return View();
            }
        }
    }
}
