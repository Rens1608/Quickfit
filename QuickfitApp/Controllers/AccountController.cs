using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using LogicLayer;
using Microsoft.AspNetCore.Session;

namespace QuickfitApp.Controllers
{

    public class AccountController : Controller
    {
        UserContainer userContainer = new UserContainer();
        User user = new User();
        
        public ActionResult Index()
        {
            UserModel currentUser = userContainer.FindById(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            return View(currentUser);
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
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                userModel.LoginErrorMessage = "Try again";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            try
            {
                userContainer.Add(user);
                return RedirectToAction("Index", user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            UserModel user = userContainer.FindById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserModel userModel)
        {
            try
            {
                user.UpdateUser(userModel.Id, userModel.Name, userModel.Age, userModel.Weight, userModel.Height, userModel.Gender);
                return RedirectToAction("Index", userModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            UserModel user = userContainer.FindById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(UserModel user)
        {
            try
            {
                userContainer.Delete(user.Id);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}