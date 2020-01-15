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
        UserContainer userContainer = new UserContainer(AppSettingsJson.GetConnectionstring());
        User user = new User(AppSettingsJson.GetConnectionstring());
        
        public ActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Index", "Home");
            }
            UserModel currentUser = userContainer.FindById(Convert.ToInt32(HttpContext.Session.GetInt32("UserId")));
            return View(currentUser);
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